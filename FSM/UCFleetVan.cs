// Decompiled with JetBrains decompiler
// Type: FSM.UCFleetVan
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.FleetVans;
using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCFleetVan : UCBase, IUserControl
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private FleetVan _currentVan;
    private FleetVanEngineer _currentVanEngineer;
    private FleetVanMaintenance _currentVanMaintenance;
    private FleetVanFault _currentVanFault;
    private FleetVanContract _currentContract;
    private Engineer _engineer;
    private DataView _dvVanEquipment;
    private DataView _dvVanFaults;
    private DataView _dvEngineerHistory;
    private DataView _jobsTable;
    private DataView _dvVanAudits;
    private List<int> _equipmentList;

    public UCFleetVan()
    {
      this.Load += new EventHandler(this.UCFleetVan_Load);
      this._jobsTable = (DataView) null;
      this._equipmentList = new List<int>();
      this.InitializeComponent();
      ComboBox cboVanType = this.cboVanType;
      Combo.SetUpCombo(ref cboVanType, App.DB.FleetVanType.GetAll().Table, "VanTypeID", "Model", Enums.ComboValues.Please_Select);
      this.cboVanType = cboVanType;
      ComboBox cboFaultType = this.cboFaultType;
      Combo.SetUpCombo(ref cboFaultType, App.DB.FleetVanFault.FaultTypes_GetAll().Table, "VanFaultTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboFaultType = cboFaultType;
      ComboBox procurementMethod = this.cboProcurementMethod;
      Combo.SetUpCombo(ref procurementMethod, DynamicDataTables.FleetVanContractProcurementMethod, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboProcurementMethod = procurementMethod;
      if (true == App.IsGasway)
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      else
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabPage tabHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVanAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgVanAudits
    {
      get
      {
        return this._dgVanAudits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgVanAudits_Click);
        DataGrid dgVanAudits1 = this._dgVanAudits;
        if (dgVanAudits1 != null)
          dgVanAudits1.Click -= eventHandler;
        this._dgVanAudits = value;
        DataGrid dgVanAudits2 = this._dgVanAudits;
        if (dgVanAudits2 == null)
          return;
        dgVanAudits2.Click += eventHandler;
      }
    }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpMaintenance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpNextServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNextServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpLastServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpMOTExpiry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMOT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBreakdown { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBreakdownCompany { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLastService { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnfindEngineer
    {
      get
      {
        return this._btnfindEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindEngineer_Click);
        Button btnfindEngineer1 = this._btnfindEngineer;
        if (btnfindEngineer1 != null)
          btnfindEngineer1.Click -= eventHandler;
        this._btnfindEngineer = value;
        Button btnfindEngineer2 = this._btnfindEngineer;
        if (btnfindEngineer2 == null)
          return;
        btnfindEngineer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblReturned { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAverageMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAverageMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtModel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMdoel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVanType
    {
      get
      {
        return this._cboVanType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboVanType_SelectedIndexChanged);
        ComboBox cboVanType1 = this._cboVanType;
        if (cboVanType1 != null)
          cboVanType1.SelectedIndexChanged -= eventHandler;
        this._cboVanType = value;
        ComboBox cboVanType2 = this._cboVanType;
        if (cboVanType2 == null)
          return;
        cboVanType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtMake { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRegistration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegistration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInsuranceDue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMake { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl tcVans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTaxExpiry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRoadTax { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnNextService
    {
      get
      {
        return this._btnNextService;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNextService_Click);
        Button btnNextService1 = this._btnNextService;
        if (btnNextService1 != null)
          btnNextService1.Click -= eventHandler;
        this._btnNextService = value;
        Button btnNextService2 = this._btnNextService;
        if (btnNextService2 == null)
          return;
        btnNextService2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtLastServiceMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMileageLastService { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkReturned
    {
      get
      {
        return this._chkReturned;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkReturned_CheckedChanged);
        CheckBox chkReturned1 = this._chkReturned;
        if (chkReturned1 != null)
          chkReturned1.CheckedChanged -= eventHandler;
        this._chkReturned = value;
        CheckBox chkReturned2 = this._chkReturned;
        if (chkReturned2 == null)
          return;
        chkReturned2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TabPage tabFaults { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpFaultDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFaultType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineerFaultNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaultType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVanFaultDg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgVanFaults
    {
      get
      {
        return this._dgVanFaults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgVanFaults_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgVanFaults_Click);
        EventHandler eventHandler3 = new EventHandler(this.dgVanFaults_DoubleClick);
        DataGrid dgVanFaults1 = this._dgVanFaults;
        if (dgVanFaults1 != null)
        {
          dgVanFaults1.Click -= eventHandler1;
          dgVanFaults1.CurrentCellChanged -= eventHandler2;
          dgVanFaults1.DoubleClick -= eventHandler3;
        }
        this._dgVanFaults = value;
        DataGrid dgVanFaults2 = this._dgVanFaults;
        if (dgVanFaults2 == null)
          return;
        dgVanFaults2.Click += eventHandler1;
        dgVanFaults2.CurrentCellChanged += eventHandler2;
        dgVanFaults2.DoubleClick += eventHandler3;
      }
    }

    internal virtual TextBox txtFaultNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaultNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkResolved
    {
      get
      {
        return this._chkResolved;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkResolved_CheckedChanged);
        CheckBox chkResolved1 = this._chkResolved;
        if (chkResolved1 != null)
          chkResolved1.CheckedChanged -= eventHandler;
        this._chkResolved = value;
        CheckBox chkResolved2 = this._chkResolved;
        if (chkResolved2 == null)
          return;
        chkResolved2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpResolvedDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblResolvedDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFaultDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaultDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemove
    {
      get
      {
        return this._btnRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
        Button btnRemove1 = this._btnRemove;
        if (btnRemove1 != null)
          btnRemove1.Click -= eventHandler;
        this._btnRemove = value;
        Button btnRemove2 = this._btnRemove;
        if (btnRemove2 == null)
          return;
        btnRemove2.Click += eventHandler;
      }
    }

    internal virtual TabPage tabContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpContractDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboProcurementMethod
    {
      get
      {
        return this._cboProcurementMethod;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboProcurementMethod_SelectedIndexChanged);
        ComboBox procurementMethod1 = this._cboProcurementMethod;
        if (procurementMethod1 != null)
          procurementMethod1.SelectedIndexChanged -= eventHandler;
        this._cboProcurementMethod = value;
        ComboBox procurementMethod2 = this._cboProcurementMethod;
        if (procurementMethod2 == null)
          return;
        procurementMethod2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtContractLength { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLessor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLessor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProcurementMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractLength { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabEngineerHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpEngineerHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgEngineerHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnNewFault
    {
      get
      {
        return this._btnNewFault;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNewFault_Click);
        Button btnNewFault1 = this._btnNewFault;
        if (btnNewFault1 != null)
          btnNewFault1.Click -= eventHandler;
        this._btnNewFault = value;
        Button btnNewFault2 = this._btnNewFault;
        if (btnNewFault2 == null)
          return;
        btnNewFault2.Click += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpContractEnd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractEnd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpContractStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAgreementRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAgreementRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpFinances { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMonthlyRental
    {
      get
      {
        return this._txtMonthlyRental;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtMonthlyRental_KeyUp);
        TextBox txtMonthlyRental1 = this._txtMonthlyRental;
        if (txtMonthlyRental1 != null)
          txtMonthlyRental1.KeyUp -= keyEventHandler;
        this._txtMonthlyRental = value;
        TextBox txtMonthlyRental2 = this._txtMonthlyRental;
        if (txtMonthlyRental2 == null)
          return;
        txtMonthlyRental2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Label lblMonthlyRental { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAnnualRental { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWeeklyRental
    {
      get
      {
        return this._txtWeeklyRental;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtWeeklyRental_KeyUp);
        TextBox txtWeeklyRental1 = this._txtWeeklyRental;
        if (txtWeeklyRental1 != null)
          txtWeeklyRental1.KeyUp -= keyEventHandler;
        this._txtWeeklyRental = value;
        TextBox txtWeeklyRental2 = this._txtWeeklyRental;
        if (txtWeeklyRental2 == null)
          return;
        txtWeeklyRental2.KeyUp += keyEventHandler;
      }
    }

    internal virtual TextBox txtExcessMileageRate
    {
      get
      {
        return this._txtExcessMileageRate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtExcessMileageRate_KeyUp);
        TextBox excessMileageRate1 = this._txtExcessMileageRate;
        if (excessMileageRate1 != null)
          excessMileageRate1.KeyUp -= keyEventHandler;
        this._txtExcessMileageRate = value;
        TextBox excessMileageRate2 = this._txtExcessMileageRate;
        if (excessMileageRate2 == null)
          return;
        excessMileageRate2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Label lblExcessMileageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblWeeklyRental { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAnnualRental
    {
      get
      {
        return this._txtAnnualRental;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtAnnualRental_KeyUp);
        TextBox txtAnnualRental1 = this._txtAnnualRental;
        if (txtAnnualRental1 != null)
          txtAnnualRental1.KeyUp -= keyEventHandler;
        this._txtAnnualRental = value;
        TextBox txtAnnualRental2 = this._txtAnnualRental;
        if (txtAnnualRental2 == null)
          return;
        txtAnnualRental2.KeyUp += keyEventHandler;
      }
    }

    internal virtual TextBox txtContractNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabServiceHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpServiceHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgServiceHistory
    {
      get
      {
        return this._dgServiceHistory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgServiceHistory_DoubleClick);
        DataGrid dgServiceHistory1 = this._dgServiceHistory;
        if (dgServiceHistory1 != null)
          dgServiceHistory1.DoubleClick -= eventHandler;
        this._dgServiceHistory = value;
        DataGrid dgServiceHistory2 = this._dgServiceHistory;
        if (dgServiceHistory2 == null)
          return;
        dgServiceHistory2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnRemoveEquipment
    {
      get
      {
        return this._btnRemoveEquipment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveEquipment_Click);
        Button btnRemoveEquipment1 = this._btnRemoveEquipment;
        if (btnRemoveEquipment1 != null)
          btnRemoveEquipment1.Click -= eventHandler;
        this._btnRemoveEquipment = value;
        Button btnRemoveEquipment2 = this._btnRemoveEquipment;
        if (btnRemoveEquipment2 == null)
          return;
        btnRemoveEquipment2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddEquipment
    {
      get
      {
        return this._btnAddEquipment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddEquipment_Click);
        Button btnAddEquipment1 = this._btnAddEquipment;
        if (btnAddEquipment1 != null)
          btnAddEquipment1.Click -= eventHandler;
        this._btnAddEquipment = value;
        Button btnAddEquipment2 = this._btnAddEquipment;
        if (btnAddEquipment2 == null)
          return;
        btnAddEquipment2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtForecastExcessCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblForcastedExcessCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtExcessMileageCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblExcessCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtScheduled { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblScheduled { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpHistoryDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtUsername { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpHistoryDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtChange { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblChange { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOutcome { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOutcome { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEndContract
    {
      get
      {
        return this._btnEndContract;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEndContract_Click);
        Button btnEndContract1 = this._btnEndContract;
        if (btnEndContract1 != null)
          btnEndContract1.Click -= eventHandler;
        this._btnEndContract = value;
        Button btnEndContract2 = this._btnEndContract;
        if (btnEndContract2 == null)
          return;
        btnEndContract2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkEndDate
    {
      get
      {
        return this._chkEndDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkEndDate_CheckedChanged);
        CheckBox chkEndDate1 = this._chkEndDate;
        if (chkEndDate1 != null)
          chkEndDate1.CheckedChanged -= eventHandler;
        this._chkEndDate = value;
        CheckBox chkEndDate2 = this._chkEndDate;
        if (chkEndDate2 == null)
          return;
        chkEndDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAdditionalNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkArchive { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkHideArchive
    {
      get
      {
        return this._chkHideArchive;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkHideArchive_CheckedChanged);
        CheckBox chkHideArchive1 = this._chkHideArchive;
        if (chkHideArchive1 != null)
          chkHideArchive1.CheckedChanged -= eventHandler;
        this._chkHideArchive = value;
        CheckBox chkHideArchive2 = this._chkHideArchive;
        if (chkHideArchive2 == null)
          return;
        chkHideArchive2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtStartingMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStartingMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTyreSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTyresSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpBreakdownExpiry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBreakdownExpiry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpWarrantyExpiry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblWarrantyExpiry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveContractEndDate
    {
      get
      {
        return this._btnRemoveContractEndDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveContractEndDate_Click);
        Button removeContractEndDate1 = this._btnRemoveContractEndDate;
        if (removeContractEndDate1 != null)
          removeContractEndDate1.Click -= eventHandler;
        this._btnRemoveContractEndDate = value;
        Button removeContractEndDate2 = this._btnRemoveContractEndDate;
        if (removeContractEndDate2 == null)
          return;
        removeContractEndDate2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveFault
    {
      get
      {
        return this._btnSaveFault;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = (EventHandler) ((a0, a1) => this.btnSaveFault_Click());
        EventHandler eventHandler2 = new EventHandler(this.btnSaveFault_Click);
        Button btnSaveFault1 = this._btnSaveFault;
        if (btnSaveFault1 != null)
        {
          btnSaveFault1.Click -= eventHandler1;
          btnSaveFault1.Click -= eventHandler2;
        }
        this._btnSaveFault = value;
        Button btnSaveFault2 = this._btnSaveFault;
        if (btnSaveFault2 == null)
          return;
        btnSaveFault2.Click += eventHandler1;
        btnSaveFault2.Click += eventHandler2;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.tabHistory = new TabPage();
      this.grpHistoryDetails = new GroupBox();
      this.txtUsername = new TextBox();
      this.lblUser = new Label();
      this.dtpHistoryDate = new DateTimePicker();
      this.lblDate = new Label();
      this.txtChange = new TextBox();
      this.lblChange = new Label();
      this.grpVanAudit = new GroupBox();
      this.dgVanAudits = new DataGrid();
      this.tabDetails = new TabPage();
      this.grpMaintenance = new GroupBox();
      this.dtpBreakdownExpiry = new DateTimePicker();
      this.lblBreakdownExpiry = new Label();
      this.dtpWarrantyExpiry = new DateTimePicker();
      this.lblWarrantyExpiry = new Label();
      this.txtLastServiceMileage = new TextBox();
      this.lblMileageLastService = new Label();
      this.btnNextService = new Button();
      this.dtpTaxExpiry = new DateTimePicker();
      this.lblRoadTax = new Label();
      this.dtpNextServiceDate = new DateTimePicker();
      this.lblNextServiceDate = new Label();
      this.dtpLastServiceDate = new DateTimePicker();
      this.dtpMOTExpiry = new DateTimePicker();
      this.lblMOT = new Label();
      this.txtBreakdown = new TextBox();
      this.lblBreakdownCompany = new Label();
      this.lblLastService = new Label();
      this.grpEngineer = new GroupBox();
      this.cboDepartment = new ComboBox();
      this.chkEndDate = new CheckBox();
      this.dtpEndDate = new DateTimePicker();
      this.btnRemove = new Button();
      this.dtpStartDate = new DateTimePicker();
      this.lblStartDate = new Label();
      this.lblDepartment = new Label();
      this.btnfindEngineer = new Button();
      this.txtEngineer = new TextBox();
      this.lblEngineer = new Label();
      this.grpVan = new GroupBox();
      this.txtTyreSize = new TextBox();
      this.lblTyresSize = new Label();
      this.btnRemoveEquipment = new Button();
      this.btnAddEquipment = new Button();
      this.dgEquipment = new DataGrid();
      this.chkReturned = new CheckBox();
      this.lblReturned = new Label();
      this.txtAverageMileage = new TextBox();
      this.lblAverageMileage = new Label();
      this.txtMileage = new TextBox();
      this.lblMileage = new Label();
      this.txtModel = new TextBox();
      this.lblMdoel = new Label();
      this.cboVanType = new ComboBox();
      this.txtMake = new TextBox();
      this.txtRegistration = new TextBox();
      this.lblRegistration = new Label();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.lblInsuranceDue = new Label();
      this.lblMake = new Label();
      this.tcVans = new TabControl();
      this.tabFaults = new TabPage();
      this.chkHideArchive = new CheckBox();
      this.grpFaultDetails = new GroupBox();
      this.chkArchive = new CheckBox();
      this.txtAdditionalNotes = new TextBox();
      this.lblAddNotes = new Label();
      this.txtOutcome = new TextBox();
      this.lblOutcome = new Label();
      this.txtStatus = new TextBox();
      this.lblVisitStatus = new Label();
      this.txtScheduled = new TextBox();
      this.lblScheduled = new Label();
      this.txtJobRef = new TextBox();
      this.lblJobRef = new Label();
      this.btnNewFault = new Button();
      this.chkResolved = new CheckBox();
      this.dtpResolvedDate = new DateTimePicker();
      this.lblResolvedDate = new Label();
      this.dtpFaultDate = new DateTimePicker();
      this.lblFaultDate = new Label();
      this.txtFaultNotes = new TextBox();
      this.lblFaultNotes = new Label();
      this.cboFaultType = new ComboBox();
      this.txtEngineerFaultNotes = new TextBox();
      this.lblEngineerNotes = new Label();
      this.lblFaultType = new Label();
      this.grpVanFaultDg = new GroupBox();
      this.dgVanFaults = new DataGrid();
      this.tabContract = new TabPage();
      this.grpFinances = new GroupBox();
      this.txtForecastExcessCost = new TextBox();
      this.lblForcastedExcessCost = new Label();
      this.txtExcessMileageCost = new TextBox();
      this.lblExcessCost = new Label();
      this.txtAnnualRental = new TextBox();
      this.txtMonthlyRental = new TextBox();
      this.lblMonthlyRental = new Label();
      this.lblAnnualRental = new Label();
      this.txtWeeklyRental = new TextBox();
      this.txtExcessMileageRate = new TextBox();
      this.lblExcessMileageRate = new Label();
      this.lblWeeklyRental = new Label();
      this.grpContractDetails = new GroupBox();
      this.btnRemoveContractEndDate = new Button();
      this.txtStartingMileage = new TextBox();
      this.lblStartingMileage = new Label();
      this.btnEndContract = new Button();
      this.txtContractNotes = new TextBox();
      this.lblContractNotes = new Label();
      this.txtAgreementRef = new TextBox();
      this.lblAgreementRef = new Label();
      this.txtContractMileage = new TextBox();
      this.lblContractMileage = new Label();
      this.dtpContractEnd = new DateTimePicker();
      this.lblContractEnd = new Label();
      this.dtpContractStart = new DateTimePicker();
      this.lblContractStart = new Label();
      this.cboProcurementMethod = new ComboBox();
      this.txtContractLength = new TextBox();
      this.txtLessor = new TextBox();
      this.lblLessor = new Label();
      this.lblProcurementMethod = new Label();
      this.lblContractLength = new Label();
      this.tabEngineerHistory = new TabPage();
      this.grpEngineerHistory = new GroupBox();
      this.dgEngineerHistory = new DataGrid();
      this.tabServiceHistory = new TabPage();
      this.gpServiceHistory = new GroupBox();
      this.dgServiceHistory = new DataGrid();
      this.tabDocuments = new TabPage();
      this.btnSaveFault = new Button();
      this.tabHistory.SuspendLayout();
      this.grpHistoryDetails.SuspendLayout();
      this.grpVanAudit.SuspendLayout();
      this.dgVanAudits.BeginInit();
      this.tabDetails.SuspendLayout();
      this.grpMaintenance.SuspendLayout();
      this.grpEngineer.SuspendLayout();
      this.grpVan.SuspendLayout();
      this.dgEquipment.BeginInit();
      this.tcVans.SuspendLayout();
      this.tabFaults.SuspendLayout();
      this.grpFaultDetails.SuspendLayout();
      this.grpVanFaultDg.SuspendLayout();
      this.dgVanFaults.BeginInit();
      this.tabContract.SuspendLayout();
      this.grpFinances.SuspendLayout();
      this.grpContractDetails.SuspendLayout();
      this.tabEngineerHistory.SuspendLayout();
      this.grpEngineerHistory.SuspendLayout();
      this.dgEngineerHistory.BeginInit();
      this.tabServiceHistory.SuspendLayout();
      this.gpServiceHistory.SuspendLayout();
      this.dgServiceHistory.BeginInit();
      this.SuspendLayout();
      this.tabHistory.Controls.Add((Control) this.grpHistoryDetails);
      this.tabHistory.Controls.Add((Control) this.grpVanAudit);
      this.tabHistory.Location = new System.Drawing.Point(4, 22);
      this.tabHistory.Name = "tabHistory";
      this.tabHistory.Size = new Size(675, 702);
      this.tabHistory.TabIndex = 1;
      this.tabHistory.Text = "History";
      this.tabHistory.UseVisualStyleBackColor = true;
      this.grpHistoryDetails.Controls.Add((Control) this.txtUsername);
      this.grpHistoryDetails.Controls.Add((Control) this.lblUser);
      this.grpHistoryDetails.Controls.Add((Control) this.dtpHistoryDate);
      this.grpHistoryDetails.Controls.Add((Control) this.lblDate);
      this.grpHistoryDetails.Controls.Add((Control) this.txtChange);
      this.grpHistoryDetails.Controls.Add((Control) this.lblChange);
      this.grpHistoryDetails.Location = new System.Drawing.Point(6, 7);
      this.grpHistoryDetails.Name = "grpHistoryDetails";
      this.grpHistoryDetails.Size = new Size(664, 241);
      this.grpHistoryDetails.TabIndex = 17;
      this.grpHistoryDetails.TabStop = false;
      this.grpHistoryDetails.Text = "History Details";
      this.txtUsername.Location = new System.Drawing.Point(372, 24);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.ReadOnly = true;
      this.txtUsername.Size = new Size(146, 21);
      this.txtUsername.TabIndex = 68;
      this.lblUser.Location = new System.Drawing.Point(312, 27);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new Size(44, 20);
      this.lblUser.TabIndex = 67;
      this.lblUser.Text = "User";
      this.dtpHistoryDate.Enabled = false;
      this.dtpHistoryDate.Location = new System.Drawing.Point(89, 21);
      this.dtpHistoryDate.Name = "dtpHistoryDate";
      this.dtpHistoryDate.Size = new Size(146, 21);
      this.dtpHistoryDate.TabIndex = 2;
      this.dtpHistoryDate.Tag = (object) "";
      this.lblDate.Location = new System.Drawing.Point(9, 27);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new Size(85, 20);
      this.lblDate.TabIndex = 65;
      this.lblDate.Text = "Date";
      this.txtChange.Location = new System.Drawing.Point(89, 64);
      this.txtChange.Multiline = true;
      this.txtChange.Name = "txtChange";
      this.txtChange.ScrollBars = ScrollBars.Vertical;
      this.txtChange.Size = new Size(569, 161);
      this.txtChange.TabIndex = 6;
      this.txtChange.Tag = (object) "";
      this.lblChange.Location = new System.Drawing.Point(10, 64);
      this.lblChange.Name = "lblChange";
      this.lblChange.Size = new Size(59, 20);
      this.lblChange.TabIndex = 45;
      this.lblChange.Text = "Change";
      this.grpVanAudit.Controls.Add((Control) this.dgVanAudits);
      this.grpVanAudit.Location = new System.Drawing.Point(3, 254);
      this.grpVanAudit.Name = "grpVanAudit";
      this.grpVanAudit.Size = new Size(664, 553);
      this.grpVanAudit.TabIndex = 4;
      this.grpVanAudit.TabStop = false;
      this.grpVanAudit.Text = "Van Audit";
      this.dgVanAudits.DataMember = "";
      this.dgVanAudits.Dock = DockStyle.Fill;
      this.dgVanAudits.HeaderForeColor = SystemColors.ControlText;
      this.dgVanAudits.Location = new System.Drawing.Point(3, 17);
      this.dgVanAudits.Name = "dgVanAudits";
      this.dgVanAudits.Size = new Size(658, 533);
      this.dgVanAudits.TabIndex = 15;
      this.tabDetails.Controls.Add((Control) this.grpMaintenance);
      this.tabDetails.Controls.Add((Control) this.grpEngineer);
      this.tabDetails.Controls.Add((Control) this.grpVan);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(675, 702);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Main Details";
      this.grpMaintenance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpMaintenance.Controls.Add((Control) this.dtpBreakdownExpiry);
      this.grpMaintenance.Controls.Add((Control) this.lblBreakdownExpiry);
      this.grpMaintenance.Controls.Add((Control) this.dtpWarrantyExpiry);
      this.grpMaintenance.Controls.Add((Control) this.lblWarrantyExpiry);
      this.grpMaintenance.Controls.Add((Control) this.txtLastServiceMileage);
      this.grpMaintenance.Controls.Add((Control) this.lblMileageLastService);
      this.grpMaintenance.Controls.Add((Control) this.btnNextService);
      this.grpMaintenance.Controls.Add((Control) this.dtpTaxExpiry);
      this.grpMaintenance.Controls.Add((Control) this.lblRoadTax);
      this.grpMaintenance.Controls.Add((Control) this.dtpNextServiceDate);
      this.grpMaintenance.Controls.Add((Control) this.lblNextServiceDate);
      this.grpMaintenance.Controls.Add((Control) this.dtpLastServiceDate);
      this.grpMaintenance.Controls.Add((Control) this.dtpMOTExpiry);
      this.grpMaintenance.Controls.Add((Control) this.lblMOT);
      this.grpMaintenance.Controls.Add((Control) this.txtBreakdown);
      this.grpMaintenance.Controls.Add((Control) this.lblBreakdownCompany);
      this.grpMaintenance.Controls.Add((Control) this.lblLastService);
      this.grpMaintenance.Location = new System.Drawing.Point(8, 302);
      this.grpMaintenance.Name = "grpMaintenance";
      this.grpMaintenance.Size = new Size(664, 222);
      this.grpMaintenance.TabIndex = 61;
      this.grpMaintenance.TabStop = false;
      this.grpMaintenance.Text = "Maintenance";
      this.dtpBreakdownExpiry.Location = new System.Drawing.Point(457, 178);
      this.dtpBreakdownExpiry.Name = "dtpBreakdownExpiry";
      this.dtpBreakdownExpiry.Size = new Size(141, 21);
      this.dtpBreakdownExpiry.TabIndex = 71;
      this.dtpBreakdownExpiry.Tag = (object) "";
      this.lblBreakdownExpiry.Location = new System.Drawing.Point(325, 184);
      this.lblBreakdownExpiry.Name = "lblBreakdownExpiry";
      this.lblBreakdownExpiry.Size = new Size(117, 20);
      this.lblBreakdownExpiry.TabIndex = 72;
      this.lblBreakdownExpiry.Text = "Breakdown Expiry";
      this.dtpWarrantyExpiry.Location = new System.Drawing.Point(457, 138);
      this.dtpWarrantyExpiry.Name = "dtpWarrantyExpiry";
      this.dtpWarrantyExpiry.Size = new Size(141, 21);
      this.dtpWarrantyExpiry.TabIndex = 69;
      this.dtpWarrantyExpiry.Tag = (object) "";
      this.lblWarrantyExpiry.Location = new System.Drawing.Point(325, 144);
      this.lblWarrantyExpiry.Name = "lblWarrantyExpiry";
      this.lblWarrantyExpiry.Size = new Size(105, 20);
      this.lblWarrantyExpiry.TabIndex = 70;
      this.lblWarrantyExpiry.Text = "Warranty Expiry";
      this.txtLastServiceMileage.Location = new System.Drawing.Point(489, 18);
      this.txtLastServiceMileage.Name = "txtLastServiceMileage";
      this.txtLastServiceMileage.Size = new Size(109, 21);
      this.txtLastServiceMileage.TabIndex = 10;
      this.txtLastServiceMileage.Tag = (object) " ";
      this.lblMileageLastService.Location = new System.Drawing.Point(325, 21);
      this.lblMileageLastService.Name = "lblMileageLastService";
      this.lblMileageLastService.Size = new Size(142, 20);
      this.lblMileageLastService.TabIndex = 68;
      this.lblMileageLastService.Text = "Mileage at Last Service";
      this.btnNextService.Location = new System.Drawing.Point(328, 56);
      this.btnNextService.Name = "btnNextService";
      this.btnNextService.Size = new Size(270, 21);
      this.btnNextService.TabIndex = 12;
      this.btnNextService.Text = "Calculate Next Service";
      this.btnNextService.UseVisualStyleBackColor = true;
      this.dtpTaxExpiry.Location = new System.Drawing.Point(120, 138);
      this.dtpTaxExpiry.Name = "dtpTaxExpiry";
      this.dtpTaxExpiry.Size = new Size(138, 21);
      this.dtpTaxExpiry.TabIndex = 15;
      this.dtpTaxExpiry.Tag = (object) "Van.InsuranceDue";
      this.lblRoadTax.Location = new System.Drawing.Point(9, 144);
      this.lblRoadTax.Name = "lblRoadTax";
      this.lblRoadTax.Size = new Size(84, 20);
      this.lblRoadTax.TabIndex = 65;
      this.lblRoadTax.Text = "Tax Expiry";
      this.dtpNextServiceDate.Location = new System.Drawing.Point(120, 54);
      this.dtpNextServiceDate.Name = "dtpNextServiceDate";
      this.dtpNextServiceDate.Size = new Size(138, 21);
      this.dtpNextServiceDate.TabIndex = 11;
      this.dtpNextServiceDate.Tag = (object) "Van.InsuranceDue";
      this.lblNextServiceDate.Location = new System.Drawing.Point(9, 60);
      this.lblNextServiceDate.Name = "lblNextServiceDate";
      this.lblNextServiceDate.Size = new Size(85, 20);
      this.lblNextServiceDate.TabIndex = 62;
      this.lblNextServiceDate.Text = "Next Service";
      this.dtpLastServiceDate.Location = new System.Drawing.Point(120, 18);
      this.dtpLastServiceDate.Name = "dtpLastServiceDate";
      this.dtpLastServiceDate.Size = new Size(138, 21);
      this.dtpLastServiceDate.TabIndex = 9;
      this.dtpLastServiceDate.Tag = (object) "Van.InsuranceDue";
      this.dtpMOTExpiry.Location = new System.Drawing.Point(120, 99);
      this.dtpMOTExpiry.Name = "dtpMOTExpiry";
      this.dtpMOTExpiry.Size = new Size(138, 21);
      this.dtpMOTExpiry.TabIndex = 13;
      this.dtpMOTExpiry.Tag = (object) "Van.InsuranceDue";
      this.lblMOT.Location = new System.Drawing.Point(9, 105);
      this.lblMOT.Name = "lblMOT";
      this.lblMOT.Size = new Size(84, 20);
      this.lblMOT.TabIndex = 58;
      this.lblMOT.Text = "MOT Expiry";
      this.txtBreakdown.Location = new System.Drawing.Point(457, 97);
      this.txtBreakdown.Name = "txtBreakdown";
      this.txtBreakdown.Size = new Size(141, 21);
      this.txtBreakdown.TabIndex = 16;
      this.txtBreakdown.Tag = (object) " ";
      this.lblBreakdownCompany.Location = new System.Drawing.Point(325, 100);
      this.lblBreakdownCompany.Name = "lblBreakdownCompany";
      this.lblBreakdownCompany.Size = new Size(105, 20);
      this.lblBreakdownCompany.TabIndex = 53;
      this.lblBreakdownCompany.Text = "Breakdown";
      this.lblLastService.Location = new System.Drawing.Point(8, 24);
      this.lblLastService.Name = "lblLastService";
      this.lblLastService.Size = new Size(85, 20);
      this.lblLastService.TabIndex = 31;
      this.lblLastService.Text = "Last Service";
      this.grpEngineer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpEngineer.Controls.Add((Control) this.cboDepartment);
      this.grpEngineer.Controls.Add((Control) this.chkEndDate);
      this.grpEngineer.Controls.Add((Control) this.dtpEndDate);
      this.grpEngineer.Controls.Add((Control) this.btnRemove);
      this.grpEngineer.Controls.Add((Control) this.dtpStartDate);
      this.grpEngineer.Controls.Add((Control) this.lblStartDate);
      this.grpEngineer.Controls.Add((Control) this.lblDepartment);
      this.grpEngineer.Controls.Add((Control) this.btnfindEngineer);
      this.grpEngineer.Controls.Add((Control) this.txtEngineer);
      this.grpEngineer.Controls.Add((Control) this.lblEngineer);
      this.grpEngineer.Location = new System.Drawing.Point(8, 524);
      this.grpEngineer.Name = "grpEngineer";
      this.grpEngineer.Size = new Size(664, 152);
      this.grpEngineer.TabIndex = 45;
      this.grpEngineer.TabStop = false;
      this.grpEngineer.Text = "Engineer";
      this.cboDepartment.Cursor = Cursors.Hand;
      this.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDepartment.Location = new System.Drawing.Point(120, 52);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(146, 21);
      this.cboDepartment.TabIndex = 50;
      this.cboDepartment.Tag = (object) "";
      this.chkEndDate.AutoSize = true;
      this.chkEndDate.BackColor = SystemColors.Control;
      this.chkEndDate.Location = new System.Drawing.Point(328, 89);
      this.chkEndDate.Name = "chkEndDate";
      this.chkEndDate.Size = new Size(78, 17);
      this.chkEndDate.TabIndex = 65;
      this.chkEndDate.Text = "End Date";
      this.chkEndDate.UseVisualStyleBackColor = false;
      this.dtpEndDate.Enabled = false;
      this.dtpEndDate.Location = new System.Drawing.Point(421, 85);
      this.dtpEndDate.Name = "dtpEndDate";
      this.dtpEndDate.Size = new Size(138, 21);
      this.dtpEndDate.TabIndex = 63;
      this.btnRemove.Location = new System.Drawing.Point(489, 17);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(75, 23);
      this.btnRemove.TabIndex = 62;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.dtpStartDate.Location = new System.Drawing.Point(120, 84);
      this.dtpStartDate.Name = "dtpStartDate";
      this.dtpStartDate.Size = new Size(138, 21);
      this.dtpStartDate.TabIndex = 21;
      this.lblStartDate.Location = new System.Drawing.Point(9, 90);
      this.lblStartDate.Name = "lblStartDate";
      this.lblStartDate.Size = new Size(84, 20);
      this.lblStartDate.TabIndex = 58;
      this.lblStartDate.Text = "Start Date";
      this.lblDepartment.Location = new System.Drawing.Point(9, 55);
      this.lblDepartment.Name = "lblDepartment";
      this.lblDepartment.Size = new Size(104, 20);
      this.lblDepartment.TabIndex = 55;
      this.lblDepartment.Text = "Department";
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(337, 19);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 18;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(120, 19);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(201, 21);
      this.txtEngineer.TabIndex = 17;
      this.lblEngineer.Location = new System.Drawing.Point(8, 24);
      this.lblEngineer.Name = "lblEngineer";
      this.lblEngineer.Size = new Size(85, 20);
      this.lblEngineer.TabIndex = 31;
      this.lblEngineer.Text = "Engineer";
      this.grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpVan.Controls.Add((Control) this.txtTyreSize);
      this.grpVan.Controls.Add((Control) this.lblTyresSize);
      this.grpVan.Controls.Add((Control) this.btnRemoveEquipment);
      this.grpVan.Controls.Add((Control) this.btnAddEquipment);
      this.grpVan.Controls.Add((Control) this.dgEquipment);
      this.grpVan.Controls.Add((Control) this.chkReturned);
      this.grpVan.Controls.Add((Control) this.lblReturned);
      this.grpVan.Controls.Add((Control) this.txtAverageMileage);
      this.grpVan.Controls.Add((Control) this.lblAverageMileage);
      this.grpVan.Controls.Add((Control) this.txtMileage);
      this.grpVan.Controls.Add((Control) this.lblMileage);
      this.grpVan.Controls.Add((Control) this.txtModel);
      this.grpVan.Controls.Add((Control) this.lblMdoel);
      this.grpVan.Controls.Add((Control) this.cboVanType);
      this.grpVan.Controls.Add((Control) this.txtMake);
      this.grpVan.Controls.Add((Control) this.txtRegistration);
      this.grpVan.Controls.Add((Control) this.lblRegistration);
      this.grpVan.Controls.Add((Control) this.txtNotes);
      this.grpVan.Controls.Add((Control) this.lblNotes);
      this.grpVan.Controls.Add((Control) this.lblInsuranceDue);
      this.grpVan.Controls.Add((Control) this.lblMake);
      this.grpVan.Location = new System.Drawing.Point(8, 8);
      this.grpVan.Name = "grpVan";
      this.grpVan.Size = new Size(664, 288);
      this.grpVan.TabIndex = 2;
      this.grpVan.TabStop = false;
      this.grpVan.Text = "Details";
      this.txtTyreSize.Location = new System.Drawing.Point(477, 160);
      this.txtTyreSize.MaxLength = 10;
      this.txtTyreSize.Name = "txtTyreSize";
      this.txtTyreSize.Size = new Size(161, 21);
      this.txtTyreSize.TabIndex = 48;
      this.lblTyresSize.Location = new System.Drawing.Point(363, 163);
      this.lblTyresSize.Name = "lblTyresSize";
      this.lblTyresSize.Size = new Size(81, 20);
      this.lblTyresSize.TabIndex = 49;
      this.lblTyresSize.Text = "Tyre Size";
      this.btnRemoveEquipment.Location = new System.Drawing.Point(367, 121);
      this.btnRemoveEquipment.Name = "btnRemoveEquipment";
      this.btnRemoveEquipment.Size = new Size(75, 23);
      this.btnRemoveEquipment.TabIndex = 46;
      this.btnRemoveEquipment.Text = "Remove";
      this.btnRemoveEquipment.UseVisualStyleBackColor = true;
      this.btnAddEquipment.Location = new System.Drawing.Point(563, 121);
      this.btnAddEquipment.Name = "btnAddEquipment";
      this.btnAddEquipment.Size = new Size(75, 23);
      this.btnAddEquipment.TabIndex = 47;
      this.btnAddEquipment.Text = "Add";
      this.btnAddEquipment.UseVisualStyleBackColor = true;
      this.dgEquipment.DataMember = "";
      this.dgEquipment.HeaderForeColor = SystemColors.ControlText;
      this.dgEquipment.Location = new System.Drawing.Point(367, 10);
      this.dgEquipment.Name = "dgEquipment";
      this.dgEquipment.Size = new Size(271, 103);
      this.dgEquipment.TabIndex = 44;
      this.chkReturned.AutoSize = true;
      this.chkReturned.BackColor = SystemColors.Control;
      this.chkReturned.Location = new System.Drawing.Point(478, 194);
      this.chkReturned.Name = "chkReturned";
      this.chkReturned.Size = new Size(34, 17);
      this.chkReturned.TabIndex = 7;
      this.chkReturned.Text = "  ";
      this.chkReturned.UseVisualStyleBackColor = false;
      this.lblReturned.Location = new System.Drawing.Point(364, 195);
      this.lblReturned.Name = "lblReturned";
      this.lblReturned.Size = new Size(81, 20);
      this.lblReturned.TabIndex = 43;
      this.lblReturned.Text = "Returned";
      this.txtAverageMileage.Enabled = false;
      this.txtAverageMileage.Location = new System.Drawing.Point(120, 195);
      this.txtAverageMileage.MaxLength = 10;
      this.txtAverageMileage.Name = "txtAverageMileage";
      this.txtAverageMileage.Size = new Size(146, 21);
      this.txtAverageMileage.TabIndex = 6;
      this.lblAverageMileage.Location = new System.Drawing.Point(6, 198);
      this.lblAverageMileage.Name = "lblAverageMileage";
      this.lblAverageMileage.Size = new Size(112, 20);
      this.lblAverageMileage.TabIndex = 42;
      this.lblAverageMileage.Text = "Average Mileage";
      this.txtMileage.Location = new System.Drawing.Point(120, 160);
      this.txtMileage.MaxLength = 10;
      this.txtMileage.Name = "txtMileage";
      this.txtMileage.Size = new Size(146, 21);
      this.txtMileage.TabIndex = 5;
      this.lblMileage.Location = new System.Drawing.Point(6, 163);
      this.lblMileage.Name = "lblMileage";
      this.lblMileage.Size = new Size(81, 20);
      this.lblMileage.TabIndex = 40;
      this.lblMileage.Text = "Mileage";
      this.txtModel.Enabled = false;
      this.txtModel.Location = new System.Drawing.Point(120, 125);
      this.txtModel.MaxLength = 10;
      this.txtModel.Name = "txtModel";
      this.txtModel.Size = new Size(146, 21);
      this.txtModel.TabIndex = 4;
      this.lblMdoel.Location = new System.Drawing.Point(6, 128);
      this.lblMdoel.Name = "lblMdoel";
      this.lblMdoel.Size = new Size(81, 20);
      this.lblMdoel.TabIndex = 38;
      this.lblMdoel.Text = "Model";
      this.cboVanType.Cursor = Cursors.Hand;
      this.cboVanType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVanType.Location = new System.Drawing.Point(120, 55);
      this.cboVanType.Name = "cboVanType";
      this.cboVanType.Size = new Size(146, 21);
      this.cboVanType.TabIndex = 2;
      this.cboVanType.Tag = (object) "";
      this.txtMake.Enabled = false;
      this.txtMake.Location = new System.Drawing.Point(120, 90);
      this.txtMake.MaxLength = 10;
      this.txtMake.Name = "txtMake";
      this.txtMake.Size = new Size(146, 21);
      this.txtMake.TabIndex = 3;
      this.txtRegistration.Location = new System.Drawing.Point(120, 20);
      this.txtRegistration.MaxLength = 20;
      this.txtRegistration.Name = "txtRegistration";
      this.txtRegistration.Size = new Size(146, 21);
      this.txtRegistration.TabIndex = 1;
      this.lblRegistration.Location = new System.Drawing.Point(6, 23);
      this.lblRegistration.Name = "lblRegistration";
      this.lblRegistration.Size = new Size(85, 20);
      this.lblRegistration.TabIndex = 31;
      this.lblRegistration.Text = "Registration";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(120, 231);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(518, 37);
      this.txtNotes.TabIndex = 8;
      this.txtNotes.Tag = (object) "Van.Notes";
      this.lblNotes.Location = new System.Drawing.Point(6, 234);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(53, 20);
      this.lblNotes.TabIndex = 31;
      this.lblNotes.Text = "Notes";
      this.lblInsuranceDue.Location = new System.Drawing.Point(6, 58);
      this.lblInsuranceDue.Name = "lblInsuranceDue";
      this.lblInsuranceDue.Size = new Size(96, 20);
      this.lblInsuranceDue.TabIndex = 31;
      this.lblInsuranceDue.Text = "Van Type";
      this.lblMake.Location = new System.Drawing.Point(6, 93);
      this.lblMake.Name = "lblMake";
      this.lblMake.Size = new Size(81, 20);
      this.lblMake.TabIndex = 31;
      this.lblMake.Text = "Make";
      this.tcVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcVans.Controls.Add((Control) this.tabDetails);
      this.tcVans.Controls.Add((Control) this.tabFaults);
      this.tcVans.Controls.Add((Control) this.tabContract);
      this.tcVans.Controls.Add((Control) this.tabEngineerHistory);
      this.tcVans.Controls.Add((Control) this.tabServiceHistory);
      this.tcVans.Controls.Add((Control) this.tabHistory);
      this.tcVans.Controls.Add((Control) this.tabDocuments);
      this.tcVans.Location = new System.Drawing.Point(4, 7);
      this.tcVans.Name = "tcVans";
      this.tcVans.SelectedIndex = 0;
      this.tcVans.Size = new Size(683, 728);
      this.tcVans.TabIndex = 0;
      this.tabFaults.BackColor = SystemColors.Control;
      this.tabFaults.Controls.Add((Control) this.chkHideArchive);
      this.tabFaults.Controls.Add((Control) this.grpFaultDetails);
      this.tabFaults.Controls.Add((Control) this.grpVanFaultDg);
      this.tabFaults.Location = new System.Drawing.Point(4, 22);
      this.tabFaults.Name = "tabFaults";
      this.tabFaults.Size = new Size(675, 702);
      this.tabFaults.TabIndex = 2;
      this.tabFaults.Text = "Faults";
      this.chkHideArchive.AutoSize = true;
      this.chkHideArchive.Checked = true;
      this.chkHideArchive.CheckState = CheckState.Checked;
      this.chkHideArchive.Location = new System.Drawing.Point(573, 390);
      this.chkHideArchive.Name = "chkHideArchive";
      this.chkHideArchive.Size = new Size(98, 17);
      this.chkHideArchive.TabIndex = 78;
      this.chkHideArchive.Text = "Hide Archive";
      this.chkHideArchive.UseVisualStyleBackColor = true;
      this.grpFaultDetails.Controls.Add((Control) this.chkArchive);
      this.grpFaultDetails.Controls.Add((Control) this.txtAdditionalNotes);
      this.grpFaultDetails.Controls.Add((Control) this.lblAddNotes);
      this.grpFaultDetails.Controls.Add((Control) this.txtOutcome);
      this.grpFaultDetails.Controls.Add((Control) this.lblOutcome);
      this.grpFaultDetails.Controls.Add((Control) this.txtStatus);
      this.grpFaultDetails.Controls.Add((Control) this.lblVisitStatus);
      this.grpFaultDetails.Controls.Add((Control) this.txtScheduled);
      this.grpFaultDetails.Controls.Add((Control) this.lblScheduled);
      this.grpFaultDetails.Controls.Add((Control) this.txtJobRef);
      this.grpFaultDetails.Controls.Add((Control) this.lblJobRef);
      this.grpFaultDetails.Controls.Add((Control) this.btnNewFault);
      this.grpFaultDetails.Controls.Add((Control) this.btnSaveFault);
      this.grpFaultDetails.Controls.Add((Control) this.chkResolved);
      this.grpFaultDetails.Controls.Add((Control) this.dtpResolvedDate);
      this.grpFaultDetails.Controls.Add((Control) this.lblResolvedDate);
      this.grpFaultDetails.Controls.Add((Control) this.dtpFaultDate);
      this.grpFaultDetails.Controls.Add((Control) this.lblFaultDate);
      this.grpFaultDetails.Controls.Add((Control) this.txtFaultNotes);
      this.grpFaultDetails.Controls.Add((Control) this.lblFaultNotes);
      this.grpFaultDetails.Controls.Add((Control) this.cboFaultType);
      this.grpFaultDetails.Controls.Add((Control) this.txtEngineerFaultNotes);
      this.grpFaultDetails.Controls.Add((Control) this.lblEngineerNotes);
      this.grpFaultDetails.Controls.Add((Control) this.lblFaultType);
      this.grpFaultDetails.Location = new System.Drawing.Point(7, 7);
      this.grpFaultDetails.Name = "grpFaultDetails";
      this.grpFaultDetails.Size = new Size(664, 375);
      this.grpFaultDetails.TabIndex = 16;
      this.grpFaultDetails.TabStop = false;
      this.grpFaultDetails.Text = "Fault Details";
      this.chkArchive.AutoSize = true;
      this.chkArchive.Location = new System.Drawing.Point(589, 137);
      this.chkArchive.Name = "chkArchive";
      this.chkArchive.Size = new Size(69, 17);
      this.chkArchive.TabIndex = 77;
      this.chkArchive.Text = "Archive";
      this.chkArchive.UseVisualStyleBackColor = true;
      this.txtAdditionalNotes.Location = new System.Drawing.Point(112, 267);
      this.txtAdditionalNotes.Multiline = true;
      this.txtAdditionalNotes.Name = "txtAdditionalNotes";
      this.txtAdditionalNotes.ScrollBars = ScrollBars.Vertical;
      this.txtAdditionalNotes.Size = new Size(546, 62);
      this.txtAdditionalNotes.TabIndex = 75;
      this.txtAdditionalNotes.Tag = (object) "";
      this.lblAddNotes.Location = new System.Drawing.Point(9, 270);
      this.lblAddNotes.Name = "lblAddNotes";
      this.lblAddNotes.Size = new Size(103, 20);
      this.lblAddNotes.TabIndex = 76;
      this.lblAddNotes.Text = "Additional Notes";
      this.txtOutcome.Location = new System.Drawing.Point(401, 168);
      this.txtOutcome.Name = "txtOutcome";
      this.txtOutcome.ReadOnly = true;
      this.txtOutcome.Size = new Size(146, 21);
      this.txtOutcome.TabIndex = 74;
      this.lblOutcome.Location = new System.Drawing.Point(298, 171);
      this.lblOutcome.Name = "lblOutcome";
      this.lblOutcome.Size = new Size(95, 20);
      this.lblOutcome.TabIndex = 73;
      this.lblOutcome.Text = "Outcome";
      this.txtStatus.Location = new System.Drawing.Point(112, 168);
      this.txtStatus.Name = "txtStatus";
      this.txtStatus.ReadOnly = true;
      this.txtStatus.Size = new Size(146, 21);
      this.txtStatus.TabIndex = 72;
      this.lblVisitStatus.Location = new System.Drawing.Point(9, 171);
      this.lblVisitStatus.Name = "lblVisitStatus";
      this.lblVisitStatus.Size = new Size(95, 20);
      this.lblVisitStatus.TabIndex = 71;
      this.lblVisitStatus.Text = "Visit Status";
      this.txtScheduled.Location = new System.Drawing.Point(401, 135);
      this.txtScheduled.Name = "txtScheduled";
      this.txtScheduled.ReadOnly = true;
      this.txtScheduled.Size = new Size(146, 21);
      this.txtScheduled.TabIndex = 70;
      this.lblScheduled.Location = new System.Drawing.Point(298, 138);
      this.lblScheduled.Name = "lblScheduled";
      this.lblScheduled.Size = new Size(95, 20);
      this.lblScheduled.TabIndex = 69;
      this.lblScheduled.Text = "Scheduled";
      this.txtJobRef.Location = new System.Drawing.Point(112, 135);
      this.txtJobRef.Name = "txtJobRef";
      this.txtJobRef.ReadOnly = true;
      this.txtJobRef.Size = new Size(146, 21);
      this.txtJobRef.TabIndex = 68;
      this.lblJobRef.Location = new System.Drawing.Point(9, 138);
      this.lblJobRef.Name = "lblJobRef";
      this.lblJobRef.Size = new Size(95, 20);
      this.lblJobRef.TabIndex = 67;
      this.lblJobRef.Text = "Job Reference";
      this.btnNewFault.Location = new System.Drawing.Point(13, 338);
      this.btnNewFault.Name = "btnNewFault";
      this.btnNewFault.Size = new Size(75, 23);
      this.btnNewFault.TabIndex = 7;
      this.btnNewFault.Text = "New";
      this.btnNewFault.UseVisualStyleBackColor = true;
      this.chkResolved.AutoSize = true;
      this.chkResolved.Location = new System.Drawing.Point(300, 99);
      this.chkResolved.Name = "chkResolved";
      this.chkResolved.Size = new Size(78, 17);
      this.chkResolved.TabIndex = 4;
      this.chkResolved.Text = "Resolved";
      this.chkResolved.UseVisualStyleBackColor = true;
      this.dtpResolvedDate.Enabled = false;
      this.dtpResolvedDate.Location = new System.Drawing.Point(112, 96);
      this.dtpResolvedDate.Name = "dtpResolvedDate";
      this.dtpResolvedDate.Size = new Size(146, 21);
      this.dtpResolvedDate.TabIndex = 3;
      this.dtpResolvedDate.Tag = (object) "";
      this.lblResolvedDate.Location = new System.Drawing.Point(9, 102);
      this.lblResolvedDate.Name = "lblResolvedDate";
      this.lblResolvedDate.Size = new Size(95, 20);
      this.lblResolvedDate.TabIndex = 66;
      this.lblResolvedDate.Text = "Resolved Date";
      this.dtpFaultDate.Location = new System.Drawing.Point(112, 60);
      this.dtpFaultDate.Name = "dtpFaultDate";
      this.dtpFaultDate.Size = new Size(146, 21);
      this.dtpFaultDate.TabIndex = 2;
      this.dtpFaultDate.Tag = (object) "";
      this.lblFaultDate.Location = new System.Drawing.Point(8, 66);
      this.lblFaultDate.Name = "lblFaultDate";
      this.lblFaultDate.Size = new Size(85, 20);
      this.lblFaultDate.TabIndex = 65;
      this.lblFaultDate.Text = "Fault Date";
      this.txtFaultNotes.Location = new System.Drawing.Point(112, 202);
      this.txtFaultNotes.Multiline = true;
      this.txtFaultNotes.Name = "txtFaultNotes";
      this.txtFaultNotes.ReadOnly = true;
      this.txtFaultNotes.ScrollBars = ScrollBars.Vertical;
      this.txtFaultNotes.Size = new Size(546, 52);
      this.txtFaultNotes.TabIndex = 6;
      this.txtFaultNotes.Tag = (object) "";
      this.lblFaultNotes.Location = new System.Drawing.Point(10, 205);
      this.lblFaultNotes.Name = "lblFaultNotes";
      this.lblFaultNotes.Size = new Size(96, 20);
      this.lblFaultNotes.TabIndex = 45;
      this.lblFaultNotes.Text = "Notes";
      this.cboFaultType.Cursor = Cursors.Hand;
      this.cboFaultType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFaultType.Location = new System.Drawing.Point(112, 27);
      this.cboFaultType.Name = "cboFaultType";
      this.cboFaultType.Size = new Size(146, 21);
      this.cboFaultType.TabIndex = 1;
      this.cboFaultType.Tag = (object) "";
      this.txtEngineerFaultNotes.Location = new System.Drawing.Point(401, 27);
      this.txtEngineerFaultNotes.Multiline = true;
      this.txtEngineerFaultNotes.Name = "txtEngineerFaultNotes";
      this.txtEngineerFaultNotes.ScrollBars = ScrollBars.Vertical;
      this.txtEngineerFaultNotes.Size = new Size(257, 95);
      this.txtEngineerFaultNotes.TabIndex = 5;
      this.txtEngineerFaultNotes.Tag = (object) "";
      this.lblEngineerNotes.Location = new System.Drawing.Point(297, 30);
      this.lblEngineerNotes.Name = "lblEngineerNotes";
      this.lblEngineerNotes.Size = new Size(98, 20);
      this.lblEngineerNotes.TabIndex = 31;
      this.lblEngineerNotes.Text = "Engineer Notes";
      this.lblFaultType.Location = new System.Drawing.Point(8, 30);
      this.lblFaultType.Name = "lblFaultType";
      this.lblFaultType.Size = new Size(96, 20);
      this.lblFaultType.TabIndex = 31;
      this.lblFaultType.Text = "Fault Type";
      this.grpVanFaultDg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpVanFaultDg.Controls.Add((Control) this.dgVanFaults);
      this.grpVanFaultDg.Location = new System.Drawing.Point(11, 413);
      this.grpVanFaultDg.Name = "grpVanFaultDg";
      this.grpVanFaultDg.Size = new Size(664, 287);
      this.grpVanFaultDg.TabIndex = 5;
      this.grpVanFaultDg.TabStop = false;
      this.grpVanFaultDg.Text = "Van Fault History (Double click to view)";
      this.dgVanFaults.DataMember = "";
      this.dgVanFaults.Dock = DockStyle.Fill;
      this.dgVanFaults.HeaderForeColor = SystemColors.ControlText;
      this.dgVanFaults.Location = new System.Drawing.Point(3, 17);
      this.dgVanFaults.Name = "dgVanFaults";
      this.dgVanFaults.Size = new Size(658, 267);
      this.dgVanFaults.TabIndex = 15;
      this.tabContract.BackColor = SystemColors.Control;
      this.tabContract.Controls.Add((Control) this.grpFinances);
      this.tabContract.Controls.Add((Control) this.grpContractDetails);
      this.tabContract.Location = new System.Drawing.Point(4, 22);
      this.tabContract.Name = "tabContract";
      this.tabContract.Size = new Size(675, 702);
      this.tabContract.TabIndex = 3;
      this.tabContract.Text = "Contract";
      this.grpFinances.Controls.Add((Control) this.txtForecastExcessCost);
      this.grpFinances.Controls.Add((Control) this.lblForcastedExcessCost);
      this.grpFinances.Controls.Add((Control) this.txtExcessMileageCost);
      this.grpFinances.Controls.Add((Control) this.lblExcessCost);
      this.grpFinances.Controls.Add((Control) this.txtAnnualRental);
      this.grpFinances.Controls.Add((Control) this.txtMonthlyRental);
      this.grpFinances.Controls.Add((Control) this.lblMonthlyRental);
      this.grpFinances.Controls.Add((Control) this.lblAnnualRental);
      this.grpFinances.Controls.Add((Control) this.txtWeeklyRental);
      this.grpFinances.Controls.Add((Control) this.txtExcessMileageRate);
      this.grpFinances.Controls.Add((Control) this.lblExcessMileageRate);
      this.grpFinances.Controls.Add((Control) this.lblWeeklyRental);
      this.grpFinances.Location = new System.Drawing.Point(8, 294);
      this.grpFinances.Name = "grpFinances";
      this.grpFinances.Size = new Size(664, 138);
      this.grpFinances.TabIndex = 75;
      this.grpFinances.TabStop = false;
      this.grpFinances.Text = "Finances";
      this.txtForecastExcessCost.Enabled = false;
      this.txtForecastExcessCost.Location = new System.Drawing.Point(498, 99);
      this.txtForecastExcessCost.MaxLength = 10;
      this.txtForecastExcessCost.Name = "txtForecastExcessCost";
      this.txtForecastExcessCost.Size = new Size(146, 21);
      this.txtForecastExcessCost.TabIndex = 75;
      this.lblForcastedExcessCost.Location = new System.Drawing.Point(347, 102);
      this.lblForcastedExcessCost.Name = "lblForcastedExcessCost";
      this.lblForcastedExcessCost.Size = new Size(145, 20);
      this.lblForcastedExcessCost.TabIndex = 76;
      this.lblForcastedExcessCost.Text = "Forecast Excess Cost";
      this.txtExcessMileageCost.Enabled = false;
      this.txtExcessMileageCost.Location = new System.Drawing.Point(159, 99);
      this.txtExcessMileageCost.MaxLength = 10;
      this.txtExcessMileageCost.Name = "txtExcessMileageCost";
      this.txtExcessMileageCost.Size = new Size(146, 21);
      this.txtExcessMileageCost.TabIndex = 73;
      this.lblExcessCost.Location = new System.Drawing.Point(8, 102);
      this.lblExcessCost.Name = "lblExcessCost";
      this.lblExcessCost.Size = new Size(126, 20);
      this.lblExcessCost.TabIndex = 74;
      this.lblExcessCost.Text = "Excess Mileage Cost";
      this.txtAnnualRental.Location = new System.Drawing.Point(498, 60);
      this.txtAnnualRental.MaxLength = 10;
      this.txtAnnualRental.Name = "txtAnnualRental";
      this.txtAnnualRental.Size = new Size(146, 21);
      this.txtAnnualRental.TabIndex = 12;
      this.txtMonthlyRental.Location = new System.Drawing.Point(159, 60);
      this.txtMonthlyRental.MaxLength = 10;
      this.txtMonthlyRental.Name = "txtMonthlyRental";
      this.txtMonthlyRental.Size = new Size(146, 21);
      this.txtMonthlyRental.TabIndex = 11;
      this.lblMonthlyRental.Location = new System.Drawing.Point(8, 63);
      this.lblMonthlyRental.Name = "lblMonthlyRental";
      this.lblMonthlyRental.Size = new Size(126, 20);
      this.lblMonthlyRental.TabIndex = 72;
      this.lblMonthlyRental.Text = "Monthly Rental";
      this.lblAnnualRental.Location = new System.Drawing.Point(347, 63);
      this.lblAnnualRental.Name = "lblAnnualRental";
      this.lblAnnualRental.Size = new Size(126, 20);
      this.lblAnnualRental.TabIndex = 69;
      this.lblAnnualRental.Text = "Annual Rental";
      this.txtWeeklyRental.Location = new System.Drawing.Point(498, 20);
      this.txtWeeklyRental.MaxLength = 10;
      this.txtWeeklyRental.Name = "txtWeeklyRental";
      this.txtWeeklyRental.Size = new Size(146, 21);
      this.txtWeeklyRental.TabIndex = 10;
      this.txtExcessMileageRate.Location = new System.Drawing.Point(159, 20);
      this.txtExcessMileageRate.MaxLength = 20;
      this.txtExcessMileageRate.Name = "txtExcessMileageRate";
      this.txtExcessMileageRate.Size = new Size(146, 21);
      this.txtExcessMileageRate.TabIndex = 9;
      this.lblExcessMileageRate.Location = new System.Drawing.Point(8, 24);
      this.lblExcessMileageRate.Name = "lblExcessMileageRate";
      this.lblExcessMileageRate.Size = new Size(126, 20);
      this.lblExcessMileageRate.TabIndex = 31;
      this.lblExcessMileageRate.Text = "Excess Mileage Rate";
      this.lblWeeklyRental.Location = new System.Drawing.Point(347, 23);
      this.lblWeeklyRental.Name = "lblWeeklyRental";
      this.lblWeeklyRental.Size = new Size(100, 20);
      this.lblWeeklyRental.TabIndex = 31;
      this.lblWeeklyRental.Text = "Weekly Rental";
      this.grpContractDetails.Controls.Add((Control) this.btnRemoveContractEndDate);
      this.grpContractDetails.Controls.Add((Control) this.txtStartingMileage);
      this.grpContractDetails.Controls.Add((Control) this.lblStartingMileage);
      this.grpContractDetails.Controls.Add((Control) this.btnEndContract);
      this.grpContractDetails.Controls.Add((Control) this.txtContractNotes);
      this.grpContractDetails.Controls.Add((Control) this.lblContractNotes);
      this.grpContractDetails.Controls.Add((Control) this.txtAgreementRef);
      this.grpContractDetails.Controls.Add((Control) this.lblAgreementRef);
      this.grpContractDetails.Controls.Add((Control) this.txtContractMileage);
      this.grpContractDetails.Controls.Add((Control) this.lblContractMileage);
      this.grpContractDetails.Controls.Add((Control) this.dtpContractEnd);
      this.grpContractDetails.Controls.Add((Control) this.lblContractEnd);
      this.grpContractDetails.Controls.Add((Control) this.dtpContractStart);
      this.grpContractDetails.Controls.Add((Control) this.lblContractStart);
      this.grpContractDetails.Controls.Add((Control) this.cboProcurementMethod);
      this.grpContractDetails.Controls.Add((Control) this.txtContractLength);
      this.grpContractDetails.Controls.Add((Control) this.txtLessor);
      this.grpContractDetails.Controls.Add((Control) this.lblLessor);
      this.grpContractDetails.Controls.Add((Control) this.lblProcurementMethod);
      this.grpContractDetails.Controls.Add((Control) this.lblContractLength);
      this.grpContractDetails.Location = new System.Drawing.Point(8, 3);
      this.grpContractDetails.Name = "grpContractDetails";
      this.grpContractDetails.Size = new Size(664, 285);
      this.grpContractDetails.TabIndex = 3;
      this.grpContractDetails.TabStop = false;
      this.grpContractDetails.Text = "Details";
      this.btnRemoveContractEndDate.Location = new System.Drawing.Point(433, 100);
      this.btnRemoveContractEndDate.Name = "btnRemoveContractEndDate";
      this.btnRemoveContractEndDate.Size = new Size(24, 23);
      this.btnRemoveContractEndDate.TabIndex = 80;
      this.btnRemoveContractEndDate.Text = "X";
      this.btnRemoveContractEndDate.UseVisualStyleBackColor = true;
      this.btnRemoveContractEndDate.Visible = false;
      this.txtStartingMileage.Location = new System.Drawing.Point(498, 142);
      this.txtStartingMileage.MaxLength = 10;
      this.txtStartingMileage.Name = "txtStartingMileage";
      this.txtStartingMileage.Size = new Size(146, 21);
      this.txtStartingMileage.TabIndex = 78;
      this.lblStartingMileage.Location = new System.Drawing.Point(347, 145);
      this.lblStartingMileage.Name = "lblStartingMileage";
      this.lblStartingMileage.Size = new Size(126, 20);
      this.lblStartingMileage.TabIndex = 79;
      this.lblStartingMileage.Text = "Starting Mileage";
      this.btnEndContract.Location = new System.Drawing.Point(498, 99);
      this.btnEndContract.Name = "btnEndContract";
      this.btnEndContract.Size = new Size(146, 23);
      this.btnEndContract.TabIndex = 77;
      this.btnEndContract.Text = "End Contract";
      this.btnEndContract.UseVisualStyleBackColor = true;
      this.btnEndContract.Visible = false;
      this.txtContractNotes.Location = new System.Drawing.Point(159, 185);
      this.txtContractNotes.Multiline = true;
      this.txtContractNotes.Name = "txtContractNotes";
      this.txtContractNotes.ScrollBars = ScrollBars.Vertical;
      this.txtContractNotes.Size = new Size(485, 75);
      this.txtContractNotes.TabIndex = 8;
      this.txtContractNotes.Tag = (object) "Van.Notes";
      this.lblContractNotes.Location = new System.Drawing.Point(6, 188);
      this.lblContractNotes.Name = "lblContractNotes";
      this.lblContractNotes.Size = new Size(53, 20);
      this.lblContractNotes.TabIndex = 76;
      this.lblContractNotes.Text = "Notes";
      this.txtAgreementRef.Location = new System.Drawing.Point(159, 142);
      this.txtAgreementRef.MaxLength = 10;
      this.txtAgreementRef.Name = "txtAgreementRef";
      this.txtAgreementRef.Size = new Size(146, 21);
      this.txtAgreementRef.TabIndex = 7;
      this.lblAgreementRef.Location = new System.Drawing.Point(8, 145);
      this.lblAgreementRef.Name = "lblAgreementRef";
      this.lblAgreementRef.Size = new Size(100, 20);
      this.lblAgreementRef.TabIndex = 74;
      this.lblAgreementRef.Text = "Agreement Ref";
      this.txtContractMileage.Location = new System.Drawing.Point(498, 62);
      this.txtContractMileage.MaxLength = 10;
      this.txtContractMileage.Name = "txtContractMileage";
      this.txtContractMileage.Size = new Size(146, 21);
      this.txtContractMileage.TabIndex = 4;
      this.lblContractMileage.Location = new System.Drawing.Point(347, 65);
      this.lblContractMileage.Name = "lblContractMileage";
      this.lblContractMileage.Size = new Size(126, 20);
      this.lblContractMileage.TabIndex = 72;
      this.lblContractMileage.Text = "Contract Mileage";
      this.dtpContractEnd.Enabled = false;
      this.dtpContractEnd.Location = new System.Drawing.Point(498, 99);
      this.dtpContractEnd.Name = "dtpContractEnd";
      this.dtpContractEnd.Size = new Size(146, 21);
      this.dtpContractEnd.TabIndex = 6;
      this.dtpContractEnd.Tag = (object) "";
      this.dtpContractEnd.Visible = false;
      this.lblContractEnd.Location = new System.Drawing.Point(347, 105);
      this.lblContractEnd.Name = "lblContractEnd";
      this.lblContractEnd.Size = new Size(95, 20);
      this.lblContractEnd.TabIndex = 70;
      this.lblContractEnd.Text = "Contract End";
      this.lblContractEnd.UseCompatibleTextRendering = true;
      this.dtpContractStart.Location = new System.Drawing.Point(159, 99);
      this.dtpContractStart.Name = "dtpContractStart";
      this.dtpContractStart.Size = new Size(146, 21);
      this.dtpContractStart.TabIndex = 5;
      this.dtpContractStart.Tag = (object) "";
      this.lblContractStart.Location = new System.Drawing.Point(8, 105);
      this.lblContractStart.Name = "lblContractStart";
      this.lblContractStart.Size = new Size(126, 20);
      this.lblContractStart.TabIndex = 69;
      this.lblContractStart.Text = "Contract Start";
      this.cboProcurementMethod.Cursor = Cursors.Hand;
      this.cboProcurementMethod.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboProcurementMethod.Location = new System.Drawing.Point(498, 20);
      this.cboProcurementMethod.Name = "cboProcurementMethod";
      this.cboProcurementMethod.Size = new Size(146, 21);
      this.cboProcurementMethod.TabIndex = 2;
      this.cboProcurementMethod.Tag = (object) "";
      this.txtContractLength.Location = new System.Drawing.Point(159, 59);
      this.txtContractLength.MaxLength = 10;
      this.txtContractLength.Name = "txtContractLength";
      this.txtContractLength.Size = new Size(146, 21);
      this.txtContractLength.TabIndex = 3;
      this.txtLessor.Location = new System.Drawing.Point(159, 20);
      this.txtLessor.MaxLength = 20;
      this.txtLessor.Name = "txtLessor";
      this.txtLessor.Size = new Size(146, 21);
      this.txtLessor.TabIndex = 1;
      this.lblLessor.Location = new System.Drawing.Point(8, 24);
      this.lblLessor.Name = "lblLessor";
      this.lblLessor.Size = new Size(85, 20);
      this.lblLessor.TabIndex = 31;
      this.lblLessor.Text = "Lessor";
      this.lblProcurementMethod.Location = new System.Drawing.Point(347, 23);
      this.lblProcurementMethod.Name = "lblProcurementMethod";
      this.lblProcurementMethod.Size = new Size(126, 20);
      this.lblProcurementMethod.TabIndex = 31;
      this.lblProcurementMethod.Text = "Procurement Method";
      this.lblContractLength.Location = new System.Drawing.Point(8, 62);
      this.lblContractLength.Name = "lblContractLength";
      this.lblContractLength.Size = new Size(100, 20);
      this.lblContractLength.TabIndex = 31;
      this.lblContractLength.Text = "Contract Length";
      this.tabEngineerHistory.Controls.Add((Control) this.grpEngineerHistory);
      this.tabEngineerHistory.Location = new System.Drawing.Point(4, 22);
      this.tabEngineerHistory.Name = "tabEngineerHistory";
      this.tabEngineerHistory.Size = new Size(675, 702);
      this.tabEngineerHistory.TabIndex = 4;
      this.tabEngineerHistory.Text = "Engineer History";
      this.tabEngineerHistory.UseVisualStyleBackColor = true;
      this.grpEngineerHistory.Controls.Add((Control) this.dgEngineerHistory);
      this.grpEngineerHistory.Location = new System.Drawing.Point(5, 6);
      this.grpEngineerHistory.Name = "grpEngineerHistory";
      this.grpEngineerHistory.Size = new Size(664, 801);
      this.grpEngineerHistory.TabIndex = 5;
      this.grpEngineerHistory.TabStop = false;
      this.grpEngineerHistory.Text = "Engineer History";
      this.dgEngineerHistory.DataMember = "";
      this.dgEngineerHistory.Dock = DockStyle.Fill;
      this.dgEngineerHistory.HeaderForeColor = SystemColors.ControlText;
      this.dgEngineerHistory.Location = new System.Drawing.Point(3, 17);
      this.dgEngineerHistory.Name = "dgEngineerHistory";
      this.dgEngineerHistory.Size = new Size(658, 781);
      this.dgEngineerHistory.TabIndex = 15;
      this.tabServiceHistory.Controls.Add((Control) this.gpServiceHistory);
      this.tabServiceHistory.Location = new System.Drawing.Point(4, 22);
      this.tabServiceHistory.Name = "tabServiceHistory";
      this.tabServiceHistory.Size = new Size(675, 702);
      this.tabServiceHistory.TabIndex = 5;
      this.tabServiceHistory.Text = "Service History";
      this.tabServiceHistory.UseVisualStyleBackColor = true;
      this.gpServiceHistory.Controls.Add((Control) this.dgServiceHistory);
      this.gpServiceHistory.Location = new System.Drawing.Point(5, 6);
      this.gpServiceHistory.Name = "gpServiceHistory";
      this.gpServiceHistory.Size = new Size(664, 801);
      this.gpServiceHistory.TabIndex = 6;
      this.gpServiceHistory.TabStop = false;
      this.gpServiceHistory.Text = "Service History";
      this.dgServiceHistory.DataMember = "";
      this.dgServiceHistory.Dock = DockStyle.Fill;
      this.dgServiceHistory.HeaderForeColor = SystemColors.ControlText;
      this.dgServiceHistory.Location = new System.Drawing.Point(3, 17);
      this.dgServiceHistory.Name = "dgServiceHistory";
      this.dgServiceHistory.Size = new Size(658, 781);
      this.dgServiceHistory.TabIndex = 15;
      this.tabDocuments.Location = new System.Drawing.Point(4, 22);
      this.tabDocuments.Name = "tabDocuments";
      this.tabDocuments.Size = new Size(675, 702);
      this.tabDocuments.TabIndex = 6;
      this.tabDocuments.Text = "Documents";
      this.tabDocuments.UseVisualStyleBackColor = true;
      this.btnSaveFault.Location = new System.Drawing.Point(583, 338);
      this.btnSaveFault.Name = "btnSaveFault";
      this.btnSaveFault.Size = new Size(75, 23);
      this.btnSaveFault.TabIndex = 8;
      this.btnSaveFault.Text = "Save";
      this.btnSaveFault.UseVisualStyleBackColor = true;
      this.Controls.Add((Control) this.tcVans);
      this.Name = nameof (UCFleetVan);
      this.Size = new Size(693, 748);
      this.tabHistory.ResumeLayout(false);
      this.grpHistoryDetails.ResumeLayout(false);
      this.grpHistoryDetails.PerformLayout();
      this.grpVanAudit.ResumeLayout(false);
      this.dgVanAudits.EndInit();
      this.tabDetails.ResumeLayout(false);
      this.grpMaintenance.ResumeLayout(false);
      this.grpMaintenance.PerformLayout();
      this.grpEngineer.ResumeLayout(false);
      this.grpEngineer.PerformLayout();
      this.grpVan.ResumeLayout(false);
      this.grpVan.PerformLayout();
      this.dgEquipment.EndInit();
      this.tcVans.ResumeLayout(false);
      this.tabFaults.ResumeLayout(false);
      this.tabFaults.PerformLayout();
      this.grpFaultDetails.ResumeLayout(false);
      this.grpFaultDetails.PerformLayout();
      this.grpVanFaultDg.ResumeLayout(false);
      this.dgVanFaults.EndInit();
      this.tabContract.ResumeLayout(false);
      this.grpFinances.ResumeLayout(false);
      this.grpFinances.PerformLayout();
      this.grpContractDetails.ResumeLayout(false);
      this.grpContractDetails.PerformLayout();
      this.tabEngineerHistory.ResumeLayout(false);
      this.grpEngineerHistory.ResumeLayout(false);
      this.dgEngineerHistory.EndInit();
      this.tabServiceHistory.ResumeLayout(false);
      this.gpServiceHistory.ResumeLayout(false);
      this.dgServiceHistory.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupDGEquipment();
      this.SetupDGFault();
      this.SetupDGEngineerHistory();
      this.SetupDGServiceHistory();
      this.SetupDGAudit();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentVan;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public FleetVan CurrentVan
    {
      get
      {
        return this._currentVan;
      }
      set
      {
        this._currentVan = value;
        if (this._currentVan == null)
          this._currentVan = new FleetVan();
        if (this._currentVan.Exists)
        {
          this.PopulateVanEquipmentDatagrid();
          this.PopulateEngineerHistoryDatagrid();
          this.PopulateVanFaultDatagrid();
          this.PopulateServiceDatagrid();
          this.PopulateVanAuditDatagrid();
          this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblFleetVan, this._currentVan.VanID);
        }
        else
        {
          this.tcVans.TabPages.Remove(this.tabFaults);
          this.tcVans.TabPages.Remove(this.tabEngineerHistory);
          this.tcVans.TabPages.Remove(this.tabServiceHistory);
          this.tcVans.TabPages.Remove(this.tabHistory);
          this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblFleetVan, App.DB.FleetVan.Get_NextVanID());
        }
        this.tabDocuments.Controls.Add((Control) this.DocumentsControl);
      }
    }

    public FleetVanEngineer CurrentVanEngineer
    {
      get
      {
        return this._currentVanEngineer;
      }
      set
      {
        this._currentVanEngineer = value;
        if (this._currentVanEngineer != null)
          return;
        this._currentVanEngineer = new FleetVanEngineer();
        this._currentVanEngineer.Exists = false;
      }
    }

    public FleetVanMaintenance CurrentVanMaintenance
    {
      get
      {
        return this._currentVanMaintenance;
      }
      set
      {
        this._currentVanMaintenance = value;
        if (this._currentVanMaintenance != null)
          return;
        this._currentVanMaintenance = new FleetVanMaintenance();
        this._currentVanMaintenance.Exists = false;
      }
    }

    public FleetVanFault CurrentVanFault
    {
      get
      {
        return this._currentVanFault;
      }
      set
      {
        this._currentVanFault = value;
        if (this._currentVanFault != null)
          return;
        this._currentVanFault = new FleetVanFault();
        this._currentVanFault.Exists = false;
      }
    }

    public FleetVanContract CurrentContract
    {
      get
      {
        return this._currentContract;
      }
      set
      {
        this._currentContract = value;
        if (this._currentContract != null)
          return;
        this._currentContract = new FleetVanContract();
        this._currentContract.Exists = false;
      }
    }

    public Engineer Engineer
    {
      get
      {
        return this._engineer;
      }
      set
      {
        this._engineer = value;
        if (this._engineer != null)
          this.txtEngineer.Text = this.Engineer.Name;
        else
          this.txtEngineer.Text = "<Not Set>";
      }
    }

    private DataView VanEquipmentDataview
    {
      get
      {
        return this._dvVanEquipment;
      }
      set
      {
        this._dvVanEquipment = value;
        this._dvVanEquipment.AllowNew = false;
        this._dvVanEquipment.AllowEdit = false;
        this._dvVanEquipment.AllowDelete = false;
        this._dvVanEquipment.Table.TableName = Enums.TableNames.tblFleetVanEquipment.ToString();
        this.dgEquipment.DataSource = (object) this.VanEquipmentDataview;
      }
    }

    private DataRow SelectedEquipmentDataRow
    {
      get
      {
        return this.dgEquipment.CurrentRowIndex != -1 ? this.VanEquipmentDataview[this.dgEquipment.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView VanFaultDataview
    {
      get
      {
        return this._dvVanFaults;
      }
      set
      {
        this._dvVanFaults = value;
        this._dvVanFaults.AllowNew = false;
        this._dvVanFaults.AllowEdit = false;
        this._dvVanFaults.AllowDelete = false;
        this._dvVanFaults.Table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
        this.dgVanFaults.DataSource = (object) this.VanFaultDataview;
      }
    }

    private DataRow SelectedFaultDataRow
    {
      get
      {
        return this.dgVanFaults.CurrentRowIndex != -1 ? this.VanFaultDataview[this.dgVanFaults.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView EngineerHistoryDataview
    {
      get
      {
        return this._dvEngineerHistory;
      }
      set
      {
        this._dvEngineerHistory = value;
        this._dvEngineerHistory.AllowNew = false;
        this._dvEngineerHistory.AllowEdit = false;
        this._dvEngineerHistory.AllowDelete = false;
        this._dvEngineerHistory.Table.TableName = Enums.TableNames.tblFleetVanEngineer.ToString();
        this.dgEngineerHistory.DataSource = (object) this.EngineerHistoryDataview;
      }
    }

    public DataView ServiceDataView
    {
      get
      {
        return this._jobsTable;
      }
      set
      {
        this._jobsTable = value;
        this._jobsTable.Table.TableName = Enums.TableNames.tblJob.ToString();
        this._jobsTable.AllowNew = false;
        this._jobsTable.AllowEdit = false;
        this._jobsTable.AllowDelete = false;
        this.dgServiceHistory.DataSource = (object) this.ServiceDataView;
      }
    }

    private DataRow SelectedServiceDataRow
    {
      get
      {
        return this.dgServiceHistory.CurrentRowIndex != -1 ? this.ServiceDataView[this.dgServiceHistory.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView VanAuditsDataview
    {
      get
      {
        return this._dvVanAudits;
      }
      set
      {
        this._dvVanAudits = value;
        this._dvVanAudits.AllowNew = false;
        this._dvVanAudits.AllowEdit = false;
        this._dvVanAudits.AllowDelete = false;
        this._dvVanAudits.Table.TableName = Enums.TableNames.tblFleetVanAudit.ToString();
        this.dgVanAudits.DataSource = (object) this.VanAuditsDataview;
      }
    }

    private DataRow SelectedVanHistoryDataRow
    {
      get
      {
        return this.dgVanAudits.CurrentRowIndex != -1 ? this.VanAuditsDataview[this.dgVanAudits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private List<int> EquipmentList
    {
      get
      {
        return this._equipmentList;
      }
      set
      {
        this._equipmentList = value;
      }
    }

    public void SetupDGEquipment()
    {
      DataGridTableStyle tableStyle = this.dgEquipment.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Equipment";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Added On";
      dataGridLabelColumn2.MappingName = "AddedOn";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 137;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblFleetVanEquipment.ToString();
      this.dgEquipment.TableStyles.Add(tableStyle);
    }

    public void SetupDGFault()
    {
      DataGridTableStyle tableStyle = this.dgVanFaults.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Fault";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 120;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Fault Date";
      dataGridLabelColumn2.MappingName = "FaultDate";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Resolved Date";
      dataGridLabelColumn3.MappingName = "ResolvedDate";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Engineer Notes";
      dataGridLabelColumn4.MappingName = "EngineerNotes";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 180;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MM/yyyy";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Last Changed";
      dataGridLabelColumn5.MappingName = "LastChanged";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Changed By";
      dataGridLabelColumn6.MappingName = "Fullname";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      this.dgVanFaults.TableStyles.Add(tableStyle);
    }

    public void SetupDGEngineerHistory()
    {
      DataGridTableStyle tableStyle = this.dgEngineerHistory.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "From";
      dataGridLabelColumn2.MappingName = "StartDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "To";
      dataGridLabelColumn3.MappingName = "EndDateTime";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblFleetVanEngineer.ToString();
      this.dgEngineerHistory.TableStyles.Add(tableStyle);
    }

    public void SetupDGServiceHistory()
    {
      DataGridTableStyle tableStyle = this.dgServiceHistory.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Created";
      dataGridLabelColumn1.MappingName = "DateCreated";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 80;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Job No";
      dataGridLabelColumn2.MappingName = "JobNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 145;
      dataGridLabelColumn3.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Visit Status";
      dataGridLabelColumn4.MappingName = "VisitStatus";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 125;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Outcome";
      dataGridLabelColumn5.MappingName = "VisitOutcome";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 125;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MM/yyyy";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Date";
      dataGridLabelColumn6.MappingName = "LastVisitDate";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJob.ToString();
      this.dgServiceHistory.TableStyles.Add(tableStyle);
    }

    public void SetupDGAudit()
    {
      DataGridTableStyle tableStyle = this.dgVanAudits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Action";
      dataGridLabelColumn1.MappingName = "ActionChange";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 350;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Date";
      dataGridLabelColumn2.MappingName = "ActionDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "User";
      dataGridLabelColumn3.MappingName = "Fullname";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblFleetVanAudit.ToString();
      this.dgVanAudits.TableStyles.Add(tableStyle);
    }

    private void UCFleetVan_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnEngineerHistory_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMEngineerHistory), true, new object[1]
      {
        (object) this.CurrentVan.VanID
      }, false);
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
      {
        this.CurrentVan = App.DB.FleetVan.Get(ID);
        this.CurrentVanEngineer = App.DB.FleetVanEngineer.Get_ByVanID(this.CurrentVan.VanID);
        this.CurrentVanMaintenance = App.DB.FleetVanMaintenance.Get_ByVanID(this.CurrentVan.VanID);
        this.CurrentContract = App.DB.FleetVanContract.Get_ByVanID(this.CurrentVan.VanID);
        this.RunEstimateUpdates();
        this.txtRegistration.Text = this.CurrentVan.Registration;
        ComboBox cboVanType = this.cboVanType;
        Combo.SetSelectedComboItem_By_Value(ref cboVanType, Conversions.ToString(this.CurrentVan.VanTypeID));
        this.cboVanType = cboVanType;
        FleetVanType fleetVanType = App.DB.FleetVanType.Get(this.CurrentVan.VanTypeID);
        if (fleetVanType != null)
        {
          this.txtMake.Text = fleetVanType.Make;
          this.txtModel.Text = fleetVanType.Model;
        }
        this.txtMileage.Text = Conversions.ToString(this.CurrentVan.Mileage);
        this.txtAverageMileage.Text = Conversions.ToString(this.CurrentVan.AverageMileage);
        this.chkReturned.Checked = this.CurrentVan.Returned;
        this.txtNotes.Text = this.CurrentVan.Notes;
        this.txtTyreSize.Text = this.CurrentVan.TyreSize;
        string str = this.CurrentVan.Department;
        if (this.CurrentVanEngineer.Exists)
        {
          this.Engineer = App.DB.Engineer.Engineer_Get(this.CurrentVanEngineer.EngineerID);
          this.txtEngineer.Text = this.Engineer.Name;
          str = this.Engineer.Department.Trim();
          this.dtpStartDate.Value = this.CurrentVanEngineer.StartDate;
        }
        else
          this.txtEngineer.Text = "<Not Set>";
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetSelectedComboItem_By_Value(ref cboDepartment, str);
        this.cboDepartment = cboDepartment;
        if (this.CurrentVanMaintenance.Exists)
        {
          FleetVanMaintenance currentVanMaintenance = this.CurrentVanMaintenance;
          this.dtpLastServiceDate.Value = currentVanMaintenance.LastService;
          this.dtpNextServiceDate.Value = currentVanMaintenance.NextService;
          this.txtLastServiceMileage.Text = Conversions.ToString(currentVanMaintenance.LastServiceMileage);
          this.dtpMOTExpiry.Value = currentVanMaintenance.MOTExpiry;
          this.dtpTaxExpiry.Value = currentVanMaintenance.RoadTaxExpiry;
          this.txtBreakdown.Text = currentVanMaintenance.Breakdown;
          if ((uint) DateTime.Compare(currentVanMaintenance.WarrantyExpiry, DateTime.MinValue) > 0U)
            this.dtpWarrantyExpiry.Value = currentVanMaintenance.WarrantyExpiry;
          if ((uint) DateTime.Compare(currentVanMaintenance.BreakdownExpiry, DateTime.MinValue) > 0U)
            this.dtpBreakdownExpiry.Value = currentVanMaintenance.BreakdownExpiry;
        }
        if (this.CurrentContract.Exists)
        {
          FleetVanContract currentContract = this.CurrentContract;
          this.txtLessor.Text = currentContract.Lessor;
          ComboBox procurementMethod = this.cboProcurementMethod;
          Combo.SetSelectedComboItem_By_Value(ref procurementMethod, Conversions.ToString(currentContract.ProcurementMethod));
          this.cboProcurementMethod = procurementMethod;
          if ((uint) DateTime.Compare(this.CurrentContract.ContractEnd, DateTime.MinValue) > 0U)
          {
            this.dtpContractEnd.Enabled = true;
            this.dtpContractEnd.Visible = true;
            this.btnRemoveContractEndDate.Visible = true;
            this.btnRemoveContractEndDate.Enabled = true;
            this.btnEndContract.Visible = false;
            this.btnEndContract.Enabled = false;
          }
          else if (currentContract.ProcurementMethod != 3)
          {
            this.dtpContractEnd.Enabled = true;
            this.dtpContractEnd.Visible = true;
            this.btnRemoveContractEndDate.Visible = true;
            this.btnRemoveContractEndDate.Enabled = true;
            this.btnEndContract.Visible = false;
            this.btnEndContract.Enabled = false;
          }
          else
          {
            this.dtpContractEnd.Enabled = false;
            this.dtpContractEnd.Visible = false;
            this.btnRemoveContractEndDate.Visible = false;
            this.btnRemoveContractEndDate.Enabled = false;
            this.btnEndContract.Visible = true;
            this.btnEndContract.Enabled = true;
          }
          this.txtContractLength.Text = Conversions.ToString(currentContract.ContractLength);
          this.txtContractMileage.Text = Conversions.ToString(currentContract.ContractMileage);
          this.txtStartingMileage.Text = Conversions.ToString(currentContract.StartingMileage);
          this.dtpContractStart.Value = currentContract.ContractStart;
          if ((uint) DateTime.Compare(currentContract.ContractEnd, DateTime.MinValue) > 0U)
            this.dtpContractEnd.Value = currentContract.ContractEnd;
          this.txtAgreementRef.Text = currentContract.AgreementRef;
          this.txtContractNotes.Text = currentContract.Notes;
          this.txtExcessMileageRate.Text = Conversions.ToString(currentContract.ExcessMileageRate);
          this.txtWeeklyRental.Text = Conversions.ToString(currentContract.WeeklyRental);
          this.txtMonthlyRental.Text = Conversions.ToString(currentContract.MonthlyRental);
          this.txtAnnualRental.Text = Conversions.ToString(currentContract.AnnualRental);
          this.txtExcessMileageCost.Text = Conversions.ToString(currentContract.ExcessMileageCost);
          this.txtForecastExcessCost.Text = Conversions.ToString(currentContract.ForecastExcessMileageCost);
        }
        this.PopulateVanEquipmentDatagrid();
        this.PopulateEngineerHistoryDatagrid();
        this.PopulateVanFaultDatagrid();
        this.PopulateServiceDatagrid();
        this.PopulateVanAuditDatagrid();
      }
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    private void PopulateVanEquipmentDatagrid()
    {
      try
      {
        this.VanEquipmentDataview = App.DB.FleetVanEquipment.Get_ByVanID(this.CurrentVan.VanID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void PopulateVanFaultDatagrid()
    {
      try
      {
        this.VanFaultDataview = App.DB.FleetVanFault.GetAll_ByVanID(this.CurrentVan.VanID);
        this.VanFaultDataview.RowFilter = "Archive = 0";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void PopulateServiceDatagrid()
    {
      try
      {
        this.ServiceDataView = App.DB.FleetVanService.GetServices_ByVanId(this.CurrentVan.VanID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void PopulateEngineerHistoryDatagrid()
    {
      try
      {
        this.EngineerHistoryDataview = App.DB.FleetVanEngineer.GetAll_ByVanID(this.CurrentVan.VanID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void PopulateVanAuditDatagrid()
    {
      try
      {
        this.VanAuditsDataview = App.DB.FleetVan.VanAudit_Get(this.CurrentVan.VanID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public bool Save()
    {
      object objectValue = RuntimeHelpers.GetObjectValue(new object());
      EventArgs e = new EventArgs();
      bool flag;
      if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(this.btnSave_Click(RuntimeHelpers.GetObjectValue(objectValue), e))))
        flag = false;
      else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(this.btnContractSave_Click(RuntimeHelpers.GetObjectValue(objectValue), e))))
        flag = false;
      else
        App.MainForm.RefreshEntity(this.CurrentVan.VanID, "");
      return flag;
    }

    private object btnSave_Click(object sender, EventArgs e)
    {
      bool flag;
      object obj;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentVan.IgnoreExceptionsOnSetMethods = true;
        string actionChange1 = this.UpdateVanAudit();
        if (!this.CurrentVan.Exists)
          this.btnNextService_Click(RuntimeHelpers.GetObjectValue(sender), e);
        FleetVan currentVan = this.CurrentVan;
        currentVan.SetRegistration = (object) this.txtRegistration.Text;
        currentVan.SetVanTypeID = (object) Combo.get_GetSelectedItemValue(this.cboVanType);
        currentVan.SetMileage = (object) Helper.MakeIntegerValid((object) this.txtMileage.Text);
        currentVan.SetAverageMileage = (object) Helper.MakeIntegerValid((object) this.txtAverageMileage.Text);
        currentVan.SetReturned = (object) this.chkReturned.Checked;
        currentVan.SetNotes = (object) this.txtNotes.Text;
        currentVan.SetDepartment = (object) Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment).Trim());
        currentVan.SetTyreSize = (object) Math.Round(Helper.MakeDoubleValid((object) this.txtTyreSize.Text), 2).ToString();
        new FleetVanValidator().Validate(this.CurrentVan);
        flag = true;
        if (this.CurrentVan.Exists)
          App.DB.FleetVan.Update(this.CurrentVan);
        else
          this.CurrentVan = App.DB.FleetVan.Insert(this.CurrentVan);
        if (!string.IsNullOrEmpty(actionChange1))
          App.DB.FleetVan.VanAudit_Insert(this.CurrentVan.VanID, actionChange1);
        if (this.CurrentVan.VanID > 0)
        {
          if (this.CurrentVanMaintenance == null)
            this.CurrentVanMaintenance = new FleetVanMaintenance();
          string actionChange2 = this.UpdateVanMaintenanceAudit();
          FleetVanMaintenance currentVanMaintenance = this.CurrentVanMaintenance;
          currentVanMaintenance.SetVanID = (object) this.CurrentVan.VanID;
          currentVanMaintenance.LastService = this.dtpLastServiceDate.Value;
          currentVanMaintenance.NextService = this.dtpNextServiceDate.Value;
          currentVanMaintenance.SetLastServiceMileage = (object) Helper.MakeIntegerValid((object) this.txtLastServiceMileage.Text);
          currentVanMaintenance.MOTExpiry = this.dtpMOTExpiry.Value;
          currentVanMaintenance.RoadTaxExpiry = this.dtpTaxExpiry.Value;
          currentVanMaintenance.SetBreakdown = (object) this.txtBreakdown.Text;
          currentVanMaintenance.BreakdownExpiry = this.dtpBreakdownExpiry.Value;
          currentVanMaintenance.WarrantyExpiry = this.dtpWarrantyExpiry.Value;
          if (this.CurrentVanEngineer == null)
            this.CurrentVanEngineer = new FleetVanEngineer();
          string actionChange3 = this.UpdateVanEngineerAudit();
          FleetVanEngineer currentVanEngineer = this.CurrentVanEngineer;
          currentVanEngineer.SetEngineerID = this.Engineer != null ? (object) this.Engineer.EngineerID : (object) 0;
          currentVanEngineer.SetVanID = (object) this.CurrentVan.VanID;
          currentVanEngineer.StartDate = this.dtpStartDate.Value.Date;
          if (this.chkEndDate.Checked)
            currentVanEngineer.EndDate = this.dtpEndDate.Value.Date;
          new FleetVanEngineerValidator().Validate(this.CurrentVanEngineer);
          if (this.CurrentVanEngineer.EngineerID > 0)
          {
            if (this.CurrentVanEngineer.Exists)
              App.DB.FleetVanEngineer.Update(this.CurrentVanEngineer);
            else
              this.CurrentVanEngineer = App.DB.FleetVanEngineer.Insert(this.CurrentVanEngineer);
          }
          if (!string.IsNullOrEmpty(actionChange3))
            App.DB.FleetVan.VanAudit_Insert(this.CurrentVan.VanID, actionChange3);
          new FleetVanMaintenanceValidator().Validate(this.CurrentVanMaintenance);
          if (this.CurrentVanMaintenance.Exists)
            App.DB.FleetVanMaintenance.Update(this.CurrentVanMaintenance);
          else
            this.CurrentVanMaintenance = App.DB.FleetVanMaintenance.Insert(this.CurrentVanMaintenance);
          if (!string.IsNullOrEmpty(actionChange2))
            App.DB.FleetVan.VanAudit_Insert(this.CurrentVan.VanID, actionChange2);
        }
        if (this.EquipmentList.Count > 0)
        {
          try
          {
            foreach (int equipment in this.EquipmentList)
              App.DB.FleetVanEquipment.Update(equipment, this.CurrentVan.VanID);
          }
          finally
          {
            List<int>.Enumerator enumerator;
            enumerator.Dispose();
          }
        }
        obj = (object) true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        ValidationException validationException = ex;
        if (flag)
        {
          int num1 = (int) App.ShowMessage(string.Format("Main van details have been saved, please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) validationException.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          int num2 = (int) App.ShowMessage(string.Format("Details have NOT been saved, please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) validationException.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        obj = (object) false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        obj = (object) false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return obj;
    }

    private string UpdateVanAudit()
    {
      bool flag = false;
      string str = "";
      FleetVan currentVan = this.CurrentVan;
      if (currentVan.Exists)
      {
        if ((double) currentVan.VanTypeID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVanType)))
        {
          flag = true;
          FleetVanType fleetVanType1 = App.DB.FleetVanType.Get(currentVan.VanTypeID);
          FleetVanType fleetVanType2 = App.DB.FleetVanType.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVanType)));
          str = str + "Type of van changed from: " + fleetVanType1.Make + " " + fleetVanType1.Model + " to: " + fleetVanType2.Make + " " + fleetVanType2.Model;
        }
        if ((double) currentVan.Mileage != Conversions.ToDouble(this.txtMileage.Text))
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Mileage changed from: " + Conversions.ToString(currentVan.Mileage) + " to: " + this.txtMileage.Text;
        }
        if ((double) currentVan.AverageMileage != Conversions.ToDouble(this.txtAverageMileage.Text))
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Average Mileage changed from: " + Conversions.ToString(currentVan.AverageMileage) + " to: " + this.txtAverageMileage.Text;
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentVan.Department, Combo.get_GetSelectedItemValue(this.cboDepartment), false) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Department changed from: " + currentVan.Department + " to: " + Combo.get_GetSelectedItemValue(this.cboDepartment);
        }
        if (currentVan.Returned != this.chkReturned.Checked)
        {
          if (flag)
            str += ", ";
          flag = true;
          if (currentVan.Returned)
            str += "Van has been returned";
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentVan.Notes, this.txtNotes.Text, false) > 0U)
        {
          if (flag)
            str += ", ";
          str += "Notes were updated";
        }
      }
      return str;
    }

    private string UpdateVanMaintenanceAudit()
    {
      bool flag = false;
      string str = (string) null;
      FleetVanMaintenance currentVanMaintenance = this.CurrentVanMaintenance;
      if (currentVanMaintenance.Exists)
      {
        if ((uint) DateTime.Compare(currentVanMaintenance.LastService, this.dtpLastServiceDate.Value) > 0U)
        {
          flag = true;
          str = str + "Last service date changed from: " + Conversions.ToString(currentVanMaintenance.LastService) + " to: " + Conversions.ToString(this.dtpLastServiceDate.Value);
        }
        if ((uint) DateTime.Compare(currentVanMaintenance.NextService, this.dtpNextServiceDate.Value) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Next service date changed from: " + Conversions.ToString(currentVanMaintenance.NextService) + " to: " + Conversions.ToString(this.dtpNextServiceDate.Value);
        }
        if ((uint) Helper.MakeIntegerValid((object) this.txtLastServiceMileage.Text) > 0U)
        {
          if ((double) currentVanMaintenance.LastServiceMileage != Conversions.ToDouble(this.txtLastServiceMileage.Text))
          {
            if (flag)
              str += ", ";
            flag = true;
            str = str + "Last service mileage changed from: " + Conversions.ToString(currentVanMaintenance.LastServiceMileage) + " to: " + this.txtLastServiceMileage.Text;
          }
        }
        else
        {
          int num = (int) App.ShowMessage("Last Service requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        if ((uint) DateTime.Compare(currentVanMaintenance.MOTExpiry, this.dtpMOTExpiry.Value) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "MOT expiry date changed from: " + Conversions.ToString(currentVanMaintenance.MOTExpiry) + " to: " + Conversions.ToString(this.dtpMOTExpiry.Value);
        }
        if ((uint) DateTime.Compare(currentVanMaintenance.RoadTaxExpiry, this.dtpTaxExpiry.Value) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Road tax expiry date changed from: " + Conversions.ToString(currentVanMaintenance.RoadTaxExpiry) + " to: " + Conversions.ToString(this.dtpTaxExpiry.Value);
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentVanMaintenance.Breakdown, this.txtBreakdown.Text, false) > 0U)
        {
          if (flag)
            str += ", ";
          str = str + "Breakdown provider changed from: " + currentVanMaintenance.Breakdown + " to: " + this.txtBreakdown.Text;
        }
      }
      return str;
    }

    private string UpdateVanEngineerAudit()
    {
      bool flag = false;
      string str = "";
      FleetVanEngineer currentVanEngineer = this.CurrentVanEngineer;
      if (currentVanEngineer.Exists)
      {
        if (currentVanEngineer.EngineerID != this.Engineer.EngineerID)
        {
          flag = true;
          str += "Engineer changed";
        }
        if ((uint) DateTime.Compare(currentVanEngineer.StartDate, this.dtpStartDate.Value) > 0U)
        {
          if (flag)
            str += ", ";
          str = str + "Start date changed from: " + Conversions.ToString(currentVanEngineer.StartDate) + " to: " + Conversions.ToString(this.dtpStartDate.Value);
        }
      }
      return str;
    }

    private bool btnSaveFault_Click()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.CurrentVanFault == null)
          this.CurrentVanFault = new FleetVanFault();
        this.CurrentVanFault.IgnoreExceptionsOnSetMethods = true;
        FleetVanFault currentVanFault = this.CurrentVanFault;
        currentVanFault.SetFaultTypeID = (object) Combo.get_GetSelectedItemValue(this.cboFaultType);
        currentVanFault.SetVanID = (object) this.CurrentVan.VanID;
        currentVanFault.FaultDate = this.dtpFaultDate.Value;
        currentVanFault.SetArchive = this.chkArchive.Checked;
        currentVanFault.ResolvedDate = Conversions.ToDate(Interaction.IIf(this.chkResolved.Checked, (object) this.dtpResolvedDate.Value, (object) null));
        currentVanFault.SetEngineerNotes = (object) this.txtEngineerFaultNotes.Text;
        currentVanFault.SetNotes = !string.IsNullOrEmpty(this.txtAdditionalNotes.Text) ? (!string.IsNullOrEmpty(this.txtFaultNotes.Text) ? (object) (this.txtFaultNotes.Text + "\r\n\r\n" + this.txtAdditionalNotes.Text) : (object) this.txtAdditionalNotes.Text) : (object) this.txtFaultNotes.Text;
        new FleetVanFaultValidator().Validate(this.CurrentVanFault);
        if (this.CurrentVanFault.Exists)
          App.DB.FleetVanFault.Update(this.CurrentVanFault);
        else
          this.CurrentVanFault = App.DB.FleetVanFault.Insert(this.CurrentVanFault);
        this.PopulateVanFaultDatagrid();
        flag = true;
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
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private object btnContractSave_Click(object sender, EventArgs e)
    {
      string MessageText = "Please ensure the main details are saved first!";
      object obj;
      if (this.CurrentVan == null)
      {
        int num = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        obj = (object) false;
      }
      else if (!this.CurrentVan.Exists)
      {
        int num = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        obj = (object) false;
      }
      else
      {
        try
        {
          this.Cursor = Cursors.WaitCursor;
          if (this.CurrentContract == null)
            this.CurrentContract = new FleetVanContract();
          string actionChange = this.UpdateVanContractAudit();
          FleetVanContract currentContract = this.CurrentContract;
          currentContract.IgnoreExceptionsOnSetMethods = true;
          currentContract.SetVanID = (object) this.CurrentVan.VanID;
          currentContract.SetLessor = (object) this.txtLessor.Text;
          currentContract.SetProcurementMethod = (object) Combo.get_GetSelectedItemValue(this.cboProcurementMethod);
          currentContract.SetContractLength = (object) this.txtContractLength.Text;
          currentContract.ContractStart = this.dtpContractStart.Value;
          currentContract.ContractEnd = this.dtpContractEnd.Enabled ? this.dtpContractEnd.Value : DateTime.MinValue;
          currentContract.SetContractMileage = (object) Helper.MakeIntegerValid((object) this.txtContractMileage.Text);
          currentContract.SetStartingMileage = (object) Helper.MakeIntegerValid((object) this.txtStartingMileage.Text);
          currentContract.SetExcessMileageRate = (object) Helper.MakeDoubleValid((object) this.txtExcessMileageRate.Text);
          currentContract.SetWeeklyRental = (object) Helper.MakeDoubleValid((object) this.txtWeeklyRental.Text);
          currentContract.SetMonthlyRental = (object) Helper.MakeDoubleValid((object) this.txtMonthlyRental.Text);
          currentContract.SetAnnualRental = (object) Helper.MakeDoubleValid((object) this.txtAnnualRental.Text);
          currentContract.SetAgreementRef = (object) this.txtAgreementRef.Text;
          currentContract.SetNotes = (object) this.txtContractNotes.Text;
          new FleetVanContractValidator().Validate(this.CurrentContract);
          if (this.CurrentContract.Exists)
            App.DB.FleetVanContract.Update(this.CurrentContract);
          else
            this.CurrentContract = App.DB.FleetVanContract.Insert(this.CurrentContract);
          if (!string.IsNullOrEmpty(actionChange))
            App.DB.FleetVan.VanAudit_Insert(this.CurrentVan.VanID, actionChange);
          obj = (object) true;
        }
        catch (ValidationException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          obj = (object) false;
          ProjectData.ClearProjectError();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          obj = (object) false;
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
      return obj;
    }

    private string UpdateVanContractAudit()
    {
      bool flag = false;
      string str = "";
      FleetVanContract currentContract = this.CurrentContract;
      if (currentContract.Exists)
      {
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentContract.Lessor, this.txtLessor.Text, false) > 0U)
        {
          flag = true;
          str = str + "Lessor changed from: " + currentContract.Lessor + " to: " + this.txtLessor.Text;
        }
        if ((uint) Helper.MakeIntegerValid((object) this.txtContractLength.Text) > 0U)
        {
          if ((double) currentContract.ContractLength != Conversions.ToDouble(this.txtContractLength.Text))
          {
            if (flag)
              str += ", ";
            flag = true;
            str = str + "Contract length changed from: " + Conversions.ToString(currentContract.ContractLength) + " to: " + this.txtContractLength.Text;
          }
        }
        else
        {
          int num = (int) App.ShowMessage("Contract Length requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      if ((uint) DateTime.Compare(currentContract.ContractStart, this.dtpContractStart.Value) > 0U)
      {
        if (flag)
          str += ", ";
        flag = true;
        str = str + "Contract start changed from: " + Conversions.ToString(currentContract.ContractStart) + " to: " + Conversions.ToString(this.dtpContractStart.Value);
      }
      if ((uint) DateTime.Compare(currentContract.ContractEnd, this.dtpContractEnd.Value) > 0U)
      {
        if (flag)
          str += ", ";
        flag = true;
        str = str + "Contract end changed from: " + Conversions.ToString(currentContract.ContractEnd) + " to: " + Conversions.ToString(this.dtpContractEnd.Value);
      }
      if ((uint) Helper.MakeIntegerValid((object) this.txtContractMileage.Text) > 0U)
      {
        if ((double) currentContract.ContractMileage != Conversions.ToDouble(this.txtContractMileage.Text))
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Contract mileage changed from: " + Conversions.ToString(currentContract.ContractMileage) + " to: " + this.txtContractMileage.Text;
        }
      }
      else
      {
        int num1 = (int) App.ShowMessage("Contract mileage requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if ((uint) Helper.MakeIntegerValid((object) this.txtStartingMileage.Text) > 0U)
      {
        if ((double) currentContract.StartingMileage != Conversions.ToDouble(this.txtStartingMileage.Text))
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Contract start mileage changed from: " + Conversions.ToString(currentContract.StartingMileage) + " to: " + this.txtStartingMileage.Text;
        }
      }
      else
      {
        int num2 = (int) App.ShowMessage("Contract mileage requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if (currentContract.ExcessMileageRate != Conversions.ToDouble(this.txtExcessMileageRate.Text))
      {
        if (flag)
          str += ", ";
        flag = true;
        str = str + "Excess mileage rate changed from: " + Conversions.ToString(currentContract.ExcessMileageRate) + " to: " + this.txtExcessMileageRate.Text;
      }
      if (currentContract.ExcessMileageCost != Conversions.ToDouble(this.txtExcessMileageCost.Text))
      {
        if (flag)
          str += ", ";
        flag = true;
        str = str + "Excess mileage cost changed from: " + Conversions.ToString(currentContract.ExcessMileageCost) + " to: " + this.txtExcessMileageCost.Text;
      }
      if (currentContract.ForecastExcessMileageCost != Conversions.ToDouble(this.txtForecastExcessCost.Text))
      {
        if (flag)
          str += ", ";
        flag = true;
        str = str + "Forecast excess mileage cost changed from: " + Conversions.ToString(currentContract.ForecastExcessMileageCost) + " to: " + this.txtForecastExcessCost.Text;
      }
      if (currentContract.WeeklyRental != Conversions.ToDouble(this.txtWeeklyRental.Text))
      {
        if (flag)
          str += ", ";
        flag = true;
        str = str + "Weekly rental rate changed from: " + Conversions.ToString(currentContract.WeeklyRental) + " to: " + this.txtWeeklyRental.Text;
      }
      if (currentContract.MonthlyRental != Conversions.ToDouble(this.txtMonthlyRental.Text))
      {
        if (flag)
          str += ", ";
        flag = true;
        str = str + "Monthly rental rate changed from: " + Conversions.ToString(currentContract.MonthlyRental) + " to: " + this.txtMonthlyRental.Text;
      }
      if (currentContract.AnnualRental != Conversions.ToDouble(this.txtAnnualRental.Text))
      {
        if (flag)
          str += ", ";
        str = str + "Annual rental rate changed from: " + Conversions.ToString(currentContract.AnnualRental) + " to: " + this.txtAnnualRental.Text;
      }
      return str;
    }

    private void RunEstimateUpdates()
    {
      if (!this.CurrentVanMaintenance.Exists)
        return;
      try
      {
        int num1 = checked ((int) DateAndTime.DateDiff(DateInterval.WeekOfYear, this.CurrentVanMaintenance.LastService, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
        if (num1 < 1)
          num1 = 1;
        if (this.CurrentVan.Mileage < 1)
          return;
        int num2 = checked (this.CurrentVan.Mileage - this.CurrentVanMaintenance.LastServiceMileage);
        List<int> source = new List<int>();
        int num3 = 0;
        double a1 = Math.Round((double) num2 / (double) num1 * 4.3, MidpointRounding.AwayFromZero);
        this.CurrentVan.SetAverageMileage = (object) a1;
        if (this.CurrentContract.Exists && DateTime.Compare(this.CurrentContract.ContractStart, DateTime.Now) < 0 & this.CurrentContract.ProcurementMethod != 4 & this.CurrentContract.ContractLength > 0)
        {
          source.Add(checked ((int) Math.Round(a1)));
          num3 = checked ((int) DateAndTime.DateDiff(DateInterval.WeekOfYear, this.CurrentContract.ContractStart, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          int num4 = checked (this.CurrentVan.Mileage - this.CurrentContract.StartingMileage);
          if (num3 > 0)
          {
            double a2 = Math.Round((double) num4 / (double) num3 * 4.3, MidpointRounding.AwayFromZero);
            source.Add(checked ((int) Math.Round(a2)));
            this.CurrentVan.SetAverageMileage = (object) checked ((int) Math.Round(source.Average()));
          }
        }
        FleetVanType fleetVanType = App.DB.FleetVanType.Get(this.CurrentVan.VanTypeID);
        DateTime t1 = this.CurrentVanMaintenance.LastService.AddMonths(fleetVanType.DateServiceInterval);
        DateTime t2 = this.CurrentVanMaintenance.LastService.AddMonths(checked ((int) Math.Round(unchecked ((double) fleetVanType.MileageServiceInterval / (double) this.CurrentVan.AverageMileage))));
        this.CurrentVanMaintenance.NextService = DateTime.Compare(t1, t2) >= 0 ? t2 : t1;
        if (this.CurrentContract.ContractMileage == 0)
        {
          this.CurrentContract.SetExcessMileageCost = (object) 0;
          this.CurrentContract.SetForecastExcessMileageCost = (object) this.CurrentContract.ExcessMileageCost;
        }
        else
        {
          this.CurrentContract.SetExcessMileageCost = this.CurrentVan.Mileage <= this.CurrentContract.ContractMileage ? (object) 0 : (object) (this.CurrentContract.ExcessMileageRate * (double) checked (this.CurrentVan.Mileage - this.CurrentContract.ContractMileage));
          if (DateTime.Compare(this.CurrentContract.ContractEnd, DateTime.MinValue) == 0)
            return;
          this.CurrentContract.SetContractLength = (object) DateAndTime.DateDiff(DateInterval.Month, this.CurrentContract.ContractStart, this.CurrentContract.ContractEnd, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
          int num4 = checked ((int) Math.Round(unchecked ((double) this.CurrentContract.ContractLength - (double) num3 / 4.3)));
          int num5 = checked ((int) Math.Round(unchecked (a1 * (double) num4 + (double) this.CurrentVan.Mileage)));
          this.CurrentContract.SetForecastExcessMileageCost = num5 <= this.CurrentContract.ContractMileage ? (object) this.CurrentContract.ExcessMileageCost : (object) Math.Round(this.CurrentContract.ExcessMileageRate * (double) checked (num5 - this.CurrentContract.ContractMileage), 2, MidpointRounding.AwayFromZero);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      Engineer engineer = App.DB.Engineer.Engineer_Get(integer);
      if (engineer != null)
      {
        if (engineer.EngineerID != 666)
        {
          DataView allByEngineerId = App.DB.FleetVanEngineer.GetAll_ByEngineerID(engineer.EngineerID);
          if (allByEngineerId.Table.Rows.Count > 0)
          {
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();
            IEnumerator enumerator1;
            try
            {
              enumerator1 = allByEngineerId.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow row = ((DataRowView) enumerator1.Current).Row;
                stringList.Add(Conversions.ToString(row["Registration"]));
                intList.Add(Conversions.ToInteger(row["VanEngineerID"]));
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            if (stringList.Count > 0)
            {
              string str = string.Join(Environment.NewLine, stringList.ToArray());
              if (App.ShowMessage(engineer.Name + " is currently assigned to the following van(s): " + str + ", do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                try
                {
                  foreach (int oVanEngineerID in intList)
                    App.DB.FleetVanEngineer.Delete(oVanEngineerID, DateTime.MinValue);
                }
                finally
                {
                  List<int>.Enumerator enumerator2;
                  enumerator2.Dispose();
                }
                this.Engineer = engineer;
              }
            }
          }
          else
            this.Engineer = engineer;
        }
        else
          this.Engineer = engineer;
      }
    }

    private void btnNextService_Click(object sender, EventArgs e)
    {
      DateTime Date1 = this.dtpLastServiceDate.Value;
      int integer1;
      try
      {
        if (this.txtMileage.Text.Trim().Length < 1)
          throw new Exception();
        integer1 = Conversions.ToInteger(this.txtMileage.Text);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Please add mileage", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
        return;
      }
      int integer2;
      try
      {
        if (this.txtLastServiceMileage.Text.Trim().Length < 1)
          throw new Exception();
        integer2 = Conversions.ToInteger(this.txtLastServiceMileage.Text);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Please add last service mileage", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
        return;
      }
      int num1 = checked ((int) DateAndTime.DateDiff(DateInterval.WeekOfYear, Date1, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
      if (num1 < 1)
        num1 = 1;
      int num2 = checked (integer1 - integer2);
      List<int> source = new List<int>();
      int num3 = checked ((int) Math.Round(Math.Round(unchecked ((double) num2 / (double) num1 * 4.3), MidpointRounding.AwayFromZero)));
      this.txtAverageMileage.Text = Conversions.ToString(num3);
      if (this.CurrentContract != null && this.CurrentContract.Exists && DateTime.Compare(this.CurrentContract.ContractStart, DateTime.Now) < 0 & this.CurrentContract.ProcurementMethod != 4 & this.CurrentContract.ContractLength > 0)
      {
        source.Add(num3);
        int num4 = checked ((int) DateAndTime.DateDiff(DateInterval.WeekOfYear, this.CurrentContract.ContractStart, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
        int num5 = checked (integer1 - Helper.MakeIntegerValid((object) this.txtStartingMileage.Text));
        if (num4 > 0)
        {
          double a = Math.Round((double) num5 / (double) num4 * 4.3, MidpointRounding.AwayFromZero);
          source.Add(checked ((int) Math.Round(a)));
          this.txtAverageMileage.Text = Conversions.ToString(checked ((int) Math.Round(source.Average())));
        }
      }
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVanType)) == 0.0)
      {
        int num6 = (int) App.ShowMessage("Please select van type", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        FleetVanType fleetVanType = App.DB.FleetVanType.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVanType)));
        DateTime t1 = Date1.AddMonths(fleetVanType.DateServiceInterval);
        if (Conversions.ToInteger(this.txtAverageMileage.Text) > 0)
        {
          int months = checked ((int) Math.Round(unchecked ((double) fleetVanType.MileageServiceInterval / (double) Conversions.ToInteger(this.txtAverageMileage.Text))));
          DateTime t2 = Date1.AddMonths(months);
          this.dtpNextServiceDate.Value = DateTime.Compare(t1, t2) >= 0 ? t2 : t1;
        }
      }
    }

    private void cboVanType_SelectedIndexChanged(object sender, EventArgs e)
    {
      FleetVanType fleetVanType = App.DB.FleetVanType.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVanType)));
      if (fleetVanType == null)
        return;
      this.txtMake.Text = fleetVanType.Make;
      this.txtModel.Text = fleetVanType.Model;
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.CurrentVanEngineer == null || App.ShowMessage("Are you sure you want to remove " + this.txtEngineer.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      if (this.CurrentVanEngineer.Exists)
      {
        DateTime date = Conversions.ToDate(Interaction.IIf(this.chkEndDate.Checked, (object) this.dtpEndDate.Value.Date, (object) null));
        App.DB.FleetVanEngineer.Delete(this.CurrentVanEngineer.VanEngineerID, date);
        this.CurrentVanEngineer = (FleetVanEngineer) null;
        this.Engineer = (Engineer) null;
        this.PopulateEngineerHistoryDatagrid();
        this.chkEndDate.Checked = false;
        this.dtpStartDate.Value = DateTime.Now;
        this.dtpEndDate.Value = DateTime.Now;
        int num = (int) App.ShowMessage("Engineer has been removed from current van.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this.CurrentVanEngineer = (FleetVanEngineer) null;
        this.Engineer = (Engineer) null;
        this.PopulateEngineerHistoryDatagrid();
      }
    }

    private void dgVanFaults_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.CurrentVan == null || !this.CurrentVan.Exists || this.SelectedFaultDataRow == null)
          return;
        this.CurrentVanFault = App.DB.FleetVanFault.Get(Conversions.ToInteger(this.SelectedFaultDataRow["VanFaultID"]));
        FleetVanFault currentVanFault = this.CurrentVanFault;
        ComboBox cboFaultType = this.cboFaultType;
        Combo.SetSelectedComboItem_By_Value(ref cboFaultType, Conversions.ToString(currentVanFault.FaultTypeID));
        this.cboFaultType = cboFaultType;
        this.dtpFaultDate.Value = currentVanFault.FaultDate;
        this.chkResolved.Checked = false;
        this.chkArchive.Checked = currentVanFault.Archive;
        if ((uint) DateTime.Compare(currentVanFault.ResolvedDate, DateTime.MinValue) > 0U)
        {
          this.dtpResolvedDate.Value = currentVanFault.ResolvedDate;
          this.chkResolved.Checked = true;
        }
        else
          this.dtpResolvedDate.Value = DateAndTime.Now;
        this.dtpResolvedDate.Enabled = this.chkResolved.Checked;
        this.txtEngineerFaultNotes.Text = currentVanFault.EngineerNotes;
        this.txtFaultNotes.Text = currentVanFault.Notes;
        this.txtAdditionalNotes.Text = string.Empty;
        Job job = App.DB.Job.Job_Get(currentVanFault.JobID);
        EngineerVisit lastForJob = App.DB.EngineerVisits.EngineerVisits_Get_LastForJob(currentVanFault.JobID, "");
        if (job != null & lastForJob != null)
        {
          this.txtJobRef.Text = job.JobNumber;
          if ((uint) DateTime.Compare(lastForJob.StartDateTime, DateTime.MinValue) > 0U)
            this.txtScheduled.Text = lastForJob.StartDateTime.ToShortDateString();
          this.txtStatus.Text = lastForJob.VisitStatus;
          this.txtOutcome.Text = lastForJob.VisitOutcome;
        }
        else
        {
          this.txtJobRef.Text = "";
          this.txtScheduled.Text = "";
          this.txtStatus.Text = "";
          this.txtOutcome.Text = "";
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error, cannot find fault : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnNewFault_Click(object sender, EventArgs e)
    {
      ComboBox cboFaultType = this.cboFaultType;
      Combo.SetSelectedComboItem_By_Value(ref cboFaultType, Conversions.ToString(0));
      this.cboFaultType = cboFaultType;
      this.CurrentVanFault = (FleetVanFault) null;
      this.dtpFaultDate.Value = DateAndTime.Now;
      this.dtpResolvedDate.Value = DateAndTime.Now;
      this.chkResolved.Checked = false;
      this.chkArchive.Checked = false;
      this.txtEngineerFaultNotes.Text = string.Empty;
      this.txtFaultNotes.Text = string.Empty;
      this.txtJobRef.Text = "";
      this.txtScheduled.Text = "";
      this.txtStatus.Text = "";
      this.txtOutcome.Text = "";
    }

    private void dgServiceHistory_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedServiceDataRow == null)
        return;
      App.ShowForm(typeof (FRMLogCallout), true, new object[3]
      {
        this.SelectedServiceDataRow["JobID"],
        this.SelectedServiceDataRow["SiteID"],
        (object) this
      }, false);
    }

    private void btnRemoveEquipment_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Are you sure you want to remove ", this.SelectedEquipmentDataRow["Name"]), (object) "?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      App.DB.FleetVanEquipment.Delete(Conversions.ToInteger(this.SelectedEquipmentDataRow["VanEquipmentID"]));
      this.PopulateVanEquipmentDatagrid();
    }

    private void btnAddEquipment_Click(object sender, EventArgs e)
    {
      FRMAddVanEquipment frmAddVanEquipment = new FRMAddVanEquipment();
      int num1 = (int) frmAddVanEquipment.ShowDialog();
      if (App.DB.FleetVanEquipment.Check(this.CurrentVan.VanID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(frmAddVanEquipment.cboEquipment))) == 0)
      {
        int num2 = App.DB.FleetVanEquipment.Insert(this.CurrentVan.VanID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(frmAddVanEquipment.cboEquipment)));
        if (this.CurrentVan.VanID == 0)
          this.EquipmentList.Add(num2);
        this.PopulateVanEquipmentDatagrid();
      }
      else
      {
        int num3 = (int) App.ShowMessage("Equipment already assigned to van", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void chkResolved_CheckedChanged(object sender, EventArgs e)
    {
      this.dtpResolvedDate.Enabled = this.chkResolved.Checked;
      if (this.CurrentVanFault != null)
      {
        if (DateTime.Compare(this.CurrentVanFault.ResolvedDate, DateTime.MinValue) != 0)
          return;
        this.dtpResolvedDate.Value = DateAndTime.Now;
      }
      else
        this.dtpResolvedDate.Value = DateAndTime.Now;
    }

    private void dgVanFaults_DoubleClick(object sender, EventArgs e)
    {
      if (!this.CurrentVanFault.Exists || this.CurrentVanFault.JobID <= 0)
        return;
      Job job = App.DB.Job.Job_Get(this.CurrentVanFault.JobID);
      if (job != null)
        App.ShowForm(typeof (FRMLogCallout), true, new object[3]
        {
          (object) job.JobID,
          (object) job.PropertyID,
          (object) this
        }, false);
    }

    private void txtExcessMileageRate_KeyUp(object sender, KeyEventArgs e)
    {
      if (this.CurrentContract == null || !this.CurrentContract.Exists)
        return;
      this.CurrentContract.SetExcessMileageRate = (object) this.txtExcessMileageRate.Text;
      this.RunEstimateUpdates();
    }

    private void txtWeeklyRental_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        double num = Conversions.ToDouble(this.txtWeeklyRental.Text);
        this.txtMonthlyRental.Text = Conversions.ToString(Math.Round(num * 4.3, MidpointRounding.AwayFromZero));
        this.txtAnnualRental.Text = Conversions.ToString(Math.Round(num * 52.0, MidpointRounding.AwayFromZero));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Weekly rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtMonthlyRental_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        double num = Conversions.ToDouble(this.txtMonthlyRental.Text);
        this.txtWeeklyRental.Text = Conversions.ToString(Math.Round(num / 4.3, MidpointRounding.AwayFromZero));
        this.txtAnnualRental.Text = Conversions.ToString(Math.Round(num * 12.0, MidpointRounding.AwayFromZero));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Monthly rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtAnnualRental_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        double num = Conversions.ToDouble(this.txtAnnualRental.Text);
        this.txtWeeklyRental.Text = Conversions.ToString(Math.Round(num / 52.0, MidpointRounding.AwayFromZero));
        this.txtMonthlyRental.Text = Conversions.ToString(Math.Round(num / 12.0, MidpointRounding.AwayFromZero));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Annual rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgVanAudits_Click(object sender, EventArgs e)
    {
      if (this.SelectedVanHistoryDataRow == null)
        return;
      this.dtpHistoryDate.Value = Conversions.ToDate(this.SelectedVanHistoryDataRow["ActionDateTime"]);
      this.txtUsername.Text = Conversions.ToString(this.SelectedVanHistoryDataRow["Fullname"]);
      this.txtChange.Text = Conversions.ToString(this.SelectedVanHistoryDataRow["ActionChange"]);
    }

    private void btnEndContract_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("End Contract, Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK || !this.CurrentContract.Exists)
        return;
      this.CurrentContract.ContractEnd = DateTime.Now;
      App.DB.FleetVanContract.Update(this.CurrentContract);
      string actionChange = "Contract ended";
      if (!string.IsNullOrEmpty(actionChange))
        App.DB.FleetVan.VanAudit_Insert(this.CurrentVan.VanID, actionChange);
    }

    private void cboProcurementMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboProcurementMethod)) != 3.0)
      {
        this.dtpContractEnd.Enabled = true;
        this.dtpContractEnd.Visible = true;
        this.btnEndContract.Visible = false;
        this.btnEndContract.Enabled = false;
      }
      else
      {
        this.dtpContractEnd.Enabled = false;
        this.dtpContractEnd.Visible = false;
        this.btnEndContract.Visible = true;
        this.btnEndContract.Enabled = true;
      }
      if (this.CurrentContract == null || (uint) DateTime.Compare(this.CurrentContract.ContractEnd, DateTime.MinValue) <= 0U)
        return;
      this.dtpContractEnd.Enabled = true;
      this.dtpContractEnd.Visible = true;
      this.btnEndContract.Visible = false;
      this.btnEndContract.Enabled = false;
    }

    private void chkReturned_CheckedChanged(object sender, EventArgs e)
    {
      if (App.ControlLoading || !this.chkReturned.Checked)
        return;
      if (App.ShowMessage("Return Vehicle? If yes, contract will end today and engineer shall be removed!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        if (this.CurrentVanEngineer != null && this.CurrentVanEngineer.Exists)
        {
          App.DB.FleetVanEngineer.Delete(this.CurrentVanEngineer.VanEngineerID, DateTime.MinValue);
          this.CurrentVanEngineer = (FleetVanEngineer) null;
          this.Engineer = (Engineer) null;
        }
        if (this.CurrentContract.Exists)
        {
          this.CurrentContract.ContractEnd = DateTime.Now;
          App.DB.FleetVanContract.Update(this.CurrentContract);
        }
        App.DB.FleetVan.ReturnVan(this.CurrentVan.VanID);
        string actionChange = "Van returned";
        if (!string.IsNullOrEmpty(actionChange))
          App.DB.FleetVan.VanAudit_Insert(this.CurrentVan.VanID, actionChange);
        this.Populate(this.CurrentVan.VanID);
        this.Save();
        App.ControlChanged = false;
      }
      else
        this.chkReturned.Checked = false;
    }

    private void chkEndDate_CheckedChanged(object sender, EventArgs e)
    {
      if (App.ControlLoading)
        return;
      if (this.chkEndDate.Checked)
        this.dtpEndDate.Enabled = true;
      else
        this.dtpEndDate.Enabled = false;
    }

    private void chkHideArchive_CheckedChanged(object sender, EventArgs e)
    {
      if (this.VanFaultDataview == null)
        return;
      this.VanFaultDataview.RowFilter = Conversions.ToString(Interaction.IIf(this.chkHideArchive.Checked, (object) "Archive = 0", (object) ""));
    }

    private void btnRemoveContractEndDate_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("Are you sure you want to remove the contract end date?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.btnRemoveContractEndDate.Visible = false;
      this.dtpContractEnd.Visible = false;
      this.dtpContractEnd.Enabled = false;
      this.btnEndContract.Visible = true;
      this.btnEndContract.Enabled = true;
    }

    private void btnSaveFault_Click(object sender, EventArgs e)
    {
    }
  }
}
