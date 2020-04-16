// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractsOriginal;
using FSM.Entity.CostCentres;
using FSM.Entity.CustomerCharges;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisitAdditionals;
using FSM.Entity.EngineerVisitAssetWorkSheets;
using FSM.Entity.EngineerVisitCharges;
using FSM.Entity.EngineerVisitDefectss;
using FSM.Entity.EngineerVisitNCCGSRs;
using FSM.Entity.EngineerVisitPhotos;
using FSM.Entity.EngineerVisitQCs;
using FSM.Entity.EngineerVisits;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers.Enums;
using FSM.Entity.InvoiceAddresss;
using FSM.Entity.InvoicedLiness;
using FSM.Entity.Invoiceds;
using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.JobAudits;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Management;
using FSM.Entity.OrderLocations;
using FSM.Entity.OrderParts;
using FSM.Entity.OrderProducts;
using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.PickLists;
using FSM.Entity.Products;
using FSM.Entity.ProductSuppliers;
using FSM.Entity.ProductTransactions;
using FSM.Entity.QuoteJobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.VATRatess;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class FRMEngineerVisit : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataTable dtEngineerGetAll;
    private DataTable dtPassFailNA;
    private DataTable dtYesNoNA;
    private DataTable dtYesNo;
    private UCDocumentsList DocumentsControl;
    private DataView _VisitDefectDataview;
    private DataView _ApplianceWorkSheetDataview;
    private DataView _AdditionalWorkSheetDataview;
    private DataView _SmokeComoDataview;
    private FRMLogCallout _LogCalloutForm;
    private bool _updating;
    private bool _Loading;
    private EngineerVisit _EngineerVisit;
    private DataView _JobItems;
    private int _PartProductIDUsed;
    private string _PartProductReferenceUsed;
    private FSM.Entity.Sites.Site _theSite;
    private DataView _AssetsTable;
    private EngineerVisitQC _QC;
    private FSM.Entity.JobLock.JobLock _JobLock;
    private CustomerCharge _customerCharge;
    private int loops;
    private bool isSpecialPart;
    private DataView _AdditionalCharges;
    private DataView _ScheduleOfRateCharges;
    private EngineerVisitCharge _engVisitCharge;
    private DataView _PartProductsCharges;
    private Job _Job;
    private bool _readOnly;
    private DataView _TimeSheetCharges;
    private InvoiceToBeRaised _invoiceToBeRaised;
    private DataView _PartsAndProductsAllocated;
    private DataView _PartsAndProductsUsed;
    private DataView _PartsAndProductsDistribution;
    private DataView _PhotoDataview;
    private DataView _dvSiteFuels;

    public FRMEngineerVisit()
    {
      this.FormClosing += new FormClosingEventHandler(this.FRMEngineerVisit_FormClosing);
      this.Load += new EventHandler(this.FRMEngineerVisit_Load);
      this.dtEngineerGetAll = App.DB.Engineer.Engineer_GetAll().Table;
      this.dtPassFailNA = App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.PassFailNA, false).Table;
      this.dtYesNoNA = App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.YesNoNA, false).Table;
      this.dtYesNo = App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.YesNo, false).Table;
      this._LogCalloutForm = (FRMLogCallout) null;
      this._updating = true;
      this._Loading = true;
      this._PartProductIDUsed = 0;
      this._PartProductReferenceUsed = "";
      this._AssetsTable = (DataView) null;
      this.loops = 0;
      this.isSpecialPart = false;
      this._readOnly = false;
      this._invoiceToBeRaised = (InvoiceToBeRaised) null;
      this._PartsAndProductsAllocated = (DataView) null;
      this._PartsAndProductsUsed = (DataView) null;
      this._PartsAndProductsDistribution = (DataView) null;
      this._dvSiteFuels = (DataView) null;
      this.InitializeComponent();
      ComboBox cboInvType = this.cboInvType;
      Combo.SetUpCombo(ref cboInvType, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.InvoiceTerms, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboInvType = cboInvType;
      ComboBox cboPaidBy = this.cboPaidBy;
      Combo.SetUpCombo(ref cboPaidBy, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Locations | FSM.Entity.Sys.Enums.PickListTypes.Symptoms, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboPaidBy = cboPaidBy;
      ComboBox cboEngineer = this.cboEngineer;
      Combo.SetUpCombo(ref cboEngineer, this.dtEngineerGetAll, "EngineerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Not_Applicable);
      this.cboEngineer = cboEngineer;
      ComboBox cboOutcome = this.cboOutcome;
      Combo.SetUpCombo(ref cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboOutcome = cboOutcome;
      ComboBox installationTightnessTest = this.cboGasInstallationTightnessTest;
      Combo.SetUpCombo(ref installationTightnessTest, this.dtPassFailNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboGasInstallationTightnessTest = installationTightnessTest;
      ComboBox controlAccessible = this.cboEmergencyControlAccessible;
      Combo.SetUpCombo(ref controlAccessible, this.dtPassFailNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboEmergencyControlAccessible = controlAccessible;
      ComboBox cboBonding = this.cboBonding;
      Combo.SetUpCombo(ref cboBonding, this.dtPassFailNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboBonding = cboBonding;
      ComboBox cboPropertyRented = this.cboPropertyRented;
      Combo.SetUpCombo(ref cboPropertyRented, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboPropertyRented = cboPropertyRented;
      ComboBox cboPaymentMethod = this.cboPaymentMethod;
      Combo.SetUpCombo(ref cboPaymentMethod, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.PaymentMethods, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboPaymentMethod = cboPaymentMethod;
      ComboBox signatureSelected = this.cboSignatureSelected;
      Combo.SetUpCombo(ref signatureSelected, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Signature, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboSignatureSelected = signatureSelected;
      ComboBox cboQcAppliance = this.cboQCAppliance;
      Combo.SetUpCombo(ref cboQcAppliance, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCAppliance = cboQcAppliance;
      ComboBox cboQcCustSig = this.cboQCCustSig;
      Combo.SetUpCombo(ref cboQcCustSig, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCCustSig = cboQcCustSig;
      ComboBox qcCustomerDetails = this.cboQCCustomerDetails;
      Combo.SetUpCombo(ref qcCustomerDetails, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCCustomerDetails = qcCustomerDetails;
      ComboBox engineerPaymentRecieved = this.cboQCEngineerPaymentRecieved;
      Combo.SetUpCombo(ref engineerPaymentRecieved, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCEngineerPaymentRecieved = engineerPaymentRecieved;
      ComboBox cboQcJobType = this.cboQCJobType;
      Combo.SetUpCombo(ref cboQcJobType, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCJobType = cboQcJobType;
      ComboBox jobUploadTimescale = this.cboQCJobUploadTimescale;
      Combo.SetUpCombo(ref jobUploadTimescale, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCJobUploadTimescale = jobUploadTimescale;
      ComboBox cboQcLabourTime = this.cboQCLabourTime;
      Combo.SetUpCombo(ref cboQcLabourTime, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCLabourTime = cboQcLabourTime;
      ComboBox cboQclgsr = this.cboQCLGSR;
      Combo.SetUpCombo(ref cboQclgsr, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCLGSR = cboQclgsr;
      ComboBox cboQcOrderNo = this.cboQCOrderNo;
      Combo.SetUpCombo(ref cboQcOrderNo, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCOrderNo = cboQcOrderNo;
      ComboBox cboQcParts = this.cboQCParts;
      Combo.SetUpCombo(ref cboQcParts, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCParts = cboQcParts;
      ComboBox paymentCollection = this.cboQCPaymentCollection;
      Combo.SetUpCombo(ref paymentCollection, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCPaymentCollection = paymentCollection;
      ComboBox cboQcPaymentMethod = this.cboQCPaymentMethod;
      Combo.SetUpCombo(ref cboQcPaymentMethod, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCPaymentMethod = cboQcPaymentMethod;
      ComboBox paymentSelection = this.cboQCPaymentSelection;
      Combo.SetUpCombo(ref paymentSelection, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCPaymentSelection = paymentSelection;
      ComboBox qcScheduleOfRate = this.cboQCScheduleOfRate;
      Combo.SetUpCombo(ref qcScheduleOfRate, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQCScheduleOfRate = qcScheduleOfRate;
      ComboBox cboRecall = this.cboRecall;
      Combo.SetUpCombo(ref cboRecall, this.dtYesNo, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboRecall = cboRecall;
      ComboBox cboRecallEngineer = this.cboRecallEngineer;
      Combo.SetUpCombo(ref cboRecallEngineer, this.dtEngineerGetAll, "EngineerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboRecallEngineer = cboRecallEngineer;
      ComboBox cboFtfCode = this.cboFTFCode;
      Combo.SetUpCombo(ref cboFtfCode, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.FTFCodes, false).Table, "ManagerID", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboFTFCode = cboFtfCode;
      ComboBox cboVatRate = this.cboVATRate;
      Combo.SetUpCombo(ref cboVatRate, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboVATRate = cboVatRate;
      ComboBox correctMaterialsUsedId = this.cboCorrectMaterialsUsedID;
      Combo.SetUpCombo(ref correctMaterialsUsedId, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboCorrectMaterialsUsedID = correctMaterialsUsedId;
      ComboBox pipeWorkCorrectId = this.cboInstallationPipeWorkCorrectID;
      Combo.SetUpCombo(ref pipeWorkCorrectId, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboInstallationPipeWorkCorrectID = pipeWorkCorrectId;
      ComboBox installationSafeToUseId = this.cboInstallationSafeToUseID;
      Combo.SetUpCombo(ref installationSafeToUseId, this.dtYesNo, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboInstallationSafeToUseID = installationSafeToUseId;
      ComboBox strainerFittedId = this.cboStrainerFittedID;
      Combo.SetUpCombo(ref strainerFittedId, this.dtYesNo, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboStrainerFittedID = strainerFittedId;
      ComboBox strainerInspectedId = this.cboStrainerInspectedID;
      Combo.SetUpCombo(ref strainerInspectedId, this.dtYesNo, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboStrainerInspectedID = strainerInspectedId;
      ComboBox heatingSystemTypeId = this.cboHeatingSystemTypeID;
      Combo.SetUpCombo(ref heatingSystemTypeId, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.HeatingSystemType, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboHeatingSystemTypeID = heatingSystemTypeId;
      ComboBox partialHeatingId = this.cboPartialHeatingID;
      Combo.SetUpCombo(ref partialHeatingId, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboPartialHeatingID = partialHeatingId;
      ComboBox cboCylinderTypeId = this.cboCylinderTypeID;
      Combo.SetUpCombo(ref cboCylinderTypeId, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.CylinderType, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboCylinderTypeID = cboCylinderTypeId;
      ComboBox certificateTypeId = this.cboCertificateTypeID;
      Combo.SetUpCombo(ref certificateTypeId, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.CertificateType, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboCertificateTypeID = certificateTypeId;
      ComboBox cboJacketId = this.cboJacketID;
      Combo.SetUpCombo(ref cboJacketId, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Jacket, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboJacketID = cboJacketId;
      ComboBox cboImmersionId = this.cboImmersionID;
      Combo.SetUpCombo(ref cboImmersionId, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboImmersionID = cboImmersionId;
      ComboBox detectorFittedId = this.cboCODetectorFittedID;
      Combo.SetUpCombo(ref detectorFittedId, this.dtYesNo, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboCODetectorFittedID = detectorFittedId;
      ComboBox cboFillDisc = this.cboFillDisc;
      Combo.SetUpCombo(ref cboFillDisc, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboFillDisc = cboFillDisc;
      ComboBox cboSiTimer = this.cboSITimer;
      Combo.SetUpCombo(ref cboSiTimer, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboSITimer = cboSiTimer;
      ComboBox inspectionSatisfactoryId = this.cboVisualInspectionSatisfactoryID;
      Combo.SetUpCombo(ref inspectionSatisfactoryId, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboVisualInspectionSatisfactoryID = inspectionSatisfactoryId;
      ComboBox cboRecharge = this.cboRecharge;
      Combo.SetUpCombo(ref cboRecharge, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Recharge, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboRecharge = cboRecharge;
      ComboBox cboNccRad = this.cboNccRad;
      Combo.SetUpCombo(ref cboNccRad, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.NccRad, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboNccRad = cboNccRad;
      ComboBox cboMeterLocation = this.cboMeterLocation;
      Combo.SetUpCombo(ref cboMeterLocation, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.MeterLocation, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboMeterLocation = cboMeterLocation;
      ComboBox cboMeterCapped = this.cboMeterCapped;
      Combo.SetUpCombo(ref cboMeterCapped, this.dtYesNoNA, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboMeterCapped = cboMeterCapped;
      if (true == App.IsGasway)
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
      else
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl tcWorkSheet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpMainDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpPartsAndProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpTimesheets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtScheduledTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpTimesheets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotesFromEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOutcome
    {
      get
      {
        return this._cboOutcome;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboOutcome_SelectedIndexChanged);
        ComboBox cboOutcome1 = this._cboOutcome;
        if (cboOutcome1 != null)
          cboOutcome1.SelectedIndexChanged -= eventHandler;
        this._cboOutcome = value;
        ComboBox cboOutcome2 = this._cboOutcome;
        if (cboOutcome2 == null)
          return;
        cboOutcome2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtOutcomeDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtUploadedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotesToEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ContextMenu mnuAddChecklist { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobItems
    {
      get
      {
        return this._dgJobItems;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgJobItems_CurrentCellChanged);
        DataGrid dgJobItems1 = this._dgJobItems;
        if (dgJobItems1 != null)
          dgJobItems1.CurrentCellChanged -= eventHandler;
        this._dgJobItems = value;
        DataGrid dgJobItems2 = this._dgJobItems;
        if (dgJobItems2 == null)
          return;
        dgJobItems2.CurrentCellChanged += eventHandler;
      }
    }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartsAndProductsUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNameUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemovePartProductUsed
    {
      get
      {
        return this._btnRemovePartProductUsed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemovePartProduct_Click);
        Button removePartProductUsed1 = this._btnRemovePartProductUsed;
        if (removePartProductUsed1 != null)
          removePartProductUsed1.Click -= eventHandler;
        this._btnRemovePartProductUsed = value;
        Button removePartProductUsed2 = this._btnRemovePartProductUsed;
        if (removePartProductUsed2 == null)
          return;
        removePartProductUsed2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindProductUsed
    {
      get
      {
        return this._btnFindProductUsed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindProduct_Click);
        Button btnFindProductUsed1 = this._btnFindProductUsed;
        if (btnFindProductUsed1 != null)
          btnFindProductUsed1.Click -= eventHandler;
        this._btnFindProductUsed = value;
        Button btnFindProductUsed2 = this._btnFindProductUsed;
        if (btnFindProductUsed2 == null)
          return;
        btnFindProductUsed2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindPartUsed
    {
      get
      {
        return this._btnFindPartUsed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindPart_Click);
        Button btnFindPartUsed1 = this._btnFindPartUsed;
        if (btnFindPartUsed1 != null)
          btnFindPartUsed1.Click -= eventHandler;
        this._btnFindPartUsed = value;
        Button btnFindPartUsed2 = this._btnFindPartUsed;
        if (btnFindPartUsed2 == null)
          return;
        btnFindPartUsed2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddPartProductUsed
    {
      get
      {
        return this._btnAddPartProductUsed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddPartProduct_Click);
        Button addPartProductUsed1 = this._btnAddPartProductUsed;
        if (addPartProductUsed1 != null)
          addPartProductUsed1.Click -= eventHandler;
        this._btnAddPartProductUsed = value;
        Button addPartProductUsed2 = this._btnAddPartProductUsed;
        if (addPartProductUsed2 == null)
          return;
        addPartProductUsed2.Click += eventHandler;
      }
    }

    internal virtual NumericUpDown nudQuantityUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNumberUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddTimeSheet
    {
      get
      {
        return this._btnAddTimeSheet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddTimeSheet_Click);
        Button btnAddTimeSheet1 = this._btnAddTimeSheet;
        if (btnAddTimeSheet1 != null)
          btnAddTimeSheet1.Click -= eventHandler;
        this._btnAddTimeSheet = value;
        Button btnAddTimeSheet2 = this._btnAddTimeSheet;
        if (btnAddTimeSheet2 == null)
          return;
        btnAddTimeSheet2.Click += eventHandler;
      }
    }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveTimeSheet
    {
      get
      {
        return this._btnRemoveTimeSheet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveTimeSheet_Click);
        Button btnRemoveTimeSheet1 = this._btnRemoveTimeSheet;
        if (btnRemoveTimeSheet1 != null)
          btnRemoveTimeSheet1.Click -= eventHandler;
        this._btnRemoveTimeSheet = value;
        Button btnRemoveTimeSheet2 = this._btnRemoveTimeSheet;
        if (btnRemoveTimeSheet2 == null)
          return;
        btnRemoveTimeSheet2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgTimeSheets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpStartDate
    {
      get
      {
        return this._dtpStartDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpStartDate_ValueChanged);
        DateTimePicker dtpStartDate1 = this._dtpStartDate;
        if (dtpStartDate1 != null)
          dtpStartDate1.ValueChanged -= eventHandler;
        this._dtpStartDate = value;
        DateTimePicker dtpStartDate2 = this._dtpStartDate;
        if (dtpStartDate2 == null)
          return;
        dtpStartDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTimeSheetType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbScheduleOfRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbTimesheets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbAdditionalCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbPartsAndProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgScheduleOfRateCharges
    {
      get
      {
        return this._dgScheduleOfRateCharges;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgScheduleOfRateCharges_MouseUp);
        DataGrid scheduleOfRateCharges1 = this._dgScheduleOfRateCharges;
        if (scheduleOfRateCharges1 != null)
          scheduleOfRateCharges1.MouseUp -= mouseEventHandler;
        this._dgScheduleOfRateCharges = value;
        DataGrid scheduleOfRateCharges2 = this._dgScheduleOfRateCharges;
        if (scheduleOfRateCharges2 == null)
          return;
        scheduleOfRateCharges2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual TextBox txtScheduleOfRatesTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTimesheetTotal
    {
      get
      {
        return this._txtTimesheetTotal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtTimesheetTotal_Leave);
        TextBox txtTimesheetTotal1 = this._txtTimesheetTotal;
        if (txtTimesheetTotal1 != null)
          txtTimesheetTotal1.Leave -= eventHandler;
        this._txtTimesheetTotal = value;
        TextBox txtTimesheetTotal2 = this._txtTimesheetTotal;
        if (txtTimesheetTotal2 == null)
          return;
        txtTimesheetTotal2.Leave += eventHandler;
      }
    }

    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgTimesheetCharges
    {
      get
      {
        return this._dgTimesheetCharges;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgTimesheetCharges_MouseUp);
        DataGrid timesheetCharges1 = this._dgTimesheetCharges;
        if (timesheetCharges1 != null)
          timesheetCharges1.MouseUp -= mouseEventHandler;
        this._dgTimesheetCharges = value;
        DataGrid timesheetCharges2 = this._dgTimesheetCharges;
        if (timesheetCharges2 == null)
          return;
        timesheetCharges2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAdditionalChargeDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveAdditionalCharge
    {
      get
      {
        return this._btnRemoveAdditionalCharge;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveAdditionalCharge_Click);
        Button additionalCharge1 = this._btnRemoveAdditionalCharge;
        if (additionalCharge1 != null)
          additionalCharge1.Click -= eventHandler;
        this._btnRemoveAdditionalCharge = value;
        Button additionalCharge2 = this._btnRemoveAdditionalCharge;
        if (additionalCharge2 == null)
          return;
        additionalCharge2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddAdditionalCharge
    {
      get
      {
        return this._btnAddAdditionalCharge;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddAdditionalCharge_Click);
        Button additionalCharge1 = this._btnAddAdditionalCharge;
        if (additionalCharge1 != null)
          additionalCharge1.Click -= eventHandler;
        this._btnAddAdditionalCharge = value;
        Button additionalCharge2 = this._btnAddAdditionalCharge;
        if (additionalCharge2 == null)
          return;
        additionalCharge2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartsProductCharging
    {
      get
      {
        return this._dgPartsProductCharging;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgPartsProductCharging_MouseUp);
        DataGrid partsProductCharging1 = this._dgPartsProductCharging;
        if (partsProductCharging1 != null)
          partsProductCharging1.MouseUp -= mouseEventHandler;
        this._dgPartsProductCharging = value;
        DataGrid partsProductCharging2 = this._dgPartsProductCharging;
        if (partsProductCharging2 == null)
          return;
        partsProductCharging2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual TextBox txtAdditionalChargeTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAdditionalCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAdditionalCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxVisitLockDown
    {
      get
      {
        return this._cbxVisitLockDown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbxVisitLockDown_CheckedChanged);
        CheckBox cbxVisitLockDown1 = this._cbxVisitLockDown;
        if (cbxVisitLockDown1 != null)
          cbxVisitLockDown1.CheckedChanged -= eventHandler;
        this._cbxVisitLockDown = value;
        CheckBox cbxVisitLockDown2 = this._cbxVisitLockDown;
        if (cbxVisitLockDown2 == null)
          return;
        cbxVisitLockDown2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label lblSellPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStatusWarning { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rdoJobValue
    {
      get
      {
        return this._rdoJobValue;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoJobValue_CheckedChanged);
        RadioButton rdoJobValue1 = this._rdoJobValue;
        if (rdoJobValue1 != null)
          rdoJobValue1.CheckedChanged -= eventHandler;
        this._rdoJobValue = value;
        RadioButton rdoJobValue2 = this._rdoJobValue;
        if (rdoJobValue2 == null)
          return;
        rdoJobValue2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rdoChargeOther
    {
      get
      {
        return this._rdoChargeOther;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoChargeOther_CheckedChanged);
        RadioButton rdoChargeOther1 = this._rdoChargeOther;
        if (rdoChargeOther1 != null)
          rdoChargeOther1.CheckedChanged -= eventHandler;
        this._rdoChargeOther = value;
        RadioButton rdoChargeOther2 = this._rdoChargeOther;
        if (rdoChargeOther2 == null)
          return;
        rdoChargeOther2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtPercentOfQuote
    {
      get
      {
        return this._txtPercentOfQuote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPercentOfQuote_TextChanged);
        TextBox txtPercentOfQuote1 = this._txtPercentOfQuote;
        if (txtPercentOfQuote1 != null)
          txtPercentOfQuote1.TextChanged -= eventHandler;
        this._txtPercentOfQuote = value;
        TextBox txtPercentOfQuote2 = this._txtPercentOfQuote;
        if (txtPercentOfQuote2 == null)
          return;
        txtPercentOfQuote2.TextChanged += eventHandler;
      }
    }

    internal virtual RadioButton rdoPercentageOfQuoteValue
    {
      get
      {
        return this._rdoPercentageOfQuoteValue;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoPercentageOfQuoteValue_CheckedChanged);
        RadioButton percentageOfQuoteValue1 = this._rdoPercentageOfQuoteValue;
        if (percentageOfQuoteValue1 != null)
          percentageOfQuoteValue1.CheckedChanged -= eventHandler;
        this._rdoPercentageOfQuoteValue = value;
        RadioButton percentageOfQuoteValue2 = this._rdoPercentageOfQuoteValue;
        if (percentageOfQuoteValue2 == null)
          return;
        percentageOfQuoteValue2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label lblPercent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbInvoice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxReadyToBeInvoiced
    {
      get
      {
        return this._cbxReadyToBeInvoiced;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbxReadyToBeInvoiced_CheckedChanged);
        CheckBox readyToBeInvoiced1 = this._cbxReadyToBeInvoiced;
        if (readyToBeInvoiced1 != null)
          readyToBeInvoiced1.CheckedChanged -= eventHandler;
        this._cbxReadyToBeInvoiced = value;
        CheckBox readyToBeInvoiced2 = this._cbxReadyToBeInvoiced;
        if (readyToBeInvoiced2 == null)
          return;
        readyToBeInvoiced2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEquals { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuotePercentageTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRaiseInvoiceOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpRaiseInvoiceOn
    {
      get
      {
        return this._dtpRaiseInvoiceOn;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpRaiseInvoiceOn_ValueChanged);
        DateTimePicker dtpRaiseInvoiceOn1 = this._dtpRaiseInvoiceOn;
        if (dtpRaiseInvoiceOn1 != null)
          dtpRaiseInvoiceOn1.ValueChanged -= eventHandler;
        this._dtpRaiseInvoiceOn = value;
        DateTimePicker dtpRaiseInvoiceOn2 = this._dtpRaiseInvoiceOn;
        if (dtpRaiseInvoiceOn2 == null)
          return;
        dtpRaiseInvoiceOn2.ValueChanged += eventHandler;
      }
    }

    internal virtual TextBox txtEngineerCostTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOrders
    {
      get
      {
        return this._btnOrders;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOrders_Click);
        Button btnOrders1 = this._btnOrders;
        if (btnOrders1 != null)
          btnOrders1.Click -= eventHandler;
        this._btnOrders = value;
        Button btnOrders2 = this._btnOrders;
        if (btnOrders2 == null)
          return;
        btnOrders2.Click += eventHandler;
      }
    }

    internal virtual Button btnInvoice
    {
      get
      {
        return this._btnInvoice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnInvoice_Click);
        Button btnInvoice1 = this._btnInvoice;
        if (btnInvoice1 != null)
          btnInvoice1.Click -= eventHandler;
        this._btnInvoice = value;
        Button btnInvoice2 = this._btnInvoice;
        if (btnInvoice2 == null)
          return;
        btnInvoice2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpAllocated { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartsProductsAllocated
    {
      get
      {
        return this._dgPartsProductsAllocated;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgPartsProductsAllocated_Click);
        DataGrid productsAllocated1 = this._dgPartsProductsAllocated;
        if (productsAllocated1 != null)
          productsAllocated1.Click -= eventHandler;
        this._dgPartsProductsAllocated = value;
        DataGrid productsAllocated2 = this._dgPartsProductsAllocated;
        if (productsAllocated2 == null)
          return;
        productsAllocated2.Click += eventHandler;
      }
    }

    internal virtual Button btnAllocatedNotUsed
    {
      get
      {
        return this._btnAllocatedNotUsed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAllocatedNotUsed_Click);
        Button allocatedNotUsed1 = this._btnAllocatedNotUsed;
        if (allocatedNotUsed1 != null)
          allocatedNotUsed1.Click -= eventHandler;
        this._btnAllocatedNotUsed = value;
        Button allocatedNotUsed2 = this._btnAllocatedNotUsed;
        if (allocatedNotUsed2 == null)
          return;
        allocatedNotUsed2.Click += eventHandler;
      }
    }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label35 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAllUsed
    {
      get
      {
        return this._btnAllUsed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAllUsed_Click);
        Button btnAllUsed1 = this._btnAllUsed;
        if (btnAllUsed1 != null)
          btnAllUsed1.Click -= eventHandler;
        this._btnAllUsed = value;
        Button btnAllUsed2 = this._btnAllUsed;
        if (btnAllUsed2 == null)
          return;
        btnAllUsed2.Click += eventHandler;
      }
    }

    internal virtual Label lblContractPerVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPrint
    {
      get
      {
        return this._btnPrint;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrint_Click);
        Button btnPrint1 = this._btnPrint;
        if (btnPrint1 != null)
          btnPrint1.Click -= eventHandler;
        this._btnPrint = value;
        Button btnPrint2 = this._btnPrint;
        if (btnPrint2 == null)
          return;
        btnPrint2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddSoR
    {
      get
      {
        return this._btnAddSoR;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddSoR_Click);
        Button btnAddSoR1 = this._btnAddSoR;
        if (btnAddSoR1 != null)
          btnAddSoR1.Click -= eventHandler;
        this._btnAddSoR = value;
        Button btnAddSoR2 = this._btnAddSoR;
        if (btnAddSoR2 == null)
          return;
        btnAddSoR2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCurrentContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label39 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSearch
    {
      get
      {
        return this._btnSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearch_Click);
        Button btnSearch1 = this._btnSearch;
        if (btnSearch1 != null)
          btnSearch1.Click -= eventHandler;
        this._btnSearch = value;
        Button btnSearch2 = this._btnSearch;
        if (btnSearch2 == null)
          return;
        btnSearch2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpWorksheets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVisitWorksheet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label40 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label41 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboGasInstallationTightnessTest { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEmergencyControlAccessible { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboBonding { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPropertyRented { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSignatureSelected { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label42 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label43 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label44 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaymentMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAmountCollected { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpApplianceWorksheet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVisitDefects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgApplianceWorkSheets
    {
      get
      {
        return this._dgApplianceWorkSheets;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgApplianceWorkSheets_DoubleClick);
        DataGrid applianceWorkSheets1 = this._dgApplianceWorkSheets;
        if (applianceWorkSheets1 != null)
          applianceWorkSheets1.DoubleClick -= eventHandler;
        this._dgApplianceWorkSheets = value;
        DataGrid applianceWorkSheets2 = this._dgApplianceWorkSheets;
        if (applianceWorkSheets2 == null)
          return;
        applianceWorkSheets2.DoubleClick += eventHandler;
      }
    }

    internal virtual DataGrid dgVisitDefects
    {
      get
      {
        return this._dgVisitDefects;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgVisitDefects_DoubleClick);
        DataGrid dgVisitDefects1 = this._dgVisitDefects;
        if (dgVisitDefects1 != null)
          dgVisitDefects1.DoubleClick -= eventHandler;
        this._dgVisitDefects = value;
        DataGrid dgVisitDefects2 = this._dgVisitDefects;
        if (dgVisitDefects2 == null)
          return;
        dgVisitDefects2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnRemoveVisitDefect
    {
      get
      {
        return this._btnRemoveVisitDefect;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveVisitDefect_Click);
        Button removeVisitDefect1 = this._btnRemoveVisitDefect;
        if (removeVisitDefect1 != null)
          removeVisitDefect1.Click -= eventHandler;
        this._btnRemoveVisitDefect = value;
        Button removeVisitDefect2 = this._btnRemoveVisitDefect;
        if (removeVisitDefect2 == null)
          return;
        removeVisitDefect2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddVisitDefect
    {
      get
      {
        return this._btnAddVisitDefect;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddVisitDefect_Click);
        Button btnAddVisitDefect1 = this._btnAddVisitDefect;
        if (btnAddVisitDefect1 != null)
          btnAddVisitDefect1.Click -= eventHandler;
        this._btnAddVisitDefect = value;
        Button btnAddVisitDefect2 = this._btnAddVisitDefect;
        if (btnAddVisitDefect2 == null)
          return;
        btnAddVisitDefect2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveApplianceWorkSheet
    {
      get
      {
        return this._btnRemoveApplianceWorkSheet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveApplianceWorkSheet_Click);
        Button applianceWorkSheet1 = this._btnRemoveApplianceWorkSheet;
        if (applianceWorkSheet1 != null)
          applianceWorkSheet1.Click -= eventHandler;
        this._btnRemoveApplianceWorkSheet = value;
        Button applianceWorkSheet2 = this._btnRemoveApplianceWorkSheet;
        if (applianceWorkSheet2 == null)
          return;
        applianceWorkSheet2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip PrintMenu { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem mnuGasSafetyInspectionBoilerServiceRecord { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceAddressDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominalCode
    {
      get
      {
        return this._txtNominalCode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtNominalCode_TextChanged);
        TextBox txtNominalCode1 = this._txtNominalCode;
        if (txtNominalCode1 != null)
          txtNominalCode1.TextChanged -= eventHandler;
        this._txtNominalCode = value;
        TextBox txtNominalCode2 = this._txtNominalCode;
        if (txtNominalCode2 == null)
          return;
        txtNominalCode2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblNominalCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPrintGSR
    {
      get
      {
        return this._btnPrintGSR;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintGSR_Click);
        Button btnPrintGsr1 = this._btnPrintGSR;
        if (btnPrintGsr1 != null)
          btnPrintGsr1.Click -= eventHandler;
        this._btnPrintGSR = value;
        Button btnPrintGsr2 = this._btnPrintGSR;
        if (btnPrintGsr2 == null)
          return;
        btnPrintGsr2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpAppliances { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpAppliances { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpOutcomes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkGasServiceCompleted { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpOutcomes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPrintSVR
    {
      get
      {
        return this._btnPrintSVR;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintSVR_Click);
        Button btnPrintSvr1 = this._btnPrintSVR;
        if (btnPrintSvr1 != null)
          btnPrintSvr1.Click -= eventHandler;
        this._btnPrintSVR = value;
        Button btnPrintSvr2 = this._btnPrintSVR;
        if (btnPrintSvr2 == null)
          return;
        btnPrintSvr2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpQC { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxEmailReceiptToCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccountCode
    {
      get
      {
        return this._txtAccountCode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtAccountCode_TextChanged);
        TextBox txtAccountCode1 = this._txtAccountCode;
        if (txtAccountCode1 != null)
          txtAccountCode1.TextChanged -= eventHandler;
        this._txtAccountCode = value;
        TextBox txtAccountCode2 = this._txtAccountCode;
        if (txtAccountCode2 == null)
          return;
        txtAccountCode2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblAccountCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnJob
    {
      get
      {
        return this._btnJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnJob_Click);
        Button btnJob1 = this._btnJob;
        if (btnJob1 != null)
          btnJob1.Click -= eventHandler;
        this._btnJob = value;
        Button btnJob2 = this._btnJob;
        if (btnJob2 == null)
          return;
        btnJob2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtPriceIncVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPriceInvVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual NumericUpDown nudPartAllocatedQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAllocatedQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox pbCustomerSignature { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox pbEngineerSignature { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVisitWorksheetExtended { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStrainerInspectedID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label57 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStrainerFittedID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInstallationSafeToUseID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInstallationPipeWorkCorrectID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCorrectMaterialsUsedID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label58 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label59 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label60 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label61 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVisualInspectionReason { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label68 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label69 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label70 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label62 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label63 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label64 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label65 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label66 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label67 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCertificateTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCODetectorFittedID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboImmersionID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJacketID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCylinderTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPartialHeatingID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboHeatingSystemTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtApproxAgeOfBoiler { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label56 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkRecharge
    {
      get
      {
        return this._chkRecharge;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkRecharge_CheckedChanged);
        CheckBox chkRecharge1 = this._chkRecharge;
        if (chkRecharge1 != null)
          chkRecharge1.CheckedChanged -= eventHandler;
        this._chkRecharge = value;
        CheckBox chkRecharge2 = this._chkRecharge;
        if (chkRecharge2 == null)
          return;
        chkRecharge2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtRadiators { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisualInspectionSatisfactoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRechargeTicked { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnChangeOutcome
    {
      get
      {
        return this._btnChangeOutcome;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnChangeOutcome_Click);
        Button btnChangeOutcome1 = this._btnChangeOutcome;
        if (btnChangeOutcome1 != null)
          btnChangeOutcome1.Click -= eventHandler;
        this._btnChangeOutcome = value;
        Button btnChangeOutcome2 = this._btnChangeOutcome;
        if (btnChangeOutcome2 == null)
          return;
        btnChangeOutcome2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtScheduledTime2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label71 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnShowVisits
    {
      get
      {
        return this._btnShowVisits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnShowVisits_Click);
        Button btnShowVisits1 = this._btnShowVisits;
        if (btnShowVisits1 != null)
          btnShowVisits1.Click -= eventHandler;
        this._btnShowVisits = value;
        Button btnShowVisits2 = this._btnShowVisits;
        if (btnShowVisits2 == null)
          return;
        btnShowVisits2.Click += eventHandler;
      }
    }

    internal virtual RadioButton CostsToOption3
    {
      get
      {
        return this._CostsToOption3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radioButtonCostsTo_CheckedChanged);
        RadioButton costsToOption3_1 = this._CostsToOption3;
        if (costsToOption3_1 != null)
          costsToOption3_1.CheckedChanged -= eventHandler;
        this._CostsToOption3 = value;
        RadioButton costsToOption3_2 = this._CostsToOption3;
        if (costsToOption3_2 == null)
          return;
        costsToOption3_2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton CostsToOption2
    {
      get
      {
        return this._CostsToOption2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radioButtonCostsTo_CheckedChanged);
        RadioButton costsToOption2_1 = this._CostsToOption2;
        if (costsToOption2_1 != null)
          costsToOption2_1.CheckedChanged -= eventHandler;
        this._CostsToOption2 = value;
        RadioButton costsToOption2_2 = this._CostsToOption2;
        if (costsToOption2_2 == null)
          return;
        costsToOption2_2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton CostsToOption1
    {
      get
      {
        return this._CostsToOption1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radioButtonCostsTo_CheckedChanged);
        RadioButton costsToOption1_1 = this._CostsToOption1;
        if (costsToOption1_1 != null)
          costsToOption1_1.CheckedChanged -= eventHandler;
        this._CostsToOption1 = value;
        RadioButton costsToOption1_2 = this._CostsToOption1;
        if (costsToOption1_2 == null)
          return;
        costsToOption1_2.CheckedChanged += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAlarmInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpPhotos
    {
      get
      {
        return this._tpPhotos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tpPhotos_Enter);
        TabPage tpPhotos1 = this._tpPhotos;
        if (tpPhotos1 != null)
          tpPhotos1.Enter -= eventHandler;
        this._tpPhotos = value;
        TabPage tpPhotos2 = this._tpPhotos;
        if (tpPhotos2 == null)
          return;
        tpPhotos2.Enter += eventHandler;
      }
    }

    internal virtual FlowLayoutPanel flPhotos { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFTFCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label74 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAdditional
    {
      get
      {
        return this._dgAdditional;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgAdditionalWorkSheets_DoubleClick);
        DataGrid dgAdditional1 = this._dgAdditional;
        if (dgAdditional1 != null)
          dgAdditional1.DoubleClick -= eventHandler;
        this._dgAdditional = value;
        DataGrid dgAdditional2 = this._dgAdditional;
        if (dgAdditional2 == null)
          return;
        dgAdditional2.DoubleClick += eventHandler;
      }
    }

    internal virtual ComboBox cboRecharge
    {
      get
      {
        return this._cboRecharge;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboRecharge_SelectedIndexChanged);
        ComboBox cboRecharge1 = this._cboRecharge;
        if (cboRecharge1 != null)
          cboRecharge1.SelectedIndexChanged -= eventHandler;
        this._cboRecharge = value;
        ComboBox cboRecharge2 = this._cboRecharge;
        if (cboRecharge2 == null)
          return;
        cboRecharge2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label75 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboNccRad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label76 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripPanel BottomToolStripPanel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripPanel TopToolStripPanel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripPanel RightToolStripPanel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripPanel LeftToolStripPanel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripContentPanel ContentPanel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSITimer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFillDisc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label81 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label80 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label79 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCustEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEditInvoiceNotes
    {
      get
      {
        return this._btnEditInvoiceNotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEditInvoiceNotes_Click);
        Button editInvoiceNotes1 = this._btnEditInvoiceNotes;
        if (editInvoiceNotes1 != null)
          editInvoiceNotes1.Click -= eventHandler;
        this._btnEditInvoiceNotes = value;
        Button editInvoiceNotes2 = this._btnEditInvoiceNotes;
        if (editInvoiceNotes2 == null)
          return;
        editInvoiceNotes2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboVATRate
    {
      get
      {
        return this._cboVATRate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboVATRate_SelectedIndexChanged);
        ComboBox cboVatRate1 = this._cboVATRate;
        if (cboVatRate1 != null)
          cboVatRate1.SelectedIndexChanged -= eventHandler;
        this._cboVATRate = value;
        ComboBox cboVatRate2 = this._cboVATRate;
        if (cboVatRate2 == null)
          return;
        cboVatRate2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaidBy
    {
      get
      {
        return this._cboPaidBy;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPaidBy_SelectedIndexChanged);
        ComboBox cboPaidBy1 = this._cboPaidBy;
        if (cboPaidBy1 != null)
          cboPaidBy1.SelectedIndexChanged -= eventHandler;
        this._cboPaidBy = value;
        ComboBox cboPaidBy2 = this._cboPaidBy;
        if (cboPaidBy2 == null)
          return;
        cboPaidBy2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvType
    {
      get
      {
        return this._cboInvType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboInvType_SelectedIndexChanged);
        ComboBox cboInvType1 = this._cboInvType;
        if (cboInvType1 != null)
          cboInvType1.SelectedIndexChanged -= eventHandler;
        this._cboInvType = value;
        ComboBox cboInvType2 = this._cboInvType;
        if (cboInvType2 == null)
          return;
        cboInvType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblInvType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcredit
    {
      get
      {
        return this._lblcredit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lblcredit_Click);
        Label lblcredit1 = this._lblcredit;
        if (lblcredit1 != null)
          lblcredit1.Click -= eventHandler;
        this._lblcredit = value;
        Label lblcredit2 = this._lblcredit;
        if (lblcredit2 == null)
          return;
        lblcredit2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCreditAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCreateServ
    {
      get
      {
        return this._btnCreateServ;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreateServ_Click);
        Button btnCreateServ1 = this._btnCreateServ;
        if (btnCreateServ1 != null)
          btnCreateServ1.Click -= eventHandler;
        this._btnCreateServ = value;
        Button btnCreateServ2 = this._btnCreateServ;
        if (btnCreateServ2 == null)
          return;
        btnCreateServ2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkSORDesc
    {
      get
      {
        return this._chkSORDesc;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSORDesc_CheckedChanged);
        CheckBox chkSorDesc1 = this._chkSORDesc;
        if (chkSorDesc1 != null)
          chkSorDesc1.CheckedChanged -= eventHandler;
        this._chkSORDesc = value;
        CheckBox chkSorDesc2 = this._chkSORDesc;
        if (chkSorDesc2 == null)
          return;
        chkSorDesc2.CheckedChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpAdditionalWorksheet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveAdd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddAdd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid DGSmokeComo
    {
      get
      {
        return this._DGSmokeComo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgSmokeComoWorkSheets_DoubleClick);
        DataGrid dgSmokeComo1 = this._DGSmokeComo;
        if (dgSmokeComo1 != null)
          dgSmokeComo1.DoubleClick -= eventHandler;
        this._DGSmokeComo = value;
        DataGrid dgSmokeComo2 = this._DGSmokeComo;
        if (dgSmokeComo2 == null)
          return;
        dgSmokeComo2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnRemoveSmokeComo
    {
      get
      {
        return this._btnRemoveSmokeComo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveSmokeComo_Click);
        Button btnRemoveSmokeComo1 = this._btnRemoveSmokeComo;
        if (btnRemoveSmokeComo1 != null)
          btnRemoveSmokeComo1.Click -= eventHandler;
        this._btnRemoveSmokeComo = value;
        Button btnRemoveSmokeComo2 = this._btnRemoveSmokeComo;
        if (btnRemoveSmokeComo2 == null)
          return;
        btnRemoveSmokeComo2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddSmokeComo
    {
      get
      {
        return this._btnAddSmokeComo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddSmokeComo_Click);
        Button btnAddSmokeComo1 = this._btnAddSmokeComo;
        if (btnAddSmokeComo1 != null)
          btnAddSmokeComo1.Click -= eventHandler;
        this._btnAddSmokeComo = value;
        Button btnAddSmokeComo2 = this._btnAddSmokeComo;
        if (btnAddSmokeComo2 == null)
          return;
        btnAddSmokeComo2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip SVRs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem svrmenu
    {
      get
      {
        return this._svrmenu;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.svrmenu_Click);
        ToolStripMenuItem svrmenu1 = this._svrmenu;
        if (svrmenu1 != null)
          svrmenu1.Click -= eventHandler;
        this._svrmenu = value;
        ToolStripMenuItem svrmenu2 = this._svrmenu;
        if (svrmenu2 == null)
          return;
        svrmenu2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem JobSheetMenu
    {
      get
      {
        return this._JobSheetMenu;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.JobSheetMenu_Click);
        ToolStripMenuItem jobSheetMenu1 = this._JobSheetMenu;
        if (jobSheetMenu1 != null)
          jobSheetMenu1.Click -= eventHandler;
        this._JobSheetMenu = value;
        ToolStripMenuItem jobSheetMenu2 = this._JobSheetMenu;
        if (jobSheetMenu2 == null)
          return;
        jobSheetMenu2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem DomesticGSRToolStripMenuItem
    {
      get
      {
        return this._DomesticGSRToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.DomesticGSRToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._DomesticGSRToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._DomesticGSRToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._DomesticGSRToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem WarningNoticeToolStripMenuItem
    {
      get
      {
        return this._WarningNoticeToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.WarningNoticeToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._WarningNoticeToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._WarningNoticeToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._WarningNoticeToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem CommercialGSRToolStripMenuItem
    {
      get
      {
        return this._CommercialGSRToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CommercialGSRToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._CommercialGSRToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._CommercialGSRToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._CommercialGSRToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem QCResultsToolStripMenuItem
    {
      get
      {
        return this._QCResultsToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.QCResultsToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._QCResultsToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._QCResultsToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._QCResultsToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ElectricalMinorWorksToolStripMenuItem
    {
      get
      {
        return this._ElectricalMinorWorksToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ElectricalMinorWorksToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._ElectricalMinorWorksToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._ElectricalMinorWorksToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._ElectricalMinorWorksToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem AllGasPaperworkToolStripMenuItem
    {
      get
      {
        return this._AllGasPaperworkToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AllGasPaperworkToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._AllGasPaperworkToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._AllGasPaperworkToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._AllGasPaperworkToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem CommercialCateringToolStripMenuItem
    {
      get
      {
        return this._CommercialCateringToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CommercialCateringToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._CommercialCateringToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._CommercialCateringToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._CommercialCateringToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem SaffronUnventedWorkshhetToolStripMenuItem
    {
      get
      {
        return this._SaffronUnventedWorkshhetToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.SaffronUnventedWorkshhetToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._SaffronUnventedWorkshhetToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._SaffronUnventedWorkshhetToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._SaffronUnventedWorkshhetToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem PropertyMaintenanceWorksheetToolStripMenuItem
    {
      get
      {
        return this._PropertyMaintenanceWorksheetToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PropertyMaintenanceWorksheetToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._PropertyMaintenanceWorksheetToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._PropertyMaintenanceWorksheetToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._PropertyMaintenanceWorksheetToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ASHPWorksheetToolStripMenuItem
    {
      get
      {
        return this._ASHPWorksheetToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ASHPWorksheetToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._ASHPWorksheetToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._ASHPWorksheetToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._ASHPWorksheetToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboMeterCapped { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label73 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboMeterLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label72 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label82 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label78 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label77 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitPerc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCosts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSale { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDept
    {
      get
      {
        return this._cboDept;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboDept_SelectedIndexChanged);
        ComboBox cboDept1 = this._cboDept;
        if (cboDept1 != null)
          cboDept1.SelectedIndexChanged -= eventHandler;
        this._cboDept = value;
        ComboBox cboDept2 = this._cboDept;
        if (cboDept2 == null)
          return;
        cboDept2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkShowJobCharges
    {
      get
      {
        return this._chkShowJobCharges;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkShowJobCharges_CheckedChanged);
        CheckBox chkShowJobCharges1 = this._chkShowJobCharges;
        if (chkShowJobCharges1 != null)
          chkShowJobCharges1.CheckedChanged -= eventHandler;
        this._chkShowJobCharges = value;
        CheckBox chkShowJobCharges2 = this._chkShowJobCharges;
        if (chkShowJobCharges2 == null)
          return;
        chkShowJobCharges2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtPartProductCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPPTotalCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsProductTotal
    {
      get
      {
        return this._txtPartsProductTotal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartsProductTotal_Leave);
        TextBox partsProductTotal1 = this._txtPartsProductTotal;
        if (partsProductTotal1 != null)
          partsProductTotal1.Leave -= eventHandler;
        this._txtPartsProductTotal = value;
        TextBox partsProductTotal2 = this._txtPartsProductTotal;
        if (partsProductTotal2 == null)
          return;
        partsProductTotal2.Leave += eventHandler;
      }
    }

    internal virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbStandard { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuantityWarning { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRevertUsed
    {
      get
      {
        return this._btnRevertUsed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRevertUsed_Click);
        Button btnRevertUsed1 = this._btnRevertUsed;
        if (btnRevertUsed1 != null)
          btnRevertUsed1.Click -= eventHandler;
        this._btnRevertUsed = value;
        Button btnRevertUsed2 = this._btnRevertUsed;
        if (btnRevertUsed2 == null)
          return;
        btnRevertUsed2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpOfficeQC { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobTypeCorrect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpQCField { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCPoorJobNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCEngineerPaymentRecieved { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCEngineerMonies { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCPaymentSelection { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCEngPaymentMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCPaymentCollection { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCPaymentCollection { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCJobUploadTimescale { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobUploadTimescale { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCLGSR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCLGSR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCLabourTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCLabourTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCPaymentMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPaymentMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCOrderNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCScheduleOfRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblScheduleRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCCustomerDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomerDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQCDocumentsRecieved { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkQCDocumentsRecieved
    {
      get
      {
        return this._chkQCDocumentsRecieved;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkQCDocumentsRecieved_CheckedChanged);
        CheckBox documentsRecieved1 = this._chkQCDocumentsRecieved;
        if (documentsRecieved1 != null)
          documentsRecieved1.CheckedChanged -= eventHandler;
        this._chkQCDocumentsRecieved = value;
        CheckBox documentsRecieved2 = this._chkQCDocumentsRecieved;
        if (documentsRecieved2 == null)
          return;
        documentsRecieved2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtQCPoorJobNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUnselectAllPPA
    {
      get
      {
        return this._btnUnselectAllPPA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUnselectAllPPA_Click);
        Button btnUnselectAllPpa1 = this._btnUnselectAllPPA;
        if (btnUnselectAllPpa1 != null)
          btnUnselectAllPpa1.Click -= eventHandler;
        this._btnUnselectAllPPA = value;
        Button btnUnselectAllPpa2 = this._btnUnselectAllPPA;
        if (btnUnselectAllPpa2 == null)
          return;
        btnUnselectAllPpa2.Click += eventHandler;
      }
    }

    internal virtual Button btnSelectAllPPA
    {
      get
      {
        return this._btnSelectAllPPA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelectAllPPA_Click);
        Button btnSelectAllPpa1 = this._btnSelectAllPPA;
        if (btnSelectAllPpa1 != null)
          btnSelectAllPpa1.Click -= eventHandler;
        this._btnSelectAllPPA = value;
        Button btnSelectAllPpa2 = this._btnSelectAllPPA;
        if (btnSelectAllPpa2 == null)
          return;
        btnSelectAllPpa2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpSiteFuels { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSiteFuel
    {
      get
      {
        return this._dgSiteFuel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgSiteFuel_Click);
        DataGrid dgSiteFuel1 = this._dgSiteFuel;
        if (dgSiteFuel1 != null)
          dgSiteFuel1.Click -= eventHandler;
        this._dgSiteFuel = value;
        DataGrid dgSiteFuel2 = this._dgSiteFuel;
        if (dgSiteFuel2 == null)
          return;
        dgSiteFuel2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtActualTimeSpent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDifference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSORTimeAllowance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label52 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label51 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label50 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRecallEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label49 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRecall
    {
      get
      {
        return this._cboRecall;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboRecall_SelectedIndexChanged);
        ComboBox cboRecall1 = this._cboRecall;
        if (cboRecall1 != null)
          cboRecall1.SelectedIndexChanged -= eventHandler;
        this._cboRecall = value;
        ComboBox cboRecall2 = this._cboRecall;
        if (cboRecall2 == null)
          return;
        cboRecall2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label48 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQCCustSig { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQCCustSig { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem CommissioningChecklistToolStripMenuItem
    {
      get
      {
        return this._CommissioningChecklistToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CommissioningChecklistToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._CommissioningChecklistToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._CommissioningChecklistToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._CommissioningChecklistToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkPartsSelectAll
    {
      get
      {
        return this._chkPartsSelectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkPartsSelectAll_Click);
        CheckBox chkPartsSelectAll1 = this._chkPartsSelectAll;
        if (chkPartsSelectAll1 != null)
          chkPartsSelectAll1.Click -= eventHandler;
        this._chkPartsSelectAll = value;
        CheckBox chkPartsSelectAll2 = this._chkPartsSelectAll;
        if (chkPartsSelectAll2 == null)
          return;
        chkPartsSelectAll2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtPartsMarkUp
    {
      get
      {
        return this._txtPartsMarkUp;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartsMarkUp_Leave);
        TextBox txtPartsMarkUp1 = this._txtPartsMarkUp;
        if (txtPartsMarkUp1 != null)
          txtPartsMarkUp1.Leave -= eventHandler;
        this._txtPartsMarkUp = value;
        TextBox txtPartsMarkUp2 = this._txtPartsMarkUp;
        if (txtPartsMarkUp2 == null)
          return;
        txtPartsMarkUp2.Leave += eventHandler;
      }
    }

    internal virtual CheckBox chkTimesheetSelectAll
    {
      get
      {
        return this._chkTimesheetSelectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkTimesheetSelectAll_Click);
        CheckBox timesheetSelectAll1 = this._chkTimesheetSelectAll;
        if (timesheetSelectAll1 != null)
          timesheetSelectAll1.Click -= eventHandler;
        this._chkTimesheetSelectAll = value;
        CheckBox timesheetSelectAll2 = this._chkTimesheetSelectAll;
        if (timesheetSelectAll2 == null)
          return;
        timesheetSelectAll2.Click += eventHandler;
      }
    }

    internal virtual Label lblPartsMarkUp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAdditionalCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem HotWorksPermitToolStripMenuItem
    {
      get
      {
        return this._HotWorksPermitToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.HotWorksPermitToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._HotWorksPermitToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._HotWorksPermitToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._HotWorksPermitToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddApplianceWorksheet
    {
      get
      {
        return this._btnAddApplianceWorksheet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddApplianceWorksheet_Click);
        Button applianceWorksheet1 = this._btnAddApplianceWorksheet;
        if (applianceWorksheet1 != null)
          applianceWorksheet1.Click -= eventHandler;
        this._btnAddApplianceWorksheet = value;
        Button applianceWorksheet2 = this._btnAddApplianceWorksheet;
        if (applianceWorksheet2 == null)
          return;
        applianceWorksheet2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.tcWorkSheet = new TabControl();
      this.tpMainDetails = new TabPage();
      this.chkSORDesc = new CheckBox();
      this.btnEditInvoiceNotes = new Button();
      this.txtScheduledTime2 = new TextBox();
      this.Label71 = new Label();
      this.btnChangeOutcome = new Button();
      this.pbCustomerSignature = new PictureBox();
      this.pbEngineerSignature = new PictureBox();
      this.cbxEmailReceiptToCustomer = new CheckBox();
      this.cboSignatureSelected = new ComboBox();
      this.Label42 = new Label();
      this.dgJobItems = new DataGrid();
      this.Label12 = new Label();
      this.txtNotesToEngineer = new TextBox();
      this.Label6 = new Label();
      this.txtCustomer = new TextBox();
      this.cboEngineer = new ComboBox();
      this.txtNotesFromEngineer = new TextBox();
      this.cboOutcome = new ComboBox();
      this.txtOutcomeDetails = new TextBox();
      this.Label11 = new Label();
      this.txtUploadedBy = new TextBox();
      this.txtStatus = new TextBox();
      this.Label9 = new Label();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.tpAppliances = new TabPage();
      this.gpAppliances = new GroupBox();
      this.dgAssets = new DataGrid();
      this.tpWorksheets = new TabPage();
      this.grpAdditionalWorksheet = new GroupBox();
      this.btnRemoveAdd = new Button();
      this.btnAddAdd = new Button();
      this.dgAdditional = new DataGrid();
      this.grpAlarmInfo = new GroupBox();
      this.btnRemoveSmokeComo = new Button();
      this.btnAddSmokeComo = new Button();
      this.DGSmokeComo = new DataGrid();
      this.grpVisitWorksheetExtended = new GroupBox();
      this.cboSITimer = new ComboBox();
      this.cboFillDisc = new ComboBox();
      this.Label81 = new Label();
      this.Label80 = new Label();
      this.Label79 = new Label();
      this.txtRadiators = new TextBox();
      this.txtVisualInspectionReason = new TextBox();
      this.Label68 = new Label();
      this.Label69 = new Label();
      this.Label70 = new Label();
      this.Label62 = new Label();
      this.Label63 = new Label();
      this.Label64 = new Label();
      this.Label65 = new Label();
      this.Label66 = new Label();
      this.Label67 = new Label();
      this.cboCertificateTypeID = new ComboBox();
      this.cboCODetectorFittedID = new ComboBox();
      this.cboVisualInspectionSatisfactoryID = new ComboBox();
      this.cboImmersionID = new ComboBox();
      this.cboJacketID = new ComboBox();
      this.cboCylinderTypeID = new ComboBox();
      this.cboPartialHeatingID = new ComboBox();
      this.cboHeatingSystemTypeID = new ComboBox();
      this.txtApproxAgeOfBoiler = new TextBox();
      this.cboStrainerInspectedID = new ComboBox();
      this.Label56 = new Label();
      this.Label57 = new Label();
      this.cboStrainerFittedID = new ComboBox();
      this.cboInstallationSafeToUseID = new ComboBox();
      this.cboInstallationPipeWorkCorrectID = new ComboBox();
      this.cboCorrectMaterialsUsedID = new ComboBox();
      this.Label58 = new Label();
      this.Label59 = new Label();
      this.Label60 = new Label();
      this.Label61 = new Label();
      this.grpVisitDefects = new GroupBox();
      this.btnAddVisitDefect = new Button();
      this.btnRemoveVisitDefect = new Button();
      this.dgVisitDefects = new DataGrid();
      this.grpApplianceWorksheet = new GroupBox();
      this.btnRemoveApplianceWorkSheet = new Button();
      this.dgApplianceWorkSheets = new DataGrid();
      this.btnAddApplianceWorksheet = new Button();
      this.grpVisitWorksheet = new GroupBox();
      this.cboMeterCapped = new ComboBox();
      this.Label73 = new Label();
      this.cboMeterLocation = new ComboBox();
      this.Label72 = new Label();
      this.txtAmountCollected = new TextBox();
      this.cboPaymentMethod = new ComboBox();
      this.Label44 = new Label();
      this.Label43 = new Label();
      this.cboPropertyRented = new ComboBox();
      this.cboBonding = new ComboBox();
      this.cboEmergencyControlAccessible = new ComboBox();
      this.cboGasInstallationTightnessTest = new ComboBox();
      this.Label41 = new Label();
      this.Label40 = new Label();
      this.Label8 = new Label();
      this.Label7 = new Label();
      this.tpTimesheets = new TabPage();
      this.grpTimesheets = new GroupBox();
      this.txtActualTimeSpent = new TextBox();
      this.txtDifference = new TextBox();
      this.txtSORTimeAllowance = new TextBox();
      this.Label52 = new Label();
      this.Label51 = new Label();
      this.Label50 = new Label();
      this.Label22 = new Label();
      this.cboTimeSheetType = new ComboBox();
      this.Label14 = new Label();
      this.txtComments = new TextBox();
      this.dtpEndDate = new DateTimePicker();
      this.dtpStartDate = new DateTimePicker();
      this.dgTimeSheets = new DataGrid();
      this.btnAddTimeSheet = new Button();
      this.Label20 = new Label();
      this.Label21 = new Label();
      this.btnRemoveTimeSheet = new Button();
      this.txtScheduledTime = new TextBox();
      this.Label10 = new Label();
      this.tpPartsAndProducts = new TabPage();
      this.grpAllocated = new GroupBox();
      this.btnUnselectAllPPA = new Button();
      this.btnSelectAllPPA = new Button();
      this.btnRevertUsed = new Button();
      this.nudPartAllocatedQty = new NumericUpDown();
      this.lblAllocatedQuantity = new Label();
      this.btnAllUsed = new Button();
      this.Label35 = new Label();
      this.Panel2 = new Panel();
      this.Label34 = new Label();
      this.Panel1 = new Panel();
      this.btnAllocatedNotUsed = new Button();
      this.dgPartsProductsAllocated = new DataGrid();
      this.lblQuantityWarning = new Label();
      this.grpUsed = new GroupBox();
      this.lblEquipment = new Label();
      this.lblSellPrice = new Label();
      this.dgPartsAndProductsUsed = new DataGrid();
      this.btnAddPartProductUsed = new Button();
      this.nudQuantityUsed = new NumericUpDown();
      this.txtNameUsed = new TextBox();
      this.txtNumberUsed = new TextBox();
      this.Label13 = new Label();
      this.Label15 = new Label();
      this.Label16 = new Label();
      this.btnRemovePartProductUsed = new Button();
      this.btnFindProductUsed = new Button();
      this.btnFindPartUsed = new Button();
      this.tpOutcomes = new TabPage();
      this.grpOutcomes = new GroupBox();
      this.grpSiteFuels = new GroupBox();
      this.dgSiteFuel = new DataGrid();
      this.cboNccRad = new ComboBox();
      this.Label76 = new Label();
      this.cboRecharge = new ComboBox();
      this.Label75 = new Label();
      this.chkRecharge = new CheckBox();
      this.chkGasServiceCompleted = new CheckBox();
      this.tpQC = new TabPage();
      this.GroupBox4 = new GroupBox();
      this.grpQCField = new GroupBox();
      this.cboQCCustSig = new ComboBox();
      this.lblQCCustSig = new Label();
      this.cboRecallEngineer = new ComboBox();
      this.Label49 = new Label();
      this.cboRecall = new ComboBox();
      this.Label48 = new Label();
      this.dtpQCDocumentsRecieved = new DateTimePicker();
      this.chkQCDocumentsRecieved = new CheckBox();
      this.txtQCPoorJobNotes = new TextBox();
      this.lblQCPoorJobNotes = new Label();
      this.cboQCEngineerPaymentRecieved = new ComboBox();
      this.lblQCEngineerMonies = new Label();
      this.cboQCPaymentSelection = new ComboBox();
      this.lblQCEngPaymentMethod = new Label();
      this.cboQCAppliance = new ComboBox();
      this.cboQCPaymentCollection = new ComboBox();
      this.lblQCPaymentCollection = new Label();
      this.cboQCJobUploadTimescale = new ComboBox();
      this.lblQCAppliance = new Label();
      this.cboQCParts = new ComboBox();
      this.lblJobUploadTimescale = new Label();
      this.lblQCParts = new Label();
      this.cboQCLGSR = new ComboBox();
      this.lblQCLGSR = new Label();
      this.cboQCLabourTime = new ComboBox();
      this.lblQCLabourTime = new Label();
      this.grpOfficeQC = new GroupBox();
      this.cboQCPaymentMethod = new ComboBox();
      this.lblPaymentMethod = new Label();
      this.cboQCOrderNo = new ComboBox();
      this.lblOrderNo = new Label();
      this.cboQCScheduleOfRate = new ComboBox();
      this.lblScheduleRate = new Label();
      this.cboQCCustomerDetails = new ComboBox();
      this.lblCustomerDetails = new Label();
      this.cboQCJobType = new ComboBox();
      this.lblJobTypeCorrect = new Label();
      this.cboFTFCode = new ComboBox();
      this.Label74 = new Label();
      this.tpCharges = new TabPage();
      this.gpbInvoice = new GroupBox();
      this.cboDept = new ComboBox();
      this.btnCreateServ = new Button();
      this.txtInvAmount = new TextBox();
      this.txtCreditAmount = new TextBox();
      this.txtInvNo = new TextBox();
      this.cboPaidBy = new ComboBox();
      this.cboInvType = new ComboBox();
      this.cboVATRate = new ComboBox();
      this.txtPriceIncVAT = new TextBox();
      this.txtAccountCode = new TextBox();
      this.lblInvoiceAddressDetails = new Label();
      this.txtNominalCode = new TextBox();
      this.btnSearch = new Button();
      this.dtpRaiseInvoiceOn = new DateTimePicker();
      this.cbxReadyToBeInvoiced = new CheckBox();
      this.lblInvAmount = new Label();
      this.lblcredit = new Label();
      this.lblInvNo = new Label();
      this.lblPaidBy = new Label();
      this.lblInvType = new Label();
      this.lblVAT = new Label();
      this.lblNominalCode = new Label();
      this.lblAccountCode = new Label();
      this.lblPriceInvVAT = new Label();
      this.lblDepartment = new Label();
      this.lblRaiseInvoiceOn = new Label();
      this.gpbCharges = new GroupBox();
      this.chkShowJobCharges = new CheckBox();
      this.GroupBox6 = new GroupBox();
      this.Label82 = new Label();
      this.Label78 = new Label();
      this.Label77 = new Label();
      this.txtProfitPerc = new TextBox();
      this.txtProfit = new TextBox();
      this.CostsToOption1 = new RadioButton();
      this.txtCosts = new TextBox();
      this.CostsToOption3 = new RadioButton();
      this.txtSale = new TextBox();
      this.CostsToOption2 = new RadioButton();
      this.lblContractPerVisit = new Label();
      this.lblOR = new Label();
      this.Label30 = new Label();
      this.lblQuotePercentageTotal = new Label();
      this.lblEquals = new Label();
      this.GroupBox9 = new GroupBox();
      this.rbStandard = new RadioButton();
      this.rbSite = new RadioButton();
      this.lblPercent = new Label();
      this.txtPercentOfQuote = new TextBox();
      this.rdoPercentageOfQuoteValue = new RadioButton();
      this.txtCharge = new TextBox();
      this.rdoChargeOther = new RadioButton();
      this.rdoJobValue = new RadioButton();
      this.txtJobValue = new TextBox();
      this.gpbAdditionalCharges = new GroupBox();
      this.lblAdditionalCharge = new Label();
      this.btnAddAdditionalCharge = new Button();
      this.txtAdditionalCharge = new TextBox();
      this.btnRemoveAdditionalCharge = new Button();
      this.txtAdditionalChargeDescription = new TextBox();
      this.lblDescription = new Label();
      this.txtAdditionalChargeTotal = new TextBox();
      this.Label29 = new Label();
      this.dgAdditionalCharges = new DataGrid();
      this.gpbPartsAndProducts = new GroupBox();
      this.txtPartsMarkUp = new TextBox();
      this.chkPartsSelectAll = new CheckBox();
      this.txtPartProductCost = new TextBox();
      this.txtPartsProductTotal = new TextBox();
      this.Label28 = new Label();
      this.lblPPTotalCost = new Label();
      this.lblPartsMarkUp = new Label();
      this.dgPartsProductCharging = new DataGrid();
      this.gpbTimesheets = new GroupBox();
      this.chkTimesheetSelectAll = new CheckBox();
      this.txtEngineerCostTotal = new TextBox();
      this.txtTimesheetTotal = new TextBox();
      this.Label27 = new Label();
      this.Label32 = new Label();
      this.dgTimesheetCharges = new DataGrid();
      this.gpbScheduleOfRates = new GroupBox();
      this.btnAddSoR = new Button();
      this.txtScheduleOfRatesTotal = new TextBox();
      this.dgScheduleOfRateCharges = new DataGrid();
      this.Label26 = new Label();
      this.tpDocuments = new TabPage();
      this.tpPhotos = new TabPage();
      this.flPhotos = new FlowLayoutPanel();
      this.btnClose = new Button();
      this.btnSave = new Button();
      this.mnuAddChecklist = new ContextMenu();
      this.cbxVisitLockDown = new CheckBox();
      this.lblStatusWarning = new Label();
      this.btnOrders = new Button();
      this.btnInvoice = new Button();
      this.btnPrint = new Button();
      this.PrintMenu = new ContextMenuStrip(this.components);
      this.mnuGasSafetyInspectionBoilerServiceRecord = new ToolStripMenuItem();
      this.txtCurrentContract = new TextBox();
      this.Label39 = new Label();
      this.btnPrintGSR = new Button();
      this.btnPrintSVR = new Button();
      this.btnJob = new Button();
      this.lblRechargeTicked = new Label();
      this.btnShowVisits = new Button();
      this.BottomToolStripPanel = new ToolStripPanel();
      this.TopToolStripPanel = new ToolStripPanel();
      this.RightToolStripPanel = new ToolStripPanel();
      this.LeftToolStripPanel = new ToolStripPanel();
      this.ContentPanel = new ToolStripContentPanel();
      this.Button1 = new Button();
      this.txtCustEmail = new TextBox();
      this.SVRs = new ContextMenuStrip(this.components);
      this.AllGasPaperworkToolStripMenuItem = new ToolStripMenuItem();
      this.svrmenu = new ToolStripMenuItem();
      this.JobSheetMenu = new ToolStripMenuItem();
      this.DomesticGSRToolStripMenuItem = new ToolStripMenuItem();
      this.WarningNoticeToolStripMenuItem = new ToolStripMenuItem();
      this.CommercialGSRToolStripMenuItem = new ToolStripMenuItem();
      this.QCResultsToolStripMenuItem = new ToolStripMenuItem();
      this.ElectricalMinorWorksToolStripMenuItem = new ToolStripMenuItem();
      this.CommercialCateringToolStripMenuItem = new ToolStripMenuItem();
      this.SaffronUnventedWorkshhetToolStripMenuItem = new ToolStripMenuItem();
      this.PropertyMaintenanceWorksheetToolStripMenuItem = new ToolStripMenuItem();
      this.ASHPWorksheetToolStripMenuItem = new ToolStripMenuItem();
      this.CommissioningChecklistToolStripMenuItem = new ToolStripMenuItem();
      this.HotWorksPermitToolStripMenuItem = new ToolStripMenuItem();
      this.tcWorkSheet.SuspendLayout();
      this.tpMainDetails.SuspendLayout();
      ((ISupportInitialize) this.pbCustomerSignature).BeginInit();
      ((ISupportInitialize) this.pbEngineerSignature).BeginInit();
      this.dgJobItems.BeginInit();
      this.tpAppliances.SuspendLayout();
      this.gpAppliances.SuspendLayout();
      this.dgAssets.BeginInit();
      this.tpWorksheets.SuspendLayout();
      this.grpAdditionalWorksheet.SuspendLayout();
      this.dgAdditional.BeginInit();
      this.grpAlarmInfo.SuspendLayout();
      this.DGSmokeComo.BeginInit();
      this.grpVisitWorksheetExtended.SuspendLayout();
      this.grpVisitDefects.SuspendLayout();
      this.dgVisitDefects.BeginInit();
      this.grpApplianceWorksheet.SuspendLayout();
      this.dgApplianceWorkSheets.BeginInit();
      this.grpVisitWorksheet.SuspendLayout();
      this.tpTimesheets.SuspendLayout();
      this.grpTimesheets.SuspendLayout();
      this.dgTimeSheets.BeginInit();
      this.tpPartsAndProducts.SuspendLayout();
      this.grpAllocated.SuspendLayout();
      this.nudPartAllocatedQty.BeginInit();
      this.dgPartsProductsAllocated.BeginInit();
      this.grpUsed.SuspendLayout();
      this.dgPartsAndProductsUsed.BeginInit();
      this.nudQuantityUsed.BeginInit();
      this.tpOutcomes.SuspendLayout();
      this.grpOutcomes.SuspendLayout();
      this.grpSiteFuels.SuspendLayout();
      this.dgSiteFuel.BeginInit();
      this.tpQC.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.grpQCField.SuspendLayout();
      this.grpOfficeQC.SuspendLayout();
      this.tpCharges.SuspendLayout();
      this.gpbInvoice.SuspendLayout();
      this.gpbCharges.SuspendLayout();
      this.GroupBox6.SuspendLayout();
      this.GroupBox9.SuspendLayout();
      this.gpbAdditionalCharges.SuspendLayout();
      this.dgAdditionalCharges.BeginInit();
      this.gpbPartsAndProducts.SuspendLayout();
      this.dgPartsProductCharging.BeginInit();
      this.gpbTimesheets.SuspendLayout();
      this.dgTimesheetCharges.BeginInit();
      this.gpbScheduleOfRates.SuspendLayout();
      this.dgScheduleOfRateCharges.BeginInit();
      this.tpPhotos.SuspendLayout();
      this.PrintMenu.SuspendLayout();
      this.SVRs.SuspendLayout();
      this.SuspendLayout();
      this.tcWorkSheet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcWorkSheet.Controls.Add((Control) this.tpMainDetails);
      this.tcWorkSheet.Controls.Add((Control) this.tpAppliances);
      this.tcWorkSheet.Controls.Add((Control) this.tpWorksheets);
      this.tcWorkSheet.Controls.Add((Control) this.tpTimesheets);
      this.tcWorkSheet.Controls.Add((Control) this.tpPartsAndProducts);
      this.tcWorkSheet.Controls.Add((Control) this.tpOutcomes);
      this.tcWorkSheet.Controls.Add((Control) this.tpQC);
      this.tcWorkSheet.Controls.Add((Control) this.tpCharges);
      this.tcWorkSheet.Controls.Add((Control) this.tpDocuments);
      this.tcWorkSheet.Controls.Add((Control) this.tpPhotos);
      this.tcWorkSheet.Location = new System.Drawing.Point(0, 64);
      this.tcWorkSheet.Name = "tcWorkSheet";
      this.tcWorkSheet.SelectedIndex = 0;
      this.tcWorkSheet.Size = new Size(1255, 678);
      this.tcWorkSheet.TabIndex = 1;
      this.tpMainDetails.Controls.Add((Control) this.chkSORDesc);
      this.tpMainDetails.Controls.Add((Control) this.btnEditInvoiceNotes);
      this.tpMainDetails.Controls.Add((Control) this.txtScheduledTime2);
      this.tpMainDetails.Controls.Add((Control) this.Label71);
      this.tpMainDetails.Controls.Add((Control) this.btnChangeOutcome);
      this.tpMainDetails.Controls.Add((Control) this.pbCustomerSignature);
      this.tpMainDetails.Controls.Add((Control) this.pbEngineerSignature);
      this.tpMainDetails.Controls.Add((Control) this.cbxEmailReceiptToCustomer);
      this.tpMainDetails.Controls.Add((Control) this.cboSignatureSelected);
      this.tpMainDetails.Controls.Add((Control) this.Label42);
      this.tpMainDetails.Controls.Add((Control) this.dgJobItems);
      this.tpMainDetails.Controls.Add((Control) this.Label12);
      this.tpMainDetails.Controls.Add((Control) this.txtNotesToEngineer);
      this.tpMainDetails.Controls.Add((Control) this.Label6);
      this.tpMainDetails.Controls.Add((Control) this.txtCustomer);
      this.tpMainDetails.Controls.Add((Control) this.cboEngineer);
      this.tpMainDetails.Controls.Add((Control) this.txtNotesFromEngineer);
      this.tpMainDetails.Controls.Add((Control) this.cboOutcome);
      this.tpMainDetails.Controls.Add((Control) this.txtOutcomeDetails);
      this.tpMainDetails.Controls.Add((Control) this.Label11);
      this.tpMainDetails.Controls.Add((Control) this.txtUploadedBy);
      this.tpMainDetails.Controls.Add((Control) this.txtStatus);
      this.tpMainDetails.Controls.Add((Control) this.Label9);
      this.tpMainDetails.Controls.Add((Control) this.Label5);
      this.tpMainDetails.Controls.Add((Control) this.Label4);
      this.tpMainDetails.Controls.Add((Control) this.Label3);
      this.tpMainDetails.Controls.Add((Control) this.Label2);
      this.tpMainDetails.Controls.Add((Control) this.Label1);
      this.tpMainDetails.Location = new System.Drawing.Point(4, 22);
      this.tpMainDetails.Name = "tpMainDetails";
      this.tpMainDetails.Size = new Size(1247, 652);
      this.tpMainDetails.TabIndex = 0;
      this.tpMainDetails.Text = "Main Details";
      this.tpMainDetails.UseVisualStyleBackColor = true;
      this.chkSORDesc.AutoSize = true;
      this.chkSORDesc.Font = new Font("Verdana", 16f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkSORDesc.Location = new System.Drawing.Point(128, 413);
      this.chkSORDesc.Name = "chkSORDesc";
      this.chkSORDesc.Size = new Size(394, 30);
      this.chkSORDesc.TabIndex = 35;
      this.chkSORDesc.Text = "Use SOR Descriptions for Invoice";
      this.chkSORDesc.UseVisualStyleBackColor = true;
      this.btnEditInvoiceNotes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnEditInvoiceNotes.Location = new System.Drawing.Point(11, 384);
      this.btnEditInvoiceNotes.Name = "btnEditInvoiceNotes";
      this.btnEditInvoiceNotes.Size = new Size(97, 23);
      this.btnEditInvoiceNotes.TabIndex = 34;
      this.btnEditInvoiceNotes.Text = "Edit Inv Notes";
      this.btnEditInvoiceNotes.Visible = false;
      this.txtScheduledTime2.Location = new System.Drawing.Point(128, 204);
      this.txtScheduledTime2.Name = "txtScheduledTime2";
      this.txtScheduledTime2.ReadOnly = true;
      this.txtScheduledTime2.Size = new Size(510, 21);
      this.txtScheduledTime2.TabIndex = 32;
      this.Label71.Location = new System.Drawing.Point(8, 207);
      this.Label71.Name = "Label71";
      this.Label71.Size = new Size(104, 16);
      this.Label71.TabIndex = 33;
      this.Label71.Text = "Scheduled";
      this.btnChangeOutcome.Location = new System.Drawing.Point(128, 171);
      this.btnChangeOutcome.Name = "btnChangeOutcome";
      this.btnChangeOutcome.Size = new Size(114, 23);
      this.btnChangeOutcome.TabIndex = 31;
      this.btnChangeOutcome.Text = "Change Outcome";
      this.btnChangeOutcome.UseVisualStyleBackColor = true;
      this.pbCustomerSignature.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pbCustomerSignature.BorderStyle = BorderStyle.FixedSingle;
      this.pbCustomerSignature.Location = new System.Drawing.Point(647, 207);
      this.pbCustomerSignature.Name = "pbCustomerSignature";
      this.pbCustomerSignature.Size = new Size(592, 119);
      this.pbCustomerSignature.SizeMode = PictureBoxSizeMode.Zoom;
      this.pbCustomerSignature.TabIndex = 30;
      this.pbCustomerSignature.TabStop = false;
      this.pbEngineerSignature.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pbEngineerSignature.BorderStyle = BorderStyle.FixedSingle;
      this.pbEngineerSignature.Location = new System.Drawing.Point(647, 44);
      this.pbEngineerSignature.Name = "pbEngineerSignature";
      this.pbEngineerSignature.Size = new Size(592, 121);
      this.pbEngineerSignature.SizeMode = PictureBoxSizeMode.Zoom;
      this.pbEngineerSignature.TabIndex = 29;
      this.pbEngineerSignature.TabStop = false;
      this.cbxEmailReceiptToCustomer.AutoSize = true;
      this.cbxEmailReceiptToCustomer.Location = new System.Drawing.Point(647, 390);
      this.cbxEmailReceiptToCustomer.Name = "cbxEmailReceiptToCustomer";
      this.cbxEmailReceiptToCustomer.Size = new Size(180, 17);
      this.cbxEmailReceiptToCustomer.TabIndex = 28;
      this.cbxEmailReceiptToCustomer.Text = "Email Receipt To Customer";
      this.cbxEmailReceiptToCustomer.UseVisualStyleBackColor = true;
      this.cboSignatureSelected.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboSignatureSelected.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSignatureSelected.Location = new System.Drawing.Point(714, 332);
      this.cboSignatureSelected.Name = "cboSignatureSelected";
      this.cboSignatureSelected.Size = new Size(525, 21);
      this.cboSignatureSelected.TabIndex = 27;
      this.Label42.Location = new System.Drawing.Point(644, 335);
      this.Label42.Name = "Label42";
      this.Label42.Size = new Size(64, 23);
      this.Label42.TabIndex = 26;
      this.Label42.Text = "Signature";
      this.dgJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobItems.DataMember = "";
      this.dgJobItems.HeaderForeColor = SystemColors.ControlText;
      this.dgJobItems.Location = new System.Drawing.Point(128, 450);
      this.dgJobItems.Name = "dgJobItems";
      this.dgJobItems.Size = new Size(1111, 196);
      this.dgJobItems.TabIndex = 9;
      this.dgJobItems.TabStop = false;
      this.Label12.Location = new System.Drawing.Point(8, 450);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(80, 16);
      this.Label12.TabIndex = 25;
      this.Label12.Text = "Job Items";
      this.txtNotesToEngineer.Location = new System.Drawing.Point(128, 44);
      this.txtNotesToEngineer.Multiline = true;
      this.txtNotesToEngineer.Name = "txtNotesToEngineer";
      this.txtNotesToEngineer.ReadOnly = true;
      this.txtNotesToEngineer.ScrollBars = ScrollBars.Both;
      this.txtNotesToEngineer.Size = new Size(510, 66);
      this.txtNotesToEngineer.TabIndex = 10;
      this.txtNotesToEngineer.TabStop = false;
      this.Label6.Location = new System.Drawing.Point(8, 40);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(64, 16);
      this.Label6.TabIndex = 21;
      this.Label6.Text = "Notes";
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Location = new System.Drawing.Point(714, 173);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.Size = new Size(525, 21);
      this.txtCustomer.TabIndex = 6;
      this.cboEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineer.Location = new System.Drawing.Point(714, 14);
      this.cboEngineer.Name = "cboEngineer";
      this.cboEngineer.Size = new Size(525, 21);
      this.cboEngineer.TabIndex = 4;
      this.txtNotesFromEngineer.Location = new System.Drawing.Point(128, 335);
      this.txtNotesFromEngineer.Multiline = true;
      this.txtNotesFromEngineer.Name = "txtNotesFromEngineer";
      this.txtNotesFromEngineer.ScrollBars = ScrollBars.Both;
      this.txtNotesFromEngineer.Size = new Size(510, 72);
      this.txtNotesFromEngineer.TabIndex = 3;
      this.cboOutcome.Location = new System.Drawing.Point(128, 144);
      this.cboOutcome.Name = "cboOutcome";
      this.cboOutcome.Size = new Size(510, 21);
      this.cboOutcome.TabIndex = 1;
      this.txtOutcomeDetails.Location = new System.Drawing.Point(128, 231);
      this.txtOutcomeDetails.Multiline = true;
      this.txtOutcomeDetails.Name = "txtOutcomeDetails";
      this.txtOutcomeDetails.ScrollBars = ScrollBars.Both;
      this.txtOutcomeDetails.Size = new Size(510, 95);
      this.txtOutcomeDetails.TabIndex = 2;
      this.Label11.Location = new System.Drawing.Point(8, 234);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(80, 16);
      this.Label11.TabIndex = 12;
      this.Label11.Text = "Details";
      this.txtUploadedBy.Location = new System.Drawing.Point(128, 116);
      this.txtUploadedBy.Name = "txtUploadedBy";
      this.txtUploadedBy.ReadOnly = true;
      this.txtUploadedBy.Size = new Size(510, 21);
      this.txtUploadedBy.TabIndex = 2;
      this.txtUploadedBy.TabStop = false;
      this.txtStatus.Location = new System.Drawing.Point(128, 14);
      this.txtStatus.Name = "txtStatus";
      this.txtStatus.ReadOnly = true;
      this.txtStatus.Size = new Size(510, 21);
      this.txtStatus.TabIndex = 1;
      this.txtStatus.TabStop = false;
      this.Label9.Location = new System.Drawing.Point(8, 147);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(80, 19);
      this.Label9.TabIndex = 8;
      this.Label9.Text = "Outcome";
      this.Label5.Location = new System.Drawing.Point(644, 176);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(64, 16);
      this.Label5.TabIndex = 4;
      this.Label5.Text = "Customer";
      this.Label4.Location = new System.Drawing.Point(8, 119);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(80, 16);
      this.Label4.TabIndex = 3;
      this.Label4.Text = "Uploaded by";
      this.Label3.Location = new System.Drawing.Point(8, 16);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(56, 16);
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Status";
      this.Label2.Location = new System.Drawing.Point(8, 335);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(128, 24);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Invoice Notes";
      this.Label1.Location = new System.Drawing.Point(644, 14);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Engineer";
      this.tpAppliances.Controls.Add((Control) this.gpAppliances);
      this.tpAppliances.Location = new System.Drawing.Point(4, 22);
      this.tpAppliances.Name = "tpAppliances";
      this.tpAppliances.Padding = new Padding(3);
      this.tpAppliances.Size = new Size(1247, 652);
      this.tpAppliances.TabIndex = 6;
      this.tpAppliances.Text = "Appliances";
      this.tpAppliances.UseVisualStyleBackColor = true;
      this.gpAppliances.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpAppliances.Controls.Add((Control) this.dgAssets);
      this.gpAppliances.Location = new System.Drawing.Point(6, 6);
      this.gpAppliances.Name = "gpAppliances";
      this.gpAppliances.Size = new Size(1235, 640);
      this.gpAppliances.TabIndex = 0;
      this.gpAppliances.TabStop = false;
      this.gpAppliances.Text = "Appliances";
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(6, 20);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(1223, 614);
      this.dgAssets.TabIndex = 2;
      this.tpWorksheets.Controls.Add((Control) this.grpAdditionalWorksheet);
      this.tpWorksheets.Controls.Add((Control) this.grpAlarmInfo);
      this.tpWorksheets.Controls.Add((Control) this.grpVisitWorksheetExtended);
      this.tpWorksheets.Controls.Add((Control) this.grpVisitDefects);
      this.tpWorksheets.Controls.Add((Control) this.grpApplianceWorksheet);
      this.tpWorksheets.Controls.Add((Control) this.grpVisitWorksheet);
      this.tpWorksheets.Location = new System.Drawing.Point(4, 22);
      this.tpWorksheets.Name = "tpWorksheets";
      this.tpWorksheets.Size = new Size(1247, 652);
      this.tpWorksheets.TabIndex = 5;
      this.tpWorksheets.Text = "Worksheets";
      this.tpWorksheets.UseVisualStyleBackColor = true;
      this.grpAdditionalWorksheet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpAdditionalWorksheet.Controls.Add((Control) this.btnRemoveAdd);
      this.grpAdditionalWorksheet.Controls.Add((Control) this.btnAddAdd);
      this.grpAdditionalWorksheet.Controls.Add((Control) this.dgAdditional);
      this.grpAdditionalWorksheet.Location = new System.Drawing.Point(515, 259);
      this.grpAdditionalWorksheet.Name = "grpAdditionalWorksheet";
      this.grpAdditionalWorksheet.Size = new Size(360, 247);
      this.grpAdditionalWorksheet.TabIndex = 29;
      this.grpAdditionalWorksheet.TabStop = false;
      this.grpAdditionalWorksheet.Text = "Additional Worksheets";
      this.btnRemoveAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveAdd.Location = new System.Drawing.Point(8, 218);
      this.btnRemoveAdd.Name = "btnRemoveAdd";
      this.btnRemoveAdd.Size = new Size(75, 23);
      this.btnRemoveAdd.TabIndex = 3;
      this.btnRemoveAdd.Text = "Remove";
      this.btnAddAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddAdd.Location = new System.Drawing.Point(275, 218);
      this.btnAddAdd.Name = "btnAddAdd";
      this.btnAddAdd.Size = new Size(75, 23);
      this.btnAddAdd.TabIndex = 4;
      this.btnAddAdd.Text = "Add";
      this.dgAdditional.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAdditional.DataMember = "";
      this.dgAdditional.HeaderForeColor = SystemColors.ControlText;
      this.dgAdditional.Location = new System.Drawing.Point(6, 20);
      this.dgAdditional.Name = "dgAdditional";
      this.dgAdditional.Size = new Size(344, 192);
      this.dgAdditional.TabIndex = 0;
      this.grpAlarmInfo.Controls.Add((Control) this.btnRemoveSmokeComo);
      this.grpAlarmInfo.Controls.Add((Control) this.btnAddSmokeComo);
      this.grpAlarmInfo.Controls.Add((Control) this.DGSmokeComo);
      this.grpAlarmInfo.Location = new System.Drawing.Point(515, 8);
      this.grpAlarmInfo.Name = "grpAlarmInfo";
      this.grpAlarmInfo.Size = new Size(360, 242);
      this.grpAlarmInfo.TabIndex = 4;
      this.grpAlarmInfo.TabStop = false;
      this.grpAlarmInfo.Text = "Alarm Info";
      this.btnRemoveSmokeComo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveSmokeComo.Location = new System.Drawing.Point(12, 202);
      this.btnRemoveSmokeComo.Name = "btnRemoveSmokeComo";
      this.btnRemoveSmokeComo.Size = new Size(75, 23);
      this.btnRemoveSmokeComo.TabIndex = 30;
      this.btnRemoveSmokeComo.Text = "Remove";
      this.btnAddSmokeComo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddSmokeComo.Location = new System.Drawing.Point(275, 202);
      this.btnAddSmokeComo.Name = "btnAddSmokeComo";
      this.btnAddSmokeComo.Size = new Size(75, 23);
      this.btnAddSmokeComo.TabIndex = 31;
      this.btnAddSmokeComo.Text = "Add";
      this.DGSmokeComo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.DGSmokeComo.DataMember = "";
      this.DGSmokeComo.HeaderForeColor = SystemColors.ControlText;
      this.DGSmokeComo.Location = new System.Drawing.Point(12, 17);
      this.DGSmokeComo.Name = "DGSmokeComo";
      this.DGSmokeComo.Size = new Size(338, 181);
      this.DGSmokeComo.TabIndex = 29;
      this.grpVisitWorksheetExtended.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboSITimer);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboFillDisc);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label81);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label80);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label79);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.txtRadiators);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.txtVisualInspectionReason);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label68);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label69);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label70);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label62);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label63);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label64);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label65);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label66);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label67);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboCertificateTypeID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboCODetectorFittedID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboVisualInspectionSatisfactoryID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboImmersionID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboJacketID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboCylinderTypeID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboPartialHeatingID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboHeatingSystemTypeID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.txtApproxAgeOfBoiler);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboStrainerInspectedID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label56);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label57);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboStrainerFittedID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboInstallationSafeToUseID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboInstallationPipeWorkCorrectID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.cboCorrectMaterialsUsedID);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label58);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label59);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label60);
      this.grpVisitWorksheetExtended.Controls.Add((Control) this.Label61);
      this.grpVisitWorksheetExtended.Location = new System.Drawing.Point(881, 8);
      this.grpVisitWorksheetExtended.Name = "grpVisitWorksheetExtended";
      this.grpVisitWorksheetExtended.Size = new Size(358, 636);
      this.grpVisitWorksheetExtended.TabIndex = 3;
      this.grpVisitWorksheetExtended.TabStop = false;
      this.grpVisitWorksheetExtended.Text = "Visit Worksheet - Extended";
      this.cboSITimer.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSITimer.Location = new System.Drawing.Point(192, 449);
      this.cboSITimer.Name = "cboSITimer";
      this.cboSITimer.Size = new Size(160, 21);
      this.cboSITimer.TabIndex = 33;
      this.cboFillDisc.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFillDisc.Location = new System.Drawing.Point(192, 422);
      this.cboFillDisc.Name = "cboFillDisc";
      this.cboFillDisc.Size = new Size(160, 21);
      this.cboFillDisc.TabIndex = 32;
      this.Label81.Location = new System.Drawing.Point(6, 477);
      this.Label81.Name = "Label81";
      this.Label81.Size = new Size(180, 21);
      this.Label81.TabIndex = 31;
      this.Label81.Text = "Flue/Tank In loft details";
      this.Label80.Location = new System.Drawing.Point(6, 423);
      this.Label80.Name = "Label80";
      this.Label80.Size = new Size(180, 21);
      this.Label80.TabIndex = 30;
      this.Label80.Text = "Filling Loop Disconnected?";
      this.Label79.Location = new System.Drawing.Point(6, 449);
      this.Label79.Name = "Label79";
      this.Label79.Size = new Size(180, 21);
      this.Label79.TabIndex = 29;
      this.Label79.Text = "SI Timer Reset";
      this.txtRadiators.Location = new System.Drawing.Point(192, 287);
      this.txtRadiators.Name = "txtRadiators";
      this.txtRadiators.Size = new Size(160, 21);
      this.txtRadiators.TabIndex = 10;
      this.txtRadiators.Text = "0";
      this.txtVisualInspectionReason.Location = new System.Drawing.Point(192, 476);
      this.txtVisualInspectionReason.Multiline = true;
      this.txtVisualInspectionReason.Name = "txtVisualInspectionReason";
      this.txtVisualInspectionReason.Size = new Size(160, 43);
      this.txtVisualInspectionReason.TabIndex = 15;
      this.Label68.Location = new System.Drawing.Point(6, 397);
      this.Label68.Name = "Label68";
      this.Label68.Size = new Size(180, 21);
      this.Label68.TabIndex = 28;
      this.Label68.Text = "Flue/Tank In Loft Satisfactory\r\n";
      this.Label69.Location = new System.Drawing.Point(6, 371);
      this.Label69.Name = "Label69";
      this.Label69.Size = new Size(180, 23);
      this.Label69.TabIndex = 27;
      this.Label69.Text = "Certificate Type";
      this.Label70.Location = new System.Drawing.Point(6, 344);
      this.Label70.Name = "Label70";
      this.Label70.Size = new Size(180, 23);
      this.Label70.TabIndex = 26;
      this.Label70.Text = "Approx. Age Of Boiler";
      this.Label62.Location = new System.Drawing.Point(6, 317);
      this.Label62.Name = "Label62";
      this.Label62.Size = new Size(180, 23);
      this.Label62.TabIndex = 25;
      this.Label62.Text = "CO Detector Fitted ";
      this.Label63.Location = new System.Drawing.Point(6, 290);
      this.Label63.Name = "Label63";
      this.Label63.Size = new Size(180, 23);
      this.Label63.TabIndex = 24;
      this.Label63.Text = "Radiators";
      this.Label64.Location = new System.Drawing.Point(6, 128);
      this.Label64.Name = "Label64";
      this.Label64.Size = new Size(180, 23);
      this.Label64.TabIndex = 23;
      this.Label64.Text = "Is Strainer Inspected";
      this.Label65.Location = new System.Drawing.Point(6, 101);
      this.Label65.Name = "Label65";
      this.Label65.Size = new Size(180, 23);
      this.Label65.TabIndex = 22;
      this.Label65.Text = "Is Strainer Fitted";
      this.Label66.Location = new System.Drawing.Point(6, 263);
      this.Label66.Name = "Label66";
      this.Label66.Size = new Size(180, 23);
      this.Label66.TabIndex = 21;
      this.Label66.Text = "Immersion";
      this.Label67.Location = new System.Drawing.Point(6, 236);
      this.Label67.Name = "Label67";
      this.Label67.Size = new Size(180, 23);
      this.Label67.TabIndex = 20;
      this.Label67.Text = "Jacket";
      this.cboCertificateTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCertificateTypeID.Location = new System.Drawing.Point(192, 368);
      this.cboCertificateTypeID.Name = "cboCertificateTypeID";
      this.cboCertificateTypeID.Size = new Size(160, 21);
      this.cboCertificateTypeID.TabIndex = 13;
      this.cboCODetectorFittedID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCODetectorFittedID.Location = new System.Drawing.Point(192, 314);
      this.cboCODetectorFittedID.Name = "cboCODetectorFittedID";
      this.cboCODetectorFittedID.Size = new Size(160, 21);
      this.cboCODetectorFittedID.TabIndex = 11;
      this.cboVisualInspectionSatisfactoryID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisualInspectionSatisfactoryID.Location = new System.Drawing.Point(192, 395);
      this.cboVisualInspectionSatisfactoryID.Name = "cboVisualInspectionSatisfactoryID";
      this.cboVisualInspectionSatisfactoryID.Size = new Size(160, 21);
      this.cboVisualInspectionSatisfactoryID.TabIndex = 14;
      this.cboImmersionID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboImmersionID.Location = new System.Drawing.Point(192, 260);
      this.cboImmersionID.Name = "cboImmersionID";
      this.cboImmersionID.Size = new Size(160, 21);
      this.cboImmersionID.TabIndex = 9;
      this.cboJacketID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboJacketID.Location = new System.Drawing.Point(192, 233);
      this.cboJacketID.Name = "cboJacketID";
      this.cboJacketID.Size = new Size(160, 21);
      this.cboJacketID.TabIndex = 8;
      this.cboCylinderTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCylinderTypeID.Location = new System.Drawing.Point(192, 206);
      this.cboCylinderTypeID.Name = "cboCylinderTypeID";
      this.cboCylinderTypeID.Size = new Size(160, 21);
      this.cboCylinderTypeID.TabIndex = 7;
      this.cboPartialHeatingID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPartialHeatingID.Location = new System.Drawing.Point(192, 179);
      this.cboPartialHeatingID.Name = "cboPartialHeatingID";
      this.cboPartialHeatingID.Size = new Size(160, 21);
      this.cboPartialHeatingID.TabIndex = 6;
      this.cboHeatingSystemTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboHeatingSystemTypeID.Location = new System.Drawing.Point(192, 152);
      this.cboHeatingSystemTypeID.Name = "cboHeatingSystemTypeID";
      this.cboHeatingSystemTypeID.Size = new Size(160, 21);
      this.cboHeatingSystemTypeID.TabIndex = 5;
      this.txtApproxAgeOfBoiler.Location = new System.Drawing.Point(192, 341);
      this.txtApproxAgeOfBoiler.Name = "txtApproxAgeOfBoiler";
      this.txtApproxAgeOfBoiler.Size = new Size(160, 21);
      this.txtApproxAgeOfBoiler.TabIndex = 12;
      this.txtApproxAgeOfBoiler.Text = "0";
      this.cboStrainerInspectedID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStrainerInspectedID.Location = new System.Drawing.Point(192, 125);
      this.cboStrainerInspectedID.Name = "cboStrainerInspectedID";
      this.cboStrainerInspectedID.Size = new Size(160, 21);
      this.cboStrainerInspectedID.TabIndex = 4;
      this.Label56.Location = new System.Drawing.Point(6, 209);
      this.Label56.Name = "Label56";
      this.Label56.Size = new Size(180, 23);
      this.Label56.TabIndex = 9;
      this.Label56.Text = "Cylinder type ";
      this.Label57.Location = new System.Drawing.Point(6, 182);
      this.Label57.Name = "Label57";
      this.Label57.Size = new Size(180, 23);
      this.Label57.TabIndex = 8;
      this.Label57.Text = "Partial Heating";
      this.cboStrainerFittedID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStrainerFittedID.Location = new System.Drawing.Point(192, 98);
      this.cboStrainerFittedID.Name = "cboStrainerFittedID";
      this.cboStrainerFittedID.Size = new Size(160, 21);
      this.cboStrainerFittedID.TabIndex = 3;
      this.cboInstallationSafeToUseID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInstallationSafeToUseID.Location = new System.Drawing.Point(192, 71);
      this.cboInstallationSafeToUseID.Name = "cboInstallationSafeToUseID";
      this.cboInstallationSafeToUseID.Size = new Size(160, 21);
      this.cboInstallationSafeToUseID.TabIndex = 2;
      this.cboInstallationPipeWorkCorrectID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInstallationPipeWorkCorrectID.Location = new System.Drawing.Point(192, 44);
      this.cboInstallationPipeWorkCorrectID.Name = "cboInstallationPipeWorkCorrectID";
      this.cboInstallationPipeWorkCorrectID.Size = new Size(160, 21);
      this.cboInstallationPipeWorkCorrectID.TabIndex = 1;
      this.cboCorrectMaterialsUsedID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCorrectMaterialsUsedID.Location = new System.Drawing.Point(192, 17);
      this.cboCorrectMaterialsUsedID.Name = "cboCorrectMaterialsUsedID";
      this.cboCorrectMaterialsUsedID.Size = new Size(160, 21);
      this.cboCorrectMaterialsUsedID.TabIndex = 0;
      this.Label58.Location = new System.Drawing.Point(6, 155);
      this.Label58.Name = "Label58";
      this.Label58.Size = new Size(180, 23);
      this.Label58.TabIndex = 3;
      this.Label58.Text = "Heating System Type";
      this.Label59.Location = new System.Drawing.Point(6, 74);
      this.Label59.Name = "Label59";
      this.Label59.Size = new Size(180, 23);
      this.Label59.TabIndex = 2;
      this.Label59.Text = "Installation Safe To Use ";
      this.Label60.Location = new System.Drawing.Point(6, 47);
      this.Label60.Name = "Label60";
      this.Label60.Size = new Size(180, 23);
      this.Label60.TabIndex = 1;
      this.Label60.Text = "Installation Pipework Correct";
      this.Label61.Location = new System.Drawing.Point(6, 20);
      this.Label61.Name = "Label61";
      this.Label61.Size = new Size(180, 23);
      this.Label61.TabIndex = 0;
      this.Label61.Text = "Correct Materials Used In Installation ";
      this.grpVisitDefects.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpVisitDefects.Controls.Add((Control) this.btnAddVisitDefect);
      this.grpVisitDefects.Controls.Add((Control) this.btnRemoveVisitDefect);
      this.grpVisitDefects.Controls.Add((Control) this.dgVisitDefects);
      this.grpVisitDefects.Location = new System.Drawing.Point(8, 503);
      this.grpVisitDefects.Name = "grpVisitDefects";
      this.grpVisitDefects.Size = new Size(501, 141);
      this.grpVisitDefects.TabIndex = 2;
      this.grpVisitDefects.TabStop = false;
      this.grpVisitDefects.Text = "Visit Defects";
      this.btnAddVisitDefect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddVisitDefect.Location = new System.Drawing.Point(421, 109);
      this.btnAddVisitDefect.Name = "btnAddVisitDefect";
      this.btnAddVisitDefect.Size = new Size(75, 23);
      this.btnAddVisitDefect.TabIndex = 3;
      this.btnAddVisitDefect.Text = "Add";
      this.btnRemoveVisitDefect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveVisitDefect.Location = new System.Drawing.Point(8, 109);
      this.btnRemoveVisitDefect.Name = "btnRemoveVisitDefect";
      this.btnRemoveVisitDefect.Size = new Size(75, 23);
      this.btnRemoveVisitDefect.TabIndex = 2;
      this.btnRemoveVisitDefect.Text = "Remove";
      this.dgVisitDefects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisitDefects.DataMember = "";
      this.dgVisitDefects.HeaderForeColor = SystemColors.ControlText;
      this.dgVisitDefects.Location = new System.Drawing.Point(8, 20);
      this.dgVisitDefects.Name = "dgVisitDefects";
      this.dgVisitDefects.Size = new Size(485, 83);
      this.dgVisitDefects.TabIndex = 1;
      this.grpApplianceWorksheet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpApplianceWorksheet.Controls.Add((Control) this.btnRemoveApplianceWorkSheet);
      this.grpApplianceWorksheet.Controls.Add((Control) this.dgApplianceWorkSheets);
      this.grpApplianceWorksheet.Controls.Add((Control) this.btnAddApplianceWorksheet);
      this.grpApplianceWorksheet.Location = new System.Drawing.Point(8, 256);
      this.grpApplianceWorksheet.Name = "grpApplianceWorksheet";
      this.grpApplianceWorksheet.Size = new Size(501, 247);
      this.grpApplianceWorksheet.TabIndex = 1;
      this.grpApplianceWorksheet.TabStop = false;
      this.grpApplianceWorksheet.Text = "Appliance Worksheets";
      this.btnRemoveApplianceWorkSheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveApplianceWorkSheet.Location = new System.Drawing.Point(8, 218);
      this.btnRemoveApplianceWorkSheet.Name = "btnRemoveApplianceWorkSheet";
      this.btnRemoveApplianceWorkSheet.Size = new Size(75, 23);
      this.btnRemoveApplianceWorkSheet.TabIndex = 3;
      this.btnRemoveApplianceWorkSheet.Text = "Remove";
      this.dgApplianceWorkSheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgApplianceWorkSheets.DataMember = "";
      this.dgApplianceWorkSheets.HeaderForeColor = SystemColors.ControlText;
      this.dgApplianceWorkSheets.Location = new System.Drawing.Point(8, 20);
      this.dgApplianceWorkSheets.Name = "dgApplianceWorkSheets";
      this.dgApplianceWorkSheets.Size = new Size(485, 192);
      this.dgApplianceWorkSheets.TabIndex = 0;
      this.btnAddApplianceWorksheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddApplianceWorksheet.Location = new System.Drawing.Point(413, 218);
      this.btnAddApplianceWorksheet.Name = "btnAddApplianceWorksheet";
      this.btnAddApplianceWorksheet.Size = new Size(75, 23);
      this.btnAddApplianceWorksheet.TabIndex = 4;
      this.btnAddApplianceWorksheet.Text = "Add";
      this.grpVisitWorksheet.Controls.Add((Control) this.cboMeterCapped);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label73);
      this.grpVisitWorksheet.Controls.Add((Control) this.cboMeterLocation);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label72);
      this.grpVisitWorksheet.Controls.Add((Control) this.txtAmountCollected);
      this.grpVisitWorksheet.Controls.Add((Control) this.cboPaymentMethod);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label44);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label43);
      this.grpVisitWorksheet.Controls.Add((Control) this.cboPropertyRented);
      this.grpVisitWorksheet.Controls.Add((Control) this.cboBonding);
      this.grpVisitWorksheet.Controls.Add((Control) this.cboEmergencyControlAccessible);
      this.grpVisitWorksheet.Controls.Add((Control) this.cboGasInstallationTightnessTest);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label41);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label40);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label8);
      this.grpVisitWorksheet.Controls.Add((Control) this.Label7);
      this.grpVisitWorksheet.Location = new System.Drawing.Point(8, 8);
      this.grpVisitWorksheet.Name = "grpVisitWorksheet";
      this.grpVisitWorksheet.Size = new Size(501, 242);
      this.grpVisitWorksheet.TabIndex = 0;
      this.grpVisitWorksheet.TabStop = false;
      this.grpVisitWorksheet.Text = "Visit Worksheet";
      this.cboMeterCapped.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboMeterCapped.Location = new System.Drawing.Point(216, 211);
      this.cboMeterCapped.Name = "cboMeterCapped";
      this.cboMeterCapped.Size = new Size(276, 21);
      this.cboMeterCapped.TabIndex = 15;
      this.Label73.Location = new System.Drawing.Point(16, 214);
      this.Label73.Name = "Label73";
      this.Label73.Size = new Size(120, 23);
      this.Label73.TabIndex = 14;
      this.Label73.Text = "Meter Capped";
      this.cboMeterLocation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboMeterLocation.Location = new System.Drawing.Point(216, 182);
      this.cboMeterLocation.Name = "cboMeterLocation";
      this.cboMeterLocation.Size = new Size(276, 21);
      this.cboMeterLocation.TabIndex = 13;
      this.Label72.Location = new System.Drawing.Point(16, 185);
      this.Label72.Name = "Label72";
      this.Label72.Size = new Size(120, 23);
      this.Label72.TabIndex = 12;
      this.Label72.Text = "Meter Location";
      this.txtAmountCollected.Location = new System.Drawing.Point(216, 155);
      this.txtAmountCollected.Name = "txtAmountCollected";
      this.txtAmountCollected.Size = new Size(276, 21);
      this.txtAmountCollected.TabIndex = 11;
      this.cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPaymentMethod.Location = new System.Drawing.Point(216, 128);
      this.cboPaymentMethod.Name = "cboPaymentMethod";
      this.cboPaymentMethod.Size = new Size(276, 21);
      this.cboPaymentMethod.TabIndex = 10;
      this.Label44.Location = new System.Drawing.Point(16, 158);
      this.Label44.Name = "Label44";
      this.Label44.Size = new Size(120, 23);
      this.Label44.TabIndex = 9;
      this.Label44.Text = "Amount Collected";
      this.Label43.Location = new System.Drawing.Point(16, 131);
      this.Label43.Name = "Label43";
      this.Label43.Size = new Size(100, 23);
      this.Label43.TabIndex = 8;
      this.Label43.Text = "Payment Method";
      this.cboPropertyRented.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPropertyRented.Location = new System.Drawing.Point(216, 101);
      this.cboPropertyRented.Name = "cboPropertyRented";
      this.cboPropertyRented.Size = new Size(276, 21);
      this.cboPropertyRented.TabIndex = 7;
      this.cboBonding.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboBonding.Location = new System.Drawing.Point(216, 74);
      this.cboBonding.Name = "cboBonding";
      this.cboBonding.Size = new Size(276, 21);
      this.cboBonding.TabIndex = 6;
      this.cboEmergencyControlAccessible.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEmergencyControlAccessible.Location = new System.Drawing.Point(216, 47);
      this.cboEmergencyControlAccessible.Name = "cboEmergencyControlAccessible";
      this.cboEmergencyControlAccessible.Size = new Size(276, 21);
      this.cboEmergencyControlAccessible.TabIndex = 5;
      this.cboGasInstallationTightnessTest.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboGasInstallationTightnessTest.Location = new System.Drawing.Point(216, 20);
      this.cboGasInstallationTightnessTest.Name = "cboGasInstallationTightnessTest";
      this.cboGasInstallationTightnessTest.Size = new Size(276, 21);
      this.cboGasInstallationTightnessTest.TabIndex = 4;
      this.Label41.Location = new System.Drawing.Point(16, 104);
      this.Label41.Name = "Label41";
      this.Label41.Size = new Size(128, 23);
      this.Label41.TabIndex = 3;
      this.Label41.Text = "Property Rented";
      this.Label40.Location = new System.Drawing.Point(16, 77);
      this.Label40.Name = "Label40";
      this.Label40.Size = new Size(64, 23);
      this.Label40.TabIndex = 2;
      this.Label40.Text = "Bonding";
      this.Label8.Location = new System.Drawing.Point(16, 50);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(192, 23);
      this.Label8.TabIndex = 1;
      this.Label8.Text = "Emergency Control Accessible";
      this.Label7.Location = new System.Drawing.Point(16, 23);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(192, 23);
      this.Label7.TabIndex = 0;
      this.Label7.Text = "Gas Installation Tightness Test";
      this.tpTimesheets.Controls.Add((Control) this.grpTimesheets);
      this.tpTimesheets.Controls.Add((Control) this.txtScheduledTime);
      this.tpTimesheets.Controls.Add((Control) this.Label10);
      this.tpTimesheets.Location = new System.Drawing.Point(4, 22);
      this.tpTimesheets.Name = "tpTimesheets";
      this.tpTimesheets.Size = new Size(1247, 652);
      this.tpTimesheets.TabIndex = 2;
      this.tpTimesheets.Text = "Timesheets";
      this.tpTimesheets.UseVisualStyleBackColor = true;
      this.grpTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpTimesheets.Controls.Add((Control) this.txtActualTimeSpent);
      this.grpTimesheets.Controls.Add((Control) this.txtDifference);
      this.grpTimesheets.Controls.Add((Control) this.txtSORTimeAllowance);
      this.grpTimesheets.Controls.Add((Control) this.Label52);
      this.grpTimesheets.Controls.Add((Control) this.Label51);
      this.grpTimesheets.Controls.Add((Control) this.Label50);
      this.grpTimesheets.Controls.Add((Control) this.Label22);
      this.grpTimesheets.Controls.Add((Control) this.cboTimeSheetType);
      this.grpTimesheets.Controls.Add((Control) this.Label14);
      this.grpTimesheets.Controls.Add((Control) this.txtComments);
      this.grpTimesheets.Controls.Add((Control) this.dtpEndDate);
      this.grpTimesheets.Controls.Add((Control) this.dtpStartDate);
      this.grpTimesheets.Controls.Add((Control) this.dgTimeSheets);
      this.grpTimesheets.Controls.Add((Control) this.btnAddTimeSheet);
      this.grpTimesheets.Controls.Add((Control) this.Label20);
      this.grpTimesheets.Controls.Add((Control) this.Label21);
      this.grpTimesheets.Controls.Add((Control) this.btnRemoveTimeSheet);
      this.grpTimesheets.Location = new System.Drawing.Point(8, 48);
      this.grpTimesheets.Name = "grpTimesheets";
      this.grpTimesheets.Size = new Size(1231, 598);
      this.grpTimesheets.TabIndex = 3;
      this.grpTimesheets.TabStop = false;
      this.grpTimesheets.Text = "TimeSheets";
      this.txtActualTimeSpent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtActualTimeSpent.Location = new System.Drawing.Point(348, 541);
      this.txtActualTimeSpent.Name = "txtActualTimeSpent";
      this.txtActualTimeSpent.ReadOnly = true;
      this.txtActualTimeSpent.Size = new Size(136, 21);
      this.txtActualTimeSpent.TabIndex = 70;
      this.txtDifference.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtDifference.Location = new System.Drawing.Point(348, 571);
      this.txtDifference.Name = "txtDifference";
      this.txtDifference.ReadOnly = true;
      this.txtDifference.Size = new Size(136, 21);
      this.txtDifference.TabIndex = 72;
      this.txtSORTimeAllowance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtSORTimeAllowance.Location = new System.Drawing.Point(348, 509);
      this.txtSORTimeAllowance.Name = "txtSORTimeAllowance";
      this.txtSORTimeAllowance.ReadOnly = true;
      this.txtSORTimeAllowance.Size = new Size(136, 21);
      this.txtSORTimeAllowance.TabIndex = 68;
      this.Label52.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label52.AutoSize = true;
      this.Label52.Location = new System.Drawing.Point(203, 577);
      this.Label52.Name = "Label52";
      this.Label52.Size = new Size(71, 13);
      this.Label52.TabIndex = 71;
      this.Label52.Text = "Difference:";
      this.Label51.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label51.AutoSize = true;
      this.Label51.Location = new System.Drawing.Point(203, 544);
      this.Label51.Name = "Label51";
      this.Label51.Size = new Size(103, 13);
      this.Label51.TabIndex = 69;
      this.Label51.Text = "Act. Time Spent:";
      this.Label50.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label50.AutoSize = true;
      this.Label50.Location = new System.Drawing.Point(203, 512);
      this.Label50.Name = "Label50";
      this.Label50.Size = new Size(130, 13);
      this.Label50.TabIndex = 67;
      this.Label50.Text = "SOR Time Allowance:";
      this.Label22.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label22.Location = new System.Drawing.Point(506, 512);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(72, 23);
      this.Label22.TabIndex = 66;
      this.Label22.Text = "Comments";
      this.cboTimeSheetType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cboTimeSheetType.Location = new System.Drawing.Point(46, 509);
      this.cboTimeSheetType.Name = "cboTimeSheetType";
      this.cboTimeSheetType.Size = new Size(136, 21);
      this.cboTimeSheetType.TabIndex = 3;
      this.Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label14.Location = new System.Drawing.Point(5, 512);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(41, 23);
      this.Label14.TabIndex = 64;
      this.Label14.Text = "Type";
      this.txtComments.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtComments.Location = new System.Drawing.Point(584, 509);
      this.txtComments.Multiline = true;
      this.txtComments.Name = "txtComments";
      this.txtComments.ScrollBars = ScrollBars.Vertical;
      this.txtComments.Size = new Size(404, 83);
      this.txtComments.TabIndex = 4;
      this.dtpEndDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
      this.dtpEndDate.Format = DateTimePickerFormat.Custom;
      this.dtpEndDate.Location = new System.Drawing.Point(46, 571);
      this.dtpEndDate.Name = "dtpEndDate";
      this.dtpEndDate.Size = new Size(136, 21);
      this.dtpEndDate.TabIndex = 2;
      this.dtpStartDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
      this.dtpStartDate.Format = DateTimePickerFormat.Custom;
      this.dtpStartDate.Location = new System.Drawing.Point(46, 540);
      this.dtpStartDate.Name = "dtpStartDate";
      this.dtpStartDate.Size = new Size(136, 21);
      this.dtpStartDate.TabIndex = 1;
      this.dgTimeSheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTimeSheets.DataMember = "";
      this.dgTimeSheets.HeaderForeColor = SystemColors.ControlText;
      this.dgTimeSheets.Location = new System.Drawing.Point(8, 30);
      this.dgTimeSheets.Name = "dgTimeSheets";
      this.dgTimeSheets.Size = new Size(1215, 466);
      this.dgTimeSheets.TabIndex = 7;
      this.dgTimeSheets.TabStop = false;
      this.btnAddTimeSheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddTimeSheet.Location = new System.Drawing.Point(1151, 569);
      this.btnAddTimeSheet.Name = "btnAddTimeSheet";
      this.btnAddTimeSheet.Size = new Size(72, 23);
      this.btnAddTimeSheet.TabIndex = 5;
      this.btnAddTimeSheet.Text = "Add";
      this.Label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label20.Location = new System.Drawing.Point(5, 573);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(35, 23);
      this.Label20.TabIndex = 28;
      this.Label20.Text = "End";
      this.Label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label21.Location = new System.Drawing.Point(5, 544);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(35, 23);
      this.Label21.TabIndex = 25;
      this.Label21.Text = "Start Date/Time";
      this.btnRemoveTimeSheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveTimeSheet.Location = new System.Drawing.Point(1151, 534);
      this.btnRemoveTimeSheet.Name = "btnRemoveTimeSheet";
      this.btnRemoveTimeSheet.Size = new Size(72, 23);
      this.btnRemoveTimeSheet.TabIndex = 6;
      this.btnRemoveTimeSheet.Text = "Remove";
      this.txtScheduledTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtScheduledTime.Location = new System.Drawing.Point(112, 16);
      this.txtScheduledTime.Name = "txtScheduledTime";
      this.txtScheduledTime.ReadOnly = true;
      this.txtScheduledTime.Size = new Size(1127, 21);
      this.txtScheduledTime.TabIndex = 1;
      this.Label10.Location = new System.Drawing.Point(8, 16);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(104, 16);
      this.Label10.TabIndex = 9;
      this.Label10.Text = "Scheduled time";
      this.tpPartsAndProducts.Controls.Add((Control) this.grpAllocated);
      this.tpPartsAndProducts.Controls.Add((Control) this.grpUsed);
      this.tpPartsAndProducts.Location = new System.Drawing.Point(4, 22);
      this.tpPartsAndProducts.Name = "tpPartsAndProducts";
      this.tpPartsAndProducts.Size = new Size(1247, 652);
      this.tpPartsAndProducts.TabIndex = 1;
      this.tpPartsAndProducts.Text = "Parts && Products";
      this.tpPartsAndProducts.UseVisualStyleBackColor = true;
      this.grpAllocated.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAllocated.Controls.Add((Control) this.btnUnselectAllPPA);
      this.grpAllocated.Controls.Add((Control) this.btnSelectAllPPA);
      this.grpAllocated.Controls.Add((Control) this.btnRevertUsed);
      this.grpAllocated.Controls.Add((Control) this.nudPartAllocatedQty);
      this.grpAllocated.Controls.Add((Control) this.lblAllocatedQuantity);
      this.grpAllocated.Controls.Add((Control) this.btnAllUsed);
      this.grpAllocated.Controls.Add((Control) this.Label35);
      this.grpAllocated.Controls.Add((Control) this.Panel2);
      this.grpAllocated.Controls.Add((Control) this.Label34);
      this.grpAllocated.Controls.Add((Control) this.Panel1);
      this.grpAllocated.Controls.Add((Control) this.btnAllocatedNotUsed);
      this.grpAllocated.Controls.Add((Control) this.dgPartsProductsAllocated);
      this.grpAllocated.Controls.Add((Control) this.lblQuantityWarning);
      this.grpAllocated.Location = new System.Drawing.Point(8, 8);
      this.grpAllocated.Name = "grpAllocated";
      this.grpAllocated.Size = new Size(1231, 275);
      this.grpAllocated.TabIndex = 1;
      this.grpAllocated.TabStop = false;
      this.grpAllocated.Text = "Parts && Products Allocated";
      this.btnUnselectAllPPA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnUnselectAllPPA.Location = new System.Drawing.Point(438, 244);
      this.btnUnselectAllPPA.Name = "btnUnselectAllPPA";
      this.btnUnselectAllPPA.Size = new Size(98, 23);
      this.btnUnselectAllPPA.TabIndex = 34;
      this.btnUnselectAllPPA.Text = "Deselect All";
      this.btnSelectAllPPA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectAllPPA.Location = new System.Drawing.Point(334, 244);
      this.btnSelectAllPPA.Name = "btnSelectAllPPA";
      this.btnSelectAllPPA.Size = new Size(98, 23);
      this.btnSelectAllPPA.TabIndex = 33;
      this.btnSelectAllPPA.Text = "Select All";
      this.btnRevertUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRevertUsed.Location = new System.Drawing.Point(234, 244);
      this.btnRevertUsed.Name = "btnRevertUsed";
      this.btnRevertUsed.Size = new Size(96, 23);
      this.btnRevertUsed.TabIndex = 32;
      this.btnRevertUsed.Text = "Revert Used";
      this.nudPartAllocatedQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.nudPartAllocatedQty.Location = new System.Drawing.Point(937, 243);
      this.nudPartAllocatedQty.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.nudPartAllocatedQty.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.nudPartAllocatedQty.Name = "nudPartAllocatedQty";
      this.nudPartAllocatedQty.Size = new Size(64, 21);
      this.nudPartAllocatedQty.TabIndex = 29;
      this.nudPartAllocatedQty.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.lblAllocatedQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblAllocatedQuantity.Location = new System.Drawing.Point(873, 243);
      this.lblAllocatedQuantity.Name = "lblAllocatedQuantity";
      this.lblAllocatedQuantity.Size = new Size(64, 23);
      this.lblAllocatedQuantity.TabIndex = 30;
      this.lblAllocatedQuantity.Text = "Quantity";
      this.btnAllUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAllUsed.Location = new System.Drawing.Point(1015, 243);
      this.btnAllUsed.Name = "btnAllUsed";
      this.btnAllUsed.Size = new Size(96, 23);
      this.btnAllUsed.TabIndex = 2;
      this.btnAllUsed.Text = "Used";
      this.Label35.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label35.Location = new System.Drawing.Point(160, 249);
      this.Label35.Name = "Label35";
      this.Label35.Size = new Size(104, 16);
      this.Label35.TabIndex = 28;
      this.Label35.Text = "Distributed";
      this.Panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel2.BackColor = Color.Lime;
      this.Panel2.Location = new System.Drawing.Point(136, 247);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(16, 16);
      this.Panel2.TabIndex = 27;
      this.Label34.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label34.Location = new System.Drawing.Point(32, 249);
      this.Label34.Name = "Label34";
      this.Label34.Size = new Size(104, 16);
      this.Label34.TabIndex = 26;
      this.Label34.Text = "Not Distributed";
      this.Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel1.BackColor = Color.Red;
      this.Panel1.Location = new System.Drawing.Point(8, 246);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(16, 16);
      this.Panel1.TabIndex = 25;
      this.btnAllocatedNotUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAllocatedNotUsed.Location = new System.Drawing.Point(1119, 243);
      this.btnAllocatedNotUsed.Name = "btnAllocatedNotUsed";
      this.btnAllocatedNotUsed.Size = new Size(96, 23);
      this.btnAllocatedNotUsed.TabIndex = 3;
      this.btnAllocatedNotUsed.Text = "Not Used";
      this.dgPartsProductsAllocated.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartsProductsAllocated.DataMember = "";
      this.dgPartsProductsAllocated.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsProductsAllocated.Location = new System.Drawing.Point(8, 18);
      this.dgPartsProductsAllocated.Name = "dgPartsProductsAllocated";
      this.dgPartsProductsAllocated.Size = new Size(1215, 222);
      this.dgPartsProductsAllocated.TabIndex = 1;
      this.dgPartsProductsAllocated.TabStop = false;
      this.lblQuantityWarning.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblQuantityWarning.AutoSize = true;
      this.lblQuantityWarning.Location = new System.Drawing.Point(603, 249);
      this.lblQuantityWarning.Name = "lblQuantityWarning";
      this.lblQuantityWarning.Size = new Size(241, 13);
      this.lblQuantityWarning.TabIndex = 31;
      this.lblQuantityWarning.Text = "The quantity ordered will be carried over";
      this.lblQuantityWarning.Visible = false;
      this.grpUsed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpUsed.Controls.Add((Control) this.lblEquipment);
      this.grpUsed.Controls.Add((Control) this.lblSellPrice);
      this.grpUsed.Controls.Add((Control) this.dgPartsAndProductsUsed);
      this.grpUsed.Controls.Add((Control) this.btnAddPartProductUsed);
      this.grpUsed.Controls.Add((Control) this.nudQuantityUsed);
      this.grpUsed.Controls.Add((Control) this.txtNameUsed);
      this.grpUsed.Controls.Add((Control) this.txtNumberUsed);
      this.grpUsed.Controls.Add((Control) this.Label13);
      this.grpUsed.Controls.Add((Control) this.Label15);
      this.grpUsed.Controls.Add((Control) this.Label16);
      this.grpUsed.Controls.Add((Control) this.btnRemovePartProductUsed);
      this.grpUsed.Controls.Add((Control) this.btnFindProductUsed);
      this.grpUsed.Controls.Add((Control) this.btnFindPartUsed);
      this.grpUsed.Location = new System.Drawing.Point(8, 289);
      this.grpUsed.Name = "grpUsed";
      this.grpUsed.Size = new Size(1231, 360);
      this.grpUsed.TabIndex = 2;
      this.grpUsed.TabStop = false;
      this.grpUsed.Text = "Parts && Products Used";
      this.lblEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblEquipment.Location = new System.Drawing.Point(853, 296);
      this.lblEquipment.Name = "lblEquipment";
      this.lblEquipment.Size = new Size(100, 23);
      this.lblEquipment.TabIndex = 24;
      this.lblEquipment.Text = "Equipment?";
      this.lblEquipment.Visible = false;
      this.lblSellPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblSellPrice.Location = new System.Drawing.Point(1007, 296);
      this.lblSellPrice.Name = "lblSellPrice";
      this.lblSellPrice.Size = new Size(100, 23);
      this.lblSellPrice.TabIndex = 23;
      this.lblSellPrice.Text = "SELL PRICE";
      this.lblSellPrice.Visible = false;
      this.dgPartsAndProductsUsed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartsAndProductsUsed.DataMember = "";
      this.dgPartsAndProductsUsed.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsAndProductsUsed.Location = new System.Drawing.Point(8, 13);
      this.dgPartsAndProductsUsed.Name = "dgPartsAndProductsUsed";
      this.dgPartsAndProductsUsed.Size = new Size(1215, 283);
      this.dgPartsAndProductsUsed.TabIndex = 1;
      this.dgPartsAndProductsUsed.TabStop = false;
      this.btnAddPartProductUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddPartProductUsed.Enabled = false;
      this.btnAddPartProductUsed.Location = new System.Drawing.Point(1119, 328);
      this.btnAddPartProductUsed.Name = "btnAddPartProductUsed";
      this.btnAddPartProductUsed.Size = new Size(96, 23);
      this.btnAddPartProductUsed.TabIndex = 5;
      this.btnAddPartProductUsed.Text = "PICK ITEM";
      this.nudQuantityUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.nudQuantityUsed.Location = new System.Drawing.Point(1047, 328);
      this.nudQuantityUsed.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.nudQuantityUsed.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.nudQuantityUsed.Name = "nudQuantityUsed";
      this.nudQuantityUsed.Size = new Size(64, 21);
      this.nudQuantityUsed.TabIndex = 4;
      this.nudQuantityUsed.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.txtNameUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNameUsed.Location = new System.Drawing.Point(312, 328);
      this.txtNameUsed.Name = "txtNameUsed";
      this.txtNameUsed.ReadOnly = true;
      this.txtNameUsed.Size = new Size(671, 21);
      this.txtNameUsed.TabIndex = 8;
      this.txtNumberUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtNumberUsed.Location = new System.Drawing.Point(72, 328);
      this.txtNumberUsed.Name = "txtNumberUsed";
      this.txtNumberUsed.ReadOnly = true;
      this.txtNumberUsed.Size = new Size(184, 21);
      this.txtNumberUsed.TabIndex = 7;
      this.Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label13.Location = new System.Drawing.Point(983, 328);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(64, 23);
      this.Label13.TabIndex = 16;
      this.Label13.Text = "Quantity";
      this.Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label15.Location = new System.Drawing.Point(264, 328);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(64, 23);
      this.Label15.TabIndex = 15;
      this.Label15.Text = "Name";
      this.Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label16.Location = new System.Drawing.Point(8, 328);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(72, 23);
      this.Label16.TabIndex = 12;
      this.Label16.Text = "Number";
      this.btnRemovePartProductUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemovePartProductUsed.Location = new System.Drawing.Point(1119, 296);
      this.btnRemovePartProductUsed.Name = "btnRemovePartProductUsed";
      this.btnRemovePartProductUsed.Size = new Size(96, 23);
      this.btnRemovePartProductUsed.TabIndex = 6;
      this.btnRemovePartProductUsed.Text = "Remove";
      this.btnFindProductUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnFindProductUsed.Location = new System.Drawing.Point(104, 296);
      this.btnFindProductUsed.Name = "btnFindProductUsed";
      this.btnFindProductUsed.Size = new Size(88, 23);
      this.btnFindProductUsed.TabIndex = 3;
      this.btnFindProductUsed.Text = "Find Product";
      this.btnFindPartUsed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnFindPartUsed.Location = new System.Drawing.Point(8, 296);
      this.btnFindPartUsed.Name = "btnFindPartUsed";
      this.btnFindPartUsed.Size = new Size(88, 23);
      this.btnFindPartUsed.TabIndex = 2;
      this.btnFindPartUsed.Text = "Find Part";
      this.tpOutcomes.Controls.Add((Control) this.grpOutcomes);
      this.tpOutcomes.Location = new System.Drawing.Point(4, 22);
      this.tpOutcomes.Name = "tpOutcomes";
      this.tpOutcomes.Padding = new Padding(3);
      this.tpOutcomes.Size = new Size(1247, 652);
      this.tpOutcomes.TabIndex = 7;
      this.tpOutcomes.Text = "Outcomes";
      this.tpOutcomes.UseVisualStyleBackColor = true;
      this.grpOutcomes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpOutcomes.Controls.Add((Control) this.grpSiteFuels);
      this.grpOutcomes.Controls.Add((Control) this.cboNccRad);
      this.grpOutcomes.Controls.Add((Control) this.Label76);
      this.grpOutcomes.Controls.Add((Control) this.cboRecharge);
      this.grpOutcomes.Controls.Add((Control) this.Label75);
      this.grpOutcomes.Controls.Add((Control) this.chkRecharge);
      this.grpOutcomes.Controls.Add((Control) this.chkGasServiceCompleted);
      this.grpOutcomes.Location = new System.Drawing.Point(8, 6);
      this.grpOutcomes.Name = "grpOutcomes";
      this.grpOutcomes.Size = new Size(1231, 640);
      this.grpOutcomes.TabIndex = 2;
      this.grpOutcomes.TabStop = false;
      this.grpOutcomes.Text = "Tick those that have been completed on this visit";
      this.grpSiteFuels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSiteFuels.Controls.Add((Control) this.dgSiteFuel);
      this.grpSiteFuels.Location = new System.Drawing.Point(3, 17);
      this.grpSiteFuels.Margin = new Padding(0);
      this.grpSiteFuels.Name = "grpSiteFuels";
      this.grpSiteFuels.Padding = new Padding(0);
      this.grpSiteFuels.Size = new Size(437, 390);
      this.grpSiteFuels.TabIndex = 15;
      this.grpSiteFuels.TabStop = false;
      this.grpSiteFuels.Text = "Site Fuel";
      this.dgSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSiteFuel.DataMember = "";
      this.dgSiteFuel.HeaderForeColor = SystemColors.ControlText;
      this.dgSiteFuel.Location = new System.Drawing.Point(5, 19);
      this.dgSiteFuel.Name = "dgSiteFuel";
      this.dgSiteFuel.Size = new Size(429, 366);
      this.dgSiteFuel.TabIndex = 11;
      this.cboNccRad.FormattingEnabled = true;
      this.cboNccRad.Location = new System.Drawing.Point(649, 108);
      this.cboNccRad.Name = "cboNccRad";
      this.cboNccRad.Size = new Size(180, 21);
      this.cboNccRad.TabIndex = 9;
      this.Label76.AutoSize = true;
      this.Label76.Location = new System.Drawing.Point(458, 111);
      this.Label76.Name = "Label76";
      this.Label76.Size = new Size(172, 13);
      this.Label76.TabIndex = 8;
      this.Label76.Text = "Ncc Radiator Removal / Refit";
      this.cboRecharge.FormattingEnabled = true;
      this.cboRecharge.Location = new System.Drawing.Point(649, 81);
      this.cboRecharge.Name = "cboRecharge";
      this.cboRecharge.Size = new Size(180, 21);
      this.cboRecharge.TabIndex = 7;
      this.Label75.AutoSize = true;
      this.Label75.Location = new System.Drawing.Point(458, 84);
      this.Label75.Name = "Label75";
      this.Label75.Size = new Size(83, 13);
      this.Label75.TabIndex = 6;
      this.Label75.Text = "Recharge To:";
      this.chkRecharge.AutoSize = true;
      this.chkRecharge.Location = new System.Drawing.Point(458, 59);
      this.chkRecharge.Name = "chkRecharge";
      this.chkRecharge.Size = new Size(80, 17);
      this.chkRecharge.TabIndex = 2;
      this.chkRecharge.Text = "Recharge";
      this.chkRecharge.UseVisualStyleBackColor = true;
      this.chkGasServiceCompleted.AutoSize = true;
      this.chkGasServiceCompleted.Location = new System.Drawing.Point(458, 36);
      this.chkGasServiceCompleted.Name = "chkGasServiceCompleted";
      this.chkGasServiceCompleted.Size = new Size(135, 17);
      this.chkGasServiceCompleted.TabIndex = 1;
      this.chkGasServiceCompleted.Text = "Service Completed";
      this.chkGasServiceCompleted.UseVisualStyleBackColor = true;
      this.tpQC.Controls.Add((Control) this.GroupBox4);
      this.tpQC.Location = new System.Drawing.Point(4, 22);
      this.tpQC.Name = "tpQC";
      this.tpQC.Padding = new Padding(3);
      this.tpQC.Size = new Size(1247, 652);
      this.tpQC.TabIndex = 8;
      this.tpQC.Text = "QC";
      this.tpQC.UseVisualStyleBackColor = true;
      this.GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox4.Controls.Add((Control) this.grpQCField);
      this.GroupBox4.Controls.Add((Control) this.grpOfficeQC);
      this.GroupBox4.Location = new System.Drawing.Point(8, 0);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(1235, 646);
      this.GroupBox4.TabIndex = 0;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "QC";
      this.grpQCField.Controls.Add((Control) this.cboQCCustSig);
      this.grpQCField.Controls.Add((Control) this.lblQCCustSig);
      this.grpQCField.Controls.Add((Control) this.cboRecallEngineer);
      this.grpQCField.Controls.Add((Control) this.Label49);
      this.grpQCField.Controls.Add((Control) this.cboRecall);
      this.grpQCField.Controls.Add((Control) this.Label48);
      this.grpQCField.Controls.Add((Control) this.dtpQCDocumentsRecieved);
      this.grpQCField.Controls.Add((Control) this.chkQCDocumentsRecieved);
      this.grpQCField.Controls.Add((Control) this.txtQCPoorJobNotes);
      this.grpQCField.Controls.Add((Control) this.lblQCPoorJobNotes);
      this.grpQCField.Controls.Add((Control) this.cboQCEngineerPaymentRecieved);
      this.grpQCField.Controls.Add((Control) this.lblQCEngineerMonies);
      this.grpQCField.Controls.Add((Control) this.cboQCPaymentSelection);
      this.grpQCField.Controls.Add((Control) this.lblQCEngPaymentMethod);
      this.grpQCField.Controls.Add((Control) this.cboQCAppliance);
      this.grpQCField.Controls.Add((Control) this.cboQCPaymentCollection);
      this.grpQCField.Controls.Add((Control) this.lblQCPaymentCollection);
      this.grpQCField.Controls.Add((Control) this.cboQCJobUploadTimescale);
      this.grpQCField.Controls.Add((Control) this.lblQCAppliance);
      this.grpQCField.Controls.Add((Control) this.cboQCParts);
      this.grpQCField.Controls.Add((Control) this.lblJobUploadTimescale);
      this.grpQCField.Controls.Add((Control) this.lblQCParts);
      this.grpQCField.Controls.Add((Control) this.cboQCLGSR);
      this.grpQCField.Controls.Add((Control) this.lblQCLGSR);
      this.grpQCField.Controls.Add((Control) this.cboQCLabourTime);
      this.grpQCField.Controls.Add((Control) this.lblQCLabourTime);
      this.grpQCField.Location = new System.Drawing.Point(9, 158);
      this.grpQCField.Name = "grpQCField";
      this.grpQCField.Size = new Size(1220, 342);
      this.grpQCField.TabIndex = 38;
      this.grpQCField.TabStop = false;
      this.grpQCField.Text = "Field";
      this.cboQCCustSig.FormattingEnabled = true;
      this.cboQCCustSig.Location = new System.Drawing.Point(251, 198);
      this.cboQCCustSig.Name = "cboQCCustSig";
      this.cboQCCustSig.Size = new Size(277, 21);
      this.cboQCCustSig.TabIndex = 84;
      this.lblQCCustSig.AutoSize = true;
      this.lblQCCustSig.Location = new System.Drawing.Point(12, 201);
      this.lblQCCustSig.Name = "lblQCCustSig";
      this.lblQCCustSig.Size = new Size(111, 13);
      this.lblQCCustSig.TabIndex = 83;
      this.lblQCCustSig.Text = "Customer Signed:";
      this.cboRecallEngineer.FormattingEnabled = true;
      this.cboRecallEngineer.Location = new System.Drawing.Point(847, 27);
      this.cboRecallEngineer.Name = "cboRecallEngineer";
      this.cboRecallEngineer.Size = new Size(353, 21);
      this.cboRecallEngineer.TabIndex = 82;
      this.Label49.AutoSize = true;
      this.Label49.Location = new System.Drawing.Point(584, 27);
      this.Label49.Name = "Label49";
      this.Label49.Size = new Size(100, 13);
      this.Label49.TabIndex = 81;
      this.Label49.Text = "Recall Engineer:";
      this.cboRecall.FormattingEnabled = true;
      this.cboRecall.Location = new System.Drawing.Point(251, 24);
      this.cboRecall.Name = "cboRecall";
      this.cboRecall.Size = new Size(277, 21);
      this.cboRecall.TabIndex = 80;
      this.Label48.AutoSize = true;
      this.Label48.Location = new System.Drawing.Point(12, 27);
      this.Label48.Name = "Label48";
      this.Label48.Size = new Size(46, 13);
      this.Label48.TabIndex = 79;
      this.Label48.Text = "Recall:";
      this.dtpQCDocumentsRecieved.Location = new System.Drawing.Point(251, 236);
      this.dtpQCDocumentsRecieved.Name = "dtpQCDocumentsRecieved";
      this.dtpQCDocumentsRecieved.Size = new Size(180, 21);
      this.dtpQCDocumentsRecieved.TabIndex = 78;
      this.dtpQCDocumentsRecieved.Visible = false;
      this.chkQCDocumentsRecieved.AutoSize = true;
      this.chkQCDocumentsRecieved.CheckAlign = ContentAlignment.MiddleRight;
      this.chkQCDocumentsRecieved.Location = new System.Drawing.Point(15, 236);
      this.chkQCDocumentsRecieved.Name = "chkQCDocumentsRecieved";
      this.chkQCDocumentsRecieved.Size = new Size(164, 17);
      this.chkQCDocumentsRecieved.TabIndex = 77;
      this.chkQCDocumentsRecieved.Text = "All documents recieved:";
      this.chkQCDocumentsRecieved.UseVisualStyleBackColor = true;
      this.txtQCPoorJobNotes.Location = new System.Drawing.Point(759, 198);
      this.txtQCPoorJobNotes.Multiline = true;
      this.txtQCPoorJobNotes.Name = "txtQCPoorJobNotes";
      this.txtQCPoorJobNotes.ScrollBars = ScrollBars.Vertical;
      this.txtQCPoorJobNotes.Size = new Size(441, 111);
      this.txtQCPoorJobNotes.TabIndex = 76;
      this.txtQCPoorJobNotes.Tag = (object) "";
      this.lblQCPoorJobNotes.AutoSize = true;
      this.lblQCPoorJobNotes.Location = new System.Drawing.Point(584, 198);
      this.lblQCPoorJobNotes.Name = "lblQCPoorJobNotes";
      this.lblQCPoorJobNotes.Size = new Size(95, 13);
      this.lblQCPoorJobNotes.TabIndex = 40;
      this.lblQCPoorJobNotes.Text = "Poor job notes:";
      this.cboQCEngineerPaymentRecieved.FormattingEnabled = true;
      this.cboQCEngineerPaymentRecieved.Location = new System.Drawing.Point(847, 162);
      this.cboQCEngineerPaymentRecieved.Name = "cboQCEngineerPaymentRecieved";
      this.cboQCEngineerPaymentRecieved.Size = new Size(353, 21);
      this.cboQCEngineerPaymentRecieved.TabIndex = 39;
      this.lblQCEngineerMonies.AutoSize = true;
      this.lblQCEngineerMonies.Location = new System.Drawing.Point(584, 162);
      this.lblQCEngineerMonies.Name = "lblQCEngineerMonies";
      this.lblQCEngineerMonies.Size = new Size(251, 13);
      this.lblQCEngineerMonies.TabIndex = 38;
      this.lblQCEngineerMonies.Text = "Engineer Cash/Cheque payment recieved:";
      this.cboQCPaymentSelection.FormattingEnabled = true;
      this.cboQCPaymentSelection.Location = new System.Drawing.Point(847, 130);
      this.cboQCPaymentSelection.Name = "cboQCPaymentSelection";
      this.cboQCPaymentSelection.Size = new Size(353, 21);
      this.cboQCPaymentSelection.TabIndex = 37;
      this.lblQCEngPaymentMethod.AutoSize = true;
      this.lblQCEngPaymentMethod.Location = new System.Drawing.Point(584, 130);
      this.lblQCEngPaymentMethod.Name = "lblQCEngPaymentMethod";
      this.lblQCEngPaymentMethod.Size = new Size(207, 13);
      this.lblQCEngPaymentMethod.TabIndex = 36;
      this.lblQCEngPaymentMethod.Text = "Correct payment method selected:";
      this.cboQCAppliance.FormattingEnabled = true;
      this.cboQCAppliance.Location = new System.Drawing.Point(847, 96);
      this.cboQCAppliance.Name = "cboQCAppliance";
      this.cboQCAppliance.Size = new Size(353, 21);
      this.cboQCAppliance.TabIndex = 35;
      this.cboQCPaymentCollection.FormattingEnabled = true;
      this.cboQCPaymentCollection.Location = new System.Drawing.Point(251, 159);
      this.cboQCPaymentCollection.Name = "cboQCPaymentCollection";
      this.cboQCPaymentCollection.Size = new Size(277, 21);
      this.cboQCPaymentCollection.TabIndex = 16;
      this.lblQCPaymentCollection.AutoSize = true;
      this.lblQCPaymentCollection.Location = new System.Drawing.Point(12, 162);
      this.lblQCPaymentCollection.Name = "lblQCPaymentCollection";
      this.lblQCPaymentCollection.Size = new Size(116, 13);
      this.lblQCPaymentCollection.TabIndex = 15;
      this.lblQCPaymentCollection.Text = "Payment collected:";
      this.cboQCJobUploadTimescale.FormattingEnabled = true;
      this.cboQCJobUploadTimescale.Location = new System.Drawing.Point(251, (int) sbyte.MaxValue);
      this.cboQCJobUploadTimescale.Name = "cboQCJobUploadTimescale";
      this.cboQCJobUploadTimescale.Size = new Size(277, 21);
      this.cboQCJobUploadTimescale.TabIndex = 14;
      this.lblQCAppliance.AutoSize = true;
      this.lblQCAppliance.Location = new System.Drawing.Point(584, 96);
      this.lblQCAppliance.Name = "lblQCAppliance";
      this.lblQCAppliance.Size = new Size(122, 13);
      this.lblQCAppliance.TabIndex = 34;
      this.lblQCAppliance.Text = "Appliance recorded:";
      this.cboQCParts.FormattingEnabled = true;
      this.cboQCParts.Location = new System.Drawing.Point(251, 93);
      this.cboQCParts.Name = "cboQCParts";
      this.cboQCParts.Size = new Size(277, 21);
      this.cboQCParts.TabIndex = 33;
      this.lblJobUploadTimescale.AutoSize = true;
      this.lblJobUploadTimescale.Location = new System.Drawing.Point(12, 130);
      this.lblJobUploadTimescale.Name = "lblJobUploadTimescale";
      this.lblJobUploadTimescale.Size = new Size(159, 13);
      this.lblJobUploadTimescale.TabIndex = 13;
      this.lblJobUploadTimescale.Text = "Job uploaded in timescale:";
      this.lblQCParts.AutoSize = true;
      this.lblQCParts.Location = new System.Drawing.Point(12, 96);
      this.lblQCParts.Name = "lblQCParts";
      this.lblQCParts.Size = new Size(102, 13);
      this.lblQCParts.TabIndex = 32;
      this.lblQCParts.Text = "Parts confirmed:";
      this.cboQCLGSR.FormattingEnabled = true;
      this.cboQCLGSR.Location = new System.Drawing.Point(847, 62);
      this.cboQCLGSR.Name = "cboQCLGSR";
      this.cboQCLGSR.Size = new Size(353, 21);
      this.cboQCLGSR.TabIndex = 31;
      this.lblQCLGSR.AutoSize = true;
      this.lblQCLGSR.Location = new System.Drawing.Point(584, 62);
      this.lblQCLGSR.Name = "lblQCLGSR";
      this.lblQCLGSR.Size = new Size(90, 13);
      this.lblQCLGSR.TabIndex = 30;
      this.lblQCLGSR.Text = "LGSR missing:";
      this.cboQCLabourTime.FormattingEnabled = true;
      this.cboQCLabourTime.Location = new System.Drawing.Point(251, 59);
      this.cboQCLabourTime.Name = "cboQCLabourTime";
      this.cboQCLabourTime.Size = new Size(277, 21);
      this.cboQCLabourTime.TabIndex = 29;
      this.lblQCLabourTime.AutoSize = true;
      this.lblQCLabourTime.Location = new System.Drawing.Point(12, 62);
      this.lblQCLabourTime.Name = "lblQCLabourTime";
      this.lblQCLabourTime.Size = new Size(167, 13);
      this.lblQCLabourTime.TabIndex = 28;
      this.lblQCLabourTime.Text = "Labour/Travel time missing:";
      this.grpOfficeQC.Controls.Add((Control) this.cboQCPaymentMethod);
      this.grpOfficeQC.Controls.Add((Control) this.lblPaymentMethod);
      this.grpOfficeQC.Controls.Add((Control) this.cboQCOrderNo);
      this.grpOfficeQC.Controls.Add((Control) this.lblOrderNo);
      this.grpOfficeQC.Controls.Add((Control) this.cboQCScheduleOfRate);
      this.grpOfficeQC.Controls.Add((Control) this.lblScheduleRate);
      this.grpOfficeQC.Controls.Add((Control) this.cboQCCustomerDetails);
      this.grpOfficeQC.Controls.Add((Control) this.lblCustomerDetails);
      this.grpOfficeQC.Controls.Add((Control) this.cboQCJobType);
      this.grpOfficeQC.Controls.Add((Control) this.lblJobTypeCorrect);
      this.grpOfficeQC.Controls.Add((Control) this.cboFTFCode);
      this.grpOfficeQC.Controls.Add((Control) this.Label74);
      this.grpOfficeQC.Location = new System.Drawing.Point(9, 20);
      this.grpOfficeQC.Name = "grpOfficeQC";
      this.grpOfficeQC.Size = new Size(1220, 132);
      this.grpOfficeQC.TabIndex = 30;
      this.grpOfficeQC.TabStop = false;
      this.grpOfficeQC.Text = "Office";
      this.cboQCPaymentMethod.FormattingEnabled = true;
      this.cboQCPaymentMethod.Location = new System.Drawing.Point(251, 90);
      this.cboQCPaymentMethod.Name = "cboQCPaymentMethod";
      this.cboQCPaymentMethod.Size = new Size(277, 21);
      this.cboQCPaymentMethod.TabIndex = 37;
      this.lblPaymentMethod.AutoSize = true;
      this.lblPaymentMethod.Location = new System.Drawing.Point(12, 93);
      this.lblPaymentMethod.Name = "lblPaymentMethod";
      this.lblPaymentMethod.Size = new Size(158, 13);
      this.lblPaymentMethod.TabIndex = 36;
      this.lblPaymentMethod.Text = "Payment method detailed:";
      this.cboQCOrderNo.FormattingEnabled = true;
      this.cboQCOrderNo.Location = new System.Drawing.Point(759, 57);
      this.cboQCOrderNo.Name = "cboQCOrderNo";
      this.cboQCOrderNo.Size = new Size(441, 21);
      this.cboQCOrderNo.TabIndex = 35;
      this.lblOrderNo.AutoSize = true;
      this.lblOrderNo.Location = new System.Drawing.Point(584, 60);
      this.lblOrderNo.Name = "lblOrderNo";
      this.lblOrderNo.Size = new Size(150, 13);
      this.lblOrderNo.TabIndex = 34;
      this.lblOrderNo.Text = "Order number attached: ";
      this.cboQCScheduleOfRate.FormattingEnabled = true;
      this.cboQCScheduleOfRate.Location = new System.Drawing.Point(251, 54);
      this.cboQCScheduleOfRate.Name = "cboQCScheduleOfRate";
      this.cboQCScheduleOfRate.Size = new Size(277, 21);
      this.cboQCScheduleOfRate.TabIndex = 33;
      this.lblScheduleRate.AutoSize = true;
      this.lblScheduleRate.Location = new System.Drawing.Point(12, 57);
      this.lblScheduleRate.Name = "lblScheduleRate";
      this.lblScheduleRate.Size = new Size(208, 13);
      this.lblScheduleRate.TabIndex = 32;
      this.lblScheduleRate.Text = "Correct schedule of rates selected:";
      this.cboQCCustomerDetails.FormattingEnabled = true;
      this.cboQCCustomerDetails.Location = new System.Drawing.Point(759, 20);
      this.cboQCCustomerDetails.Name = "cboQCCustomerDetails";
      this.cboQCCustomerDetails.Size = new Size(441, 21);
      this.cboQCCustomerDetails.TabIndex = 31;
      this.lblCustomerDetails.AutoSize = true;
      this.lblCustomerDetails.Location = new System.Drawing.Point(584, 23);
      this.lblCustomerDetails.Name = "lblCustomerDetails";
      this.lblCustomerDetails.Size = new Size(157, 13);
      this.lblCustomerDetails.TabIndex = 30;
      this.lblCustomerDetails.Text = "Correct customer details: ";
      this.cboQCJobType.FormattingEnabled = true;
      this.cboQCJobType.Location = new System.Drawing.Point(251, 20);
      this.cboQCJobType.Name = "cboQCJobType";
      this.cboQCJobType.Size = new Size(277, 21);
      this.cboQCJobType.TabIndex = 29;
      this.lblJobTypeCorrect.AutoSize = true;
      this.lblJobTypeCorrect.Location = new System.Drawing.Point(12, 23);
      this.lblJobTypeCorrect.Name = "lblJobTypeCorrect";
      this.lblJobTypeCorrect.Size = new Size(157, 13);
      this.lblJobTypeCorrect.TabIndex = 28;
      this.lblJobTypeCorrect.Text = "Correct job type selected:";
      this.cboFTFCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboFTFCode.FormattingEnabled = true;
      this.cboFTFCode.Location = new System.Drawing.Point(759, 90);
      this.cboFTFCode.Name = "cboFTFCode";
      this.cboFTFCode.Size = new Size(441, 21);
      this.cboFTFCode.TabIndex = 27;
      this.Label74.AutoSize = true;
      this.Label74.Location = new System.Drawing.Point(584, 93);
      this.Label74.Name = "Label74";
      this.Label74.Size = new Size(65, 13);
      this.Label74.TabIndex = 26;
      this.Label74.Text = "FTF Code:";
      this.tpCharges.Controls.Add((Control) this.gpbInvoice);
      this.tpCharges.Controls.Add((Control) this.gpbCharges);
      this.tpCharges.Controls.Add((Control) this.gpbAdditionalCharges);
      this.tpCharges.Controls.Add((Control) this.gpbPartsAndProducts);
      this.tpCharges.Controls.Add((Control) this.gpbTimesheets);
      this.tpCharges.Controls.Add((Control) this.gpbScheduleOfRates);
      this.tpCharges.Location = new System.Drawing.Point(4, 22);
      this.tpCharges.Name = "tpCharges";
      this.tpCharges.Size = new Size(1247, 652);
      this.tpCharges.TabIndex = 4;
      this.tpCharges.Text = "Visit Charges";
      this.tpCharges.UseVisualStyleBackColor = true;
      this.gpbInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.gpbInvoice.Controls.Add((Control) this.cboDept);
      this.gpbInvoice.Controls.Add((Control) this.btnCreateServ);
      this.gpbInvoice.Controls.Add((Control) this.txtInvAmount);
      this.gpbInvoice.Controls.Add((Control) this.txtCreditAmount);
      this.gpbInvoice.Controls.Add((Control) this.txtInvNo);
      this.gpbInvoice.Controls.Add((Control) this.cboPaidBy);
      this.gpbInvoice.Controls.Add((Control) this.cboInvType);
      this.gpbInvoice.Controls.Add((Control) this.cboVATRate);
      this.gpbInvoice.Controls.Add((Control) this.txtPriceIncVAT);
      this.gpbInvoice.Controls.Add((Control) this.txtAccountCode);
      this.gpbInvoice.Controls.Add((Control) this.lblInvoiceAddressDetails);
      this.gpbInvoice.Controls.Add((Control) this.txtNominalCode);
      this.gpbInvoice.Controls.Add((Control) this.btnSearch);
      this.gpbInvoice.Controls.Add((Control) this.dtpRaiseInvoiceOn);
      this.gpbInvoice.Controls.Add((Control) this.cbxReadyToBeInvoiced);
      this.gpbInvoice.Controls.Add((Control) this.lblInvAmount);
      this.gpbInvoice.Controls.Add((Control) this.lblcredit);
      this.gpbInvoice.Controls.Add((Control) this.lblInvNo);
      this.gpbInvoice.Controls.Add((Control) this.lblPaidBy);
      this.gpbInvoice.Controls.Add((Control) this.lblInvType);
      this.gpbInvoice.Controls.Add((Control) this.lblVAT);
      this.gpbInvoice.Controls.Add((Control) this.lblNominalCode);
      this.gpbInvoice.Controls.Add((Control) this.lblAccountCode);
      this.gpbInvoice.Controls.Add((Control) this.lblPriceInvVAT);
      this.gpbInvoice.Controls.Add((Control) this.lblDepartment);
      this.gpbInvoice.Controls.Add((Control) this.lblRaiseInvoiceOn);
      this.gpbInvoice.Location = new System.Drawing.Point(717, 425);
      this.gpbInvoice.Name = "gpbInvoice";
      this.gpbInvoice.Size = new Size(522, 221);
      this.gpbInvoice.TabIndex = 6;
      this.gpbInvoice.TabStop = false;
      this.gpbInvoice.Text = "Ready To Be Invoiced";
      this.cboDept.FormattingEnabled = true;
      this.cboDept.Location = new System.Drawing.Point(315, 26);
      this.cboDept.Name = "cboDept";
      this.cboDept.Size = new Size(98, 21);
      this.cboDept.TabIndex = 32;
      this.btnCreateServ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreateServ.Location = new System.Drawing.Point(8, 192);
      this.btnCreateServ.Name = "btnCreateServ";
      this.btnCreateServ.Size = new Size(159, 23);
      this.btnCreateServ.TabIndex = 31;
      this.btnCreateServ.Text = "Create Multiple Services";
      this.txtInvAmount.Location = new System.Drawing.Point(340, 190);
      this.txtInvAmount.Name = "txtInvAmount";
      this.txtInvAmount.ReadOnly = true;
      this.txtInvAmount.Size = new Size(74, 21);
      this.txtInvAmount.TabIndex = 27;
      this.txtInvAmount.Visible = false;
      this.txtCreditAmount.Location = new System.Drawing.Point(425, 190);
      this.txtCreditAmount.Name = "txtCreditAmount";
      this.txtCreditAmount.ReadOnly = true;
      this.txtCreditAmount.Size = new Size(91, 21);
      this.txtCreditAmount.TabIndex = 25;
      this.txtCreditAmount.Visible = false;
      this.txtInvNo.Location = new System.Drawing.Point(251, 190);
      this.txtInvNo.Name = "txtInvNo";
      this.txtInvNo.ReadOnly = true;
      this.txtInvNo.Size = new Size(76, 21);
      this.txtInvNo.TabIndex = 23;
      this.txtInvNo.Visible = false;
      this.cboPaidBy.FormattingEnabled = true;
      this.cboPaidBy.Location = new System.Drawing.Point(249, 106);
      this.cboPaidBy.Name = "cboPaidBy";
      this.cboPaidBy.Size = new Size(164, 21);
      this.cboPaidBy.TabIndex = 19;
      this.cboPaidBy.Visible = false;
      this.cboInvType.FormattingEnabled = true;
      this.cboInvType.Location = new System.Drawing.Point(249, 64);
      this.cboInvType.Name = "cboInvType";
      this.cboInvType.Size = new Size(164, 21);
      this.cboInvType.TabIndex = 17;
      this.cboInvType.Visible = false;
      this.cboVATRate.FormattingEnabled = true;
      this.cboVATRate.Location = new System.Drawing.Point(425, 63);
      this.cboVATRate.Name = "cboVATRate";
      this.cboVATRate.Size = new Size(90, 21);
      this.cboVATRate.TabIndex = 13;
      this.cboVATRate.Visible = false;
      this.txtPriceIncVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPriceIncVAT.Location = new System.Drawing.Point(425, 106);
      this.txtPriceIncVAT.Name = "txtPriceIncVAT";
      this.txtPriceIncVAT.ReadOnly = true;
      this.txtPriceIncVAT.Size = new Size(91, 21);
      this.txtPriceIncVAT.TabIndex = 3;
      this.txtPriceIncVAT.Visible = false;
      this.txtAccountCode.Location = new System.Drawing.Point(425, 24);
      this.txtAccountCode.Name = "txtAccountCode";
      this.txtAccountCode.Size = new Size(91, 21);
      this.txtAccountCode.TabIndex = 12;
      this.txtAccountCode.Visible = false;
      this.lblInvoiceAddressDetails.Location = new System.Drawing.Point(8, 43);
      this.lblInvoiceAddressDetails.Name = "lblInvoiceAddressDetails";
      this.lblInvoiceAddressDetails.Size = new Size(231, (int) sbyte.MaxValue);
      this.lblInvoiceAddressDetails.TabIndex = 4;
      this.lblInvoiceAddressDetails.Visible = false;
      this.txtNominalCode.Location = new System.Drawing.Point(249, 24);
      this.txtNominalCode.Name = "txtNominalCode";
      this.txtNominalCode.Size = new Size(47, 21);
      this.txtNominalCode.TabIndex = 9;
      this.btnSearch.Location = new System.Drawing.Point(177, 16);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(62, 23);
      this.btnSearch.TabIndex = 1;
      this.btnSearch.Text = "Change";
      this.btnSearch.Visible = false;
      this.dtpRaiseInvoiceOn.Format = DateTimePickerFormat.Short;
      this.dtpRaiseInvoiceOn.Location = new System.Drawing.Point(425, 148);
      this.dtpRaiseInvoiceOn.Name = "dtpRaiseInvoiceOn";
      this.dtpRaiseInvoiceOn.Size = new Size(91, 21);
      this.dtpRaiseInvoiceOn.TabIndex = 6;
      this.dtpRaiseInvoiceOn.Visible = false;
      this.cbxReadyToBeInvoiced.Location = new System.Drawing.Point(8, 22);
      this.cbxReadyToBeInvoiced.Name = "cbxReadyToBeInvoiced";
      this.cbxReadyToBeInvoiced.Size = new Size(180, 16);
      this.cbxReadyToBeInvoiced.TabIndex = 0;
      this.cbxReadyToBeInvoiced.Text = "Ready To Be Invoiced To:";
      this.lblInvAmount.Location = new System.Drawing.Point(338, 172);
      this.lblInvAmount.Name = "lblInvAmount";
      this.lblInvAmount.Size = new Size(76, 17);
      this.lblInvAmount.TabIndex = 28;
      this.lblInvAmount.Text = "Inv Ex VAT";
      this.lblInvAmount.TextAlign = ContentAlignment.MiddleLeft;
      this.lblInvAmount.Visible = false;
      this.lblcredit.Location = new System.Drawing.Point(420, 173);
      this.lblcredit.Name = "lblcredit";
      this.lblcredit.Size = new Size(92, 14);
      this.lblcredit.TabIndex = 26;
      this.lblcredit.Text = "Credit Ex VAT";
      this.lblcredit.TextAlign = ContentAlignment.MiddleLeft;
      this.lblcredit.Visible = false;
      this.lblInvNo.Location = new System.Drawing.Point(249, 170);
      this.lblInvNo.Name = "lblInvNo";
      this.lblInvNo.Size = new Size(91, 17);
      this.lblInvNo.TabIndex = 24;
      this.lblInvNo.Text = "Invoice No.";
      this.lblInvNo.TextAlign = ContentAlignment.MiddleLeft;
      this.lblInvNo.Visible = false;
      this.lblPaidBy.Location = new System.Drawing.Point(248, 89);
      this.lblPaidBy.Name = "lblPaidBy";
      this.lblPaidBy.Size = new Size(130, 17);
      this.lblPaidBy.TabIndex = 20;
      this.lblPaidBy.Text = "Paid By";
      this.lblPaidBy.TextAlign = ContentAlignment.MiddleLeft;
      this.lblPaidBy.Visible = false;
      this.lblInvType.Location = new System.Drawing.Point(248, 48);
      this.lblInvType.Name = "lblInvType";
      this.lblInvType.Size = new Size(130, 17);
      this.lblInvType.TabIndex = 18;
      this.lblInvType.Text = "Invoice Type";
      this.lblInvType.TextAlign = ContentAlignment.MiddleLeft;
      this.lblInvType.Visible = false;
      this.lblVAT.Location = new System.Drawing.Point(420, 48);
      this.lblVAT.Name = "lblVAT";
      this.lblVAT.Size = new Size(94, 17);
      this.lblVAT.TabIndex = 14;
      this.lblVAT.Text = "VAT Rate";
      this.lblVAT.TextAlign = ContentAlignment.MiddleLeft;
      this.lblVAT.Visible = false;
      this.lblNominalCode.Location = new System.Drawing.Point(246, 9);
      this.lblNominalCode.Name = "lblNominalCode";
      this.lblNominalCode.Size = new Size(60, 14);
      this.lblNominalCode.TabIndex = 7;
      this.lblNominalCode.Text = "Nominal";
      this.lblNominalCode.TextAlign = ContentAlignment.MiddleLeft;
      this.lblAccountCode.Location = new System.Drawing.Point(420, 8);
      this.lblAccountCode.Name = "lblAccountCode";
      this.lblAccountCode.Size = new Size(107, 14);
      this.lblAccountCode.TabIndex = 11;
      this.lblAccountCode.Text = "Account Code";
      this.lblAccountCode.TextAlign = ContentAlignment.MiddleLeft;
      this.lblAccountCode.Visible = false;
      this.lblPriceInvVAT.Location = new System.Drawing.Point(420, 87);
      this.lblPriceInvVAT.Name = "lblPriceInvVAT";
      this.lblPriceInvVAT.Size = new Size(92, 16);
      this.lblPriceInvVAT.TabIndex = 2;
      this.lblPriceInvVAT.Text = "Price Inc VAT";
      this.lblPriceInvVAT.TextAlign = ContentAlignment.MiddleLeft;
      this.lblPriceInvVAT.Visible = false;
      this.lblDepartment.Location = new System.Drawing.Point(312, 7);
      this.lblDepartment.Name = "lblDepartment";
      this.lblDepartment.Size = new Size(79, 16);
      this.lblDepartment.TabIndex = 8;
      this.lblDepartment.Text = "Cost Centre";
      this.lblDepartment.TextAlign = ContentAlignment.MiddleLeft;
      this.lblRaiseInvoiceOn.Location = new System.Drawing.Point(423, 130);
      this.lblRaiseInvoiceOn.Name = "lblRaiseInvoiceOn";
      this.lblRaiseInvoiceOn.Size = new Size(99, 16);
      this.lblRaiseInvoiceOn.TabIndex = 5;
      this.lblRaiseInvoiceOn.Text = "Raise Inv Date:";
      this.lblRaiseInvoiceOn.TextAlign = ContentAlignment.MiddleLeft;
      this.lblRaiseInvoiceOn.Visible = false;
      this.gpbCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.gpbCharges.Controls.Add((Control) this.chkShowJobCharges);
      this.gpbCharges.Controls.Add((Control) this.GroupBox6);
      this.gpbCharges.Controls.Add((Control) this.lblContractPerVisit);
      this.gpbCharges.Controls.Add((Control) this.lblOR);
      this.gpbCharges.Controls.Add((Control) this.Label30);
      this.gpbCharges.Controls.Add((Control) this.lblQuotePercentageTotal);
      this.gpbCharges.Controls.Add((Control) this.lblEquals);
      this.gpbCharges.Controls.Add((Control) this.GroupBox9);
      this.gpbCharges.Controls.Add((Control) this.lblPercent);
      this.gpbCharges.Controls.Add((Control) this.txtPercentOfQuote);
      this.gpbCharges.Controls.Add((Control) this.rdoPercentageOfQuoteValue);
      this.gpbCharges.Controls.Add((Control) this.txtCharge);
      this.gpbCharges.Controls.Add((Control) this.rdoChargeOther);
      this.gpbCharges.Controls.Add((Control) this.rdoJobValue);
      this.gpbCharges.Controls.Add((Control) this.txtJobValue);
      this.gpbCharges.Location = new System.Drawing.Point(8, 425);
      this.gpbCharges.Name = "gpbCharges";
      this.gpbCharges.Size = new Size(603, 221);
      this.gpbCharges.TabIndex = 3;
      this.gpbCharges.TabStop = false;
      this.gpbCharges.Text = "Charges";
      this.chkShowJobCharges.AutoSize = true;
      this.chkShowJobCharges.Location = new System.Drawing.Point(41, 187);
      this.chkShowJobCharges.Name = "chkShowJobCharges";
      this.chkShowJobCharges.Size = new Size(183, 17);
      this.chkShowJobCharges.TabIndex = 17;
      this.chkShowJobCharges.Text = "Show All Charges From Job";
      this.chkShowJobCharges.UseVisualStyleBackColor = true;
      this.GroupBox6.Controls.Add((Control) this.Label82);
      this.GroupBox6.Controls.Add((Control) this.Label78);
      this.GroupBox6.Controls.Add((Control) this.Label77);
      this.GroupBox6.Controls.Add((Control) this.txtProfitPerc);
      this.GroupBox6.Controls.Add((Control) this.txtProfit);
      this.GroupBox6.Controls.Add((Control) this.CostsToOption1);
      this.GroupBox6.Controls.Add((Control) this.txtCosts);
      this.GroupBox6.Controls.Add((Control) this.CostsToOption3);
      this.GroupBox6.Controls.Add((Control) this.txtSale);
      this.GroupBox6.Controls.Add((Control) this.CostsToOption2);
      this.GroupBox6.Location = new System.Drawing.Point(8, 93);
      this.GroupBox6.Name = "GroupBox6";
      this.GroupBox6.Size = new Size(583, 82);
      this.GroupBox6.TabIndex = 16;
      this.GroupBox6.TabStop = false;
      this.GroupBox6.Text = "Costs To:";
      this.Label82.Location = new System.Drawing.Point(266, 17);
      this.Label82.Name = "Label82";
      this.Label82.Size = new Size(101, 16);
      this.Label82.TabIndex = 23;
      this.Label82.Text = "Sale";
      this.Label78.Location = new System.Drawing.Point(266, 57);
      this.Label78.Name = "Label78";
      this.Label78.Size = new Size(101, 19);
      this.Label78.TabIndex = 22;
      this.Label78.Text = "Profit";
      this.Label77.Location = new System.Drawing.Point(266, 36);
      this.Label77.Name = "Label77";
      this.Label77.Size = new Size(101, 20);
      this.Label77.TabIndex = 21;
      this.Label77.Text = "Costs";
      this.txtProfitPerc.Location = new System.Drawing.Point(501, 57);
      this.txtProfitPerc.Name = "txtProfitPerc";
      this.txtProfitPerc.ReadOnly = true;
      this.txtProfitPerc.Size = new Size(76, 21);
      this.txtProfitPerc.TabIndex = 20;
      this.txtProfit.Location = new System.Drawing.Point(373, 57);
      this.txtProfit.Name = "txtProfit";
      this.txtProfit.ReadOnly = true;
      this.txtProfit.Size = new Size(120, 21);
      this.txtProfit.TabIndex = 19;
      this.CostsToOption1.AutoSize = true;
      this.CostsToOption1.Location = new System.Drawing.Point(33, 16);
      this.CostsToOption1.Name = "CostsToOption1";
      this.CostsToOption1.Size = new Size(74, 17);
      this.CostsToOption1.TabIndex = 13;
      this.CostsToOption1.TabStop = true;
      this.CostsToOption1.Text = "Contract";
      this.CostsToOption1.UseVisualStyleBackColor = true;
      this.txtCosts.Location = new System.Drawing.Point(373, 34);
      this.txtCosts.Name = "txtCosts";
      this.txtCosts.ReadOnly = true;
      this.txtCosts.Size = new Size(120, 21);
      this.txtCosts.TabIndex = 18;
      this.CostsToOption3.AutoSize = true;
      this.CostsToOption3.Location = new System.Drawing.Point(33, 62);
      this.CostsToOption3.Name = "CostsToOption3";
      this.CostsToOption3.Size = new Size(77, 17);
      this.CostsToOption3.TabIndex = 15;
      this.CostsToOption3.TabStop = true;
      this.CostsToOption3.Text = "Warranty";
      this.CostsToOption3.UseVisualStyleBackColor = true;
      this.txtSale.Location = new System.Drawing.Point(373, 12);
      this.txtSale.Name = "txtSale";
      this.txtSale.ReadOnly = true;
      this.txtSale.Size = new Size(120, 21);
      this.txtSale.TabIndex = 17;
      this.CostsToOption2.AutoSize = true;
      this.CostsToOption2.Location = new System.Drawing.Point(33, 39);
      this.CostsToOption2.Name = "CostsToOption2";
      this.CostsToOption2.Size = new Size(91, 17);
      this.CostsToOption2.TabIndex = 14;
      this.CostsToOption2.TabStop = true;
      this.CostsToOption2.Text = "Chargeable";
      this.CostsToOption2.UseVisualStyleBackColor = true;
      this.lblContractPerVisit.BackColor = SystemColors.Info;
      this.lblContractPerVisit.BorderStyle = BorderStyle.FixedSingle;
      this.lblContractPerVisit.Location = new System.Drawing.Point(507, 14);
      this.lblContractPerVisit.Name = "lblContractPerVisit";
      this.lblContractPerVisit.Size = new Size(85, 56);
      this.lblContractPerVisit.TabIndex = 3;
      this.lblContractPerVisit.Text = "Contract Job - Invoicing Per Visit";
      this.lblContractPerVisit.Visible = false;
      this.lblOR.Location = new System.Drawing.Point(8, 58);
      this.lblOR.Name = "lblOR";
      this.lblOR.Size = new Size(27, 26);
      this.lblOR.TabIndex = 5;
      this.lblOR.Text = "OR";
      this.Label30.Location = new System.Drawing.Point(8, 34);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(27, 18);
      this.Label30.TabIndex = 2;
      this.Label30.Text = "OR";
      this.lblQuotePercentageTotal.Location = new System.Drawing.Point(537, 73);
      this.lblQuotePercentageTotal.Name = "lblQuotePercentageTotal";
      this.lblQuotePercentageTotal.Size = new Size(34, 16);
      this.lblQuotePercentageTotal.TabIndex = 11;
      this.lblQuotePercentageTotal.Text = "N/A";
      this.lblEquals.Location = new System.Drawing.Point(522, 73);
      this.lblEquals.Name = "lblEquals";
      this.lblEquals.Size = new Size(24, 16);
      this.lblEquals.TabIndex = 10;
      this.lblEquals.Text = "=";
      this.GroupBox9.Controls.Add((Control) this.rbStandard);
      this.GroupBox9.Controls.Add((Control) this.rbSite);
      this.GroupBox9.Location = new System.Drawing.Point(354, 177);
      this.GroupBox9.Name = "GroupBox9";
      this.GroupBox9.Size = new Size(238, 31);
      this.GroupBox9.TabIndex = 83;
      this.GroupBox9.TabStop = false;
      this.GroupBox9.Visible = false;
      this.rbStandard.AutoSize = true;
      this.rbStandard.Checked = true;
      this.rbStandard.Location = new System.Drawing.Point(114, 10);
      this.rbStandard.Name = "rbStandard";
      this.rbStandard.Size = new Size(123, 17);
      this.rbStandard.TabIndex = 1;
      this.rbStandard.TabStop = true;
      this.rbStandard.Text = "Standard Markup";
      this.rbStandard.UseVisualStyleBackColor = true;
      this.rbSite.AutoSize = true;
      this.rbSite.Location = new System.Drawing.Point(11, 11);
      this.rbSite.Name = "rbSite";
      this.rbSite.Size = new Size(95, 17);
      this.rbSite.TabIndex = 0;
      this.rbSite.Text = "Site markup";
      this.rbSite.UseVisualStyleBackColor = true;
      this.lblPercent.Location = new System.Drawing.Point(506, 73);
      this.lblPercent.Name = "lblPercent";
      this.lblPercent.Size = new Size(24, 16);
      this.lblPercent.TabIndex = 9;
      this.lblPercent.Text = "%";
      this.txtPercentOfQuote.Location = new System.Drawing.Point(381, 69);
      this.txtPercentOfQuote.Name = "txtPercentOfQuote";
      this.txtPercentOfQuote.Size = new Size(120, 21);
      this.txtPercentOfQuote.TabIndex = 8;
      this.rdoPercentageOfQuoteValue.Location = new System.Drawing.Point(41, 66);
      this.rdoPercentageOfQuoteValue.Name = "rdoPercentageOfQuoteValue";
      this.rdoPercentageOfQuoteValue.Size = new Size(175, 24);
      this.rdoPercentageOfQuoteValue.TabIndex = 7;
      this.rdoPercentageOfQuoteValue.Text = "Charge % of Quote Value";
      this.txtCharge.Location = new System.Drawing.Point(381, 44);
      this.txtCharge.Name = "txtCharge";
      this.txtCharge.ReadOnly = true;
      this.txtCharge.Size = new Size(120, 21);
      this.txtCharge.TabIndex = 6;
      this.rdoChargeOther.Location = new System.Drawing.Point(41, 41);
      this.rdoChargeOther.Name = "rdoChargeOther";
      this.rdoChargeOther.Size = new Size(171, 24);
      this.rdoChargeOther.TabIndex = 4;
      this.rdoChargeOther.Text = "Charge Other";
      this.rdoJobValue.Location = new System.Drawing.Point(41, 16);
      this.rdoJobValue.Name = "rdoJobValue";
      this.rdoJobValue.Size = new Size(149, 24);
      this.rdoJobValue.TabIndex = 0;
      this.rdoJobValue.Text = "Charge Visit Value";
      this.txtJobValue.Location = new System.Drawing.Point(381, 19);
      this.txtJobValue.Name = "txtJobValue";
      this.txtJobValue.ReadOnly = true;
      this.txtJobValue.Size = new Size(120, 21);
      this.txtJobValue.TabIndex = 1;
      this.gpbAdditionalCharges.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbAdditionalCharges.Controls.Add((Control) this.lblAdditionalCharge);
      this.gpbAdditionalCharges.Controls.Add((Control) this.btnAddAdditionalCharge);
      this.gpbAdditionalCharges.Controls.Add((Control) this.txtAdditionalCharge);
      this.gpbAdditionalCharges.Controls.Add((Control) this.btnRemoveAdditionalCharge);
      this.gpbAdditionalCharges.Controls.Add((Control) this.txtAdditionalChargeDescription);
      this.gpbAdditionalCharges.Controls.Add((Control) this.lblDescription);
      this.gpbAdditionalCharges.Controls.Add((Control) this.txtAdditionalChargeTotal);
      this.gpbAdditionalCharges.Controls.Add((Control) this.Label29);
      this.gpbAdditionalCharges.Controls.Add((Control) this.dgAdditionalCharges);
      this.gpbAdditionalCharges.Location = new System.Drawing.Point(617, 184);
      this.gpbAdditionalCharges.Name = "gpbAdditionalCharges";
      this.gpbAdditionalCharges.Size = new Size(622, 233);
      this.gpbAdditionalCharges.TabIndex = 5;
      this.gpbAdditionalCharges.TabStop = false;
      this.gpbAdditionalCharges.Text = "Additional Charges";
      this.lblAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblAdditionalCharge.Location = new System.Drawing.Point(8, 206);
      this.lblAdditionalCharge.Name = "lblAdditionalCharge";
      this.lblAdditionalCharge.Size = new Size(74, 20);
      this.lblAdditionalCharge.TabIndex = 9;
      this.lblAdditionalCharge.Text = "Charge";
      this.btnAddAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddAdditionalCharge.Location = new System.Drawing.Point(539, 204);
      this.btnAddAdditionalCharge.Name = "btnAddAdditionalCharge";
      this.btnAddAdditionalCharge.Size = new Size(75, 23);
      this.btnAddAdditionalCharge.TabIndex = 8;
      this.btnAddAdditionalCharge.Text = "Add";
      this.btnAddAdditionalCharge.UseVisualStyleBackColor = true;
      this.txtAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtAdditionalCharge.Location = new System.Drawing.Point(88, 203);
      this.txtAdditionalCharge.Name = "txtAdditionalCharge";
      this.txtAdditionalCharge.Size = new Size(96, 21);
      this.txtAdditionalCharge.TabIndex = 7;
      this.btnRemoveAdditionalCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveAdditionalCharge.Location = new System.Drawing.Point(8, 129);
      this.btnRemoveAdditionalCharge.Name = "btnRemoveAdditionalCharge";
      this.btnRemoveAdditionalCharge.Size = new Size(75, 23);
      this.btnRemoveAdditionalCharge.TabIndex = 1;
      this.btnRemoveAdditionalCharge.Text = "Remove";
      this.btnRemoveAdditionalCharge.UseVisualStyleBackColor = true;
      this.txtAdditionalChargeDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAdditionalChargeDescription.Location = new System.Drawing.Point(88, 157);
      this.txtAdditionalChargeDescription.Multiline = true;
      this.txtAdditionalChargeDescription.Name = "txtAdditionalChargeDescription";
      this.txtAdditionalChargeDescription.Size = new Size(526, 40);
      this.txtAdditionalChargeDescription.TabIndex = 5;
      this.lblDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblDescription.Location = new System.Drawing.Point(8, 161);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(74, 23);
      this.lblDescription.TabIndex = 4;
      this.lblDescription.Text = "Description";
      this.txtAdditionalChargeTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtAdditionalChargeTotal.Location = new System.Drawing.Point(541, 131);
      this.txtAdditionalChargeTotal.Name = "txtAdditionalChargeTotal";
      this.txtAdditionalChargeTotal.ReadOnly = true;
      this.txtAdditionalChargeTotal.Size = new Size(71, 21);
      this.txtAdditionalChargeTotal.TabIndex = 3;
      this.Label29.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label29.Location = new System.Drawing.Point(492, 131);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(40, 23);
      this.Label29.TabIndex = 2;
      this.Label29.Text = "Total";
      this.Label29.TextAlign = ContentAlignment.MiddleLeft;
      this.dgAdditionalCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAdditionalCharges.DataMember = "";
      this.dgAdditionalCharges.HeaderForeColor = SystemColors.ControlText;
      this.dgAdditionalCharges.Location = new System.Drawing.Point(8, 20);
      this.dgAdditionalCharges.Name = "dgAdditionalCharges";
      this.dgAdditionalCharges.Size = new Size(606, 109);
      this.dgAdditionalCharges.TabIndex = 0;
      this.gpbPartsAndProducts.Controls.Add((Control) this.txtPartsMarkUp);
      this.gpbPartsAndProducts.Controls.Add((Control) this.chkPartsSelectAll);
      this.gpbPartsAndProducts.Controls.Add((Control) this.txtPartProductCost);
      this.gpbPartsAndProducts.Controls.Add((Control) this.txtPartsProductTotal);
      this.gpbPartsAndProducts.Controls.Add((Control) this.Label28);
      this.gpbPartsAndProducts.Controls.Add((Control) this.lblPPTotalCost);
      this.gpbPartsAndProducts.Controls.Add((Control) this.lblPartsMarkUp);
      this.gpbPartsAndProducts.Controls.Add((Control) this.dgPartsProductCharging);
      this.gpbPartsAndProducts.Location = new System.Drawing.Point(8, 184);
      this.gpbPartsAndProducts.Name = "gpbPartsAndProducts";
      this.gpbPartsAndProducts.Size = new Size(603, 233);
      this.gpbPartsAndProducts.TabIndex = 1;
      this.gpbPartsAndProducts.TabStop = false;
      this.gpbPartsAndProducts.Text = "Parts && Products";
      this.txtPartsMarkUp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPartsMarkUp.Enabled = false;
      this.txtPartsMarkUp.Location = new System.Drawing.Point(405, 203);
      this.txtPartsMarkUp.Name = "txtPartsMarkUp";
      this.txtPartsMarkUp.Size = new Size(37, 21);
      this.txtPartsMarkUp.TabIndex = 81;
      this.txtPartsMarkUp.Visible = false;
      this.chkPartsSelectAll.AutoCheck = false;
      this.chkPartsSelectAll.AutoSize = true;
      this.chkPartsSelectAll.Location = new System.Drawing.Point(6, 205);
      this.chkPartsSelectAll.Name = "chkPartsSelectAll";
      this.chkPartsSelectAll.Size = new Size(79, 17);
      this.chkPartsSelectAll.TabIndex = 80;
      this.chkPartsSelectAll.Text = "Select All";
      this.chkPartsSelectAll.UseVisualStyleBackColor = true;
      this.txtPartProductCost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPartProductCost.Location = new System.Drawing.Point(252, 203);
      this.txtPartProductCost.Name = "txtPartProductCost";
      this.txtPartProductCost.ReadOnly = true;
      this.txtPartProductCost.Size = new Size(71, 21);
      this.txtPartProductCost.TabIndex = 2;
      this.txtPartsProductTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPartsProductTotal.Location = new System.Drawing.Point(525, 202);
      this.txtPartsProductTotal.Name = "txtPartsProductTotal";
      this.txtPartsProductTotal.ReadOnly = true;
      this.txtPartsProductTotal.Size = new Size(71, 21);
      this.txtPartsProductTotal.TabIndex = 4;
      this.Label28.Location = new System.Drawing.Point(448, 202);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(72, 21);
      this.Label28.TabIndex = 3;
      this.Label28.Text = "Total Price";
      this.Label28.TextAlign = ContentAlignment.MiddleLeft;
      this.lblPPTotalCost.Location = new System.Drawing.Point(174, 203);
      this.lblPPTotalCost.Name = "lblPPTotalCost";
      this.lblPPTotalCost.Size = new Size(72, 21);
      this.lblPPTotalCost.TabIndex = 79;
      this.lblPPTotalCost.Text = "Total Cost";
      this.lblPPTotalCost.TextAlign = ContentAlignment.MiddleLeft;
      this.lblPartsMarkUp.Location = new System.Drawing.Point(329, 202);
      this.lblPartsMarkUp.Name = "lblPartsMarkUp";
      this.lblPartsMarkUp.Size = new Size(70, 21);
      this.lblPartsMarkUp.TabIndex = 82;
      this.lblPartsMarkUp.Text = "Mark Up %";
      this.lblPartsMarkUp.TextAlign = ContentAlignment.MiddleLeft;
      this.lblPartsMarkUp.Visible = false;
      this.dgPartsProductCharging.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartsProductCharging.DataMember = "";
      this.dgPartsProductCharging.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsProductCharging.Location = new System.Drawing.Point(9, 16);
      this.dgPartsProductCharging.Name = "dgPartsProductCharging";
      this.dgPartsProductCharging.Size = new Size(587, 181);
      this.dgPartsProductCharging.TabIndex = 0;
      this.gpbTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbTimesheets.Controls.Add((Control) this.chkTimesheetSelectAll);
      this.gpbTimesheets.Controls.Add((Control) this.txtEngineerCostTotal);
      this.gpbTimesheets.Controls.Add((Control) this.txtTimesheetTotal);
      this.gpbTimesheets.Controls.Add((Control) this.Label27);
      this.gpbTimesheets.Controls.Add((Control) this.Label32);
      this.gpbTimesheets.Controls.Add((Control) this.dgTimesheetCharges);
      this.gpbTimesheets.Location = new System.Drawing.Point(617, 8);
      this.gpbTimesheets.Name = "gpbTimesheets";
      this.gpbTimesheets.Size = new Size(622, 170);
      this.gpbTimesheets.TabIndex = 4;
      this.gpbTimesheets.TabStop = false;
      this.gpbTimesheets.Text = "Timesheets";
      this.chkTimesheetSelectAll.AutoCheck = false;
      this.chkTimesheetSelectAll.AutoSize = true;
      this.chkTimesheetSelectAll.Location = new System.Drawing.Point(6, 142);
      this.chkTimesheetSelectAll.Name = "chkTimesheetSelectAll";
      this.chkTimesheetSelectAll.Size = new Size(79, 17);
      this.chkTimesheetSelectAll.TabIndex = 81;
      this.chkTimesheetSelectAll.Text = "Select All";
      this.chkTimesheetSelectAll.UseVisualStyleBackColor = true;
      this.txtEngineerCostTotal.Location = new System.Drawing.Point(382, 140);
      this.txtEngineerCostTotal.Name = "txtEngineerCostTotal";
      this.txtEngineerCostTotal.ReadOnly = true;
      this.txtEngineerCostTotal.Size = new Size(71, 21);
      this.txtEngineerCostTotal.TabIndex = 2;
      this.txtTimesheetTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTimesheetTotal.Location = new System.Drawing.Point(540, 140);
      this.txtTimesheetTotal.Name = "txtTimesheetTotal";
      this.txtTimesheetTotal.ReadOnly = true;
      this.txtTimesheetTotal.Size = new Size(71, 21);
      this.txtTimesheetTotal.TabIndex = 4;
      this.Label27.Location = new System.Drawing.Point(462, 140);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(72, 21);
      this.Label27.TabIndex = 3;
      this.Label27.Text = "Total Price";
      this.Label27.TextAlign = ContentAlignment.MiddleLeft;
      this.Label32.Location = new System.Drawing.Point(308, 139);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(68, 23);
      this.Label32.TabIndex = 1;
      this.Label32.Text = "Total Cost";
      this.Label32.TextAlign = ContentAlignment.MiddleLeft;
      this.dgTimesheetCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTimesheetCharges.DataMember = "";
      this.dgTimesheetCharges.HeaderForeColor = SystemColors.ControlText;
      this.dgTimesheetCharges.Location = new System.Drawing.Point(6, 17);
      this.dgTimesheetCharges.Name = "dgTimesheetCharges";
      this.dgTimesheetCharges.Size = new Size(606, 118);
      this.dgTimesheetCharges.TabIndex = 0;
      this.gpbScheduleOfRates.Controls.Add((Control) this.btnAddSoR);
      this.gpbScheduleOfRates.Controls.Add((Control) this.txtScheduleOfRatesTotal);
      this.gpbScheduleOfRates.Controls.Add((Control) this.dgScheduleOfRateCharges);
      this.gpbScheduleOfRates.Controls.Add((Control) this.Label26);
      this.gpbScheduleOfRates.Location = new System.Drawing.Point(8, 8);
      this.gpbScheduleOfRates.Name = "gpbScheduleOfRates";
      this.gpbScheduleOfRates.Size = new Size(603, 170);
      this.gpbScheduleOfRates.TabIndex = 0;
      this.gpbScheduleOfRates.TabStop = false;
      this.gpbScheduleOfRates.Text = "Schedule Of Rates";
      this.btnAddSoR.Location = new System.Drawing.Point(6, 141);
      this.btnAddSoR.Name = "btnAddSoR";
      this.btnAddSoR.Size = new Size(75, 23);
      this.btnAddSoR.TabIndex = 1;
      this.btnAddSoR.Text = "Add";
      this.txtScheduleOfRatesTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtScheduleOfRatesTotal.Location = new System.Drawing.Point(521, 143);
      this.txtScheduleOfRatesTotal.Name = "txtScheduleOfRatesTotal";
      this.txtScheduleOfRatesTotal.ReadOnly = true;
      this.txtScheduleOfRatesTotal.Size = new Size(71, 21);
      this.txtScheduleOfRatesTotal.TabIndex = 3;
      this.dgScheduleOfRateCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgScheduleOfRateCharges.DataMember = "";
      this.dgScheduleOfRateCharges.HeaderForeColor = SystemColors.ControlText;
      this.dgScheduleOfRateCharges.Location = new System.Drawing.Point(8, 17);
      this.dgScheduleOfRateCharges.Name = "dgScheduleOfRateCharges";
      this.dgScheduleOfRateCharges.Size = new Size(585, 121);
      this.dgScheduleOfRateCharges.TabIndex = 0;
      this.Label26.Location = new System.Drawing.Point(481, 141);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(39, 23);
      this.Label26.TabIndex = 2;
      this.Label26.Text = "Total";
      this.Label26.TextAlign = ContentAlignment.MiddleLeft;
      this.tpDocuments.Location = new System.Drawing.Point(4, 22);
      this.tpDocuments.Name = "tpDocuments";
      this.tpDocuments.Size = new Size(1247, 652);
      this.tpDocuments.TabIndex = 9;
      this.tpDocuments.Text = "Documents";
      this.tpDocuments.UseVisualStyleBackColor = true;
      this.tpPhotos.Controls.Add((Control) this.flPhotos);
      this.tpPhotos.Location = new System.Drawing.Point(4, 22);
      this.tpPhotos.Name = "tpPhotos";
      this.tpPhotos.Size = new Size(1247, 652);
      this.tpPhotos.TabIndex = 10;
      this.tpPhotos.Text = "Photos";
      this.tpPhotos.UseVisualStyleBackColor = true;
      this.flPhotos.AutoScroll = true;
      this.flPhotos.AutoSize = true;
      this.flPhotos.Dock = DockStyle.Fill;
      this.flPhotos.Location = new System.Drawing.Point(0, 0);
      this.flPhotos.Name = "flPhotos";
      this.flPhotos.Size = new Size(1247, 652);
      this.flPhotos.TabIndex = 2;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(8, 750);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(64, 23);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(1183, 750);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(64, 23);
      this.btnSave.TabIndex = 6;
      this.btnSave.Text = "Save";
      this.cbxVisitLockDown.BackColor = SystemColors.Info;
      this.cbxVisitLockDown.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbxVisitLockDown.Location = new System.Drawing.Point(8, 32);
      this.cbxVisitLockDown.Name = "cbxVisitLockDown";
      this.cbxVisitLockDown.Size = new Size(296, 24);
      this.cbxVisitLockDown.TabIndex = 5;
      this.cbxVisitLockDown.Text = "Visit locked down and ready for charging";
      this.cbxVisitLockDown.UseVisualStyleBackColor = false;
      this.lblStatusWarning.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblStatusWarning.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblStatusWarning.ForeColor = Color.Red;
      this.lblStatusWarning.Location = new System.Drawing.Point(312, 32);
      this.lblStatusWarning.Name = "lblStatusWarning";
      this.lblStatusWarning.Size = new Size(736, 23);
      this.lblStatusWarning.TabIndex = 6;
      this.lblStatusWarning.Text = "Reversing this status will result in the lost of charge changes";
      this.lblStatusWarning.TextAlign = ContentAlignment.MiddleLeft;
      this.lblStatusWarning.Visible = false;
      this.btnOrders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnOrders.Location = new System.Drawing.Point(148, 750);
      this.btnOrders.Name = "btnOrders";
      this.btnOrders.Size = new Size(64, 23);
      this.btnOrders.TabIndex = 4;
      this.btnOrders.Text = "Orders";
      this.btnInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnInvoice.Location = new System.Drawing.Point(289, 750);
      this.btnInvoice.Name = "btnInvoice";
      this.btnInvoice.Size = new Size(64, 23);
      this.btnInvoice.TabIndex = 5;
      this.btnInvoice.Text = "Invoice";
      this.btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrint.Location = new System.Drawing.Point(1064, 750);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(103, 23);
      this.btnPrint.TabIndex = 7;
      this.btnPrint.Text = "Print QC";
      this.PrintMenu.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.mnuGasSafetyInspectionBoilerServiceRecord
      });
      this.PrintMenu.Name = "PrintMenu";
      this.PrintMenu.Size = new Size(302, 26);
      this.mnuGasSafetyInspectionBoilerServiceRecord.Name = "mnuGasSafetyInspectionBoilerServiceRecord";
      this.mnuGasSafetyInspectionBoilerServiceRecord.Size = new Size(301, 22);
      this.mnuGasSafetyInspectionBoilerServiceRecord.Text = "Gas Safety Inspection/Boiler Service Record";
      this.txtCurrentContract.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtCurrentContract.Location = new System.Drawing.Point(1116, 38);
      this.txtCurrentContract.Name = "txtCurrentContract";
      this.txtCurrentContract.ReadOnly = true;
      this.txtCurrentContract.Size = new Size(135, 21);
      this.txtCurrentContract.TabIndex = 27;
      this.Label39.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label39.Location = new System.Drawing.Point(1054, 39);
      this.Label39.Name = "Label39";
      this.Label39.Size = new Size(63, 16);
      this.Label39.TabIndex = 26;
      this.Label39.Text = "Contract:";
      this.btnPrintGSR.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrintGSR.Location = new System.Drawing.Point(1064, 750);
      this.btnPrintGSR.Name = "btnPrintGSR";
      this.btnPrintGSR.Size = new Size(105, 23);
      this.btnPrintGSR.TabIndex = 29;
      this.btnPrintGSR.Text = "Print GSR";
      this.btnPrintSVR.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrintSVR.Location = new System.Drawing.Point(1057, 750);
      this.btnPrintSVR.Name = "btnPrintSVR";
      this.btnPrintSVR.Size = new Size(112, 23);
      this.btnPrintSVR.TabIndex = 30;
      this.btnPrintSVR.Text = "Print...";
      this.btnJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnJob.Location = new System.Drawing.Point(78, 750);
      this.btnJob.Name = "btnJob";
      this.btnJob.Size = new Size(64, 23);
      this.btnJob.TabIndex = 31;
      this.btnJob.Text = "Job";
      this.lblRechargeTicked.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblRechargeTicked.ForeColor = Color.Red;
      this.lblRechargeTicked.Location = new System.Drawing.Point(75, 4);
      this.lblRechargeTicked.Name = "lblRechargeTicked";
      this.lblRechargeTicked.Size = new Size(457, 23);
      this.lblRechargeTicked.TabIndex = 32;
      this.lblRechargeTicked.Text = "Recharge is Selected";
      this.lblRechargeTicked.TextAlign = ContentAlignment.MiddleLeft;
      this.lblRechargeTicked.Visible = false;
      this.btnShowVisits.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnShowVisits.Location = new System.Drawing.Point(687, 750);
      this.btnShowVisits.Name = "btnShowVisits";
      this.btnShowVisits.Size = new Size(99, 23);
      this.btnShowVisits.TabIndex = 33;
      this.btnShowVisits.Text = "Show History";
      this.btnShowVisits.UseVisualStyleBackColor = true;
      this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.BottomToolStripPanel.Name = "BottomToolStripPanel";
      this.BottomToolStripPanel.Orientation = Orientation.Horizontal;
      this.BottomToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
      this.BottomToolStripPanel.Size = new Size(0, 0);
      this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.TopToolStripPanel.Name = "TopToolStripPanel";
      this.TopToolStripPanel.Orientation = Orientation.Horizontal;
      this.TopToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
      this.TopToolStripPanel.Size = new Size(0, 0);
      this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.RightToolStripPanel.Name = "RightToolStripPanel";
      this.RightToolStripPanel.Orientation = Orientation.Horizontal;
      this.RightToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
      this.RightToolStripPanel.Size = new Size(0, 0);
      this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.LeftToolStripPanel.Name = "LeftToolStripPanel";
      this.LeftToolStripPanel.Orientation = Orientation.Horizontal;
      this.LeftToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
      this.LeftToolStripPanel.Size = new Size(0, 0);
      this.ContentPanel.Size = new Size(150, 150);
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button1.Location = new System.Drawing.Point(218, 750);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(64, 23);
      this.Button1.TabIndex = 34;
      this.Button1.Text = "Cust";
      this.txtCustEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtCustEmail.BorderStyle = BorderStyle.None;
      this.txtCustEmail.Location = new System.Drawing.Point(718, 8);
      this.txtCustEmail.Name = "txtCustEmail";
      this.txtCustEmail.ReadOnly = true;
      this.txtCustEmail.Size = new Size(533, 14);
      this.txtCustEmail.TabIndex = 36;
      this.SVRs.Items.AddRange(new ToolStripItem[14]
      {
        (ToolStripItem) this.AllGasPaperworkToolStripMenuItem,
        (ToolStripItem) this.svrmenu,
        (ToolStripItem) this.JobSheetMenu,
        (ToolStripItem) this.DomesticGSRToolStripMenuItem,
        (ToolStripItem) this.WarningNoticeToolStripMenuItem,
        (ToolStripItem) this.CommercialGSRToolStripMenuItem,
        (ToolStripItem) this.QCResultsToolStripMenuItem,
        (ToolStripItem) this.ElectricalMinorWorksToolStripMenuItem,
        (ToolStripItem) this.CommercialCateringToolStripMenuItem,
        (ToolStripItem) this.SaffronUnventedWorkshhetToolStripMenuItem,
        (ToolStripItem) this.PropertyMaintenanceWorksheetToolStripMenuItem,
        (ToolStripItem) this.ASHPWorksheetToolStripMenuItem,
        (ToolStripItem) this.CommissioningChecklistToolStripMenuItem,
        (ToolStripItem) this.HotWorksPermitToolStripMenuItem
      });
      this.SVRs.Name = "SVRs";
      this.SVRs.Size = new Size(251, 312);
      this.AllGasPaperworkToolStripMenuItem.Name = "AllGasPaperworkToolStripMenuItem";
      this.AllGasPaperworkToolStripMenuItem.Size = new Size(250, 22);
      this.AllGasPaperworkToolStripMenuItem.Text = "All Safety Paperwork";
      this.svrmenu.Name = "svrmenu";
      this.svrmenu.Size = new Size(250, 22);
      this.svrmenu.Text = "SVR";
      this.JobSheetMenu.Name = "JobSheetMenu";
      this.JobSheetMenu.Size = new Size(250, 22);
      this.JobSheetMenu.Text = "Job Sheet";
      this.DomesticGSRToolStripMenuItem.Name = "DomesticGSRToolStripMenuItem";
      this.DomesticGSRToolStripMenuItem.Size = new Size(250, 22);
      this.DomesticGSRToolStripMenuItem.Text = "Domestic LSR";
      this.WarningNoticeToolStripMenuItem.Name = "WarningNoticeToolStripMenuItem";
      this.WarningNoticeToolStripMenuItem.Size = new Size(250, 22);
      this.WarningNoticeToolStripMenuItem.Text = "Warning Notice";
      this.CommercialGSRToolStripMenuItem.Name = "CommercialGSRToolStripMenuItem";
      this.CommercialGSRToolStripMenuItem.Size = new Size(250, 22);
      this.CommercialGSRToolStripMenuItem.Text = "Commercial LSR";
      this.QCResultsToolStripMenuItem.Name = "QCResultsToolStripMenuItem";
      this.QCResultsToolStripMenuItem.Size = new Size(250, 22);
      this.QCResultsToolStripMenuItem.Text = "QC Results";
      this.ElectricalMinorWorksToolStripMenuItem.Name = "ElectricalMinorWorksToolStripMenuItem";
      this.ElectricalMinorWorksToolStripMenuItem.Size = new Size(250, 22);
      this.ElectricalMinorWorksToolStripMenuItem.Text = "Electrical Minor Works";
      this.CommercialCateringToolStripMenuItem.Name = "CommercialCateringToolStripMenuItem";
      this.CommercialCateringToolStripMenuItem.Size = new Size(250, 22);
      this.CommercialCateringToolStripMenuItem.Text = "Commercial Catering";
      this.SaffronUnventedWorkshhetToolStripMenuItem.Name = "SaffronUnventedWorkshhetToolStripMenuItem";
      this.SaffronUnventedWorkshhetToolStripMenuItem.Size = new Size(250, 22);
      this.SaffronUnventedWorkshhetToolStripMenuItem.Text = "Saffron Unvented Worksheet";
      this.PropertyMaintenanceWorksheetToolStripMenuItem.Name = "PropertyMaintenanceWorksheetToolStripMenuItem";
      this.PropertyMaintenanceWorksheetToolStripMenuItem.Size = new Size(250, 22);
      this.PropertyMaintenanceWorksheetToolStripMenuItem.Text = "Property Maintenance Worksheet";
      this.ASHPWorksheetToolStripMenuItem.Name = "ASHPWorksheetToolStripMenuItem";
      this.ASHPWorksheetToolStripMenuItem.Size = new Size(250, 22);
      this.ASHPWorksheetToolStripMenuItem.Text = "Waveney ASHP Worksheet";
      this.CommissioningChecklistToolStripMenuItem.Name = "CommissioningChecklistToolStripMenuItem";
      this.CommissioningChecklistToolStripMenuItem.Size = new Size(250, 22);
      this.CommissioningChecklistToolStripMenuItem.Text = "Commissioning Checklist";
      this.HotWorksPermitToolStripMenuItem.Name = "HotWorksPermitToolStripMenuItem";
      this.HotWorksPermitToolStripMenuItem.Size = new Size(250, 22);
      this.HotWorksPermitToolStripMenuItem.Text = "Hot Works Permit";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1255, 780);
      this.Controls.Add((Control) this.btnPrintSVR);
      this.Controls.Add((Control) this.txtCustEmail);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.btnShowVisits);
      this.Controls.Add((Control) this.lblRechargeTicked);
      this.Controls.Add((Control) this.btnJob);
      this.Controls.Add((Control) this.btnPrintGSR);
      this.Controls.Add((Control) this.txtCurrentContract);
      this.Controls.Add((Control) this.Label39);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.btnInvoice);
      this.Controls.Add((Control) this.btnOrders);
      this.Controls.Add((Control) this.lblStatusWarning);
      this.Controls.Add((Control) this.cbxVisitLockDown);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.tcWorkSheet);
      this.MinimumSize = new Size(936, 664);
      this.Name = nameof (FRMEngineerVisit);
      this.Text = "Engineer Visit";
      this.Controls.SetChildIndex((Control) this.tcWorkSheet, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.cbxVisitLockDown, 0);
      this.Controls.SetChildIndex((Control) this.lblStatusWarning, 0);
      this.Controls.SetChildIndex((Control) this.btnOrders, 0);
      this.Controls.SetChildIndex((Control) this.btnInvoice, 0);
      this.Controls.SetChildIndex((Control) this.btnPrint, 0);
      this.Controls.SetChildIndex((Control) this.Label39, 0);
      this.Controls.SetChildIndex((Control) this.txtCurrentContract, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintGSR, 0);
      this.Controls.SetChildIndex((Control) this.btnJob, 0);
      this.Controls.SetChildIndex((Control) this.lblRechargeTicked, 0);
      this.Controls.SetChildIndex((Control) this.btnShowVisits, 0);
      this.Controls.SetChildIndex((Control) this.Button1, 0);
      this.Controls.SetChildIndex((Control) this.txtCustEmail, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintSVR, 0);
      this.tcWorkSheet.ResumeLayout(false);
      this.tpMainDetails.ResumeLayout(false);
      this.tpMainDetails.PerformLayout();
      ((ISupportInitialize) this.pbCustomerSignature).EndInit();
      ((ISupportInitialize) this.pbEngineerSignature).EndInit();
      this.dgJobItems.EndInit();
      this.tpAppliances.ResumeLayout(false);
      this.gpAppliances.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.tpWorksheets.ResumeLayout(false);
      this.grpAdditionalWorksheet.ResumeLayout(false);
      this.dgAdditional.EndInit();
      this.grpAlarmInfo.ResumeLayout(false);
      this.DGSmokeComo.EndInit();
      this.grpVisitWorksheetExtended.ResumeLayout(false);
      this.grpVisitWorksheetExtended.PerformLayout();
      this.grpVisitDefects.ResumeLayout(false);
      this.dgVisitDefects.EndInit();
      this.grpApplianceWorksheet.ResumeLayout(false);
      this.dgApplianceWorkSheets.EndInit();
      this.grpVisitWorksheet.ResumeLayout(false);
      this.grpVisitWorksheet.PerformLayout();
      this.tpTimesheets.ResumeLayout(false);
      this.tpTimesheets.PerformLayout();
      this.grpTimesheets.ResumeLayout(false);
      this.grpTimesheets.PerformLayout();
      this.dgTimeSheets.EndInit();
      this.tpPartsAndProducts.ResumeLayout(false);
      this.grpAllocated.ResumeLayout(false);
      this.grpAllocated.PerformLayout();
      this.nudPartAllocatedQty.EndInit();
      this.dgPartsProductsAllocated.EndInit();
      this.grpUsed.ResumeLayout(false);
      this.grpUsed.PerformLayout();
      this.dgPartsAndProductsUsed.EndInit();
      this.nudQuantityUsed.EndInit();
      this.tpOutcomes.ResumeLayout(false);
      this.grpOutcomes.ResumeLayout(false);
      this.grpOutcomes.PerformLayout();
      this.grpSiteFuels.ResumeLayout(false);
      this.dgSiteFuel.EndInit();
      this.tpQC.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.grpQCField.ResumeLayout(false);
      this.grpQCField.PerformLayout();
      this.grpOfficeQC.ResumeLayout(false);
      this.grpOfficeQC.PerformLayout();
      this.tpCharges.ResumeLayout(false);
      this.gpbInvoice.ResumeLayout(false);
      this.gpbInvoice.PerformLayout();
      this.gpbCharges.ResumeLayout(false);
      this.gpbCharges.PerformLayout();
      this.GroupBox6.ResumeLayout(false);
      this.GroupBox6.PerformLayout();
      this.GroupBox9.ResumeLayout(false);
      this.GroupBox9.PerformLayout();
      this.gpbAdditionalCharges.ResumeLayout(false);
      this.gpbAdditionalCharges.PerformLayout();
      this.dgAdditionalCharges.EndInit();
      this.gpbPartsAndProducts.ResumeLayout(false);
      this.gpbPartsAndProducts.PerformLayout();
      this.dgPartsProductCharging.EndInit();
      this.gpbTimesheets.ResumeLayout(false);
      this.gpbTimesheets.PerformLayout();
      this.dgTimesheetCharges.EndInit();
      this.gpbScheduleOfRates.ResumeLayout(false);
      this.gpbScheduleOfRates.PerformLayout();
      this.dgScheduleOfRateCharges.EndInit();
      this.tpPhotos.ResumeLayout(false);
      this.tpPhotos.PerformLayout();
      this.PrintMenu.ResumeLayout(false);
      this.SVRs.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupJobItemsDataGrid();
      this.SetupPartsAndProductsDataGrid();
      this.SetupTimesheetDataGrid();
      this.SetupAdditionalChargeDataGrid();
      this.SetupSoRChargeDataGrid();
      this.SetupPartProductDataGrid();
      this.SetupTimeSheetChargeDataGrid();
      this.SetupVisitDefectDataGrid();
      this.SetupApplianceWorksheetDataGrid();
      this.SetupAssetDataGrid();
      this.SetupAdditionalDataGrid();
      this.SetupSmokeComoDG();
      this.SetupSiteFuelsDatagrid();
      this.EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_New_As_Object(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0))));
      this.mnuAddChecklist.MenuItems.Clear();
      DataTable table = App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.TimeSheetTypes, false).Table;
      int index = checked (table.Rows.Count - 1);
      while (index >= 0)
      {
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(table.Rows[index]["Name"], (object) "Travelling", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(table.Rows[index]["Name"], (object) "Working", false)))))
          table.Rows.RemoveAt(index);
        checked { index += -1; }
      }
      ComboBox cboTimeSheetType = this.cboTimeSheetType;
      Combo.SetUpCombo(ref cboTimeSheetType, table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboTimeSheetType = cboTimeSheetType;
      try
      {
        this.LogCalloutForm = this.get_GetParameter(1) == null ? (FRMLogCallout) null : ((UCVisitBreakdown) this.get_GetParameter(1)).OnControl.OnContol.OnForm;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LogCalloutForm = (FRMLogCallout) null;
        ProjectData.ClearProjectError();
      }
      if (this.Job.JobTypeID == 521)
        this.btnCreateServ.Visible = true;
      else
        this.btnCreateServ.Visible = false;
      if (App.IsRFT)
      {
        this.tcWorkSheet.TabPages.Remove(this.tpAppliances);
        this.tcWorkSheet.TabPages.Remove(this.tpWorksheets);
        this.tcWorkSheet.TabPages.Remove(this.tpOutcomes);
      }
      if (App.loggedInUser.Admin)
        return;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.tpMainDetails.Controls.GetEnumerator();
        while (enumerator1.MoveNext())
          ((Control) enumerator1.Current).Enabled = false;
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      this.txtOutcomeDetails.ReadOnly = true;
      this.txtNotesFromEngineer.ReadOnly = true;
      this.txtOutcomeDetails.Enabled = true;
      this.txtNotesFromEngineer.Enabled = true;
      IEnumerator enumerator2;
      try
      {
        enumerator2 = this.tpCharges.Controls.GetEnumerator();
        while (enumerator2.MoveNext())
          ((Control) enumerator2.Current).Enabled = false;
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      IEnumerator enumerator3;
      try
      {
        enumerator3 = this.tpTimesheets.Controls.GetEnumerator();
        while (enumerator3.MoveNext())
          ((Control) enumerator3.Current).Enabled = false;
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
      this.btnAddAdd.Visible = false;
      this.btnAddApplianceWorksheet.Visible = false;
      this.btnAddVisitDefect.Visible = false;
      this.btnRemoveAdd.Visible = false;
      this.btnRemoveApplianceWorkSheet.Visible = false;
      this.btnRemoveVisitDefect.Visible = false;
      this.tcWorkSheet.TabPages.Remove(this.tpQC);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    public DataView VisitDefectDataview
    {
      get
      {
        return this._VisitDefectDataview;
      }
      set
      {
        this._VisitDefectDataview = value;
        this._VisitDefectDataview.AllowNew = false;
        this._VisitDefectDataview.AllowEdit = false;
        this._VisitDefectDataview.AllowDelete = false;
        this._VisitDefectDataview.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitDefects.ToString();
        this.dgVisitDefects.DataSource = (object) this.VisitDefectDataview;
      }
    }

    private DataRow SelectedVisitDefectDataRow
    {
      get
      {
        return this.dgVisitDefects.CurrentRowIndex != -1 ? this.VisitDefectDataview[this.dgVisitDefects.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView ApplianceWorkSheetDataview
    {
      get
      {
        return this._ApplianceWorkSheetDataview;
      }
      set
      {
        this._ApplianceWorkSheetDataview = value;
        this._ApplianceWorkSheetDataview.AllowNew = false;
        this._ApplianceWorkSheetDataview.AllowEdit = false;
        this._ApplianceWorkSheetDataview.AllowDelete = false;
        this._ApplianceWorkSheetDataview.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
        this.dgApplianceWorkSheets.DataSource = (object) this.ApplianceWorkSheetDataview;
      }
    }

    public DataView AdditionalWorkSheetDataview
    {
      get
      {
        return this._AdditionalWorkSheetDataview;
      }
      set
      {
        this._AdditionalWorkSheetDataview = value;
        this._AdditionalWorkSheetDataview.AllowNew = false;
        this._AdditionalWorkSheetDataview.AllowEdit = false;
        this._AdditionalWorkSheetDataview.AllowDelete = false;
        this._AdditionalWorkSheetDataview.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
        this.dgAdditional.DataSource = (object) this.AdditionalWorkSheetDataview;
      }
    }

    public DataView SmokeComoDataview
    {
      get
      {
        return this._SmokeComoDataview;
      }
      set
      {
        this._SmokeComoDataview = value;
        this._SmokeComoDataview.AllowNew = false;
        this._SmokeComoDataview.AllowEdit = false;
        this._SmokeComoDataview.AllowDelete = false;
        this._SmokeComoDataview.Table.TableName = "Alarms";
        this.DGSmokeComo.DataSource = (object) this.SmokeComoDataview;
      }
    }

    private DataRow SelectedApplianceWorkSheetDataRow
    {
      get
      {
        return this.dgApplianceWorkSheets.CurrentRowIndex != -1 ? this.ApplianceWorkSheetDataview[this.dgApplianceWorkSheets.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataRow SelectedAdditionalWorkSheetDataRow
    {
      get
      {
        return this.dgAdditional.CurrentRowIndex != -1 ? this.AdditionalWorkSheetDataview[this.dgAdditional.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataRow SelectedSmokeComoDataRow
    {
      get
      {
        return this.DGSmokeComo.CurrentRowIndex != -1 ? this.SmokeComoDataview[this.DGSmokeComo.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public FRMLogCallout LogCalloutForm
    {
      get
      {
        return this._LogCalloutForm;
      }
      set
      {
        this._LogCalloutForm = value;
      }
    }

    public bool Updating
    {
      get
      {
        return this._updating;
      }
      set
      {
        this._updating = value;
      }
    }

    public bool Loading
    {
      get
      {
        return this._Loading;
      }
      set
      {
        this._Loading = value;
      }
    }

    public EngineerVisit EngineerVisit
    {
      get
      {
        return this._EngineerVisit;
      }
      set
      {
        this._EngineerVisit = value;
        this.Populate();
        this.tpDocuments.Controls.Clear();
        this.DocumentsControl = new UCDocumentsList(FSM.Entity.Sys.Enums.TableNames.tblEngineerVisit, this.EngineerVisit.EngineerVisitID);
        this.tpDocuments.Controls.Add((Control) this.DocumentsControl);
      }
    }

    private DataView JobItems
    {
      get
      {
        return this._JobItems;
      }
      set
      {
        this._JobItems = value;
        this._JobItems.AllowNew = false;
        this._JobItems.AllowEdit = true;
        this._JobItems.AllowDelete = false;
        this._JobItems.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblJobItem.ToString();
        this.dgJobItems.DataSource = (object) this.JobItems;
      }
    }

    public int PartProductIDUsed
    {
      get
      {
        return this._PartProductIDUsed;
      }
      set
      {
        this._PartProductIDUsed = value;
      }
    }

    public string PartProductReferenceUsed
    {
      get
      {
        return this._PartProductReferenceUsed;
      }
      set
      {
        this._PartProductReferenceUsed = value;
      }
    }

    private FSM.Entity.Sites.Site theSite
    {
      get
      {
        return this._theSite;
      }
      set
      {
        this._theSite = value;
        ContractOriginal currentForSite = App.DB.ContractOriginal.Get_Current_ForSite(this.theSite.SiteID);
        if (currentForSite == null)
          this.txtCurrentContract.Text = "Not on contract";
        else
          this.txtCurrentContract.Text = currentForSite.ContractType + " - Expires " + Microsoft.VisualBasic.Strings.Format((object) currentForSite.ContractEndDate, "dd/MM/yyyy");
      }
    }

    public DataView AssetsDataView
    {
      get
      {
        return this._AssetsTable;
      }
      set
      {
        this._AssetsTable = value;
        this._AssetsTable.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblAsset.ToString();
        this._AssetsTable.AllowNew = false;
        this._AssetsTable.AllowEdit = false;
        this._AssetsTable.AllowDelete = false;
        this.dgAssets.DataSource = (object) this.AssetsDataView;
      }
    }

    private EngineerVisitQC QC
    {
      get
      {
        return this._QC;
      }
      set
      {
        this._QC = value;
      }
    }

    private FSM.Entity.JobLock.JobLock JobLock
    {
      get
      {
        return this._JobLock;
      }
      set
      {
        this._JobLock = value;
      }
    }

    public CustomerCharge CustomerCharge
    {
      get
      {
        return this._customerCharge;
      }
      set
      {
        this._customerCharge = value;
        if (Helper.MakeIntegerValid((object) this._customerCharge?.CustomerChargeID) > 0)
          return;
        Settings settings = App.DB.Manager.Get();
        this._customerCharge.SetMileageRate = (object) Helper.MakeDoubleValid((object) settings?.MileageRate);
        this._customerCharge.SetPartsMarkup = (object) Helper.MakeDoubleValid((object) settings?.PartsMarkup);
        this._customerCharge.SetRatesMarkup = (object) Helper.MakeDoubleValid((object) settings?.RatesMarkup);
      }
    }

    private void SetupVisitDefectDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgVisitDefects.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "typemakemodel";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Serial Num";
      dataGridLabelColumn2.MappingName = "SerialNum";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Location";
      dataGridLabelColumn3.MappingName = "Location";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Category";
      dataGridLabelColumn4.MappingName = "Category";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Warning Notice Issued";
      dataGridLabelColumn5.MappingName = "WarningNoticeIssued";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 80;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Disconnected";
      dataGridLabelColumn6.MappingName = "Disconnected";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 80;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitDefects.ToString();
      this.dgVisitDefects.TableStyles.Add(tableStyle);
    }

    private void SetupApplianceWorksheetDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgApplianceWorkSheets.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "typemakemodel";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Serial Num";
      dataGridLabelColumn2.MappingName = "SerialNum";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Location";
      dataGridLabelColumn3.MappingName = "Location";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
      this.dgApplianceWorkSheets.TableStyles.Add(tableStyle);
    }

    private void SetupSmokeComoDG()
    {
      DataGridTableStyle tableStyle = this.DGSmokeComo.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Location";
      dataGridLabelColumn1.MappingName = "Location";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 120;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Type";
      dataGridLabelColumn2.MappingName = "Type";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 80;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Power Type";
      dataGridLabelColumn3.MappingName = "PowerType";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Date";
      dataGridLabelColumn4.MappingName = "Date";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Date Type";
      dataGridLabelColumn5.MappingName = "DateType";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 80;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "Alarms";
      this.DGSmokeComo.TableStyles.Add(tableStyle);
    }

    private void SetupAdditionalDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgAdditional.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Type";
      dataGridLabelColumn.MappingName = "Type";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 250;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
      this.dgAdditional.TableStyles.Add(tableStyle);
    }

    private void SetupJobItemsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgJobItems, false);
      DataGridTableStyle tableStyle = this.dgJobItems.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgJobItems.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Summary";
      dataGridLabelColumn1.MappingName = "Summary";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 600;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "No. Of Units Allocated to Job";
      dataGridLabelColumn2.MappingName = "NumAllocated";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "G";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "No.Of Units Used (Type value in cell)";
      editableTextBoxColumn.MappingName = "NumUnitsUsed";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 75;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblJobItem.ToString();
      this.dgJobItems.TableStyles.Add(tableStyle);
    }

    public void SetupPartsAndProductsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgPartsAndProductsUsed, false);
      DataGridTableStyle tableStyle = this.dgPartsAndProductsUsed.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Number";
      dataGridLabelColumn2.MappingName = "number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 250;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Name";
      dataGridLabelColumn3.MappingName = "Name";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 300;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Qty";
      dataGridLabelColumn4.MappingName = "quantity";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 60;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Reference";
      dataGridLabelColumn5.MappingName = "reference";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Appliance";
      dataGridLabelColumn6.MappingName = "asset";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Buy Price";
      dataGridLabelColumn7.MappingName = "BuyPrice";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "C";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Sell Price";
      dataGridLabelColumn8.MappingName = "SellPrice";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "";
      dataGridLabelColumn9.MappingName = "OrderPartID";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 5;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      this.dgPartsAndProductsUsed.TableStyles.Add(tableStyle);
    }

    private void SetupTimesheetDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgTimeSheets.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Start Date&Time";
      dataGridLabelColumn1.MappingName = "StartDateTime";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 180;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "End Date&Time";
      dataGridLabelColumn2.MappingName = "EndDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 180;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Timesheet Type";
      dataGridLabelColumn3.MappingName = "TimeSheetType";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 180;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Comments";
      dataGridLabelColumn4.MappingName = "Comments";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 180;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString();
      this.dgTimeSheets.TableStyles.Add(tableStyle);
    }

    public void SetupAssetDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAssets, false);
      DataGridTableStyle tableStyle = this.dgAssets.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgAssets.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "Product";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Serial";
      dataGridLabelColumn3.MappingName = "SerialNum";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "GC Number";
      dataGridLabelColumn4.MappingName = "GCNumber";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Year Of Manufacture";
      dataGridLabelColumn5.MappingName = "YearOfManufacture";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Approx.Value";
      dataGridLabelColumn6.MappingName = "ApproximateValue";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgAssets);
    }

    private void FRMEngineerVisit_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.EngVisitCharge != null && this.cbxReadyToBeInvoiced.Checked)
      {
        string str = "";
        if (this.EngVisitCharge.NominalCode.Trim().Length == 0)
          str += "* Nominal Code is Mandatory\r\n";
        if (this.EngVisitCharge.ForSageAccountCode.Trim().Length == 0)
          str += "* Account Code is Mandatory\r\n";
        if (this.EngVisitCharge.Department.Trim().Length == 0)
          str += "* Department is Mandatory\r\n";
        if (str.Length > 0)
        {
          e.Cancel = true;
          int num = (int) App.ShowMessage("Cannot close for the following reasons:\r\n" + str, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
      }
      if (this.chkShowJobCharges.Checked)
      {
        this.ShutdownNonChargableVisits(e);
        if (e.Cancel)
          return;
      }
      if (this.JobLock != null)
      {
        if (this.JobLock.UserID == App.loggedInUser.UserID)
          App.DB.JobLock.Delete(this.JobLock.JobLockID);
        this._readOnly = false;
      }
    }

    private void FRMEngineerVisit_Load(object sender, EventArgs e)
    {
      this.btnInvoice.Visible = false;
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.tcWorkSheet.TabPages.Remove(this.tpCharges);
      this.tcWorkSheet.SelectedTab = this.tpMainDetails;
      this.Loading = true;
      this.cbxVisitLockDown.Checked = this.EngineerVisit.VisitLocked;
      if (this.cbxVisitLockDown.Checked)
        this.PopulateCharges(true);
      this.Loading = false;
      if (this.Job == null || this.Job.StatusEnumID < 2)
        return;
      this.cbxVisitLockDown.Enabled = false;
      this.cbxReadyToBeInvoiced.Enabled = false;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnFindPart_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblPart, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      Part part = App.DB.Part.Part_Get(integer);
      this.PartProductIDUsed = integer;
      this.PartProductReferenceUsed = part.Reference;
      this.isSpecialPart = part.IsSpecialPart;
      this.txtNumberUsed.Text = part.Number;
      this.txtNameUsed.Text = part.Name;
      this.nudQuantityUsed.Value = Decimal.One;
      this.lblSellPrice.Text = Conversions.ToString(part.SellPrice);
      this.btnAddPartProductUsed.Text = "Add Part";
      this.btnAddPartProductUsed.Enabled = true;
      this.lblEquipment.Text = "False";
    }

    private void btnFindProduct_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblProduct, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      Product product = App.DB.Product.Product_Get(integer);
      this.PartProductIDUsed = integer;
      this.PartProductReferenceUsed = product.Reference;
      this.txtNumberUsed.Text = product.Number;
      this.txtNameUsed.Text = product.Name;
      this.nudQuantityUsed.Value = Decimal.One;
      this.lblSellPrice.Text = Conversions.ToString(product.SellPrice);
      this.btnAddPartProductUsed.Text = "Add Product";
      this.btnAddPartProductUsed.Enabled = true;
    }

    private void btnRemovePartProduct_Click(object sender, EventArgs e)
    {
      if (this.dgPartsAndProductsUsed.CurrentRowIndex > -1)
      {
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["LocationID"], (object) 0, false), (object) (bool) (this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["AllocatedID"] == DBNull.Value ? 1 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["AllocatedID"], (object) 0, false)) ? 1 : 0)))))
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["Type"], (object) "Part", false))
            App.DB.EngineerVisitsPartsAndProducts.PartsUsed_DeleteOne(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"])));
          else
            App.DB.EngineerVisitsPartsAndProducts.ProductsUsed_DeleteOne(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"])));
          this.EngineerVisit.PartsAndProductsUsed.Table.AcceptChanges();
          this.EngineerVisit.PartsAndProductsUsed.Table.Rows.RemoveAt(this.dgPartsAndProductsUsed.CurrentRowIndex);
        }
        else if (this.RemovePart(Conversions.ToInteger(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["Quantity"]), Conversions.ToString(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["Name"]), Conversions.ToString(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["Type"]), Conversions.ToInteger(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["ID"])))
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["Type"], (object) "Part", false))
            App.DB.EngineerVisitsPartsAndProducts.PartsUsed_DeleteOne(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"])));
          else
            App.DB.EngineerVisitsPartsAndProducts.ProductsUsed_DeleteOne(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"])));
          this.EngineerVisit.PartsAndProductsUsed.Table.AcceptChanges();
          this.EngineerVisit.PartsAndProductsUsed.Table.Rows.RemoveAt(this.dgPartsAndProductsUsed.CurrentRowIndex);
        }
      }
      else
      {
        int num = (int) App.ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnAddPartProduct_Click(object sender, EventArgs e)
    {
      if (this.PartProductIDUsed == 0)
      {
        int num1 = (int) App.ShowMessage("Part / Product not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (Decimal.Compare(this.nudQuantityUsed.Value, Decimal.Zero) == 0)
      {
        int num2 = (int) App.ShowMessage("Quantity not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DataRow row = this.EngineerVisit.PartsAndProductsUsed.Table.NewRow();
        row["ID"] = (object) this.PartProductIDUsed;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnAddPartProductUsed.Text, "Add Part", false) == 0)
        {
          row["Type"] = (object) "Part";
          FRMChooseAsset frmChooseAsset = (FRMChooseAsset) App.checkIfExists(typeof (FRMChooseAsset).Name, true) ?? (FRMChooseAsset) Activator.CreateInstance(typeof (FRMChooseAsset));
          frmChooseAsset.ShowInTaskbar = false;
          frmChooseAsset.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
          int num3 = (int) frmChooseAsset.ShowDialog();
          frmChooseAsset.Close();
        }
        else
          row["Type"] = (object) "Product";
        row["Number"] = (object) this.txtNumberUsed.Text;
        row["Name"] = (object) this.txtNameUsed.Text;
        row["Quantity"] = (object) this.nudQuantityUsed.Value;
        row["Reference"] = (object) this.PartProductReferenceUsed;
        row["SellPrice"] = (object) this.lblSellPrice.Text;
        row["BuyPrice"] = (object) this.lblSellPrice.Text;
        row["UniqueID"] = (object) 0;
        if (this.isSpecialPart)
        {
          FRMSpecialOrder frmSpecialOrder = new FRMSpecialOrder(0, 0.0, 0);
          int num3 = (int) frmSpecialOrder.ShowDialog();
          if (frmSpecialOrder.DialogResult != DialogResult.OK)
            return;
          row["Quantity"] = (object) frmSpecialOrder.Quantity;
          row["SellPrice"] = (object) frmSpecialOrder.Price;
          row["BuyPrice"] = (object) frmSpecialOrder.Price;
          row["SpecialPrice"] = (object) frmSpecialOrder.Price;
          row["Name"] = (object) frmSpecialOrder.PartName;
          row["SpecialDescription"] = (object) frmSpecialOrder.PartName;
          row["Number"] = (object) frmSpecialOrder.SPN;
          row["SpecialPartNumber"] = (object) frmSpecialOrder.SPN;
          row["LocationID"] = (object) 0;
          row["AllocatedID"] = (object) 0;
        }
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnAddPartProductUsed.Text, "Add Part", false) == 0 & Conversions.ToBoolean(this.lblEquipment.Text))
        {
          this.EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(row);
          this.PartProductIDUsed = 0;
          this.txtNumberUsed.Text = "";
          this.txtNameUsed.Text = "";
          this.nudQuantityUsed.Value = Decimal.One;
          this.btnAddPartProductUsed.Text = "PICK ITEM";
          this.btnAddPartProductUsed.Enabled = false;
        }
        else if (this.DeclareWhereGotFrom(Conversions.ToInteger(row["Quantity"]), Conversions.ToString(row["Name"]), Conversions.ToString(row["Type"]), Conversions.ToInteger(row["ID"])))
        {
          this.EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(row);
          this.PartProductIDUsed = 0;
          this.txtNumberUsed.Text = "";
          this.txtNameUsed.Text = "";
          this.nudQuantityUsed.Value = Decimal.One;
          this.btnAddPartProductUsed.Text = "PICK ITEM";
          this.btnAddPartProductUsed.Enabled = false;
        }
      }
    }

    private void dtpStartDate_ValueChanged(object sender, EventArgs e)
    {
      this.dtpEndDate.Value = this.dtpStartDate.Value.AddMinutes(1.0);
    }

    private void btnAddTimeSheet_Click(object sender, EventArgs e)
    {
      DateTime dateTime = this.dtpEndDate.Value;
      DateTime date1 = dateTime.Date;
      dateTime = this.dtpStartDate.Value;
      DateTime date2 = dateTime.Date;
      if ((uint) DateTime.Compare(date1, date2) > 0U)
      {
        int num1 = (int) MessageBox.Show("Start Day must be the same as the End Day", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (DateTime.Compare(this.dtpEndDate.Value, this.dtpStartDate.Value) <= 0)
      {
        int num2 = (int) MessageBox.Show("End date & time must be after Start date & time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboTimeSheetType)) <= 0)
      {
        int num3 = (int) MessageBox.Show("Select a Timesheet Type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
      }
      else
      {
        IEnumerator enumerator;
        try
        {
          enumerator = this.EngineerVisit.TimeSheets.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual((object) this.dtpStartDate.Value, current["StartDateTime"], false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual((object) this.dtpStartDate.Value, current["EndDateTime"], false))))
            {
              int num4 = (int) MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              return;
            }
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual((object) this.dtpEndDate.Value, current["StartDateTime"], false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual((object) this.dtpEndDate.Value, current["EndDateTime"], false))))
            {
              int num4 = (int) MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              return;
            }
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual((object) this.dtpStartDate.Value, current["StartDateTime"], false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual((object) this.dtpEndDate.Value, current["EndDateTime"], false))))
            {
              int num4 = (int) MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              return;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        DataRow row = this.EngineerVisit.TimeSheets.Table.NewRow();
        row["StartDateTime"] = (object) Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) this.dtpStartDate.Value, "dd/MMM/yyyy HH:mm") + ":00");
        row["EndDateTime"] = (object) Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) this.dtpEndDate.Value, "dd/MMM/yyyy HH:mm") + ":00");
        row["Comments"] = (object) this.txtComments.Text;
        row["TimesheetTypeID"] = (object) Combo.get_GetSelectedItemValue(this.cboTimeSheetType);
        row["TimesheetType"] = (object) Combo.get_GetSelectedItemDescription(this.cboTimeSheetType);
        this.EngineerVisit.TimeSheets.Table.Rows.Add(row);
        this.dtpStartDate.Value = DateAndTime.Now;
        this.dtpEndDate.Value = DateAndTime.Now.AddMinutes(1.0);
        this.txtComments.Text = "";
        ComboBox cboTimeSheetType = this.cboTimeSheetType;
        Combo.SetSelectedComboItem_By_Value(ref cboTimeSheetType, "0");
        this.cboTimeSheetType = cboTimeSheetType;
      }
    }

    private void btnRemoveTimeSheet_Click(object sender, EventArgs e)
    {
      if (this.dgTimeSheets.CurrentRowIndex > -1)
      {
        this.EngineerVisit.TimeSheets.Table.AcceptChanges();
        this.EngineerVisit.TimeSheets.Table.Rows.RemoveAt(this.dgTimeSheets.CurrentRowIndex);
      }
      else
      {
        int num = (int) App.ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void cbxVisitLockDown_CheckedChanged(object sender, EventArgs e)
    {
      if (this.loops == 0)
      {
        if (!this.Loading)
        {
          if (this.cbxVisitLockDown.Checked)
          {
            if (this.PartsAndProductsAllocated.Table.Select("Status = " + Conversions.ToString(false)).Length > 0)
            {
              this.loops = 1;
              this.cbxVisitLockDown.Checked = false;
              int num = (int) App.ShowMessage("All allocated parts must be distributed before locking the visit down", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
              if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboOutcome)) == 1.0)
              {
                Job job = this.Job;
                if (job != null && job.JobTypeID == 71443 && MessageBox.Show("Have You\r\n- Changed fuels?\r\n- Changed last service date?\r\n- Deactivated old Assets?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                  int num = (int) App.ShowMessage("Please complete the tasks and then try again.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  this.cbxVisitLockDown.Checked = false;
                  return;
                }
              }
              if (MessageBox.Show("Any changes will now be saved, the visit details will be locked and the visit charges made available\r\nDo you want to continue?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                if (this.Save())
                {
                  this.lblStatusWarning.Visible = true;
                  this.tcWorkSheet.TabPages.Add(this.tpCharges);
                  this.tpCharges.Visible = true;
                  this.tcWorkSheet.SelectedTab = this.tpCharges;
                  this.PopulateCharges(true);
                  this.tpPartsAndProducts.Enabled = false;
                  this.tpTimesheets.Enabled = true;
                  this.tpAppliances.Enabled = false;
                  this.tpOutcomes.Enabled = false;
                  this.cboOutcome.Enabled = false;
                  this.txtOutcomeDetails.ReadOnly = true;
                  this.txtNotesFromEngineer.ReadOnly = true;
                  this.cboEngineer.Enabled = false;
                  this.txtCustomer.Enabled = false;
                  this.cboSignatureSelected.Enabled = false;
                  this.cbxEmailReceiptToCustomer.Enabled = false;
                  this.btnEditInvoiceNotes.Visible = true;
                }
                else
                  this.cbxVisitLockDown.Checked = false;
              }
              else
                this.cbxVisitLockDown.Checked = false;
            }
          }
          else if (App.DB.EngineerVisitCharge.EngineerVisitCharge_Check(this.EngineerVisit.EngineerVisitID) > 0)
          {
            this.loops = 1;
            this.cbxVisitLockDown.Checked = true;
            this.cbxVisitLockDown.Enabled = false;
          }
          else if (App.CurrentCustomerID != 2846 && !App.EnterOverridePasswordINV())
          {
            this.loops = 1;
            this.cbxVisitLockDown.Checked = true;
            this.cbxVisitLockDown.Enabled = false;
          }
          else
          {
            this.DeleteCharges();
            this.lblStatusWarning.Visible = false;
            this.tcWorkSheet.TabPages.Remove(this.tpCharges);
            this.tcWorkSheet.SelectedTab = this.tpMainDetails;
            this.tpPartsAndProducts.Enabled = true;
            this.tpTimesheets.Enabled = true;
            this.tpAppliances.Enabled = true;
            this.tpOutcomes.Enabled = true;
            this.cboOutcome.Enabled = true;
            this.txtOutcomeDetails.ReadOnly = false;
            this.txtNotesFromEngineer.ReadOnly = false;
            this.dgJobItems.ReadOnly = false;
            this.cboEngineer.Enabled = true;
            this.txtCustomer.Enabled = true;
            this.cboSignatureSelected.Enabled = true;
            this.cbxEmailReceiptToCustomer.Enabled = true;
            this.btnEditInvoiceNotes.Visible = false;
          }
        }
        else if (this.cbxVisitLockDown.Checked)
        {
          this.lblStatusWarning.Visible = true;
          this.tcWorkSheet.TabPages.Add(this.tpCharges);
          this.tpCharges.Visible = true;
          this.tcWorkSheet.SelectedTab = this.tpCharges;
          this.tpPartsAndProducts.Enabled = false;
          this.tpTimesheets.Enabled = true;
          this.tpAppliances.Enabled = false;
          this.tpOutcomes.Enabled = false;
          this.cboOutcome.Enabled = false;
          this.txtOutcomeDetails.ReadOnly = true;
          this.txtNotesFromEngineer.ReadOnly = true;
          this.cboEngineer.Enabled = false;
          this.txtCustomer.Enabled = false;
          this.cboSignatureSelected.Enabled = false;
          this.cbxEmailReceiptToCustomer.Enabled = false;
          this.btnEditInvoiceNotes.Visible = true;
        }
        else if (App.DB.EngineerVisitCharge.EngineerVisitCharge_Check(this.EngineerVisit.EngineerVisitID) > 0)
        {
          this.loops = 1;
          this.cbxVisitLockDown.Checked = true;
          this.cbxVisitLockDown.Enabled = false;
        }
        else
        {
          this.lblStatusWarning.Visible = false;
          this.tcWorkSheet.TabPages.Remove(this.tpCharges);
          this.tcWorkSheet.SelectedTab = this.tpMainDetails;
          this.tpPartsAndProducts.Enabled = true;
          this.tpTimesheets.Enabled = true;
          this.tpOutcomes.Enabled = true;
          this.cboOutcome.Enabled = true;
          this.txtOutcomeDetails.ReadOnly = false;
          this.txtNotesFromEngineer.ReadOnly = false;
          this.dgJobItems.ReadOnly = false;
          this.cboEngineer.Enabled = true;
          this.txtCustomer.Enabled = true;
          this.cboSignatureSelected.Enabled = true;
          this.cbxEmailReceiptToCustomer.Enabled = true;
          this.btnEditInvoiceNotes.Visible = false;
        }
      }
      else
        this.loops = 0;
    }

    private void btnOrders_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes || !Navigation.Navigate(FSM.Entity.Sys.Enums.MenuTypes.Spares))
        return;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
      if (this.LogCalloutForm != null)
        this.LogCalloutForm.CloseForm();
      App.ShowForm(typeof (FRMOrderManager), false, new object[2]
      {
        (object) App.DB.Order.Orders_GetForEngineerVisit(this.EngineerVisit.EngineerVisitID),
        null
      }, false);
    }

    private void btnInvoice_Click(object sender, EventArgs e)
    {
      string str = "";
      if (!this.cbxReadyToBeInvoiced.Checked)
        str += "* Visit is not ready to be invoiced\r\n";
      if (this.EngVisitCharge.NominalCode.Trim().Length != 0)
        ;
      if (this.EngVisitCharge.ForSageAccountCode.Trim().Length == 0)
        str += "* Account Code is Mandatory\r\n";
      if (this.EngVisitCharge.Department.Trim().Length == 0)
        str += "* Department is Mandatory\r\n";
      if (str.Length > 0)
      {
        int num = (int) App.ShowMessage("Cannot close for the following reasons:\r\n" + str, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && Navigation.Navigate(FSM.Entity.Sys.Enums.MenuTypes.Invoicing))
      {
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
        if (this.LogCalloutForm != null)
          this.LogCalloutForm.CloseForm();
        DataView engineerVisitChargeId = App.DB.InvoiceToBeRaised.Invoices_GetAll_For_EngineerVisitChargeID(this.EngVisitCharge.EngineerVisitChargeID);
        bool flag = true;
        if (engineerVisitChargeId.Table.Rows.Count > 0 && App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(engineerVisitChargeId.Table.Rows[0]["InvoiceToBeRaisedID"])).Table.Rows.Count > 0)
          flag = false;
        if (!flag)
          App.ShowForm(typeof (FRMInvoicedManager), false, new object[3]
          {
            (object) engineerVisitChargeId,
            (object) flag,
            this.get_GetParameter(1)
          }, false);
        else
          App.ShowForm(typeof (FRMInvoiceManager), false, new object[3]
          {
            (object) engineerVisitChargeId,
            (object) flag,
            this.get_GetParameter(1)
          }, false);
      }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      DataTable dataTable = App.DB.ExecuteWithReturn("Select TestType From tblEngineerVisitAdditionalChecks Where EngineerVisitID = " + Conversions.ToString(this.EngineerVisit.EngineerVisitID), true);
      IEnumerator enumerator;
      try
      {
        enumerator = dataTable.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["TestType"], (object) 69318, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["TestType"], (object) 69319, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["TestType"], (object) 69473, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["TestType"], (object) 69592, false))))
          {
            Printing printing = new Printing((object) new ArrayList()
            {
              (object) this.EngineerVisit.EngineerVisitID,
              RuntimeHelpers.GetObjectValue(current["TestType"])
            }, "QC Results", FSM.Entity.Sys.Enums.SystemDocumentType.QCPrint, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void dgVisitDefects_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedVisitDefectDataRow == null)
        return;
      DLGEngineerVisitDefect engineerVisitDefect = (DLGEngineerVisitDefect) App.checkIfExists(typeof (DLGEngineerVisitDefect).Name, true) ?? (DLGEngineerVisitDefect) Activator.CreateInstance(typeof (DLGEngineerVisitDefect));
      engineerVisitDefect.ShowInTaskbar = false;
      engineerVisitDefect.Defect = App.DB.EngineerVisitDefects.EngineerVisitDefects_Get(Conversions.ToInteger(this.SelectedVisitDefectDataRow["EngineerVisitDefectID"]));
      engineerVisitDefect.EngineerVisit = this.EngineerVisit;
      engineerVisitDefect.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
      engineerVisitDefect.Updating = true;
      int num = (int) engineerVisitDefect.ShowDialog();
      if (engineerVisitDefect.DialogResult == DialogResult.OK)
        this.VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(this.EngineerVisit.EngineerVisitID);
      engineerVisitDefect.Close();
    }

    private void dgApplianceWorkSheets_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedApplianceWorkSheetDataRow == null)
        return;
      DLGVisitAssetWorkSheet visitAssetWorkSheet = (DLGVisitAssetWorkSheet) App.checkIfExists(typeof (DLGVisitAssetWorkSheet).Name, true) ?? (DLGVisitAssetWorkSheet) Activator.CreateInstance(typeof (DLGVisitAssetWorkSheet));
      visitAssetWorkSheet.ShowInTaskbar = false;
      visitAssetWorkSheet.Worksheet = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_Get(Conversions.ToInteger(this.SelectedApplianceWorkSheetDataRow["EngineerVisitAssetWorkSheetID"]));
      visitAssetWorkSheet.EngineerVisit = this.EngineerVisit;
      visitAssetWorkSheet.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
      visitAssetWorkSheet.Updating = true;
      int num = (int) visitAssetWorkSheet.ShowDialog();
      if (visitAssetWorkSheet.DialogResult == DialogResult.OK)
        this.ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(this.EngineerVisit.EngineerVisitID, -1);
      visitAssetWorkSheet.Close();
    }

    private void dgAdditionalWorkSheets_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedAdditionalWorkSheetDataRow == null)
        return;
      DLGVisitAdditionalWorkSheet additionalWorkSheet = (DLGVisitAdditionalWorkSheet) App.checkIfExists(typeof (DLGVisitAdditionalWorkSheet).Name, true) ?? (DLGVisitAdditionalWorkSheet) Activator.CreateInstance(typeof (DLGVisitAdditionalWorkSheet));
      additionalWorkSheet.ShowInTaskbar = false;
      additionalWorkSheet.Worksheet = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_Get(Conversions.ToInteger(this.SelectedAdditionalWorkSheetDataRow["EngineerVisitAdditionalID"]));
      additionalWorkSheet.EngineerVisit = this.EngineerVisit;
      additionalWorkSheet.TheSite = this.theSite;
      additionalWorkSheet.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
      additionalWorkSheet.Updating = true;
      int num = (int) additionalWorkSheet.ShowDialog();
      if (additionalWorkSheet.DialogResult == DialogResult.OK)
        this.AdditionalWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(this.EngineerVisit.EngineerVisitID, 0);
      additionalWorkSheet.Close();
    }

    private void dgSmokeComoWorkSheets_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedSmokeComoDataRow == null)
        return;
      FRMSmokeComo frmSmokeComo1 = (FRMSmokeComo) App.checkIfExists(typeof (FRMSmokeComo).Name, true) ?? (FRMSmokeComo) Activator.CreateInstance(typeof (FRMSmokeComo));
      frmSmokeComo1.ShowInTaskbar = false;
      FRMSmokeComo frmSmokeComo2;
      ComboBox cboDetType = (frmSmokeComo2 = frmSmokeComo1).cboDetType;
      Combo.SetUpCombo(ref cboDetType, ((IEnumerable<DataRow>) App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.TestType, false).Table.Select("PercentageRate = 1.00")).CopyToDataTable<DataRow>(), "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      frmSmokeComo2.cboDetType = cboDetType;
      FRMSmokeComo frmSmokeComo3 = frmSmokeComo1;
      ComboBox c = frmSmokeComo3.cboPower;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Power, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      frmSmokeComo3.cboPower = c;
      FRMSmokeComo frmSmokeComo4 = frmSmokeComo1;
      c = frmSmokeComo4.cboDateType;
      Combo.SetUpCombo(ref c, DynamicDataTables.ComoDateType, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      frmSmokeComo4.cboDateType = c;
      frmSmokeComo1.AdditionalID = Conversions.ToInteger(this.SelectedSmokeComoDataRow["EngineerVisitAdditionalID"]);
      frmSmokeComo1.EngineerVisitID = this.EngineerVisit.EngineerVisitID;
      try
      {
        frmSmokeComo1.dtpDate.Value = Conversions.ToDate(this.SelectedSmokeComoDataRow["Date"]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        frmSmokeComo1.chkNA.Checked = true;
        frmSmokeComo1.dtpDate.Enabled = false;
        ProjectData.ClearProjectError();
      }
      FRMSmokeComo frmSmokeComo5 = frmSmokeComo1;
      ComboBox combo = frmSmokeComo5.cboDetType;
      Combo.SetSelectedComboItem_By_Description(ref combo, Conversions.ToString(this.SelectedSmokeComoDataRow["Type"]));
      frmSmokeComo5.cboDetType = combo;
      FRMSmokeComo frmSmokeComo6 = frmSmokeComo1;
      combo = frmSmokeComo6.cboPower;
      Combo.SetSelectedComboItem_By_Description(ref combo, Conversions.ToString(this.SelectedSmokeComoDataRow["PowerType"]));
      frmSmokeComo6.cboPower = combo;
      FRMSmokeComo frmSmokeComo7 = frmSmokeComo1;
      combo = frmSmokeComo7.cboDateType;
      Combo.SetSelectedComboItem_By_Description(ref combo, Conversions.ToString(this.SelectedSmokeComoDataRow["DateType"]));
      frmSmokeComo7.cboDateType = combo;
      frmSmokeComo1.txtLocation.Text = Conversions.ToString(this.SelectedSmokeComoDataRow["Location"]);
      int num = (int) frmSmokeComo1.ShowDialog();
      if (frmSmokeComo1.DialogResult == DialogResult.OK)
        this.SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(this.EngineerVisit.EngineerVisitID);
      frmSmokeComo1.Close();
    }

    private void btnAddSmokeComo_Click(object sender, EventArgs e)
    {
      FRMSmokeComo frmSmokeComo1 = (FRMSmokeComo) App.checkIfExists(typeof (FRMSmokeComo).Name, true) ?? (FRMSmokeComo) Activator.CreateInstance(typeof (FRMSmokeComo));
      frmSmokeComo1.ShowInTaskbar = false;
      FRMSmokeComo frmSmokeComo2;
      ComboBox cboDetType = (frmSmokeComo2 = frmSmokeComo1).cboDetType;
      Combo.SetUpCombo(ref cboDetType, ((IEnumerable<DataRow>) App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.TestType, false).Table.Select("PercentageRate = 1.00")).CopyToDataTable<DataRow>(), "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      frmSmokeComo2.cboDetType = cboDetType;
      FRMSmokeComo frmSmokeComo3 = frmSmokeComo1;
      ComboBox cboPower = frmSmokeComo3.cboPower;
      Combo.SetUpCombo(ref cboPower, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Power, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      frmSmokeComo3.cboPower = cboPower;
      FRMSmokeComo frmSmokeComo4 = frmSmokeComo1;
      ComboBox cboDateType = frmSmokeComo4.cboDateType;
      Combo.SetUpCombo(ref cboDateType, DynamicDataTables.ComoDateType, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      frmSmokeComo4.cboDateType = cboDateType;
      frmSmokeComo1.EngineerVisitID = this.EngineerVisit.EngineerVisitID;
      int num = (int) frmSmokeComo1.ShowDialog();
      if (frmSmokeComo1.DialogResult == DialogResult.OK)
        this.SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(this.EngineerVisit.EngineerVisitID);
      frmSmokeComo1.Close();
    }

    private void btnRemoveSmokeComo_Click(object sender, EventArgs e)
    {
      if (this.SelectedSmokeComoDataRow == null)
        return;
      App.DB.EngineerVisitAdditional.Delete(Conversions.ToInteger(this.SelectedSmokeComoDataRow["EngineerVisitAdditionalID"]));
      this.SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(this.EngineerVisit.EngineerVisitID);
    }

    private void btnAddVisitDefect_Click(object sender, EventArgs e)
    {
      DLGEngineerVisitDefect engineerVisitDefect = (DLGEngineerVisitDefect) App.checkIfExists(typeof (DLGEngineerVisitDefect).Name, true) ?? (DLGEngineerVisitDefect) Activator.CreateInstance(typeof (DLGEngineerVisitDefect));
      engineerVisitDefect.ShowInTaskbar = false;
      engineerVisitDefect.Defect = new EngineerVisitDefects();
      engineerVisitDefect.EngineerVisit = this.EngineerVisit;
      engineerVisitDefect.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
      engineerVisitDefect.Updating = false;
      int num = (int) engineerVisitDefect.ShowDialog();
      if (engineerVisitDefect.DialogResult == DialogResult.OK)
        this.VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(this.EngineerVisit.EngineerVisitID);
      engineerVisitDefect.Close();
    }

    private void btnAddApplianceWorksheet_Click(object sender, EventArgs e)
    {
      DLGVisitAssetWorkSheet visitAssetWorkSheet = (DLGVisitAssetWorkSheet) App.checkIfExists(typeof (DLGVisitAssetWorkSheet).Name, true) ?? (DLGVisitAssetWorkSheet) Activator.CreateInstance(typeof (DLGVisitAssetWorkSheet));
      visitAssetWorkSheet.ShowInTaskbar = false;
      visitAssetWorkSheet.Worksheet = new EngineerVisitAssetWorkSheet();
      visitAssetWorkSheet.EngineerVisit = this.EngineerVisit;
      visitAssetWorkSheet.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
      visitAssetWorkSheet.Updating = false;
      int num = (int) visitAssetWorkSheet.ShowDialog();
      if (visitAssetWorkSheet.DialogResult == DialogResult.OK)
        this.ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(this.EngineerVisit.EngineerVisitID, -1);
      visitAssetWorkSheet.Close();
    }

    private void btnAddAdd_Click(object sender, EventArgs e)
    {
      DLGVisitAdditionalWorkSheet additionalWorkSheet = (DLGVisitAdditionalWorkSheet) App.checkIfExists(typeof (DLGVisitAdditionalWorkSheet).Name, true) ?? (DLGVisitAdditionalWorkSheet) Activator.CreateInstance(typeof (DLGVisitAdditionalWorkSheet));
      additionalWorkSheet.ShowInTaskbar = false;
      additionalWorkSheet.Worksheet = new EngineerVisitAdditional();
      additionalWorkSheet.EngineerVisit = this.EngineerVisit;
      additionalWorkSheet.TheSite = this.theSite;
      additionalWorkSheet.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
      additionalWorkSheet.Updating = false;
      int num = (int) additionalWorkSheet.ShowDialog();
      if (additionalWorkSheet.DialogResult == DialogResult.OK)
        this.AdditionalWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(this.EngineerVisit.EngineerVisitID, -1);
      additionalWorkSheet.Close();
    }

    private void btnRemoveVisitDefect_Click(object sender, EventArgs e)
    {
      if (this.SelectedVisitDefectDataRow == null)
        return;
      App.DB.EngineerVisitDefects.Delete(Conversions.ToInteger(this.SelectedVisitDefectDataRow["EngineerVisitDefectID"]));
      this.VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(this.EngineerVisit.EngineerVisitID);
    }

    private void btnRemoveApplianceWorkSheet_Click(object sender, EventArgs e)
    {
      if (this.SelectedApplianceWorkSheetDataRow == null)
        return;
      App.DB.EngineerVisitAssetWorkSheet.Delete(Conversions.ToInteger(this.SelectedApplianceWorkSheetDataRow["EngineerVisitAssetWorkSheetID"]));
      this.ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(this.EngineerVisit.EngineerVisitID, -1);
    }

    private void btnRemoveAdd_Click(object sender, EventArgs e)
    {
      if (this.SelectedAdditionalWorkSheetDataRow == null)
        return;
      App.DB.EngineerVisitAdditional.Delete(Conversions.ToInteger(this.SelectedAdditionalWorkSheetDataRow["EngineerVisitAdditionalID"]));
      this.ApplianceWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(this.EngineerVisit.EngineerVisitID, -1);
    }

    private void btnPrintGSR_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID
      }, "Gas Safety Record ", FSM.Entity.Sys.Enums.SystemDocumentType.GSR, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void btnPrintSVR_Click(object sender, EventArgs e)
    {
      this.SVRs.Show((Control) this.btnPrintSVR, new System.Drawing.Point(0, 0));
    }

    private void dgJobItems_CurrentCellChanged(object sender, EventArgs e)
    {
    }

    private void cboRecall_SelectedIndexChanged(object sender, EventArgs e)
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboRecall);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(387), false) == 0)
      {
        ComboBox cboRecallEngineer = this.cboRecallEngineer;
        Combo.SetSelectedComboItem_By_Value(ref cboRecallEngineer, Conversions.ToString(0));
        this.cboRecallEngineer = cboRecallEngineer;
        this.cboRecallEngineer.Enabled = false;
      }
      else
        this.cboRecallEngineer.Enabled = true;
    }

    private void btnJob_Click(object sender, EventArgs e)
    {
      bool flag = true;
      switch (App.ShowMessage("This form will reload when the job form is closed. Do you want to save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case DialogResult.Cancel:
          flag = false;
          break;
        case DialogResult.Yes:
          flag = this.Save();
          break;
      }
      if (!flag)
        return;
      App.ShowForm(typeof (FRMLogCallout), true, new object[5]
      {
        (object) this.Job.JobID,
        (object) this.theSite.SiteID,
        (object) this,
        null,
        (object) this.EngineerVisit.EngineerVisitID
      }, false);
      this.EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_New_As_Object(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0))));
    }

    private void chkRecharge_CheckedChanged(object sender, EventArgs e)
    {
      this.lblRechargeTicked.Visible = this.chkRecharge.Checked;
    }

    private void Populate()
    {
      this.Job = App.DB.Job.Get(this.EngineerVisit.EngineerVisitID, FSM.Entity.Jobs.GetBy.EngineerVisitId);
      this.theSite = App.DB.Sites.Get((object) this.Job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (App.loggedInUser.UserRegions.Count <= 0)
        throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(this.theSite.RegionID)).Length < 1)
        throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      FSM.Entity.Customers.Customer forSiteId = App.DB.Customer.Customer_Get_ForSiteID(this.theSite.SiteID);
      FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) forSiteId.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
      this.Text = string.Format("Engineer Visit ID: {0}, Job No: {1}, Property: {2}, Customer: {3}", (object) this.EngineerVisit.EngineerVisitID, (object) this.Job.JobNumber, (object) this.theSite.Name, (object) forSiteId.Name);
      App.CurrentCustomerID = forSiteId.CustomerID;
      this.txtCustEmail.Text = site == null || site.EmailAddress.Length <= 0 ? "" : "Customer Email: " + site.EmailAddress;
      bool flag = false;
      switch (this.EngineerVisit.StatusEnumID)
      {
        case 0:
          int num1 = (int) App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          flag = true;
          break;
        case 1:
          int num2 = (int) App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          flag = true;
          break;
        case 2:
          int num3 = (int) App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          flag = true;
          break;
        case 4:
          this.txtStatus.Text = "Ready For Schedule";
          this.txtUploadedBy.Text = "Not Set";
          break;
        case 5:
          this.txtStatus.Text = "Scheduled";
          this.txtUploadedBy.Text = "Not Set";
          break;
        case 6:
          int num4 = (int) App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          flag = true;
          break;
        default:
          this.txtStatus.Text = this.EngineerVisit.VisitStatus;
          this.txtUploadedBy.Text = this.EngineerVisit.ManualEntryByUserID != 0 ? App.DB.User.Get(this.EngineerVisit.ManualEntryByUserID, false).Fullname + " via PC @ " + Microsoft.VisualBasic.Strings.Format((object) this.EngineerVisit.ManualEntryOn, "dddd dd MMMM yyyy HH:mm:ss") : "Engineer via PDA (See timesheets for date)";
          break;
      }
      if (flag)
      {
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
      else
      {
        if (this.EngineerVisit.OutcomeEnumID == 0)
        {
          this.Updating = false;
          this.cboOutcome.Enabled = true;
        }
        else
        {
          this.cboEngineer.Enabled = false;
          this.cboOutcome.Enabled = false;
        }
        ComboBox cboOutcome = this.cboOutcome;
        Combo.SetSelectedComboItem_By_Value(ref cboOutcome, Conversions.ToString(this.EngineerVisit.OutcomeEnumID));
        this.cboOutcome = cboOutcome;
        switch (this.EngineerVisit.OutcomeEnumID)
        {
          case 1:
            this.btnChangeOutcome.Visible = true;
            break;
          case 2:
            this.btnChangeOutcome.Visible = true;
            break;
          case 3:
            this.btnChangeOutcome.Visible = true;
            break;
          case 5:
            this.btnChangeOutcome.Visible = true;
            break;
          default:
            this.btnChangeOutcome.Visible = App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Servicing);
            break;
        }
        this.txtOutcomeDetails.Text = this.EngineerVisit.OutcomeDetails;
        ComboBox cboEngineer1 = this.cboEngineer;
        Combo.SetSelectedComboItem_By_Value(ref cboEngineer1, Conversions.ToString(this.EngineerVisit.EngineerID));
        this.cboEngineer = cboEngineer1;
        if ((uint) (-(Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEngineer)) == 0.0 ? 1 : 0) & this.EngineerVisit.EngineerID) > 0U)
        {
          this.cboEngineer.Items.Add((object) new Combo(App.DB.Engineer.Engineer_Get(this.EngineerVisit.EngineerID).Name, Conversions.ToString(this.EngineerVisit.EngineerID), (object) null));
          ComboBox cboEngineer2 = this.cboEngineer;
          Combo.SetSelectedComboItem_By_Value(ref cboEngineer2, Conversions.ToString(this.EngineerVisit.EngineerID));
          this.cboEngineer = cboEngineer2;
        }
        if (this.EngineerVisit.CustomerSignature != null)
          this.pbCustomerSignature.Image = (Image) new Bitmap((Stream) new MemoryStream(this.EngineerVisit.CustomerSignature));
        this.txtCustomer.Text = this.EngineerVisit.CustomerName;
        if (this.EngineerVisit.EngineerSignature != null)
          this.pbEngineerSignature.Image = (Image) new Bitmap((Stream) new MemoryStream(this.EngineerVisit.EngineerSignature));
        this.txtNotesToEngineer.Text = this.EngineerVisit.NotesToEngineer;
        this.txtNotesFromEngineer.Text = this.EngineerVisit.NotesFromEngineer;
        this.txtScheduledTime.Text = "From ";
        if (DateTime.Compare(this.EngineerVisit.StartDateTime, DateTime.MinValue) == 0)
        {
          TextBox txtScheduledTime;
          string str = (txtScheduledTime = this.txtScheduledTime).Text + "'Not Set' ";
          txtScheduledTime.Text = str;
        }
        else
        {
          TextBox txtScheduledTime;
          string str = (txtScheduledTime = this.txtScheduledTime).Text + Microsoft.VisualBasic.Strings.Format((object) this.EngineerVisit.StartDateTime, "dddd dd MMMM yyyy HH:mm:ss");
          txtScheduledTime.Text = str;
        }
        TextBox txtScheduledTime1;
        string str1 = (txtScheduledTime1 = this.txtScheduledTime).Text + " to ";
        txtScheduledTime1.Text = str1;
        if (DateTime.Compare(this.EngineerVisit.EndDateTime, DateTime.MinValue) == 0)
        {
          TextBox txtScheduledTime2;
          string str2 = (txtScheduledTime2 = this.txtScheduledTime).Text + "'Not Set' ";
          txtScheduledTime2.Text = str2;
        }
        else
        {
          TextBox txtScheduledTime2;
          string str2 = (txtScheduledTime2 = this.txtScheduledTime).Text + Microsoft.VisualBasic.Strings.Format((object) this.EngineerVisit.EndDateTime, "dddd dd MMMM yyyy HH:mm:ss");
          txtScheduledTime2.Text = str2;
        }
        if (DateTime.Compare(this.EngineerVisit.StartDateTime, DateTime.MinValue) == 0)
        {
          TextBox txtScheduledTime2;
          string str2 = (txtScheduledTime2 = this.txtScheduledTime2).Text + "'Not Set' ";
          txtScheduledTime2.Text = str2;
        }
        else
        {
          TextBox txtScheduledTime2;
          string str2 = (txtScheduledTime2 = this.txtScheduledTime2).Text + Microsoft.VisualBasic.Strings.Format((object) this.EngineerVisit.StartDateTime, "ddd dd/MM/yyyy HH:mm:ss");
          txtScheduledTime2.Text = str2;
        }
        TextBox txtScheduledTime2_1;
        string str3 = (txtScheduledTime2_1 = this.txtScheduledTime2).Text + "-";
        txtScheduledTime2_1.Text = str3;
        if (DateTime.Compare(this.EngineerVisit.EndDateTime, DateTime.MinValue) == 0)
        {
          TextBox txtScheduledTime2_2;
          string str2 = (txtScheduledTime2_2 = this.txtScheduledTime2).Text + "'Not Set' ";
          txtScheduledTime2_2.Text = str2;
        }
        else
        {
          TextBox txtScheduledTime2_2;
          string str2 = (txtScheduledTime2_2 = this.txtScheduledTime2).Text + Microsoft.VisualBasic.Strings.Format((object) this.EngineerVisit.EndDateTime, "ddd dd/MM/yyyy HH:mm:ss");
          txtScheduledTime2_2.Text = str2;
        }
        this.JobItems = App.DB.EngineerVisits.EngineerVisitUnitsUsed_Get_For_EngineerVisitID(this.EngineerVisit.EngineerVisitID);
        this.dgPartsAndProductsUsed.DataSource = (object) this.EngineerVisit.PartsAndProductsUsed;
        this.dgTimeSheets.DataSource = (object) this.EngineerVisit.TimeSheets;
        this.TimesheetCalc();
        this.SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(this.EngineerVisit.EngineerVisitID);
        this.ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(this.EngineerVisit.EngineerVisitID, -1);
        this.VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(this.EngineerVisit.EngineerVisitID);
        this.AdditionalWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(this.EngineerVisit.EngineerVisitID, -1);
        ComboBox controlAccessible = this.cboEmergencyControlAccessible;
        Combo.SetSelectedComboItem_By_Value(ref controlAccessible, Conversions.ToString(this.EngineerVisit.EmergencyControlAccessibleID));
        this.cboEmergencyControlAccessible = controlAccessible;
        ComboBox cboBonding = this.cboBonding;
        Combo.SetSelectedComboItem_By_Value(ref cboBonding, Conversions.ToString(this.EngineerVisit.BondingID));
        this.cboBonding = cboBonding;
        ComboBox installationTightnessTest = this.cboGasInstallationTightnessTest;
        Combo.SetSelectedComboItem_By_Value(ref installationTightnessTest, Conversions.ToString(this.EngineerVisit.GasInstallationTightnessTestID));
        this.cboGasInstallationTightnessTest = installationTightnessTest;
        ComboBox cboPropertyRented = this.cboPropertyRented;
        Combo.SetSelectedComboItem_By_Value(ref cboPropertyRented, Conversions.ToString(this.EngineerVisit.PropertyRented));
        this.cboPropertyRented = cboPropertyRented;
        ComboBox combo1 = this.cboSignatureSelected;
        Combo.SetSelectedComboItem_By_Value(ref combo1, Conversions.ToString(this.EngineerVisit.SignatureSelectedID));
        this.cboSignatureSelected = combo1;
        combo1 = this.cboPaymentMethod;
        Combo.SetSelectedComboItem_By_Value(ref combo1, Conversions.ToString(this.EngineerVisit.PaymentMethodID));
        this.cboPaymentMethod = combo1;
        combo1 = this.cboRecharge;
        Combo.SetSelectedComboItem_By_Value(ref combo1, Conversions.ToString(this.EngineerVisit.RechargeTypeID));
        this.cboRecharge = combo1;
        combo1 = this.cboNccRad;
        Combo.SetSelectedComboItem_By_Value(ref combo1, Conversions.ToString(this.EngineerVisit.NccRadID));
        this.cboNccRad = combo1;
        combo1 = this.cboMeterLocation;
        Combo.SetSelectedComboItem_By_Value(ref combo1, Conversions.ToString(this.EngineerVisit.MeterLocationID));
        this.cboMeterLocation = combo1;
        combo1 = this.cboMeterCapped;
        Combo.SetSelectedComboItem_By_Value(ref combo1, Conversions.ToString(this.EngineerVisit.MeterCappedID));
        this.cboMeterCapped = combo1;
        this.txtAmountCollected.Text = Conversions.ToString(this.EngineerVisit.AmountCollected);
        this.chkGasServiceCompleted.Checked = this.EngineerVisit.GasServiceCompleted;
        this.PopulateSiteFuelDataGrid();
        this.chkRecharge.Checked = this.EngineerVisit.Recharge;
        this.PartsAndProductsAllocated = this.EngineerVisit.PartsAndProductsAllocated;
        this.AssetsDataView = App.DB.Asset.Asset_GetForSite(this.Job.PropertyID);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.AssetsDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator1.Current;
            IEnumerator enumerator2;
            try
            {
              enumerator2 = App.DB.JobAsset.JobAsset_Get_For_Job(this.Job.JobID).Table.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator2.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual((object) Conversions.ToInteger(current1["AssetID"]), current2["AssetID"], false))
                {
                  current1["Tick"] = (object) true;
                  break;
                }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        this.cbxEmailReceiptToCustomer.Checked = this.EngineerVisit.EmailReceipt;
        this.QC = App.DB.EngineerVisitQCSQL.EngineerVisitQC_Get_EngineerVisitID(this.EngineerVisit.EngineerVisitID);
        if (this.QC == null)
          this.QC = new EngineerVisitQC();
        ComboBox cboQcAppliance = this.cboQCAppliance;
        Combo.SetSelectedComboItem_By_Value(ref cboQcAppliance, Conversions.ToString(this.QC.ApplianceRecorded));
        this.cboQCAppliance = cboQcAppliance;
        ComboBox cboQcCustSig = this.cboQCCustSig;
        Combo.SetSelectedComboItem_By_Value(ref cboQcCustSig, Conversions.ToString(this.QC.CustomerSigned));
        this.cboQCCustSig = cboQcCustSig;
        ComboBox combo2 = this.cboQCCustomerDetails;
        Combo.SetSelectedComboItem_By_Value(ref combo2, Conversions.ToString(this.QC.CustomerDetailsIncorrect));
        this.cboQCCustomerDetails = combo2;
        combo2 = this.cboQCEngineerPaymentRecieved;
        Combo.SetSelectedComboItem_By_Value(ref combo2, Conversions.ToString(this.QC.EngineerPaymentReceived));
        this.cboQCEngineerPaymentRecieved = combo2;
        ComboBox combo3 = this.cboQCJobType;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.JobTypeIncorrect));
        this.cboQCJobType = combo3;
        combo3 = this.cboQCJobUploadTimescale;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.JobUploadInTimeScale));
        this.cboQCJobUploadTimescale = combo3;
        combo3 = this.cboQCLabourTime;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.LabourTimeMissing));
        this.cboQCLabourTime = combo3;
        combo3 = this.cboQCLGSR;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.LGSRMissing));
        this.cboQCLGSR = combo3;
        combo3 = this.cboQCOrderNo;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.OrderNumberAttached));
        this.cboQCOrderNo = combo3;
        combo3 = this.cboQCParts;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.PartsConfirmation));
        this.cboQCParts = combo3;
        combo3 = this.cboQCPaymentCollection;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.PaymentCollection));
        this.cboQCPaymentCollection = combo3;
        combo3 = this.cboQCPaymentMethod;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.PaymentMethodDetailed));
        this.cboQCPaymentMethod = combo3;
        combo3 = this.cboQCPaymentSelection;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.PaymentMethodSelectionIncorrect));
        this.cboQCPaymentSelection = combo3;
        combo3 = this.cboQCScheduleOfRate;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.SorIncorrect));
        this.cboQCScheduleOfRate = combo3;
        combo3 = this.cboFTFCode;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.FTFCode));
        this.cboFTFCode = combo3;
        combo3 = this.cboRecall;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.Recall));
        this.cboRecall = combo3;
        combo3 = this.cboRecallEngineer;
        Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.QC.EngineerID));
        this.cboRecallEngineer = combo3;
        this.txtQCPoorJobNotes.Text = this.QC.PoorJobNotes;
        this.chkQCDocumentsRecieved.Checked = this.QC.DocumentsRecieved;
        this.dtpQCDocumentsRecieved.Value = Conversions.ToDate(Interaction.IIf((uint) DateTime.Compare(this.QC.DateDocumentsRecieved, DateTime.MinValue) > 0U, (object) this.QC.DateDocumentsRecieved, (object) DateAndTime.Now));
        this.Profitable();
        if (this.EngineerVisit.EngineerVisitNCCGSR != null)
        {
          this.txtApproxAgeOfBoiler.Text = Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.ApproxAgeOfBoiler);
          this.txtRadiators.Text = Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.Radiators);
          this.txtVisualInspectionReason.Text = this.EngineerVisit.EngineerVisitNCCGSR.VisualInspectionReason;
          combo3 = this.cboCertificateTypeID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.CertificateTypeID));
          this.cboCertificateTypeID = combo3;
          combo3 = this.cboCODetectorFittedID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.CODetectorFittedID));
          this.cboCODetectorFittedID = combo3;
          combo3 = this.cboCorrectMaterialsUsedID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.CorrectMaterialsUsedID));
          this.cboCorrectMaterialsUsedID = combo3;
          combo3 = this.cboCylinderTypeID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.CylinderTypeID));
          this.cboCylinderTypeID = combo3;
          combo3 = this.cboHeatingSystemTypeID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.HeatingSystemTypeID));
          this.cboHeatingSystemTypeID = combo3;
          combo3 = this.cboImmersionID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.ImmersionID));
          this.cboImmersionID = combo3;
          combo3 = this.cboInstallationPipeWorkCorrectID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.InstallationPipeWorkCorrectID));
          this.cboInstallationPipeWorkCorrectID = combo3;
          combo3 = this.cboInstallationSafeToUseID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.InstallationSafeToUseID));
          this.cboInstallationSafeToUseID = combo3;
          combo3 = this.cboJacketID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.JacketID));
          this.cboJacketID = combo3;
          combo3 = this.cboPartialHeatingID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.PartialHeatingID));
          this.cboPartialHeatingID = combo3;
          combo3 = this.cboStrainerFittedID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.StrainerFittedID));
          this.cboStrainerFittedID = combo3;
          combo3 = this.cboStrainerInspectedID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.StrainerInspectedID));
          this.cboStrainerInspectedID = combo3;
          combo3 = this.cboVisualInspectionSatisfactoryID;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.VisualInspectionSatisfactoryID));
          this.cboVisualInspectionSatisfactoryID = combo3;
          combo3 = this.cboSITimer;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.SITimerID));
          this.cboSITimer = combo3;
          combo3 = this.cboFillDisc;
          Combo.SetSelectedComboItem_By_Value(ref combo3, Conversions.ToString(this.EngineerVisit.EngineerVisitNCCGSR.FillDiscID));
          this.cboFillDisc = combo3;
        }
        DataTable table = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(this.EngineerVisit.EngineerVisitID, -1).Table;
        this.ASHPWorksheetToolStripMenuItem.Visible = false;
        this.CommercialGSRToolStripMenuItem.Visible = false;
        this.DomesticGSRToolStripMenuItem.Visible = false;
        this.WarningNoticeToolStripMenuItem.Visible = false;
        this.QCResultsToolStripMenuItem.Visible = false;
        this.ElectricalMinorWorksToolStripMenuItem.Visible = false;
        this.AllGasPaperworkToolStripMenuItem.Visible = true;
        this.CommercialCateringToolStripMenuItem.Visible = false;
        this.SaffronUnventedWorkshhetToolStripMenuItem.Visible = false;
        this.PropertyMaintenanceWorksheetToolStripMenuItem.Visible = false;
        this.CommissioningChecklistToolStripMenuItem.Visible = false;
        this.HotWorksPermitToolStripMenuItem.Visible = false;
        IEnumerator enumerator3;
        try
        {
          enumerator3 = table.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            switch (Conversions.ToInteger(((DataRow) enumerator3.Current)["TestType"]))
            {
              case 69108:
              case 69109:
              case 69110:
              case 69111:
                this.CommercialGSRToolStripMenuItem.Visible = true;
                break;
              case 69318:
              case 69319:
              case 69473:
              case 69592:
              case 71484:
                this.QCResultsToolStripMenuItem.Visible = true;
                break;
              case 69419:
              case 69424:
                this.ASHPWorksheetToolStripMenuItem.Visible = true;
                break;
              case 69591:
                this.PropertyMaintenanceWorksheetToolStripMenuItem.Visible = true;
                break;
              case 69902:
                this.SaffronUnventedWorkshhetToolStripMenuItem.Visible = true;
                break;
              case 69903:
                this.CommercialCateringToolStripMenuItem.Visible = true;
                break;
              case 69995:
                this.ElectricalMinorWorksToolStripMenuItem.Visible = true;
                break;
              case 71482:
                this.CommissioningChecklistToolStripMenuItem.Visible = true;
                break;
              case 71914:
                this.HotWorksPermitToolStripMenuItem.Visible = true;
                break;
            }
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
        if (this.ApplianceWorkSheetDataview.Count > 0 | this.VisitDefectDataview.Count > 0)
          this.DomesticGSRToolStripMenuItem.Visible = true;
        EnumerableRowCollection<DataRow> source1 = this.VisitDefectDataview.Table.AsEnumerable();
        Func<DataRow, bool> predicate;
        // ISSUE: reference to a compiler-generated field
        if (FRMEngineerVisit._Closure\u0024__.\u0024I1469\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          predicate = FRMEngineerVisit._Closure\u0024__.\u0024I1469\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMEngineerVisit._Closure\u0024__.\u0024I1469\u002D0 = predicate = (Func<DataRow, bool>) (x => Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["WarningNoticeIssued"])));
        }
        EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
        Func<DataRow, DataRow> selector;
        // ISSUE: reference to a compiler-generated field
        if (FRMEngineerVisit._Closure\u0024__.\u0024I1469\u002D1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = FRMEngineerVisit._Closure\u0024__.\u0024I1469\u002D1;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMEngineerVisit._Closure\u0024__.\u0024I1469\u002D1 = selector = (Func<DataRow, DataRow>) (x => x);
        }
        if (source2.Select<DataRow, DataRow>(selector).ToArray<DataRow>().Length > 0)
          this.WarningNoticeToolStripMenuItem.Visible = true;
      }
      if (this.JobLock == null)
        this.JobLock = App.DB.JobLock.JobLock(this.Job.JobID);
      int? userId1 = this.JobLock?.UserID;
      int userId2 = App.loggedInUser.UserID;
      if (!(userId1.HasValue ? new bool?(userId1.GetValueOrDefault() != userId2) : new bool?()).GetValueOrDefault())
        return;
      int num5 = (int) MessageBox.Show("The job is currently being viewed by: " + this.JobLock.NameOfUserWhoLocked, "READ ONLY - JOB LOCKED!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.MakeReadOnly();
      this.Text = this.Text + " Job Locked by: " + this.JobLock.NameOfUserWhoLocked;
    }

    private void TimesheetCalc()
    {
      double num1 = 0.0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.JobItems.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["NumAllocated"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["TimeInMins"]));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      double num2 = 0.0;
      IEnumerator enumerator2;
      if (this.EngineerVisit.TimeSheets != null)
      {
        if (this.EngineerVisit.TimeSheets.Table != null)
        {
          try
          {
            enumerator2 = this.EngineerVisit.TimeSheets.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              num2 += Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["EndDateTime"])).Subtract(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["StartDateTime"]))).TotalMinutes;
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
      }
      this.txtSORTimeAllowance.Text = Conversions.ToString(num1);
      this.txtActualTimeSpent.Text = Conversions.ToString(num2);
      this.txtDifference.Text = Conversions.ToString(num1 - num2);
    }

    private void Profitable()
    {
      if (this.EngVisitCharge == null)
        return;
      double num1 = 0.0 + Helper.MakeDoubleValid((object) this.txtEngineerCostTotal.Text) + Helper.MakeDoubleValid((object) this.txtPartProductCost.Text);
      this.txtSale.Text = this.txtJobValue.Text;
      this.txtCosts.Text = Microsoft.VisualBasic.Strings.Format((object) num1, "C");
      this.txtProfit.Text = Microsoft.VisualBasic.Strings.Format((object) (Conversions.ToDouble(this.txtSale.Text) - Conversions.ToDouble(this.txtCosts.Text)), "C");
      this.txtProfitPerc.Text = this.txtSale.Text.Length <= 0 ? "N/A" : Conversions.ToString(Math.Round(Conversions.ToDouble(this.txtProfit.Text) / Conversions.ToDouble(this.txtSale.Text) * 100.0, 2)) + "%";
      double num2 = 0.0;
      switch (this.EngVisitCharge.ChargeTypeID)
      {
        case 1:
          num2 = Helper.MakeDoubleValid((object) this.txtJobValue.Text);
          break;
        case 2:
          num2 = Helper.MakeDoubleValid((object) this.txtCharge.Text);
          break;
        case 3:
        case 4:
        case 5:
          num2 = 0.0;
          break;
        case 6:
          num2 = Helper.MakeDoubleValid((object) this.lblQuotePercentageTotal.Text);
          break;
      }
    }

    private bool Save()
    {
      bool flag;
      try
      {
        if (this._readOnly)
        {
          flag = true;
        }
        else
        {
          this.Cursor = Cursors.WaitCursor;
          if (App.loggedInUser.UserRegions.Count <= 0)
            throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(this.theSite.RegionID)).Length < 1)
            throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          int num1 = 0;
          if (this.SiteFuelsDataView.Table.Select("tick = 1").Length > 0)
            num1 = Conversions.ToInteger(this.SiteFuelsDataView.Table.Select("tick = 1")[0]["ManagerID"]);
          if (this.chkGasServiceCompleted.Checked && num1 == 69498)
          {
            int num2 = (int) App.ShowMessage("Please select correct fuel type.\r\nCannot find fuel, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            flag = false;
          }
          else
          {
            this.EngineerVisit.IgnoreExceptionsOnSetMethods = true;
            this.EngineerVisit.SetEngineerID = (object) Combo.get_GetSelectedItemValue(this.cboEngineer);
            this.EngineerVisit.SetNotesFromEngineer = (object) this.txtNotesFromEngineer.Text.Trim();
            this.EngineerVisit.SetOutcomeEnumID = (object) Combo.get_GetSelectedItemValue(this.cboOutcome);
            this.EngineerVisit.SetOutcomeDetails = (object) this.txtOutcomeDetails.Text.Trim();
            this.EngineerVisit.SetCustomerName = (object) this.txtCustomer.Text.Trim();
            this.EngineerVisit.SetVisitLocked = this.cbxVisitLockDown.Checked;
            this.EngineerVisit.SetAmountCollected = (object) this.txtAmountCollected.Text;
            this.EngineerVisit.SetPaymentMethodID = (object) Combo.get_GetSelectedItemValue(this.cboPaymentMethod);
            this.EngineerVisit.SetPropertyRented = (object) Combo.get_GetSelectedItemValue(this.cboPropertyRented);
            this.EngineerVisit.SetBondingID = (object) Combo.get_GetSelectedItemValue(this.cboBonding);
            this.EngineerVisit.SetEmergencyControlAccessibleID = (object) Combo.get_GetSelectedItemValue(this.cboEmergencyControlAccessible);
            this.EngineerVisit.SetSignatureSelectedID = (object) Combo.get_GetSelectedItemValue(this.cboSignatureSelected);
            this.EngineerVisit.SetGasInstallationTightnessTestID = (object) Combo.get_GetSelectedItemValue(this.cboGasInstallationTightnessTest);
            this.EngineerVisit.SetGasServiceCompleted = (object) this.chkGasServiceCompleted.Checked;
            this.EngineerVisit.SetFuelID = (object) num1;
            this.EngineerVisit.SetEmailReceipt = (object) this.cbxEmailReceiptToCustomer.Checked;
            this.EngineerVisit.SetRecharge = (object) this.chkRecharge.Checked;
            this.EngineerVisit.setRechargeTypeID = (object) Combo.get_GetSelectedItemValue(this.cboRecharge);
            this.EngineerVisit.setNccRadID = (object) Combo.get_GetSelectedItemValue(this.cboNccRad);
            this.EngineerVisit.SetMeterCappedID = (object) Combo.get_GetSelectedItemValue(this.cboMeterCapped);
            this.EngineerVisit.SetMeterLocationID = (object) Combo.get_GetSelectedItemValue(this.cboMeterLocation);
            this.EngineerVisit.SetUseSORDescription = (object) this.chkSORDesc.Checked;
            if (this.ScheduleOfRateCharges != null && this.chkSORDesc.Checked & this.ScheduleOfRateCharges.Table.Select("tick <> 0").Length == 0 & this.cbxReadyToBeInvoiced.Checked)
            {
              int num2 = (int) App.ShowMessage("You Can not use SOR Descriptions for Invoicing without selecting chargeable SORS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              flag = false;
            }
            else
            {
              if (this.EngineerVisit.EngineerVisitNCCGSR == null)
                this.EngineerVisit.EngineerVisitNCCGSR = new EngineerVisitNCCGSR();
              this.EngineerVisit.EngineerVisitNCCGSR.SetApproxAgeOfBoiler = (object) this.txtApproxAgeOfBoiler.Text;
              this.EngineerVisit.EngineerVisitNCCGSR.SetCertificateTypeID = (object) Combo.get_GetSelectedItemValue(this.cboCertificateTypeID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetCODetectorFittedID = (object) Combo.get_GetSelectedItemValue(this.cboCODetectorFittedID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetCorrectMaterialsUsedID = (object) Combo.get_GetSelectedItemValue(this.cboCorrectMaterialsUsedID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetCylinderTypeID = (object) Combo.get_GetSelectedItemValue(this.cboCylinderTypeID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
              this.EngineerVisit.EngineerVisitNCCGSR.SetHeatingSystemTypeID = (object) Combo.get_GetSelectedItemValue(this.cboHeatingSystemTypeID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetImmersionID = (object) Combo.get_GetSelectedItemValue(this.cboImmersionID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetInstallationPipeWorkCorrectID = (object) Combo.get_GetSelectedItemValue(this.cboInstallationPipeWorkCorrectID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetInstallationSafeToUseID = (object) Combo.get_GetSelectedItemValue(this.cboInstallationSafeToUseID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetJacketID = (object) Combo.get_GetSelectedItemValue(this.cboJacketID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetPartialHeatingID = (object) Combo.get_GetSelectedItemValue(this.cboPartialHeatingID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetRadiators = (object) this.txtRadiators.Text;
              this.EngineerVisit.EngineerVisitNCCGSR.SetStrainerFittedID = (object) Combo.get_GetSelectedItemValue(this.cboStrainerFittedID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetStrainerInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboStrainerInspectedID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetVisualInspectionReason = (object) this.txtVisualInspectionReason.Text;
              this.EngineerVisit.EngineerVisitNCCGSR.SetVisualInspectionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboVisualInspectionSatisfactoryID);
              this.EngineerVisit.EngineerVisitNCCGSR.SetFillDiscID = (object) Combo.get_GetSelectedItemValue(this.cboFillDisc);
              this.EngineerVisit.EngineerVisitNCCGSR.SetSITimerID = (object) Combo.get_GetSelectedItemValue(this.cboSITimer);
              if (this.EngineerVisit.EngineerVisitSMOKE == null)
                this.EngineerVisit.EngineerVisitSMOKE = new EngineerVisitAdditional();
              if (this.EngineerVisit.EngineerVisitCOMO == null)
                this.EngineerVisit.EngineerVisitCOMO = new EngineerVisitAdditional();
              new EngineerVisitValidator().Validate(this.EngineerVisit, this.theSite.CustomerID);
              switch (this.EngineerVisit.StatusEnumID)
              {
                case 4:
                case 5:
                  if (App.ShowMessage("Are you sure you wish to manually complete this visit? (The outcome can not be altered from this point)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                  {
                    flag = false;
                    goto label_45;
                  }
                  else
                    break;
              }
              this.QC.SetApplianceRecorded = (object) Combo.get_GetSelectedItemValue(this.cboQCAppliance);
              this.QC.SetCustomerSigned = (object) Combo.get_GetSelectedItemValue(this.cboQCCustSig);
              this.QC.SetCustomerDetailsIncorrect = (object) Combo.get_GetSelectedItemValue(this.cboQCCustomerDetails);
              this.QC.SetEngineerPaymentReceived = (object) Combo.get_GetSelectedItemValue(this.cboQCEngineerPaymentRecieved);
              this.QC.SetJobTypeIncorrect = (object) Combo.get_GetSelectedItemValue(this.cboQCJobType);
              this.QC.SetJobUploadInTimeScale = (object) Combo.get_GetSelectedItemValue(this.cboQCJobUploadTimescale);
              this.QC.SetLabourTimeMissing = (object) Combo.get_GetSelectedItemValue(this.cboQCLabourTime);
              this.QC.SetLGSRMissing = (object) Combo.get_GetSelectedItemValue(this.cboQCLGSR);
              this.QC.SetOrderNumberAttached = (object) Combo.get_GetSelectedItemValue(this.cboQCOrderNo);
              this.QC.SetPartsConfirmation = (object) Combo.get_GetSelectedItemValue(this.cboQCParts);
              this.QC.SetPaymentCollection = (object) Combo.get_GetSelectedItemValue(this.cboQCPaymentCollection);
              this.QC.SetPaymentMethodDetailed = (object) Combo.get_GetSelectedItemValue(this.cboQCPaymentMethod);
              this.QC.SetPaymentMethodSelectionIncorrect = (object) Combo.get_GetSelectedItemValue(this.cboQCPaymentSelection);
              this.QC.SetSorIncorrect = (object) Combo.get_GetSelectedItemValue(this.cboQCScheduleOfRate);
              this.QC.SetFTFCode = (object) Combo.get_GetSelectedItemValue(this.cboFTFCode);
              this.QC.SetRecall = (object) Combo.get_GetSelectedItemValue(this.cboRecall);
              this.QC.SetEngineerID = (object) Combo.get_GetSelectedItemValue(this.cboRecallEngineer);
              this.QC.SetPoorJobNotes = (object) this.txtQCPoorJobNotes.Text;
              this.QC.SetDocumentsRecieved = this.chkQCDocumentsRecieved.Checked;
              this.QC.DateDocumentsRecieved = Conversions.ToDate(Interaction.IIf(this.chkQCDocumentsRecieved.Checked, (object) this.dtpQCDocumentsRecieved.Value, (object) null));
              this.QC.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
              if (this.QC.Exists)
                App.DB.EngineerVisitQCSQL.Update(this.QC);
              else
                App.DB.EngineerVisitQCSQL.Insert(this.QC);
              JobOfWork Jow = App.DB.JobOfWorks.JobOfWork_Get(this.EngineerVisit.JobOfWorkID);
              PickList oneAsObject = App.DB.Picklists.Get_One_As_Object(Jow.Priority);
              int num2 = 0;
              DataTable table = App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.JOWPriority, false).Table;
              IEnumerator enumerator;
              try
              {
                enumerator = table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Name"], (object) "RC - Recall", false))
                  {
                    num2 = Conversions.ToInteger(current["ManagerID"]);
                    break;
                  }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboRecall), "Yes", false) == 0)
              {
                if (oneAsObject == null)
                {
                  Jow.SetPriority = (object) num2;
                  Jow.PriorityDateSet = DateAndTime.Now;
                  App.DB.JobOfWorks.Update_Priority(Jow);
                }
                else if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(oneAsObject.Name, "RC - Recall", false) > 0U)
                {
                  Jow.SetPriority = (object) num2;
                  Jow.PriorityDateSet = DateAndTime.Now;
                  App.DB.JobOfWorks.Update_Priority(Jow);
                }
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboRecall), "No", false) == 0 && oneAsObject != null && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(oneAsObject.Name, "RC - Recall", false) == 0)
              {
                FRMChangePriority frmChangePriority = new FRMChangePriority();
                int num3 = (int) frmChangePriority.ShowDialog();
                Jow.SetPriority = (object) Combo.get_GetSelectedItemValue(frmChangePriority.cboJobType);
                Jow.PriorityDateSet = DateAndTime.Now;
                App.DB.JobOfWorks.Update_Priority(Jow);
              }
              this.EngineerVisit = App.DB.EngineerVisits.ManuallyComplete(this.EngineerVisit, this.JobItems, this.PartsAndProductsDistribution);
              this.Updating = true;
              flag = true;
            }
          }
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error saving details : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
label_45:
      return flag;
    }

    private DataView AdditionalCharges
    {
      get
      {
        return this._AdditionalCharges;
      }
      set
      {
        this._AdditionalCharges = value;
        this._AdditionalCharges.AllowNew = false;
        this._AdditionalCharges.AllowEdit = false;
        this._AdditionalCharges.AllowDelete = false;
        this._AdditionalCharges.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
        this.dgAdditionalCharges.DataSource = (object) this.AdditionalCharges;
      }
    }

    private DataRow SelectedAdditionalChargesDataRow
    {
      get
      {
        return this.dgAdditionalCharges.CurrentRowIndex != -1 ? this.AdditionalCharges[this.dgAdditionalCharges.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView ScheduleOfRateCharges
    {
      get
      {
        return this._ScheduleOfRateCharges;
      }
      set
      {
        this._ScheduleOfRateCharges = value;
        this._ScheduleOfRateCharges.AllowNew = false;
        this._ScheduleOfRateCharges.AllowEdit = true;
        this._ScheduleOfRateCharges.AllowDelete = false;
        this._ScheduleOfRateCharges.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
        this.dgScheduleOfRateCharges.DataSource = (object) this.ScheduleOfRateCharges;
      }
    }

    private DataRow SelectedScheduleOfRateChargesDataRow
    {
      get
      {
        return this.dgScheduleOfRateCharges.CurrentRowIndex != -1 ? this.ScheduleOfRateCharges[this.dgScheduleOfRateCharges.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private EngineerVisitCharge EngVisitCharge
    {
      get
      {
        return this._engVisitCharge;
      }
      set
      {
        this._engVisitCharge = value;
        if (this.EngVisitCharge == null)
          this.btnInvoice.Visible = false;
        else if (this.EngVisitCharge.InvoiceReadyID == 2)
          this.btnInvoice.Visible = true;
        else
          this.btnInvoice.Visible = false;
      }
    }

    private DataView PartProductsCharges
    {
      get
      {
        return this._PartProductsCharges;
      }
      set
      {
        this._PartProductsCharges = value;
        this._PartProductsCharges.AllowNew = false;
        this._PartProductsCharges.AllowEdit = false;
        this._PartProductsCharges.AllowDelete = false;
        this._PartProductsCharges.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
        this.dgPartsProductCharging.DataSource = (object) this.PartProductsCharges;
      }
    }

    private DataRow SelectedPartProductsChargesDataRow
    {
      get
      {
        return this.dgPartsProductCharging.CurrentRowIndex != -1 ? this.PartProductsCharges[this.dgPartsProductCharging.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private Job Job
    {
      get
      {
        return this._Job;
      }
      set
      {
        this._Job = value;
      }
    }

    private void MakeReadOnly()
    {
      this.tpMainDetails.Enabled = false;
      this.tpAppliances.Enabled = false;
      this.grpVisitWorksheet.Enabled = false;
      this.grpVisitWorksheetExtended.Enabled = false;
      this.grpAlarmInfo.Enabled = false;
      this.grpVisitDefects.Enabled = false;
      this.grpApplianceWorksheet.Enabled = false;
      this.grpAdditionalWorksheet.Enabled = false;
      this.tpTimesheets.Enabled = false;
      this.grpTimesheets.Enabled = false;
      this.tpPartsAndProducts.Enabled = false;
      this.tpOutcomes.Enabled = false;
      this.tpQC.Enabled = false;
      this.tpCharges.Enabled = false;
      this.btnSave.Enabled = false;
      this.cbxVisitLockDown.Enabled = false;
      this._readOnly = true;
    }

    private DataView TimeSheetCharges
    {
      get
      {
        return this._TimeSheetCharges;
      }
      set
      {
        this._TimeSheetCharges = value;
        this._TimeSheetCharges.AllowNew = false;
        this._TimeSheetCharges.AllowEdit = true;
        this._TimeSheetCharges.AllowDelete = false;
        this._TimeSheetCharges.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
        this.dgTimesheetCharges.DataSource = (object) this.TimeSheetCharges;
      }
    }

    private DataRow SelectedTimeSheetChargesDataRow
    {
      get
      {
        return this.dgTimesheetCharges.CurrentRowIndex != -1 ? this.TimeSheetCharges[this.dgTimesheetCharges.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public InvoiceToBeRaised InvoiceToBeRaised
    {
      get
      {
        return this._invoiceToBeRaised;
      }
      set
      {
        this._invoiceToBeRaised = value;
      }
    }

    public void SetupAdditionalChargeDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAdditionalCharges, false);
      DataGridTableStyle tableStyle = this.dgAdditionalCharges.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Description";
      dataGridLabelColumn1.MappingName = "ChargeDescription";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 320;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "C";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Charge";
      dataGridLabelColumn2.MappingName = "Charge";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
      this.dgAdditionalCharges.TableStyles.Add(tableStyle);
    }

    public void SetupSoRChargeDataGrid()
    {
      Helper.SetUpDataGrid(this.dgScheduleOfRateCharges, false);
      DataGridTableStyle tableStyle = this.dgScheduleOfRateCharges.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgScheduleOfRateCharges.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Code";
      dataGridLabelColumn1.MappingName = "Code";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 65;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Category";
      dataGridLabelColumn2.MappingName = "category";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Summary";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 85;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "# Used";
      dataGridLabelColumn4.MappingName = "NumUnitsUsed";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 52;
      dataGridLabelColumn4.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Price";
      dataGridLabelColumn5.MappingName = "Price";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 60;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Charge";
      dataGridLabelColumn6.MappingName = "Total";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 65;
      dataGridLabelColumn6.NullText = "ï¿\x00BD0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
      this.dgScheduleOfRateCharges.TableStyles.Add(tableStyle);
    }

    public void SetupPartProductDataGrid()
    {
      Helper.SetUpDataGrid(this.dgPartsProductCharging, false);
      DataGridTableStyle tableStyle = this.dgPartsProductCharging.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgScheduleOfRateCharges.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 40;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Part/Product";
      dataGridLabelColumn2.MappingName = "Part/Product";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Appliance (part applied to)";
      dataGridLabelColumn3.MappingName = "Asset";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 60;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Warranty? (Appliance on)";
      dataGridLabelColumn4.MappingName = "Warranty";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 55;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Cost";
      dataGridLabelColumn5.MappingName = "Rate";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 45;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Qty";
      dataGridLabelColumn6.MappingName = "Quantity";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 40;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Price";
      dataGridLabelColumn7.MappingName = "Price";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 45;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "C";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Charge";
      dataGridLabelColumn8.MappingName = "Total";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 65;
      dataGridLabelColumn8.NullText = "ï¿\x00BD0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
      this.dgPartsProductCharging.TableStyles.Add(tableStyle);
    }

    public void SetupTimeSheetChargeDataGrid()
    {
      Helper.SetUpDataGrid(this.dgTimesheetCharges, false);
      DataGridTableStyle tableStyle = this.dgTimesheetCharges.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgTimesheetCharges.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yy HH:mm";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Start ";
      dataGridLabelColumn1.MappingName = "StartDateTime";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 95;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yy HH:mm";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "End";
      dataGridLabelColumn2.MappingName = "EndDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 95;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "C";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Eng. Cost";
      dataGridLabelColumn3.MappingName = "EngineerCost";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Price";
      dataGridLabelColumn4.MappingName = "Price";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 60;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "TimesheetID";
      dataGridLabelColumn5.MappingName = "TimesheetID";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 5;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
      this.dgTimesheetCharges.TableStyles.Add(tableStyle);
    }

    private void btnAddAdditionalCharge_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.txtAdditionalChargeDescription.Text.Trim().Length <= 0)
        str += "* Charge Description Required\r\n";
      if (this.txtAdditionalCharge.Text.Trim().Length <= 0)
        str += "* Charge Required\r\n";
      else if (!Versioned.IsNumeric((object) this.txtAdditionalCharge.Text))
        str += "* Charge Must Be Numeric\r\n";
      if (str.Length > 0)
      {
        int num = (int) MessageBox.Show("Please correct the following errors:\r\n" + str, "Additional Charge", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Insert(this.EngineerVisit.EngineerVisitID, this.txtAdditionalChargeDescription.Text, Conversions.ToDouble(this.txtAdditionalCharge.Text));
        this.txtAdditionalCharge.Text = "";
        this.txtAdditionalChargeDescription.Text = "";
        this.PopulateAdditionalCharges(false);
      }
    }

    private void btnRemoveAdditionalCharge_Click(object sender, EventArgs e)
    {
      if (this.SelectedAdditionalChargesDataRow == null)
        return;
      App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete(Conversions.ToInteger(this.SelectedAdditionalChargesDataRow["EngineerVisitAdditionalChargeID"]));
      this.PopulateAdditionalCharges(false);
    }

    private void dgScheduleOfRateCharges_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgScheduleOfRateCharges.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgScheduleOfRateCharges.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedScheduleOfRateChargesDataRow == null)
          return;
        App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete(Conversions.ToInteger(this.SelectedScheduleOfRateChargesDataRow["EngineerVisitScheduleOfRateChargesID"]));
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedScheduleOfRateChargesDataRow["tick"], (object) 0, false))
          App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(this.SelectedScheduleOfRateChargesDataRow["jobitemID"]), Conversions.ToDouble(this.SelectedScheduleOfRateChargesDataRow["Price"]), 1);
        else
          App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(this.SelectedScheduleOfRateChargesDataRow["jobitemID"]), Conversions.ToDouble(this.SelectedScheduleOfRateChargesDataRow["Price"]), 0);
        this.PopulateScheduleOfRateCharges(false);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtNominalCode_TextChanged(object sender, EventArgs e)
    {
      this.SaveVisitCharge(false);
    }

    private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SaveVisitCharge(false);
    }

    private void txtAccountCode_TextChanged(object sender, EventArgs e)
    {
      if (this.txtAccountCode.Text.Trim().Length == 0)
      {
        int num = (int) App.ShowMessage("Account code cannot be blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.txtAccountCode.Text = this.EngVisitCharge.ForSageAccountCode;
      }
      else
        this.SaveVisitCharge(false);
    }

    private void dgPartsProductCharging_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgPartsProductCharging.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgPartsProductCharging.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedPartProductsChargesDataRow == null)
          return;
        double Price = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(this.SelectedPartProductsChargesDataRow["Rate"], (object) (1.0 + (double) Helper.MakeIntegerValid((object) this.txtPartsMarkUp.Text) / 100.0)));
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPartProductsChargesDataRow["Type"], (object) "Part", false))
        {
          try
          {
            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(this.SelectedPartProductsChargesDataRow["ChargeID"]));
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPartProductsChargesDataRow["tick"], (object) 0, false))
            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(this.SelectedPartProductsChargesDataRow["UniqueID"]), Price, 1, Conversions.ToDouble(this.SelectedPartProductsChargesDataRow["Rate"]), Conversions.ToInteger(this.SelectedPartProductsChargesDataRow["PartUsedID"]));
          else
            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(this.SelectedPartProductsChargesDataRow["UniqueID"]), Price, 0, Conversions.ToDouble(this.SelectedPartProductsChargesDataRow["Rate"]), Conversions.ToInteger(this.SelectedPartProductsChargesDataRow["PartUsedID"]));
        }
        else
        {
          App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartProductsChargesDataRow["ChargeID"])));
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPartProductsChargesDataRow["tick"], (object) 0, false))
            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(this.SelectedPartProductsChargesDataRow["UniqueID"]), Price, 1, Conversions.ToDouble(this.SelectedPartProductsChargesDataRow["Rate"]));
          else
            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(this.SelectedPartProductsChargesDataRow["UniqueID"]), Price, 0, Conversions.ToDouble(this.SelectedPartProductsChargesDataRow["Rate"]));
        }
        this.PopulatePartsProductsCharges(false, true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void rdoJobValue_CheckedChanged(object sender, EventArgs e)
    {
      if (this.rdoJobValue.Checked)
      {
        this.gpbInvoice.Enabled = true;
        this.ShowEditableVisitCharges();
        this.cbxReadyToBeInvoiced.Enabled = true;
        if (this.EngVisitCharge != null)
          this.cbxReadyToBeInvoiced.Checked = this.EngVisitCharge.InvoiceReadyID == 2;
        this.txtPercentOfQuote.ReadOnly = true;
      }
      this.SaveVisitCharge(false);
    }

    private void rdoChargeOther_CheckedChanged(object sender, EventArgs e)
    {
      if (this.rdoChargeOther.Checked)
      {
        if (this.Job != null)
        {
          if (this.Job.JobDefinitionEnumID == 1)
          {
            this.gpbInvoice.Enabled = true;
            this.ShowEditableVisitCharges();
            if (this.EngVisitCharge != null)
              this.cbxReadyToBeInvoiced.Checked = this.EngVisitCharge.InvoiceReadyID == 2;
          }
          else
          {
            this.gpbInvoice.Enabled = false;
            this.cbxReadyToBeInvoiced.Checked = false;
            this.txtPartsMarkUp.Visible = false;
            this.lblPartsMarkUp.Visible = false;
            this.txtPartsMarkUp.Enabled = false;
            this.txtPartsProductTotal.ReadOnly = true;
            this.txtTimesheetTotal.ReadOnly = true;
          }
        }
        this.txtPercentOfQuote.ReadOnly = true;
      }
      this.SaveVisitCharge(false);
    }

    private void rdoPercentageOfQuoteValue_CheckedChanged(object sender, EventArgs e)
    {
      if (this.rdoPercentageOfQuoteValue.Checked)
      {
        this.gpbInvoice.Enabled = true;
        this.ShowEditableVisitCharges();
        if (this.EngVisitCharge != null)
          this.cbxReadyToBeInvoiced.Checked = this.EngVisitCharge.InvoiceReadyID == 2;
        this.txtPercentOfQuote.ReadOnly = false;
      }
      this.SaveVisitCharge(false);
    }

    private void txtPercentOfQuote_TextChanged(object sender, EventArgs e)
    {
      if ((uint) this.txtPercentOfQuote.Text.Trim().Length > 0U)
      {
        if (Versioned.IsNumeric((object) this.txtPercentOfQuote.Text))
        {
          this.lblQuotePercentageTotal.Text = Microsoft.VisualBasic.Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtCharge.Text) / 100.0 * Conversions.ToDouble(this.txtPercentOfQuote.Text)), "C");
          this.SaveVisitCharge(false);
        }
        else
          this.lblQuotePercentageTotal.Text = "ERROR";
      }
      else
        this.lblQuotePercentageTotal.Text = "ERROR";
    }

    private void dgTimesheetCharges_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgTimesheetCharges.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgTimesheetCharges.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedTimeSheetChargesDataRow == null)
          return;
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedTimeSheetChargesDataRow["tick"], (object) 0, false))
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedTimeSheetChargesDataRow["EngineerVisitTimesheetChargeID"], (object) 0, false))
            this.InsertEngineerTimnesheetCharge(Conversions.ToDate(this.SelectedTimeSheetChargesDataRow["StartDateTime"]), Conversions.ToDate(this.SelectedTimeSheetChargesDataRow["EndDateTime"]), Conversions.ToInteger(this.SelectedTimeSheetChargesDataRow["TimesheetID"]), Conversions.ToInteger(this.SelectedTimeSheetChargesDataRow["TimeSheetTypeID"]), Conversions.ToDouble(this.SelectedTimeSheetChargesDataRow["EngineerCost"]), true, Conversions.ToInteger(this.SelectedTimeSheetChargesDataRow["EngineerVisitID"]));
          else
            App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(this.SelectedTimeSheetChargesDataRow["EngineerVisitTimesheetChargeID"]), 1);
        }
        else
          App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(this.SelectedTimeSheetChargesDataRow["EngineerVisitTimesheetChargeID"]), 0);
        this.PopulateTimeSheetCharges(false, true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void cbxReadyToBeInvoiced_CheckedChanged(object sender, EventArgs e)
    {
      if (this.EngVisitCharge == null)
        return;
      if (this.cbxReadyToBeInvoiced.Checked)
      {
        double num1 = 0.0;
        if (this.Job.JobDefinitionEnumID == 1)
        {
          switch ((FSM.Entity.Sys.Enums.JobChargingType) this.EngVisitCharge.ChargeTypeID)
          {
            case FSM.Entity.Sys.Enums.JobChargingType.JobValue:
              num1 = this.EngVisitCharge.JobValue;
              break;
            case FSM.Entity.Sys.Enums.JobChargingType.QuoteValue:
              num1 = Helper.MakeDoubleValid((object) this.txtCharge.Text);
              break;
            case FSM.Entity.Sys.Enums.JobChargingType.PercentageOfQuote:
              num1 = this.EngVisitCharge.Charge;
              break;
          }
        }
        else
          num1 = this.EngVisitCharge.JobValue;
        if (num1 > 0.0)
        {
          this.SetPriceIncVAT();
          this.gpbScheduleOfRates.Enabled = false;
          this.gpbPartsAndProducts.Enabled = false;
          this.gpbTimesheets.Enabled = false;
          this.gpbAdditionalCharges.Enabled = false;
          this.gpbCharges.Enabled = false;
          this.cbxVisitLockDown.Enabled = false;
          this.btnSave.Enabled = false;
        }
        else
        {
          int num2 = (int) App.ShowMessage("Charge Amount must be greater than zero", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.cbxReadyToBeInvoiced.Checked = false;
        }
      }
      else
      {
        this.gpbScheduleOfRates.Enabled = true;
        this.gpbPartsAndProducts.Enabled = true;
        this.gpbTimesheets.Enabled = true;
        this.gpbAdditionalCharges.Enabled = true;
        this.gpbCharges.Enabled = true;
        this.cbxVisitLockDown.Enabled = true;
        this.btnSave.Enabled = true;
      }
      this.SaveVisitCharge(false);
      this.LoadReadyToBeInvoicedDetails();
    }

    private void SetPriceIncVAT()
    {
      if (this.EngVisitCharge == null)
        return;
      VATRates vatRates = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVATRate)) >= 1.0 ? App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVATRate))) : App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(this.dtpRaiseInvoiceOn.Value));
      if (vatRates != null)
        this.txtPriceIncVAT.Text = Microsoft.VisualBasic.Strings.Format((object) (this.EngVisitCharge.JobValue * (1.0 + vatRates.VATRate / 100.0)), "C");
    }

    private void dtpRaiseInvoiceOn_ValueChanged(object sender, EventArgs e)
    {
      if (this.InvoiceToBeRaised == null)
        return;
      this.SetPriceIncVAT();
      this.SaveInvoiceToBeRaisedDetails();
    }

    private void btnAddSoR_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      table.Columns.Add("ScheduleOfRatesCategoryID");
      table.Columns.Add("Category");
      table.Columns.Add("Code");
      table.Columns.Add("Description");
      table.Columns.Add("Price");
      table.Columns.Add("Quantity");
      table.Columns.Add("Total");
      table.Columns.Add("RateID");
      table.Columns.Add("TimeInMins");
      table.Columns.Add("SystemLinkID");
      int siteId = this.theSite.SiteID;
      DataView dataView = new DataView(table);
      ref DataView local = ref dataView;
      using (FRMSiteScheduleOfRateList scheduleOfRateList = new FRMSiteScheduleOfRateList(siteId, ref local, true, false))
      {
        int num = (int) scheduleOfRateList.ShowDialog();
      }
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          JobItem jobItem = App.DB.JobItems.Insert(new JobItem()
          {
            SetJobOfWorkID = (object) this.EngineerVisit.JobOfWorkID,
            SetQty = RuntimeHelpers.GetObjectValue(current["Quantity"]),
            SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"]),
            SetSummary = RuntimeHelpers.GetObjectValue(current["Description"]),
            SetSystemLinkID = RuntimeHelpers.GetObjectValue(current["SystemLinkID"])
          });
          App.DB.EngineerVisits.EngineerVisitUnitsUsed_Insert(this.EngineerVisit.EngineerVisitID, jobItem.JobItemID, Convert.ToDouble(jobItem.Qty));
          App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(this.EngineerVisit.EngineerVisitID, jobItem.JobItemID, Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"])), 1);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.JobItems = App.DB.EngineerVisits.EngineerVisitUnitsUsed_Get_For_EngineerVisitID(this.EngineerVisit.EngineerVisitID);
      this.dgJobItems.DataSource = (object) this.JobItems;
      this.PopulateScheduleOfRateCharges(false);
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (this.InvoiceToBeRaised == null)
        return;
      FRMSelectInvoiceAddress selectInvoiceAddress = new FRMSelectInvoiceAddress(this.theSite.SiteID);
      if (selectInvoiceAddress.ShowDialog() != DialogResult.OK)
      {
        selectInvoiceAddress.Dispose();
      }
      else
      {
        this.InvoiceToBeRaised.SetAddressLinkID = (object) selectInvoiceAddress.AddressLinkID;
        this.InvoiceToBeRaised.SetAddressTypeID = (object) selectInvoiceAddress.AddressTypeID;
        selectInvoiceAddress.Dispose();
        this.SaveInvoiceToBeRaisedDetails();
      }
    }

    private void ShowEditableVisitCharges()
    {
      if (!App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.VisitCharge))
        return;
      this.txtPartsMarkUp.Visible = true;
      this.lblPartsMarkUp.Visible = true;
      this.txtPartsMarkUp.Enabled = true;
      this.txtPartsProductTotal.ReadOnly = false;
      this.txtTimesheetTotal.ReadOnly = false;
    }

    private void InsertCharges(QuoteJob jbQuote)
    {
      this.EngVisitCharge = new EngineerVisitCharge();
      switch (this.Job.JobDefinitionEnumID)
      {
        case 1:
          if (jbQuote == null)
          {
            this.EngVisitCharge.SetLabourRate = (object) App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(this.EngineerVisit.EngineerVisitID);
            this.EngVisitCharge.SetChargeTypeID = (object) 1;
            this.EngVisitCharge.SetCharge = (object) 0;
            this.EngVisitCharge.SetInvoiceReadyID = (object) 1;
            break;
          }
          this.EngVisitCharge.SetLabourRate = (object) Helper.MakeDoubleValid((object) jbQuote.MileageRate);
          this.EngVisitCharge.SetChargeTypeID = (object) 2;
          this.EngVisitCharge.SetCharge = (object) 0;
          this.EngVisitCharge.SetInvoiceReadyID = (object) 1;
          break;
        case 2:
          int invoiceFrequency = App.DB.EngineerVisitCharge.EngineerVisitCharge_GetContractInvoiceFrequency(this.EngineerVisit.EngineerVisitID);
          this.EngVisitCharge.SetLabourRate = (object) App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_ContractJob(this.Job.JobID);
          if (invoiceFrequency == 7)
          {
            this.EngVisitCharge.SetChargeTypeID = (object) 1;
            this.EngVisitCharge.SetCharge = (object) 0;
            this.EngVisitCharge.SetInvoiceReadyID = (object) 1;
            this.lblContractPerVisit.Visible = true;
            break;
          }
          this.EngVisitCharge.SetChargeTypeID = (object) 3;
          this.EngVisitCharge.SetCharge = (object) 0;
          this.EngVisitCharge.SetInvoiceReadyID = (object) 3;
          this.lblContractPerVisit.Visible = false;
          break;
        case 3:
          this.EngVisitCharge.SetLabourRate = (object) App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(this.EngineerVisit.EngineerVisitID);
          this.EngVisitCharge.SetChargeTypeID = (object) 1;
          this.EngVisitCharge.SetCharge = (object) 0;
          this.EngVisitCharge.SetInvoiceReadyID = (object) 1;
          break;
        case 4:
          this.EngVisitCharge.SetLabourRate = (object) App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(this.EngineerVisit.EngineerVisitID);
          this.EngVisitCharge.SetChargeTypeID = (object) 4;
          this.EngVisitCharge.SetCharge = (object) 0;
          this.EngVisitCharge.SetInvoiceReadyID = (object) 3;
          break;
      }
      this.CustomerCharge = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(this.theSite.CustomerID);
      this.EngVisitCharge.SetNominalCode = (object) App.DB.Customer.Customer_Get_ForSiteID(this.theSite.SiteID).Nominal;
      Engineer engineer = App.DB.Engineer.Engineer_Get(this.EngineerVisit.EngineerID);
      int costCentre = this.GetCostCentre();
      this.EngVisitCharge.SetDepartment = costCentre != -1 ? (object) costCentre.ToString() : (object) engineer?.Department;
      this.EngVisitCharge.SetForSageAccountCode = (object) "";
      this.EngVisitCharge.SetMainContractorDiscount = (object) App.DB.EngineerVisitCharge.EngineerVisit_Get_CustomerContractorDiscount(this.EngineerVisit.EngineerVisitID);
      this.EngVisitCharge.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
      this.EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Insert(this.EngVisitCharge);
      double num1 = 0.0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.JobItems.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["JobItemID"]), Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"])), 1);
          num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"]));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      this.txtPartsMarkUp.Text = Conversions.ToString(this.CustomerCharge.PartsMarkup);
      IEnumerator enumerator2;
      try
      {
        enumerator2 = this.EngineerVisit.PartsAndProductsUsed.Table.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Part", false))
            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["ID"]), Conversions.ToDouble(current["SellPrice"]), 1, this.GetPartProductCost(current), Conversions.ToInteger(current["UniqueID"]));
          else
            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["ID"]), Conversions.ToDouble(current["SellPrice"]), 1, this.GetPartProductCost(current));
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      bool Tick = true;
      if (num1 > 0.0)
        Tick = false;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      double num5 = 0.0;
      double num6 = 0.0;
      double num7 = 0.0;
      if (engineer != null)
      {
        num5 = engineer.CostToCompanyNormal;
        num6 = engineer.CostToCompanyTimeAndHalf;
        num7 = engineer.CostToCompanyDouble;
        this.InsertVisitEngineer(engineer);
      }
      if (this.CustomerCharge == null)
        return;
      DataTable table = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Get(this.theSite.CustomerID, this.Job.JobTypeID).Table;
      if (table.Rows.Count > 0)
      {
        int integer = Conversions.ToInteger(table.Rows[0]["CustomerScheduleOfRateID"]);
        CustomerScheduleOfRate customerScheduleOfRate = App.DB.CustomerScheduleOfRate.Get(integer);
        num2 = customerScheduleOfRate.Price;
        num3 = customerScheduleOfRate.Price;
        num4 = customerScheduleOfRate.Price;
      }
      IEnumerator enumerator3;
      try
      {
        enumerator3 = this.EngineerVisit.TimeSheets.Table.Rows.GetEnumerator();
        while (enumerator3.MoveNext())
        {
          DataRow current = (DataRow) enumerator3.Current;
          this.InsertEngineerTimnesheetCharge(Conversions.ToDate(current["StartDateTime"]), Conversions.ToDate(current["EndDateTime"]), Conversions.ToInteger(current["EngineerVisitTimeSheetID"]), Conversions.ToInteger(current["TimeSheetTypeID"]), 0.0, Tick, this.EngineerVisit.EngineerVisitID);
        }
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
    }

    private void InsertVisitEngineer(Engineer engineer)
    {
      EngineerVisitEngineer eve = new EngineerVisitEngineer()
      {
        EngineerVisitId = this.EngineerVisit.EngineerVisitID,
        EngineerId = engineer.EngineerID,
        Department = Helper.MakeIntegerValid((object) engineer.Department),
        OftecNo = engineer.OftecNo,
        GasSafeNo = engineer.GasSafeNo,
        ManagerId = engineer.ManagerUserID,
        CostToCompany = engineer.CostToCompanyNormal
      };
      App.DB.EvEngineer.Insert(eve);
    }

    private void InsertEngineerTimnesheetCharge(
      DateTime StartDateTime,
      DateTime EndDateTime,
      int TimesheetID,
      int TimesheettypeID,
      double EngCost,
      bool Tick,
      int EngineerVisitID)
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      double num5 = 0.0;
      double num6 = 0.0;
      Engineer engineer = App.DB.Engineer.Engineer_Get(this.EngineerVisit.EngineerID);
      if (engineer != null)
      {
        num4 = engineer.CostToCompanyNormal;
        num5 = engineer.CostToCompanyTimeAndHalf;
        num6 = engineer.CostToCompanyDouble;
      }
      DataTable table = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Get(this.theSite.CustomerID, this.Job.JobTypeID).Table;
      if (table.Rows.Count > 0)
      {
        int integer = Conversions.ToInteger(table.Rows[0]["CustomerScheduleOfRateID"]);
        CustomerScheduleOfRate customerScheduleOfRate = App.DB.CustomerScheduleOfRate.Get(integer);
        num1 = customerScheduleOfRate.Price;
        num2 = customerScheduleOfRate.Price;
        num3 = customerScheduleOfRate.Price;
      }
      double Price = 0.0;
      string Summary = "";
      double EngineerCost = 0.0;
      switch (App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_BankHoliday(StartDateTime))
      {
        case 0:
          DataView dataView1 = new DataView();
          DataView dataView2 = App.DB.EngineerVisitCharge.EngineerVisitTimesheetCharge_ByTimeSheet(TimesheetID);
          IEnumerator enumerator;
          try
          {
            enumerator = dataView2.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              switch (Conversions.ToInteger(current["rate"]))
              {
                case 1:
                  Price = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Price, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(current["Total"], (object) 60), (object) num1)));
                  Summary = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Summary, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Basic: ", current["Total"]), (object) "mins@"), (object) Microsoft.VisualBasic.Strings.Format((object) num1, "C")), (object) "/hr; ")));
                  EngineerCost = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) EngineerCost, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(current["Total"], (object) 60), (object) num4)));
                  break;
                case 2:
                  Price = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Price, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(current["Total"], (object) 60), (object) num2)));
                  Summary = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Summary, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Time&Half: ", current["Total"]), (object) "mins@"), (object) Microsoft.VisualBasic.Strings.Format((object) num2, "C")), (object) "/hr; ")));
                  EngineerCost = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) EngineerCost, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(current["Total"], (object) 60), (object) num5)));
                  break;
                case 3:
                  Price = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Price, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(current["Total"], (object) 60), (object) num3)));
                  Summary = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Summary, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Double: ", current["Total"]), (object) "mins@"), (object) Microsoft.VisualBasic.Strings.Format((object) num3, "C")), (object) "/hr; ")));
                  EngineerCost = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) EngineerCost, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(current["Total"], (object) 60), (object) num6)));
                  break;
              }
            }
            break;
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        case 1:
          Price = (double) DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 60.0 * num1;
          Summary = Summary + "Bank Holiday Rate (Basic): " + Conversions.ToString(DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + "mins@" + Microsoft.VisualBasic.Strings.Format((object) num1, "C") + "/hr; ";
          EngineerCost += (double) DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 60.0 * num4;
          goto default;
        case 2:
          Price = (double) DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 60.0 * num2;
          Summary = Summary + "Bank Holiday Rate (Time&Half): " + Conversions.ToString(DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + "mins@" + Microsoft.VisualBasic.Strings.Format((object) num2, "C") + "/hr; ";
          EngineerCost += (double) DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 60.0 * num5;
          goto default;
        case 3:
          Price = (double) DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 60.0 * num3;
          Summary = Summary + "Bank Holiday Rate (Double): " + Conversions.ToString(DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + "mins@" + Microsoft.VisualBasic.Strings.Format((object) num3, "C") + "/hr; ";
          EngineerCost += (double) DateAndTime.DateDiff(DateInterval.Minute, StartDateTime, EndDateTime, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 60.0 * num6;
          goto default;
      }
      if (EngCost > 0.0)
        EngineerCost = EngCost;
      App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Insert(EngineerVisitID, -(Tick ? 1 : 0), StartDateTime, EndDateTime, Price, TimesheettypeID, Summary, EngineerCost);
    }

    private void DeleteCharges()
    {
      if (this.EngVisitCharge != null)
        App.DB.EngineerVisitCharge.EngineerVisitCharge_Delete(this.EngVisitCharge.EngineerVisitChargeID);
      IEnumerator enumerator1;
      if (this.AdditionalCharges != null)
      {
        try
        {
          enumerator1 = this.AdditionalCharges.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete(Conversions.ToInteger(current["EngineerVisitAdditionalChargeID"]));
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
      }
      IEnumerator enumerator2;
      if (this.ScheduleOfRateCharges != null)
      {
        try
        {
          enumerator2 = this.ScheduleOfRateCharges.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete(Conversions.ToInteger(current["EngineerVisitScheduleOfRateChargesID"]));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      App.DB.EvEngineer.Delete((object) this.EngineerVisit.EngineerVisitID, DeleteBy.EngineerVisitId);
      App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID(this.EngineerVisit.EngineerVisitID);
      App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Delete(this.EngineerVisit.EngineerVisitID);
    }

    private void PopulateCharges(bool initialLoad = false)
    {
      this.Loading = true;
      QuoteJob jbQuote = new QuoteJob();
      if (this.Job.JobDefinitionEnumID == 1)
        jbQuote = App.DB.QuoteJob.Get(this.Job.QuoteID);
      this.EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(this.EngineerVisit.EngineerVisitID);
      if (this.EngVisitCharge == null)
        this.InsertCharges(jbQuote);
      if (Helper.MakeDoubleValid((object) this.txtPartsMarkUp.Text) == 0.0)
        this.txtPartsMarkUp.Text = Conversions.ToString(this.EngVisitCharge.PartsMarkUp);
      this.rdoPercentageOfQuoteValue.Visible = false;
      this.lblPercent.Visible = false;
      this.txtPercentOfQuote.Visible = false;
      this.txtCharge.Visible = false;
      this.lblEquals.Visible = false;
      this.lblQuotePercentageTotal.Visible = false;
      this.lblOR.Visible = false;
      switch ((FSM.Entity.Sys.Enums.JobChargingType) this.EngVisitCharge.ChargeTypeID)
      {
        case FSM.Entity.Sys.Enums.JobChargingType.JobValue:
          this.rdoJobValue.Checked = true;
          break;
        case FSM.Entity.Sys.Enums.JobChargingType.PercentageOfQuote:
          this.rdoPercentageOfQuoteValue.Checked = true;
          this.txtPercentOfQuote.Text = Conversions.ToString(this.EngVisitCharge.Charge);
          break;
        default:
          this.rdoChargeOther.Checked = true;
          break;
      }
      switch (this.Job.JobDefinitionEnumID)
      {
        case 1:
          this.rdoChargeOther.Text = "No Charge For Callout Work";
          break;
        case 2:
          this.rdoChargeOther.Text = "No Charge - included On Contract Invoice";
          break;
        case 3:
          this.rdoChargeOther.Text = "No Charge For Callout Work";
          break;
        case 4:
          this.rdoChargeOther.Text = "No Charge For Miscellaneous Work";
          break;
      }
      switch (this.EngVisitCharge.InvoiceReadyID)
      {
        case 1:
          this.cbxReadyToBeInvoiced.Checked = false;
          this.cbxReadyToBeInvoiced.Enabled = true;
          break;
        case 2:
          this.cbxReadyToBeInvoiced.Checked = true;
          this.cbxReadyToBeInvoiced.Enabled = true;
          break;
        case 3:
          this.cbxReadyToBeInvoiced.Checked = false;
          this.cbxReadyToBeInvoiced.Enabled = false;
          break;
      }
      this.PopulateCostsTo();
      this.PopulateSageDetails();
      this.PopulateAdditionalCharges(true);
      this.PopulateScheduleOfRateCharges(true);
      this.PopulatePartsProductsCharges(true, false);
      this.PopulateTimeSheetCharges(true, false);
      this.CalculateJobValue();
      this.InvoiceToBeRaised = App.DB.InvoiceToBeRaised.InvoiceToBeRaised_Get_By_LinkID(this.EngVisitCharge.EngineerVisitChargeID, FSM.Entity.Sys.Enums.InvoiceType.Visit);
      DataTable dataTable1 = new DataTable();
      if (this.InvoiceToBeRaised != null)
      {
        this.DisplayInvoiceAddress(this.InvoiceToBeRaised.AddressLinkID, this.InvoiceToBeRaised.AddressTypeID);
        DataTable dataTable2 = App.DB.ExecuteWithReturn("Select TOP(1) i.VATRateID, i.InvoiceNumber, i.TermID, i.PaidByID,il.Amount,il.CreditAmount from tblInvoiced i inner  JOIN (Select SUM(Amount) Amount , ISNULL(SUM(CreditAmount),0) CreditAmount, InvoicedID,InvoiceToBeRaisedID from tblInvoicedLines il2 LEFT JOIN tblInvoicedLinesCredit ilc On ilc.InvoicedLineID = il2.InvoicedLineID   Group by InvoicedID,InvoiceToBeRaisedID) il On il.invoicedid = i.InvoicedID  where InvoiceToBeRaisedID =  " + Conversions.ToString(this.InvoiceToBeRaised.InvoiceToBeRaisedID), true);
        DataTable dataTable3 = App.DB.ExecuteWithReturn("Select PaymentTermID,TaxrateID from tblInvoiceToBeRaised where InvoiceToBeRaisedID =  " + Conversions.ToString(this.InvoiceToBeRaised.InvoiceToBeRaisedID), true);
        if (dataTable2.Rows.Count == 0 || Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["VATRateID"])))
        {
          ComboBox comboBox = this.cboVATRate;
          Combo.SetUpCombo(ref comboBox, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
          this.cboVATRate = comboBox;
          if (dataTable3 == null || Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable3.Rows[0]["TaxrateID"])))
          {
            comboBox = this.cboVATRate;
            Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(6));
            this.cboVATRate = comboBox;
            comboBox = this.cboInvType;
            Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(69482));
            this.cboInvType = comboBox;
          }
          else
          {
            comboBox = this.cboVATRate;
            Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(dataTable3.Rows[0]["TaxrateID"]));
            this.cboVATRate = comboBox;
            comboBox = this.cboInvType;
            Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(dataTable3.Rows[0]["PaymentTermID"]));
            this.cboInvType = comboBox;
          }
        }
        else
        {
          ComboBox comboBox = this.cboVATRate;
          Combo.SetUpCombo(ref comboBox, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
          this.cboVATRate = comboBox;
          comboBox = this.cboVATRate;
          Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(dataTable2.Rows[0]["VATRateID"]));
          this.cboVATRate = comboBox;
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TermID"])))
          {
            comboBox = this.cboInvType;
            Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(dataTable2.Rows[0]["TermID"]));
            this.cboInvType = comboBox;
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["PaidByID"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable2.Rows[0]["TermID"], (object) 69491, false))
            {
              comboBox = this.cboPaidBy;
              Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(dataTable2.Rows[0]["PaidByID"]));
              this.cboPaidBy = comboBox;
            }
          }
          else
          {
            comboBox = this.cboInvType;
            Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(69482));
            this.cboInvType = comboBox;
          }
          this.txtInvNo.Text = Conversions.ToString(dataTable2.Rows[0]["InvoiceNumber"]);
          this.txtInvAmount.Text = Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["Amount"]), "C");
          this.txtCreditAmount.Text = Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["CreditAmount"]), "C");
        }
        this.dtpRaiseInvoiceOn.Value = this.InvoiceToBeRaised.RaiseDate;
        if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(this.InvoiceToBeRaised.InvoiceToBeRaisedID).Table.Rows.Count > 0)
          this.gpbInvoice.Enabled = false;
        else
          this.gpbInvoice.Enabled = true;
      }
      else
      {
        ComboBox comboBox = this.cboVATRate;
        Combo.SetUpCombo(ref comboBox, App.DB.VATRatesSQL.VATRates_GetAll_Valid().Table, "VATRateID", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
        this.cboVATRate = comboBox;
        comboBox = this.cboVATRate;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(6));
        this.cboVATRate = comboBox;
        comboBox = this.cboInvType;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(69482));
        this.cboInvType = comboBox;
      }
      this.Loading = false;
      this.chkSORDesc.Checked = this.EngineerVisit.UseSORDescription;
      if (initialLoad)
        this.chkShowJobCharges.Checked = this.EngVisitCharge.HasChargesFromJob;
      if (this.chkSORDesc.Checked)
        this.txtNotesFromEngineer.Enabled = false;
      else
        this.txtNotesFromEngineer.Enabled = true;
      this.SaveVisitCharge(initialLoad);
      this.ShowEditableVisitCharges();
    }

    private void PopulateAdditionalCharges(bool batchRun = false)
    {
      this.AdditionalCharges = App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_GetAll(this.EngineerVisit.EngineerVisitID);
      double num = 0.0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.AdditionalCharges.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          num += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Charge"]));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtAdditionalChargeTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num, "C");
      if (batchRun)
        return;
      this.CalculateJobValue();
    }

    private void PopulateScheduleOfRateCharges(bool batchRun = false)
    {
      this.ScheduleOfRateCharges = App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(this.EngineerVisit.EngineerVisitID);
      double num = 0.0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ScheduleOfRateCharges.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
            num += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Total"]));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtScheduleOfRatesTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num, "C");
      if (batchRun)
        return;
      this.CalculateJobValue();
    }

    private void PopulateSageDetails()
    {
      int costCentre = this.GetCostCentre();
      if (this.EngVisitCharge != null)
      {
        this.txtNominalCode.Text = this.EngVisitCharge.NominalCode;
        if (string.IsNullOrEmpty(this.EngVisitCharge.Department))
        {
          ComboBox cboDept = this.cboDept;
          Combo.SetSelectedComboItem_By_Value(ref cboDept, Conversions.ToString(costCentre));
          this.cboDept = cboDept;
        }
        else
        {
          ComboBox cboDept = this.cboDept;
          Combo.SetSelectedComboItem_By_Value(ref cboDept, this.EngVisitCharge.Department);
          this.cboDept = cboDept;
        }
        this.txtAccountCode.Text = this.EngVisitCharge.ForSageAccountCode;
      }
      else
      {
        this.txtNominalCode.Text = "";
        ComboBox cboDept = this.cboDept;
        Combo.SetSelectedComboItem_By_Value(ref cboDept, Conversions.ToString(costCentre));
        this.cboDept = cboDept;
        this.txtAccountCode.Text = "";
      }
    }

    private void PopulatePartsProductsCharges(bool batchRun = false, bool recalc = false)
    {
      this.PartProductsCharges = !this.chkShowJobCharges.Checked ? App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(this.EngineerVisit.EngineerVisitID) : App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_JobID(this.Job.JobID, this.EngineerVisit.EngineerVisitID);
      Decimal num1 = new Decimal();
      Decimal num2 = new Decimal();
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.PartProductsCharges.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          num2 = new Decimal(Convert.ToDouble(num2) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Rate"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Quantity"])));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (Decimal.Compare(this.EngVisitCharge.PartsPrice, Decimal.Zero) > 0)
        num1 = this.EngVisitCharge.PartsPrice;
      if (recalc | Decimal.Compare(this.EngVisitCharge.PartsPrice, Decimal.Zero) == 0)
      {
        num1 = new Decimal();
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.PartProductsCharges.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
              num1 = new Decimal(Convert.ToDouble(num1) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Total"])));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      this.txtPartsProductTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num1, "C");
      this.txtPartProductCost.Text = Microsoft.VisualBasic.Strings.Format((object) num2, "C");
      DataRow[] dataRowArray = this.PartProductsCharges.Table.Select("Tick = " + Conversions.ToString(true));
      int num3 = (dataRowArray != null ? new int?(((IEnumerable<DataRow>) dataRowArray).Count<DataRow>()) : new int?()).Value;
      if (num3 == this.PartProductsCharges.Count)
        this.chkPartsSelectAll.Checked = true;
      if (num3 == 0)
        this.chkPartsSelectAll.Checked = false;
      if (batchRun)
        return;
      this.CalculateJobValue();
    }

    private void PopulateTimeSheetCharges(bool batchRun = false, bool recalc = false)
    {
      this.TimeSheetCharges = !this.chkShowJobCharges.Checked ? App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get(this.EngineerVisit.EngineerVisitID) : App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get_ForJob(this.Job.JobID);
      double num1 = 0.0;
      double num2 = 0.0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.TimeSheetCharges.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          num2 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["EngineerCost"]));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (Decimal.Compare(this.EngVisitCharge.LabourPrice, Decimal.Zero) > 0)
        num1 = Convert.ToDouble(this.EngVisitCharge.LabourPrice);
      if (recalc | Decimal.Compare(this.EngVisitCharge.LabourPrice, Decimal.Zero) == 0)
      {
        num1 = 0.0;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.TimeSheetCharges.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
              num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"]));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      this.txtTimesheetTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num1, "C");
      this.txtEngineerCostTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num2, "C");
      DataRow[] dataRowArray = this.TimeSheetCharges.Table.Select("Tick = " + Conversions.ToString(true));
      int num3 = (dataRowArray != null ? new int?(((IEnumerable<DataRow>) dataRowArray).Count<DataRow>()) : new int?()).Value;
      if (num3 == this.TimeSheetCharges.Count)
        this.chkTimesheetSelectAll.Checked = true;
      if (num3 == 0)
        this.chkTimesheetSelectAll.Checked = false;
      if (batchRun)
        return;
      this.CalculateJobValue();
    }

    private void CalculateJobValue()
    {
      this.txtJobValue.Text = Microsoft.VisualBasic.Strings.Format((object) (0.0 + Helper.MakeDoubleValid((object) this.txtScheduleOfRatesTotal.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtAdditionalChargeTotal.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtPartsProductTotal.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtTimesheetTotal.Text.Replace("£", ""))), "C");
      if (this.EngVisitCharge == null)
        this.EngVisitCharge = new EngineerVisitCharge();
      this.SaveVisitCharge(false);
      this.Profitable();
    }

    private void SaveVisitCharge(bool initialLoad = false)
    {
      if (!this.Loading)
      {
        if (this.EngVisitCharge == null)
          this.EngVisitCharge = new EngineerVisitCharge();
        string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
        if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) < 0)
        {
          int num = (int) App.ShowMessage("Please select a department!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          this.EngVisitCharge.SetNominalCode = (object) this.txtNominalCode.Text.Trim();
          this.EngVisitCharge.SetDepartment = (object) Combo.get_GetSelectedItemValue(this.cboDept);
          this.EngVisitCharge.SetForSageAccountCode = (object) this.txtAccountCode.Text.Trim();
          this.EngVisitCharge.SetMainContractorDiscount = (object) 0;
          this.EngVisitCharge.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
          this.EngVisitCharge.SetJobValue = (object) Helper.MakeDoubleValid((object) this.txtJobValue.Text.Replace("£", ""));
          this.EngVisitCharge.SetTaxRateID = (object) Combo.get_GetSelectedItemValue(this.cboVATRate);
          if (this.rdoJobValue.Checked)
          {
            this.EngVisitCharge.SetChargeTypeID = (object) 1;
            this.EngVisitCharge.SetCharge = (object) 0;
            this.EngVisitCharge.SetInvoiceReadyID = !this.cbxReadyToBeInvoiced.Checked ? (object) 1 : (object) 2;
          }
          else if (this.rdoPercentageOfQuoteValue.Checked)
          {
            this.EngVisitCharge.SetChargeTypeID = (object) 6;
            this.EngVisitCharge.SetCharge = (object) Helper.MakeDoubleValid((object) this.txtPercentOfQuote.Text.Trim());
            this.EngVisitCharge.SetInvoiceReadyID = !this.cbxReadyToBeInvoiced.Checked ? (object) 1 : (object) 2;
          }
          else
          {
            switch (this.Job.JobDefinitionEnumID)
            {
              case 1:
                this.EngVisitCharge.SetChargeTypeID = (object) 2;
                this.EngVisitCharge.SetCharge = (object) 0;
                this.EngVisitCharge.SetInvoiceReadyID = (object) 3;
                break;
              case 2:
                this.EngVisitCharge.SetChargeTypeID = (object) 3;
                this.EngVisitCharge.SetCharge = (object) 0;
                this.EngVisitCharge.SetInvoiceReadyID = (object) 3;
                break;
              case 3:
                this.EngVisitCharge.SetChargeTypeID = (object) 5;
                this.EngVisitCharge.SetCharge = (object) 0;
                this.EngVisitCharge.SetInvoiceReadyID = (object) 3;
                break;
              case 4:
                this.EngVisitCharge.SetChargeTypeID = (object) 4;
                this.EngVisitCharge.SetCharge = (object) 0;
                this.EngVisitCharge.SetInvoiceReadyID = (object) 3;
                break;
            }
          }
          this.EngVisitCharge.SetPartsMarkUp = (object) Helper.MakeIntegerValid((object) this.txtPartsMarkUp.Text);
          this.EngVisitCharge.SetPartsPrice = (object) Helper.MakeDoubleValid((object) this.txtPartsProductTotal.Text);
          this.EngVisitCharge.SetLabourPrice = (object) Helper.MakeDoubleValid((object) this.txtTimesheetTotal.Text);
          this.EngVisitCharge.SetHasChargesFromJob = (object) this.chkShowJobCharges.Checked;
          if (this.EngVisitCharge.Exists)
          {
            App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(this.EngVisitCharge, this.Job);
          }
          else
          {
            this.EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Insert(this.EngVisitCharge);
            if (this.cbxReadyToBeInvoiced.Checked)
              App.DB.JobAudit.Insert(new JobAudit()
              {
                SetJobID = (object) App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID,
                SetActionChange = (object) ("Visit Status changed to Ready to be Invoiced (Unique Visit ID: " + Conversions.ToString(this.EngineerVisit.EngineerVisitID) + ")")
              });
          }
          if (this.InvoiceToBeRaised == null & initialLoad)
            this.AutoInvoice();
        }
      }
    }

    private void AutoInvoice()
    {
      DataView all = App.DB.Ibc.GetAll();
      if (all.Table.Rows.Count == 0)
        return;
      EnumerableRowCollection<DataRow> source1 = all.Table.AsEnumerable();
      Func<DataRow, int> selector1;
      // ISSUE: reference to a compiler-generated field
      if (FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector1 = FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D0;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D0 = selector1 = (Func<DataRow, int>) (x => x.Field<int>("SupplierId"));
      }
      DataRow[] dataRowArray = this.EngineerVisit.PartsAndProductsAllocated.Table.Select("PartProductID IN (" + string.Join<int>(",", (IEnumerable<int>) new List<int>()
      {
        674025,
        607573
      }.ToArray()) + ") AND SupplierID IN (" + string.Join<int>(",", (IEnumerable<int>) source1.Select<DataRow, int>(selector1).Distinct<int>().ToList<int>().ToArray()) + ")");
      if (dataRowArray.Length == 1 & this.EngineerVisit.OutcomeEnumID == 1)
      {
        double Charge = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["SellPrice"]));
        int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["SupplierID"]));
        if (Charge <= 0.0 || App.ShowMessage("Auto Invoice Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        Cursor.Current = Cursors.WaitCursor;
        this.UnCheckAllCharges();
        EnumerableRowCollection<DataRow> source2 = all.Table.AsEnumerable().Where<DataRow>((Func<DataRow, bool>) (x => x.Field<int>("SupplierId") == num));
        Func<DataRow, DataRow> selector2;
        // ISSUE: reference to a compiler-generated field
        if (FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D2 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector2 = FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D2;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D2 = selector2 = (Func<DataRow, DataRow>) (x => x);
        }
        DataRow dataRow = source2.Select<DataRow, DataRow>(selector2).FirstOrDefault<DataRow>();
        int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["Department"]));
        int num2 = this.GetCostCentre();
        if (this.txtNotesFromEngineer.Text.Contains("IBC") & num2 < 0)
        {
          List<string> list = ((IEnumerable<string>) this.txtNotesFromEngineer.Text.Split(' ')).ToList<string>();
          Func<string, bool> predicate;
          // ISSUE: reference to a compiler-generated field
          if (FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            predicate = FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D3;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D3 = predicate = (Func<string, bool>) (x => x.Contains("IBC"));
          }
          int number = Helper.GetNumber((object) list.Where<string>(predicate).FirstOrDefault<string>());
          EnumerableRowCollection<DataRow> source3 = App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table.AsEnumerable().Where<DataRow>((Func<DataRow, bool>) (x => Conversions.ToDouble(x.Field<string>("Name")) == (double) number));
          Func<DataRow, DataRow> selector3;
          // ISSUE: reference to a compiler-generated field
          if (FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D5 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector3 = FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D5;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMEngineerVisit._Closure\u0024__.\u0024I1545\u002D5 = selector3 = (Func<DataRow, DataRow>) (x => x);
          }
          if (source3.Select<DataRow, DataRow>(selector3).Count<DataRow>() > 0)
            num2 = number;
        }
        if (num2 == -1)
        {
          int num3 = (int) App.ShowMessage("Could not determine cost centre!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          string str = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Nominal"]));
          App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Insert(this.EngineerVisit.EngineerVisitID, "IBC" + Conversions.ToString(num2) + " - " + Charge.ToString("C"), Charge);
          this.EngVisitCharge.SetChargeTypeID = (object) 1;
          this.EngVisitCharge.SetInvoiceReadyID = (object) 2;
          this.EngVisitCharge.SetDepartment = (object) num1;
          this.EngVisitCharge.SetCharge = (object) Charge;
          this.EngVisitCharge.SetJobValue = (object) Charge;
          this.EngVisitCharge.SetForSageAccountCode = (object) ("IBC" + Conversions.ToString(num2));
          this.EngVisitCharge.SetPartsPrice = (object) 0;
          this.EngVisitCharge.SetLabourPrice = (object) 0;
          if (!string.IsNullOrWhiteSpace(str))
            this.EngVisitCharge.SetNominalCode = (object) str;
          App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(this.EngVisitCharge, this.Job);
          InvoiceAddress oInvoiceAddress = new InvoiceAddress();
          InvoiceAddress invoiceAddress = oInvoiceAddress;
          invoiceAddress.SetAddress1 = (object) ("DEPT " + Combo.get_GetSelectedItemValue(this.cboDept));
          invoiceAddress.SetAddress2 = (object) App.TheSystem.Configuration.CompanyName;
          invoiceAddress.SetAddress3 = (object) App.TheSystem.Configuration.CompanyAddres1;
          invoiceAddress.SetAddress4 = (object) App.TheSystem.Configuration.CompanyAddres3;
          invoiceAddress.SetAddress5 = (object) string.Empty;
          invoiceAddress.SetPostcode = (object) App.TheSystem.Configuration.CompanyPostcode;
          invoiceAddress.SetSiteID = (object) this.Job.PropertyID;
          int num4 = App.DB.InvoiceAddress.Insert(oInvoiceAddress)?.InvoiceAddressID.Value;
          int num5 = 258;
          DateTime dateTime = this.EngineerVisit.StartDateTime;
          if (DateTime.Compare(dateTime, DateTime.MinValue) == 0 || DateTime.Compare(DateHelper.GetFirstDayOfMonth(dateTime), DateHelper.GetFirstDayOfMonth(DateAndTime.Now)) < 0)
          {
            FRMContractUpgradeDowngrade upgradeDowngrade = new FRMContractUpgradeDowngrade();
            upgradeDowngrade.Text = "Select Date";
            upgradeDowngrade.lblText.Text = "Please select invoice date";
            int num6 = (int) upgradeDowngrade.ShowDialog();
            if (upgradeDowngrade.DialogResult == DialogResult.OK)
              dateTime = upgradeDowngrade.EffDate;
          }
          this.InvoiceToBeRaised = new InvoiceToBeRaised();
          InvoiceToBeRaised invoiceToBeRaised = this.InvoiceToBeRaised;
          invoiceToBeRaised.SetAddressLinkID = (object) num4;
          invoiceToBeRaised.SetAddressTypeID = (object) num5;
          invoiceToBeRaised.RaiseDate = DateTime.Compare(dateTime, DateTime.MinValue) == 0 ? DateAndTime.Now : dateTime;
          invoiceToBeRaised.SetInvoiceTypeID = (object) 260;
          invoiceToBeRaised.SetLinkID = (object) this.EngVisitCharge.EngineerVisitChargeID;
          invoiceToBeRaised.SetCustomerID = (object) this.theSite.CustomerID;
          invoiceToBeRaised.SetTaxRateID = (object) 7;
          invoiceToBeRaised.SetPaymentTermID = (object) 69482;
          this.InvoiceToBeRaised = App.DB.InvoiceToBeRaised.Insert(this.InvoiceToBeRaised);
          this.DisplayInvoiceAddress(this.InvoiceToBeRaised.AddressLinkID, this.InvoiceToBeRaised.AddressTypeID);
          Invoiced oInvoiced = new Invoiced();
          JobNumber jobNumber = new JobNumber();
          JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(FSM.Entity.Sys.Enums.JobDefinition.Quoted | FSM.Entity.Sys.Enums.JobDefinition.Misc);
          Invoiced invoiced1 = oInvoiced;
          invoiced1.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
          invoiced1.SetRaisedByUserID = (object) App.loggedInUser.UserID;
          invoiced1.RaisedDate = this.InvoiceToBeRaised.RaiseDate;
          invoiced1.SetVATRateID = (object) this.InvoiceToBeRaised.TaxRateID;
          invoiced1.SetPaymentTermID = (object) this.InvoiceToBeRaised.PaymentTermID;
          invoiced1.SetPaidByID = (object) this.InvoiceToBeRaised.PaidByID;
          Invoiced invoiced2 = App.DB.Invoiced.Insert(oInvoiced);
          InvoicedLines oInvoicedLines = new InvoicedLines();
          InvoicedLines invoicedLines = oInvoicedLines;
          invoicedLines.SetAmount = (object) this.EngVisitCharge.Charge;
          invoicedLines.SetInvoicedID = (object) invoiced2.InvoicedID;
          invoicedLines.SetInvoiceToBeRaisedID = (object) this.InvoiceToBeRaised.InvoiceToBeRaisedID;
          App.DB.InvoicedLines.Insert(oInvoicedLines);
          if (App.ShowMessage("Do you want to view the invoice document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            Printing printing = new Printing((object) new ArrayList()
            {
              (object) new ArrayList()
              {
                (object) new ArrayList()
                {
                  (object) invoiced2.InvoicedID,
                  (object) this.theSite.RegionID
                }
              }
            }, "Invoice", FSM.Entity.Sys.Enums.SystemDocumentType.Invoice, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
          }
          this.PopulateCharges(false);
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void SetInvoiceControls()
    {
      this.lblPriceInvVAT.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.txtPriceIncVAT.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblRaiseInvoiceOn.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.dtpRaiseInvoiceOn.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblInvoiceAddressDetails.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblAccountCode.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.txtAccountCode.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.btnSearch.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblVAT.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.cboVATRate.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblInvType.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.cboInvType.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblInvNo.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.txtInvNo.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblInvAmount.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.txtInvAmount.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.lblcredit.Visible = this.cbxReadyToBeInvoiced.Checked;
      this.txtCreditAmount.Visible = this.cbxReadyToBeInvoiced.Checked;
      if (this.EngVisitCharge.InvoiceReadyID == 2)
        this.btnInvoice.Visible = true;
      else
        this.btnInvoice.Visible = false;
    }

    private void LoadReadyToBeInvoicedDetails()
    {
      this.Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID);
      if (!this.Loading)
      {
        this.dtpRaiseInvoiceOn.Value = DateAndTime.Now;
        if ((uint) DateTime.Compare(this.EngineerVisit.StartDateTime, DateTime.MinValue) > 0U)
          this.dtpRaiseInvoiceOn.Value = this.EngineerVisit.StartDateTime;
        if (this.cbxReadyToBeInvoiced.Checked)
          this.SaveInvoiceToBeRaisedDetails();
        else if (this.InvoiceToBeRaised != null)
          this.DeleteInvoiceToBeRaiseDetails();
      }
      this.SetInvoiceControls();
    }

    private void SaveInvoiceToBeRaisedDetails()
    {
      if (!this.Loading)
      {
        if (this.InvoiceToBeRaised == null)
        {
          FRMSelectInvoiceAddress selectInvoiceAddress = new FRMSelectInvoiceAddress(this.theSite.SiteID);
          if (selectInvoiceAddress.ShowDialog() != DialogResult.OK)
          {
            selectInvoiceAddress.Dispose();
            this.cbxReadyToBeInvoiced.Checked = false;
            int num = (int) App.ShowMessage("An invoice address must be selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
          }
          this.InvoiceToBeRaised = new InvoiceToBeRaised();
          this.InvoiceToBeRaised.SetAddressLinkID = (object) selectInvoiceAddress.AddressLinkID;
          this.InvoiceToBeRaised.SetAddressTypeID = (object) selectInvoiceAddress.AddressTypeID;
          selectInvoiceAddress.Dispose();
        }
        this.InvoiceToBeRaised.RaiseDate = this.dtpRaiseInvoiceOn.Value;
        this.InvoiceToBeRaised.SetInvoiceTypeID = (object) 260;
        this.InvoiceToBeRaised.SetLinkID = (object) this.EngVisitCharge.EngineerVisitChargeID;
        this.InvoiceToBeRaised.SetCustomerID = (object) App.DB.Customer.Customer_Get_ForSiteID(this.theSite.SiteID).CustomerID;
        this.InvoiceToBeRaised.SetTaxRateID = (object) Combo.get_GetSelectedItemValue(this.cboVATRate);
        this.InvoiceToBeRaised.SetPaymentTermID = (object) Combo.get_GetSelectedItemValue(this.cboInvType);
        this.InvoiceToBeRaised.SetPaidByID = (object) Combo.get_GetSelectedItemValue(this.cboPaidBy);
        if (!this.InvoiceToBeRaised.Exists)
          this.InvoiceToBeRaised = App.DB.InvoiceToBeRaised.Insert(this.InvoiceToBeRaised);
        else
          App.DB.InvoiceToBeRaised.Update(this.InvoiceToBeRaised);
        this.DisplayInvoiceAddress(this.InvoiceToBeRaised.AddressLinkID, this.InvoiceToBeRaised.AddressTypeID);
      }
    }

    private void DeleteInvoiceToBeRaiseDetails()
    {
      App.DB.InvoiceToBeRaised.Delete(this.InvoiceToBeRaised.InvoiceToBeRaisedID);
      this.InvoiceToBeRaised = (InvoiceToBeRaised) null;
    }

    private double GetPartProductCost(DataRow dr)
    {
      string index = "ID";
      string str = Conversions.ToString(dr["Type"]);
      DataRow[] dataRowArray1 = this.EngineerVisit.PartsAndProductsAllocated.Table.Select("Type='" + str + "' AND  ID=" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["AllocatedID"]))));
      if (dataRowArray1.Length <= 0 || Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["OrderID"])) <= 0)
        return this.GetSupplierBuyPrice(dr);
      DataView all = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(dataRowArray1[0]["OrderID"]));
      if (Conversions.ToInteger(dataRowArray1[0]["OrderLocationTypeID"]) != 1)
        return this.GetSupplierBuyPrice(dr);
      DataRow[] dataRowArray2 = all.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Type='Order" + str + "' AND PartProductID="), dr[index])));
      return dataRowArray2.Length > 0 ? Helper.MakeDoubleValid(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(dataRowArray2[0]["BuyPrice"], dr["Quantity"])) : this.GetSupplierBuyPrice(dr);
    }

    private double GetSupplierBuyPrice(DataRow dr)
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"])).ToLower(), "part", false) == 0)
      {
        DataTable table = App.DB.PartSupplier.Get_ByPartID(Conversions.ToInteger(dr["ID"])).Table;
        DataRow[] dataRowArray = table.Select("Preferred=1");
        if (dataRowArray.Length > 0)
          return Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(dataRowArray[0]["Price"], (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["Quantity"]))));
        double num = 0.0;
        if (table.Rows.Count > 0)
        {
          num = Conversions.ToDouble(table.Rows[0]["Price"]);
          IEnumerator enumerator;
          try
          {
            enumerator = table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(current["Price"], (object) num, false))
                num = Conversions.ToDouble(current["Price"]);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        return num * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["Quantity"]));
      }
      DataTable table1 = App.DB.ProductSupplier.Get_ByProductID(Conversions.ToInteger(dr["ID"])).Table;
      return table1.Rows.Count > 0 ? Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["Price"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["Quantity"])) : 0.0;
    }

    private void DisplayInvoiceAddress(int AddressLinkID, int AddressTypeID)
    {
      string str = "";
      switch (AddressTypeID)
      {
        case 253:
        case 254:
          FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) AddressLinkID, SiteSQL.GetBy.SiteId, (object) null);
          if (site.Name.Trim().Length > 0)
            str = str + site.Name + "\r\n";
          if (site.Address1.Trim().Length > 0)
            str = str + site.Address1 + "\r\n";
          if (site.Address2.Trim().Length > 0)
            str = str + site.Address2 + "\r\n";
          if (site.Address3.Trim().Length > 0)
            str = str + site.Address3 + "\r\n";
          if (site.Address4.Trim().Length > 0)
            str = str + site.Address4 + "\r\n";
          if (site.Address5.Trim().Length > 0)
            str = str + site.Address5 + "\r\n";
          if (site.Postcode.Trim().Length > 0)
            str = str + site.Postcode + "\r\n";
          this.lblInvoiceAddressDetails.Text = str;
          break;
        case 258:
          InvoiceAddress invoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(AddressLinkID);
          if (invoiceAddress.Address1.Trim().Length > 0)
            str = str + invoiceAddress.Address1 + "\r\n";
          if (invoiceAddress.Address2.Trim().Length > 0)
            str = str + invoiceAddress.Address2 + "\r\n";
          if (invoiceAddress.Address3.Trim().Length > 0)
            str = str + invoiceAddress.Address3 + "\r\n";
          if (invoiceAddress.Address4.Trim().Length > 0)
            str = str + invoiceAddress.Address4 + "\r\n";
          if (invoiceAddress.Address5.Trim().Length > 0)
            str = str + invoiceAddress.Address5 + "\r\n";
          if (invoiceAddress.Postcode.Trim().Length > 0)
            str = str + invoiceAddress.Postcode + "\r\n";
          break;
        default:
          str += "Not selected";
          break;
      }
      this.lblInvoiceAddressDetails.Text = str;
    }

    public int GetCostCentre()
    {
      List<CostCentre> source = App.DB.CostCentre.Get(this.Job?.JobTypeID.Value, this.theSite.CustomerID, FSM.Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId);
      CostCentre costCentre = source != null ? source.FirstOrDefault<CostCentre>() : (CostCentre) null;
      return costCentre != null ? costCentre.Name : -1;
    }

    private void ShutdownNonChargableVisits(FormClosingEventArgs e)
    {
      DataView allJobId = App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(this.Job?.JobID.Value);
      if (allJobId.Count == 0)
        return;
      DataRow[] dataRowArray1 = allJobId.Table.Select("StatusEnumID = " + Conversions.ToString(7));
      if (dataRowArray1.Length == 0)
        return;
      switch (App.ShowMessage("This current visit has job releated charges.\r\n\r\nThere are open relating visits, do you want to cost them off as non-chargeable?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case DialogResult.Cancel:
          e.Cancel = true;
          break;
        case DialogResult.Yes:
          DataRow[] dataRowArray2 = dataRowArray1;
          int index = 0;
          while (index < dataRowArray2.Length)
          {
            int EngineerVisitID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRowArray2[index]["EngineerVisitID"]));
            EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID, true);
            if (asObject != null)
            {
              asObject.SetVisitLocked = true;
              asObject.SetStatusEnumID = (object) 8;
              App.DB.EngineerVisits.Update(asObject, 0, true);
              EngineerVisitCharge oEngineerVisitCharge = new EngineerVisitCharge();
              EngineerVisitCharge engineerVisitCharge = oEngineerVisitCharge;
              engineerVisitCharge.SetEngineerVisitID = (object) asObject.EngineerVisitID;
              engineerVisitCharge.SetNominalCode = (object) this.txtNominalCode.Text.Trim();
              engineerVisitCharge.SetDepartment = (object) Combo.get_GetSelectedItemValue(this.cboDept).Trim();
              engineerVisitCharge.SetForSageAccountCode = (object) this.txtAccountCode.Text.Trim();
              engineerVisitCharge.SetInvoiceReadyID = (object) 3;
              engineerVisitCharge.SetPartsMarkUp = (object) Helper.MakeIntegerValid((object) this.txtPartsMarkUp.Text);
              engineerVisitCharge.SetMainContractorDiscount = (object) 0;
              engineerVisitCharge.SetJobValue = (object) 0;
              engineerVisitCharge.SetTaxRateID = (object) 0;
              engineerVisitCharge.SetCharge = (object) 0;
              engineerVisitCharge.SetPartsPrice = (object) 0;
              engineerVisitCharge.SetLabourPrice = (object) 0;
              engineerVisitCharge.SetHasChargesFromJob = (object) false;
              App.DB.EngineerVisitCharge.EngineerVisitCharge_Insert(oEngineerVisitCharge);
            }
            checked { ++index; }
          }
          break;
      }
    }

    public void SetupAllocatedDG()
    {
      Helper.SetUpDataGrid(this.dgPartsProductsAllocated, false);
      DataGridTableStyle tableStyle = this.dgPartsProductsAllocated.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      FRMEngineerVisit.AllocatedStatusColourColumn statusColourColumn = new FRMEngineerVisit.AllocatedStatusColourColumn();
      statusColourColumn.Format = "";
      statusColourColumn.FormatInfo = (IFormatProvider) null;
      statusColourColumn.HeaderText = "";
      statusColourColumn.MappingName = "Status";
      statusColourColumn.ReadOnly = true;
      statusColourColumn.Width = 15;
      statusColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) statusColourColumn);
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 60;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Number";
      dataGridLabelColumn2.MappingName = "number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 80;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Name";
      dataGridLabelColumn3.MappingName = "Name";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 300;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Qty Allocated";
      dataGridLabelColumn4.MappingName = "Quantity";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 50;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Quantity Unallocated";
      dataGridLabelColumn5.MappingName = "QtyRemaining";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 60;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Order Ref.";
      dataGridLabelColumn6.MappingName = "OrderReference";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Order Status";
      dataGridLabelColumn7.MappingName = "OrderStatus";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Order Qty Received";
      dataGridLabelColumn8.MappingName = "QuantityReceived";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Qty Credit";
      dataGridLabelColumn9.MappingName = "CreditQty";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 75;
      dataGridLabelColumn9.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "C";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Buy Price";
      dataGridLabelColumn10.MappingName = "SellPrice";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 75;
      dataGridLabelColumn10.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsAllocated.ToString();
      this.dgPartsProductsAllocated.TableStyles.Add(tableStyle);
    }

    public DataView PartsAndProductsAllocated
    {
      get
      {
        return this._PartsAndProductsAllocated;
      }
      set
      {
        this.PartsAndProductsDistribution = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit(this.EngineerVisit.EngineerVisitID);
        this.PartsAndProductsDistribution.Table.Constraints.Clear();
        value.Table.AcceptChanges();
        value.Table.Columns.Add(new DataColumn("Status", System.Type.GetType("System.Boolean")));
        value.Table.Columns.Add(new DataColumn("Tick", typeof (bool)));
        IEnumerator enumerator1;
        try
        {
          enumerator1 = value.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            current["Tick"] = (object) false;
            int num1 = 0;
            bool flag = false;
            DataRow[] dataRowArray = this.PartsAndProductsDistribution.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Type = '", current["Type"]), (object) "'")));
            int index = 0;
            while (index < dataRowArray.Length)
            {
              DataRow dataRow = dataRowArray[index];
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["AllocatedID"], current["ID"], false))
                num1 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num1, dataRow["Quantity"]));
              checked { ++index; }
            }
            IEnumerator enumerator2;
            try
            {
              enumerator2 = value.Table.Columns.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(((DataColumn) enumerator2.Current).ColumnName, "CreditQty", false) == 0)
                {
                  flag = true;
                  break;
                }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            int num2 = flag ? (current["CreditQty"] != DBNull.Value ? Conversions.ToInteger(current["CreditQty"]) : 0) : 0;
            current["Status"] = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["OrderItemID"], (object) 0, false) ? (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual((object) checked (num1 + num2), current["QtyRemaining"], false) ? (object) false : (object) true) : (object) true;
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        value.Table.PrimaryKey = new DataColumn[1]
        {
          value.Table.Columns["ID"]
        };
        this._PartsAndProductsAllocated = value;
        this._PartsAndProductsAllocated.Table.TableName = FSM.Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsAllocated.ToString();
        this._PartsAndProductsAllocated.AllowNew = false;
        this._PartsAndProductsAllocated.AllowEdit = false;
        this._PartsAndProductsAllocated.AllowDelete = false;
        this.dgPartsProductsAllocated.DataSource = (object) this.PartsAndProductsAllocated;
        this.SetupAllocatedDG();
      }
    }

    private DataRow SelectedPartProductAllocatedDataRow
    {
      get
      {
        return this.dgPartsProductsAllocated.CurrentRowIndex != -1 ? this.PartsAndProductsAllocated[this.dgPartsProductsAllocated.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataRow SelectedPartProductUsedDataRow
    {
      get
      {
        return this.dgPartsAndProductsUsed.CurrentRowIndex != -1 ? this.PartsAndProductsUsed[this.dgPartsAndProductsUsed.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView PartsAndProductsUsed
    {
      get
      {
        return this._PartsAndProductsUsed;
      }
      set
      {
        this._PartsAndProductsUsed = value;
      }
    }

    public DataView PartsAndProductsDistribution
    {
      get
      {
        return this._PartsAndProductsDistribution;
      }
      set
      {
        this._PartsAndProductsDistribution = value;
      }
    }

    private void btnAllocatedNotUsed_Click(object sender, EventArgs e)
    {
      if (this.SelectedPartProductAllocatedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a part or product to mark as not used", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num2 = 0;
        DataRow[] dataRowArray = this.PartsAndProductsDistribution.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Type = '", this.SelectedPartProductAllocatedDataRow["Type"]), (object) "'")));
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow dataRow = dataRowArray[index];
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["AllocatedID"], this.SelectedPartProductAllocatedDataRow["ID"], false))
            num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRow["Quantity"]));
          checked { ++index; }
        }
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual((object) num2, this.SelectedPartProductAllocatedDataRow["Quantity"], false))
        {
          int num3 = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distribution is complete for this ", this.SelectedPartProductAllocatedDataRow["Type"])), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) "Are you sure the remaining", Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) " ", Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedPartProductAllocatedDataRow["Quantity"], (object) num2)), (object) ", "), this.SelectedPartProductAllocatedDataRow["Name"]), (object) "'s have not been used? This action cannot be reversed once the job details have been saved"))), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["OrderID"])) == 0)
          {
            this.PartsAndProductsDistribution.Table.AcceptChanges();
            DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
            row["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["Type"]);
            row["DistributedID"] = (object) 0;
            row["LocationID"] = (object) 0;
            row["AllocatedID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["ID"]);
            row["Other"] = (object) false;
            row["Quantity"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedPartProductAllocatedDataRow["Quantity"], (object) num2);
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["PartProductID"]);
            row["OrderPartProductID"] = (object) 0;
            row["StockTransactionType"] = (object) 2;
            this.PartsAndProductsDistribution.Table.Rows.Add(row);
            this.SelectedPartProductAllocatedDataRow["Status"] = (object) true;
          }
          else
          {
            int num4 = 0;
            bool flag = false;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPartProductAllocatedDataRow["OrderStatusID"], (object) 2, false) && App.ShowMessage("This order is still confirmed! Would you like to make it as complete now?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
              this.CompleteOrder(Conversions.ToInteger(this.SelectedPartProductAllocatedDataRow["OrderItemID"]));
              flag = true;
            }
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedPartProductAllocatedDataRow["OrderLocationTypeID"], (object) 1, false), Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(this.SelectedPartProductAllocatedDataRow["OrderStatusID"], (object) 4, false), (object) flag))))
            {
              FRMAddPartToBeCredited partToBeCredited = new FRMAddPartToBeCredited(Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedPartProductAllocatedDataRow["Quantity"], (object) num2)));
              if (partToBeCredited.ShowDialog() == DialogResult.OK)
                num4 = Helper.MakeIntegerValid((object) partToBeCredited.txtQtyToReturn.Text);
              if (num4 > 0)
              {
                DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
                row["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["Type"]);
                row["DistributedID"] = (object) 0;
                row["LocationID"] = (object) 0;
                row["AllocatedID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["ID"]);
                row["Other"] = (object) false;
                row["Quantity"] = (object) num4;
                row["PartProductID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["PartProductID"]);
                row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["OrderItemID"]);
                row["StockTransactionType"] = (object) -1;
                this.PartsAndProductsDistribution.Table.Rows.Add(row);
                checked { num2 += num4; }
                this.SelectedPartProductAllocatedDataRow["Status"] = (object) true;
              }
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedPartProductAllocatedDataRow["Quantity"], (object) num2), (object) 0, false))
            {
              FRMDistributeAllocated distributeAllocated = new FRMDistributeAllocated(false, Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedPartProductAllocatedDataRow["Quantity"], (object) num2)), Conversions.ToString(this.SelectedPartProductAllocatedDataRow["Name"]), Conversions.ToString(this.SelectedPartProductAllocatedDataRow["Type"]), Conversions.ToInteger(this.SelectedPartProductAllocatedDataRow["PartProductID"]), (ArrayList) null);
              if (distributeAllocated.ShowDialog() == DialogResult.OK)
              {
                this.PartsAndProductsDistribution.Table.AcceptChanges();
                IEnumerator enumerator;
                try
                {
                  enumerator = distributeAllocated.Locations.Table.Rows.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Quantity"], (object) 0, false))
                    {
                      DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
                      row["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["Type"]);
                      row["DistributedID"] = (object) 0;
                      row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
                      row["AllocatedID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["ID"]);
                      row["Other"] = (object) false;
                      row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
                      row["PartProductID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["PartProductID"]);
                      row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["OrderItemID"]);
                      row["StockTransactionType"] = (object) 2;
                      this.PartsAndProductsDistribution.Table.Rows.Add(row);
                    }
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
                this.SelectedPartProductAllocatedDataRow["Status"] = (object) true;
              }
            }
          }
        }
      }
    }

    private void CompleteOrder(int OrderPartID)
    {
      OrderPart orderPart1 = App.DB.OrderPart.OrderPart_Get(OrderPartID);
      if (orderPart1 == null)
        return;
      Order oOrder = App.DB.Order.Order_Get(orderPart1.OrderID);
      if (oOrder.OrderStatusID != 2)
      {
        int num1 = (int) App.ShowMessage("Order must be confirmed to Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DataView all = App.DB.Order.Order_ItemsGetAll(orderPart1.OrderID);
        IEnumerator enumerator;
        try
        {
          enumerator = all.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToInteger(current["QuantityOnOrder"]) != Conversions.ToInteger(current["QuantityReceived"]))
            {
              int num2 = checked (Conversions.ToInteger(current["QuantityOnOrder"]) - Conversions.ToInteger(current["QuantityReceived"]));
              string Left = Conversions.ToString(current["Type"]);
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderProduct", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderPart", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationProduct", false) != 0)
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationPart", false) == 0)
                    {
                      FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(current["ID"]));
                      PartTransaction orderLocationPart = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(oOrderLocationPart.OrderLocationPartID);
                      orderLocationPart.SetAmount = (object) checked (orderLocationPart.Amount + num2);
                      App.DB.PartTransaction.Update(orderLocationPart);
                      orderLocationPart.SetLocationID = (object) oOrderLocationPart.LocationID;
                      orderLocationPart.SetPartID = (object) oOrderLocationPart.PartID;
                      orderLocationPart.SetOrderLocationPartID = (object) oOrderLocationPart.OrderLocationPartID;
                      orderLocationPart.SetTransactionTypeID = (object) 3;
                      orderLocationPart.SetAmount = (object) checked (-num2);
                      App.DB.PartTransaction.Insert(orderLocationPart);
                      oOrderLocationPart.SetQuantityReceived = (object) checked (oOrderLocationPart.QuantityReceived + num2);
                      App.DB.OrderLocationPart.Update(oOrderLocationPart);
                      switch (oOrder.OrderTypeID)
                      {
                        case 3:
                          OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderLocationPart.OrderID);
                          orderLocationPart.SetLocationID = (object) forOrder.LocationID;
                          orderLocationPart.SetTransactionTypeID = (object) 2;
                          orderLocationPart.SetOrderLocationPartID = (object) oOrderLocationPart.OrderLocationPartID;
                          orderLocationPart.SetAmount = (object) num2;
                          orderLocationPart.SetPartID = (object) oOrderLocationPart.PartID;
                          App.DB.PartTransaction.Insert(orderLocationPart);
                          break;
                      }
                    }
                  }
                  else
                  {
                    FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(current["ID"]));
                    ProductTransaction orderLocationProduct = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(oOrderLocationProduct.OrderLocationProductID);
                    orderLocationProduct.SetAmount = (object) checked (orderLocationProduct.Amount + num2);
                    App.DB.ProductTransaction.Update(orderLocationProduct);
                    orderLocationProduct.SetLocationID = (object) oOrderLocationProduct.LocationID;
                    orderLocationProduct.SetProductID = (object) oOrderLocationProduct.ProductID;
                    orderLocationProduct.SetOrderLocationProductID = (object) oOrderLocationProduct.OrderLocationProductID;
                    orderLocationProduct.SetTransactionTypeID = (object) 3;
                    orderLocationProduct.SetAmount = (object) checked (-num2);
                    App.DB.ProductTransaction.Insert(orderLocationProduct);
                    oOrderLocationProduct.SetQuantityReceived = (object) checked (oOrderLocationProduct.QuantityReceived + num2);
                    App.DB.OrderLocationProduct.Update(oOrderLocationProduct);
                    switch (oOrder.OrderTypeID)
                    {
                      case 3:
                        OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderLocationProduct.OrderID);
                        orderLocationProduct.SetLocationID = (object) forOrder.LocationID;
                        orderLocationProduct.SetTransactionTypeID = (object) 2;
                        orderLocationProduct.SetOrderLocationProductID = (object) oOrderLocationProduct.OrderLocationProductID;
                        orderLocationProduct.SetAmount = (object) num2;
                        orderLocationProduct.SetProductID = (object) oOrderLocationProduct.ProductID;
                        App.DB.ProductTransaction.Insert(orderLocationProduct);
                        break;
                    }
                  }
                }
                else
                {
                  OrderPart orderPart2 = new OrderPart();
                  OrderPart oOrderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(current["ID"]));
                  oOrderPart.SetQuantityReceived = (object) checked (oOrderPart.QuantityReceived + num2);
                  App.DB.OrderPart.Update(oOrderPart);
                  switch (oOrder.OrderTypeID)
                  {
                    case 3:
                      OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderPart.OrderID);
                      PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(oOrderPart.PartSupplierID);
                      App.DB.PartTransaction.Insert(new PartTransaction()
                      {
                        SetLocationID = (object) forOrder.LocationID,
                        SetPartID = (object) partSupplier.PartID,
                        SetOrderPartID = (object) oOrderPart.OrderPartID,
                        SetAmount = (object) ((double) num2 * partSupplier.QuantityInPack),
                        SetTransactionTypeID = (object) 2
                      });
                      break;
                  }
                }
              }
              else
              {
                OrderProduct orderProduct = new OrderProduct();
                Product product = new Product();
                OrderProduct oOrderProduct = App.DB.OrderProduct.OrderProduct_Get(Conversions.ToInteger(current["ID"]));
                ProductSupplier productSupplier = App.DB.ProductSupplier.ProductSupplier_Get(oOrderProduct.ProductSupplierID);
                product = App.DB.Product.Product_Get(productSupplier.ProductID);
                oOrderProduct.SetQuantityReceived = (object) checked (oOrderProduct.QuantityReceived + num2);
                App.DB.OrderProduct.Update(oOrderProduct);
                switch (oOrder.OrderTypeID)
                {
                  case 3:
                    OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderProduct.OrderID);
                    App.DB.ProductTransaction.Insert(new ProductTransaction()
                    {
                      SetLocationID = (object) forOrder.LocationID,
                      SetProductID = (object) productSupplier.ProductID,
                      SetOrderProductID = (object) oOrderProduct.OrderProductID,
                      SetAmount = (object) ((double) num2 * productSupplier.QuantityInPack),
                      SetTransactionTypeID = (object) 2
                    });
                    break;
                }
              }
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        oOrder.SetOrderStatusID = (object) 4;
        App.DB.Order.Update(oOrder);
      }
    }

    private bool DeclareWhereGotFrom(int Quantity, string NameIn, string TypeIn, int IDIn)
    {
      FRMDistributeAllocated distributeAllocated = new FRMDistributeAllocated(true, Quantity, NameIn, TypeIn, IDIn, this.BuildAllocatedArray(IDIn, TypeIn));
      if (distributeAllocated.ShowDialog() != DialogResult.OK)
        return false;
      this.PartsAndProductsDistribution.Table.AcceptChanges();
      IEnumerator enumerator1;
      try
      {
        enumerator1 = distributeAllocated.Locations.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current[nameof (Quantity)], (object) 0, false))
          {
            DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
            row["Type"] = (object) TypeIn;
            row["DistributedID"] = (object) 0;
            row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
            row["AllocatedID"] = RuntimeHelpers.GetObjectValue(current["AllocatedID"]);
            row["Other"] = !Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["LocationID"], (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AllocatedID"], (object) 0, false))) ? (object) false : (object) true;
            row[nameof (Quantity)] = RuntimeHelpers.GetObjectValue(current[nameof (Quantity)]);
            row["PartProductID"] = (object) IDIn;
            row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(current["OrderPartProductID"]);
            row["StockTransactionType"] = RuntimeHelpers.GetObjectValue(current["StockTransactionType"]);
            this.PartsAndProductsDistribution.Table.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          int num = 0;
          DataRow[] dataRowArray = this.PartsAndProductsDistribution.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Type = '", current["Type"]), (object) "'")));
          int index = 0;
          while (index < dataRowArray.Length)
          {
            DataRow dataRow = dataRowArray[index];
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["AllocatedID"], current["ID"], false))
              num = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num, dataRow[nameof (Quantity)]));
            checked { ++index; }
          }
          current["Status"] = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual((object) num, current[nameof (Quantity)], false) ? (object) false : (object) true;
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      return true;
    }

    private ArrayList BuildAllocatedArray(int PartProductIDIn, string TypeIn)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["Status"], (object) false, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["PartProductID"], (object) PartProductIDIn, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["Type"], (object) TypeIn, false)), (object) ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderID"])) > 0U))))
          {
            int num = 0;
            DataRow[] dataRowArray = this.PartsAndProductsDistribution.Table.Select("Type = '" + TypeIn + "'");
            int index = 0;
            while (index < dataRowArray.Length)
            {
              DataRow dataRow = dataRowArray[index];
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["AllocatedID"], current["ID"], false))
                num = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num, dataRow["Quantity"]));
              checked { ++index; }
            }
            int integer = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["Quantity"], (object) num));
            if (integer >= 0)
              arrayList.Add((object) new ArrayList()
              {
                RuntimeHelpers.GetObjectValue(current["ID"]),
                (object) integer,
                RuntimeHelpers.GetObjectValue(current["OrderItemID"])
              });
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    private bool RemovePart(int Quantity, string PartProductName, string Type, int PartProductID)
    {
      bool flag1 = false;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Type, "Part", false) == 0 && App.DB.Part.Part_Get(PartProductID).Equipment)
        flag1 = true;
      bool flag2;
      if (!flag1)
      {
        int num1 = 0;
        int num2 = 0;
        if (this.dgPartsProductsAllocated.CurrentRowIndex != -1)
        {
          FRMAddPartToBeCredited partToBeCredited = new FRMAddPartToBeCredited(Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedPartProductAllocatedDataRow[nameof (Quantity)], (object) num2)));
          if (partToBeCredited.ShowDialog() == DialogResult.OK)
            num1 = Helper.MakeIntegerValid((object) partToBeCredited.txtQtyToReturn.Text);
          if (num1 > 0)
          {
            DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
            row[nameof (Type)] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow[nameof (Type)]);
            row["DistributedID"] = (object) 0;
            row["LocationID"] = (object) 0;
            row["AllocatedID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["ID"]);
            row["Other"] = (object) false;
            row[nameof (Quantity)] = (object) num1;
            row[nameof (PartProductID)] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow[nameof (PartProductID)]);
            row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductAllocatedDataRow["OrderItemID"]);
            row["StockTransactionType"] = (object) -1;
            this.PartsAndProductsDistribution.Table.Rows.Add(row);
            checked { num2 += num1; }
            this.SelectedPartProductAllocatedDataRow["Status"] = (object) true;
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedPartProductAllocatedDataRow[nameof (Quantity)], (object) num2), (object) 0, false))
          {
            FRMDistributeAllocated distributeAllocated = new FRMDistributeAllocated(false, Quantity, PartProductName, Type, PartProductID, (ArrayList) null);
            if (distributeAllocated.ShowDialog() == DialogResult.OK)
            {
              this.PartsAndProductsDistribution.Table.AcceptChanges();
              IEnumerator enumerator;
              try
              {
                enumerator = distributeAllocated.Locations.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current[nameof (Quantity)], (object) 0, false))
                  {
                    DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
                    row[nameof (Type)] = (object) Type;
                    row["DistributedID"] = (object) 0;
                    row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
                    row["AllocatedID"] = (object) 0;
                    row["Other"] = (object) false;
                    row[nameof (Quantity)] = RuntimeHelpers.GetObjectValue(current[nameof (Quantity)]);
                    row[nameof (PartProductID)] = (object) PartProductID;
                    row["OrderPartProductID"] = (object) 0;
                    row["StockTransactionType"] = (object) 2;
                    this.PartsAndProductsDistribution.Table.Rows.Add(row);
                  }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              flag2 = true;
            }
            else
              flag2 = false;
          }
          else
            flag2 = true;
        }
        else if (this.dgPartsAndProductsUsed.CurrentRowIndex != -1)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["OrderPartID"], (object) 0, false))
          {
            FRMAddPartToBeCredited partToBeCredited = new FRMAddPartToBeCredited(Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex][nameof (Quantity)], (object) num2)));
            if (partToBeCredited.ShowDialog() == DialogResult.OK)
              num1 = Helper.MakeIntegerValid((object) partToBeCredited.txtQtyToReturn.Text);
          }
          if (num1 > 0)
          {
            DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
            row[nameof (Type)] = RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex][nameof (Type)]);
            row["DistributedID"] = (object) 0;
            row["LocationID"] = (object) 0;
            row["AllocatedID"] = RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["AllocatedID"]);
            row["Other"] = (object) false;
            row[nameof (Quantity)] = (object) num1;
            row[nameof (PartProductID)] = RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["ID"]);
            row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex]["OrderItemID"]);
            row["StockTransactionType"] = (object) -1;
            this.PartsAndProductsDistribution.Table.Rows.Add(row);
            checked { num2 += num1; }
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex][nameof (Quantity)], (object) num2), (object) 0, false))
          {
            FRMDistributeAllocated distributeAllocated = new FRMDistributeAllocated(false, Quantity, PartProductName, Type, PartProductID, (ArrayList) null);
            if (distributeAllocated.ShowDialog() == DialogResult.OK)
            {
              this.PartsAndProductsDistribution.Table.AcceptChanges();
              IEnumerator enumerator;
              try
              {
                enumerator = distributeAllocated.Locations.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current[nameof (Quantity)], (object) 0, false))
                  {
                    DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
                    row[nameof (Type)] = (object) Type;
                    row["DistributedID"] = (object) 0;
                    row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
                    row["AllocatedID"] = (object) 0;
                    row["Other"] = (object) false;
                    row[nameof (Quantity)] = RuntimeHelpers.GetObjectValue(current[nameof (Quantity)]);
                    row[nameof (PartProductID)] = (object) PartProductID;
                    row["OrderPartProductID"] = (object) 0;
                    row["StockTransactionType"] = (object) 2;
                    this.PartsAndProductsDistribution.Table.Rows.Add(row);
                  }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              flag2 = true;
            }
            else
              flag2 = false;
          }
          else
            flag2 = true;
        }
      }
      else
        flag2 = true;
      return flag2;
    }

    private void btnAllUsed_Click(object sender, EventArgs e)
    {
      if (this.SelectedPartProductAllocatedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a part or product to mark as fully used", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        bool flag = false;
        int num2 = 0;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataRow) enumerator1.Current)["Tick"], (object) true, false))
            {
              checked { ++num2; }
              if (num2 > 1)
              {
                flag = true;
                break;
              }
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        IEnumerator enumerator2;
        IEnumerator enumerator3;
        if (flag)
        {
          try
          {
            enumerator2 = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["Tick"], (object) true, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["QtyRemaining"], (object) 0, false))))
                this.UsePart(current, Conversions.ToInteger(current["QtyRemaining"]));
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
        else
        {
          try
          {
            enumerator3 = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              DataRow current = (DataRow) enumerator3.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
                this.UsePart(current, Convert.ToInt32(this.nudPartAllocatedQty.Value));
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
        }
      }
    }

    public void UsePart(DataRow dr, int qty)
    {
      bool flag1 = false;
      int num1 = 0;
      int num2 = 0;
      DataRow[] dataRowArray1 = this.PartsAndProductsDistribution.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Type = '", dr["Type"]), (object) "'")));
      int index1 = 0;
      while (index1 < dataRowArray1.Length)
      {
        DataRow dataRow = dataRowArray1[index1];
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["AllocatedID"], dr["ID"], false))
          num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRow["Quantity"]));
        checked { ++index1; }
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual((object) num2, dr["Quantity"], false))
      {
        int num3 = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distribution is complete for this ", dr["Type"])), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["OrderID"])) == 0)
        {
          FRMDistributeAllocated distributeAllocated = new FRMDistributeAllocated(true, qty, Conversions.ToString(dr["Name"]), Conversions.ToString(dr["Type"]), Conversions.ToInteger(dr["PartProductID"]), this.BuildAllocatedArray(Conversions.ToInteger(dr["PartProductID"]), Conversions.ToString(dr["Type"])));
          if (distributeAllocated.ShowDialog() == DialogResult.OK)
          {
            this.PartsAndProductsDistribution.Table.AcceptChanges();
            IEnumerator enumerator;
            try
            {
              enumerator = distributeAllocated.Locations.Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["QtyRemaining"], (object) 0, false))
                {
                  DataRow[] dataRowArray2 = this.PartsAndProductsDistribution.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AllocatedID = ", dr["ID"])));
                  int index2 = 0;
                  while (index2 < dataRowArray2.Length)
                  {
                    DataRow dataRow1 = dataRowArray2[index2];
                    if (dataRow1 == null)
                    {
                      DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
                      row["Type"] = RuntimeHelpers.GetObjectValue(dr["Type"]);
                      row["DistributedID"] = (object) 0;
                      row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
                      row["AllocatedID"] = RuntimeHelpers.GetObjectValue(dr["ID"]);
                      row["Other"] = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["LocationID"], (object) 0, false) ? (object) false : (object) true;
                      row["Quantity"] = (object) qty;
                      row["PartProductID"] = RuntimeHelpers.GetObjectValue(dr["PartProductID"]);
                      row["OrderPartProductID"] = (object) 0;
                      row["StockTransactionType"] = (object) 3;
                      this.PartsAndProductsDistribution.Table.Rows.Add(row);
                      num1 = Conversions.ToInteger(current["LocationID"]);
                    }
                    else
                    {
                      DataRow dataRow2;
                      (dataRow2 = dataRow1)["Quantity"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["Quantity"], (object) qty);
                    }
                    checked { ++index2; }
                  }
                }
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            DataRow dataRow;
            (dataRow = dr)["QtyRemaining"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow["QtyRemaining"], (object) qty);
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dr["Quantity"], dr["QtyRemaining"]), dr["Quantity"], false))
              dr["Status"] = (object) true;
            flag1 = true;
          }
        }
        else
        {
          bool flag2 = false;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["OrderStatusID"], (object) 2, false) && App.ShowMessage("This order is still confirmed! Would you like to make it as complete now?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
          {
            this.CompleteOrder(Conversions.ToInteger(dr["OrderItemID"]));
            flag2 = true;
          }
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["QuantityOrdered"])) == Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["QuantityReceived"])) | flag2)
          {
            this.PartsAndProductsDistribution.Table.AcceptChanges();
            DataRow[] dataRowArray2 = this.PartsAndProductsDistribution.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AllocatedID = ", dr["ID"])));
            int index2 = 0;
            while (index2 < dataRowArray2.Length)
            {
              DataRow dataRow1 = dataRowArray2[index2];
              if (dataRow1 == null)
              {
                DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
                row["Type"] = RuntimeHelpers.GetObjectValue(dr["Type"]);
                row["DistributedID"] = (object) 0;
                row["LocationID"] = (object) 0;
                row["AllocatedID"] = RuntimeHelpers.GetObjectValue(dr["ID"]);
                row["Other"] = (object) false;
                row["Quantity"] = (object) qty;
                row["PartProductID"] = RuntimeHelpers.GetObjectValue(dr["PartProductID"]);
                row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(dr["OrderItemID"]);
                row["StockTransactionType"] = (object) 0;
                this.PartsAndProductsDistribution.Table.Rows.Add(row);
              }
              else
              {
                DataRow dataRow2;
                (dataRow2 = dataRow1)["Quantity"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["Quantity"], (object) qty);
              }
              checked { ++index2; }
            }
            DataRow dataRow;
            (dataRow = dr)["QtyRemaining"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow["QtyRemaining"], (object) qty);
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dr["Quantity"], dr["QtyRemaining"]), dr["Quantity"], false))
              dr["Status"] = (object) true;
            flag1 = true;
          }
          else if (App.ShowMessage("This is part that has been ordered but not fully received.\r\nWould you like to continue and select stock from another location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            FRMDistributeAllocated distributeAllocated = new FRMDistributeAllocated(true, qty, Conversions.ToString(dr["Name"]), Conversions.ToString(dr["Type"]), Conversions.ToInteger(dr["PartProductID"]), this.BuildAllocatedArray(Conversions.ToInteger(dr["PartProductID"]), Conversions.ToString(dr["Type"])));
            if (distributeAllocated.ShowDialog() == DialogResult.OK)
            {
              this.PartsAndProductsDistribution.Table.AcceptChanges();
              IEnumerator enumerator;
              try
              {
                enumerator = distributeAllocated.Locations.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["QtyRemaining"], (object) 0, false))
                  {
                    DataRow[] dataRowArray2 = this.PartsAndProductsDistribution.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AllocatedID = ", dr["ID"])));
                    int index2 = 0;
                    while (index2 < dataRowArray2.Length)
                    {
                      DataRow dataRow1 = dataRowArray2[index2];
                      if (dataRow1 == null)
                      {
                        DataRow row = this.PartsAndProductsDistribution.Table.NewRow();
                        row["Type"] = RuntimeHelpers.GetObjectValue(dr["Type"]);
                        row["DistributedID"] = (object) 0;
                        row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
                        row["AllocatedID"] = RuntimeHelpers.GetObjectValue(dr["ID"]);
                        row["Other"] = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["LocationID"], (object) 0, false) ? (object) false : (object) true;
                        row["Quantity"] = (object) qty;
                        row["PartProductID"] = RuntimeHelpers.GetObjectValue(dr["PartProductID"]);
                        row["OrderPartProductID"] = (object) 0;
                        row["StockTransactionType"] = (object) 3;
                        this.PartsAndProductsDistribution.Table.Rows.Add(row);
                        num1 = Conversions.ToInteger(current["LocationID"]);
                      }
                      else
                      {
                        DataRow dataRow2;
                        (dataRow2 = dataRow1)["Quantity"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["Quantity"], (object) qty);
                      }
                      checked { ++index2; }
                    }
                  }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              DataRow dataRow;
              (dataRow = dr)["QtyRemaining"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow["QtyRemaining"], (object) qty);
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dr["Quantity"], dr["QtyRemaining"]), dr["Quantity"], false))
                dr["Status"] = (object) true;
              flag1 = true;
            }
          }
        }
        if (flag1)
        {
          DataRow row = this.EngineerVisit.PartsAndProductsUsed.Table.NewRow();
          row["ID"] = RuntimeHelpers.GetObjectValue(dr["PartProductID"]);
          row["AllocatedID"] = RuntimeHelpers.GetObjectValue(dr["ID"]);
          row["Type"] = RuntimeHelpers.GetObjectValue(dr["Type"]);
          row["Quantity"] = (object) qty;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Part", false))
          {
            FRMChooseAsset frmChooseAsset = (FRMChooseAsset) App.checkIfExists(typeof (FRMChooseAsset).Name, true) ?? (FRMChooseAsset) Activator.CreateInstance(typeof (FRMChooseAsset));
            frmChooseAsset.ShowInTaskbar = false;
            frmChooseAsset.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID).JobID;
            frmChooseAsset.Part = Conversions.ToString(dr["Name"]);
            int num4 = (int) frmChooseAsset.ShowDialog();
            frmChooseAsset.Close();
            Part part = App.DB.Part.Part_Get(Conversions.ToInteger(dr["PartProductID"]));
            row["Number"] = (object) part.Number;
            row["Name"] = RuntimeHelpers.GetObjectValue(dr["Name"]);
            row["Reference"] = (object) part.Reference;
            row["SellPrice"] = RuntimeHelpers.GetObjectValue(dr["SellPrice"]);
            if (part.IsSpecialPart)
            {
              row["SpecialPrice"] = RuntimeHelpers.GetObjectValue(dr["SellPrice"]);
              row["BuyPrice"] = RuntimeHelpers.GetObjectValue(dr["SellPrice"]);
              row["SpecialDescription"] = RuntimeHelpers.GetObjectValue(dr["Name"]);
              row["Number"] = RuntimeHelpers.GetObjectValue(dr["Number"]);
              row["SpecialPartNumber"] = RuntimeHelpers.GetObjectValue(dr["Number"]);
            }
          }
          else
          {
            Product product = App.DB.Product.Product_Get(Conversions.ToInteger(dr["PartProductID"]));
            row["Number"] = (object) product.Number;
            row["Name"] = (object) product.Name;
            row["Reference"] = (object) product.Reference;
            row["SellPrice"] = (object) product.SellPrice;
          }
          this.EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(row);
        }
      }
    }

    public DataView PhotoDataview
    {
      get
      {
        return this._PhotoDataview;
      }
      set
      {
        this._PhotoDataview = value;
        this._PhotoDataview.AllowNew = false;
        this._PhotoDataview.AllowEdit = false;
        this._PhotoDataview.AllowDelete = false;
        this.LoadPhotoControls();
      }
    }

    private void tpPhotos_Enter(object sender, EventArgs e)
    {
      if (this.EngineerVisit.Photos.Count >= 1)
        return;
      this.EngineerVisit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(this.EngineerVisit.EngineerVisitID);
      this.PhotoDataview = this.EngineerVisit.Photos;
    }

    private void LoadPhotoControls()
    {
      this.flPhotos.SuspendLayout();
      this.flPhotos.Controls.Clear();
      IEnumerator enumerator;
      try
      {
        enumerator = this.PhotoDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          ucEngineerVisitPhoto engineerVisitPhoto = new ucEngineerVisitPhoto();
          engineerVisitPhoto.Photo = Image.FromStream((Stream) new MemoryStream((byte[]) current["Photo"]));
          engineerVisitPhoto.Caption = Conversions.ToString(current["Caption"]);
          engineerVisitPhoto.EngineerVisitPhotoID = Conversions.ToInteger(current["EngineerVisitPhotoID"]);
          engineerVisitPhoto.PhotoDeleteClicked += new ucEngineerVisitPhoto.PhotoDeleteClickedEventHandler(this.PhotoDeleteClicked);
          engineerVisitPhoto.PhotoCaptionChanged += new ucEngineerVisitPhoto.PhotoCaptionChangedEventHandler(this.PhotoCaptionChanged);
          this.flPhotos.Controls.Add((Control) engineerVisitPhoto);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.flPhotos.ResumeLayout();
    }

    private void PhotoCaptionChanged(int EngineerVisitPhotoID, string Caption)
    {
      EngineerVisitPhoto engineerVisitPhoto = new EngineerVisitPhoto();
      EngineerVisitPhoto oEngineerVisitPhoto = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_Get(EngineerVisitPhotoID);
      oEngineerVisitPhoto.SetCaption = (object) Caption;
      App.DB.EngineerVisitPhotos.Update(oEngineerVisitPhoto);
    }

    private void PhotoDeleteClicked(int EngineerVisitPhotoID)
    {
      if (MessageBox.Show("Are you sure you want to delete this photo?", "Delete Photo", MessageBoxButtons.YesNo) == DialogResult.Yes)
        App.DB.EngineerVisitPhotos.Delete(EngineerVisitPhotoID);
      this.EngineerVisit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(this.EngineerVisit.EngineerVisitID);
      this.PhotoDataview = this.EngineerVisit.Photos;
    }

    private void btnChangeOutcome_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Supervisor))
        return;
      this.cboOutcome.Enabled = true;
    }

    private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboOutcome)) == 1.0)
      {
        this.chkGasServiceCompleted.Enabled = true;
        if (this.Job.JobTypeID == 4702 | this.Job.JobTypeID == 519)
          this.chkGasServiceCompleted.Checked = true;
        else
          this.chkGasServiceCompleted.Checked = false;
      }
      else
      {
        this.chkGasServiceCompleted.Enabled = false;
        this.chkGasServiceCompleted.Checked = false;
      }
    }

    private void btnShowVisits_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMSiteVisitManager), true, new object[1]
      {
        (object) this.Job.PropertyID
      }, false);
    }

    private void radioButtonCostsTo_CheckedChanged(object sender, EventArgs e)
    {
      if (!(sender is RadioButton radioButton))
      {
        int num = (int) MessageBox.Show("Sender is not a RadioButton");
      }
      else if (radioButton.Checked && (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(radioButton.Text, this.EngineerVisit.CostsTo, false) > 0U)
        this.EngineerVisit.SetCostsTo = (object) radioButton.Text;
    }

    private void PopulateCostsTo()
    {
      string costsTo = this.EngineerVisit.CostsTo;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(costsTo, "Contract", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(costsTo, "Chargeable", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(costsTo, "Warranty", false) != 0)
            return;
          this.CostsToOption3.Checked = true;
        }
        else
          this.CostsToOption2.Checked = true;
      }
      else
        this.CostsToOption1.Checked = true;
    }

    private void cboRecharge_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboRecharge)) > 0.0)
        this.lblRechargeTicked.Visible = true;
      else
        this.lblRechargeTicked.Visible = false;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMCustomer), true, new object[1]
      {
        (object) App.CurrentCustomerID
      }, false);
    }

    private void btnEditInvoiceNotes_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Invoicing))
        return;
      this.txtNotesFromEngineer.ReadOnly = false;
      this.btnSave.Enabled = true;
    }

    private void cboVATRate_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SetPriceIncVAT();
      this.SaveInvoiceToBeRaisedDetails();
    }

    private void cboInvType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboInvType)) == 69491.0)
      {
        this.lblPaidBy.Visible = true;
        this.cboPaidBy.Visible = true;
      }
      else
      {
        this.lblPaidBy.Visible = false;
        this.cboPaidBy.Visible = false;
      }
      this.SaveInvoiceToBeRaisedDetails();
    }

    private void cboPaidBy_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SaveInvoiceToBeRaisedDetails();
    }

    private void btnCreateServ_Click(object sender, EventArgs e)
    {
      int num = (int) new FRMCreateServices()
      {
        SiteID = this.theSite.SiteID
      }.ShowDialog();
    }

    private void chkSORDesc_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkSORDesc.Checked)
        this.txtNotesFromEngineer.Enabled = false;
      else
        this.txtNotesFromEngineer.Enabled = true;
    }

    private void svrmenu_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit
      }, "Site Visit Report ", FSM.Entity.Sys.Enums.SystemDocumentType.SVR, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void JobSheetMenu_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit
      }, "JobSheet Report ", FSM.Entity.Sys.Enums.SystemDocumentType.JobSheet, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void DomesticGSRToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID
      }, "Domestic GSR", FSM.Entity.Sys.Enums.SystemDocumentType.DomGSR, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void WarningNoticeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.VisitDefectDataview
      }, "Warning Notice", FSM.Entity.Sys.Enums.SystemDocumentType.Warn, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void CommercialGSRToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID
      }, "Commercial GSR", FSM.Entity.Sys.Enums.SystemDocumentType.ComGSR, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void QCResultsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DataTable dataTable = App.DB.ExecuteWithReturn("Select TestType From tblEngineerVisitAdditionalChecks Where EngineerVisitID = " + Conversions.ToString(this.EngineerVisit.EngineerVisitID), true);
      IEnumerator enumerator;
      try
      {
        enumerator = dataTable.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["TestType"])))
          {
            case 69318:
            case 69319:
            case 69473:
            case 69592:
            case 71484:
              Printing printing = new Printing((object) new ArrayList()
              {
                (object) this.EngineerVisit.EngineerVisitID,
                RuntimeHelpers.GetObjectValue(current["TestType"])
              }, "QC Results", FSM.Entity.Sys.Enums.SystemDocumentType.QCPrint, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
              break;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void ElectricalMinorWorksToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit
      }, "Electrical Minor Works", FSM.Entity.Sys.Enums.SystemDocumentType.ElecMinor, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void AllGasPaperworkToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID,
        (object) this.VisitDefectDataview
      }, "Gas Safety Record ", FSM.Entity.Sys.Enums.SystemDocumentType.GSR, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void CommercialCateringToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID
      }, "Commercial Catering", FSM.Entity.Sys.Enums.SystemDocumentType.ComCat, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void SaffronUnventedWorkshhetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID
      }, "Saffron Unvented Worksheet", FSM.Entity.Sys.Enums.SystemDocumentType.SaffUnv, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void PropertyMaintenanceWorksheetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID
      }, "Property Maintenance Worksheer", FSM.Entity.Sys.Enums.SystemDocumentType.PropMaint, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void CommissioningChecklistToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit
      }, "Commissioning Checklist", FSM.Entity.Sys.Enums.SystemDocumentType.CommissioningChecklist, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void HotWorksPermitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit
      }, "Hot Works Permit", FSM.Entity.Sys.Enums.SystemDocumentType.HotWorksPermit, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void ASHPWorksheetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Save())
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit,
        (object) this.theSite.CustomerID
      }, "ASHP Worksheet", FSM.Entity.Sys.Enums.SystemDocumentType.ASHP, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.DocumentsControl.Populate();
    }

    private void rbSite_CheckedChanged(object sender, EventArgs e)
    {
      this.PopulateCharges(false);
    }

    private void chkShowJobCharges_CheckedChanged(object sender, EventArgs e)
    {
      if (this.EngineerVisit == null)
        return;
      this.PopulateCharges(false);
    }

    private void lblcredit_Click(object sender, EventArgs e)
    {
    }

    private void dgPartsProductsAllocated_Click(object sender, EventArgs e)
    {
      this.lblAllocatedQuantity.Visible = true;
      this.nudPartAllocatedQty.Visible = true;
      this.lblQuantityWarning.Visible = false;
      if (this.SelectedPartProductAllocatedDataRow == null)
        return;
      this.dgPartsProductsAllocated[this.dgPartsProductsAllocated.CurrentRowIndex, 1] = (object) !Conversions.ToBoolean(this.dgPartsProductsAllocated[this.dgPartsProductsAllocated.CurrentRowIndex, 1]);
      int num = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (Conversions.ToBoolean(((DataRow) enumerator.Current)["Tick"]))
          {
            checked { ++num; }
            if (num > 1)
            {
              this.lblAllocatedQuantity.Visible = false;
              this.nudPartAllocatedQty.Visible = false;
              this.lblQuantityWarning.Visible = true;
            }
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnRevertUsed_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("You are about to revert the parts and products used! Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.EngineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(this.EngineerVisit.EngineerVisitID);
      this.PartsAndProductsAllocated = this.EngineerVisit.PartsAndProductsAllocated;
      this.EngineerVisit.PartsAndProductsUsed = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(this.EngineerVisit.EngineerVisitID);
      this.dgPartsAndProductsUsed.DataSource = (object) this.EngineerVisit.PartsAndProductsUsed;
    }

    private void chkQCDocumentsRecieved_CheckedChanged(object sender, EventArgs e)
    {
      this.dtpQCDocumentsRecieved.Visible = this.chkQCDocumentsRecieved.Checked;
    }

    private void btnUnselectAllPPA_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          ((DataRow) enumerator.Current)["Tick"] = (object) false;
          this.lblAllocatedQuantity.Visible = true;
          this.nudPartAllocatedQty.Visible = true;
          this.lblQuantityWarning.Visible = false;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnSelectAllPPA_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.PartsAndProductsAllocated.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          ((DataRow) enumerator.Current)["Tick"] = (object) true;
          this.lblAllocatedQuantity.Visible = false;
          this.nudPartAllocatedQty.Visible = false;
          this.lblQuantityWarning.Visible = true;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public void SetupSiteFuelsDatagrid()
    {
      Helper.SetUpDataGrid(this.dgSiteFuel, false);
      DataGridTableStyle tableStyle = this.dgSiteFuel.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      tableStyle.AllowSorting = false;
      this.dgSiteFuel.ReadOnly = false;
      this.dgSiteFuel.AllowSorting = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Name";
      dataGridLabelColumn.MappingName = "Name";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 110;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      DataGridSiteFuelColumn gridSiteFuelColumn1 = new DataGridSiteFuelColumn();
      gridSiteFuelColumn1.Format = "dd/MM/yyyy";
      gridSiteFuelColumn1.FormatInfo = (IFormatProvider) null;
      gridSiteFuelColumn1.HeaderText = "Service Due";
      gridSiteFuelColumn1.MappingName = "ServiceDue";
      gridSiteFuelColumn1.ReadOnly = true;
      gridSiteFuelColumn1.Width = 105;
      gridSiteFuelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridSiteFuelColumn1);
      DataGridSiteFuelColumn gridSiteFuelColumn2 = new DataGridSiteFuelColumn();
      gridSiteFuelColumn2.Format = "dd/MM/yyyy";
      gridSiteFuelColumn2.FormatInfo = (IFormatProvider) null;
      gridSiteFuelColumn2.HeaderText = "Service Date";
      gridSiteFuelColumn2.MappingName = "ActualServiceDate";
      gridSiteFuelColumn2.ReadOnly = true;
      gridSiteFuelColumn2.Width = 105;
      gridSiteFuelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridSiteFuelColumn2);
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblSiteFuel.ToString();
      this.dgSiteFuel.TableStyles.Add(tableStyle);
    }

    public DataView SiteFuelsDataView
    {
      get
      {
        return this._dvSiteFuels;
      }
      set
      {
        this._dvSiteFuels = value;
        this._dvSiteFuels.AllowNew = false;
        this._dvSiteFuels.AllowEdit = false;
        this._dvSiteFuels.AllowDelete = false;
        this._dvSiteFuels.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblSiteFuel.ToString();
        this.dgSiteFuel.DataSource = (object) this.SiteFuelsDataView;
      }
    }

    private DataRow SelectedSiteFuelDataRow
    {
      get
      {
        return this.dgSiteFuel.CurrentRowIndex != -1 ? this.SiteFuelsDataView[this.dgSiteFuel.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void PopulateSiteFuelDataGrid()
    {
      try
      {
        this.SiteFuelsDataView = App.DB.Sites.SiteFuel_Get_ForEngineerVisit(this.EngineerVisit.EngineerVisitID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgSiteFuel_Click(object sender, EventArgs e)
    {
      if (this.SelectedSiteFuelDataRow == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.SiteFuelsDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) 0;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.dgSiteFuel[this.dgSiteFuel.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgSiteFuel[this.dgSiteFuel.CurrentRowIndex, 0]);
    }

    private void chkTimesheetSelectAll_Click(object sender, EventArgs e)
    {
      this.chkTimesheetSelectAll.Checked = !this.chkTimesheetSelectAll.Checked;
      try
      {
        IEnumerator enumerator1;
        IEnumerator enumerator2;
        if (this.chkTimesheetSelectAll.Checked)
        {
          try
          {
            enumerator1 = this.TimeSheetCharges.Table.Rows.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRow current = (DataRow) enumerator1.Current;
              App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(current["EngineerVisitTimesheetChargeID"]), 1);
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        }
        else
        {
          try
          {
            enumerator2 = this.TimeSheetCharges.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(current["EngineerVisitTimesheetChargeID"]), 0);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
        this.PopulateTimeSheetCharges(false, true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void chkPartsSelectAll_Click(object sender, EventArgs e)
    {
      this.chkPartsSelectAll.Checked = !this.chkPartsSelectAll.Checked;
      try
      {
        IEnumerator enumerator1;
        IEnumerator enumerator2;
        if (this.chkPartsSelectAll.Checked)
        {
          try
          {
            enumerator1 = this.PartProductsCharges.Table.Rows.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRow current = (DataRow) enumerator1.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Part", false))
              {
                App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(current["ChargeID"]));
                App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["UniqueID"]), Conversions.ToDouble(current["Price"]), 1, Conversions.ToDouble(current["Cost"]), Conversions.ToInteger(current["PartUsedID"]));
              }
              else
              {
                App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Conversions.ToInteger(current["ChargeID"]));
                App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["UniqueID"]), Conversions.ToDouble(current["Price"]), 1, Conversions.ToDouble(current["Cost"]));
              }
              current["tick"] = (object) true;
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        }
        else
        {
          try
          {
            enumerator2 = this.PartProductsCharges.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Part", false))
              {
                App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(current["ChargeID"]));
                App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["UniqueID"]), Conversions.ToDouble(current["Price"]), 0, Conversions.ToDouble(current["Cost"]), Conversions.ToInteger(current["PartUsedID"]));
              }
              else
              {
                App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Conversions.ToInteger(current["ChargeID"]));
                App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["UniqueID"]), Conversions.ToDouble(current["Price"]), 0, Conversions.ToDouble(current["Cost"]));
              }
              current["tick"] = (object) false;
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
        this.PopulatePartsProductsCharges(false, true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtLabourMarkUp_TextChanged(object sender, EventArgs e)
    {
      try
      {
        IEnumerator enumerator;
        try
        {
          enumerator = this.TimeSheetCharges.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(current["EngineerVisitTimesheetChargeID"]), 1);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void txtPartsMarkUp_Leave(object sender, EventArgs e)
    {
      try
      {
        App.DB.EngineerVisitCharge.EngineerVisitPartsCharge_Update_Price(this.EngineerVisit.EngineerVisitID, Helper.MakeIntegerValid((object) this.txtPartsMarkUp.Text));
        this.PopulatePartsProductsCharges(false, false);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void txtPartsProductTotal_Leave(object sender, EventArgs e)
    {
      this.CalculateJobValue();
    }

    private void txtTimesheetTotal_Leave(object sender, EventArgs e)
    {
      this.CalculateJobValue();
    }

    private void UnCheckAllCharges()
    {
      try
      {
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.PartProductsCharges.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Part", false))
            {
              App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(Conversions.ToInteger(current["ChargeID"]));
              App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["UniqueID"]), Conversions.ToDouble(current["Price"]), 0, Conversions.ToDouble(current["Cost"]), Conversions.ToInteger(current["PartUsedID"]));
            }
            else
            {
              App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Conversions.ToInteger(current["ChargeID"]));
              App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(this.EngineerVisit.EngineerVisitID, Conversions.ToInteger(current["UniqueID"]), Conversions.ToDouble(current["Price"]), 0, Conversions.ToDouble(current["Cost"]));
            }
            current["tick"] = (object) false;
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.TimeSheetCharges.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(Conversions.ToInteger(current["EngineerVisitTimesheetChargeID"]), 0);
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private class CheckListMenuItem : MenuItem
    {
      private string _Section;
      private int _SectionID;
      private int _EngineerVisitID;
      private DataGrid _ChecklistDatagrid;
      private DataView _ChecklistDataview;

      public string Section
      {
        get
        {
          return this._Section;
        }
        set
        {
          this._Section = value;
        }
      }

      public int SectionID
      {
        get
        {
          return this._SectionID;
        }
        set
        {
          this._SectionID = value;
        }
      }

      public int EngineerVisitID
      {
        get
        {
          return this._EngineerVisitID;
        }
        set
        {
          this._EngineerVisitID = value;
        }
      }

      public DataGrid ChecklistDatagrid
      {
        get
        {
          return this._ChecklistDatagrid;
        }
        set
        {
          this._ChecklistDatagrid = value;
        }
      }

      public DataView ChecklistDataview
      {
        get
        {
          return this._ChecklistDataview;
        }
        set
        {
          this._ChecklistDataview = value;
        }
      }

      public CheckListMenuItem(
        string SectionIn,
        int SectionIDIn,
        int EngineerVisitIDIn,
        ref DataView ChecklistDataviewIn,
        ref DataGrid ChecklistDatagridIn)
      {
        this._Section = "";
        this._SectionID = 0;
        this._EngineerVisitID = 0;
        this.Section = SectionIn;
        this.SectionID = SectionIDIn;
        this.EngineerVisitID = EngineerVisitIDIn;
        this.ChecklistDataview = ChecklistDataviewIn;
        this.ChecklistDatagrid = ChecklistDatagridIn;
        this.Text = "Check List : " + this.Section;
        this.Click += new EventHandler(this.OpenChecklist);
      }

      private void OpenChecklist(object sender, EventArgs e)
      {
        App.ShowForm(typeof (FRMAnswers), true, new object[3]
        {
          (object) this.EngineerVisitID,
          (object) this.SectionID,
          (object) 0
        }, false);
        this.ChecklistDataview = App.DB.Checklists.GetAll_For_Engineer_Visit(this.EngineerVisitID);
        this.ChecklistDatagrid.DataSource = (object) this.ChecklistDataview;
      }
    }

    public class AllocatedStatusColourColumn : DataGridLabelColumn
    {
      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        Brush brush = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "Status"
        }, (string[]) null, (System.Type[]) null, (bool[]) null))) ? Brushes.Red : Brushes.Lime;
        Rectangle rect = bounds;
        g.FillRectangle(brush, rect);
        g.DrawString("", this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
      }
    }
  }
}
