using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisitCharges;
using FSM.Entity.EngineerVisits;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers.Enums;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMEngineerVisit : FRMBaseForm, IForm
    {
        // SEE LAST REGION FOR ALL CHARGE PAGE CODE - ALP

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal GroupBox grpUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpUsed != null)
                {
                }

                _grpUsed = value;
                if (_grpUsed != null)
                {
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

        internal Button btnRemovePartProductUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemovePartProductUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemovePartProductUsed != null)
                {
                    _btnRemovePartProductUsed.Click -= btnRemovePartProduct_Click;
                }

                _btnRemovePartProductUsed = value;
                if (_btnRemovePartProductUsed != null)
                {
                    _btnRemovePartProductUsed.Click += btnRemovePartProduct_Click;
                }
            }
        }

        private Button _btnFindProductUsed;

        internal Button btnFindProductUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindProductUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindProductUsed != null)
                {
                    _btnFindProductUsed.Click -= btnFindProduct_Click;
                }

                _btnFindProductUsed = value;
                if (_btnFindProductUsed != null)
                {
                    _btnFindProductUsed.Click += btnFindProduct_Click;
                }
            }
        }

        private Button _btnFindPartUsed;

        internal Button btnFindPartUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindPartUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindPartUsed != null)
                {
                    _btnFindPartUsed.Click -= btnFindPart_Click;
                }

                _btnFindPartUsed = value;
                if (_btnFindPartUsed != null)
                {
                    _btnFindPartUsed.Click += btnFindPart_Click;
                }
            }
        }

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

        internal Button btnAddTimeSheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddTimeSheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddTimeSheet != null)
                {
                    _btnAddTimeSheet.Click -= btnAddTimeSheet_Click;
                }

                _btnAddTimeSheet = value;
                if (_btnAddTimeSheet != null)
                {
                    _btnAddTimeSheet.Click += btnAddTimeSheet_Click;
                }
            }
        }

        private Label _Label20;

        internal Label Label20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label20 != null)
                {
                }

                _Label20 = value;
                if (_Label20 != null)
                {
                }
            }
        }

        private Label _Label21;

        internal Label Label21
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label21;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label21 != null)
                {
                }

                _Label21 = value;
                if (_Label21 != null)
                {
                }
            }
        }

        private Button _btnRemoveTimeSheet;

        internal Button btnRemoveTimeSheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveTimeSheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveTimeSheet != null)
                {
                    _btnRemoveTimeSheet.Click -= btnRemoveTimeSheet_Click;
                }

                _btnRemoveTimeSheet = value;
                if (_btnRemoveTimeSheet != null)
                {
                    _btnRemoveTimeSheet.Click += btnRemoveTimeSheet_Click;
                }
            }
        }

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

        internal Label Label22
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label22;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label22 != null)
                {
                }

                _Label22 = value;
                if (_Label22 != null)
                {
                }
            }
        }

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

        internal Label Label26
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label26;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label26 != null)
                {
                }

                _Label26 = value;
                if (_Label26 != null)
                {
                }
            }
        }

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

        internal Label Label27
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label27;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label27 != null)
                {
                }

                _Label27 = value;
                if (_Label27 != null)
                {
                }
            }
        }

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

        internal Label Label29
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label29;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label29 != null)
                {
                }

                _Label29 = value;
                if (_Label29 != null)
                {
                }
            }
        }

        private Label _lblDescription;

        internal Label lblDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDescription != null)
                {
                }

                _lblDescription = value;
                if (_lblDescription != null)
                {
                }
            }
        }

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

        internal Button btnRemoveAdditionalCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveAdditionalCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveAdditionalCharge != null)
                {
                    _btnRemoveAdditionalCharge.Click -= btnRemoveAdditionalCharge_Click;
                }

                _btnRemoveAdditionalCharge = value;
                if (_btnRemoveAdditionalCharge != null)
                {
                    _btnRemoveAdditionalCharge.Click += btnRemoveAdditionalCharge_Click;
                }
            }
        }

        private Button _btnAddAdditionalCharge;

        internal Button btnAddAdditionalCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddAdditionalCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddAdditionalCharge != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnAddAdditionalCharge.Click -= btnAddAdditionalCharge_Click;
                }

                _btnAddAdditionalCharge = value;
                if (_btnAddAdditionalCharge != null)
                {
                    _btnAddAdditionalCharge.Click += btnAddAdditionalCharge_Click;
                }
            }
        }

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

        internal Label Label30
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label30;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label30 != null)
                {
                }

                _Label30 = value;
                if (_Label30 != null)
                {
                }
            }
        }

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

        internal Label Label32
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label32;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label32 != null)
                {
                }

                _Label32 = value;
                if (_Label32 != null)
                {
                }
            }
        }

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

        internal GroupBox grpAllocated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAllocated;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAllocated != null)
                {
                }

                _grpAllocated = value;
                if (_grpAllocated != null)
                {
                }
            }
        }

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

        internal Button btnAllocatedNotUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAllocatedNotUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAllocatedNotUsed != null)
                {
                    _btnAllocatedNotUsed.Click -= btnAllocatedNotUsed_Click;
                }

                _btnAllocatedNotUsed = value;
                if (_btnAllocatedNotUsed != null)
                {
                    _btnAllocatedNotUsed.Click += btnAllocatedNotUsed_Click;
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

        private Label _Label34;

        internal Label Label34
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label34;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label34 != null)
                {
                }

                _Label34 = value;
                if (_Label34 != null)
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

        private Label _Label35;

        internal Label Label35
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label35;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label35 != null)
                {
                }

                _Label35 = value;
                if (_Label35 != null)
                {
                }
            }
        }

        private Button _btnAllUsed;

        internal Button btnAllUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAllUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAllUsed != null)
                {
                    _btnAllUsed.Click -= btnAllUsed_Click;
                }

                _btnAllUsed = value;
                if (_btnAllUsed != null)
                {
                    _btnAllUsed.Click += btnAllUsed_Click;
                }
            }
        }

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

        internal Button btnPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrint != null)
                {
                    _btnPrint.Click -= btnPrint_Click;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click;
                }
            }
        }

        private Button _btnAddSoR;

        internal Button btnAddSoR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddSoR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddSoR != null)
                {
                    _btnAddSoR.Click -= btnAddSoR_Click;
                }

                _btnAddSoR = value;
                if (_btnAddSoR != null)
                {
                    _btnAddSoR.Click += btnAddSoR_Click;
                }
            }
        }

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

        internal Label Label39
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label39;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label39 != null)
                {
                }

                _Label39 = value;
                if (_Label39 != null)
                {
                }
            }
        }

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

        private Label _Label40;

        internal Label Label40
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label40;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label40 != null)
                {
                }

                _Label40 = value;
                if (_Label40 != null)
                {
                }
            }
        }

        private Label _Label41;

        internal Label Label41
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label41;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label41 != null)
                {
                }

                _Label41 = value;
                if (_Label41 != null)
                {
                }
            }
        }

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

        internal Label Label42
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label42;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label42 != null)
                {
                }

                _Label42 = value;
                if (_Label42 != null)
                {
                }
            }
        }

        private Label _Label43;

        internal Label Label43
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label43;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label43 != null)
                {
                }

                _Label43 = value;
                if (_Label43 != null)
                {
                }
            }
        }

        private Label _Label44;

        internal Label Label44
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label44;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label44 != null)
                {
                }

                _Label44 = value;
                if (_Label44 != null)
                {
                }
            }
        }

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

        internal ToolStripMenuItem mnuGasSafetyInspectionBoilerServiceRecord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuGasSafetyInspectionBoilerServiceRecord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuGasSafetyInspectionBoilerServiceRecord != null)
                {
                }

                _mnuGasSafetyInspectionBoilerServiceRecord = value;
                if (_mnuGasSafetyInspectionBoilerServiceRecord != null)
                {
                }
            }
        }

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

        internal Label lblDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDepartment != null)
                {
                }

                _lblDepartment = value;
                if (_lblDepartment != null)
                {
                }
            }
        }

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

        internal Label lblNominalCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNominalCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNominalCode != null)
                {
                }

                _lblNominalCode = value;
                if (_lblNominalCode != null)
                {
                }
            }
        }

        private Button _btnPrintGSR;

        internal Button btnPrintGSR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintGSR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintGSR != null)
                {
                    _btnPrintGSR.Click -= btnPrintGSR_Click;
                }

                _btnPrintGSR = value;
                if (_btnPrintGSR != null)
                {
                    _btnPrintGSR.Click += btnPrintGSR_Click;
                }
            }
        }

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

        internal GroupBox gpAppliances
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpAppliances;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpAppliances != null)
                {
                }

                _gpAppliances = value;
                if (_gpAppliances != null)
                {
                }
            }
        }

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

        internal GroupBox grpOutcomes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpOutcomes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpOutcomes != null)
                {
                }

                _grpOutcomes = value;
                if (_grpOutcomes != null)
                {
                }
            }
        }

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

        internal GroupBox GroupBox4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox4 != null)
                {
                }

                _GroupBox4 = value;
                if (_GroupBox4 != null)
                {
                }
            }
        }

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

        internal Button btnJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnJob != null)
                {
                    _btnJob.Click -= btnJob_Click;
                }

                _btnJob = value;
                if (_btnJob != null)
                {
                    _btnJob.Click += btnJob_Click;
                }
            }
        }

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

        internal Label Label57
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label57;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label57 != null)
                {
                }

                _Label57 = value;
                if (_Label57 != null)
                {
                }
            }
        }

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

        internal Label Label58
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label58;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label58 != null)
                {
                }

                _Label58 = value;
                if (_Label58 != null)
                {
                }
            }
        }

        private Label _Label59;

        internal Label Label59
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label59;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label59 != null)
                {
                }

                _Label59 = value;
                if (_Label59 != null)
                {
                }
            }
        }

        private Label _Label60;

        internal Label Label60
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label60;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label60 != null)
                {
                }

                _Label60 = value;
                if (_Label60 != null)
                {
                }
            }
        }

        private Label _Label61;

        internal Label Label61
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label61;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label61 != null)
                {
                }

                _Label61 = value;
                if (_Label61 != null)
                {
                }
            }
        }

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

        internal Label Label68
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label68;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label68 != null)
                {
                }

                _Label68 = value;
                if (_Label68 != null)
                {
                }
            }
        }

        private Label _Label69;

        internal Label Label69
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label69;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label69 != null)
                {
                }

                _Label69 = value;
                if (_Label69 != null)
                {
                }
            }
        }

        private Label _Label70;

        internal Label Label70
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label70;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label70 != null)
                {
                }

                _Label70 = value;
                if (_Label70 != null)
                {
                }
            }
        }

        private Label _Label62;

        internal Label Label62
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label62;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label62 != null)
                {
                }

                _Label62 = value;
                if (_Label62 != null)
                {
                }
            }
        }

        private Label _Label63;

        internal Label Label63
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label63;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label63 != null)
                {
                }

                _Label63 = value;
                if (_Label63 != null)
                {
                }
            }
        }

        private Label _Label64;

        internal Label Label64
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label64;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label64 != null)
                {
                }

                _Label64 = value;
                if (_Label64 != null)
                {
                }
            }
        }

        private Label _Label65;

        internal Label Label65
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label65;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label65 != null)
                {
                }

                _Label65 = value;
                if (_Label65 != null)
                {
                }
            }
        }

        private Label _Label66;

        internal Label Label66
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label66;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label66 != null)
                {
                }

                _Label66 = value;
                if (_Label66 != null)
                {
                }
            }
        }

        private Label _Label67;

        internal Label Label67
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label67;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label67 != null)
                {
                }

                _Label67 = value;
                if (_Label67 != null)
                {
                }
            }
        }

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

        internal Label Label56
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label56;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label56 != null)
                {
                }

                _Label56 = value;
                if (_Label56 != null)
                {
                }
            }
        }

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

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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

        internal Label Label71
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label71;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label71 != null)
                {
                }

                _Label71 = value;
                if (_Label71 != null)
                {
                }
            }
        }

        private Button _btnShowVisits;

        internal Button btnShowVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnShowVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnShowVisits != null)
                {
                    _btnShowVisits.Click -= btnShowVisits_Click;
                }

                _btnShowVisits = value;
                if (_btnShowVisits != null)
                {
                    _btnShowVisits.Click += btnShowVisits_Click;
                }
            }
        }

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

        internal GroupBox GroupBox6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox6 != null)
                {
                }

                _GroupBox6 = value;
                if (_GroupBox6 != null)
                {
                }
            }
        }

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

        internal TabPage tpPhotos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpPhotos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpPhotos != null)
                {
                    _tpPhotos.Enter -= tpPhotos_Enter;
                }

                _tpPhotos = value;
                if (_tpPhotos != null)
                {
                    _tpPhotos.Enter += tpPhotos_Enter;
                }
            }
        }

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

        internal Label Label74
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label74;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label74 != null)
                {
                }

                _Label74 = value;
                if (_Label74 != null)
                {
                }
            }
        }

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

        internal Label Label75
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label75;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label75 != null)
                {
                }

                _Label75 = value;
                if (_Label75 != null)
                {
                }
            }
        }

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

        internal Label Label76
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label76;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label76 != null)
                {
                }

                _Label76 = value;
                if (_Label76 != null)
                {
                }
            }
        }

        private ToolStripPanel _BottomToolStripPanel;

        internal ToolStripPanel BottomToolStripPanel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BottomToolStripPanel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BottomToolStripPanel != null)
                {
                }

                _BottomToolStripPanel = value;
                if (_BottomToolStripPanel != null)
                {
                }
            }
        }

        private ToolStripPanel _TopToolStripPanel;

        internal ToolStripPanel TopToolStripPanel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TopToolStripPanel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TopToolStripPanel != null)
                {
                }

                _TopToolStripPanel = value;
                if (_TopToolStripPanel != null)
                {
                }
            }
        }

        private ToolStripPanel _RightToolStripPanel;

        internal ToolStripPanel RightToolStripPanel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RightToolStripPanel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RightToolStripPanel != null)
                {
                }

                _RightToolStripPanel = value;
                if (_RightToolStripPanel != null)
                {
                }
            }
        }

        private ToolStripPanel _LeftToolStripPanel;

        internal ToolStripPanel LeftToolStripPanel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LeftToolStripPanel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LeftToolStripPanel != null)
                {
                }

                _LeftToolStripPanel = value;
                if (_LeftToolStripPanel != null)
                {
                }
            }
        }

        private ToolStripContentPanel _ContentPanel;

        internal ToolStripContentPanel ContentPanel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContentPanel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContentPanel != null)
                {
                }

                _ContentPanel = value;
                if (_ContentPanel != null)
                {
                }
            }
        }

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

        internal Label Label81
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label81;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label81 != null)
                {
                }

                _Label81 = value;
                if (_Label81 != null)
                {
                }
            }
        }

        private Label _Label80;

        internal Label Label80
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label80;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label80 != null)
                {
                }

                _Label80 = value;
                if (_Label80 != null)
                {
                }
            }
        }

        private Label _Label79;

        internal Label Label79
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label79;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label79 != null)
                {
                }

                _Label79 = value;
                if (_Label79 != null)
                {
                }
            }
        }

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

        internal Button btnRemoveSmokeComo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveSmokeComo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveSmokeComo != null)
                {
                    _btnRemoveSmokeComo.Click -= btnRemoveSmokeComo_Click;
                }

                _btnRemoveSmokeComo = value;
                if (_btnRemoveSmokeComo != null)
                {
                    _btnRemoveSmokeComo.Click += btnRemoveSmokeComo_Click;
                }
            }
        }

        private Button _btnAddSmokeComo;

        internal Button btnAddSmokeComo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddSmokeComo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddSmokeComo != null)
                {
                    _btnAddSmokeComo.Click -= btnAddSmokeComo_Click;
                }

                _btnAddSmokeComo = value;
                if (_btnAddSmokeComo != null)
                {
                    _btnAddSmokeComo.Click += btnAddSmokeComo_Click;
                }
            }
        }

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

        internal ToolStripMenuItem svrmenu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _svrmenu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_svrmenu != null)
                {
                    _svrmenu.Click -= svrmenu_Click;
                }

                _svrmenu = value;
                if (_svrmenu != null)
                {
                    _svrmenu.Click += svrmenu_Click;
                }
            }
        }

        private ToolStripMenuItem _JobSheetMenu;

        internal ToolStripMenuItem JobSheetMenu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _JobSheetMenu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_JobSheetMenu != null)
                {
                    _JobSheetMenu.Click -= JobSheetMenu_Click;
                }

                _JobSheetMenu = value;
                if (_JobSheetMenu != null)
                {
                    _JobSheetMenu.Click += JobSheetMenu_Click;
                }
            }
        }

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

        internal Label Label73
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label73;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label73 != null)
                {
                }

                _Label73 = value;
                if (_Label73 != null)
                {
                }
            }
        }

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

        internal Label Label72
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label72;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label72 != null)
                {
                }

                _Label72 = value;
                if (_Label72 != null)
                {
                }
            }
        }

        private Label _Label82;

        internal Label Label82
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label82;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label82 != null)
                {
                }

                _Label82 = value;
                if (_Label82 != null)
                {
                }
            }
        }

        private Label _Label78;

        internal Label Label78
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label78;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label78 != null)
                {
                }

                _Label78 = value;
                if (_Label78 != null)
                {
                }
            }
        }

        private Label _Label77;

        internal Label Label77
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label77;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label77 != null)
                {
                }

                _Label77 = value;
                if (_Label77 != null)
                {
                }
            }
        }

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

        internal Label lblPPTotalCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPPTotalCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPPTotalCost != null)
                {
                }

                _lblPPTotalCost = value;
                if (_lblPPTotalCost != null)
                {
                }
            }
        }

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

        internal Label Label28
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label28;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label28 != null)
                {
                }

                _Label28 = value;
                if (_Label28 != null)
                {
                }
            }
        }

        private GroupBox _GroupBox9;

        internal GroupBox GroupBox9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox9 != null)
                {
                }

                _GroupBox9 = value;
                if (_GroupBox9 != null)
                {
                }
            }
        }

        private RadioButton _rbStandard;

        internal RadioButton rbStandard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbStandard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbStandard != null)
                {
                }

                _rbStandard = value;
                if (_rbStandard != null)
                {
                }
            }
        }

        private RadioButton _rbSite;

        internal RadioButton rbSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbSite != null)
                {
                }

                _rbSite = value;
                if (_rbSite != null)
                {
                }
            }
        }

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

        internal Button btnRevertUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRevertUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRevertUsed != null)
                {
                    _btnRevertUsed.Click -= btnRevertUsed_Click;
                }

                _btnRevertUsed = value;
                if (_btnRevertUsed != null)
                {
                    _btnRevertUsed.Click += btnRevertUsed_Click;
                }
            }
        }

        private GroupBox _grpOfficeQC;

        internal GroupBox grpOfficeQC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpOfficeQC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpOfficeQC != null)
                {
                }

                _grpOfficeQC = value;
                if (_grpOfficeQC != null)
                {
                }
            }
        }

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

        internal Label lblJobTypeCorrect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobTypeCorrect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobTypeCorrect != null)
                {
                }

                _lblJobTypeCorrect = value;
                if (_lblJobTypeCorrect != null)
                {
                }
            }
        }

        private GroupBox _grpQCField;

        internal GroupBox grpQCField
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpQCField;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpQCField != null)
                {
                }

                _grpQCField = value;
                if (_grpQCField != null)
                {
                }
            }
        }

        private Label _lblQCPoorJobNotes;

        internal Label lblQCPoorJobNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCPoorJobNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCPoorJobNotes != null)
                {
                }

                _lblQCPoorJobNotes = value;
                if (_lblQCPoorJobNotes != null)
                {
                }
            }
        }

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

        internal Label lblQCEngineerMonies
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCEngineerMonies;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCEngineerMonies != null)
                {
                }

                _lblQCEngineerMonies = value;
                if (_lblQCEngineerMonies != null)
                {
                }
            }
        }

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

        internal Label lblQCEngPaymentMethod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCEngPaymentMethod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCEngPaymentMethod != null)
                {
                }

                _lblQCEngPaymentMethod = value;
                if (_lblQCEngPaymentMethod != null)
                {
                }
            }
        }

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

        internal Label lblQCPaymentCollection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCPaymentCollection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCPaymentCollection != null)
                {
                }

                _lblQCPaymentCollection = value;
                if (_lblQCPaymentCollection != null)
                {
                }
            }
        }

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

        internal Label lblQCAppliance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCAppliance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCAppliance != null)
                {
                }

                _lblQCAppliance = value;
                if (_lblQCAppliance != null)
                {
                }
            }
        }

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

        internal Label lblJobUploadTimescale
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobUploadTimescale;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobUploadTimescale != null)
                {
                }

                _lblJobUploadTimescale = value;
                if (_lblJobUploadTimescale != null)
                {
                }
            }
        }

        private Label _lblQCParts;

        internal Label lblQCParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCParts != null)
                {
                }

                _lblQCParts = value;
                if (_lblQCParts != null)
                {
                }
            }
        }

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

        internal Label lblQCLGSR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCLGSR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCLGSR != null)
                {
                }

                _lblQCLGSR = value;
                if (_lblQCLGSR != null)
                {
                }
            }
        }

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

        internal Label lblQCLabourTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCLabourTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCLabourTime != null)
                {
                }

                _lblQCLabourTime = value;
                if (_lblQCLabourTime != null)
                {
                }
            }
        }

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

        internal Label lblOrderNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderNo != null)
                {
                }

                _lblOrderNo = value;
                if (_lblOrderNo != null)
                {
                }
            }
        }

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

        internal Label lblScheduleRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblScheduleRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblScheduleRate != null)
                {
                }

                _lblScheduleRate = value;
                if (_lblScheduleRate != null)
                {
                }
            }
        }

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

        internal Label lblCustomerDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomerDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomerDetails != null)
                {
                }

                _lblCustomerDetails = value;
                if (_lblCustomerDetails != null)
                {
                }
            }
        }

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

        internal Button btnUnselectAllPPA
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUnselectAllPPA;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUnselectAllPPA != null)
                {
                    _btnUnselectAllPPA.Click -= btnUnselectAllPPA_Click;
                }

                _btnUnselectAllPPA = value;
                if (_btnUnselectAllPPA != null)
                {
                    _btnUnselectAllPPA.Click += btnUnselectAllPPA_Click;
                }
            }
        }

        private Button _btnSelectAllPPA;

        internal Button btnSelectAllPPA
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAllPPA;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAllPPA != null)
                {
                    _btnSelectAllPPA.Click -= btnSelectAllPPA_Click;
                }

                _btnSelectAllPPA = value;
                if (_btnSelectAllPPA != null)
                {
                    _btnSelectAllPPA.Click += btnSelectAllPPA_Click;
                }
            }
        }

        private GroupBox _grpSiteFuels;

        internal GroupBox grpSiteFuels
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteFuels;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteFuels != null)
                {
                }

                _grpSiteFuels = value;
                if (_grpSiteFuels != null)
                {
                }
            }
        }

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

        internal Label Label52
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label52;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label52 != null)
                {
                }

                _Label52 = value;
                if (_Label52 != null)
                {
                }
            }
        }

        private Label _Label51;

        internal Label Label51
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label51;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label51 != null)
                {
                }

                _Label51 = value;
                if (_Label51 != null)
                {
                }
            }
        }

        private Label _Label50;

        internal Label Label50
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label50;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label50 != null)
                {
                }

                _Label50 = value;
                if (_Label50 != null)
                {
                }
            }
        }

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

        internal Label Label49
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label49;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label49 != null)
                {
                }

                _Label49 = value;
                if (_Label49 != null)
                {
                }
            }
        }

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

        internal Label Label48
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label48;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label48 != null)
                {
                }

                _Label48 = value;
                if (_Label48 != null)
                {
                }
            }
        }

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

        internal Label lblQCCustSig
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQCCustSig;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQCCustSig != null)
                {
                }

                _lblQCCustSig = value;
                if (_lblQCCustSig != null)
                {
                }
            }
        }

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

        internal Label lblAdditionalCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAdditionalCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAdditionalCharge != null)
                {
                }

                _lblAdditionalCharge = value;
                if (_lblAdditionalCharge != null)
                {
                }
            }
        }

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
            components = new System.ComponentModel.Container();
            _tcWorkSheet = new TabControl();
            _tpMainDetails = new TabPage();
            _chkSORDesc = new CheckBox();
            _chkSORDesc.CheckedChanged += new EventHandler(chkSORDesc_CheckedChanged);
            _btnEditInvoiceNotes = new Button();
            _btnEditInvoiceNotes.Click += new EventHandler(btnEditInvoiceNotes_Click);
            _txtScheduledTime2 = new TextBox();
            _Label71 = new Label();
            _btnChangeOutcome = new Button();
            _btnChangeOutcome.Click += new EventHandler(btnChangeOutcome_Click);
            _pbCustomerSignature = new PictureBox();
            _pbEngineerSignature = new PictureBox();
            _cbxEmailReceiptToCustomer = new CheckBox();
            _cboSignatureSelected = new ComboBox();
            _Label42 = new Label();
            _dgJobItems = new DataGrid();
            _dgJobItems.CurrentCellChanged += new EventHandler(dgJobItems_CurrentCellChanged);
            _Label12 = new Label();
            _txtNotesToEngineer = new TextBox();
            _Label6 = new Label();
            _txtCustomer = new TextBox();
            _cboEngineer = new ComboBox();
            _txtNotesFromEngineer = new TextBox();
            _cboOutcome = new ComboBox();
            _cboOutcome.SelectedIndexChanged += new EventHandler(cboOutcome_SelectedIndexChanged);
            _txtOutcomeDetails = new TextBox();
            _Label11 = new Label();
            _txtUploadedBy = new TextBox();
            _txtStatus = new TextBox();
            _Label9 = new Label();
            _Label5 = new Label();
            _Label4 = new Label();
            _Label3 = new Label();
            _Label2 = new Label();
            _Label1 = new Label();
            _tpAppliances = new TabPage();
            _gpAppliances = new GroupBox();
            _dgAssets = new DataGrid();
            _tpWorksheets = new TabPage();
            _grpAdditionalWorksheet = new GroupBox();
            _btnRemoveAdd = new Button();
            _btnAddAdd = new Button();
            _dgAdditional = new DataGrid();
            _dgAdditional.DoubleClick += new EventHandler(dgAdditionalWorkSheets_DoubleClick);
            _grpAlarmInfo = new GroupBox();
            _btnRemoveSmokeComo = new Button();
            _btnRemoveSmokeComo.Click += new EventHandler(btnRemoveSmokeComo_Click);
            _btnAddSmokeComo = new Button();
            _btnAddSmokeComo.Click += new EventHandler(btnAddSmokeComo_Click);
            _DGSmokeComo = new DataGrid();
            _DGSmokeComo.DoubleClick += new EventHandler(dgSmokeComoWorkSheets_DoubleClick);
            _grpVisitWorksheetExtended = new GroupBox();
            _cboSITimer = new ComboBox();
            _cboFillDisc = new ComboBox();
            _Label81 = new Label();
            _Label80 = new Label();
            _Label79 = new Label();
            _txtRadiators = new TextBox();
            _txtVisualInspectionReason = new TextBox();
            _Label68 = new Label();
            _Label69 = new Label();
            _Label70 = new Label();
            _Label62 = new Label();
            _Label63 = new Label();
            _Label64 = new Label();
            _Label65 = new Label();
            _Label66 = new Label();
            _Label67 = new Label();
            _cboCertificateTypeID = new ComboBox();
            _cboCODetectorFittedID = new ComboBox();
            _cboVisualInspectionSatisfactoryID = new ComboBox();
            _cboImmersionID = new ComboBox();
            _cboJacketID = new ComboBox();
            _cboCylinderTypeID = new ComboBox();
            _cboPartialHeatingID = new ComboBox();
            _cboHeatingSystemTypeID = new ComboBox();
            _txtApproxAgeOfBoiler = new TextBox();
            _cboStrainerInspectedID = new ComboBox();
            _Label56 = new Label();
            _Label57 = new Label();
            _cboStrainerFittedID = new ComboBox();
            _cboInstallationSafeToUseID = new ComboBox();
            _cboInstallationPipeWorkCorrectID = new ComboBox();
            _cboCorrectMaterialsUsedID = new ComboBox();
            _Label58 = new Label();
            _Label59 = new Label();
            _Label60 = new Label();
            _Label61 = new Label();
            _grpVisitDefects = new GroupBox();
            _btnAddVisitDefect = new Button();
            _btnAddVisitDefect.Click += new EventHandler(btnAddVisitDefect_Click);
            _btnRemoveVisitDefect = new Button();
            _btnRemoveVisitDefect.Click += new EventHandler(btnRemoveVisitDefect_Click);
            _dgVisitDefects = new DataGrid();
            _dgVisitDefects.DoubleClick += new EventHandler(dgVisitDefects_DoubleClick);
            _grpApplianceWorksheet = new GroupBox();
            _btnRemoveApplianceWorkSheet = new Button();
            _btnRemoveApplianceWorkSheet.Click += new EventHandler(btnRemoveApplianceWorkSheet_Click);
            _dgApplianceWorkSheets = new DataGrid();
            _dgApplianceWorkSheets.DoubleClick += new EventHandler(dgApplianceWorkSheets_DoubleClick);
            _btnAddApplianceWorksheet = new Button();
            _btnAddApplianceWorksheet.Click += new EventHandler(btnAddApplianceWorksheet_Click);
            _grpVisitWorksheet = new GroupBox();
            _cboMeterCapped = new ComboBox();
            _Label73 = new Label();
            _cboMeterLocation = new ComboBox();
            _Label72 = new Label();
            _txtAmountCollected = new TextBox();
            _cboPaymentMethod = new ComboBox();
            _Label44 = new Label();
            _Label43 = new Label();
            _cboPropertyRented = new ComboBox();
            _cboBonding = new ComboBox();
            _cboEmergencyControlAccessible = new ComboBox();
            _cboGasInstallationTightnessTest = new ComboBox();
            _Label41 = new Label();
            _Label40 = new Label();
            _Label8 = new Label();
            _Label7 = new Label();
            _tpTimesheets = new TabPage();
            _grpTimesheets = new GroupBox();
            _txtActualTimeSpent = new TextBox();
            _txtDifference = new TextBox();
            _txtSORTimeAllowance = new TextBox();
            _Label52 = new Label();
            _Label51 = new Label();
            _Label50 = new Label();
            _Label22 = new Label();
            _cboTimeSheetType = new ComboBox();
            _Label14 = new Label();
            _txtComments = new TextBox();
            _dtpEndDate = new DateTimePicker();
            _dtpStartDate = new DateTimePicker();
            _dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            _dgTimeSheets = new DataGrid();
            _btnAddTimeSheet = new Button();
            _btnAddTimeSheet.Click += new EventHandler(btnAddTimeSheet_Click);
            _Label20 = new Label();
            _Label21 = new Label();
            _btnRemoveTimeSheet = new Button();
            _btnRemoveTimeSheet.Click += new EventHandler(btnRemoveTimeSheet_Click);
            _txtScheduledTime = new TextBox();
            _Label10 = new Label();
            _tpPartsAndProducts = new TabPage();
            _grpAllocated = new GroupBox();
            _btnUnselectAllPPA = new Button();
            _btnUnselectAllPPA.Click += new EventHandler(btnUnselectAllPPA_Click);
            _btnSelectAllPPA = new Button();
            _btnSelectAllPPA.Click += new EventHandler(btnSelectAllPPA_Click);
            _btnRevertUsed = new Button();
            _btnRevertUsed.Click += new EventHandler(btnRevertUsed_Click);
            _nudPartAllocatedQty = new NumericUpDown();
            _lblAllocatedQuantity = new Label();
            _btnAllUsed = new Button();
            _btnAllUsed.Click += new EventHandler(btnAllUsed_Click);
            _Label35 = new Label();
            _Panel2 = new Panel();
            _Label34 = new Label();
            _Panel1 = new Panel();
            _btnAllocatedNotUsed = new Button();
            _btnAllocatedNotUsed.Click += new EventHandler(btnAllocatedNotUsed_Click);
            _dgPartsProductsAllocated = new DataGrid();
            _dgPartsProductsAllocated.Click += new EventHandler(dgPartsProductsAllocated_Click);
            _lblQuantityWarning = new Label();
            _grpUsed = new GroupBox();
            _lblEquipment = new Label();
            _lblSellPrice = new Label();
            _dgPartsAndProductsUsed = new DataGrid();
            _btnAddPartProductUsed = new Button();
            _btnAddPartProductUsed.Click += new EventHandler(btnAddPartProduct_Click);
            _nudQuantityUsed = new NumericUpDown();
            _txtNameUsed = new TextBox();
            _txtNumberUsed = new TextBox();
            _Label13 = new Label();
            _Label15 = new Label();
            _Label16 = new Label();
            _btnRemovePartProductUsed = new Button();
            _btnRemovePartProductUsed.Click += new EventHandler(btnRemovePartProduct_Click);
            _btnFindProductUsed = new Button();
            _btnFindProductUsed.Click += new EventHandler(btnFindProduct_Click);
            _btnFindPartUsed = new Button();
            _btnFindPartUsed.Click += new EventHandler(btnFindPart_Click);
            _tpOutcomes = new TabPage();
            _grpOutcomes = new GroupBox();
            _grpSiteFuels = new GroupBox();
            _dgSiteFuel = new DataGrid();
            _dgSiteFuel.Click += new EventHandler(dgSiteFuel_Click);
            _cboNccRad = new ComboBox();
            _Label76 = new Label();
            _cboRecharge = new ComboBox();
            _cboRecharge.SelectedIndexChanged += new EventHandler(cboRecharge_SelectedIndexChanged);
            _Label75 = new Label();
            _chkRecharge = new CheckBox();
            _chkRecharge.CheckedChanged += new EventHandler(chkRecharge_CheckedChanged);
            _chkGasServiceCompleted = new CheckBox();
            _tpQC = new TabPage();
            _GroupBox4 = new GroupBox();
            _grpQCField = new GroupBox();
            _cboQCCustSig = new ComboBox();
            _lblQCCustSig = new Label();
            _cboRecallEngineer = new ComboBox();
            _Label49 = new Label();
            _cboRecall = new ComboBox();
            _cboRecall.SelectedIndexChanged += new EventHandler(cboRecall_SelectedIndexChanged);
            _Label48 = new Label();
            _dtpQCDocumentsRecieved = new DateTimePicker();
            _chkQCDocumentsRecieved = new CheckBox();
            _chkQCDocumentsRecieved.CheckedChanged += new EventHandler(chkQCDocumentsRecieved_CheckedChanged);
            _txtQCPoorJobNotes = new TextBox();
            _lblQCPoorJobNotes = new Label();
            _cboQCEngineerPaymentRecieved = new ComboBox();
            _lblQCEngineerMonies = new Label();
            _cboQCPaymentSelection = new ComboBox();
            _lblQCEngPaymentMethod = new Label();
            _cboQCAppliance = new ComboBox();
            _cboQCPaymentCollection = new ComboBox();
            _lblQCPaymentCollection = new Label();
            _cboQCJobUploadTimescale = new ComboBox();
            _lblQCAppliance = new Label();
            _cboQCParts = new ComboBox();
            _lblJobUploadTimescale = new Label();
            _lblQCParts = new Label();
            _cboQCLGSR = new ComboBox();
            _lblQCLGSR = new Label();
            _cboQCLabourTime = new ComboBox();
            _lblQCLabourTime = new Label();
            _grpOfficeQC = new GroupBox();
            _cboQCPaymentMethod = new ComboBox();
            _lblPaymentMethod = new Label();
            _cboQCOrderNo = new ComboBox();
            _lblOrderNo = new Label();
            _cboQCScheduleOfRate = new ComboBox();
            _lblScheduleRate = new Label();
            _cboQCCustomerDetails = new ComboBox();
            _lblCustomerDetails = new Label();
            _cboQCJobType = new ComboBox();
            _lblJobTypeCorrect = new Label();
            _cboFTFCode = new ComboBox();
            _Label74 = new Label();
            _tpCharges = new TabPage();
            _gpbInvoice = new GroupBox();
            _cboDept = new ComboBox();
            _cboDept.SelectedIndexChanged += new EventHandler(cboDept_SelectedIndexChanged);
            _btnCreateServ = new Button();
            _btnCreateServ.Click += new EventHandler(btnCreateServ_Click);
            _txtInvAmount = new TextBox();
            _txtCreditAmount = new TextBox();
            _txtInvNo = new TextBox();
            _cboPaidBy = new ComboBox();
            _cboPaidBy.SelectedIndexChanged += new EventHandler(cboPaidBy_SelectedIndexChanged);
            _cboInvType = new ComboBox();
            _cboInvType.SelectedIndexChanged += new EventHandler(cboInvType_SelectedIndexChanged);
            _cboVATRate = new ComboBox();
            _cboVATRate.SelectedIndexChanged += new EventHandler(cboVATRate_SelectedIndexChanged);
            _txtPriceIncVAT = new TextBox();
            _txtAccountCode = new TextBox();
            _txtAccountCode.TextChanged += new EventHandler(txtAccountCode_TextChanged);
            _lblInvoiceAddressDetails = new Label();
            _txtNominalCode = new TextBox();
            _txtNominalCode.TextChanged += new EventHandler(txtNominalCode_TextChanged);
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _dtpRaiseInvoiceOn = new DateTimePicker();
            _dtpRaiseInvoiceOn.ValueChanged += new EventHandler(dtpRaiseInvoiceOn_ValueChanged);
            _cbxReadyToBeInvoiced = new CheckBox();
            _cbxReadyToBeInvoiced.CheckedChanged += new EventHandler(cbxReadyToBeInvoiced_CheckedChanged);
            _lblInvAmount = new Label();
            _lblcredit = new Label();
            _lblcredit.Click += new EventHandler(lblcredit_Click);
            _lblInvNo = new Label();
            _lblPaidBy = new Label();
            _lblInvType = new Label();
            _lblVAT = new Label();
            _lblNominalCode = new Label();
            _lblAccountCode = new Label();
            _lblPriceInvVAT = new Label();
            _lblDepartment = new Label();
            _lblRaiseInvoiceOn = new Label();
            _gpbCharges = new GroupBox();
            _chkShowJobCharges = new CheckBox();
            _chkShowJobCharges.CheckedChanged += new EventHandler(chkShowJobCharges_CheckedChanged);
            _GroupBox6 = new GroupBox();
            _Label82 = new Label();
            _Label78 = new Label();
            _Label77 = new Label();
            _txtProfitPerc = new TextBox();
            _txtProfit = new TextBox();
            _CostsToOption1 = new RadioButton();
            _CostsToOption1.CheckedChanged += new EventHandler(radioButtonCostsTo_CheckedChanged);
            _txtCosts = new TextBox();
            _CostsToOption3 = new RadioButton();
            _CostsToOption3.CheckedChanged += new EventHandler(radioButtonCostsTo_CheckedChanged);
            _txtSale = new TextBox();
            _CostsToOption2 = new RadioButton();
            _CostsToOption2.CheckedChanged += new EventHandler(radioButtonCostsTo_CheckedChanged);
            _lblContractPerVisit = new Label();
            _lblOR = new Label();
            _Label30 = new Label();
            _lblQuotePercentageTotal = new Label();
            _lblEquals = new Label();
            _GroupBox9 = new GroupBox();
            _rbStandard = new RadioButton();
            _rbSite = new RadioButton();
            _lblPercent = new Label();
            _txtPercentOfQuote = new TextBox();
            _txtPercentOfQuote.TextChanged += new EventHandler(txtPercentOfQuote_TextChanged);
            _rdoPercentageOfQuoteValue = new RadioButton();
            _rdoPercentageOfQuoteValue.CheckedChanged += new EventHandler(rdoPercentageOfQuoteValue_CheckedChanged);
            _txtCharge = new TextBox();
            _rdoChargeOther = new RadioButton();
            _rdoChargeOther.CheckedChanged += new EventHandler(rdoChargeOther_CheckedChanged);
            _rdoJobValue = new RadioButton();
            _rdoJobValue.CheckedChanged += new EventHandler(rdoJobValue_CheckedChanged);
            _txtJobValue = new TextBox();
            _gpbAdditionalCharges = new GroupBox();
            _lblAdditionalCharge = new Label();
            _btnAddAdditionalCharge = new Button();
            _btnAddAdditionalCharge.Click += new EventHandler(btnAddAdditionalCharge_Click);
            _txtAdditionalCharge = new TextBox();
            _btnRemoveAdditionalCharge = new Button();
            _btnRemoveAdditionalCharge.Click += new EventHandler(btnRemoveAdditionalCharge_Click);
            _txtAdditionalChargeDescription = new TextBox();
            _lblDescription = new Label();
            _txtAdditionalChargeTotal = new TextBox();
            _Label29 = new Label();
            _dgAdditionalCharges = new DataGrid();
            _gpbPartsAndProducts = new GroupBox();
            _txtPartsMarkUp = new TextBox();
            _txtPartsMarkUp.Leave += new EventHandler(txtPartsMarkUp_Leave);
            _chkPartsSelectAll = new CheckBox();
            _chkPartsSelectAll.Click += new EventHandler(chkPartsSelectAll_Click);
            _txtPartProductCost = new TextBox();
            _txtPartsProductTotal = new TextBox();
            _txtPartsProductTotal.Leave += new EventHandler(txtPartsProductTotal_Leave);
            _Label28 = new Label();
            _lblPPTotalCost = new Label();
            _lblPartsMarkUp = new Label();
            _dgPartsProductCharging = new DataGrid();
            _dgPartsProductCharging.MouseUp += new MouseEventHandler(dgPartsProductCharging_MouseUp);
            _gpbTimesheets = new GroupBox();
            _chkTimesheetSelectAll = new CheckBox();
            _chkTimesheetSelectAll.Click += new EventHandler(chkTimesheetSelectAll_Click);
            _txtEngineerCostTotal = new TextBox();
            _txtTimesheetTotal = new TextBox();
            _txtTimesheetTotal.Leave += new EventHandler(txtTimesheetTotal_Leave);
            _Label27 = new Label();
            _Label32 = new Label();
            _dgTimesheetCharges = new DataGrid();
            _dgTimesheetCharges.MouseUp += new MouseEventHandler(dgTimesheetCharges_MouseUp);
            _gpbScheduleOfRates = new GroupBox();
            _btnAddSoR = new Button();
            _btnAddSoR.Click += new EventHandler(btnAddSoR_Click);
            _txtScheduleOfRatesTotal = new TextBox();
            _dgScheduleOfRateCharges = new DataGrid();
            _dgScheduleOfRateCharges.MouseUp += new MouseEventHandler(dgScheduleOfRateCharges_MouseUp);
            _Label26 = new Label();
            _tpDocuments = new TabPage();
            _tpPhotos = new TabPage();
            _tpPhotos.Enter += new EventHandler(tpPhotos_Enter);
            _flPhotos = new FlowLayoutPanel();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _mnuAddChecklist = new ContextMenu();
            _cbxVisitLockDown = new CheckBox();
            _cbxVisitLockDown.CheckedChanged += new EventHandler(cbxVisitLockDown_CheckedChanged);
            _lblStatusWarning = new Label();
            _btnOrders = new Button();
            _btnOrders.Click += new EventHandler(btnOrders_Click);
            _btnInvoice = new Button();
            _btnInvoice.Click += new EventHandler(btnInvoice_Click);
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _PrintMenu = new ContextMenuStrip(components);
            _mnuGasSafetyInspectionBoilerServiceRecord = new ToolStripMenuItem();
            _txtCurrentContract = new TextBox();
            _Label39 = new Label();
            _btnPrintGSR = new Button();
            _btnPrintGSR.Click += new EventHandler(btnPrintGSR_Click);
            _btnPrintSVR = new Button();
            _btnPrintSVR.Click += new EventHandler(btnPrintSVR_Click);
            _btnJob = new Button();
            _btnJob.Click += new EventHandler(btnJob_Click);
            _lblRechargeTicked = new Label();
            _btnShowVisits = new Button();
            _btnShowVisits.Click += new EventHandler(btnShowVisits_Click);
            _BottomToolStripPanel = new ToolStripPanel();
            _TopToolStripPanel = new ToolStripPanel();
            _RightToolStripPanel = new ToolStripPanel();
            _LeftToolStripPanel = new ToolStripPanel();
            _ContentPanel = new ToolStripContentPanel();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _txtCustEmail = new TextBox();
            _SVRs = new ContextMenuStrip(components);
            _AllGasPaperworkToolStripMenuItem = new ToolStripMenuItem();
            _AllGasPaperworkToolStripMenuItem.Click += new EventHandler(AllGasPaperworkToolStripMenuItem_Click);
            _svrmenu = new ToolStripMenuItem();
            _svrmenu.Click += new EventHandler(svrmenu_Click);
            _JobSheetMenu = new ToolStripMenuItem();
            _JobSheetMenu.Click += new EventHandler(JobSheetMenu_Click);
            _DomesticGSRToolStripMenuItem = new ToolStripMenuItem();
            _DomesticGSRToolStripMenuItem.Click += new EventHandler(DomesticGSRToolStripMenuItem_Click);
            _WarningNoticeToolStripMenuItem = new ToolStripMenuItem();
            _WarningNoticeToolStripMenuItem.Click += new EventHandler(WarningNoticeToolStripMenuItem_Click);
            _CommercialGSRToolStripMenuItem = new ToolStripMenuItem();
            _CommercialGSRToolStripMenuItem.Click += new EventHandler(CommercialGSRToolStripMenuItem_Click);
            _QCResultsToolStripMenuItem = new ToolStripMenuItem();
            _QCResultsToolStripMenuItem.Click += new EventHandler(QCResultsToolStripMenuItem_Click);
            _ElectricalMinorWorksToolStripMenuItem = new ToolStripMenuItem();
            _ElectricalMinorWorksToolStripMenuItem.Click += new EventHandler(ElectricalMinorWorksToolStripMenuItem_Click);
            _CommercialCateringToolStripMenuItem = new ToolStripMenuItem();
            _CommercialCateringToolStripMenuItem.Click += new EventHandler(CommercialCateringToolStripMenuItem_Click);
            _SaffronUnventedWorkshhetToolStripMenuItem = new ToolStripMenuItem();
            _SaffronUnventedWorkshhetToolStripMenuItem.Click += new EventHandler(SaffronUnventedWorkshhetToolStripMenuItem_Click);
            _PropertyMaintenanceWorksheetToolStripMenuItem = new ToolStripMenuItem();
            _PropertyMaintenanceWorksheetToolStripMenuItem.Click += new EventHandler(PropertyMaintenanceWorksheetToolStripMenuItem_Click);
            _ASHPWorksheetToolStripMenuItem = new ToolStripMenuItem();
            _ASHPWorksheetToolStripMenuItem.Click += new EventHandler(ASHPWorksheetToolStripMenuItem_Click);
            _CommissioningChecklistToolStripMenuItem = new ToolStripMenuItem();
            _CommissioningChecklistToolStripMenuItem.Click += new EventHandler(CommissioningChecklistToolStripMenuItem_Click);
            _HotWorksPermitToolStripMenuItem = new ToolStripMenuItem();
            _HotWorksPermitToolStripMenuItem.Click += new EventHandler(HotWorksPermitToolStripMenuItem_Click);
            _tcWorkSheet.SuspendLayout();
            _tpMainDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_pbCustomerSignature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_pbEngineerSignature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgJobItems).BeginInit();
            _tpAppliances.SuspendLayout();
            _gpAppliances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            _tpWorksheets.SuspendLayout();
            _grpAdditionalWorksheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAdditional).BeginInit();
            _grpAlarmInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_DGSmokeComo).BeginInit();
            _grpVisitWorksheetExtended.SuspendLayout();
            _grpVisitDefects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVisitDefects).BeginInit();
            _grpApplianceWorksheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgApplianceWorkSheets).BeginInit();
            _grpVisitWorksheet.SuspendLayout();
            _tpTimesheets.SuspendLayout();
            _grpTimesheets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTimeSheets).BeginInit();
            _tpPartsAndProducts.SuspendLayout();
            _grpAllocated.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_nudPartAllocatedQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgPartsProductsAllocated).BeginInit();
            _grpUsed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsAndProductsUsed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_nudQuantityUsed).BeginInit();
            _tpOutcomes.SuspendLayout();
            _grpOutcomes.SuspendLayout();
            _grpSiteFuels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuel).BeginInit();
            _tpQC.SuspendLayout();
            _GroupBox4.SuspendLayout();
            _grpQCField.SuspendLayout();
            _grpOfficeQC.SuspendLayout();
            _tpCharges.SuspendLayout();
            _gpbInvoice.SuspendLayout();
            _gpbCharges.SuspendLayout();
            _GroupBox6.SuspendLayout();
            _GroupBox9.SuspendLayout();
            _gpbAdditionalCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAdditionalCharges).BeginInit();
            _gpbPartsAndProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsProductCharging).BeginInit();
            _gpbTimesheets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTimesheetCharges).BeginInit();
            _gpbScheduleOfRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRateCharges).BeginInit();
            _tpPhotos.SuspendLayout();
            _PrintMenu.SuspendLayout();
            _SVRs.SuspendLayout();
            SuspendLayout();
            // 
            // tcWorkSheet
            // 
            _tcWorkSheet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcWorkSheet.Controls.Add(_tpMainDetails);
            _tcWorkSheet.Controls.Add(_tpAppliances);
            _tcWorkSheet.Controls.Add(_tpWorksheets);
            _tcWorkSheet.Controls.Add(_tpTimesheets);
            _tcWorkSheet.Controls.Add(_tpPartsAndProducts);
            _tcWorkSheet.Controls.Add(_tpOutcomes);
            _tcWorkSheet.Controls.Add(_tpQC);
            _tcWorkSheet.Controls.Add(_tpCharges);
            _tcWorkSheet.Controls.Add(_tpDocuments);
            _tcWorkSheet.Controls.Add(_tpPhotos);
            _tcWorkSheet.Location = new Point(0, 64);
            _tcWorkSheet.Name = "tcWorkSheet";
            _tcWorkSheet.SelectedIndex = 0;
            _tcWorkSheet.Size = new Size(1255, 678);
            _tcWorkSheet.TabIndex = 1;
            // 
            // tpMainDetails
            // 
            _tpMainDetails.Controls.Add(_chkSORDesc);
            _tpMainDetails.Controls.Add(_btnEditInvoiceNotes);
            _tpMainDetails.Controls.Add(_txtScheduledTime2);
            _tpMainDetails.Controls.Add(_Label71);
            _tpMainDetails.Controls.Add(_btnChangeOutcome);
            _tpMainDetails.Controls.Add(_pbCustomerSignature);
            _tpMainDetails.Controls.Add(_pbEngineerSignature);
            _tpMainDetails.Controls.Add(_cbxEmailReceiptToCustomer);
            _tpMainDetails.Controls.Add(_cboSignatureSelected);
            _tpMainDetails.Controls.Add(_Label42);
            _tpMainDetails.Controls.Add(_dgJobItems);
            _tpMainDetails.Controls.Add(_Label12);
            _tpMainDetails.Controls.Add(_txtNotesToEngineer);
            _tpMainDetails.Controls.Add(_Label6);
            _tpMainDetails.Controls.Add(_txtCustomer);
            _tpMainDetails.Controls.Add(_cboEngineer);
            _tpMainDetails.Controls.Add(_txtNotesFromEngineer);
            _tpMainDetails.Controls.Add(_cboOutcome);
            _tpMainDetails.Controls.Add(_txtOutcomeDetails);
            _tpMainDetails.Controls.Add(_Label11);
            _tpMainDetails.Controls.Add(_txtUploadedBy);
            _tpMainDetails.Controls.Add(_txtStatus);
            _tpMainDetails.Controls.Add(_Label9);
            _tpMainDetails.Controls.Add(_Label5);
            _tpMainDetails.Controls.Add(_Label4);
            _tpMainDetails.Controls.Add(_Label3);
            _tpMainDetails.Controls.Add(_Label2);
            _tpMainDetails.Controls.Add(_Label1);
            _tpMainDetails.Location = new Point(4, 22);
            _tpMainDetails.Name = "tpMainDetails";
            _tpMainDetails.Size = new Size(1247, 652);
            _tpMainDetails.TabIndex = 0;
            _tpMainDetails.Text = "Main Details";
            _tpMainDetails.UseVisualStyleBackColor = true;
            // 
            // chkSORDesc
            // 
            _chkSORDesc.AutoSize = true;
            _chkSORDesc.Font = new Font("Verdana", 16.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkSORDesc.Location = new Point(128, 413);
            _chkSORDesc.Name = "chkSORDesc";
            _chkSORDesc.Size = new Size(394, 30);
            _chkSORDesc.TabIndex = 35;
            _chkSORDesc.Text = "Use SOR Descriptions for Invoice";
            _chkSORDesc.UseVisualStyleBackColor = true;
            // 
            // btnEditInvoiceNotes
            // 
            _btnEditInvoiceNotes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnEditInvoiceNotes.Location = new Point(11, 384);
            _btnEditInvoiceNotes.Name = "btnEditInvoiceNotes";
            _btnEditInvoiceNotes.Size = new Size(97, 23);
            _btnEditInvoiceNotes.TabIndex = 34;
            _btnEditInvoiceNotes.Text = "Edit Inv Notes";
            _btnEditInvoiceNotes.Visible = false;
            // 
            // txtScheduledTime2
            // 
            _txtScheduledTime2.Location = new Point(128, 204);
            _txtScheduledTime2.Name = "txtScheduledTime2";
            _txtScheduledTime2.ReadOnly = true;
            _txtScheduledTime2.Size = new Size(510, 21);
            _txtScheduledTime2.TabIndex = 32;
            // 
            // Label71
            // 
            _Label71.Location = new Point(8, 207);
            _Label71.Name = "Label71";
            _Label71.Size = new Size(104, 16);
            _Label71.TabIndex = 33;
            _Label71.Text = "Scheduled";
            // 
            // btnChangeOutcome
            // 
            _btnChangeOutcome.Location = new Point(128, 171);
            _btnChangeOutcome.Name = "btnChangeOutcome";
            _btnChangeOutcome.Size = new Size(114, 23);
            _btnChangeOutcome.TabIndex = 31;
            _btnChangeOutcome.Text = "Change Outcome";
            _btnChangeOutcome.UseVisualStyleBackColor = true;
            // 
            // pbCustomerSignature
            // 
            _pbCustomerSignature.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _pbCustomerSignature.BorderStyle = BorderStyle.FixedSingle;
            _pbCustomerSignature.Location = new Point(647, 207);
            _pbCustomerSignature.Name = "pbCustomerSignature";
            _pbCustomerSignature.Size = new Size(592, 119);
            _pbCustomerSignature.SizeMode = PictureBoxSizeMode.Zoom;
            _pbCustomerSignature.TabIndex = 30;
            _pbCustomerSignature.TabStop = false;
            // 
            // pbEngineerSignature
            // 
            _pbEngineerSignature.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _pbEngineerSignature.BorderStyle = BorderStyle.FixedSingle;
            _pbEngineerSignature.Location = new Point(647, 44);
            _pbEngineerSignature.Name = "pbEngineerSignature";
            _pbEngineerSignature.Size = new Size(592, 121);
            _pbEngineerSignature.SizeMode = PictureBoxSizeMode.Zoom;
            _pbEngineerSignature.TabIndex = 29;
            _pbEngineerSignature.TabStop = false;
            // 
            // cbxEmailReceiptToCustomer
            // 
            _cbxEmailReceiptToCustomer.AutoSize = true;
            _cbxEmailReceiptToCustomer.Location = new Point(647, 390);
            _cbxEmailReceiptToCustomer.Name = "cbxEmailReceiptToCustomer";
            _cbxEmailReceiptToCustomer.Size = new Size(180, 17);
            _cbxEmailReceiptToCustomer.TabIndex = 28;
            _cbxEmailReceiptToCustomer.Text = "Email Receipt To Customer";
            _cbxEmailReceiptToCustomer.UseVisualStyleBackColor = true;
            // 
            // cboSignatureSelected
            // 
            _cboSignatureSelected.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboSignatureSelected.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSignatureSelected.Location = new Point(714, 332);
            _cboSignatureSelected.Name = "cboSignatureSelected";
            _cboSignatureSelected.Size = new Size(525, 21);
            _cboSignatureSelected.TabIndex = 27;
            // 
            // Label42
            // 
            _Label42.Location = new Point(644, 335);
            _Label42.Name = "Label42";
            _Label42.Size = new Size(64, 23);
            _Label42.TabIndex = 26;
            _Label42.Text = "Signature";
            // 
            // dgJobItems
            // 
            _dgJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobItems.DataMember = "";
            _dgJobItems.HeaderForeColor = SystemColors.ControlText;
            _dgJobItems.Location = new Point(128, 450);
            _dgJobItems.Name = "dgJobItems";
            _dgJobItems.Size = new Size(1111, 196);
            _dgJobItems.TabIndex = 9;
            _dgJobItems.TabStop = false;
            // 
            // Label12
            // 
            _Label12.Location = new Point(8, 450);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(80, 16);
            _Label12.TabIndex = 25;
            _Label12.Text = "Job Items";
            // 
            // txtNotesToEngineer
            // 
            _txtNotesToEngineer.Location = new Point(128, 44);
            _txtNotesToEngineer.Multiline = true;
            _txtNotesToEngineer.Name = "txtNotesToEngineer";
            _txtNotesToEngineer.ReadOnly = true;
            _txtNotesToEngineer.ScrollBars = ScrollBars.Both;
            _txtNotesToEngineer.Size = new Size(510, 66);
            _txtNotesToEngineer.TabIndex = 10;
            _txtNotesToEngineer.TabStop = false;
            // 
            // Label6
            // 
            _Label6.Location = new Point(8, 40);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(64, 16);
            _Label6.TabIndex = 21;
            _Label6.Text = "Notes";
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Location = new Point(714, 173);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.Size = new Size(525, 21);
            _txtCustomer.TabIndex = 6;
            // 
            // cboEngineer
            // 
            _cboEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineer.Location = new Point(714, 14);
            _cboEngineer.Name = "cboEngineer";
            _cboEngineer.Size = new Size(525, 21);
            _cboEngineer.TabIndex = 4;
            // 
            // txtNotesFromEngineer
            // 
            _txtNotesFromEngineer.Location = new Point(128, 335);
            _txtNotesFromEngineer.Multiline = true;
            _txtNotesFromEngineer.Name = "txtNotesFromEngineer";
            _txtNotesFromEngineer.ScrollBars = ScrollBars.Both;
            _txtNotesFromEngineer.Size = new Size(510, 72);
            _txtNotesFromEngineer.TabIndex = 3;
            // 
            // cboOutcome
            // 
            _cboOutcome.Location = new Point(128, 144);
            _cboOutcome.Name = "cboOutcome";
            _cboOutcome.Size = new Size(510, 21);
            _cboOutcome.TabIndex = 1;
            // 
            // txtOutcomeDetails
            // 
            _txtOutcomeDetails.Location = new Point(128, 231);
            _txtOutcomeDetails.Multiline = true;
            _txtOutcomeDetails.Name = "txtOutcomeDetails";
            _txtOutcomeDetails.ScrollBars = ScrollBars.Both;
            _txtOutcomeDetails.Size = new Size(510, 95);
            _txtOutcomeDetails.TabIndex = 2;
            // 
            // Label11
            // 
            _Label11.Location = new Point(8, 234);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(80, 16);
            _Label11.TabIndex = 12;
            _Label11.Text = "Details";
            // 
            // txtUploadedBy
            // 
            _txtUploadedBy.Location = new Point(128, 116);
            _txtUploadedBy.Name = "txtUploadedBy";
            _txtUploadedBy.ReadOnly = true;
            _txtUploadedBy.Size = new Size(510, 21);
            _txtUploadedBy.TabIndex = 2;
            _txtUploadedBy.TabStop = false;
            // 
            // txtStatus
            // 
            _txtStatus.Location = new Point(128, 14);
            _txtStatus.Name = "txtStatus";
            _txtStatus.ReadOnly = true;
            _txtStatus.Size = new Size(510, 21);
            _txtStatus.TabIndex = 1;
            _txtStatus.TabStop = false;
            // 
            // Label9
            // 
            _Label9.Location = new Point(8, 147);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(80, 19);
            _Label9.TabIndex = 8;
            _Label9.Text = "Outcome";
            // 
            // Label5
            // 
            _Label5.Location = new Point(644, 176);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(64, 16);
            _Label5.TabIndex = 4;
            _Label5.Text = "Customer";
            // 
            // Label4
            // 
            _Label4.Location = new Point(8, 119);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(80, 16);
            _Label4.TabIndex = 3;
            _Label4.Text = "Uploaded by";
            // 
            // Label3
            // 
            _Label3.Location = new Point(8, 16);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(56, 16);
            _Label3.TabIndex = 2;
            _Label3.Text = "Status";
            // 
            // Label2
            // 
            _Label2.Location = new Point(8, 335);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(128, 24);
            _Label2.TabIndex = 1;
            _Label2.Text = "Invoice Notes";
            // 
            // Label1
            // 
            _Label1.Location = new Point(644, 14);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 0;
            _Label1.Text = "Engineer";
            // 
            // tpAppliances
            // 
            _tpAppliances.Controls.Add(_gpAppliances);
            _tpAppliances.Location = new Point(4, 22);
            _tpAppliances.Name = "tpAppliances";
            _tpAppliances.Padding = new Padding(3);
            _tpAppliances.Size = new Size(1247, 652);
            _tpAppliances.TabIndex = 6;
            _tpAppliances.Text = "Appliances";
            _tpAppliances.UseVisualStyleBackColor = true;
            // 
            // gpAppliances
            // 
            _gpAppliances.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpAppliances.Controls.Add(_dgAssets);
            _gpAppliances.Location = new Point(6, 6);
            _gpAppliances.Name = "gpAppliances";
            _gpAppliances.Size = new Size(1235, 640);
            _gpAppliances.TabIndex = 0;
            _gpAppliances.TabStop = false;
            _gpAppliances.Text = "Appliances";
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(6, 20);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(1223, 614);
            _dgAssets.TabIndex = 2;
            // 
            // tpWorksheets
            // 
            _tpWorksheets.Controls.Add(_grpAdditionalWorksheet);
            _tpWorksheets.Controls.Add(_grpAlarmInfo);
            _tpWorksheets.Controls.Add(_grpVisitWorksheetExtended);
            _tpWorksheets.Controls.Add(_grpVisitDefects);
            _tpWorksheets.Controls.Add(_grpApplianceWorksheet);
            _tpWorksheets.Controls.Add(_grpVisitWorksheet);
            _tpWorksheets.Location = new Point(4, 22);
            _tpWorksheets.Name = "tpWorksheets";
            _tpWorksheets.Size = new Size(1247, 652);
            _tpWorksheets.TabIndex = 5;
            _tpWorksheets.Text = "Worksheets";
            _tpWorksheets.UseVisualStyleBackColor = true;
            // 
            // grpAdditionalWorksheet
            // 
            _grpAdditionalWorksheet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpAdditionalWorksheet.Controls.Add(_btnRemoveAdd);
            _grpAdditionalWorksheet.Controls.Add(_btnAddAdd);
            _grpAdditionalWorksheet.Controls.Add(_dgAdditional);
            _grpAdditionalWorksheet.Location = new Point(515, 259);
            _grpAdditionalWorksheet.Name = "grpAdditionalWorksheet";
            _grpAdditionalWorksheet.Size = new Size(360, 247);
            _grpAdditionalWorksheet.TabIndex = 29;
            _grpAdditionalWorksheet.TabStop = false;
            _grpAdditionalWorksheet.Text = "Additional Worksheets";
            // 
            // btnRemoveAdd
            // 
            _btnRemoveAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveAdd.Location = new Point(8, 218);
            _btnRemoveAdd.Name = "btnRemoveAdd";
            _btnRemoveAdd.Size = new Size(75, 23);
            _btnRemoveAdd.TabIndex = 3;
            _btnRemoveAdd.Text = "Remove";
            // 
            // btnAddAdd
            // 
            _btnAddAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddAdd.Location = new Point(275, 218);
            _btnAddAdd.Name = "btnAddAdd";
            _btnAddAdd.Size = new Size(75, 23);
            _btnAddAdd.TabIndex = 4;
            _btnAddAdd.Text = "Add";
            // 
            // dgAdditional
            // 
            _dgAdditional.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAdditional.DataMember = "";
            _dgAdditional.HeaderForeColor = SystemColors.ControlText;
            _dgAdditional.Location = new Point(6, 20);
            _dgAdditional.Name = "dgAdditional";
            _dgAdditional.Size = new Size(344, 192);
            _dgAdditional.TabIndex = 0;
            // 
            // grpAlarmInfo
            // 
            _grpAlarmInfo.Controls.Add(_btnRemoveSmokeComo);
            _grpAlarmInfo.Controls.Add(_btnAddSmokeComo);
            _grpAlarmInfo.Controls.Add(_DGSmokeComo);
            _grpAlarmInfo.Location = new Point(515, 8);
            _grpAlarmInfo.Name = "grpAlarmInfo";
            _grpAlarmInfo.Size = new Size(360, 242);
            _grpAlarmInfo.TabIndex = 4;
            _grpAlarmInfo.TabStop = false;
            _grpAlarmInfo.Text = "Alarm Info";
            // 
            // btnRemoveSmokeComo
            // 
            _btnRemoveSmokeComo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveSmokeComo.Location = new Point(12, 202);
            _btnRemoveSmokeComo.Name = "btnRemoveSmokeComo";
            _btnRemoveSmokeComo.Size = new Size(75, 23);
            _btnRemoveSmokeComo.TabIndex = 30;
            _btnRemoveSmokeComo.Text = "Remove";
            // 
            // btnAddSmokeComo
            // 
            _btnAddSmokeComo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddSmokeComo.Location = new Point(275, 202);
            _btnAddSmokeComo.Name = "btnAddSmokeComo";
            _btnAddSmokeComo.Size = new Size(75, 23);
            _btnAddSmokeComo.TabIndex = 31;
            _btnAddSmokeComo.Text = "Add";
            // 
            // DGSmokeComo
            // 
            _DGSmokeComo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _DGSmokeComo.DataMember = "";
            _DGSmokeComo.HeaderForeColor = SystemColors.ControlText;
            _DGSmokeComo.Location = new Point(12, 17);
            _DGSmokeComo.Name = "DGSmokeComo";
            _DGSmokeComo.Size = new Size(338, 181);
            _DGSmokeComo.TabIndex = 29;
            // 
            // grpVisitWorksheetExtended
            // 
            _grpVisitWorksheetExtended.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVisitWorksheetExtended.Controls.Add(_cboSITimer);
            _grpVisitWorksheetExtended.Controls.Add(_cboFillDisc);
            _grpVisitWorksheetExtended.Controls.Add(_Label81);
            _grpVisitWorksheetExtended.Controls.Add(_Label80);
            _grpVisitWorksheetExtended.Controls.Add(_Label79);
            _grpVisitWorksheetExtended.Controls.Add(_txtRadiators);
            _grpVisitWorksheetExtended.Controls.Add(_txtVisualInspectionReason);
            _grpVisitWorksheetExtended.Controls.Add(_Label68);
            _grpVisitWorksheetExtended.Controls.Add(_Label69);
            _grpVisitWorksheetExtended.Controls.Add(_Label70);
            _grpVisitWorksheetExtended.Controls.Add(_Label62);
            _grpVisitWorksheetExtended.Controls.Add(_Label63);
            _grpVisitWorksheetExtended.Controls.Add(_Label64);
            _grpVisitWorksheetExtended.Controls.Add(_Label65);
            _grpVisitWorksheetExtended.Controls.Add(_Label66);
            _grpVisitWorksheetExtended.Controls.Add(_Label67);
            _grpVisitWorksheetExtended.Controls.Add(_cboCertificateTypeID);
            _grpVisitWorksheetExtended.Controls.Add(_cboCODetectorFittedID);
            _grpVisitWorksheetExtended.Controls.Add(_cboVisualInspectionSatisfactoryID);
            _grpVisitWorksheetExtended.Controls.Add(_cboImmersionID);
            _grpVisitWorksheetExtended.Controls.Add(_cboJacketID);
            _grpVisitWorksheetExtended.Controls.Add(_cboCylinderTypeID);
            _grpVisitWorksheetExtended.Controls.Add(_cboPartialHeatingID);
            _grpVisitWorksheetExtended.Controls.Add(_cboHeatingSystemTypeID);
            _grpVisitWorksheetExtended.Controls.Add(_txtApproxAgeOfBoiler);
            _grpVisitWorksheetExtended.Controls.Add(_cboStrainerInspectedID);
            _grpVisitWorksheetExtended.Controls.Add(_Label56);
            _grpVisitWorksheetExtended.Controls.Add(_Label57);
            _grpVisitWorksheetExtended.Controls.Add(_cboStrainerFittedID);
            _grpVisitWorksheetExtended.Controls.Add(_cboInstallationSafeToUseID);
            _grpVisitWorksheetExtended.Controls.Add(_cboInstallationPipeWorkCorrectID);
            _grpVisitWorksheetExtended.Controls.Add(_cboCorrectMaterialsUsedID);
            _grpVisitWorksheetExtended.Controls.Add(_Label58);
            _grpVisitWorksheetExtended.Controls.Add(_Label59);
            _grpVisitWorksheetExtended.Controls.Add(_Label60);
            _grpVisitWorksheetExtended.Controls.Add(_Label61);
            _grpVisitWorksheetExtended.Location = new Point(881, 8);
            _grpVisitWorksheetExtended.Name = "grpVisitWorksheetExtended";
            _grpVisitWorksheetExtended.Size = new Size(358, 636);
            _grpVisitWorksheetExtended.TabIndex = 3;
            _grpVisitWorksheetExtended.TabStop = false;
            _grpVisitWorksheetExtended.Text = "Visit Worksheet - Extended";
            // 
            // cboSITimer
            // 
            _cboSITimer.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSITimer.Location = new Point(192, 449);
            _cboSITimer.Name = "cboSITimer";
            _cboSITimer.Size = new Size(160, 21);
            _cboSITimer.TabIndex = 33;
            // 
            // cboFillDisc
            // 
            _cboFillDisc.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFillDisc.Location = new Point(192, 422);
            _cboFillDisc.Name = "cboFillDisc";
            _cboFillDisc.Size = new Size(160, 21);
            _cboFillDisc.TabIndex = 32;
            // 
            // Label81
            // 
            _Label81.Location = new Point(6, 477);
            _Label81.Name = "Label81";
            _Label81.Size = new Size(180, 21);
            _Label81.TabIndex = 31;
            _Label81.Text = "Flue/Tank In loft details";
            // 
            // Label80
            // 
            _Label80.Location = new Point(6, 423);
            _Label80.Name = "Label80";
            _Label80.Size = new Size(180, 21);
            _Label80.TabIndex = 30;
            _Label80.Text = "Filling Loop Disconnected?";
            // 
            // Label79
            // 
            _Label79.Location = new Point(6, 449);
            _Label79.Name = "Label79";
            _Label79.Size = new Size(180, 21);
            _Label79.TabIndex = 29;
            _Label79.Text = "SI Timer Reset";
            // 
            // txtRadiators
            // 
            _txtRadiators.Location = new Point(192, 287);
            _txtRadiators.Name = "txtRadiators";
            _txtRadiators.Size = new Size(160, 21);
            _txtRadiators.TabIndex = 10;
            _txtRadiators.Text = "0";
            // 
            // txtVisualInspectionReason
            // 
            _txtVisualInspectionReason.Location = new Point(192, 476);
            _txtVisualInspectionReason.Multiline = true;
            _txtVisualInspectionReason.Name = "txtVisualInspectionReason";
            _txtVisualInspectionReason.Size = new Size(160, 43);
            _txtVisualInspectionReason.TabIndex = 15;
            // 
            // Label68
            // 
            _Label68.Location = new Point(6, 397);
            _Label68.Name = "Label68";
            _Label68.Size = new Size(180, 21);
            _Label68.TabIndex = 28;
            _Label68.Text = "Flue/Tank In Loft Satisfactory" + (char)13 + (char)10;
            // 
            // Label69
            // 
            _Label69.Location = new Point(6, 371);
            _Label69.Name = "Label69";
            _Label69.Size = new Size(180, 23);
            _Label69.TabIndex = 27;
            _Label69.Text = "Certificate Type";
            // 
            // Label70
            // 
            _Label70.Location = new Point(6, 344);
            _Label70.Name = "Label70";
            _Label70.Size = new Size(180, 23);
            _Label70.TabIndex = 26;
            _Label70.Text = "Approx. Age Of Boiler";
            // 
            // Label62
            // 
            _Label62.Location = new Point(6, 317);
            _Label62.Name = "Label62";
            _Label62.Size = new Size(180, 23);
            _Label62.TabIndex = 25;
            _Label62.Text = "CO Detector Fitted ";
            // 
            // Label63
            // 
            _Label63.Location = new Point(6, 290);
            _Label63.Name = "Label63";
            _Label63.Size = new Size(180, 23);
            _Label63.TabIndex = 24;
            _Label63.Text = "Radiators";
            // 
            // Label64
            // 
            _Label64.Location = new Point(6, 128);
            _Label64.Name = "Label64";
            _Label64.Size = new Size(180, 23);
            _Label64.TabIndex = 23;
            _Label64.Text = "Is Strainer Inspected";
            // 
            // Label65
            // 
            _Label65.Location = new Point(6, 101);
            _Label65.Name = "Label65";
            _Label65.Size = new Size(180, 23);
            _Label65.TabIndex = 22;
            _Label65.Text = "Is Strainer Fitted";
            // 
            // Label66
            // 
            _Label66.Location = new Point(6, 263);
            _Label66.Name = "Label66";
            _Label66.Size = new Size(180, 23);
            _Label66.TabIndex = 21;
            _Label66.Text = "Immersion";
            // 
            // Label67
            // 
            _Label67.Location = new Point(6, 236);
            _Label67.Name = "Label67";
            _Label67.Size = new Size(180, 23);
            _Label67.TabIndex = 20;
            _Label67.Text = "Jacket";
            // 
            // cboCertificateTypeID
            // 
            _cboCertificateTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCertificateTypeID.Location = new Point(192, 368);
            _cboCertificateTypeID.Name = "cboCertificateTypeID";
            _cboCertificateTypeID.Size = new Size(160, 21);
            _cboCertificateTypeID.TabIndex = 13;
            // 
            // cboCODetectorFittedID
            // 
            _cboCODetectorFittedID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCODetectorFittedID.Location = new Point(192, 314);
            _cboCODetectorFittedID.Name = "cboCODetectorFittedID";
            _cboCODetectorFittedID.Size = new Size(160, 21);
            _cboCODetectorFittedID.TabIndex = 11;
            // 
            // cboVisualInspectionSatisfactoryID
            // 
            _cboVisualInspectionSatisfactoryID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisualInspectionSatisfactoryID.Location = new Point(192, 395);
            _cboVisualInspectionSatisfactoryID.Name = "cboVisualInspectionSatisfactoryID";
            _cboVisualInspectionSatisfactoryID.Size = new Size(160, 21);
            _cboVisualInspectionSatisfactoryID.TabIndex = 14;
            // 
            // cboImmersionID
            // 
            _cboImmersionID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboImmersionID.Location = new Point(192, 260);
            _cboImmersionID.Name = "cboImmersionID";
            _cboImmersionID.Size = new Size(160, 21);
            _cboImmersionID.TabIndex = 9;
            // 
            // cboJacketID
            // 
            _cboJacketID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJacketID.Location = new Point(192, 233);
            _cboJacketID.Name = "cboJacketID";
            _cboJacketID.Size = new Size(160, 21);
            _cboJacketID.TabIndex = 8;
            // 
            // cboCylinderTypeID
            // 
            _cboCylinderTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCylinderTypeID.Location = new Point(192, 206);
            _cboCylinderTypeID.Name = "cboCylinderTypeID";
            _cboCylinderTypeID.Size = new Size(160, 21);
            _cboCylinderTypeID.TabIndex = 7;
            // 
            // cboPartialHeatingID
            // 
            _cboPartialHeatingID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPartialHeatingID.Location = new Point(192, 179);
            _cboPartialHeatingID.Name = "cboPartialHeatingID";
            _cboPartialHeatingID.Size = new Size(160, 21);
            _cboPartialHeatingID.TabIndex = 6;
            // 
            // cboHeatingSystemTypeID
            // 
            _cboHeatingSystemTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboHeatingSystemTypeID.Location = new Point(192, 152);
            _cboHeatingSystemTypeID.Name = "cboHeatingSystemTypeID";
            _cboHeatingSystemTypeID.Size = new Size(160, 21);
            _cboHeatingSystemTypeID.TabIndex = 5;
            // 
            // txtApproxAgeOfBoiler
            // 
            _txtApproxAgeOfBoiler.Location = new Point(192, 341);
            _txtApproxAgeOfBoiler.Name = "txtApproxAgeOfBoiler";
            _txtApproxAgeOfBoiler.Size = new Size(160, 21);
            _txtApproxAgeOfBoiler.TabIndex = 12;
            _txtApproxAgeOfBoiler.Text = "0";
            // 
            // cboStrainerInspectedID
            // 
            _cboStrainerInspectedID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStrainerInspectedID.Location = new Point(192, 125);
            _cboStrainerInspectedID.Name = "cboStrainerInspectedID";
            _cboStrainerInspectedID.Size = new Size(160, 21);
            _cboStrainerInspectedID.TabIndex = 4;
            // 
            // Label56
            // 
            _Label56.Location = new Point(6, 209);
            _Label56.Name = "Label56";
            _Label56.Size = new Size(180, 23);
            _Label56.TabIndex = 9;
            _Label56.Text = "Cylinder type ";
            // 
            // Label57
            // 
            _Label57.Location = new Point(6, 182);
            _Label57.Name = "Label57";
            _Label57.Size = new Size(180, 23);
            _Label57.TabIndex = 8;
            _Label57.Text = "Partial Heating";
            // 
            // cboStrainerFittedID
            // 
            _cboStrainerFittedID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStrainerFittedID.Location = new Point(192, 98);
            _cboStrainerFittedID.Name = "cboStrainerFittedID";
            _cboStrainerFittedID.Size = new Size(160, 21);
            _cboStrainerFittedID.TabIndex = 3;
            // 
            // cboInstallationSafeToUseID
            // 
            _cboInstallationSafeToUseID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInstallationSafeToUseID.Location = new Point(192, 71);
            _cboInstallationSafeToUseID.Name = "cboInstallationSafeToUseID";
            _cboInstallationSafeToUseID.Size = new Size(160, 21);
            _cboInstallationSafeToUseID.TabIndex = 2;
            // 
            // cboInstallationPipeWorkCorrectID
            // 
            _cboInstallationPipeWorkCorrectID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInstallationPipeWorkCorrectID.Location = new Point(192, 44);
            _cboInstallationPipeWorkCorrectID.Name = "cboInstallationPipeWorkCorrectID";
            _cboInstallationPipeWorkCorrectID.Size = new Size(160, 21);
            _cboInstallationPipeWorkCorrectID.TabIndex = 1;
            // 
            // cboCorrectMaterialsUsedID
            // 
            _cboCorrectMaterialsUsedID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCorrectMaterialsUsedID.Location = new Point(192, 17);
            _cboCorrectMaterialsUsedID.Name = "cboCorrectMaterialsUsedID";
            _cboCorrectMaterialsUsedID.Size = new Size(160, 21);
            _cboCorrectMaterialsUsedID.TabIndex = 0;
            // 
            // Label58
            // 
            _Label58.Location = new Point(6, 155);
            _Label58.Name = "Label58";
            _Label58.Size = new Size(180, 23);
            _Label58.TabIndex = 3;
            _Label58.Text = "Heating System Type";
            // 
            // Label59
            // 
            _Label59.Location = new Point(6, 74);
            _Label59.Name = "Label59";
            _Label59.Size = new Size(180, 23);
            _Label59.TabIndex = 2;
            _Label59.Text = "Installation Safe To Use ";
            // 
            // Label60
            // 
            _Label60.Location = new Point(6, 47);
            _Label60.Name = "Label60";
            _Label60.Size = new Size(180, 23);
            _Label60.TabIndex = 1;
            _Label60.Text = "Installation Pipework Correct";
            // 
            // Label61
            // 
            _Label61.Location = new Point(6, 20);
            _Label61.Name = "Label61";
            _Label61.Size = new Size(180, 23);
            _Label61.TabIndex = 0;
            _Label61.Text = "Correct Materials Used In Installation ";
            // 
            // grpVisitDefects
            // 
            _grpVisitDefects.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _grpVisitDefects.Controls.Add(_btnAddVisitDefect);
            _grpVisitDefects.Controls.Add(_btnRemoveVisitDefect);
            _grpVisitDefects.Controls.Add(_dgVisitDefects);
            _grpVisitDefects.Location = new Point(8, 503);
            _grpVisitDefects.Name = "grpVisitDefects";
            _grpVisitDefects.Size = new Size(501, 141);
            _grpVisitDefects.TabIndex = 2;
            _grpVisitDefects.TabStop = false;
            _grpVisitDefects.Text = "Visit Defects";
            // 
            // btnAddVisitDefect
            // 
            _btnAddVisitDefect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddVisitDefect.Location = new Point(421, 109);
            _btnAddVisitDefect.Name = "btnAddVisitDefect";
            _btnAddVisitDefect.Size = new Size(75, 23);
            _btnAddVisitDefect.TabIndex = 3;
            _btnAddVisitDefect.Text = "Add";
            // 
            // btnRemoveVisitDefect
            // 
            _btnRemoveVisitDefect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveVisitDefect.Location = new Point(8, 109);
            _btnRemoveVisitDefect.Name = "btnRemoveVisitDefect";
            _btnRemoveVisitDefect.Size = new Size(75, 23);
            _btnRemoveVisitDefect.TabIndex = 2;
            _btnRemoveVisitDefect.Text = "Remove";
            // 
            // dgVisitDefects
            // 
            _dgVisitDefects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisitDefects.DataMember = "";
            _dgVisitDefects.HeaderForeColor = SystemColors.ControlText;
            _dgVisitDefects.Location = new Point(8, 20);
            _dgVisitDefects.Name = "dgVisitDefects";
            _dgVisitDefects.Size = new Size(485, 83);
            _dgVisitDefects.TabIndex = 1;
            // 
            // grpApplianceWorksheet
            // 
            _grpApplianceWorksheet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpApplianceWorksheet.Controls.Add(_btnRemoveApplianceWorkSheet);
            _grpApplianceWorksheet.Controls.Add(_dgApplianceWorkSheets);
            _grpApplianceWorksheet.Controls.Add(_btnAddApplianceWorksheet);
            _grpApplianceWorksheet.Location = new Point(8, 256);
            _grpApplianceWorksheet.Name = "grpApplianceWorksheet";
            _grpApplianceWorksheet.Size = new Size(501, 247);
            _grpApplianceWorksheet.TabIndex = 1;
            _grpApplianceWorksheet.TabStop = false;
            _grpApplianceWorksheet.Text = "Appliance Worksheets";
            // 
            // btnRemoveApplianceWorkSheet
            // 
            _btnRemoveApplianceWorkSheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveApplianceWorkSheet.Location = new Point(8, 218);
            _btnRemoveApplianceWorkSheet.Name = "btnRemoveApplianceWorkSheet";
            _btnRemoveApplianceWorkSheet.Size = new Size(75, 23);
            _btnRemoveApplianceWorkSheet.TabIndex = 3;
            _btnRemoveApplianceWorkSheet.Text = "Remove";
            // 
            // dgApplianceWorkSheets
            // 
            _dgApplianceWorkSheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgApplianceWorkSheets.DataMember = "";
            _dgApplianceWorkSheets.HeaderForeColor = SystemColors.ControlText;
            _dgApplianceWorkSheets.Location = new Point(8, 20);
            _dgApplianceWorkSheets.Name = "dgApplianceWorkSheets";
            _dgApplianceWorkSheets.Size = new Size(485, 192);
            _dgApplianceWorkSheets.TabIndex = 0;
            // 
            // btnAddApplianceWorksheet
            // 
            _btnAddApplianceWorksheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddApplianceWorksheet.Location = new Point(413, 218);
            _btnAddApplianceWorksheet.Name = "btnAddApplianceWorksheet";
            _btnAddApplianceWorksheet.Size = new Size(75, 23);
            _btnAddApplianceWorksheet.TabIndex = 4;
            _btnAddApplianceWorksheet.Text = "Add";
            // 
            // grpVisitWorksheet
            // 
            _grpVisitWorksheet.Controls.Add(_cboMeterCapped);
            _grpVisitWorksheet.Controls.Add(_Label73);
            _grpVisitWorksheet.Controls.Add(_cboMeterLocation);
            _grpVisitWorksheet.Controls.Add(_Label72);
            _grpVisitWorksheet.Controls.Add(_txtAmountCollected);
            _grpVisitWorksheet.Controls.Add(_cboPaymentMethod);
            _grpVisitWorksheet.Controls.Add(_Label44);
            _grpVisitWorksheet.Controls.Add(_Label43);
            _grpVisitWorksheet.Controls.Add(_cboPropertyRented);
            _grpVisitWorksheet.Controls.Add(_cboBonding);
            _grpVisitWorksheet.Controls.Add(_cboEmergencyControlAccessible);
            _grpVisitWorksheet.Controls.Add(_cboGasInstallationTightnessTest);
            _grpVisitWorksheet.Controls.Add(_Label41);
            _grpVisitWorksheet.Controls.Add(_Label40);
            _grpVisitWorksheet.Controls.Add(_Label8);
            _grpVisitWorksheet.Controls.Add(_Label7);
            _grpVisitWorksheet.Location = new Point(8, 8);
            _grpVisitWorksheet.Name = "grpVisitWorksheet";
            _grpVisitWorksheet.Size = new Size(501, 242);
            _grpVisitWorksheet.TabIndex = 0;
            _grpVisitWorksheet.TabStop = false;
            _grpVisitWorksheet.Text = "Visit Worksheet";
            // 
            // cboMeterCapped
            // 
            _cboMeterCapped.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboMeterCapped.Location = new Point(216, 211);
            _cboMeterCapped.Name = "cboMeterCapped";
            _cboMeterCapped.Size = new Size(276, 21);
            _cboMeterCapped.TabIndex = 15;
            // 
            // Label73
            // 
            _Label73.Location = new Point(16, 214);
            _Label73.Name = "Label73";
            _Label73.Size = new Size(120, 23);
            _Label73.TabIndex = 14;
            _Label73.Text = "Meter Capped";
            // 
            // cboMeterLocation
            // 
            _cboMeterLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboMeterLocation.Location = new Point(216, 182);
            _cboMeterLocation.Name = "cboMeterLocation";
            _cboMeterLocation.Size = new Size(276, 21);
            _cboMeterLocation.TabIndex = 13;
            // 
            // Label72
            // 
            _Label72.Location = new Point(16, 185);
            _Label72.Name = "Label72";
            _Label72.Size = new Size(120, 23);
            _Label72.TabIndex = 12;
            _Label72.Text = "Meter Location";
            // 
            // txtAmountCollected
            // 
            _txtAmountCollected.Location = new Point(216, 155);
            _txtAmountCollected.Name = "txtAmountCollected";
            _txtAmountCollected.Size = new Size(276, 21);
            _txtAmountCollected.TabIndex = 11;
            // 
            // cboPaymentMethod
            // 
            _cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPaymentMethod.Location = new Point(216, 128);
            _cboPaymentMethod.Name = "cboPaymentMethod";
            _cboPaymentMethod.Size = new Size(276, 21);
            _cboPaymentMethod.TabIndex = 10;
            // 
            // Label44
            // 
            _Label44.Location = new Point(16, 158);
            _Label44.Name = "Label44";
            _Label44.Size = new Size(120, 23);
            _Label44.TabIndex = 9;
            _Label44.Text = "Amount Collected";
            // 
            // Label43
            // 
            _Label43.Location = new Point(16, 131);
            _Label43.Name = "Label43";
            _Label43.Size = new Size(100, 23);
            _Label43.TabIndex = 8;
            _Label43.Text = "Payment Method";
            // 
            // cboPropertyRented
            // 
            _cboPropertyRented.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPropertyRented.Location = new Point(216, 101);
            _cboPropertyRented.Name = "cboPropertyRented";
            _cboPropertyRented.Size = new Size(276, 21);
            _cboPropertyRented.TabIndex = 7;
            // 
            // cboBonding
            // 
            _cboBonding.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboBonding.Location = new Point(216, 74);
            _cboBonding.Name = "cboBonding";
            _cboBonding.Size = new Size(276, 21);
            _cboBonding.TabIndex = 6;
            // 
            // cboEmergencyControlAccessible
            // 
            _cboEmergencyControlAccessible.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEmergencyControlAccessible.Location = new Point(216, 47);
            _cboEmergencyControlAccessible.Name = "cboEmergencyControlAccessible";
            _cboEmergencyControlAccessible.Size = new Size(276, 21);
            _cboEmergencyControlAccessible.TabIndex = 5;
            // 
            // cboGasInstallationTightnessTest
            // 
            _cboGasInstallationTightnessTest.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboGasInstallationTightnessTest.Location = new Point(216, 20);
            _cboGasInstallationTightnessTest.Name = "cboGasInstallationTightnessTest";
            _cboGasInstallationTightnessTest.Size = new Size(276, 21);
            _cboGasInstallationTightnessTest.TabIndex = 4;
            // 
            // Label41
            // 
            _Label41.Location = new Point(16, 104);
            _Label41.Name = "Label41";
            _Label41.Size = new Size(128, 23);
            _Label41.TabIndex = 3;
            _Label41.Text = "Property Rented";
            // 
            // Label40
            // 
            _Label40.Location = new Point(16, 77);
            _Label40.Name = "Label40";
            _Label40.Size = new Size(64, 23);
            _Label40.TabIndex = 2;
            _Label40.Text = "Bonding";
            // 
            // Label8
            // 
            _Label8.Location = new Point(16, 50);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(192, 23);
            _Label8.TabIndex = 1;
            _Label8.Text = "Emergency Control Accessible";
            // 
            // Label7
            // 
            _Label7.Location = new Point(16, 23);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(192, 23);
            _Label7.TabIndex = 0;
            _Label7.Text = "Gas Installation Tightness Test";
            // 
            // tpTimesheets
            // 
            _tpTimesheets.Controls.Add(_grpTimesheets);
            _tpTimesheets.Controls.Add(_txtScheduledTime);
            _tpTimesheets.Controls.Add(_Label10);
            _tpTimesheets.Location = new Point(4, 22);
            _tpTimesheets.Name = "tpTimesheets";
            _tpTimesheets.Size = new Size(1247, 652);
            _tpTimesheets.TabIndex = 2;
            _tpTimesheets.Text = "Timesheets";
            _tpTimesheets.UseVisualStyleBackColor = true;
            // 
            // grpTimesheets
            // 
            _grpTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpTimesheets.Controls.Add(_txtActualTimeSpent);
            _grpTimesheets.Controls.Add(_txtDifference);
            _grpTimesheets.Controls.Add(_txtSORTimeAllowance);
            _grpTimesheets.Controls.Add(_Label52);
            _grpTimesheets.Controls.Add(_Label51);
            _grpTimesheets.Controls.Add(_Label50);
            _grpTimesheets.Controls.Add(_Label22);
            _grpTimesheets.Controls.Add(_cboTimeSheetType);
            _grpTimesheets.Controls.Add(_Label14);
            _grpTimesheets.Controls.Add(_txtComments);
            _grpTimesheets.Controls.Add(_dtpEndDate);
            _grpTimesheets.Controls.Add(_dtpStartDate);
            _grpTimesheets.Controls.Add(_dgTimeSheets);
            _grpTimesheets.Controls.Add(_btnAddTimeSheet);
            _grpTimesheets.Controls.Add(_Label20);
            _grpTimesheets.Controls.Add(_Label21);
            _grpTimesheets.Controls.Add(_btnRemoveTimeSheet);
            _grpTimesheets.Location = new Point(8, 48);
            _grpTimesheets.Name = "grpTimesheets";
            _grpTimesheets.Size = new Size(1231, 598);
            _grpTimesheets.TabIndex = 3;
            _grpTimesheets.TabStop = false;
            _grpTimesheets.Text = "TimeSheets";
            // 
            // txtActualTimeSpent
            // 
            _txtActualTimeSpent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtActualTimeSpent.Location = new Point(348, 541);
            _txtActualTimeSpent.Name = "txtActualTimeSpent";
            _txtActualTimeSpent.ReadOnly = true;
            _txtActualTimeSpent.Size = new Size(136, 21);
            _txtActualTimeSpent.TabIndex = 70;
            // 
            // txtDifference
            // 
            _txtDifference.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtDifference.Location = new Point(348, 571);
            _txtDifference.Name = "txtDifference";
            _txtDifference.ReadOnly = true;
            _txtDifference.Size = new Size(136, 21);
            _txtDifference.TabIndex = 72;
            // 
            // txtSORTimeAllowance
            // 
            _txtSORTimeAllowance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtSORTimeAllowance.Location = new Point(348, 509);
            _txtSORTimeAllowance.Name = "txtSORTimeAllowance";
            _txtSORTimeAllowance.ReadOnly = true;
            _txtSORTimeAllowance.Size = new Size(136, 21);
            _txtSORTimeAllowance.TabIndex = 68;
            // 
            // Label52
            // 
            _Label52.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label52.AutoSize = true;
            _Label52.Location = new Point(203, 577);
            _Label52.Name = "Label52";
            _Label52.Size = new Size(71, 13);
            _Label52.TabIndex = 71;
            _Label52.Text = "Difference:";
            // 
            // Label51
            // 
            _Label51.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label51.AutoSize = true;
            _Label51.Location = new Point(203, 544);
            _Label51.Name = "Label51";
            _Label51.Size = new Size(103, 13);
            _Label51.TabIndex = 69;
            _Label51.Text = "Act. Time Spent:";
            // 
            // Label50
            // 
            _Label50.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label50.AutoSize = true;
            _Label50.Location = new Point(203, 512);
            _Label50.Name = "Label50";
            _Label50.Size = new Size(130, 13);
            _Label50.TabIndex = 67;
            _Label50.Text = "SOR Time Allowance:";
            // 
            // Label22
            // 
            _Label22.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label22.Location = new Point(506, 512);
            _Label22.Name = "Label22";
            _Label22.Size = new Size(72, 23);
            _Label22.TabIndex = 66;
            _Label22.Text = "Comments";
            // 
            // cboTimeSheetType
            // 
            _cboTimeSheetType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cboTimeSheetType.Location = new Point(46, 509);
            _cboTimeSheetType.Name = "cboTimeSheetType";
            _cboTimeSheetType.Size = new Size(136, 21);
            _cboTimeSheetType.TabIndex = 3;
            // 
            // Label14
            // 
            _Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label14.Location = new Point(5, 512);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(41, 23);
            _Label14.TabIndex = 64;
            _Label14.Text = "Type";
            // 
            // txtComments
            // 
            _txtComments.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtComments.Location = new Point(584, 509);
            _txtComments.Multiline = true;
            _txtComments.Name = "txtComments";
            _txtComments.ScrollBars = ScrollBars.Vertical;
            _txtComments.Size = new Size(404, 83);
            _txtComments.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            _dtpEndDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            _dtpEndDate.Format = DateTimePickerFormat.Custom;
            _dtpEndDate.Location = new Point(46, 571);
            _dtpEndDate.Name = "dtpEndDate";
            _dtpEndDate.Size = new Size(136, 21);
            _dtpEndDate.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            _dtpStartDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            _dtpStartDate.Format = DateTimePickerFormat.Custom;
            _dtpStartDate.Location = new Point(46, 540);
            _dtpStartDate.Name = "dtpStartDate";
            _dtpStartDate.Size = new Size(136, 21);
            _dtpStartDate.TabIndex = 1;
            // 
            // dgTimeSheets
            // 
            _dgTimeSheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTimeSheets.DataMember = "";
            _dgTimeSheets.HeaderForeColor = SystemColors.ControlText;
            _dgTimeSheets.Location = new Point(8, 30);
            _dgTimeSheets.Name = "dgTimeSheets";
            _dgTimeSheets.Size = new Size(1215, 466);
            _dgTimeSheets.TabIndex = 7;
            _dgTimeSheets.TabStop = false;
            // 
            // btnAddTimeSheet
            // 
            _btnAddTimeSheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddTimeSheet.Location = new Point(1151, 569);
            _btnAddTimeSheet.Name = "btnAddTimeSheet";
            _btnAddTimeSheet.Size = new Size(72, 23);
            _btnAddTimeSheet.TabIndex = 5;
            _btnAddTimeSheet.Text = "Add";
            // 
            // Label20
            // 
            _Label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label20.Location = new Point(5, 573);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(35, 23);
            _Label20.TabIndex = 28;
            _Label20.Text = "End";
            // 
            // Label21
            // 
            _Label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label21.Location = new Point(5, 544);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(35, 23);
            _Label21.TabIndex = 25;
            _Label21.Text = "Start Date/Time";
            // 
            // btnRemoveTimeSheet
            // 
            _btnRemoveTimeSheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveTimeSheet.Location = new Point(1151, 534);
            _btnRemoveTimeSheet.Name = "btnRemoveTimeSheet";
            _btnRemoveTimeSheet.Size = new Size(72, 23);
            _btnRemoveTimeSheet.TabIndex = 6;
            _btnRemoveTimeSheet.Text = "Remove";
            // 
            // txtScheduledTime
            // 
            _txtScheduledTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtScheduledTime.Location = new Point(112, 16);
            _txtScheduledTime.Name = "txtScheduledTime";
            _txtScheduledTime.ReadOnly = true;
            _txtScheduledTime.Size = new Size(1127, 21);
            _txtScheduledTime.TabIndex = 1;
            // 
            // Label10
            // 
            _Label10.Location = new Point(8, 16);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(104, 16);
            _Label10.TabIndex = 9;
            _Label10.Text = "Scheduled time";
            // 
            // tpPartsAndProducts
            // 
            _tpPartsAndProducts.Controls.Add(_grpAllocated);
            _tpPartsAndProducts.Controls.Add(_grpUsed);
            _tpPartsAndProducts.Location = new Point(4, 22);
            _tpPartsAndProducts.Name = "tpPartsAndProducts";
            _tpPartsAndProducts.Size = new Size(1247, 652);
            _tpPartsAndProducts.TabIndex = 1;
            _tpPartsAndProducts.Text = "Parts && Products";
            _tpPartsAndProducts.UseVisualStyleBackColor = true;
            // 
            // grpAllocated
            // 
            _grpAllocated.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpAllocated.Controls.Add(_btnUnselectAllPPA);
            _grpAllocated.Controls.Add(_btnSelectAllPPA);
            _grpAllocated.Controls.Add(_btnRevertUsed);
            _grpAllocated.Controls.Add(_nudPartAllocatedQty);
            _grpAllocated.Controls.Add(_lblAllocatedQuantity);
            _grpAllocated.Controls.Add(_btnAllUsed);
            _grpAllocated.Controls.Add(_Label35);
            _grpAllocated.Controls.Add(_Panel2);
            _grpAllocated.Controls.Add(_Label34);
            _grpAllocated.Controls.Add(_Panel1);
            _grpAllocated.Controls.Add(_btnAllocatedNotUsed);
            _grpAllocated.Controls.Add(_dgPartsProductsAllocated);
            _grpAllocated.Controls.Add(_lblQuantityWarning);
            _grpAllocated.Location = new Point(8, 8);
            _grpAllocated.Name = "grpAllocated";
            _grpAllocated.Size = new Size(1231, 275);
            _grpAllocated.TabIndex = 1;
            _grpAllocated.TabStop = false;
            _grpAllocated.Text = "Parts && Products Allocated";
            // 
            // btnUnselectAllPPA
            // 
            _btnUnselectAllPPA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnUnselectAllPPA.Location = new Point(438, 244);
            _btnUnselectAllPPA.Name = "btnUnselectAllPPA";
            _btnUnselectAllPPA.Size = new Size(98, 23);
            _btnUnselectAllPPA.TabIndex = 34;
            _btnUnselectAllPPA.Text = "Deselect All";
            // 
            // btnSelectAllPPA
            // 
            _btnSelectAllPPA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAllPPA.Location = new Point(334, 244);
            _btnSelectAllPPA.Name = "btnSelectAllPPA";
            _btnSelectAllPPA.Size = new Size(98, 23);
            _btnSelectAllPPA.TabIndex = 33;
            _btnSelectAllPPA.Text = "Select All";
            // 
            // btnRevertUsed
            // 
            _btnRevertUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRevertUsed.Location = new Point(234, 244);
            _btnRevertUsed.Name = "btnRevertUsed";
            _btnRevertUsed.Size = new Size(96, 23);
            _btnRevertUsed.TabIndex = 32;
            _btnRevertUsed.Text = "Revert Used";
            // 
            // nudPartAllocatedQty
            // 
            _nudPartAllocatedQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _nudPartAllocatedQty.Location = new Point(937, 243);
            _nudPartAllocatedQty.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            _nudPartAllocatedQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _nudPartAllocatedQty.Name = "nudPartAllocatedQty";
            _nudPartAllocatedQty.Size = new Size(64, 21);
            _nudPartAllocatedQty.TabIndex = 29;
            _nudPartAllocatedQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblAllocatedQuantity
            // 
            _lblAllocatedQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblAllocatedQuantity.Location = new Point(873, 243);
            _lblAllocatedQuantity.Name = "lblAllocatedQuantity";
            _lblAllocatedQuantity.Size = new Size(64, 23);
            _lblAllocatedQuantity.TabIndex = 30;
            _lblAllocatedQuantity.Text = "Quantity";
            // 
            // btnAllUsed
            // 
            _btnAllUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAllUsed.Location = new Point(1015, 243);
            _btnAllUsed.Name = "btnAllUsed";
            _btnAllUsed.Size = new Size(96, 23);
            _btnAllUsed.TabIndex = 2;
            _btnAllUsed.Text = "Used";
            // 
            // Label35
            // 
            _Label35.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label35.Location = new Point(160, 249);
            _Label35.Name = "Label35";
            _Label35.Size = new Size(104, 16);
            _Label35.TabIndex = 28;
            _Label35.Text = "Distributed";
            // 
            // Panel2
            // 
            _Panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel2.BackColor = Color.Lime;
            _Panel2.Location = new Point(136, 247);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(16, 16);
            _Panel2.TabIndex = 27;
            // 
            // Label34
            // 
            _Label34.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label34.Location = new Point(32, 249);
            _Label34.Name = "Label34";
            _Label34.Size = new Size(104, 16);
            _Label34.TabIndex = 26;
            _Label34.Text = "Not Distributed";
            // 
            // Panel1
            // 
            _Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel1.BackColor = Color.Red;
            _Panel1.Location = new Point(8, 246);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(16, 16);
            _Panel1.TabIndex = 25;
            // 
            // btnAllocatedNotUsed
            // 
            _btnAllocatedNotUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAllocatedNotUsed.Location = new Point(1119, 243);
            _btnAllocatedNotUsed.Name = "btnAllocatedNotUsed";
            _btnAllocatedNotUsed.Size = new Size(96, 23);
            _btnAllocatedNotUsed.TabIndex = 3;
            _btnAllocatedNotUsed.Text = "Not Used";
            // 
            // dgPartsProductsAllocated
            // 
            _dgPartsProductsAllocated.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPartsProductsAllocated.DataMember = "";
            _dgPartsProductsAllocated.HeaderForeColor = SystemColors.ControlText;
            _dgPartsProductsAllocated.Location = new Point(8, 18);
            _dgPartsProductsAllocated.Name = "dgPartsProductsAllocated";
            _dgPartsProductsAllocated.Size = new Size(1215, 222);
            _dgPartsProductsAllocated.TabIndex = 1;
            _dgPartsProductsAllocated.TabStop = false;
            // 
            // lblQuantityWarning
            // 
            _lblQuantityWarning.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblQuantityWarning.AutoSize = true;
            _lblQuantityWarning.Location = new Point(603, 249);
            _lblQuantityWarning.Name = "lblQuantityWarning";
            _lblQuantityWarning.Size = new Size(241, 13);
            _lblQuantityWarning.TabIndex = 31;
            _lblQuantityWarning.Text = "The quantity ordered will be carried over";
            _lblQuantityWarning.Visible = false;
            // 
            // grpUsed
            // 
            _grpUsed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpUsed.Controls.Add(_lblEquipment);
            _grpUsed.Controls.Add(_lblSellPrice);
            _grpUsed.Controls.Add(_dgPartsAndProductsUsed);
            _grpUsed.Controls.Add(_btnAddPartProductUsed);
            _grpUsed.Controls.Add(_nudQuantityUsed);
            _grpUsed.Controls.Add(_txtNameUsed);
            _grpUsed.Controls.Add(_txtNumberUsed);
            _grpUsed.Controls.Add(_Label13);
            _grpUsed.Controls.Add(_Label15);
            _grpUsed.Controls.Add(_Label16);
            _grpUsed.Controls.Add(_btnRemovePartProductUsed);
            _grpUsed.Controls.Add(_btnFindProductUsed);
            _grpUsed.Controls.Add(_btnFindPartUsed);
            _grpUsed.Location = new Point(8, 289);
            _grpUsed.Name = "grpUsed";
            _grpUsed.Size = new Size(1231, 360);
            _grpUsed.TabIndex = 2;
            _grpUsed.TabStop = false;
            _grpUsed.Text = "Parts && Products Used";
            // 
            // lblEquipment
            // 
            _lblEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblEquipment.Location = new Point(853, 296);
            _lblEquipment.Name = "lblEquipment";
            _lblEquipment.Size = new Size(100, 23);
            _lblEquipment.TabIndex = 24;
            _lblEquipment.Text = "Equipment?";
            _lblEquipment.Visible = false;
            // 
            // lblSellPrice
            // 
            _lblSellPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblSellPrice.Location = new Point(1007, 296);
            _lblSellPrice.Name = "lblSellPrice";
            _lblSellPrice.Size = new Size(100, 23);
            _lblSellPrice.TabIndex = 23;
            _lblSellPrice.Text = "SELL PRICE";
            _lblSellPrice.Visible = false;
            // 
            // dgPartsAndProductsUsed
            // 
            _dgPartsAndProductsUsed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPartsAndProductsUsed.DataMember = "";
            _dgPartsAndProductsUsed.HeaderForeColor = SystemColors.ControlText;
            _dgPartsAndProductsUsed.Location = new Point(8, 13);
            _dgPartsAndProductsUsed.Name = "dgPartsAndProductsUsed";
            _dgPartsAndProductsUsed.Size = new Size(1215, 283);
            _dgPartsAndProductsUsed.TabIndex = 1;
            _dgPartsAndProductsUsed.TabStop = false;
            // 
            // btnAddPartProductUsed
            // 
            _btnAddPartProductUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddPartProductUsed.Enabled = false;
            _btnAddPartProductUsed.Location = new Point(1119, 328);
            _btnAddPartProductUsed.Name = "btnAddPartProductUsed";
            _btnAddPartProductUsed.Size = new Size(96, 23);
            _btnAddPartProductUsed.TabIndex = 5;
            _btnAddPartProductUsed.Text = "PICK ITEM";
            // 
            // nudQuantityUsed
            // 
            _nudQuantityUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _nudQuantityUsed.Location = new Point(1047, 328);
            _nudQuantityUsed.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            _nudQuantityUsed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _nudQuantityUsed.Name = "nudQuantityUsed";
            _nudQuantityUsed.Size = new Size(64, 21);
            _nudQuantityUsed.TabIndex = 4;
            _nudQuantityUsed.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtNameUsed
            // 
            _txtNameUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtNameUsed.Location = new Point(312, 328);
            _txtNameUsed.Name = "txtNameUsed";
            _txtNameUsed.ReadOnly = true;
            _txtNameUsed.Size = new Size(671, 21);
            _txtNameUsed.TabIndex = 8;
            // 
            // txtNumberUsed
            // 
            _txtNumberUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtNumberUsed.Location = new Point(72, 328);
            _txtNumberUsed.Name = "txtNumberUsed";
            _txtNumberUsed.ReadOnly = true;
            _txtNumberUsed.Size = new Size(184, 21);
            _txtNumberUsed.TabIndex = 7;
            // 
            // Label13
            // 
            _Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label13.Location = new Point(983, 328);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(64, 23);
            _Label13.TabIndex = 16;
            _Label13.Text = "Quantity";
            // 
            // Label15
            // 
            _Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label15.Location = new Point(264, 328);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(64, 23);
            _Label15.TabIndex = 15;
            _Label15.Text = "Name";
            // 
            // Label16
            // 
            _Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label16.Location = new Point(8, 328);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(72, 23);
            _Label16.TabIndex = 12;
            _Label16.Text = "Number";
            // 
            // btnRemovePartProductUsed
            // 
            _btnRemovePartProductUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemovePartProductUsed.Location = new Point(1119, 296);
            _btnRemovePartProductUsed.Name = "btnRemovePartProductUsed";
            _btnRemovePartProductUsed.Size = new Size(96, 23);
            _btnRemovePartProductUsed.TabIndex = 6;
            _btnRemovePartProductUsed.Text = "Remove";
            // 
            // btnFindProductUsed
            // 
            _btnFindProductUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnFindProductUsed.Location = new Point(104, 296);
            _btnFindProductUsed.Name = "btnFindProductUsed";
            _btnFindProductUsed.Size = new Size(88, 23);
            _btnFindProductUsed.TabIndex = 3;
            _btnFindProductUsed.Text = "Find Product";
            // 
            // btnFindPartUsed
            // 
            _btnFindPartUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnFindPartUsed.Location = new Point(8, 296);
            _btnFindPartUsed.Name = "btnFindPartUsed";
            _btnFindPartUsed.Size = new Size(88, 23);
            _btnFindPartUsed.TabIndex = 2;
            _btnFindPartUsed.Text = "Find Part";
            // 
            // tpOutcomes
            // 
            _tpOutcomes.Controls.Add(_grpOutcomes);
            _tpOutcomes.Location = new Point(4, 22);
            _tpOutcomes.Name = "tpOutcomes";
            _tpOutcomes.Padding = new Padding(3);
            _tpOutcomes.Size = new Size(1247, 652);
            _tpOutcomes.TabIndex = 7;
            _tpOutcomes.Text = "Outcomes";
            _tpOutcomes.UseVisualStyleBackColor = true;
            // 
            // grpOutcomes
            // 
            _grpOutcomes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpOutcomes.Controls.Add(_grpSiteFuels);
            _grpOutcomes.Controls.Add(_cboNccRad);
            _grpOutcomes.Controls.Add(_Label76);
            _grpOutcomes.Controls.Add(_cboRecharge);
            _grpOutcomes.Controls.Add(_Label75);
            _grpOutcomes.Controls.Add(_chkRecharge);
            _grpOutcomes.Controls.Add(_chkGasServiceCompleted);
            _grpOutcomes.Location = new Point(8, 6);
            _grpOutcomes.Name = "grpOutcomes";
            _grpOutcomes.Size = new Size(1231, 640);
            _grpOutcomes.TabIndex = 2;
            _grpOutcomes.TabStop = false;
            _grpOutcomes.Text = "Tick those that have been completed on this visit";
            // 
            // grpSiteFuels
            // 
            _grpSiteFuels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSiteFuels.Controls.Add(_dgSiteFuel);
            _grpSiteFuels.Location = new Point(3, 17);
            _grpSiteFuels.Margin = new Padding(0);
            _grpSiteFuels.Name = "grpSiteFuels";
            _grpSiteFuels.Padding = new Padding(0);
            _grpSiteFuels.Size = new Size(437, 390);
            _grpSiteFuels.TabIndex = 15;
            _grpSiteFuels.TabStop = false;
            _grpSiteFuels.Text = "Site Fuel";
            // 
            // dgSiteFuel
            // 
            _dgSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSiteFuel.DataMember = "";
            _dgSiteFuel.HeaderForeColor = SystemColors.ControlText;
            _dgSiteFuel.Location = new Point(5, 19);
            _dgSiteFuel.Name = "dgSiteFuel";
            _dgSiteFuel.Size = new Size(429, 366);
            _dgSiteFuel.TabIndex = 11;
            // 
            // cboNccRad
            // 
            _cboNccRad.FormattingEnabled = true;
            _cboNccRad.Location = new Point(649, 108);
            _cboNccRad.Name = "cboNccRad";
            _cboNccRad.Size = new Size(180, 21);
            _cboNccRad.TabIndex = 9;
            // 
            // Label76
            // 
            _Label76.AutoSize = true;
            _Label76.Location = new Point(458, 111);
            _Label76.Name = "Label76";
            _Label76.Size = new Size(172, 13);
            _Label76.TabIndex = 8;
            _Label76.Text = "Ncc Radiator Removal / Refit";
            // 
            // cboRecharge
            // 
            _cboRecharge.FormattingEnabled = true;
            _cboRecharge.Location = new Point(649, 81);
            _cboRecharge.Name = "cboRecharge";
            _cboRecharge.Size = new Size(180, 21);
            _cboRecharge.TabIndex = 7;
            // 
            // Label75
            // 
            _Label75.AutoSize = true;
            _Label75.Location = new Point(458, 84);
            _Label75.Name = "Label75";
            _Label75.Size = new Size(83, 13);
            _Label75.TabIndex = 6;
            _Label75.Text = "Recharge To:";
            // 
            // chkRecharge
            // 
            _chkRecharge.AutoSize = true;
            _chkRecharge.Location = new Point(458, 59);
            _chkRecharge.Name = "chkRecharge";
            _chkRecharge.Size = new Size(80, 17);
            _chkRecharge.TabIndex = 2;
            _chkRecharge.Text = "Recharge";
            _chkRecharge.UseVisualStyleBackColor = true;
            // 
            // chkGasServiceCompleted
            // 
            _chkGasServiceCompleted.AutoSize = true;
            _chkGasServiceCompleted.Location = new Point(458, 36);
            _chkGasServiceCompleted.Name = "chkGasServiceCompleted";
            _chkGasServiceCompleted.Size = new Size(135, 17);
            _chkGasServiceCompleted.TabIndex = 1;
            _chkGasServiceCompleted.Text = "Service Completed";
            _chkGasServiceCompleted.UseVisualStyleBackColor = true;
            // 
            // tpQC
            // 
            _tpQC.Controls.Add(_GroupBox4);
            _tpQC.Location = new Point(4, 22);
            _tpQC.Name = "tpQC";
            _tpQC.Padding = new Padding(3);
            _tpQC.Size = new Size(1247, 652);
            _tpQC.TabIndex = 8;
            _tpQC.Text = "QC";
            _tpQC.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            _GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox4.Controls.Add(_grpQCField);
            _GroupBox4.Controls.Add(_grpOfficeQC);
            _GroupBox4.Location = new Point(8, 0);
            _GroupBox4.Name = "GroupBox4";
            _GroupBox4.Size = new Size(1235, 646);
            _GroupBox4.TabIndex = 0;
            _GroupBox4.TabStop = false;
            _GroupBox4.Text = "QC";
            // 
            // grpQCField
            // 
            _grpQCField.Controls.Add(_cboQCCustSig);
            _grpQCField.Controls.Add(_lblQCCustSig);
            _grpQCField.Controls.Add(_cboRecallEngineer);
            _grpQCField.Controls.Add(_Label49);
            _grpQCField.Controls.Add(_cboRecall);
            _grpQCField.Controls.Add(_Label48);
            _grpQCField.Controls.Add(_dtpQCDocumentsRecieved);
            _grpQCField.Controls.Add(_chkQCDocumentsRecieved);
            _grpQCField.Controls.Add(_txtQCPoorJobNotes);
            _grpQCField.Controls.Add(_lblQCPoorJobNotes);
            _grpQCField.Controls.Add(_cboQCEngineerPaymentRecieved);
            _grpQCField.Controls.Add(_lblQCEngineerMonies);
            _grpQCField.Controls.Add(_cboQCPaymentSelection);
            _grpQCField.Controls.Add(_lblQCEngPaymentMethod);
            _grpQCField.Controls.Add(_cboQCAppliance);
            _grpQCField.Controls.Add(_cboQCPaymentCollection);
            _grpQCField.Controls.Add(_lblQCPaymentCollection);
            _grpQCField.Controls.Add(_cboQCJobUploadTimescale);
            _grpQCField.Controls.Add(_lblQCAppliance);
            _grpQCField.Controls.Add(_cboQCParts);
            _grpQCField.Controls.Add(_lblJobUploadTimescale);
            _grpQCField.Controls.Add(_lblQCParts);
            _grpQCField.Controls.Add(_cboQCLGSR);
            _grpQCField.Controls.Add(_lblQCLGSR);
            _grpQCField.Controls.Add(_cboQCLabourTime);
            _grpQCField.Controls.Add(_lblQCLabourTime);
            _grpQCField.Location = new Point(9, 158);
            _grpQCField.Name = "grpQCField";
            _grpQCField.Size = new Size(1220, 342);
            _grpQCField.TabIndex = 38;
            _grpQCField.TabStop = false;
            _grpQCField.Text = "Field";
            // 
            // cboQCCustSig
            // 
            _cboQCCustSig.FormattingEnabled = true;
            _cboQCCustSig.Location = new Point(251, 198);
            _cboQCCustSig.Name = "cboQCCustSig";
            _cboQCCustSig.Size = new Size(277, 21);
            _cboQCCustSig.TabIndex = 84;
            // 
            // lblQCCustSig
            // 
            _lblQCCustSig.AutoSize = true;
            _lblQCCustSig.Location = new Point(12, 201);
            _lblQCCustSig.Name = "lblQCCustSig";
            _lblQCCustSig.Size = new Size(111, 13);
            _lblQCCustSig.TabIndex = 83;
            _lblQCCustSig.Text = "Customer Signed:";
            // 
            // cboRecallEngineer
            // 
            _cboRecallEngineer.FormattingEnabled = true;
            _cboRecallEngineer.Location = new Point(847, 27);
            _cboRecallEngineer.Name = "cboRecallEngineer";
            _cboRecallEngineer.Size = new Size(353, 21);
            _cboRecallEngineer.TabIndex = 82;
            // 
            // Label49
            // 
            _Label49.AutoSize = true;
            _Label49.Location = new Point(584, 27);
            _Label49.Name = "Label49";
            _Label49.Size = new Size(100, 13);
            _Label49.TabIndex = 81;
            _Label49.Text = "Recall Engineer:";
            // 
            // cboRecall
            // 
            _cboRecall.FormattingEnabled = true;
            _cboRecall.Location = new Point(251, 24);
            _cboRecall.Name = "cboRecall";
            _cboRecall.Size = new Size(277, 21);
            _cboRecall.TabIndex = 80;
            // 
            // Label48
            // 
            _Label48.AutoSize = true;
            _Label48.Location = new Point(12, 27);
            _Label48.Name = "Label48";
            _Label48.Size = new Size(46, 13);
            _Label48.TabIndex = 79;
            _Label48.Text = "Recall:";
            // 
            // dtpQCDocumentsRecieved
            // 
            _dtpQCDocumentsRecieved.Location = new Point(251, 236);
            _dtpQCDocumentsRecieved.Name = "dtpQCDocumentsRecieved";
            _dtpQCDocumentsRecieved.Size = new Size(180, 21);
            _dtpQCDocumentsRecieved.TabIndex = 78;
            _dtpQCDocumentsRecieved.Visible = false;
            // 
            // chkQCDocumentsRecieved
            // 
            _chkQCDocumentsRecieved.AutoSize = true;
            _chkQCDocumentsRecieved.CheckAlign = ContentAlignment.MiddleRight;
            _chkQCDocumentsRecieved.Location = new Point(15, 236);
            _chkQCDocumentsRecieved.Name = "chkQCDocumentsRecieved";
            _chkQCDocumentsRecieved.Size = new Size(164, 17);
            _chkQCDocumentsRecieved.TabIndex = 77;
            _chkQCDocumentsRecieved.Text = "All documents recieved:";
            _chkQCDocumentsRecieved.UseVisualStyleBackColor = true;
            // 
            // txtQCPoorJobNotes
            // 
            _txtQCPoorJobNotes.Location = new Point(759, 198);
            _txtQCPoorJobNotes.Multiline = true;
            _txtQCPoorJobNotes.Name = "txtQCPoorJobNotes";
            _txtQCPoorJobNotes.ScrollBars = ScrollBars.Vertical;
            _txtQCPoorJobNotes.Size = new Size(441, 111);
            _txtQCPoorJobNotes.TabIndex = 76;
            _txtQCPoorJobNotes.Tag = "";
            // 
            // lblQCPoorJobNotes
            // 
            _lblQCPoorJobNotes.AutoSize = true;
            _lblQCPoorJobNotes.Location = new Point(584, 198);
            _lblQCPoorJobNotes.Name = "lblQCPoorJobNotes";
            _lblQCPoorJobNotes.Size = new Size(95, 13);
            _lblQCPoorJobNotes.TabIndex = 40;
            _lblQCPoorJobNotes.Text = "Poor job notes:";
            // 
            // cboQCEngineerPaymentRecieved
            // 
            _cboQCEngineerPaymentRecieved.FormattingEnabled = true;
            _cboQCEngineerPaymentRecieved.Location = new Point(847, 162);
            _cboQCEngineerPaymentRecieved.Name = "cboQCEngineerPaymentRecieved";
            _cboQCEngineerPaymentRecieved.Size = new Size(353, 21);
            _cboQCEngineerPaymentRecieved.TabIndex = 39;
            // 
            // lblQCEngineerMonies
            // 
            _lblQCEngineerMonies.AutoSize = true;
            _lblQCEngineerMonies.Location = new Point(584, 162);
            _lblQCEngineerMonies.Name = "lblQCEngineerMonies";
            _lblQCEngineerMonies.Size = new Size(251, 13);
            _lblQCEngineerMonies.TabIndex = 38;
            _lblQCEngineerMonies.Text = "Engineer Cash/Cheque payment recieved:";
            // 
            // cboQCPaymentSelection
            // 
            _cboQCPaymentSelection.FormattingEnabled = true;
            _cboQCPaymentSelection.Location = new Point(847, 130);
            _cboQCPaymentSelection.Name = "cboQCPaymentSelection";
            _cboQCPaymentSelection.Size = new Size(353, 21);
            _cboQCPaymentSelection.TabIndex = 37;
            // 
            // lblQCEngPaymentMethod
            // 
            _lblQCEngPaymentMethod.AutoSize = true;
            _lblQCEngPaymentMethod.Location = new Point(584, 130);
            _lblQCEngPaymentMethod.Name = "lblQCEngPaymentMethod";
            _lblQCEngPaymentMethod.Size = new Size(207, 13);
            _lblQCEngPaymentMethod.TabIndex = 36;
            _lblQCEngPaymentMethod.Text = "Correct payment method selected:";
            // 
            // cboQCAppliance
            // 
            _cboQCAppliance.FormattingEnabled = true;
            _cboQCAppliance.Location = new Point(847, 96);
            _cboQCAppliance.Name = "cboQCAppliance";
            _cboQCAppliance.Size = new Size(353, 21);
            _cboQCAppliance.TabIndex = 35;
            // 
            // cboQCPaymentCollection
            // 
            _cboQCPaymentCollection.FormattingEnabled = true;
            _cboQCPaymentCollection.Location = new Point(251, 159);
            _cboQCPaymentCollection.Name = "cboQCPaymentCollection";
            _cboQCPaymentCollection.Size = new Size(277, 21);
            _cboQCPaymentCollection.TabIndex = 16;
            // 
            // lblQCPaymentCollection
            // 
            _lblQCPaymentCollection.AutoSize = true;
            _lblQCPaymentCollection.Location = new Point(12, 162);
            _lblQCPaymentCollection.Name = "lblQCPaymentCollection";
            _lblQCPaymentCollection.Size = new Size(116, 13);
            _lblQCPaymentCollection.TabIndex = 15;
            _lblQCPaymentCollection.Text = "Payment collected:";
            // 
            // cboQCJobUploadTimescale
            // 
            _cboQCJobUploadTimescale.FormattingEnabled = true;
            _cboQCJobUploadTimescale.Location = new Point(251, 127);
            _cboQCJobUploadTimescale.Name = "cboQCJobUploadTimescale";
            _cboQCJobUploadTimescale.Size = new Size(277, 21);
            _cboQCJobUploadTimescale.TabIndex = 14;
            // 
            // lblQCAppliance
            // 
            _lblQCAppliance.AutoSize = true;
            _lblQCAppliance.Location = new Point(584, 96);
            _lblQCAppliance.Name = "lblQCAppliance";
            _lblQCAppliance.Size = new Size(122, 13);
            _lblQCAppliance.TabIndex = 34;
            _lblQCAppliance.Text = "Appliance recorded:";
            // 
            // cboQCParts
            // 
            _cboQCParts.FormattingEnabled = true;
            _cboQCParts.Location = new Point(251, 93);
            _cboQCParts.Name = "cboQCParts";
            _cboQCParts.Size = new Size(277, 21);
            _cboQCParts.TabIndex = 33;
            // 
            // lblJobUploadTimescale
            // 
            _lblJobUploadTimescale.AutoSize = true;
            _lblJobUploadTimescale.Location = new Point(12, 130);
            _lblJobUploadTimescale.Name = "lblJobUploadTimescale";
            _lblJobUploadTimescale.Size = new Size(159, 13);
            _lblJobUploadTimescale.TabIndex = 13;
            _lblJobUploadTimescale.Text = "Job uploaded in timescale:";
            // 
            // lblQCParts
            // 
            _lblQCParts.AutoSize = true;
            _lblQCParts.Location = new Point(12, 96);
            _lblQCParts.Name = "lblQCParts";
            _lblQCParts.Size = new Size(102, 13);
            _lblQCParts.TabIndex = 32;
            _lblQCParts.Text = "Parts confirmed:";
            // 
            // cboQCLGSR
            // 
            _cboQCLGSR.FormattingEnabled = true;
            _cboQCLGSR.Location = new Point(847, 62);
            _cboQCLGSR.Name = "cboQCLGSR";
            _cboQCLGSR.Size = new Size(353, 21);
            _cboQCLGSR.TabIndex = 31;
            // 
            // lblQCLGSR
            // 
            _lblQCLGSR.AutoSize = true;
            _lblQCLGSR.Location = new Point(584, 62);
            _lblQCLGSR.Name = "lblQCLGSR";
            _lblQCLGSR.Size = new Size(90, 13);
            _lblQCLGSR.TabIndex = 30;
            _lblQCLGSR.Text = "LGSR missing:";
            // 
            // cboQCLabourTime
            // 
            _cboQCLabourTime.FormattingEnabled = true;
            _cboQCLabourTime.Location = new Point(251, 59);
            _cboQCLabourTime.Name = "cboQCLabourTime";
            _cboQCLabourTime.Size = new Size(277, 21);
            _cboQCLabourTime.TabIndex = 29;
            // 
            // lblQCLabourTime
            // 
            _lblQCLabourTime.AutoSize = true;
            _lblQCLabourTime.Location = new Point(12, 62);
            _lblQCLabourTime.Name = "lblQCLabourTime";
            _lblQCLabourTime.Size = new Size(167, 13);
            _lblQCLabourTime.TabIndex = 28;
            _lblQCLabourTime.Text = "Labour/Travel time missing:";
            // 
            // grpOfficeQC
            // 
            _grpOfficeQC.Controls.Add(_cboQCPaymentMethod);
            _grpOfficeQC.Controls.Add(_lblPaymentMethod);
            _grpOfficeQC.Controls.Add(_cboQCOrderNo);
            _grpOfficeQC.Controls.Add(_lblOrderNo);
            _grpOfficeQC.Controls.Add(_cboQCScheduleOfRate);
            _grpOfficeQC.Controls.Add(_lblScheduleRate);
            _grpOfficeQC.Controls.Add(_cboQCCustomerDetails);
            _grpOfficeQC.Controls.Add(_lblCustomerDetails);
            _grpOfficeQC.Controls.Add(_cboQCJobType);
            _grpOfficeQC.Controls.Add(_lblJobTypeCorrect);
            _grpOfficeQC.Controls.Add(_cboFTFCode);
            _grpOfficeQC.Controls.Add(_Label74);
            _grpOfficeQC.Location = new Point(9, 20);
            _grpOfficeQC.Name = "grpOfficeQC";
            _grpOfficeQC.Size = new Size(1220, 132);
            _grpOfficeQC.TabIndex = 30;
            _grpOfficeQC.TabStop = false;
            _grpOfficeQC.Text = "Office";
            // 
            // cboQCPaymentMethod
            // 
            _cboQCPaymentMethod.FormattingEnabled = true;
            _cboQCPaymentMethod.Location = new Point(251, 90);
            _cboQCPaymentMethod.Name = "cboQCPaymentMethod";
            _cboQCPaymentMethod.Size = new Size(277, 21);
            _cboQCPaymentMethod.TabIndex = 37;
            // 
            // lblPaymentMethod
            // 
            _lblPaymentMethod.AutoSize = true;
            _lblPaymentMethod.Location = new Point(12, 93);
            _lblPaymentMethod.Name = "lblPaymentMethod";
            _lblPaymentMethod.Size = new Size(158, 13);
            _lblPaymentMethod.TabIndex = 36;
            _lblPaymentMethod.Text = "Payment method detailed:";
            // 
            // cboQCOrderNo
            // 
            _cboQCOrderNo.FormattingEnabled = true;
            _cboQCOrderNo.Location = new Point(759, 57);
            _cboQCOrderNo.Name = "cboQCOrderNo";
            _cboQCOrderNo.Size = new Size(441, 21);
            _cboQCOrderNo.TabIndex = 35;
            // 
            // lblOrderNo
            // 
            _lblOrderNo.AutoSize = true;
            _lblOrderNo.Location = new Point(584, 60);
            _lblOrderNo.Name = "lblOrderNo";
            _lblOrderNo.Size = new Size(150, 13);
            _lblOrderNo.TabIndex = 34;
            _lblOrderNo.Text = "Order number attached: ";
            // 
            // cboQCScheduleOfRate
            // 
            _cboQCScheduleOfRate.FormattingEnabled = true;
            _cboQCScheduleOfRate.Location = new Point(251, 54);
            _cboQCScheduleOfRate.Name = "cboQCScheduleOfRate";
            _cboQCScheduleOfRate.Size = new Size(277, 21);
            _cboQCScheduleOfRate.TabIndex = 33;
            // 
            // lblScheduleRate
            // 
            _lblScheduleRate.AutoSize = true;
            _lblScheduleRate.Location = new Point(12, 57);
            _lblScheduleRate.Name = "lblScheduleRate";
            _lblScheduleRate.Size = new Size(208, 13);
            _lblScheduleRate.TabIndex = 32;
            _lblScheduleRate.Text = "Correct schedule of rates selected:";
            // 
            // cboQCCustomerDetails
            // 
            _cboQCCustomerDetails.FormattingEnabled = true;
            _cboQCCustomerDetails.Location = new Point(759, 20);
            _cboQCCustomerDetails.Name = "cboQCCustomerDetails";
            _cboQCCustomerDetails.Size = new Size(441, 21);
            _cboQCCustomerDetails.TabIndex = 31;
            // 
            // lblCustomerDetails
            // 
            _lblCustomerDetails.AutoSize = true;
            _lblCustomerDetails.Location = new Point(584, 23);
            _lblCustomerDetails.Name = "lblCustomerDetails";
            _lblCustomerDetails.Size = new Size(157, 13);
            _lblCustomerDetails.TabIndex = 30;
            _lblCustomerDetails.Text = "Correct customer details: ";
            // 
            // cboQCJobType
            // 
            _cboQCJobType.FormattingEnabled = true;
            _cboQCJobType.Location = new Point(251, 20);
            _cboQCJobType.Name = "cboQCJobType";
            _cboQCJobType.Size = new Size(277, 21);
            _cboQCJobType.TabIndex = 29;
            // 
            // lblJobTypeCorrect
            // 
            _lblJobTypeCorrect.AutoSize = true;
            _lblJobTypeCorrect.Location = new Point(12, 23);
            _lblJobTypeCorrect.Name = "lblJobTypeCorrect";
            _lblJobTypeCorrect.Size = new Size(157, 13);
            _lblJobTypeCorrect.TabIndex = 28;
            _lblJobTypeCorrect.Text = "Correct job type selected:";
            // 
            // cboFTFCode
            // 
            _cboFTFCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboFTFCode.FormattingEnabled = true;
            _cboFTFCode.Location = new Point(759, 90);
            _cboFTFCode.Name = "cboFTFCode";
            _cboFTFCode.Size = new Size(441, 21);
            _cboFTFCode.TabIndex = 27;
            // 
            // Label74
            // 
            _Label74.AutoSize = true;
            _Label74.Location = new Point(584, 93);
            _Label74.Name = "Label74";
            _Label74.Size = new Size(65, 13);
            _Label74.TabIndex = 26;
            _Label74.Text = "FTF Code:";
            // 
            // tpCharges
            // 
            _tpCharges.Controls.Add(_gpbInvoice);
            _tpCharges.Controls.Add(_gpbCharges);
            _tpCharges.Controls.Add(_gpbAdditionalCharges);
            _tpCharges.Controls.Add(_gpbPartsAndProducts);
            _tpCharges.Controls.Add(_gpbTimesheets);
            _tpCharges.Controls.Add(_gpbScheduleOfRates);
            _tpCharges.Location = new Point(4, 22);
            _tpCharges.Name = "tpCharges";
            _tpCharges.Size = new Size(1247, 652);
            _tpCharges.TabIndex = 4;
            _tpCharges.Text = "Visit Charges";
            _tpCharges.UseVisualStyleBackColor = true;
            // 
            // gpbInvoice
            // 
            _gpbInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _gpbInvoice.Controls.Add(_cboDept);
            _gpbInvoice.Controls.Add(_btnCreateServ);
            _gpbInvoice.Controls.Add(_txtInvAmount);
            _gpbInvoice.Controls.Add(_txtCreditAmount);
            _gpbInvoice.Controls.Add(_txtInvNo);
            _gpbInvoice.Controls.Add(_cboPaidBy);
            _gpbInvoice.Controls.Add(_cboInvType);
            _gpbInvoice.Controls.Add(_cboVATRate);
            _gpbInvoice.Controls.Add(_txtPriceIncVAT);
            _gpbInvoice.Controls.Add(_txtAccountCode);
            _gpbInvoice.Controls.Add(_lblInvoiceAddressDetails);
            _gpbInvoice.Controls.Add(_txtNominalCode);
            _gpbInvoice.Controls.Add(_btnSearch);
            _gpbInvoice.Controls.Add(_dtpRaiseInvoiceOn);
            _gpbInvoice.Controls.Add(_cbxReadyToBeInvoiced);
            _gpbInvoice.Controls.Add(_lblInvAmount);
            _gpbInvoice.Controls.Add(_lblcredit);
            _gpbInvoice.Controls.Add(_lblInvNo);
            _gpbInvoice.Controls.Add(_lblPaidBy);
            _gpbInvoice.Controls.Add(_lblInvType);
            _gpbInvoice.Controls.Add(_lblVAT);
            _gpbInvoice.Controls.Add(_lblNominalCode);
            _gpbInvoice.Controls.Add(_lblAccountCode);
            _gpbInvoice.Controls.Add(_lblPriceInvVAT);
            _gpbInvoice.Controls.Add(_lblDepartment);
            _gpbInvoice.Controls.Add(_lblRaiseInvoiceOn);
            _gpbInvoice.Location = new Point(717, 425);
            _gpbInvoice.Name = "gpbInvoice";
            _gpbInvoice.Size = new Size(522, 221);
            _gpbInvoice.TabIndex = 6;
            _gpbInvoice.TabStop = false;
            _gpbInvoice.Text = "Ready To Be Invoiced";
            // 
            // cboDept
            // 
            _cboDept.FormattingEnabled = true;
            _cboDept.Location = new Point(315, 26);
            _cboDept.Name = "cboDept";
            _cboDept.Size = new Size(98, 21);
            _cboDept.TabIndex = 32;
            // 
            // btnCreateServ
            // 
            _btnCreateServ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnCreateServ.Location = new Point(8, 192);
            _btnCreateServ.Name = "btnCreateServ";
            _btnCreateServ.Size = new Size(159, 23);
            _btnCreateServ.TabIndex = 31;
            _btnCreateServ.Text = "Create Multiple Services";
            // 
            // txtInvAmount
            // 
            _txtInvAmount.Location = new Point(340, 190);
            _txtInvAmount.Name = "txtInvAmount";
            _txtInvAmount.ReadOnly = true;
            _txtInvAmount.Size = new Size(74, 21);
            _txtInvAmount.TabIndex = 27;
            _txtInvAmount.Visible = false;
            // 
            // txtCreditAmount
            // 
            _txtCreditAmount.Location = new Point(425, 190);
            _txtCreditAmount.Name = "txtCreditAmount";
            _txtCreditAmount.ReadOnly = true;
            _txtCreditAmount.Size = new Size(91, 21);
            _txtCreditAmount.TabIndex = 25;
            _txtCreditAmount.Visible = false;
            // 
            // txtInvNo
            // 
            _txtInvNo.Location = new Point(251, 190);
            _txtInvNo.Name = "txtInvNo";
            _txtInvNo.ReadOnly = true;
            _txtInvNo.Size = new Size(76, 21);
            _txtInvNo.TabIndex = 23;
            _txtInvNo.Visible = false;
            // 
            // cboPaidBy
            // 
            _cboPaidBy.FormattingEnabled = true;
            _cboPaidBy.Location = new Point(249, 106);
            _cboPaidBy.Name = "cboPaidBy";
            _cboPaidBy.Size = new Size(164, 21);
            _cboPaidBy.TabIndex = 19;
            _cboPaidBy.Visible = false;
            // 
            // cboInvType
            // 
            _cboInvType.FormattingEnabled = true;
            _cboInvType.Location = new Point(249, 64);
            _cboInvType.Name = "cboInvType";
            _cboInvType.Size = new Size(164, 21);
            _cboInvType.TabIndex = 17;
            _cboInvType.Visible = false;
            // 
            // cboVATRate
            // 
            _cboVATRate.FormattingEnabled = true;
            _cboVATRate.Location = new Point(425, 63);
            _cboVATRate.Name = "cboVATRate";
            _cboVATRate.Size = new Size(90, 21);
            _cboVATRate.TabIndex = 13;
            _cboVATRate.Visible = false;
            // 
            // txtPriceIncVAT
            // 
            _txtPriceIncVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPriceIncVAT.Location = new Point(425, 106);
            _txtPriceIncVAT.Name = "txtPriceIncVAT";
            _txtPriceIncVAT.ReadOnly = true;
            _txtPriceIncVAT.Size = new Size(91, 21);
            _txtPriceIncVAT.TabIndex = 3;
            _txtPriceIncVAT.Visible = false;
            // 
            // txtAccountCode
            // 
            _txtAccountCode.Location = new Point(425, 24);
            _txtAccountCode.Name = "txtAccountCode";
            _txtAccountCode.Size = new Size(91, 21);
            _txtAccountCode.TabIndex = 12;
            _txtAccountCode.Visible = false;
            // 
            // lblInvoiceAddressDetails
            // 
            _lblInvoiceAddressDetails.Location = new Point(8, 43);
            _lblInvoiceAddressDetails.Name = "lblInvoiceAddressDetails";
            _lblInvoiceAddressDetails.Size = new Size(231, 127);
            _lblInvoiceAddressDetails.TabIndex = 4;
            _lblInvoiceAddressDetails.Visible = false;
            // 
            // txtNominalCode
            // 
            _txtNominalCode.Location = new Point(249, 24);
            _txtNominalCode.Name = "txtNominalCode";
            _txtNominalCode.Size = new Size(47, 21);
            _txtNominalCode.TabIndex = 9;
            // 
            // btnSearch
            // 
            _btnSearch.Location = new Point(177, 16);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(62, 23);
            _btnSearch.TabIndex = 1;
            _btnSearch.Text = "Change";
            _btnSearch.Visible = false;
            // 
            // dtpRaiseInvoiceOn
            // 
            _dtpRaiseInvoiceOn.Format = DateTimePickerFormat.Short;
            _dtpRaiseInvoiceOn.Location = new Point(425, 148);
            _dtpRaiseInvoiceOn.Name = "dtpRaiseInvoiceOn";
            _dtpRaiseInvoiceOn.Size = new Size(91, 21);
            _dtpRaiseInvoiceOn.TabIndex = 6;
            _dtpRaiseInvoiceOn.Visible = false;
            // 
            // cbxReadyToBeInvoiced
            // 
            _cbxReadyToBeInvoiced.Location = new Point(8, 22);
            _cbxReadyToBeInvoiced.Name = "cbxReadyToBeInvoiced";
            _cbxReadyToBeInvoiced.Size = new Size(180, 16);
            _cbxReadyToBeInvoiced.TabIndex = 0;
            _cbxReadyToBeInvoiced.Text = "Ready To Be Invoiced To:";
            // 
            // lblInvAmount
            // 
            _lblInvAmount.Location = new Point(338, 172);
            _lblInvAmount.Name = "lblInvAmount";
            _lblInvAmount.Size = new Size(76, 17);
            _lblInvAmount.TabIndex = 28;
            _lblInvAmount.Text = "Inv Ex VAT";
            _lblInvAmount.TextAlign = ContentAlignment.MiddleLeft;
            _lblInvAmount.Visible = false;
            // 
            // lblcredit
            // 
            _lblcredit.Location = new Point(420, 173);
            _lblcredit.Name = "lblcredit";
            _lblcredit.Size = new Size(92, 14);
            _lblcredit.TabIndex = 26;
            _lblcredit.Text = "Credit Ex VAT";
            _lblcredit.TextAlign = ContentAlignment.MiddleLeft;
            _lblcredit.Visible = false;
            // 
            // lblInvNo
            // 
            _lblInvNo.Location = new Point(249, 170);
            _lblInvNo.Name = "lblInvNo";
            _lblInvNo.Size = new Size(91, 17);
            _lblInvNo.TabIndex = 24;
            _lblInvNo.Text = "Invoice No.";
            _lblInvNo.TextAlign = ContentAlignment.MiddleLeft;
            _lblInvNo.Visible = false;
            // 
            // lblPaidBy
            // 
            _lblPaidBy.Location = new Point(248, 89);
            _lblPaidBy.Name = "lblPaidBy";
            _lblPaidBy.Size = new Size(130, 17);
            _lblPaidBy.TabIndex = 20;
            _lblPaidBy.Text = "Paid By";
            _lblPaidBy.TextAlign = ContentAlignment.MiddleLeft;
            _lblPaidBy.Visible = false;
            // 
            // lblInvType
            // 
            _lblInvType.Location = new Point(248, 48);
            _lblInvType.Name = "lblInvType";
            _lblInvType.Size = new Size(130, 17);
            _lblInvType.TabIndex = 18;
            _lblInvType.Text = "Invoice Type";
            _lblInvType.TextAlign = ContentAlignment.MiddleLeft;
            _lblInvType.Visible = false;
            // 
            // lblVAT
            // 
            _lblVAT.Location = new Point(420, 48);
            _lblVAT.Name = "lblVAT";
            _lblVAT.Size = new Size(94, 17);
            _lblVAT.TabIndex = 14;
            _lblVAT.Text = "VAT Rate";
            _lblVAT.TextAlign = ContentAlignment.MiddleLeft;
            _lblVAT.Visible = false;
            // 
            // lblNominalCode
            // 
            _lblNominalCode.Location = new Point(246, 9);
            _lblNominalCode.Name = "lblNominalCode";
            _lblNominalCode.Size = new Size(60, 14);
            _lblNominalCode.TabIndex = 7;
            _lblNominalCode.Text = "Nominal";
            _lblNominalCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAccountCode
            // 
            _lblAccountCode.Location = new Point(420, 8);
            _lblAccountCode.Name = "lblAccountCode";
            _lblAccountCode.Size = new Size(107, 14);
            _lblAccountCode.TabIndex = 11;
            _lblAccountCode.Text = "Account Code";
            _lblAccountCode.TextAlign = ContentAlignment.MiddleLeft;
            _lblAccountCode.Visible = false;
            // 
            // lblPriceInvVAT
            // 
            _lblPriceInvVAT.Location = new Point(420, 87);
            _lblPriceInvVAT.Name = "lblPriceInvVAT";
            _lblPriceInvVAT.Size = new Size(92, 16);
            _lblPriceInvVAT.TabIndex = 2;
            _lblPriceInvVAT.Text = "Price Inc VAT";
            _lblPriceInvVAT.TextAlign = ContentAlignment.MiddleLeft;
            _lblPriceInvVAT.Visible = false;
            // 
            // lblDepartment
            // 
            _lblDepartment.Location = new Point(312, 7);
            _lblDepartment.Name = "lblDepartment";
            _lblDepartment.Size = new Size(79, 16);
            _lblDepartment.TabIndex = 8;
            _lblDepartment.Text = "Cost Centre";
            _lblDepartment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRaiseInvoiceOn
            // 
            _lblRaiseInvoiceOn.Location = new Point(423, 130);
            _lblRaiseInvoiceOn.Name = "lblRaiseInvoiceOn";
            _lblRaiseInvoiceOn.Size = new Size(99, 16);
            _lblRaiseInvoiceOn.TabIndex = 5;
            _lblRaiseInvoiceOn.Text = "Raise Inv Date:";
            _lblRaiseInvoiceOn.TextAlign = ContentAlignment.MiddleLeft;
            _lblRaiseInvoiceOn.Visible = false;
            // 
            // gpbCharges
            // 
            _gpbCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _gpbCharges.Controls.Add(_chkShowJobCharges);
            _gpbCharges.Controls.Add(_GroupBox6);
            _gpbCharges.Controls.Add(_lblContractPerVisit);
            _gpbCharges.Controls.Add(_lblOR);
            _gpbCharges.Controls.Add(_Label30);
            _gpbCharges.Controls.Add(_lblQuotePercentageTotal);
            _gpbCharges.Controls.Add(_lblEquals);
            _gpbCharges.Controls.Add(_GroupBox9);
            _gpbCharges.Controls.Add(_lblPercent);
            _gpbCharges.Controls.Add(_txtPercentOfQuote);
            _gpbCharges.Controls.Add(_rdoPercentageOfQuoteValue);
            _gpbCharges.Controls.Add(_txtCharge);
            _gpbCharges.Controls.Add(_rdoChargeOther);
            _gpbCharges.Controls.Add(_rdoJobValue);
            _gpbCharges.Controls.Add(_txtJobValue);
            _gpbCharges.Location = new Point(8, 425);
            _gpbCharges.Name = "gpbCharges";
            _gpbCharges.Size = new Size(603, 221);
            _gpbCharges.TabIndex = 3;
            _gpbCharges.TabStop = false;
            _gpbCharges.Text = "Charges";
            // 
            // chkShowJobCharges
            // 
            _chkShowJobCharges.AutoSize = true;
            _chkShowJobCharges.Location = new Point(41, 187);
            _chkShowJobCharges.Name = "chkShowJobCharges";
            _chkShowJobCharges.Size = new Size(183, 17);
            _chkShowJobCharges.TabIndex = 17;
            _chkShowJobCharges.Text = "Show All Charges From Job";
            _chkShowJobCharges.UseVisualStyleBackColor = true;
            // 
            // GroupBox6
            // 
            _GroupBox6.Controls.Add(_Label82);
            _GroupBox6.Controls.Add(_Label78);
            _GroupBox6.Controls.Add(_Label77);
            _GroupBox6.Controls.Add(_txtProfitPerc);
            _GroupBox6.Controls.Add(_txtProfit);
            _GroupBox6.Controls.Add(_CostsToOption1);
            _GroupBox6.Controls.Add(_txtCosts);
            _GroupBox6.Controls.Add(_CostsToOption3);
            _GroupBox6.Controls.Add(_txtSale);
            _GroupBox6.Controls.Add(_CostsToOption2);
            _GroupBox6.Location = new Point(8, 93);
            _GroupBox6.Name = "GroupBox6";
            _GroupBox6.Size = new Size(583, 82);
            _GroupBox6.TabIndex = 16;
            _GroupBox6.TabStop = false;
            _GroupBox6.Text = "Costs To:";
            // 
            // Label82
            // 
            _Label82.Location = new Point(266, 17);
            _Label82.Name = "Label82";
            _Label82.Size = new Size(101, 16);
            _Label82.TabIndex = 23;
            _Label82.Text = "Sale";
            // 
            // Label78
            // 
            _Label78.Location = new Point(266, 57);
            _Label78.Name = "Label78";
            _Label78.Size = new Size(101, 19);
            _Label78.TabIndex = 22;
            _Label78.Text = "Profit";
            // 
            // Label77
            // 
            _Label77.Location = new Point(266, 36);
            _Label77.Name = "Label77";
            _Label77.Size = new Size(101, 20);
            _Label77.TabIndex = 21;
            _Label77.Text = "Costs";
            // 
            // txtProfitPerc
            // 
            _txtProfitPerc.Location = new Point(501, 57);
            _txtProfitPerc.Name = "txtProfitPerc";
            _txtProfitPerc.ReadOnly = true;
            _txtProfitPerc.Size = new Size(76, 21);
            _txtProfitPerc.TabIndex = 20;
            // 
            // txtProfit
            // 
            _txtProfit.Location = new Point(373, 57);
            _txtProfit.Name = "txtProfit";
            _txtProfit.ReadOnly = true;
            _txtProfit.Size = new Size(120, 21);
            _txtProfit.TabIndex = 19;
            // 
            // CostsToOption1
            // 
            _CostsToOption1.AutoSize = true;
            _CostsToOption1.Location = new Point(33, 16);
            _CostsToOption1.Name = "CostsToOption1";
            _CostsToOption1.Size = new Size(74, 17);
            _CostsToOption1.TabIndex = 13;
            _CostsToOption1.TabStop = true;
            _CostsToOption1.Text = "Contract";
            _CostsToOption1.UseVisualStyleBackColor = true;
            // 
            // txtCosts
            // 
            _txtCosts.Location = new Point(373, 34);
            _txtCosts.Name = "txtCosts";
            _txtCosts.ReadOnly = true;
            _txtCosts.Size = new Size(120, 21);
            _txtCosts.TabIndex = 18;
            // 
            // CostsToOption3
            // 
            _CostsToOption3.AutoSize = true;
            _CostsToOption3.Location = new Point(33, 62);
            _CostsToOption3.Name = "CostsToOption3";
            _CostsToOption3.Size = new Size(77, 17);
            _CostsToOption3.TabIndex = 15;
            _CostsToOption3.TabStop = true;
            _CostsToOption3.Text = "Warranty";
            _CostsToOption3.UseVisualStyleBackColor = true;
            // 
            // txtSale
            // 
            _txtSale.Location = new Point(373, 12);
            _txtSale.Name = "txtSale";
            _txtSale.ReadOnly = true;
            _txtSale.Size = new Size(120, 21);
            _txtSale.TabIndex = 17;
            // 
            // CostsToOption2
            // 
            _CostsToOption2.AutoSize = true;
            _CostsToOption2.Location = new Point(33, 39);
            _CostsToOption2.Name = "CostsToOption2";
            _CostsToOption2.Size = new Size(91, 17);
            _CostsToOption2.TabIndex = 14;
            _CostsToOption2.TabStop = true;
            _CostsToOption2.Text = "Chargeable";
            _CostsToOption2.UseVisualStyleBackColor = true;
            // 
            // lblContractPerVisit
            // 
            _lblContractPerVisit.BackColor = SystemColors.Info;
            _lblContractPerVisit.BorderStyle = BorderStyle.FixedSingle;
            _lblContractPerVisit.Location = new Point(507, 14);
            _lblContractPerVisit.Name = "lblContractPerVisit";
            _lblContractPerVisit.Size = new Size(85, 56);
            _lblContractPerVisit.TabIndex = 3;
            _lblContractPerVisit.Text = "Contract Job - Invoicing Per Visit";
            _lblContractPerVisit.Visible = false;
            // 
            // lblOR
            // 
            _lblOR.Location = new Point(8, 58);
            _lblOR.Name = "lblOR";
            _lblOR.Size = new Size(27, 26);
            _lblOR.TabIndex = 5;
            _lblOR.Text = "OR";
            // 
            // Label30
            // 
            _Label30.Location = new Point(8, 34);
            _Label30.Name = "Label30";
            _Label30.Size = new Size(27, 18);
            _Label30.TabIndex = 2;
            _Label30.Text = "OR";
            // 
            // lblQuotePercentageTotal
            // 
            _lblQuotePercentageTotal.Location = new Point(537, 73);
            _lblQuotePercentageTotal.Name = "lblQuotePercentageTotal";
            _lblQuotePercentageTotal.Size = new Size(34, 16);
            _lblQuotePercentageTotal.TabIndex = 11;
            _lblQuotePercentageTotal.Text = "N/A";
            // 
            // lblEquals
            // 
            _lblEquals.Location = new Point(522, 73);
            _lblEquals.Name = "lblEquals";
            _lblEquals.Size = new Size(24, 16);
            _lblEquals.TabIndex = 10;
            _lblEquals.Text = "=";
            // 
            // GroupBox9
            // 
            _GroupBox9.Controls.Add(_rbStandard);
            _GroupBox9.Controls.Add(_rbSite);
            _GroupBox9.Location = new Point(354, 177);
            _GroupBox9.Name = "GroupBox9";
            _GroupBox9.Size = new Size(238, 31);
            _GroupBox9.TabIndex = 83;
            _GroupBox9.TabStop = false;
            _GroupBox9.Visible = false;
            // 
            // rbStandard
            // 
            _rbStandard.AutoSize = true;
            _rbStandard.Checked = true;
            _rbStandard.Location = new Point(114, 10);
            _rbStandard.Name = "rbStandard";
            _rbStandard.Size = new Size(123, 17);
            _rbStandard.TabIndex = 1;
            _rbStandard.TabStop = true;
            _rbStandard.Text = "Standard Markup";
            _rbStandard.UseVisualStyleBackColor = true;
            // 
            // rbSite
            // 
            _rbSite.AutoSize = true;
            _rbSite.Location = new Point(11, 11);
            _rbSite.Name = "rbSite";
            _rbSite.Size = new Size(95, 17);
            _rbSite.TabIndex = 0;
            _rbSite.Text = "Site markup";
            _rbSite.UseVisualStyleBackColor = true;
            // 
            // lblPercent
            // 
            _lblPercent.Location = new Point(506, 73);
            _lblPercent.Name = "lblPercent";
            _lblPercent.Size = new Size(24, 16);
            _lblPercent.TabIndex = 9;
            _lblPercent.Text = "%";
            // 
            // txtPercentOfQuote
            // 
            _txtPercentOfQuote.Location = new Point(381, 69);
            _txtPercentOfQuote.Name = "txtPercentOfQuote";
            _txtPercentOfQuote.Size = new Size(120, 21);
            _txtPercentOfQuote.TabIndex = 8;
            // 
            // rdoPercentageOfQuoteValue
            // 
            _rdoPercentageOfQuoteValue.Location = new Point(41, 66);
            _rdoPercentageOfQuoteValue.Name = "rdoPercentageOfQuoteValue";
            _rdoPercentageOfQuoteValue.Size = new Size(175, 24);
            _rdoPercentageOfQuoteValue.TabIndex = 7;
            _rdoPercentageOfQuoteValue.Text = "Charge % of Quote Value";
            // 
            // txtCharge
            // 
            _txtCharge.Location = new Point(381, 44);
            _txtCharge.Name = "txtCharge";
            _txtCharge.ReadOnly = true;
            _txtCharge.Size = new Size(120, 21);
            _txtCharge.TabIndex = 6;
            // 
            // rdoChargeOther
            // 
            _rdoChargeOther.Location = new Point(41, 41);
            _rdoChargeOther.Name = "rdoChargeOther";
            _rdoChargeOther.Size = new Size(171, 24);
            _rdoChargeOther.TabIndex = 4;
            _rdoChargeOther.Text = "Charge Other";
            // 
            // rdoJobValue
            // 
            _rdoJobValue.Location = new Point(41, 16);
            _rdoJobValue.Name = "rdoJobValue";
            _rdoJobValue.Size = new Size(149, 24);
            _rdoJobValue.TabIndex = 0;
            _rdoJobValue.Text = "Charge Visit Value";
            // 
            // txtJobValue
            // 
            _txtJobValue.Location = new Point(381, 19);
            _txtJobValue.Name = "txtJobValue";
            _txtJobValue.ReadOnly = true;
            _txtJobValue.Size = new Size(120, 21);
            _txtJobValue.TabIndex = 1;
            // 
            // gpbAdditionalCharges
            // 
            _gpbAdditionalCharges.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbAdditionalCharges.Controls.Add(_lblAdditionalCharge);
            _gpbAdditionalCharges.Controls.Add(_btnAddAdditionalCharge);
            _gpbAdditionalCharges.Controls.Add(_txtAdditionalCharge);
            _gpbAdditionalCharges.Controls.Add(_btnRemoveAdditionalCharge);
            _gpbAdditionalCharges.Controls.Add(_txtAdditionalChargeDescription);
            _gpbAdditionalCharges.Controls.Add(_lblDescription);
            _gpbAdditionalCharges.Controls.Add(_txtAdditionalChargeTotal);
            _gpbAdditionalCharges.Controls.Add(_Label29);
            _gpbAdditionalCharges.Controls.Add(_dgAdditionalCharges);
            _gpbAdditionalCharges.Location = new Point(617, 184);
            _gpbAdditionalCharges.Name = "gpbAdditionalCharges";
            _gpbAdditionalCharges.Size = new Size(622, 233);
            _gpbAdditionalCharges.TabIndex = 5;
            _gpbAdditionalCharges.TabStop = false;
            _gpbAdditionalCharges.Text = "Additional Charges";
            // 
            // lblAdditionalCharge
            // 
            _lblAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblAdditionalCharge.Location = new Point(8, 206);
            _lblAdditionalCharge.Name = "lblAdditionalCharge";
            _lblAdditionalCharge.Size = new Size(74, 20);
            _lblAdditionalCharge.TabIndex = 9;
            _lblAdditionalCharge.Text = "Charge";
            // 
            // btnAddAdditionalCharge
            // 
            _btnAddAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddAdditionalCharge.Location = new Point(539, 204);
            _btnAddAdditionalCharge.Name = "btnAddAdditionalCharge";
            _btnAddAdditionalCharge.Size = new Size(75, 23);
            _btnAddAdditionalCharge.TabIndex = 8;
            _btnAddAdditionalCharge.Text = "Add";
            _btnAddAdditionalCharge.UseVisualStyleBackColor = true;
            // 
            // txtAdditionalCharge
            // 
            _txtAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtAdditionalCharge.Location = new Point(88, 203);
            _txtAdditionalCharge.Name = "txtAdditionalCharge";
            _txtAdditionalCharge.Size = new Size(96, 21);
            _txtAdditionalCharge.TabIndex = 7;
            // 
            // btnRemoveAdditionalCharge
            // 
            _btnRemoveAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveAdditionalCharge.Location = new Point(8, 129);
            _btnRemoveAdditionalCharge.Name = "btnRemoveAdditionalCharge";
            _btnRemoveAdditionalCharge.Size = new Size(75, 23);
            _btnRemoveAdditionalCharge.TabIndex = 1;
            _btnRemoveAdditionalCharge.Text = "Remove";
            _btnRemoveAdditionalCharge.UseVisualStyleBackColor = true;
            // 
            // txtAdditionalChargeDescription
            // 
            _txtAdditionalChargeDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtAdditionalChargeDescription.Location = new Point(88, 157);
            _txtAdditionalChargeDescription.Multiline = true;
            _txtAdditionalChargeDescription.Name = "txtAdditionalChargeDescription";
            _txtAdditionalChargeDescription.Size = new Size(526, 40);
            _txtAdditionalChargeDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            _lblDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblDescription.Location = new Point(8, 161);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(74, 23);
            _lblDescription.TabIndex = 4;
            _lblDescription.Text = "Description";
            // 
            // txtAdditionalChargeTotal
            // 
            _txtAdditionalChargeTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtAdditionalChargeTotal.Location = new Point(541, 131);
            _txtAdditionalChargeTotal.Name = "txtAdditionalChargeTotal";
            _txtAdditionalChargeTotal.ReadOnly = true;
            _txtAdditionalChargeTotal.Size = new Size(71, 21);
            _txtAdditionalChargeTotal.TabIndex = 3;
            // 
            // Label29
            // 
            _Label29.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label29.Location = new Point(492, 131);
            _Label29.Name = "Label29";
            _Label29.Size = new Size(40, 23);
            _Label29.TabIndex = 2;
            _Label29.Text = "Total";
            _Label29.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgAdditionalCharges
            // 
            _dgAdditionalCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAdditionalCharges.DataMember = "";
            _dgAdditionalCharges.HeaderForeColor = SystemColors.ControlText;
            _dgAdditionalCharges.Location = new Point(8, 20);
            _dgAdditionalCharges.Name = "dgAdditionalCharges";
            _dgAdditionalCharges.Size = new Size(606, 109);
            _dgAdditionalCharges.TabIndex = 0;
            // 
            // gpbPartsAndProducts
            // 
            _gpbPartsAndProducts.Controls.Add(_txtPartsMarkUp);
            _gpbPartsAndProducts.Controls.Add(_chkPartsSelectAll);
            _gpbPartsAndProducts.Controls.Add(_txtPartProductCost);
            _gpbPartsAndProducts.Controls.Add(_txtPartsProductTotal);
            _gpbPartsAndProducts.Controls.Add(_Label28);
            _gpbPartsAndProducts.Controls.Add(_lblPPTotalCost);
            _gpbPartsAndProducts.Controls.Add(_lblPartsMarkUp);
            _gpbPartsAndProducts.Controls.Add(_dgPartsProductCharging);
            _gpbPartsAndProducts.Location = new Point(8, 184);
            _gpbPartsAndProducts.Name = "gpbPartsAndProducts";
            _gpbPartsAndProducts.Size = new Size(603, 233);
            _gpbPartsAndProducts.TabIndex = 1;
            _gpbPartsAndProducts.TabStop = false;
            _gpbPartsAndProducts.Text = "Parts && Products";
            // 
            // txtPartsMarkUp
            // 
            _txtPartsMarkUp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPartsMarkUp.Enabled = false;
            _txtPartsMarkUp.Location = new Point(405, 203);
            _txtPartsMarkUp.Name = "txtPartsMarkUp";
            _txtPartsMarkUp.Size = new Size(37, 21);
            _txtPartsMarkUp.TabIndex = 81;
            _txtPartsMarkUp.Visible = false;
            // 
            // chkPartsSelectAll
            // 
            _chkPartsSelectAll.AutoCheck = false;
            _chkPartsSelectAll.AutoSize = true;
            _chkPartsSelectAll.Location = new Point(6, 205);
            _chkPartsSelectAll.Name = "chkPartsSelectAll";
            _chkPartsSelectAll.Size = new Size(79, 17);
            _chkPartsSelectAll.TabIndex = 80;
            _chkPartsSelectAll.Text = "Select All";
            _chkPartsSelectAll.UseVisualStyleBackColor = true;
            // 
            // txtPartProductCost
            // 
            _txtPartProductCost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPartProductCost.Location = new Point(252, 203);
            _txtPartProductCost.Name = "txtPartProductCost";
            _txtPartProductCost.ReadOnly = true;
            _txtPartProductCost.Size = new Size(71, 21);
            _txtPartProductCost.TabIndex = 2;
            // 
            // txtPartsProductTotal
            // 
            _txtPartsProductTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPartsProductTotal.Location = new Point(525, 202);
            _txtPartsProductTotal.Name = "txtPartsProductTotal";
            _txtPartsProductTotal.ReadOnly = true;
            _txtPartsProductTotal.Size = new Size(71, 21);
            _txtPartsProductTotal.TabIndex = 4;
            // 
            // Label28
            // 
            _Label28.Location = new Point(448, 202);
            _Label28.Name = "Label28";
            _Label28.Size = new Size(72, 21);
            _Label28.TabIndex = 3;
            _Label28.Text = "Total Price";
            _Label28.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPPTotalCost
            // 
            _lblPPTotalCost.Location = new Point(174, 203);
            _lblPPTotalCost.Name = "lblPPTotalCost";
            _lblPPTotalCost.Size = new Size(72, 21);
            _lblPPTotalCost.TabIndex = 79;
            _lblPPTotalCost.Text = "Total Cost";
            _lblPPTotalCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPartsMarkUp
            // 
            _lblPartsMarkUp.Location = new Point(329, 202);
            _lblPartsMarkUp.Name = "lblPartsMarkUp";
            _lblPartsMarkUp.Size = new Size(70, 21);
            _lblPartsMarkUp.TabIndex = 82;
            _lblPartsMarkUp.Text = "Mark Up %";
            _lblPartsMarkUp.TextAlign = ContentAlignment.MiddleLeft;
            _lblPartsMarkUp.Visible = false;
            // 
            // dgPartsProductCharging
            // 
            _dgPartsProductCharging.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPartsProductCharging.DataMember = "";
            _dgPartsProductCharging.HeaderForeColor = SystemColors.ControlText;
            _dgPartsProductCharging.Location = new Point(9, 16);
            _dgPartsProductCharging.Name = "dgPartsProductCharging";
            _dgPartsProductCharging.Size = new Size(587, 181);
            _dgPartsProductCharging.TabIndex = 0;
            // 
            // gpbTimesheets
            // 
            _gpbTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbTimesheets.Controls.Add(_chkTimesheetSelectAll);
            _gpbTimesheets.Controls.Add(_txtEngineerCostTotal);
            _gpbTimesheets.Controls.Add(_txtTimesheetTotal);
            _gpbTimesheets.Controls.Add(_Label27);
            _gpbTimesheets.Controls.Add(_Label32);
            _gpbTimesheets.Controls.Add(_dgTimesheetCharges);
            _gpbTimesheets.Location = new Point(617, 8);
            _gpbTimesheets.Name = "gpbTimesheets";
            _gpbTimesheets.Size = new Size(622, 170);
            _gpbTimesheets.TabIndex = 4;
            _gpbTimesheets.TabStop = false;
            _gpbTimesheets.Text = "Timesheets";
            // 
            // chkTimesheetSelectAll
            // 
            _chkTimesheetSelectAll.AutoCheck = false;
            _chkTimesheetSelectAll.AutoSize = true;
            _chkTimesheetSelectAll.Location = new Point(6, 142);
            _chkTimesheetSelectAll.Name = "chkTimesheetSelectAll";
            _chkTimesheetSelectAll.Size = new Size(79, 17);
            _chkTimesheetSelectAll.TabIndex = 81;
            _chkTimesheetSelectAll.Text = "Select All";
            _chkTimesheetSelectAll.UseVisualStyleBackColor = true;
            // 
            // txtEngineerCostTotal
            // 
            _txtEngineerCostTotal.Location = new Point(382, 140);
            _txtEngineerCostTotal.Name = "txtEngineerCostTotal";
            _txtEngineerCostTotal.ReadOnly = true;
            _txtEngineerCostTotal.Size = new Size(71, 21);
            _txtEngineerCostTotal.TabIndex = 2;
            // 
            // txtTimesheetTotal
            // 
            _txtTimesheetTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTimesheetTotal.Location = new Point(540, 140);
            _txtTimesheetTotal.Name = "txtTimesheetTotal";
            _txtTimesheetTotal.ReadOnly = true;
            _txtTimesheetTotal.Size = new Size(71, 21);
            _txtTimesheetTotal.TabIndex = 4;
            // 
            // Label27
            // 
            _Label27.Location = new Point(462, 140);
            _Label27.Name = "Label27";
            _Label27.Size = new Size(72, 21);
            _Label27.TabIndex = 3;
            _Label27.Text = "Total Price";
            _Label27.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label32
            // 
            _Label32.Location = new Point(308, 139);
            _Label32.Name = "Label32";
            _Label32.Size = new Size(68, 23);
            _Label32.TabIndex = 1;
            _Label32.Text = "Total Cost";
            _Label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgTimesheetCharges
            // 
            _dgTimesheetCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTimesheetCharges.DataMember = "";
            _dgTimesheetCharges.HeaderForeColor = SystemColors.ControlText;
            _dgTimesheetCharges.Location = new Point(6, 17);
            _dgTimesheetCharges.Name = "dgTimesheetCharges";
            _dgTimesheetCharges.Size = new Size(606, 118);
            _dgTimesheetCharges.TabIndex = 0;
            // 
            // gpbScheduleOfRates
            // 
            _gpbScheduleOfRates.Controls.Add(_btnAddSoR);
            _gpbScheduleOfRates.Controls.Add(_txtScheduleOfRatesTotal);
            _gpbScheduleOfRates.Controls.Add(_dgScheduleOfRateCharges);
            _gpbScheduleOfRates.Controls.Add(_Label26);
            _gpbScheduleOfRates.Location = new Point(8, 8);
            _gpbScheduleOfRates.Name = "gpbScheduleOfRates";
            _gpbScheduleOfRates.Size = new Size(603, 170);
            _gpbScheduleOfRates.TabIndex = 0;
            _gpbScheduleOfRates.TabStop = false;
            _gpbScheduleOfRates.Text = "Schedule Of Rates";
            // 
            // btnAddSoR
            // 
            _btnAddSoR.Location = new Point(6, 141);
            _btnAddSoR.Name = "btnAddSoR";
            _btnAddSoR.Size = new Size(75, 23);
            _btnAddSoR.TabIndex = 1;
            _btnAddSoR.Text = "Add";
            // 
            // txtScheduleOfRatesTotal
            // 
            _txtScheduleOfRatesTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtScheduleOfRatesTotal.Location = new Point(521, 143);
            _txtScheduleOfRatesTotal.Name = "txtScheduleOfRatesTotal";
            _txtScheduleOfRatesTotal.ReadOnly = true;
            _txtScheduleOfRatesTotal.Size = new Size(71, 21);
            _txtScheduleOfRatesTotal.TabIndex = 3;
            // 
            // dgScheduleOfRateCharges
            // 
            _dgScheduleOfRateCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgScheduleOfRateCharges.DataMember = "";
            _dgScheduleOfRateCharges.HeaderForeColor = SystemColors.ControlText;
            _dgScheduleOfRateCharges.Location = new Point(8, 17);
            _dgScheduleOfRateCharges.Name = "dgScheduleOfRateCharges";
            _dgScheduleOfRateCharges.Size = new Size(585, 121);
            _dgScheduleOfRateCharges.TabIndex = 0;
            // 
            // Label26
            // 
            _Label26.Location = new Point(481, 141);
            _Label26.Name = "Label26";
            _Label26.Size = new Size(39, 23);
            _Label26.TabIndex = 2;
            _Label26.Text = "Total";
            _Label26.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tpDocuments
            // 
            _tpDocuments.Location = new Point(4, 22);
            _tpDocuments.Name = "tpDocuments";
            _tpDocuments.Size = new Size(1247, 652);
            _tpDocuments.TabIndex = 9;
            _tpDocuments.Text = "Documents";
            _tpDocuments.UseVisualStyleBackColor = true;
            // 
            // tpPhotos
            // 
            _tpPhotos.Controls.Add(_flPhotos);
            _tpPhotos.Location = new Point(4, 22);
            _tpPhotos.Name = "tpPhotos";
            _tpPhotos.Size = new Size(1247, 652);
            _tpPhotos.TabIndex = 10;
            _tpPhotos.Text = "Photos";
            _tpPhotos.UseVisualStyleBackColor = true;
            // 
            // flPhotos
            // 
            _flPhotos.AutoScroll = true;
            _flPhotos.AutoSize = true;
            _flPhotos.Dock = DockStyle.Fill;
            _flPhotos.Location = new Point(0, 0);
            _flPhotos.Name = "flPhotos";
            _flPhotos.Size = new Size(1247, 652);
            _flPhotos.TabIndex = 2;
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(8, 750);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(64, 23);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(1183, 750);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(64, 23);
            _btnSave.TabIndex = 6;
            _btnSave.Text = "Save";
            // 
            // cbxVisitLockDown
            // 
            _cbxVisitLockDown.BackColor = SystemColors.Info;
            _cbxVisitLockDown.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _cbxVisitLockDown.Location = new Point(8, 32);
            _cbxVisitLockDown.Name = "cbxVisitLockDown";
            _cbxVisitLockDown.Size = new Size(296, 24);
            _cbxVisitLockDown.TabIndex = 5;
            _cbxVisitLockDown.Text = "Visit locked down and ready for charging";
            _cbxVisitLockDown.UseVisualStyleBackColor = false;
            // 
            // lblStatusWarning
            // 
            _lblStatusWarning.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblStatusWarning.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblStatusWarning.ForeColor = Color.Red;
            _lblStatusWarning.Location = new Point(312, 32);
            _lblStatusWarning.Name = "lblStatusWarning";
            _lblStatusWarning.Size = new Size(736, 23);
            _lblStatusWarning.TabIndex = 6;
            _lblStatusWarning.Text = "Reversing this status will result in the lost of charge changes";
            _lblStatusWarning.TextAlign = ContentAlignment.MiddleLeft;
            _lblStatusWarning.Visible = false;
            // 
            // btnOrders
            // 
            _btnOrders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnOrders.Location = new Point(148, 750);
            _btnOrders.Name = "btnOrders";
            _btnOrders.Size = new Size(64, 23);
            _btnOrders.TabIndex = 4;
            _btnOrders.Text = "Orders";
            // 
            // btnInvoice
            // 
            _btnInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnInvoice.Location = new Point(289, 750);
            _btnInvoice.Name = "btnInvoice";
            _btnInvoice.Size = new Size(64, 23);
            _btnInvoice.TabIndex = 5;
            _btnInvoice.Text = "Invoice";
            // 
            // btnPrint
            // 
            _btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrint.Location = new Point(1064, 750);
            _btnPrint.Name = "btnPrint";
            _btnPrint.Size = new Size(103, 23);
            _btnPrint.TabIndex = 7;
            _btnPrint.Text = "Print QC";
            // 
            // PrintMenu
            // 
            _PrintMenu.Items.AddRange(new ToolStripItem[] { _mnuGasSafetyInspectionBoilerServiceRecord });
            _PrintMenu.Name = "PrintMenu";
            _PrintMenu.Size = new Size(302, 26);
            // 
            // mnuGasSafetyInspectionBoilerServiceRecord
            // 
            _mnuGasSafetyInspectionBoilerServiceRecord.Name = "mnuGasSafetyInspectionBoilerServiceRecord";
            _mnuGasSafetyInspectionBoilerServiceRecord.Size = new Size(301, 22);
            _mnuGasSafetyInspectionBoilerServiceRecord.Text = "Gas Safety Inspection/Boiler Service Record";
            // 
            // txtCurrentContract
            // 
            _txtCurrentContract.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtCurrentContract.Location = new Point(1116, 38);
            _txtCurrentContract.Name = "txtCurrentContract";
            _txtCurrentContract.ReadOnly = true;
            _txtCurrentContract.Size = new Size(135, 21);
            _txtCurrentContract.TabIndex = 27;
            // 
            // Label39
            // 
            _Label39.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label39.Location = new Point(1054, 39);
            _Label39.Name = "Label39";
            _Label39.Size = new Size(63, 16);
            _Label39.TabIndex = 26;
            _Label39.Text = "Contract:";
            // 
            // btnPrintGSR
            // 
            _btnPrintGSR.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrintGSR.Location = new Point(1064, 750);
            _btnPrintGSR.Name = "btnPrintGSR";
            _btnPrintGSR.Size = new Size(105, 23);
            _btnPrintGSR.TabIndex = 29;
            _btnPrintGSR.Text = "Print GSR";
            // 
            // btnPrintSVR
            // 
            _btnPrintSVR.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrintSVR.Location = new Point(1057, 750);
            _btnPrintSVR.Name = "btnPrintSVR";
            _btnPrintSVR.Size = new Size(112, 23);
            _btnPrintSVR.TabIndex = 30;
            _btnPrintSVR.Text = "Print...";
            // 
            // btnJob
            // 
            _btnJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnJob.Location = new Point(78, 750);
            _btnJob.Name = "btnJob";
            _btnJob.Size = new Size(64, 23);
            _btnJob.TabIndex = 31;
            _btnJob.Text = "Job";
            // 
            // lblRechargeTicked
            // 
            _lblRechargeTicked.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblRechargeTicked.ForeColor = Color.Red;
            _lblRechargeTicked.Location = new Point(75, 4);
            _lblRechargeTicked.Name = "lblRechargeTicked";
            _lblRechargeTicked.Size = new Size(457, 23);
            _lblRechargeTicked.TabIndex = 32;
            _lblRechargeTicked.Text = "Recharge is Selected";
            _lblRechargeTicked.TextAlign = ContentAlignment.MiddleLeft;
            _lblRechargeTicked.Visible = false;
            // 
            // btnShowVisits
            // 
            _btnShowVisits.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnShowVisits.Location = new Point(687, 750);
            _btnShowVisits.Name = "btnShowVisits";
            _btnShowVisits.Size = new Size(99, 23);
            _btnShowVisits.TabIndex = 33;
            _btnShowVisits.Text = "Show History";
            _btnShowVisits.UseVisualStyleBackColor = true;
            // 
            // BottomToolStripPanel
            // 
            _BottomToolStripPanel.Location = new Point(0, 0);
            _BottomToolStripPanel.Name = "BottomToolStripPanel";
            _BottomToolStripPanel.Orientation = Orientation.Horizontal;
            _BottomToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            _BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            _TopToolStripPanel.Location = new Point(0, 0);
            _TopToolStripPanel.Name = "TopToolStripPanel";
            _TopToolStripPanel.Orientation = Orientation.Horizontal;
            _TopToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            _TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            _RightToolStripPanel.Location = new Point(0, 0);
            _RightToolStripPanel.Name = "RightToolStripPanel";
            _RightToolStripPanel.Orientation = Orientation.Horizontal;
            _RightToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            _RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            _LeftToolStripPanel.Location = new Point(0, 0);
            _LeftToolStripPanel.Name = "LeftToolStripPanel";
            _LeftToolStripPanel.Orientation = Orientation.Horizontal;
            _LeftToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            _LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            _ContentPanel.Size = new Size(150, 150);
            // 
            // Button1
            // 
            _Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Button1.Location = new Point(218, 750);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(64, 23);
            _Button1.TabIndex = 34;
            _Button1.Text = "Cust";
            // 
            // txtCustEmail
            // 
            _txtCustEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtCustEmail.BorderStyle = BorderStyle.None;
            _txtCustEmail.Location = new Point(718, 8);
            _txtCustEmail.Name = "txtCustEmail";
            _txtCustEmail.ReadOnly = true;
            _txtCustEmail.Size = new Size(533, 14);
            _txtCustEmail.TabIndex = 36;
            // 
            // SVRs
            // 
            _SVRs.Items.AddRange(new ToolStripItem[] { _AllGasPaperworkToolStripMenuItem, _svrmenu, _JobSheetMenu, _DomesticGSRToolStripMenuItem, _WarningNoticeToolStripMenuItem, _CommercialGSRToolStripMenuItem, _QCResultsToolStripMenuItem, _ElectricalMinorWorksToolStripMenuItem, _CommercialCateringToolStripMenuItem, _SaffronUnventedWorkshhetToolStripMenuItem, _PropertyMaintenanceWorksheetToolStripMenuItem, _ASHPWorksheetToolStripMenuItem, _CommissioningChecklistToolStripMenuItem, _HotWorksPermitToolStripMenuItem });
            _SVRs.Name = "SVRs";
            _SVRs.Size = new Size(251, 312);
            // 
            // AllGasPaperworkToolStripMenuItem
            // 
            _AllGasPaperworkToolStripMenuItem.Name = "AllGasPaperworkToolStripMenuItem";
            _AllGasPaperworkToolStripMenuItem.Size = new Size(250, 22);
            _AllGasPaperworkToolStripMenuItem.Text = "All Safety Paperwork";
            // 
            // svrmenu
            // 
            _svrmenu.Name = "svrmenu";
            _svrmenu.Size = new Size(250, 22);
            _svrmenu.Text = "SVR";
            // 
            // JobSheetMenu
            // 
            _JobSheetMenu.Name = "JobSheetMenu";
            _JobSheetMenu.Size = new Size(250, 22);
            _JobSheetMenu.Text = "Job Sheet";
            // 
            // DomesticGSRToolStripMenuItem
            // 
            _DomesticGSRToolStripMenuItem.Name = "DomesticGSRToolStripMenuItem";
            _DomesticGSRToolStripMenuItem.Size = new Size(250, 22);
            _DomesticGSRToolStripMenuItem.Text = "Domestic LSR";
            // 
            // WarningNoticeToolStripMenuItem
            // 
            _WarningNoticeToolStripMenuItem.Name = "WarningNoticeToolStripMenuItem";
            _WarningNoticeToolStripMenuItem.Size = new Size(250, 22);
            _WarningNoticeToolStripMenuItem.Text = "Warning Notice";
            // 
            // CommercialGSRToolStripMenuItem
            // 
            _CommercialGSRToolStripMenuItem.Name = "CommercialGSRToolStripMenuItem";
            _CommercialGSRToolStripMenuItem.Size = new Size(250, 22);
            _CommercialGSRToolStripMenuItem.Text = "Commercial LSR";
            // 
            // QCResultsToolStripMenuItem
            // 
            _QCResultsToolStripMenuItem.Name = "QCResultsToolStripMenuItem";
            _QCResultsToolStripMenuItem.Size = new Size(250, 22);
            _QCResultsToolStripMenuItem.Text = "QC Results";
            // 
            // ElectricalMinorWorksToolStripMenuItem
            // 
            _ElectricalMinorWorksToolStripMenuItem.Name = "ElectricalMinorWorksToolStripMenuItem";
            _ElectricalMinorWorksToolStripMenuItem.Size = new Size(250, 22);
            _ElectricalMinorWorksToolStripMenuItem.Text = "Electrical Minor Works";
            // 
            // CommercialCateringToolStripMenuItem
            // 
            _CommercialCateringToolStripMenuItem.Name = "CommercialCateringToolStripMenuItem";
            _CommercialCateringToolStripMenuItem.Size = new Size(250, 22);
            _CommercialCateringToolStripMenuItem.Text = "Commercial Catering";
            // 
            // SaffronUnventedWorkshhetToolStripMenuItem
            // 
            _SaffronUnventedWorkshhetToolStripMenuItem.Name = "SaffronUnventedWorkshhetToolStripMenuItem";
            _SaffronUnventedWorkshhetToolStripMenuItem.Size = new Size(250, 22);
            _SaffronUnventedWorkshhetToolStripMenuItem.Text = "Saffron Unvented Worksheet";
            // 
            // PropertyMaintenanceWorksheetToolStripMenuItem
            // 
            _PropertyMaintenanceWorksheetToolStripMenuItem.Name = "PropertyMaintenanceWorksheetToolStripMenuItem";
            _PropertyMaintenanceWorksheetToolStripMenuItem.Size = new Size(250, 22);
            _PropertyMaintenanceWorksheetToolStripMenuItem.Text = "Property Maintenance Worksheet";
            // 
            // ASHPWorksheetToolStripMenuItem
            // 
            _ASHPWorksheetToolStripMenuItem.Name = "ASHPWorksheetToolStripMenuItem";
            _ASHPWorksheetToolStripMenuItem.Size = new Size(250, 22);
            _ASHPWorksheetToolStripMenuItem.Text = "Waveney ASHP Worksheet";
            // 
            // CommissioningChecklistToolStripMenuItem
            // 
            _CommissioningChecklistToolStripMenuItem.Name = "CommissioningChecklistToolStripMenuItem";
            _CommissioningChecklistToolStripMenuItem.Size = new Size(250, 22);
            _CommissioningChecklistToolStripMenuItem.Text = "Commissioning Checklist";
            // 
            // HotWorksPermitToolStripMenuItem
            // 
            _HotWorksPermitToolStripMenuItem.Name = "HotWorksPermitToolStripMenuItem";
            _HotWorksPermitToolStripMenuItem.Size = new Size(250, 22);
            _HotWorksPermitToolStripMenuItem.Text = "Hot Works Permit";
            // 
            // FRMEngineerVisit
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1255, 780);
            Controls.Add(_btnPrintSVR);
            Controls.Add(_txtCustEmail);
            Controls.Add(_Button1);
            Controls.Add(_btnShowVisits);
            Controls.Add(_lblRechargeTicked);
            Controls.Add(_btnJob);
            Controls.Add(_btnPrintGSR);
            Controls.Add(_txtCurrentContract);
            Controls.Add(_Label39);
            Controls.Add(_btnPrint);
            Controls.Add(_btnInvoice);
            Controls.Add(_btnOrders);
            Controls.Add(_lblStatusWarning);
            Controls.Add(_cbxVisitLockDown);
            Controls.Add(_btnSave);
            Controls.Add(_btnClose);
            Controls.Add(_tcWorkSheet);
            MinimumSize = new Size(936, 664);
            Name = "FRMEngineerVisit";
            Text = "Engineer Visit";
            Controls.SetChildIndex(_tcWorkSheet, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_cbxVisitLockDown, 0);
            Controls.SetChildIndex(_lblStatusWarning, 0);
            Controls.SetChildIndex(_btnOrders, 0);
            Controls.SetChildIndex(_btnInvoice, 0);
            Controls.SetChildIndex(_btnPrint, 0);
            Controls.SetChildIndex(_Label39, 0);
            Controls.SetChildIndex(_txtCurrentContract, 0);
            Controls.SetChildIndex(_btnPrintGSR, 0);
            Controls.SetChildIndex(_btnJob, 0);
            Controls.SetChildIndex(_lblRechargeTicked, 0);
            Controls.SetChildIndex(_btnShowVisits, 0);
            Controls.SetChildIndex(_Button1, 0);
            Controls.SetChildIndex(_txtCustEmail, 0);
            Controls.SetChildIndex(_btnPrintSVR, 0);
            _tcWorkSheet.ResumeLayout(false);
            _tpMainDetails.ResumeLayout(false);
            _tpMainDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_pbCustomerSignature).EndInit();
            ((System.ComponentModel.ISupportInitialize)_pbEngineerSignature).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgJobItems).EndInit();
            _tpAppliances.ResumeLayout(false);
            _gpAppliances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            _tpWorksheets.ResumeLayout(false);
            _grpAdditionalWorksheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAdditional).EndInit();
            _grpAlarmInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_DGSmokeComo).EndInit();
            _grpVisitWorksheetExtended.ResumeLayout(false);
            _grpVisitWorksheetExtended.PerformLayout();
            _grpVisitDefects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVisitDefects).EndInit();
            _grpApplianceWorksheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgApplianceWorkSheets).EndInit();
            _grpVisitWorksheet.ResumeLayout(false);
            _grpVisitWorksheet.PerformLayout();
            _tpTimesheets.ResumeLayout(false);
            _tpTimesheets.PerformLayout();
            _grpTimesheets.ResumeLayout(false);
            _grpTimesheets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTimeSheets).EndInit();
            _tpPartsAndProducts.ResumeLayout(false);
            _grpAllocated.ResumeLayout(false);
            _grpAllocated.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_nudPartAllocatedQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgPartsProductsAllocated).EndInit();
            _grpUsed.ResumeLayout(false);
            _grpUsed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsAndProductsUsed).EndInit();
            ((System.ComponentModel.ISupportInitialize)_nudQuantityUsed).EndInit();
            _tpOutcomes.ResumeLayout(false);
            _grpOutcomes.ResumeLayout(false);
            _grpOutcomes.PerformLayout();
            _grpSiteFuels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuel).EndInit();
            _tpQC.ResumeLayout(false);
            _GroupBox4.ResumeLayout(false);
            _grpQCField.ResumeLayout(false);
            _grpQCField.PerformLayout();
            _grpOfficeQC.ResumeLayout(false);
            _grpOfficeQC.PerformLayout();
            _tpCharges.ResumeLayout(false);
            _gpbInvoice.ResumeLayout(false);
            _gpbInvoice.PerformLayout();
            _gpbCharges.ResumeLayout(false);
            _gpbCharges.PerformLayout();
            _GroupBox6.ResumeLayout(false);
            _GroupBox6.PerformLayout();
            _GroupBox9.ResumeLayout(false);
            _GroupBox9.PerformLayout();
            _gpbAdditionalCharges.ResumeLayout(false);
            _gpbAdditionalCharges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAdditionalCharges).EndInit();
            _gpbPartsAndProducts.ResumeLayout(false);
            _gpbPartsAndProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsProductCharging).EndInit();
            _gpbTimesheets.ResumeLayout(false);
            _gpbTimesheets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTimesheetCharges).EndInit();
            _gpbScheduleOfRates.ResumeLayout(false);
            _gpbScheduleOfRates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRateCharges).EndInit();
            _tpPhotos.ResumeLayout(false);
            _tpPhotos.PerformLayout();
            _PrintMenu.ResumeLayout(false);
            _SVRs.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataTable dtEngineerGetAll = App.DB.Engineer.Engineer_GetAll().Table;
        private DataTable dtPassFailNA = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table;
        private DataTable dtYesNoNA = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA).Table;
        private DataTable dtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo).Table;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private class CheckListMenuItem : MenuItem
        {
            private string _Section = "";

            public string Section
            {
                get
                {
                    return _Section;
                }

                set
                {
                    _Section = value;
                }
            }

            private int _SectionID = 0;

            public int SectionID
            {
                get
                {
                    return _SectionID;
                }

                set
                {
                    _SectionID = value;
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }

                set
                {
                    _EngineerVisitID = value;
                }
            }

            private DataGrid _ChecklistDatagrid;

            public DataGrid ChecklistDatagrid
            {
                get
                {
                    return _ChecklistDatagrid;
                }

                set
                {
                    _ChecklistDatagrid = value;
                }
            }

            private DataView _ChecklistDataview;

            public DataView ChecklistDataview
            {
                get
                {
                    return _ChecklistDataview;
                }

                set
                {
                    _ChecklistDataview = value;
                }
            }

            public CheckListMenuItem(string SectionIn, int SectionIDIn, int EngineerVisitIDIn, ref DataView ChecklistDataviewIn, ref DataGrid ChecklistDatagridIn)
            {
                Section = SectionIn;
                SectionID = SectionIDIn;
                EngineerVisitID = EngineerVisitIDIn;
                ChecklistDataview = ChecklistDataviewIn;
                ChecklistDatagrid = ChecklistDatagridIn;
                Text = "Check List : " + Section;
                Click += OpenChecklist;
            }

            private void OpenChecklist(object sender, EventArgs e)
            {
                App.ShowForm(typeof(FRMAnswers), true, new object[] { EngineerVisitID, SectionID, 0 });
                ChecklistDataview = App.DB.Checklists.GetAll_For_Engineer_Visit(EngineerVisitID);
                ChecklistDatagrid.DataSource = ChecklistDataview;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
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
                if (Conversions.ToBoolean(!(Operators.ConditionalCompareObjectEqual(timesheetTypesDT.Rows[i]["Name"], "Travelling", false) | Operators.ConditionalCompareObjectEqual(timesheetTypesDT.Rows[i]["Name"], "Working", false))))
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

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private UCDocumentsList DocumentsControl;

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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
                    txtCurrentContract.Text = currentContract.ContractType + " - Expires " + Strings.Format(currentContract.ContractEndDate, "dd/MM/yyyy");
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void FRMEngineerVisit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EngVisitCharge is object)
            {
                if (cbxReadyToBeInvoiced.Checked == true)
                {
                    string errorMsg = "";
                    if (EngVisitCharge.NominalCode.Trim().Length == 0)
                    {
                        errorMsg += "* Nominal Code is Mandatory" + Constants.vbCrLf;
                    }

                    if (EngVisitCharge.ForSageAccountCode.Trim().Length == 0)
                    {
                        errorMsg += "* Account Code is Mandatory" + Constants.vbCrLf;
                    }

                    if (EngVisitCharge.Department.Trim().Length == 0)
                    {
                        errorMsg += "* Department is Mandatory" + Constants.vbCrLf;
                    }

                    if (errorMsg.Length > 0)
                    {
                        e.Cancel = true;
                        App.ShowMessage("Cannot close for the following reasons:" + Constants.vbCrLf + errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (Job.StatusEnumID >= Conversions.ToInteger(Enums.JobStatus.Complete))
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
            int partID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblPart));
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
            int productID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblProduct));
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
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["LocationID"], 0, false) & (EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["AllocatedID"] == DBNull.Value || Operators.ConditionalCompareObjectEqual(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["AllocatedID"], 0, false))))
                {
                    // wasn't got from anywhere in the first place.

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Type"], "Part", false)))
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
                else if (RemovePart(Conversions.ToInteger(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Quantity"]), Conversions.ToString(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Name"]), Conversions.ToString(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Type"]), Conversions.ToInteger(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["ID"])))
                {
                    // REMOVE FROM DB
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Type"], "Part", false)))
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

            if ((btnAddPartProductUsed.Text ?? "") == "Add Part" & Conversions.ToBoolean(lblEquipment.Text) == true)
            {
                EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow);
                PartProductIDUsed = 0;
                txtNumberUsed.Text = "";
                txtNameUsed.Text = "";
                nudQuantityUsed.Value = 1;
                btnAddPartProductUsed.Text = "PICK ITEM";
                btnAddPartProductUsed.Enabled = false;
            }
            else if (DeclareWhereGotFrom(Conversions.ToInteger(newRow["Quantity"]), Conversions.ToString(newRow["Name"]), Conversions.ToString(newRow["Type"]), Conversions.ToInteger(newRow["ID"])))
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

            if (!(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboTimeSheetType)) > 0))
            {
                MessageBox.Show("Select a Timesheet Type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            foreach (DataRow timesheet in EngineerVisit.TimeSheets.Table.Rows)
            {
                if (Conversions.ToBoolean(dtpStartDate.Value >= timesheet["StartDateTime"] & dtpStartDate.Value <= timesheet["EndDateTime"]))
                {
                    MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Conversions.ToBoolean(dtpEndDate.Value >= timesheet["StartDateTime"] & dtpEndDate.Value <= timesheet["EndDateTime"]))
                {
                    MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Conversions.ToBoolean(dtpStartDate.Value <= timesheet["StartDateTime"] & dtpEndDate.Value >= timesheet["EndDateTime"]))
                {
                    MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            var newRow = EngineerVisit.TimeSheets.Table.NewRow();
            // TIMESHHETS ADD
            newRow["StartDateTime"] = Conversions.ToDate(Strings.Format(dtpStartDate.Value, "dd/MMM/yyyy HH:mm") + ":00");
            newRow["EndDateTime"] = Conversions.ToDate(Strings.Format(dtpEndDate.Value, "dd/MMM/yyyy HH:mm") + ":00");
            newRow["Comments"] = txtComments.Text;
            newRow["TimesheetTypeID"] = Combo.get_GetSelectedItemValue(cboTimeSheetType);
            newRow["TimesheetType"] = Combo.get_GetSelectedItemDescription(cboTimeSheetType);
            EngineerVisit.TimeSheets.Table.Rows.Add(newRow);
            dtpStartDate.Value = DateAndTime.Now;
            dtpEndDate.Value = DateAndTime.Now.AddMinutes(1);
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

                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOutcome)) == (double)Enums.EngineerVisitOutcomes.Complete)
                        {
                            if (Job?.JobTypeID == (int?)Enums.JobTypes.Commission == true)
                            {
                                if ((int)MessageBox.Show("Have You" + Constants.vbCrLf + "- Changed fuels?" + Constants.vbCrLf + "- Changed last service date?" + Constants.vbCrLf + "- Deactivated old Assets?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.No)
                                {
                                    App.ShowMessage("Please complete the tasks and then try again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cbxVisitLockDown.Checked = false;
                                    return;
                                }
                            }
                        }

                        // This will : save any changes, lock visit down AND enable the visit charge tab-are you sure
                        if ((int)MessageBox.Show("Any changes will now be saved, the visit details will be locked and the visit charges made available" + Constants.vbCrLf + "Do you want to continue?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
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
                errorMsg += "* Visit is not ready to be invoiced" + Constants.vbCrLf;
            }

            if (EngVisitCharge.NominalCode.Trim().Length == 0)
            {
            }

            if (EngVisitCharge.ForSageAccountCode.Trim().Length == 0)
            {
                errorMsg += "* Account Code is Mandatory" + Constants.vbCrLf;
            }

            if (EngVisitCharge.Department.Trim().Length == 0)
            {
                errorMsg += "* Department is Mandatory" + Constants.vbCrLf;
            }

            if (errorMsg.Length > 0)
            {
                // e.Cancel = True
                App.ShowMessage("Cannot close for the following reasons:" + Constants.vbCrLf + errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(dv.Table.Rows[0]["InvoiceToBeRaisedID"])).Table.Rows.Count > 0)
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
                var dt = App.DB.ExecuteWithReturn("Select TestType From tblEngineerVisitAdditionalChecks Where EngineerVisitID = " + EngineerVisit.EngineerVisitID);
                foreach (DataRow dr in dt.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["TestType"], 69318, false) | Operators.ConditionalCompareObjectEqual(dr["TestType"], 69319, false) | Operators.ConditionalCompareObjectEqual(dr["TestType"], 69473, false) | Operators.ConditionalCompareObjectEqual(dr["TestType"], 69592, false)))
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
            dialogue.Defect = App.DB.EngineerVisitDefects.EngineerVisitDefects_Get(Conversions.ToInteger(SelectedVisitDefectDataRow["EngineerVisitDefectID"]));
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
            dialogue.Worksheet = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_Get(Conversions.ToInteger(SelectedApplianceWorkSheetDataRow["EngineerVisitAssetWorkSheetID"]));
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
            dialogue.Worksheet = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_Get(Conversions.ToInteger(SelectedAdditionalWorkSheetDataRow["EngineerVisitAdditionalID"]));
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
            dialogue.AdditionalID = Conversions.ToInteger(SelectedSmokeComoDataRow["EngineerVisitAdditionalID"]);
            dialogue.EngineerVisitID = EngineerVisit.EngineerVisitID;
            try
            {
                dialogue.dtpDate.Value = Conversions.ToDate(SelectedSmokeComoDataRow["Date"]);
            }
            catch (Exception ex)
            {
                // dialogue.dtpDate.Enabled = False
                dialogue.chkNA.Checked = true;
                dialogue.dtpDate.Enabled = false;
            }

            var argcombo = dialogue.cboDetType;
            Combo.SetSelectedComboItem_By_Description(ref argcombo, Conversions.ToString(SelectedSmokeComoDataRow["Type"]));
            var argcombo1 = dialogue.cboPower;
            Combo.SetSelectedComboItem_By_Description(ref argcombo1, Conversions.ToString(SelectedSmokeComoDataRow["PowerType"]));
            var argcombo2 = dialogue.cboDateType;
            Combo.SetSelectedComboItem_By_Description(ref argcombo2, Conversions.ToString(SelectedSmokeComoDataRow["DateType"]));
            dialogue.txtLocation.Text = Conversions.ToString(SelectedSmokeComoDataRow["Location"]);
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

            App.DB.EngineerVisitAdditional.Delete(Conversions.ToInteger(SelectedSmokeComoDataRow["EngineerVisitAdditionalID"]));
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

            App.DB.EngineerVisitDefects.Delete(Conversions.ToInteger(SelectedVisitDefectDataRow["EngineerVisitDefectID"]));
            VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID);
        }

        private void btnRemoveApplianceWorkSheet_Click(object sender, EventArgs e)
        {
            if (SelectedApplianceWorkSheetDataRow is null)
            {
                return;
            }

            App.DB.EngineerVisitAssetWorkSheet.Delete(Conversions.ToInteger(SelectedApplianceWorkSheetDataRow["EngineerVisitAssetWorkSheetID"]));
            ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID);
        }

        private void btnRemoveAdd_Click(object sender, EventArgs e)
        {
            if (SelectedAdditionalWorkSheetDataRow is null)
            {
                return;
            }

            App.DB.EngineerVisitAdditional.Delete(Conversions.ToInteger(SelectedAdditionalWorkSheetDataRow["EngineerVisitAdditionalID"]));
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate()
        {
            Job = App.DB.Job.Get(EngineerVisit.EngineerVisitID, Entity.Jobs.GetBy.EngineerVisitId);
            theSite = App.DB.Sites.Get(Job.PropertyID);
            if (App.loggedInUser.UserRegions.Count > 0)
            {
                if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + theSite.RegionID).Length < 1)
                {
                    string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            else
            {
                string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
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
            var switchExpr = Conversions.ToInteger(EngineerVisit.StatusEnumID);
            switch (switchExpr)
            {
                case Conversions.ToInteger(Enums.VisitStatus.NOT_SET):
                    {
                        App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        closeMe = true;
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Parts_Need_Ordering):
                    {
                        App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        closeMe = true;
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts):
                    {
                        App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        closeMe = true;
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule):
                    {
                        txtStatus.Text = "Ready For Schedule";
                        txtUploadedBy.Text = "Not Set";
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Scheduled):
                    {
                        txtStatus.Text = "Scheduled";
                        txtUploadedBy.Text = "Not Set";
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Downloaded):
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
                            txtUploadedBy.Text = App.DB.User.Get(EngineerVisit.ManualEntryByUserID).Fullname + " via PC @ " + Strings.Format(EngineerVisit.ManualEntryOn, "dddd dd MMMM yyyy HH:mm:ss");
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
                var switchExpr1 = (Enums.EngineerVisitOutcomes)Conversions.ToInteger(EngineerVisit.OutcomeEnumID);
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
                if (Conversions.ToBoolean(Conversions.ToInteger(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEngineer)) == 0) & EngineerVisit.EngineerID))
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
                    txtScheduledTime.Text += Strings.Format(EngineerVisit.StartDateTime, "dddd dd MMMM yyyy HH:mm:ss");
                }

                txtScheduledTime.Text += " to ";
                if (EngineerVisit.EndDateTime == default)
                {
                    txtScheduledTime.Text += "'Not Set' ";
                }
                else
                {
                    txtScheduledTime.Text += Strings.Format(EngineerVisit.EndDateTime, "dddd dd MMMM yyyy HH:mm:ss");
                }

                // -------------------------------

                if (EngineerVisit.StartDateTime == default)
                {
                    txtScheduledTime2.Text += "'Not Set' ";
                }
                else
                {
                    txtScheduledTime2.Text += Strings.Format(EngineerVisit.StartDateTime, "ddd dd/MM/yyyy HH:mm:ss");
                }

                txtScheduledTime2.Text += "-";
                if (EngineerVisit.EndDateTime == default)
                {
                    txtScheduledTime2.Text += "'Not Set' ";
                }
                else
                {
                    txtScheduledTime2.Text += Strings.Format(EngineerVisit.EndDateTime, "ddd dd/MM/yyyy HH:mm:ss");
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
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Conversions.ToInteger(row["AssetID"]), dr["AssetID"], false)))
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
                dtpQCDocumentsRecieved.Value = Conversions.ToDate(Interaction.IIf(QC.DateDocumentsRecieved != default, QC.DateDocumentsRecieved, DateAndTime.Now));
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
                    var switchExpr2 = Conversions.ToInteger(dr["TestType"]);
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

            if (JobLock is null)
                JobLock = App.DB.JobLock.JobLock(Job.JobID);
            if (JobLock?.UserID != App.loggedInUser.UserID == true)
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
                txtCosts.Text = Strings.Format(totalCost, "C");
                txtProfit.Text = Strings.Format(Conversions.ToDouble(txtSale.Text) - Conversions.ToDouble(txtCosts.Text), "C");
                if (txtSale.Text.Length > 0)
                {
                    txtProfitPerc.Text = Math.Round(Conversions.ToDouble(txtProfit.Text) / Conversions.ToDouble(txtSale.Text) * 100, 2) + "%";
                }
                else
                {
                    txtProfitPerc.Text = "N/A";
                }

                double totalCharge = 0;
                var switchExpr = (Enums.JobChargingType)Conversions.ToInteger(EngVisitCharge.ChargeTypeID);
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
                        string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                        throw new System.Security.SecurityException(msg);
                    }
                }
                else
                {
                    string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }

                int fuelId = 0;
                if (SiteFuelsDataView.Table.Select("tick = 1").Length > 0)
                    fuelId = Conversions.ToInteger(SiteFuelsDataView.Table.Select("tick = 1")[0]["ManagerID"]);
                if (chkGasServiceCompleted.Checked && fuelId == Conversions.ToInteger(Enums.FuelTypes.NA))
                {
                    App.ShowMessage("Please select correct fuel type." + Constants.vbCrLf + "Cannot find fuel, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var switchExpr = Conversions.ToInteger(EngineerVisit.StatusEnumID);
                switch (switchExpr)
                {
                    case Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule):
                    case Conversions.ToInteger(Enums.VisitStatus.Scheduled):
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
                QC.DateDocumentsRecieved = Conversions.ToDate(Interaction.IIf(chkQCDocumentsRecieved.Checked, dtpQCDocumentsRecieved.Value, null));
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
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(drPriority["Name"], "RC - Recall", false)))
                    {
                        recallID = Conversions.ToInteger(drPriority["ManagerID"]);
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
                        jow.PriorityDateSet = DateAndTime.Now;
                        App.DB.JobOfWorks.Update_Priority(jow);
                    }
                    else if ((pk.Name ?? "") != "RC - Recall")
                    {
                        // Set to Recall
                        jow.SetPriority = recallID;
                        jow.PriorityDateSet = DateAndTime.Now;
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
                            jow.PriorityDateSet = DateAndTime.Now;
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
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving details : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                else if (EngVisitCharge.InvoiceReadyID == Conversions.ToInteger(Enums.InvoiceReady.Ready))
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                errMsg += "* Charge Description Required" + Constants.vbCrLf;
            }

            if (!(txtAdditionalCharge.Text.Trim().Length > 0))
            {
                errMsg += "* Charge Required" + Constants.vbCrLf;
            }
            else if (!Information.IsNumeric(txtAdditionalCharge.Text))
            {
                errMsg += "* Charge Must Be Numeric" + Constants.vbCrLf;
            }

            if (errMsg.Length > 0)
            {
                errMsg = "Please correct the following errors:" + Constants.vbCrLf + errMsg;
                MessageBox.Show(errMsg, "Additional Charge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Insert(EngineerVisit.EngineerVisitID, txtAdditionalChargeDescription.Text, Conversions.ToDouble(txtAdditionalCharge.Text));
                txtAdditionalCharge.Text = "";
                txtAdditionalChargeDescription.Text = "";
                PopulateAdditionalCharges();
            }
        }

        private void btnRemoveAdditionalCharge_Click(object sender, EventArgs e)
        {
            if (!(SelectedAdditionalChargesDataRow is null))
            {
                App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete(Conversions.ToInteger(SelectedAdditionalChargesDataRow["EngineerVisitAdditionalChargeID"]));
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

                App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete(Conversions.ToInteger(SelectedScheduleOfRateChargesDataRow["EngineerVisitScheduleOfRateChargesID"]));
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedScheduleOfRateChargesDataRow["tick"], 0, false)))
                {
                    App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(SelectedScheduleOfRateChargesDataRow["jobitemID"]), Conversions.ToDouble(SelectedScheduleOfRateChargesDataRow["Price"]), 1);
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(SelectedScheduleOfRateChargesDataRow["jobitemID"]), Conversions.ToDouble(SelectedScheduleOfRateChargesDataRow["Price"]), 0);
                }

                PopulateScheduleOfRateCharges();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                double price = Conversions.ToDouble(SelectedPartProductsChargesDataRow["Rate"] * ((double)1 + (double)Helper.MakeIntegerValid(txtPartsMarkUp.Text) / (double)100));
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPartProductsChargesDataRow["Type"], "Part", false)))
                {
                    try   // loosing the plot
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(SelectedPartProductsChargesDataRow["ChargeID"]));
                    }
                    catch (Exception ex)
                    {
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPartProductsChargesDataRow["tick"], 0, false)))
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(SelectedPartProductsChargesDataRow["UniqueID"]), price, 1, Conversions.ToDouble(SelectedPartProductsChargesDataRow["Rate"]), Conversions.ToInteger(SelectedPartProductsChargesDataRow["PartUsedID"]));
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(SelectedPartProductsChargesDataRow["UniqueID"]), price, 0, Conversions.ToDouble(SelectedPartProductsChargesDataRow["Rate"]), Conversions.ToInteger(SelectedPartProductsChargesDataRow["PartUsedID"]));
                    }
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Helper.MakeIntegerValid(SelectedPartProductsChargesDataRow["ChargeID"]));
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPartProductsChargesDataRow["tick"], 0, false)))
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(SelectedPartProductsChargesDataRow["UniqueID"]), price, 1, Conversions.ToDouble(SelectedPartProductsChargesDataRow["Rate"]));
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(SelectedPartProductsChargesDataRow["UniqueID"]), price, 0, Conversions.ToDouble(SelectedPartProductsChargesDataRow["Rate"]));
                    }
                }

                PopulatePartsProductsCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if ((Enums.InvoiceReady)Conversions.ToInteger(EngVisitCharge.InvoiceReadyID) == Enums.InvoiceReady.Ready)
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
                    if ((Enums.JobDefinition)Conversions.ToInteger(Job.JobDefinitionEnumID) == Enums.JobDefinition.Quoted)
                    {
                        gpbInvoice.Enabled = true;
                        ShowEditableVisitCharges();
                        // Check we have the VisitCharges
                        if (EngVisitCharge is object)
                        {
                            // Make sure we're not overwriting status alreay set - shouldn't be possible
                            if ((Enums.InvoiceReady)Conversions.ToInteger(EngVisitCharge.InvoiceReadyID) == Enums.InvoiceReady.Ready)
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
                    if ((Enums.InvoiceReady)Conversions.ToInteger(EngVisitCharge.InvoiceReadyID) == Enums.InvoiceReady.Ready)
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
                if (Information.IsNumeric(txtPercentOfQuote.Text))
                {
                    percentage = Conversions.ToDouble(txtPercentOfQuote.Text);
                    percentTotal = Helper.MakeDoubleValid(txtCharge.Text) / 100 * percentage;
                    lblQuotePercentageTotal.Text = Strings.Format(percentTotal, "C");
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

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedTimeSheetChargesDataRow["tick"], 0, false)))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedTimeSheetChargesDataRow["EngineerVisitTimesheetChargeID"], 0, false)))
                    {
                        InsertEngineerTimnesheetCharge(Conversions.ToDate(SelectedTimeSheetChargesDataRow["StartDateTime"]), Conversions.ToDate(SelectedTimeSheetChargesDataRow["EndDateTime"]), Conversions.ToInteger(SelectedTimeSheetChargesDataRow["TimesheetID"]), Conversions.ToInteger(SelectedTimeSheetChargesDataRow["TimeSheetTypeID"]), Conversions.ToDouble(SelectedTimeSheetChargesDataRow["EngineerCost"]), Conversions.ToBoolean(1), Conversions.ToInteger(SelectedTimeSheetChargesDataRow["EngineerVisitID"]));
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(SelectedTimeSheetChargesDataRow["EngineerVisitTimesheetChargeID"]), 1);
                    }
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(SelectedTimeSheetChargesDataRow["EngineerVisitTimesheetChargeID"]), 0);
                }

                PopulateTimeSheetCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var switchExpr = (Enums.JobChargingType)Conversions.ToInteger(EngVisitCharge.ChargeTypeID);
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
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVATRate)) < 1)
                {
                    vatRate = App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(dtpRaiseInvoiceOn.Value));
                }
                else
                {
                    vatRate = App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVATRate)));
                }

                if (vatRate is object)
                {
                    txtPriceIncVAT.Text = Strings.Format(EngVisitCharge.JobValue * (1 + vatRate.VATRate / 100), "C");
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
                App.DB.EngineerVisits.EngineerVisitUnitsUsed_Insert(EngineerVisit.EngineerVisitID, newJbItm.JobItemID, Conversions.ToDouble(newJbItm.Qty));

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void InsertCharges(Entity.QuoteJobs.QuoteJob jbQuote)
        {
            EngVisitCharge = new EngineerVisitCharge();

            // MileageRate
            var switchExpr = (Enums.JobDefinition)Conversions.ToInteger(Job.JobDefinitionEnumID);
            switch (switchExpr)
            {
                case Enums.JobDefinition.Quoted:
                    {
                        if (jbQuote is null)
                        {
                            EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID);
                            EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.JobValue);
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Not_Ready);
                        }
                        else
                        {
                            EngVisitCharge.SetLabourRate = Helper.MakeDoubleValid(jbQuote.MileageRate);
                            EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.QuoteValue);
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Not_Ready);
                        }

                        break;
                    }

                case Enums.JobDefinition.Contract:
                    {
                        // NEED TO SEE IF WE ARE INVOICING PER VISIT OR NOT?
                        int invoiceFreqID = App.DB.EngineerVisitCharge.EngineerVisitCharge_GetContractInvoiceFrequency(EngineerVisit.EngineerVisitID);
                        EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_ContractJob(Job.JobID);
                        if ((Enums.InvoiceFrequency)Conversions.ToInteger(invoiceFreqID) == Enums.InvoiceFrequency.Per_Visit)
                        {
                            // IF IS THEN LETS CHARGE FOR THE VISIT
                            EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.JobValue);
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Not_Ready);
                            lblContractPerVisit.Visible = true;
                        }
                        else
                        {
                            EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.NoChargeContractInvoice);
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Never);
                            lblContractPerVisit.Visible = false;
                        }

                        break;
                    }

                case Enums.JobDefinition.Misc:
                    {
                        EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID);
                        EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.NoChargeMisc);
                        EngVisitCharge.SetCharge = 0;
                        EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Never);
                        break;
                    }

                case Enums.JobDefinition.Callout:
                    {
                        EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID);
                        EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.JobValue);
                        EngVisitCharge.SetCharge = 0;
                        EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Not_Ready);
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
                App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(jobItemDR["JobItemID"]), Helper.MakeDoubleValid(jobItemDR["Price"]), 1);
                scheduleOfRatesTotal += Helper.MakeDoubleValid(jobItemDR["Price"]);
            }

            // Part&Products

            txtPartsMarkUp.Text = CustomerCharge.PartsMarkup.ToString();
            foreach (DataRow row in EngineerVisit.PartsAndProductsUsed.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Part", false)))
                {
                    App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(row["ID"]), Conversions.ToDouble(row["SellPrice"]), 1, GetPartProductCost(row), Conversions.ToInteger(row["UniqueID"]));
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(row["ID"]), Conversions.ToDouble(row["SellPrice"]), 1, GetPartProductCost(row));
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
                    int id = Conversions.ToInteger(custSorTable.Rows[0]["CustomerScheduleOfRateID"]);
                    TradeLabourRate = App.DB.CustomerScheduleOfRate.Get(id);  // Using a trade rate for a linked type of work
                    normalRate = TradeLabourRate.Price;
                    timeNHalfRate = TradeLabourRate.Price;
                    doubleRate = TradeLabourRate.Price;
                }

                foreach (DataRow timeSheet in EngineerVisit.TimeSheets.Table.Rows)
                    InsertEngineerTimnesheetCharge(Conversions.ToDate(timeSheet["StartDateTime"]), Conversions.ToDate(timeSheet["EndDateTime"]), Conversions.ToInteger(timeSheet["EngineerVisitTimeSheetID"]), Conversions.ToInteger(timeSheet["TimeSheetTypeID"]), 0, tick, EngineerVisit.EngineerVisitID);
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
                int id = Conversions.ToInteger(custSorTable.Rows[0]["CustomerScheduleOfRateID"]);
                TradeLabourRate = App.DB.CustomerScheduleOfRate.Get(id);  // Using a trade rate for a linked type of work
                normalRate = TradeLabourRate.Price;
                timeNHalfRate = TradeLabourRate.Price;
                doubleRate = TradeLabourRate.Price;
            }

            double totalPrice = 0.0;
            string summaryStr = "";
            int bankHolidayRate = Conversions.ToInteger(false);
            double engineerCostTotal = 0.0;

            // see if bank holiday first
            bankHolidayRate = App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_BankHoliday(StartDateTime);
            if (bankHolidayRate == 0)
            {
                var timeSheetRates = new DataView();
                timeSheetRates = App.DB.EngineerVisitCharge.EngineerVisitTimesheetCharge_ByTimeSheet(TimesheetID);
                foreach (DataRow rate in timeSheetRates.Table.Rows)
                {
                    var switchExpr = (Enums.LabourTypes)Conversions.ToInteger(rate["rate"]);
                    switch (switchExpr)
                    {
                        case Enums.LabourTypes.Basic:
                            {
                                totalPrice += rate["Total"] / 60 * normalRate;
                                summaryStr += "Basic: " + rate["Total"] + "mins@" + Strings.Format(normalRate, "C") + "/hr; ";
                                engineerCostTotal += rate["Total"] / 60 * engineerCostNormal;
                                break;
                            }

                        case Enums.LabourTypes.Time_And_Half:
                            {
                                totalPrice += rate["Total"] / 60 * timeNHalfRate;
                                summaryStr += "Time&Half: " + rate["Total"] + "mins@" + Strings.Format(timeNHalfRate, "C") + "/hr; ";
                                engineerCostTotal += rate["Total"] / 60 * engineerCostTimeHalf;
                                break;
                            }

                        case Enums.LabourTypes.Double:
                            {
                                totalPrice += rate["Total"] / 60 * doubleRate;
                                summaryStr += "Double: " + rate["Total"] + "mins@" + Strings.Format(doubleRate, "C") + "/hr; ";
                                engineerCostTotal += rate["Total"] / 60 * engineerCostDouble;
                                break;
                            }
                    }
                }
            }
            else
            {
                var switchExpr1 = (Enums.LabourTypes)Conversions.ToInteger(bankHolidayRate);
                switch (switchExpr1)
                {
                    case Enums.LabourTypes.Basic:
                        {
                            totalPrice = DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / (double)60 * normalRate;
                            summaryStr += "Bank Holiday Rate (Basic): " + DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) + "mins@" + Strings.Format(normalRate, "C") + "/hr; ";
                            engineerCostTotal += DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / (double)60 * engineerCostNormal;
                            break;
                        }

                    case Enums.LabourTypes.Time_And_Half:
                        {
                            totalPrice = DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / (double)60 * timeNHalfRate;
                            summaryStr += "Bank Holiday Rate (Time&Half): " + DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) + "mins@" + Strings.Format(timeNHalfRate, "C") + "/hr; ";
                            engineerCostTotal += DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / (double)60 * engineerCostTimeHalf;
                            break;
                        }

                    case Enums.LabourTypes.Double:
                        {
                            totalPrice = DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / (double)60 * doubleRate;
                            summaryStr += "Bank Holiday Rate (Double): " + DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) + "mins@" + Strings.Format(doubleRate, "C") + "/hr; ";
                            engineerCostTotal += DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / (double)60 * engineerCostDouble;
                            break;
                        }
                }
            }

            if (EngCost > 0)
            {
                engineerCostTotal = EngCost;
            }

            App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Insert(EngineerVisitID, Conversions.ToInteger(Tick), StartDateTime, EndDateTime, totalPrice, TimesheettypeID, summaryStr, engineerCostTotal);
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
                    App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete(Conversions.ToInteger(addCharge["EngineerVisitAdditionalChargeID"]));
            }

            // Delete Schedule OF Rate
            if (ScheduleOfRateCharges is object)
            {
                foreach (DataRow SofR in ScheduleOfRateCharges.Table.Rows)
                    App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete(Conversions.ToInteger(SofR["EngineerVisitScheduleOfRateChargesID"]));
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
            if (Job.JobDefinitionEnumID == Conversions.ToInteger(Enums.JobDefinition.Quoted))
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
            var switchExpr = (Enums.JobChargingType)Conversions.ToInteger(EngVisitCharge.ChargeTypeID);
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
            var switchExpr1 = (Enums.JobDefinition)Conversions.ToInteger(Job.JobDefinitionEnumID);
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

            var switchExpr2 = (Enums.InvoiceReady)Conversions.ToInteger(EngVisitCharge.InvoiceReadyID);
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
                if (taxrateid.Rows.Count == 0 || Information.IsDBNull(taxrateid.Rows[0]["VATRateID"])) // Check invoice details first if fail go looking for ready to be invoiced details..
                {
                    var argc = cboVATRate;
                    Combo.SetUpCombo(ref argc, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select);
                    if (readytobe is null || Information.IsDBNull(readytobe.Rows[0]["TaxrateID"])) // if not check if we have a rerady to be invoiced detailed if fail use default values..
                    {
                        var argcombo = cboVATRate;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, 6.ToString());
                        var argcombo1 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo1, 69482.ToString());
                    }
                    else // if they do exist use the ready to be invoiced details
                    {
                        var argcombo2 = cboVATRate;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo2, Conversions.ToString(readytobe.Rows[0]["TaxrateID"]));
                        var argcombo3 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo3, Conversions.ToString(readytobe.Rows[0]["PaymentTermID"]));
                    }
                }
                else // if there are invoice details (an invoice has been raised) use the invoice details
                {
                    var argc1 = cboVATRate;
                    Combo.SetUpCombo(ref argc1, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select);
                    var argcombo4 = cboVATRate;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo4, Conversions.ToString(taxrateid.Rows[0]["VATRateID"]));
                    if (!Information.IsDBNull(taxrateid.Rows[0]["TermID"]))
                    {
                        var argcombo5 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo5, Conversions.ToString(taxrateid.Rows[0]["TermID"]));
                        if (!Information.IsDBNull(taxrateid.Rows[0]["PaidByID"]) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(taxrateid.Rows[0]["TermID"], 69491, false)))
                        {
                            var argcombo6 = cboPaidBy;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo6, Conversions.ToString(taxrateid.Rows[0]["PaidByID"]));
                        }
                    }
                    else
                    {
                        var argcombo7 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo7, 69482.ToString());
                    }

                    txtInvNo.Text = Conversions.ToString(taxrateid.Rows[0]["InvoiceNumber"]);
                    txtInvAmount.Text = Strings.Format(taxrateid.Rows[0]["Amount"], "C");
                    txtCreditAmount.Text = Strings.Format(taxrateid.Rows[0]["CreditAmount"], "C");
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
            txtAdditionalChargeTotal.Text = Strings.Format(additionalChargeTotal, "C");
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

            txtScheduleOfRatesTotal.Text = Strings.Format(SORChargeTotal, "C");
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
                PPCostTotal += Helper.MakeDoubleValid(charge["Rate"]) * Helper.MakeDoubleValid(charge["Quantity"]);
            if (EngVisitCharge.PartsPrice > 0)
                PPChargeTotal = EngVisitCharge.PartsPrice;
            if (recalc | EngVisitCharge.PartsPrice == 0)
            {
                PPChargeTotal = 0;
                foreach (DataRow charge in PartProductsCharges.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(charge["Tick"]))
                    {
                        PPChargeTotal += Helper.MakeDoubleValid(charge["Total"]);
                    }
                }
            }

            txtPartsProductTotal.Text = Strings.Format(PPChargeTotal, "C");
            txtPartProductCost.Text = Strings.Format(PPCostTotal, "C");
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
                tSChargeTotal = Conversions.ToDouble(EngVisitCharge.LabourPrice);
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

            txtTimesheetTotal.Text = Strings.Format(tSChargeTotal, "C");
            txtEngineerCostTotal.Text = Strings.Format(tsCostTotal, "C");
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
            txtJobValue.Text = Strings.Format(JobValue, "C");
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
                    EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.JobValue);
                    EngVisitCharge.SetCharge = 0;
                    if (cbxReadyToBeInvoiced.Checked)
                    {
                        EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Ready);
                    }
                    else
                    {
                        EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Not_Ready);
                    }
                }
                else if (rdoPercentageOfQuoteValue.Checked == true) // Charging a percentage of a quote
                {
                    EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.PercentageOfQuote);
                    EngVisitCharge.SetCharge = Helper.MakeDoubleValid(txtPercentOfQuote.Text.Trim());
                    if (cbxReadyToBeInvoiced.Checked)
                    {
                        EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Ready);
                    }
                    else
                    {
                        EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Not_Ready);
                    }
                }
                else
                {
                    var switchExpr = (Enums.JobDefinition)Conversions.ToInteger(Job.JobDefinitionEnumID);
                    switch (switchExpr)
                    {
                        case Enums.JobDefinition.Quoted:
                            {
                                EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.QuoteValue);
                                EngVisitCharge.SetCharge = 0;
                                EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Never);
                                break;
                            }

                        case Enums.JobDefinition.Contract:
                            {
                                EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.NoChargeContractInvoice);
                                EngVisitCharge.SetCharge = 0;
                                EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Never);
                                break;
                            }

                        case Enums.JobDefinition.Misc:
                            {
                                EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.NoChargeMisc);
                                EngVisitCharge.SetCharge = 0; // No charge
                                EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Never);
                                break;
                            }

                        case Enums.JobDefinition.Callout:
                            {
                                EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.NoChargeCallout);
                                EngVisitCharge.SetCharge = 0; // No charge
                                EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Never);
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
            if (drIBCs.Length == 1 & EngineerVisit.OutcomeEnumID == Conversions.ToInteger(Enums.EngineerVisitOutcomes.Complete))
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
                             where Conversions.ToDouble(x.Field<string>("Name")) == ibcCostCentre
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
                    EngVisitCharge.SetChargeTypeID = Conversions.ToInteger(Enums.JobChargingType.JobValue);
                    EngVisitCharge.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Ready);
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
                    int invoiceAddressTypeId = Conversions.ToInteger(Enums.InvoiceAddressType.Invoice);
                    var invoiceRaiseDate = EngineerVisit.StartDateTime;
                    if (invoiceRaiseDate == default || DateHelper.GetFirstDayOfMonth(invoiceRaiseDate) < DateHelper.GetFirstDayOfMonth(DateAndTime.Now))
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
                        withBlock.RaiseDate = invoiceRaiseDate == default ? DateAndTime.Now : invoiceRaiseDate;
                        withBlock.SetInvoiceTypeID = Conversions.ToInteger(Enums.InvoiceType.Visit);
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
            if (EngVisitCharge.InvoiceReadyID == Conversions.ToInteger(Enums.InvoiceReady.Ready))
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
                dtpRaiseInvoiceOn.Value = DateAndTime.Now;
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
                InvoiceToBeRaised.SetInvoiceTypeID = Conversions.ToInteger(Enums.InvoiceType.Visit);
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
            string Type = Conversions.ToString(dr["Type"]);

            // WAS THE PART/PRODUCT ALLOCATED TO THE JOB ?
            // Dim sR As DataRow() = EngineerVisit.PartsAndProductsAllocated.Table.Select("Type='" & Type & "' AND PartProductID=" & dr(partProductColumnName))

            var Sr = EngineerVisit.PartsAndProductsAllocated.Table.Select("Type='" + Type + "' AND  ID=" + Helper.MakeIntegerValid(dr["AllocatedID"]));
            if (Sr.Length > 0)
            {

                // WAS IT ORDERED
                if (Helper.MakeIntegerValid(Sr[0]["OrderID"]) > 0)
                {
                    var dv = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(Sr[0]["OrderID"]));
                    DataRow[] pR;
                    // WAS IT SOURCED FROM SUPPLIER
                    if ((Enums.LocationType)Conversions.ToInteger(Sr[0]["OrderLocationTypeID"]) == Enums.LocationType.Supplier)
                    {
                        pR = dv.Table.Select(Conversions.ToString("Type='Order" + Type + "' AND PartProductID=" + dr[partProductColumnName]));
                    }
                    else  // FROM WAREHOUSE OR VAN
                    {
                        return GetSupplierBuyPrice(dr);
                        // pR = dv.Table.Select("Type='OrderLocation" & Type & "' AND PartProductID=" & dr(partProductColumnName))
                    }

                    // FOUND PART
                    if (pR.Length > 0)
                    {
                        return Helper.MakeDoubleValid(pR[0]["BuyPrice"] * dr["Quantity"]);
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
                dt = App.DB.PartSupplier.Get_ByPartID(Conversions.ToInteger(dr["ID"])).Table;
                var drPre = dt.Select("Preferred=1");
                if (drPre.Length > 0)
                {
                    return Conversions.ToDouble(drPre[0]["Price"] * Helper.MakeDoubleValid(dr["Quantity"]));
                }

                double lowest = 0;
                if (dt.Rows.Count > 0)
                {
                    lowest = Conversions.ToDouble(dt.Rows[0]["Price"]);
                    foreach (DataRow r in dt.Rows)
                    {
                        if (Conversions.ToBoolean(r["Price"] < lowest))
                        {
                            lowest = Conversions.ToDouble(r["Price"]);
                        }
                    }
                }

                return lowest * Helper.MakeDoubleValid(dr["Quantity"]);
            }
            else
            {
                dt = App.DB.ProductSupplier.Get_ByProductID(Conversions.ToInteger(dr["ID"])).Table;
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
                case Conversions.ToInteger(Enums.InvoiceAddressType.HQ):
                case Conversions.ToInteger(Enums.InvoiceAddressType.Site):
                    {
                        {
                            var withBlock = App.DB.Sites.Get(AddressLinkID);
                            if (withBlock.Name.Trim().Length > 0)
                            {
                                address += withBlock.Name + Constants.vbCrLf;
                            }

                            if (withBlock.Address1.Trim().Length > 0)
                            {
                                address += withBlock.Address1 + Constants.vbCrLf;
                            }

                            if (withBlock.Address2.Trim().Length > 0)
                            {
                                address += withBlock.Address2 + Constants.vbCrLf;
                            }

                            if (withBlock.Address3.Trim().Length > 0)
                            {
                                address += withBlock.Address3 + Constants.vbCrLf;
                            }

                            if (withBlock.Address4.Trim().Length > 0)
                            {
                                address += withBlock.Address4 + Constants.vbCrLf;
                            }

                            if (withBlock.Address5.Trim().Length > 0)
                            {
                                address += withBlock.Address5 + Constants.vbCrLf;
                            }

                            if (withBlock.Postcode.Trim().Length > 0)
                            {
                                address += withBlock.Postcode + Constants.vbCrLf;
                            }
                        }

                        lblInvoiceAddressDetails.Text = address;
                        break;
                    }

                case Conversions.ToInteger(Enums.InvoiceAddressType.Invoice):
                    {
                        {
                            var withBlock1 = App.DB.InvoiceAddress.InvoiceAddress_Get(AddressLinkID);
                            if (withBlock1.Address1.Trim().Length > 0)
                            {
                                address += withBlock1.Address1 + Constants.vbCrLf;
                            }

                            if (withBlock1.Address2.Trim().Length > 0)
                            {
                                address += withBlock1.Address2 + Constants.vbCrLf;
                            }

                            if (withBlock1.Address3.Trim().Length > 0)
                            {
                                address += withBlock1.Address3 + Constants.vbCrLf;
                            }

                            if (withBlock1.Address4.Trim().Length > 0)
                            {
                                address += withBlock1.Address4 + Constants.vbCrLf;
                            }

                            if (withBlock1.Address5.Trim().Length > 0)
                            {
                                address += withBlock1.Address5 + Constants.vbCrLf;
                            }

                            if (withBlock1.Postcode.Trim().Length > 0)
                            {
                                address += withBlock1.Postcode + Constants.vbCrLf;
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
            var openVisits = visits.Table.Select("StatusEnumID = " + Conversions.ToInteger(Enums.VisitStatus.Uploaded));
            if (openVisits.Length == 0)
                return;
            string msg = "This current visit has job releated charges." + Constants.vbCrLf + Constants.vbCrLf + "There are open relating visits, do you want to cost them off as non-chargeable?";
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
                            ev.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Not_To_Be_Invoiced);
                            App.DB.EngineerVisits.Update(ev, 0, true);
                            var evc = new EngineerVisitCharge();
                            {
                                var withBlock = evc;
                                withBlock.SetEngineerVisitID = ev.EngineerVisitID;
                                withBlock.SetNominalCode = txtNominalCode.Text.Trim();
                                withBlock.SetDepartment = Combo.get_GetSelectedItemValue(cboDept).Trim();
                                withBlock.SetForSageAccountCode = txtAccountCode.Text.Trim();
                                withBlock.SetInvoiceReadyID = Conversions.ToInteger(Enums.InvoiceReady.Never);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public class AllocatedStatusColourColumn : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                // set the color required dependant on the column value
                Brush brush;
                if (Helper.MakeBooleanValid(source.List[rowNum].row.item("Status")))
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
                    foreach (DataRow distrow in PartsAndProductsDistribution.Table.Select(Conversions.ToString("Type = '" + row["Type"] + "'")))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(distrow["AllocatedID"], row["ID"], false)))
                        {
                            distributed += distrow["Quantity"];
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
                        creditamt = Conversions.ToInteger(row["CreditQty"]);
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["OrderItemID"], 0, false)))
                    {
                        row["Status"] = true;
                    }
                    else if (Conversions.ToBoolean(distributed + creditamt >= row["QtyRemaining"]))
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
            foreach (DataRow row in PartsAndProductsDistribution.Table.Select(Conversions.ToString("Type = '" + SelectedPartProductAllocatedDataRow["Type"] + "'")))
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["AllocatedID"], SelectedPartProductAllocatedDataRow["ID"], false)))
                {
                    distributed += row["Quantity"];
                }
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(distributed, SelectedPartProductAllocatedDataRow["Quantity"], false)))
            {
                App.ShowMessage(Conversions.ToString("Distribution is complete for this " + SelectedPartProductAllocatedDataRow["Type"]), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string msg = "Are you sure the remaining";
            msg += Conversions.ToString(" " + (SelectedPartProductAllocatedDataRow["Quantity"] - distributed) + ", ") + SelectedPartProductAllocatedDataRow["Name"] + "'s have not been used? This action cannot be reversed once the job details have been saved";
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
                r["Quantity"] = SelectedPartProductAllocatedDataRow["Quantity"] - distributed;
                r["PartProductID"] = SelectedPartProductAllocatedDataRow["PartProductID"];
                r["OrderPartProductID"] = 0;
                r["StockTransactionType"] = Conversions.ToInteger(Enums.Transaction.StockIn);
                PartsAndProductsDistribution.Table.Rows.Add(r);
                SelectedPartProductAllocatedDataRow["Status"] = true;
            }
            else
            {
                int qtyReturned = 0;
                // IS THE PART ON A SUPPLIER PO THAT IS COMPLETE
                bool flagComleted = false;
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPartProductAllocatedDataRow["OrderStatusID"], Conversions.ToInteger(Enums.OrderStatus.Confirmed), false)))
                {
                    if (App.ShowMessage("This order is still confirmed! Would you like to make it as complete now?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CompleteOrder(Conversions.ToInteger(SelectedPartProductAllocatedDataRow["OrderItemID"]));
                        flagComleted = true;
                    }
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPartProductAllocatedDataRow["OrderLocationTypeID"], Conversions.ToInteger(Enums.LocationType.Supplier), false) & (SelectedPartProductAllocatedDataRow["OrderStatusID"] >= Conversions.ToInteger(Enums.OrderStatus.Complete) | flagComleted == true)))
                {
                    var fAddPartToBeCredited = new FRMAddPartToBeCredited(Conversions.ToInteger(SelectedPartProductAllocatedDataRow["Quantity"] - distributed));
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

                if (Conversions.ToBoolean(SelectedPartProductAllocatedDataRow["Quantity"] - distributed > 0))
                {
                    var frmDistribution = new FRMDistributeAllocated(false, Conversions.ToInteger(SelectedPartProductAllocatedDataRow["Quantity"] - distributed), Conversions.ToString(SelectedPartProductAllocatedDataRow["Name"]), Conversions.ToString(SelectedPartProductAllocatedDataRow["Type"]), Conversions.ToInteger(SelectedPartProductAllocatedDataRow["PartProductID"]), null);
                    if (frmDistribution.ShowDialog() == DialogResult.OK)
                    {
                        PartsAndProductsDistribution.Table.AcceptChanges();
                        foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                        {
                            if (Conversions.ToBoolean(row["Quantity"] > 0))
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
                                r["StockTransactionType"] = Conversions.ToInteger(Enums.Transaction.StockIn);
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
            if (!(CurrentOrder.OrderStatusID == Conversions.ToInteger(Enums.OrderStatus.Confirmed)))
            {
                App.ShowMessage("Order must be confirmed to Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var ItemsIncludedDataView = App.DB.Order.Order_ItemsGetAll(OrderPartz.OrderID);
            foreach (DataRow itemRow in ItemsIncludedDataView.Table.Rows)
            {
                if (!(Conversions.ToInteger(itemRow["QuantityOnOrder"]) == Conversions.ToInteger(itemRow["QuantityReceived"])))
                {
                    int quantityInput = Conversions.ToInteger(itemRow["QuantityOnOrder"]) - Conversions.ToInteger(itemRow["QuantityReceived"]);
                    var switchExpr = Conversions.ToString(itemRow["Type"]);
                    switch (switchExpr)
                    {
                        case "OrderProduct":
                            {
                                var OrderProduct = new Entity.OrderProducts.OrderProduct();
                                var oProduct = new Entity.Products.Product();
                                OrderProduct = App.DB.OrderProduct.OrderProduct_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID);
                                oProduct = App.DB.Product.Product_Get(oProductSupplier.ProductID);
                                OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + quantityInput;
                                App.DB.OrderProduct.Update(OrderProduct);
                                var switchExpr1 = CurrentOrder.OrderTypeID;
                                switch (switchExpr1)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID);
                                            var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                            oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oProductTransaction.SetProductID = oProductSupplier.ProductID;
                                            oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID;
                                            oProductTransaction.SetAmount = quantityInput * oProductSupplier.QuantityInPack;
                                            oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                            App.DB.ProductTransaction.Insert(oProductTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderPart":
                            {
                                var OrderPart = new Entity.OrderParts.OrderPart();
                                OrderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(itemRow["ID"]));
                                OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + quantityInput;
                                App.DB.OrderPart.Update(OrderPart);
                                var switchExpr2 = CurrentOrder.OrderTypeID;
                                switch (switchExpr2)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID);
                                            var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID);
                                            var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                            oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oPartTransaction.SetPartID = oPartSupplier.PartID;
                                            oPartTransaction.SetOrderPartID = OrderPart.OrderPartID;
                                            oPartTransaction.SetAmount = quantityInput * oPartSupplier.QuantityInPack;
                                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderLocationProduct":
                            {
                                var OrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oProductTransaction = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(OrderLocationProduct.OrderLocationProductID);
                                oProductTransaction.SetAmount = oProductTransaction.Amount + quantityInput;
                                App.DB.ProductTransaction.Update(oProductTransaction);
                                oProductTransaction.SetLocationID = OrderLocationProduct.LocationID;
                                oProductTransaction.SetProductID = OrderLocationProduct.ProductID;
                                oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID;
                                oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockOut);
                                oProductTransaction.SetAmount = -quantityInput;
                                App.DB.ProductTransaction.Insert(oProductTransaction);
                                OrderLocationProduct.SetQuantityReceived = OrderLocationProduct.QuantityReceived + quantityInput;
                                App.DB.OrderLocationProduct.Update(OrderLocationProduct);
                                var switchExpr3 = CurrentOrder.OrderTypeID;
                                switch (switchExpr3)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            Entity.OrderLocations.OrderLocation oOrderLocation;
                                            oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationProduct.OrderID);
                                            oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
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
                                var OrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oPartTransaction = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID);
                                oPartTransaction.SetAmount = oPartTransaction.Amount + quantityInput;
                                App.DB.PartTransaction.Update(oPartTransaction);
                                oPartTransaction.SetLocationID = OrderLocationPart.LocationID;
                                oPartTransaction.SetPartID = OrderLocationPart.PartID;
                                oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockOut);
                                oPartTransaction.SetAmount = -quantityInput;
                                App.DB.PartTransaction.Insert(oPartTransaction);
                                OrderLocationPart.SetQuantityReceived = OrderLocationPart.QuantityReceived + quantityInput;
                                App.DB.OrderLocationPart.Update(OrderLocationPart);
                                var switchExpr4 = CurrentOrder.OrderTypeID;
                                switch (switchExpr4)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            Entity.OrderLocations.OrderLocation oOrderLocation;
                                            oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID);
                                            oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
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

            CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Complete);
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
                    if (Conversions.ToBoolean(row["Quantity"] > 0))
                    {
                        var r = PartsAndProductsDistribution.Table.NewRow();
                        r["Type"] = TypeIn;
                        r["DistributedID"] = 0;
                        r["LocationID"] = row["LocationID"];
                        r["AllocatedID"] = row["AllocatedID"];
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false) & Operators.ConditionalCompareObjectEqual(row["AllocatedID"], 0, false)))
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
                    foreach (DataRow distrow in PartsAndProductsDistribution.Table.Select(Conversions.ToString("Type = '" + row["Type"] + "'")))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(distrow["AllocatedID"], row["ID"], false)))
                        {
                            distributed += distrow["Quantity"];
                        }
                    }

                    if (Conversions.ToBoolean(distributed >= row["Quantity"]))
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
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Status"], false, false) & Operators.ConditionalCompareObjectEqual(row["PartProductID"], PartProductIDIn, false) & Operators.ConditionalCompareObjectEqual(row["Type"], TypeIn, false) & Helper.MakeIntegerValid(row["OrderID"]) != 0))
                {
                    int distributed = 0;
                    foreach (DataRow dist in PartsAndProductsDistribution.Table.Select("Type = '" + TypeIn + "'"))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dist["AllocatedID"], row["ID"], false)))
                        {
                            distributed += dist["Quantity"];
                        }
                    }

                    int amountAvailable = Conversions.ToInteger(row["Quantity"] - distributed);
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
                    var fAddPartToBeCredited = new FRMAddPartToBeCredited(Conversions.ToInteger(SelectedPartProductAllocatedDataRow["Quantity"] - distributed));
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

                    if (Conversions.ToBoolean(SelectedPartProductAllocatedDataRow["Quantity"] - distributed > 0))
                    {
                        var frmDistribution = new FRMDistributeAllocated(false, Quantity, PartProductName, Type, PartProductID, null);
                        if (frmDistribution.ShowDialog() == DialogResult.OK)
                        {
                            PartsAndProductsDistribution.Table.AcceptChanges();
                            foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                            {
                                if (Conversions.ToBoolean(row["Quantity"] > 0))
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
                                    r["StockTransactionType"] = Conversions.ToInteger(Enums.Transaction.StockIn);
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
                    if (Conversions.ToBoolean(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["OrderPartID"] > 0))
                    {
                        var fAddPartToBeCredited = new FRMAddPartToBeCredited(Conversions.ToInteger(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Quantity"] - distributed));
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

                    if (Conversions.ToBoolean(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Quantity"] - distributed > 0))
                    {
                        var frmDistribution = new FRMDistributeAllocated(false, Quantity, PartProductName, Type, PartProductID, null);
                        if (frmDistribution.ShowDialog() == DialogResult.OK)
                        {
                            PartsAndProductsDistribution.Table.AcceptChanges();
                            foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                            {
                                if (Conversions.ToBoolean(row["Quantity"] > 0))
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
                                    r["StockTransactionType"] = Conversions.ToInteger(Enums.Transaction.StockIn);
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
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false)))
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
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false) & dr["QtyRemaining"] > 0))
                    {
                        UsePart(dr, Conversions.ToInteger(dr["QtyRemaining"]));
                    }
                }
            }
            else
            {
                foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false)))
                    {
                        UsePart(dr, Conversions.ToInteger(nudPartAllocatedQty.Value));
                    }
                }
            }
        }

        public void UsePart(DataRow dr, int qty)
        {
            bool addUsed = false;
            int LocationID = 0;
            int distributed = 0;
            foreach (DataRow row in PartsAndProductsDistribution.Table.Select(Conversions.ToString("Type = '" + dr["Type"] + "'")))
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["AllocatedID"], dr["ID"], false)))
                {
                    distributed += row["Quantity"];
                }
            }

            if (Conversions.ToBoolean(distributed >= dr["Quantity"]))
            {
                App.ShowMessage(Conversions.ToString("Distribution is complete for this " + dr["Type"]), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Helper.MakeIntegerValid(dr["OrderID"]) == 0)
            {
                var frmDistribution = new FRMDistributeAllocated(true, qty, Conversions.ToString(dr["Name"]), Conversions.ToString(dr["Type"]), Conversions.ToInteger(dr["PartProductID"]), BuildAllocatedArray(Conversions.ToInteger(dr["PartProductID"]), Conversions.ToString(dr["Type"])));
                if (frmDistribution.ShowDialog() == DialogResult.OK)
                {
                    PartsAndProductsDistribution.Table.AcceptChanges();
                    foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                    {
                        if (Conversions.ToBoolean(row["QtyRemaining"] > 0))
                        {
                            var drA = PartsAndProductsDistribution.Table.Select(Conversions.ToString("AllocatedID = " + dr["ID"]));
                            foreach (DataRow r in drA)
                            {
                                if (r is null)
                                {
                                    r = PartsAndProductsDistribution.Table.NewRow();
                                    r["Type"] = dr["Type"];
                                    r["DistributedID"] = 0;
                                    r["LocationID"] = row["LocationID"];
                                    r["AllocatedID"] = dr["ID"];
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                                    {
                                        r["Other"] = true;
                                    }
                                    else
                                    {
                                        r["Other"] = false;
                                    }

                                    r["Quantity"] = qty;
                                    r["PartProductID"] = dr["PartProductID"];
                                    r["OrderPartProductID"] = 0;
                                    r["StockTransactionType"] = Conversions.ToInteger(Enums.Transaction.StockOut);
                                    PartsAndProductsDistribution.Table.Rows.Add(r);
                                    LocationID = Conversions.ToInteger(row["LocationID"]);
                                }
                                else
                                {
                                    r["Quantity"] += qty;
                                }
                            }
                        }
                    }

                    dr["QtyRemaining"] -= qty;
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Quantity"] - dr["QtyRemaining"], dr["Quantity"], false)))
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
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["OrderStatusID"], Conversions.ToInteger(Enums.OrderStatus.Confirmed), false)))
                {
                    if (App.ShowMessage("This order is still confirmed! Would you like to make it as complete now?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CompleteOrder(Conversions.ToInteger(dr["OrderItemID"]));
                        flagComleted = true;
                    }
                }

                if (Helper.MakeIntegerValid(dr["QuantityOrdered"]) == Helper.MakeIntegerValid(dr["QuantityReceived"]) | flagComleted == true)
                {
                    PartsAndProductsDistribution.Table.AcceptChanges();
                    var drA = PartsAndProductsDistribution.Table.Select(Conversions.ToString("AllocatedID = " + dr["ID"]));
                    foreach (DataRow r in drA)
                    {
                        if (r is null)
                        {
                            r = PartsAndProductsDistribution.Table.NewRow();
                            r["Type"] = dr["Type"];
                            r["DistributedID"] = 0;
                            r["LocationID"] = 0;
                            r["AllocatedID"] = dr["ID"];
                            r["Other"] = false;
                            r["Quantity"] = qty;
                            r["PartProductID"] = dr["PartProductID"];
                            r["OrderPartProductID"] = dr["OrderItemID"];
                            r["StockTransactionType"] = 0;
                            PartsAndProductsDistribution.Table.Rows.Add(r);
                        }
                        else
                        {
                            r["Quantity"] += qty;
                        }
                    }

                    dr["QtyRemaining"] -= qty;
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Quantity"] - dr["QtyRemaining"], dr["Quantity"], false)))
                    {
                        dr["Status"] = true;
                    }

                    addUsed = true;
                }
                else if (App.ShowMessage("This is part that has been ordered but not fully received." + Constants.vbCrLf + "Would you like to continue and select stock from another location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var frmDistribution = new FRMDistributeAllocated(true, qty, Conversions.ToString(dr["Name"]), Conversions.ToString(dr["Type"]), Conversions.ToInteger(dr["PartProductID"]), BuildAllocatedArray(Conversions.ToInteger(dr["PartProductID"]), Conversions.ToString(dr["Type"])));
                    if (frmDistribution.ShowDialog() == DialogResult.OK)
                    {
                        PartsAndProductsDistribution.Table.AcceptChanges();
                        foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                        {
                            if (Conversions.ToBoolean(row["QtyRemaining"] > 0))
                            {
                                var drA = PartsAndProductsDistribution.Table.Select(Conversions.ToString("AllocatedID = " + dr["ID"]));
                                foreach (DataRow r in drA)
                                {
                                    if (r is null)
                                    {
                                        r = PartsAndProductsDistribution.Table.NewRow();
                                        r["Type"] = dr["Type"];
                                        r["DistributedID"] = 0;
                                        r["LocationID"] = row["LocationID"];
                                        r["AllocatedID"] = dr["ID"];
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                                        {
                                            r["Other"] = true;
                                        }
                                        else
                                        {
                                            r["Other"] = false;
                                        }

                                        r["Quantity"] = qty;
                                        r["PartProductID"] = dr["PartProductID"];
                                        r["OrderPartProductID"] = 0;
                                        r["StockTransactionType"] = Conversions.ToInteger(Enums.Transaction.StockOut);
                                        PartsAndProductsDistribution.Table.Rows.Add(r);
                                        LocationID = Conversions.ToInteger(row["LocationID"]);
                                    }
                                    else
                                    {
                                        r["Quantity"] += qty;
                                    }
                                }
                            }
                        }

                        dr["QtyRemaining"] -= qty;
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Quantity"] - dr["QtyRemaining"], dr["Quantity"], false)))
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
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Type"], "Part", false)))
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
                    dialogue.Part = Conversions.ToString(dr["Name"]);
                    dialogue.ShowDialog();
                    dialogue.Close();
                    var part = App.DB.Part.Part_Get(Conversions.ToInteger(dr["PartProductID"]));
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
                    var product = App.DB.Product.Product_Get(Conversions.ToInteger(dr["PartProductID"]));
                    newRow["Number"] = product.Number;
                    newRow["Name"] = product.Name;
                    newRow["Reference"] = product.Reference;
                    newRow["SellPrice"] = product.SellPrice;
                }

                EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                ucPhotoControl.Caption = Conversions.ToString(photoRow["Caption"]);
                ucPhotoControl.EngineerVisitPhotoID = Conversions.ToInteger(photoRow["EngineerVisitPhotoID"]);
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
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOutcome)) == Conversions.ToInteger(Enums.EngineerVisitOutcomes.Complete))
            {
                chkGasServiceCompleted.Enabled = true;
                if (Job.JobTypeID == Conversions.ToInteger(Enums.JobTypes.ServiceCertificate) | Job.JobTypeID == Conversions.ToInteger(Enums.JobTypes.Service))
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
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboRecharge)) > 0)
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
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboInvType)) == 69491)
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

            bool selected = !Conversions.ToBoolean(dgPartsProductsAllocated[dgPartsProductsAllocated.CurrentRowIndex, 1]);
            dgPartsProductsAllocated[dgPartsProductsAllocated.CurrentRowIndex, 1] = selected;
            int selectedCount = 0;
            foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
            {
                if (Conversions.ToBoolean(dr["Tick"]))
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
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool selected = !Conversions.ToBoolean(dgSiteFuel[dgSiteFuel.CurrentRowIndex, 0]);
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
                        App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(dr["EngineerVisitTimesheetChargeID"]), 1);
                }
                else
                {
                    foreach (DataRow dr in TimeSheetCharges.Table.Rows)
                        App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(dr["EngineerVisitTimesheetChargeID"]), 0);
                }

                PopulateTimeSheetCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Type"], "Part", false)))
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(dr["ChargeID"]));
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(dr["UniqueID"]), Conversions.ToDouble(dr["Price"]), 1, Conversions.ToDouble(dr["Cost"]), Conversions.ToInteger(dr["PartUsedID"]));
                        }
                        else
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Conversions.ToInteger(dr["ChargeID"]));
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(dr["UniqueID"]), Conversions.ToDouble(dr["Price"]), 1, Conversions.ToDouble(dr["Cost"]));
                        }

                        dr["tick"] = true;
                    }
                }
                else
                {
                    foreach (DataRow dr in PartProductsCharges.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Type"], "Part", false)))
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(dr["ChargeID"]));
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(dr["UniqueID"]), Conversions.ToDouble(dr["Price"]), 0, Conversions.ToDouble(dr["Cost"]), Conversions.ToInteger(dr["PartUsedID"]));
                        }
                        else
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Conversions.ToInteger(dr["ChargeID"]));
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(dr["UniqueID"]), Conversions.ToDouble(dr["Price"]), 0, Conversions.ToDouble(dr["Cost"]));
                        }

                        dr["tick"] = false;
                    }
                }

                PopulatePartsProductsCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLabourMarkUp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow dr in TimeSheetCharges.Table.Rows)
                    App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(dr["EngineerVisitTimesheetChargeID"]), 1);
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
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Type"], "Part", false)))
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(dr["ChargeID"]));
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(dr["UniqueID"]), Conversions.ToDouble(dr["Price"]), 0, Conversions.ToDouble(dr["Cost"]), Conversions.ToInteger(dr["PartUsedID"]));
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Conversions.ToInteger(dr["ChargeID"]));
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, Conversions.ToInteger(dr["UniqueID"]), Conversions.ToDouble(dr["Price"]), 0, Conversions.ToDouble(dr["Cost"]));
                    }

                    dr["tick"] = false;
                }

                foreach (DataRow dr in TimeSheetCharges.Table.Rows)
                    App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(dr["EngineerVisitTimesheetChargeID"]), 0);
            }
            catch (Exception ex)
            {
            }
        }
    }
}