// Decompiled with JetBrains decompiler
// Type: FSM.UCSubcontractor
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.MaxEngineerTimes;
using FSM.Entity.Subcontractors;
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
  public class UCSubcontractor : UCBase, IUserControl
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private Subcontractor _currentSubcontractor;
    private MaxEngineerTime _MaxTimes;
    private DataView postalRegionsDV;
    private DataView postalRegionsDVUT;
    private DataView _trainingQualificationsDataView;
    private DataView _engineerEquipmentDataView;
    private DataView _disciplinariesDataView;
    private DataView _dvAbsences;

    public UCSubcontractor()
    {
      this.Load += new EventHandler(this.UCSubcontractor_Load);
      this.postalRegionsDV = (DataView) null;
      this.postalRegionsDVUT = (DataView) null;
      this._dvAbsences = new DataView();
      this.InitializeComponent();
      this.TabControl1.TabPages.Clear();
      this.TabControl1.TabPages.Add(this.tpContact);
      this.TabControl1.TabPages.Add(this.tpMain);
      this.TabControl1.TabPages.Add(this.tabMaxSor);
      this.TabControl1.TabPages.Add(this.tpPostalRegions);
      this.TabControl1.TabPages.Add(this.tpTrainingQualifications);
      this.TabControl1.TabPages.Add(this.tpWages);
      this.TabControl1.TabPages.Add(this.tpHolidayAbsences);
      this.TabControl1.TabPages.Add(this.tpDisciplinary);
      this.TabControl1.TabPages.Add(this.tpKit);
      this.TabControl1.TabPages.Add(this.tpDocuments);
      ComboBox cboLinkToSupplier = this.cboLinkToSupplier;
      Combo.SetUpCombo(ref cboLinkToSupplier, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboLinkToSupplier = cboLinkToSupplier;
      ComboBox cboRegion = this.cboRegion;
      Combo.SetUpCombo(ref cboRegion, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboRegion = cboRegion;
      ComboBox cboPayGrade1 = this.cboPayGrade;
      Combo.SetUpCombo(ref cboPayGrade1, App.DB.Picklists.GetAll(Enums.PickListTypes.PayGrades, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPayGrade = cboPayGrade1;
      ComboBox cboTaxRate = this.cboTaxRate;
      Combo.SetUpCombo(ref cboTaxRate, App.DB.Picklists.GetAll(Enums.PickListTypes.SubTaxRate, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTaxRate = cboTaxRate;
      ComboBox cboDisciplinary1 = this.cboDisciplinary;
      Combo.SetUpCombo(ref cboDisciplinary1, App.DB.Picklists.GetAll(Enums.PickListTypes.DisciplinaryStatus, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboDisciplinary = cboDisciplinary1;
      ComboBox cboQualification1 = this.cboQualification;
      Combo.SetUpCombo(ref cboQualification1, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualification = cboQualification1;
      ComboBox cboEngineerGroup = this.cboEngineerGroup;
      Combo.SetUpCombo(ref cboEngineerGroup, App.DB.Picklists.GetAll(Enums.PickListTypes.EngineerGroup, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboEngineerGroup = cboEngineerGroup;
      ComboBox cboPayGrade2 = this.cboPayGrade;
      Combo.SetUpCombo(ref cboPayGrade2, App.DB.Picklists.GetAll(Enums.PickListTypes.PayGrades, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPayGrade = cboPayGrade2;
      ComboBox cboDisciplinary2 = this.cboDisciplinary;
      Combo.SetUpCombo(ref cboDisciplinary2, App.DB.Picklists.GetAll(Enums.PickListTypes.DisciplinaryStatus, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboDisciplinary = cboDisciplinary2;
      ComboBox qualificationType = this.cboQualificationType;
      Combo.SetUpCombo(ref qualificationType, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualificationType = qualificationType;
      ComboBox cboQualification2 = this.cboQualification;
      Combo.SetUpComboQual(ref cboQualification2, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualification = cboQualification2;
      ComboBox cboUser = this.cboUser;
      Combo.SetUpCombo(ref cboUser, App.DB.User.GetAll().Table, "UserID", "FullName", Enums.ComboValues.Not_Applicable);
      this.cboUser = cboUser;
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

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDrivingLicenceIssueDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDrivingLicenseDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDrivingLicenceNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDrivingLicense { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtStartingDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStartDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNextOfKinContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNextOfKinDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNextOfKinName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNextOfKin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnVanHistory
    {
      get
      {
        return this._btnVanHistory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnVanHistory_Click);
        Button btnVanHistory1 = this._btnVanHistory;
        if (btnVanHistory1 != null)
          btnVanHistory1.Click -= eventHandler;
        this._btnVanHistory = value;
        Button btnVanHistory2 = this._btnVanHistory;
        if (btnVanHistory2 == null)
          return;
        btnVanHistory2.Click += eventHandler;
      }
    }

    internal virtual Label lblRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPDAID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkApprentice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpWages { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCostToCompanyDouble { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCostToCompanyTimeHalf { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCostToCompanyNormal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNINumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPayGrade { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAnnualSalary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpTrainingQualifications { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQualificatioNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveQualification
    {
      get
      {
        return this._btnSaveQualification;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveQualification_Click);
        Button saveQualification1 = this._btnSaveQualification;
        if (saveQualification1 != null)
          saveQualification1.Click -= eventHandler;
        this._btnSaveQualification = value;
        Button saveQualification2 = this._btnSaveQualification;
        if (saveQualification2 == null)
          return;
        saveQualification2.Click += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpQualificationExpires { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationPassed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveTrainingQualifications
    {
      get
      {
        return this._btnRemoveTrainingQualifications;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveTrainingQualifications_Click);
        Button trainingQualifications1 = this._btnRemoveTrainingQualifications;
        if (trainingQualifications1 != null)
          trainingQualifications1.Click -= eventHandler;
        this._btnRemoveTrainingQualifications = value;
        Button trainingQualifications2 = this._btnRemoveTrainingQualifications;
        if (trainingQualifications2 == null)
          return;
        trainingQualifications2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgTrainingQualifications
    {
      get
      {
        return this._dgTrainingQualifications;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgTrainingQualifications_CurrentCellChanged);
        EventHandler eventHandler2 = new EventHandler(this.dgTrainingQualifications_CurrentCellChanged);
        DataGrid trainingQualifications1 = this._dgTrainingQualifications;
        if (trainingQualifications1 != null)
        {
          trainingQualifications1.Click -= eventHandler1;
          trainingQualifications1.CurrentCellChanged -= eventHandler2;
        }
        this._dgTrainingQualifications = value;
        DataGrid trainingQualifications2 = this._dgTrainingQualifications;
        if (trainingQualifications2 == null)
          return;
        trainingQualifications2.Click += eventHandler1;
        trainingQualifications2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual TabPage tpKit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEquipmentTool { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveEquipment
    {
      get
      {
        return this._btnSaveEquipment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveEquipment_Click);
        Button btnSaveEquipment1 = this._btnSaveEquipment;
        if (btnSaveEquipment1 != null)
          btnSaveEquipment1.Click -= eventHandler;
        this._btnSaveEquipment = value;
        Button btnSaveEquipment2 = this._btnSaveEquipment;
        if (btnSaveEquipment2 == null)
          return;
        btnSaveEquipment2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveEngineerEquipment
    {
      get
      {
        return this._btnRemoveEngineerEquipment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveEngineerEquipment_Click);
        Button engineerEquipment1 = this._btnRemoveEngineerEquipment;
        if (engineerEquipment1 != null)
          engineerEquipment1.Click -= eventHandler;
        this._btnRemoveEngineerEquipment = value;
        Button engineerEquipment2 = this._btnRemoveEngineerEquipment;
        if (engineerEquipment2 == null)
          return;
        engineerEquipment2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpDisciplinary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddDisciplinaries
    {
      get
      {
        return this._btnAddDisciplinaries;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddDisciplinaries_Click);
        Button addDisciplinaries1 = this._btnAddDisciplinaries;
        if (addDisciplinaries1 != null)
          addDisciplinaries1.Click -= eventHandler;
        this._btnAddDisciplinaries = value;
        Button addDisciplinaries2 = this._btnAddDisciplinaries;
        if (addDisciplinaries2 == null)
          return;
        addDisciplinaries2.Click += eventHandler;
      }
    }

    internal virtual Panel Panel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDisciplinaryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDisciplinary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveDisciplinaries
    {
      get
      {
        return this._btnSaveDisciplinaries;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveDisciplinaries_Click);
        Button saveDisciplinaries1 = this._btnSaveDisciplinaries;
        if (saveDisciplinaries1 != null)
          saveDisciplinaries1.Click -= eventHandler;
        this._btnSaveDisciplinaries = value;
        Button saveDisciplinaries2 = this._btnSaveDisciplinaries;
        if (saveDisciplinaries2 == null)
          return;
        saveDisciplinaries2.Click += eventHandler;
      }
    }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDisciplinaryIssued { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDisciplinary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveDisciplinaries
    {
      get
      {
        return this._btnRemoveDisciplinaries;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveDisciplinaries_Click);
        Button removeDisciplinaries1 = this._btnRemoveDisciplinaries;
        if (removeDisciplinaries1 != null)
          removeDisciplinaries1.Click -= eventHandler;
        this._btnRemoveDisciplinaries = value;
        Button removeDisciplinaries2 = this._btnRemoveDisciplinaries;
        if (removeDisciplinaries2 == null)
          return;
        removeDisciplinaries2.Click += eventHandler;
      }
    }

    internal virtual Button btnEditDisciplinaries
    {
      get
      {
        return this._btnEditDisciplinaries;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEditDisciplinaries_Click);
        Button editDisciplinaries1 = this._btnEditDisciplinaries;
        if (editDisciplinaries1 != null)
          editDisciplinaries1.Click -= eventHandler;
        this._btnEditDisciplinaries = value;
        Button editDisciplinaries2 = this._btnEditDisciplinaries;
        if (editDisciplinaries2 == null)
          return;
        editDisciplinaries2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgDisciplinaries { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpHolidayAbsences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAbsences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAbsences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDaysHolidayAllowed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHolidayYearEnd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHolidayYearStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpPostalRegions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPDAID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLinkToSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLinkToSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabMaxSor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDailyServiceLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label42 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSundayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSaturdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFridayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtThursdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWednesdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTuesdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMondayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label43 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label44 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label45 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label46 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label47 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label48 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label49 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOftecNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTechnician { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGasSafeNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineerID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOftecNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblManager { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTechnician { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineerGroup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label37 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblGasSafeId { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBreakPri { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtServPri { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label40 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label39 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationBooked { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label36 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpPostalRegions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label38 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPCSearch
    {
      get
      {
        return this._txtPCSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPCSearch_TextChanged);
        TextBox txtPcSearch1 = this._txtPCSearch;
        if (txtPcSearch1 != null)
          txtPcSearch1.TextChanged -= eventHandler;
        this._txtPCSearch = value;
        TextBox txtPcSearch2 = this._txtPCSearch;
        if (txtPcSearch2 == null)
          return;
        txtPcSearch2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgUnTicked
    {
      get
      {
        return this._dgUnTicked;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgUnTicked_Click);
        DataGrid dgUnTicked1 = this._dgUnTicked;
        if (dgUnTicked1 != null)
          dgUnTicked1.Click -= eventHandler;
        this._dgUnTicked = value;
        DataGrid dgUnTicked2 = this._dgUnTicked;
        if (dgUnTicked2 == null)
          return;
        dgUnTicked2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgPostalRegions
    {
      get
      {
        return this._dgPostalRegions;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgPostalRegions_Click);
        DataGrid dgPostalRegions1 = this._dgPostalRegions;
        if (dgPostalRegions1 != null)
          dgPostalRegions1.Click -= eventHandler;
        this._dgPostalRegions = value;
        DataGrid dgPostalRegions2 = this._dgPostalRegions;
        if (dgPostalRegions2 == null)
          return;
        dgPostalRegions2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboQualificationType
    {
      get
      {
        return this._cboQualificationType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboQualificationType_SelectedIndexChanged);
        ComboBox qualificationType1 = this._cboQualificationType;
        if (qualificationType1 != null)
          qualificationType1.SelectedIndexChanged -= eventHandler;
        this._cboQualificationType = value;
        ComboBox qualificationType2 = this._cboQualificationType;
        if (qualificationType2 == null)
          return;
        qualificationType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblQualificationType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTaxRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtName = new TextBox();
      this.lblName = new Label();
      this.txtAddress1 = new TextBox();
      this.lblAddress1 = new Label();
      this.txtAddress2 = new TextBox();
      this.lblAddress2 = new Label();
      this.txtAddress3 = new TextBox();
      this.lblAddress3 = new Label();
      this.txtAddress4 = new TextBox();
      this.lblAddress4 = new Label();
      this.txtAddress5 = new TextBox();
      this.lblAddress5 = new Label();
      this.txtPostcode = new TextBox();
      this.lblPostcode = new Label();
      this.txtTelephoneNum = new TextBox();
      this.lblTelephoneNum = new Label();
      this.txtFaxNum = new TextBox();
      this.lblFaxNum = new Label();
      this.txtEmailAddress = new TextBox();
      this.lblEmailAddress = new Label();
      this.txtNotes = new TextBox();
      this.TabControl1 = new TabControl();
      this.tpContact = new TabPage();
      this.cboTaxRate = new ComboBox();
      this.Label3 = new Label();
      this.cboLinkToSupplier = new ComboBox();
      this.lblLinkToSupplier = new Label();
      this.lblNotes = new Label();
      this.tpMain = new TabPage();
      this.grpEngineer = new GroupBox();
      this.cboUser = new ComboBox();
      this.txtOftecNo = new TextBox();
      this.txtTechnician = new TextBox();
      this.txtGasSafeNo = new TextBox();
      this.txtEngineerID = new TextBox();
      this.lblOftecNo = new Label();
      this.lblDepartment = new Label();
      this.lblManager = new Label();
      this.lblTechnician = new Label();
      this.cboEngineerGroup = new ComboBox();
      this.Label37 = new Label();
      this.lblGasSafeId = new Label();
      this.lblEngID = new Label();
      this.dtpDrivingLicenceIssueDate = new DateTimePicker();
      this.lblDrivingLicenseDate = new Label();
      this.txtDrivingLicenceNo = new TextBox();
      this.lblDrivingLicense = new Label();
      this.txtStartingDetails = new TextBox();
      this.lblStartDetails = new Label();
      this.txtNextOfKinContact = new TextBox();
      this.lblNextOfKinDetails = new Label();
      this.txtNextOfKinName = new TextBox();
      this.lblNextOfKin = new Label();
      this.btnVanHistory = new Button();
      this.txtPDAID = new TextBox();
      this.cboRegion = new ComboBox();
      this.lblRegion = new Label();
      this.lblPDAID = new Label();
      this.chkApprentice = new CheckBox();
      this.tabMaxSor = new TabPage();
      this.GroupBox8 = new GroupBox();
      this.txtBreakPri = new TextBox();
      this.txtServPri = new TextBox();
      this.Label40 = new Label();
      this.Label39 = new Label();
      this.txtDailyServiceLimit = new TextBox();
      this.Label42 = new Label();
      this.txtSundayValue = new TextBox();
      this.txtSaturdayValue = new TextBox();
      this.txtFridayValue = new TextBox();
      this.txtThursdayValue = new TextBox();
      this.txtWednesdayValue = new TextBox();
      this.txtTuesdayValue = new TextBox();
      this.txtMondayValue = new TextBox();
      this.Label43 = new Label();
      this.Label44 = new Label();
      this.Label45 = new Label();
      this.Label46 = new Label();
      this.Label47 = new Label();
      this.Label48 = new Label();
      this.Label49 = new Label();
      this.tpWages = new TabPage();
      this.GroupBox3 = new GroupBox();
      this.Label11 = new Label();
      this.txtCostToCompanyDouble = new TextBox();
      this.Label12 = new Label();
      this.txtCostToCompanyTimeHalf = new TextBox();
      this.Label13 = new Label();
      this.txtCostToCompanyNormal = new TextBox();
      this.GroupBox1 = new GroupBox();
      this.txtNINumber = new TextBox();
      this.Label14 = new Label();
      this.cboPayGrade = new ComboBox();
      this.Label15 = new Label();
      this.txtAnnualSalary = new TextBox();
      this.Label16 = new Label();
      this.tpTrainingQualifications = new TabPage();
      this.GroupBox5 = new GroupBox();
      this.Panel1 = new Panel();
      this.cboQualificationType = new ComboBox();
      this.lblQualificationType = new Label();
      this.dtpQualificationBooked = new DateTimePicker();
      this.Label36 = new Label();
      this.cboQualification = new ComboBox();
      this.Label22 = new Label();
      this.txtQualificatioNote = new TextBox();
      this.Label17 = new Label();
      this.btnSaveQualification = new Button();
      this.dtpQualificationExpires = new DateTimePicker();
      this.Label18 = new Label();
      this.dtpQualificationPassed = new DateTimePicker();
      this.Label19 = new Label();
      this.btnRemoveTrainingQualifications = new Button();
      this.dgTrainingQualifications = new DataGrid();
      this.tpKit = new TabPage();
      this.GroupBox4 = new GroupBox();
      this.Panel2 = new Panel();
      this.txtEquipmentTool = new TextBox();
      this.Label20 = new Label();
      this.btnSaveEquipment = new Button();
      this.btnRemoveEngineerEquipment = new Button();
      this.dgEquipment = new DataGrid();
      this.tpDisciplinary = new TabPage();
      this.GroupBox6 = new GroupBox();
      this.btnAddDisciplinaries = new Button();
      this.Panel3 = new Panel();
      this.txtDisciplinaryID = new TextBox();
      this.cboDisciplinary = new ComboBox();
      this.btnSaveDisciplinaries = new Button();
      this.Label21 = new Label();
      this.dtpDisciplinaryIssued = new DateTimePicker();
      this.Label23 = new Label();
      this.txtDisciplinary = new TextBox();
      this.Label24 = new Label();
      this.btnRemoveDisciplinaries = new Button();
      this.btnEditDisciplinaries = new Button();
      this.dgDisciplinaries = new DataGrid();
      this.tpDocuments = new TabPage();
      this.pnlDocuments = new Panel();
      this.tpHolidayAbsences = new TabPage();
      this.grpAbsences = new GroupBox();
      this.dgAbsences = new DataGrid();
      this.GroupBox7 = new GroupBox();
      this.txtDaysHolidayAllowed = new TextBox();
      this.Label25 = new Label();
      this.txtHolidayYearEnd = new TextBox();
      this.Label26 = new Label();
      this.txtHolidayYearStart = new TextBox();
      this.Label27 = new Label();
      this.tpPostalRegions = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.Button1 = new Button();
      this.TextBox1 = new TextBox();
      this.Label1 = new Label();
      this.grpPostalRegions = new GroupBox();
      this.Label38 = new Label();
      this.txtPCSearch = new TextBox();
      this.Label2 = new Label();
      this.dgUnTicked = new DataGrid();
      this.dgPostalRegions = new DataGrid();
      this.cboDepartment = new ComboBox();
      this.TabControl1.SuspendLayout();
      this.tpContact.SuspendLayout();
      this.tpMain.SuspendLayout();
      this.grpEngineer.SuspendLayout();
      this.tabMaxSor.SuspendLayout();
      this.GroupBox8.SuspendLayout();
      this.tpWages.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.tpTrainingQualifications.SuspendLayout();
      this.GroupBox5.SuspendLayout();
      this.Panel1.SuspendLayout();
      this.dgTrainingQualifications.BeginInit();
      this.tpKit.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.dgEquipment.BeginInit();
      this.tpDisciplinary.SuspendLayout();
      this.GroupBox6.SuspendLayout();
      this.Panel3.SuspendLayout();
      this.dgDisciplinaries.BeginInit();
      this.tpDocuments.SuspendLayout();
      this.tpHolidayAbsences.SuspendLayout();
      this.grpAbsences.SuspendLayout();
      this.dgAbsences.BeginInit();
      this.GroupBox7.SuspendLayout();
      this.tpPostalRegions.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.grpPostalRegions.SuspendLayout();
      this.dgUnTicked.BeginInit();
      this.dgPostalRegions.BeginInit();
      this.SuspendLayout();
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(112, 16);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(504, 21);
      this.txtName.TabIndex = 1;
      this.txtName.Tag = (object) "Subcontractor.Name";
      this.lblName.Location = new System.Drawing.Point(8, 16);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(53, 20);
      this.lblName.TabIndex = 31;
      this.lblName.Text = "Name";
      this.txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress1.Location = new System.Drawing.Point(112, 48);
      this.txtAddress1.MaxLength = (int) byte.MaxValue;
      this.txtAddress1.Name = "txtAddress1";
      this.txtAddress1.Size = new Size(504, 21);
      this.txtAddress1.TabIndex = 2;
      this.txtAddress1.Tag = (object) "Subcontractor.Address1";
      this.lblAddress1.Location = new System.Drawing.Point(8, 48);
      this.lblAddress1.Name = "lblAddress1";
      this.lblAddress1.Size = new Size(78, 20);
      this.lblAddress1.TabIndex = 31;
      this.lblAddress1.Text = "Address 1";
      this.txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress2.Location = new System.Drawing.Point(112, 80);
      this.txtAddress2.MaxLength = (int) byte.MaxValue;
      this.txtAddress2.Name = "txtAddress2";
      this.txtAddress2.Size = new Size(504, 21);
      this.txtAddress2.TabIndex = 3;
      this.txtAddress2.Tag = (object) "Subcontractor.Address2";
      this.lblAddress2.Location = new System.Drawing.Point(8, 80);
      this.lblAddress2.Name = "lblAddress2";
      this.lblAddress2.Size = new Size(73, 20);
      this.lblAddress2.TabIndex = 31;
      this.lblAddress2.Text = "Address 2";
      this.txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress3.Location = new System.Drawing.Point(112, 112);
      this.txtAddress3.MaxLength = (int) byte.MaxValue;
      this.txtAddress3.Name = "txtAddress3";
      this.txtAddress3.Size = new Size(504, 21);
      this.txtAddress3.TabIndex = 4;
      this.txtAddress3.Tag = (object) "Subcontractor.Address3";
      this.lblAddress3.Location = new System.Drawing.Point(8, 112);
      this.lblAddress3.Name = "lblAddress3";
      this.lblAddress3.Size = new Size(66, 20);
      this.lblAddress3.TabIndex = 31;
      this.lblAddress3.Text = "Address 3";
      this.txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress4.Location = new System.Drawing.Point(112, 144);
      this.txtAddress4.MaxLength = (int) byte.MaxValue;
      this.txtAddress4.Name = "txtAddress4";
      this.txtAddress4.Size = new Size(504, 21);
      this.txtAddress4.TabIndex = 5;
      this.txtAddress4.Tag = (object) "Subcontractor.Address4";
      this.lblAddress4.Location = new System.Drawing.Point(8, 144);
      this.lblAddress4.Name = "lblAddress4";
      this.lblAddress4.Size = new Size(67, 20);
      this.lblAddress4.TabIndex = 31;
      this.lblAddress4.Text = "Address 4";
      this.txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress5.Location = new System.Drawing.Point(112, 176);
      this.txtAddress5.MaxLength = (int) byte.MaxValue;
      this.txtAddress5.Name = "txtAddress5";
      this.txtAddress5.Size = new Size(504, 21);
      this.txtAddress5.TabIndex = 6;
      this.txtAddress5.Tag = (object) "Subcontractor.Address5";
      this.lblAddress5.Location = new System.Drawing.Point(8, 176);
      this.lblAddress5.Name = "lblAddress5";
      this.lblAddress5.Size = new Size(79, 20);
      this.lblAddress5.TabIndex = 31;
      this.lblAddress5.Text = "Address 5";
      this.txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPostcode.Location = new System.Drawing.Point(112, 208);
      this.txtPostcode.MaxLength = 20;
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(504, 21);
      this.txtPostcode.TabIndex = 7;
      this.txtPostcode.Tag = (object) "Subcontractor.Postcode";
      this.lblPostcode.Location = new System.Drawing.Point(8, 208);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(72, 20);
      this.lblPostcode.TabIndex = 31;
      this.lblPostcode.Text = "Postcode";
      this.txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTelephoneNum.Location = new System.Drawing.Point(112, 240);
      this.txtTelephoneNum.MaxLength = 50;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.Size = new Size(504, 21);
      this.txtTelephoneNum.TabIndex = 8;
      this.txtTelephoneNum.Tag = (object) "Subcontractor.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(8, 240);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(113, 20);
      this.lblTelephoneNum.TabIndex = 31;
      this.lblTelephoneNum.Text = "Telephone";
      this.txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFaxNum.Location = new System.Drawing.Point(112, 272);
      this.txtFaxNum.MaxLength = 50;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.Size = new Size(504, 21);
      this.txtFaxNum.TabIndex = 9;
      this.txtFaxNum.Tag = (object) "Subcontractor.FaxNum";
      this.lblFaxNum.Location = new System.Drawing.Point(8, 272);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(73, 20);
      this.lblFaxNum.TabIndex = 31;
      this.lblFaxNum.Text = "Fax";
      this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmailAddress.Location = new System.Drawing.Point(112, 304);
      this.txtEmailAddress.MaxLength = (int) byte.MaxValue;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(504, 21);
      this.txtEmailAddress.TabIndex = 10;
      this.txtEmailAddress.Tag = (object) "Subcontractor.EmailAddress";
      this.lblEmailAddress.Location = new System.Drawing.Point(8, 304);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(103, 20);
      this.lblEmailAddress.TabIndex = 31;
      this.lblEmailAddress.Text = "Email Address";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(112, 409);
      this.txtNotes.MaxLength = 0;
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(504, 194);
      this.txtNotes.TabIndex = 13;
      this.txtNotes.Tag = (object) "Subcontractor.Notes";
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tpContact);
      this.TabControl1.Controls.Add((Control) this.tpMain);
      this.TabControl1.Controls.Add((Control) this.tabMaxSor);
      this.TabControl1.Controls.Add((Control) this.tpWages);
      this.TabControl1.Controls.Add((Control) this.tpTrainingQualifications);
      this.TabControl1.Controls.Add((Control) this.tpKit);
      this.TabControl1.Controls.Add((Control) this.tpDisciplinary);
      this.TabControl1.Controls.Add((Control) this.tpDocuments);
      this.TabControl1.Controls.Add((Control) this.tpHolidayAbsences);
      this.TabControl1.Controls.Add((Control) this.tpPostalRegions);
      this.TabControl1.Location = new System.Drawing.Point(0, 0);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(632, 648);
      this.TabControl1.TabIndex = 2;
      this.tpContact.Controls.Add((Control) this.cboTaxRate);
      this.tpContact.Controls.Add((Control) this.Label3);
      this.tpContact.Controls.Add((Control) this.cboLinkToSupplier);
      this.tpContact.Controls.Add((Control) this.lblLinkToSupplier);
      this.tpContact.Controls.Add((Control) this.lblNotes);
      this.tpContact.Controls.Add((Control) this.lblFaxNum);
      this.tpContact.Controls.Add((Control) this.txtEmailAddress);
      this.tpContact.Controls.Add((Control) this.lblEmailAddress);
      this.tpContact.Controls.Add((Control) this.txtNotes);
      this.tpContact.Controls.Add((Control) this.txtName);
      this.tpContact.Controls.Add((Control) this.lblName);
      this.tpContact.Controls.Add((Control) this.txtAddress1);
      this.tpContact.Controls.Add((Control) this.lblAddress1);
      this.tpContact.Controls.Add((Control) this.txtAddress2);
      this.tpContact.Controls.Add((Control) this.lblAddress2);
      this.tpContact.Controls.Add((Control) this.txtAddress3);
      this.tpContact.Controls.Add((Control) this.lblAddress3);
      this.tpContact.Controls.Add((Control) this.txtAddress4);
      this.tpContact.Controls.Add((Control) this.lblAddress4);
      this.tpContact.Controls.Add((Control) this.txtAddress5);
      this.tpContact.Controls.Add((Control) this.lblAddress5);
      this.tpContact.Controls.Add((Control) this.txtPostcode);
      this.tpContact.Controls.Add((Control) this.lblPostcode);
      this.tpContact.Controls.Add((Control) this.txtTelephoneNum);
      this.tpContact.Controls.Add((Control) this.lblTelephoneNum);
      this.tpContact.Controls.Add((Control) this.txtFaxNum);
      this.tpContact.Location = new System.Drawing.Point(4, 22);
      this.tpContact.Name = "tpContact";
      this.tpContact.Size = new Size(624, 622);
      this.tpContact.TabIndex = 8;
      this.tpContact.Text = "Contact Details";
      this.cboTaxRate.FormattingEnabled = true;
      this.cboTaxRate.Location = new System.Drawing.Point(112, 372);
      this.cboTaxRate.Name = "cboTaxRate";
      this.cboTaxRate.Size = new Size(504, 21);
      this.cboTaxRate.TabIndex = 38;
      this.Label3.Location = new System.Drawing.Point(8, 375);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(98, 20);
      this.Label3.TabIndex = 37;
      this.Label3.Text = "Tax Rate";
      this.cboLinkToSupplier.FormattingEnabled = true;
      this.cboLinkToSupplier.Location = new System.Drawing.Point(112, 338);
      this.cboLinkToSupplier.Name = "cboLinkToSupplier";
      this.cboLinkToSupplier.Size = new Size(504, 21);
      this.cboLinkToSupplier.TabIndex = 36;
      this.lblLinkToSupplier.Location = new System.Drawing.Point(8, 341);
      this.lblLinkToSupplier.Name = "lblLinkToSupplier";
      this.lblLinkToSupplier.Size = new Size(103, 20);
      this.lblLinkToSupplier.TabIndex = 35;
      this.lblLinkToSupplier.Text = "Link To Supplier";
      this.lblNotes.Location = new System.Drawing.Point(8, 412);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(103, 20);
      this.lblNotes.TabIndex = 32;
      this.lblNotes.Text = "Notes";
      this.tpMain.Controls.Add((Control) this.grpEngineer);
      this.tpMain.Location = new System.Drawing.Point(4, 22);
      this.tpMain.Name = "tpMain";
      this.tpMain.Size = new Size(624, 622);
      this.tpMain.TabIndex = 0;
      this.tpMain.Text = "Engineer Details";
      this.grpEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineer.Controls.Add((Control) this.cboDepartment);
      this.grpEngineer.Controls.Add((Control) this.cboUser);
      this.grpEngineer.Controls.Add((Control) this.txtOftecNo);
      this.grpEngineer.Controls.Add((Control) this.txtTechnician);
      this.grpEngineer.Controls.Add((Control) this.txtGasSafeNo);
      this.grpEngineer.Controls.Add((Control) this.txtEngineerID);
      this.grpEngineer.Controls.Add((Control) this.lblOftecNo);
      this.grpEngineer.Controls.Add((Control) this.lblDepartment);
      this.grpEngineer.Controls.Add((Control) this.lblManager);
      this.grpEngineer.Controls.Add((Control) this.lblTechnician);
      this.grpEngineer.Controls.Add((Control) this.cboEngineerGroup);
      this.grpEngineer.Controls.Add((Control) this.Label37);
      this.grpEngineer.Controls.Add((Control) this.lblGasSafeId);
      this.grpEngineer.Controls.Add((Control) this.lblEngID);
      this.grpEngineer.Controls.Add((Control) this.dtpDrivingLicenceIssueDate);
      this.grpEngineer.Controls.Add((Control) this.lblDrivingLicenseDate);
      this.grpEngineer.Controls.Add((Control) this.txtDrivingLicenceNo);
      this.grpEngineer.Controls.Add((Control) this.lblDrivingLicense);
      this.grpEngineer.Controls.Add((Control) this.txtStartingDetails);
      this.grpEngineer.Controls.Add((Control) this.lblStartDetails);
      this.grpEngineer.Controls.Add((Control) this.txtNextOfKinContact);
      this.grpEngineer.Controls.Add((Control) this.lblNextOfKinDetails);
      this.grpEngineer.Controls.Add((Control) this.txtNextOfKinName);
      this.grpEngineer.Controls.Add((Control) this.lblNextOfKin);
      this.grpEngineer.Controls.Add((Control) this.btnVanHistory);
      this.grpEngineer.Controls.Add((Control) this.txtPDAID);
      this.grpEngineer.Controls.Add((Control) this.cboRegion);
      this.grpEngineer.Controls.Add((Control) this.lblRegion);
      this.grpEngineer.Controls.Add((Control) this.lblPDAID);
      this.grpEngineer.Controls.Add((Control) this.chkApprentice);
      this.grpEngineer.Location = new System.Drawing.Point(8, 0);
      this.grpEngineer.Name = "grpEngineer";
      this.grpEngineer.Size = new Size(608, 616);
      this.grpEngineer.TabIndex = 0;
      this.grpEngineer.TabStop = false;
      this.grpEngineer.Text = "Details";
      this.cboUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboUser.Cursor = Cursors.Hand;
      this.cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboUser.Location = new System.Drawing.Point(121, 172);
      this.cboUser.Name = "cboUser";
      this.cboUser.Size = new Size(470, 21);
      this.cboUser.TabIndex = 72;
      this.cboUser.Tag = (object) "";
      this.txtOftecNo.Location = new System.Drawing.Point(512, 18);
      this.txtOftecNo.Name = "txtOftecNo";
      this.txtOftecNo.Size = new Size(79, 21);
      this.txtOftecNo.TabIndex = 70;
      this.txtOftecNo.Tag = (object) "Engineer.Name";
      this.txtTechnician.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTechnician.Location = new System.Drawing.Point(121, 134);
      this.txtTechnician.Name = "txtTechnician";
      this.txtTechnician.Size = new Size(470, 21);
      this.txtTechnician.TabIndex = 61;
      this.txtTechnician.Tag = (object) "";
      this.txtGasSafeNo.Location = new System.Drawing.Point(333, 18);
      this.txtGasSafeNo.Name = "txtGasSafeNo";
      this.txtGasSafeNo.Size = new Size(79, 21);
      this.txtGasSafeNo.TabIndex = 59;
      this.txtGasSafeNo.Tag = (object) "Engineer.Name";
      this.txtEngineerID.Location = new System.Drawing.Point(121, 20);
      this.txtEngineerID.Name = "txtEngineerID";
      this.txtEngineerID.ReadOnly = true;
      this.txtEngineerID.Size = new Size(79, 21);
      this.txtEngineerID.TabIndex = 62;
      this.txtEngineerID.TabStop = false;
      this.lblOftecNo.Location = new System.Drawing.Point(438, 21);
      this.lblOftecNo.Name = "lblOftecNo";
      this.lblOftecNo.Size = new Size(68, 20);
      this.lblOftecNo.TabIndex = 71;
      this.lblOftecNo.Text = "Oftec No.";
      this.lblDepartment.Location = new System.Drawing.Point(5, 99);
      this.lblDepartment.Name = "lblDepartment";
      this.lblDepartment.Size = new Size(104, 20);
      this.lblDepartment.TabIndex = 69;
      this.lblDepartment.Text = "Department";
      this.lblManager.Location = new System.Drawing.Point(5, 175);
      this.lblManager.Name = "lblManager";
      this.lblManager.Size = new Size(104, 20);
      this.lblManager.TabIndex = 67;
      this.lblManager.Text = "Manager";
      this.lblTechnician.Location = new System.Drawing.Point(6, 137);
      this.lblTechnician.Name = "lblTechnician";
      this.lblTechnician.Size = new Size(104, 20);
      this.lblTechnician.TabIndex = 66;
      this.lblTechnician.Text = "Technician";
      this.cboEngineerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineerGroup.Cursor = Cursors.Hand;
      this.cboEngineerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEngineerGroup.Location = new System.Drawing.Point(121, 58);
      this.cboEngineerGroup.Name = "cboEngineerGroup";
      this.cboEngineerGroup.Size = new Size(470, 21);
      this.cboEngineerGroup.TabIndex = 60;
      this.cboEngineerGroup.Tag = (object) "";
      this.Label37.Location = new System.Drawing.Point(5, 61);
      this.Label37.Name = "Label37";
      this.Label37.Size = new Size(105, 20);
      this.Label37.TabIndex = 65;
      this.Label37.Text = "Engineer Group";
      this.lblGasSafeId.Location = new System.Drawing.Point(223, 23);
      this.lblGasSafeId.Name = "lblGasSafeId";
      this.lblGasSafeId.Size = new Size(90, 20);
      this.lblGasSafeId.TabIndex = 64;
      this.lblGasSafeId.Text = "Gas Safe No.";
      this.lblEngID.Location = new System.Drawing.Point(6, 23);
      this.lblEngID.Name = "lblEngID";
      this.lblEngID.Size = new Size(94, 20);
      this.lblEngID.TabIndex = 63;
      this.lblEngID.Text = "Engineer ID";
      this.dtpDrivingLicenceIssueDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpDrivingLicenceIssueDate.Checked = false;
      this.dtpDrivingLicenceIssueDate.Location = new System.Drawing.Point(441, 377);
      this.dtpDrivingLicenceIssueDate.Name = "dtpDrivingLicenceIssueDate";
      this.dtpDrivingLicenceIssueDate.ShowCheckBox = true;
      this.dtpDrivingLicenceIssueDate.Size = new Size(150, 21);
      this.dtpDrivingLicenceIssueDate.TabIndex = 7;
      this.lblDrivingLicenseDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblDrivingLicenseDate.Location = new System.Drawing.Point(359, 380);
      this.lblDrivingLicenseDate.Name = "lblDrivingLicenseDate";
      this.lblDrivingLicenseDate.Size = new Size(112, 20);
      this.lblDrivingLicenseDate.TabIndex = 41;
      this.lblDrivingLicenseDate.Text = "Issued Date";
      this.txtDrivingLicenceNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDrivingLicenceNo.Location = new System.Drawing.Point(121, 377);
      this.txtDrivingLicenceNo.Name = "txtDrivingLicenceNo";
      this.txtDrivingLicenceNo.Size = new Size(232, 21);
      this.txtDrivingLicenceNo.TabIndex = 6;
      this.lblDrivingLicense.Location = new System.Drawing.Point(6, 380);
      this.lblDrivingLicense.Name = "lblDrivingLicense";
      this.lblDrivingLicense.Size = new Size(112, 20);
      this.lblDrivingLicense.TabIndex = 39;
      this.lblDrivingLicense.Text = "Driving Licence No";
      this.txtStartingDetails.AcceptsReturn = true;
      this.txtStartingDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtStartingDetails.Location = new System.Drawing.Point(121, 286);
      this.txtStartingDetails.Multiline = true;
      this.txtStartingDetails.Name = "txtStartingDetails";
      this.txtStartingDetails.ScrollBars = ScrollBars.Vertical;
      this.txtStartingDetails.Size = new Size(470, 74);
      this.txtStartingDetails.TabIndex = 5;
      this.lblStartDetails.Location = new System.Drawing.Point(6, 289);
      this.lblStartDetails.Name = "lblStartDetails";
      this.lblStartDetails.Size = new Size(105, 20);
      this.lblStartDetails.TabIndex = 37;
      this.lblStartDetails.Text = "Starting Details";
      this.txtNextOfKinContact.AcceptsReturn = true;
      this.txtNextOfKinContact.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNextOfKinContact.Location = new System.Drawing.Point(117, 494);
      this.txtNextOfKinContact.Multiline = true;
      this.txtNextOfKinContact.Name = "txtNextOfKinContact";
      this.txtNextOfKinContact.ScrollBars = ScrollBars.Vertical;
      this.txtNextOfKinContact.Size = new Size(474, 63);
      this.txtNextOfKinContact.TabIndex = 10;
      this.lblNextOfKinDetails.Location = new System.Drawing.Point(5, 497);
      this.lblNextOfKinDetails.Name = "lblNextOfKinDetails";
      this.lblNextOfKinDetails.Size = new Size(112, 20);
      this.lblNextOfKinDetails.TabIndex = 35;
      this.lblNextOfKinDetails.Text = "Next of Kin Details";
      this.txtNextOfKinName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNextOfKinName.Location = new System.Drawing.Point(117, 456);
      this.txtNextOfKinName.Name = "txtNextOfKinName";
      this.txtNextOfKinName.Size = new Size(474, 21);
      this.txtNextOfKinName.TabIndex = 9;
      this.lblNextOfKin.Location = new System.Drawing.Point(6, 459);
      this.lblNextOfKin.Name = "lblNextOfKin";
      this.lblNextOfKin.Size = new Size(112, 20);
      this.lblNextOfKin.TabIndex = 33;
      this.lblNextOfKin.Text = "Next of Kin Name";
      this.btnVanHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnVanHistory.Location = new System.Drawing.Point(512, 584);
      this.btnVanHistory.Name = "btnVanHistory";
      this.btnVanHistory.Size = new Size(88, 23);
      this.btnVanHistory.TabIndex = 11;
      this.btnVanHistory.Text = "Van History";
      this.txtPDAID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPDAID.Location = new System.Drawing.Point(121, 248);
      this.txtPDAID.Name = "txtPDAID";
      this.txtPDAID.Size = new Size(470, 21);
      this.txtPDAID.TabIndex = 4;
      this.cboRegion.Cursor = Cursors.Hand;
      this.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegion.Location = new System.Drawing.Point(121, 210);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(470, 21);
      this.cboRegion.TabIndex = 1;
      this.cboRegion.Tag = (object) "Engineer.RegionID";
      this.lblRegion.Location = new System.Drawing.Point(5, 213);
      this.lblRegion.Name = "lblRegion";
      this.lblRegion.Size = new Size(64, 20);
      this.lblRegion.TabIndex = 31;
      this.lblRegion.Text = "Region";
      this.lblPDAID.Location = new System.Drawing.Point(6, 251);
      this.lblPDAID.Name = "lblPDAID";
      this.lblPDAID.Size = new Size(64, 20);
      this.lblPDAID.TabIndex = 31;
      this.lblPDAID.Text = "PDA ID";
      this.chkApprentice.Font = new Font("Verdana", 8f);
      this.chkApprentice.Location = new System.Drawing.Point(121, 415);
      this.chkApprentice.Name = "chkApprentice";
      this.chkApprentice.Size = new Size(112, 24);
      this.chkApprentice.TabIndex = 8;
      this.chkApprentice.Tag = (object) "Engineer.Apprentice";
      this.chkApprentice.Text = "Apprentice";
      this.tabMaxSor.Controls.Add((Control) this.GroupBox8);
      this.tabMaxSor.Location = new System.Drawing.Point(4, 22);
      this.tabMaxSor.Name = "tabMaxSor";
      this.tabMaxSor.Size = new Size(624, 622);
      this.tabMaxSor.TabIndex = 10;
      this.tabMaxSor.Text = "Max SOR";
      this.tabMaxSor.UseVisualStyleBackColor = true;
      this.GroupBox8.BackColor = SystemColors.Control;
      this.GroupBox8.Controls.Add((Control) this.txtBreakPri);
      this.GroupBox8.Controls.Add((Control) this.txtServPri);
      this.GroupBox8.Controls.Add((Control) this.Label40);
      this.GroupBox8.Controls.Add((Control) this.Label39);
      this.GroupBox8.Controls.Add((Control) this.txtDailyServiceLimit);
      this.GroupBox8.Controls.Add((Control) this.Label42);
      this.GroupBox8.Controls.Add((Control) this.txtSundayValue);
      this.GroupBox8.Controls.Add((Control) this.txtSaturdayValue);
      this.GroupBox8.Controls.Add((Control) this.txtFridayValue);
      this.GroupBox8.Controls.Add((Control) this.txtThursdayValue);
      this.GroupBox8.Controls.Add((Control) this.txtWednesdayValue);
      this.GroupBox8.Controls.Add((Control) this.txtTuesdayValue);
      this.GroupBox8.Controls.Add((Control) this.txtMondayValue);
      this.GroupBox8.Controls.Add((Control) this.Label43);
      this.GroupBox8.Controls.Add((Control) this.Label44);
      this.GroupBox8.Controls.Add((Control) this.Label45);
      this.GroupBox8.Controls.Add((Control) this.Label46);
      this.GroupBox8.Controls.Add((Control) this.Label47);
      this.GroupBox8.Controls.Add((Control) this.Label48);
      this.GroupBox8.Controls.Add((Control) this.Label49);
      this.GroupBox8.Dock = DockStyle.Fill;
      this.GroupBox8.Location = new System.Drawing.Point(0, 0);
      this.GroupBox8.Name = "GroupBox8";
      this.GroupBox8.Size = new Size(624, 622);
      this.GroupBox8.TabIndex = 1;
      this.GroupBox8.TabStop = false;
      this.GroupBox8.Text = "Max Schedule Of Rate Times Per Day (In minutes)";
      this.txtBreakPri.Location = new System.Drawing.Point(193, 262);
      this.txtBreakPri.Name = "txtBreakPri";
      this.txtBreakPri.Size = new Size(41, 21);
      this.txtBreakPri.TabIndex = 80;
      this.txtServPri.Location = new System.Drawing.Point(193, 235);
      this.txtServPri.Name = "txtServPri";
      this.txtServPri.Size = new Size(41, 21);
      this.txtServPri.TabIndex = 78;
      this.Label40.Location = new System.Drawing.Point(28, 265);
      this.Label40.Name = "Label40";
      this.Label40.Size = new Size(167, 29);
      this.Label40.TabIndex = 79;
      this.Label40.Text = "Breakdown Priority (1-10)";
      this.Label39.Location = new System.Drawing.Point(28, 238);
      this.Label39.Name = "Label39";
      this.Label39.Size = new Size(159, 29);
      this.Label39.TabIndex = 77;
      this.Label39.Text = "Service Priority (1-10)";
      this.txtDailyServiceLimit.Location = new System.Drawing.Point(193, 209);
      this.txtDailyServiceLimit.Name = "txtDailyServiceLimit";
      this.txtDailyServiceLimit.Size = new Size(131, 21);
      this.txtDailyServiceLimit.TabIndex = 15;
      this.Label42.AutoSize = true;
      this.Label42.Location = new System.Drawing.Point(28, 212);
      this.Label42.Name = "Label42";
      this.Label42.Size = new Size(114, 13);
      this.Label42.TabIndex = 14;
      this.Label42.Text = "Daily Service Limit";
      this.txtSundayValue.Location = new System.Drawing.Point(193, 183);
      this.txtSundayValue.Name = "txtSundayValue";
      this.txtSundayValue.Size = new Size(131, 21);
      this.txtSundayValue.TabIndex = 13;
      this.txtSaturdayValue.Location = new System.Drawing.Point(193, 157);
      this.txtSaturdayValue.Name = "txtSaturdayValue";
      this.txtSaturdayValue.Size = new Size(131, 21);
      this.txtSaturdayValue.TabIndex = 12;
      this.txtFridayValue.Location = new System.Drawing.Point(193, 131);
      this.txtFridayValue.Name = "txtFridayValue";
      this.txtFridayValue.Size = new Size(131, 21);
      this.txtFridayValue.TabIndex = 11;
      this.txtThursdayValue.Location = new System.Drawing.Point(193, 105);
      this.txtThursdayValue.Name = "txtThursdayValue";
      this.txtThursdayValue.Size = new Size(131, 21);
      this.txtThursdayValue.TabIndex = 10;
      this.txtWednesdayValue.Location = new System.Drawing.Point(193, 79);
      this.txtWednesdayValue.Name = "txtWednesdayValue";
      this.txtWednesdayValue.Size = new Size(131, 21);
      this.txtWednesdayValue.TabIndex = 9;
      this.txtTuesdayValue.Location = new System.Drawing.Point(193, 53);
      this.txtTuesdayValue.Name = "txtTuesdayValue";
      this.txtTuesdayValue.Size = new Size(131, 21);
      this.txtTuesdayValue.TabIndex = 8;
      this.txtMondayValue.Location = new System.Drawing.Point(193, 27);
      this.txtMondayValue.Name = "txtMondayValue";
      this.txtMondayValue.Size = new Size(131, 21);
      this.txtMondayValue.TabIndex = 7;
      this.Label43.AutoSize = true;
      this.Label43.Location = new System.Drawing.Point(28, 186);
      this.Label43.Name = "Label43";
      this.Label43.Size = new Size(50, 13);
      this.Label43.TabIndex = 6;
      this.Label43.Text = "Sunday";
      this.Label44.AutoSize = true;
      this.Label44.Location = new System.Drawing.Point(28, 160);
      this.Label44.Name = "Label44";
      this.Label44.Size = new Size(59, 13);
      this.Label44.TabIndex = 5;
      this.Label44.Text = "Saturday";
      this.Label45.AutoSize = true;
      this.Label45.Location = new System.Drawing.Point(28, 134);
      this.Label45.Name = "Label45";
      this.Label45.Size = new Size(42, 13);
      this.Label45.TabIndex = 4;
      this.Label45.Text = "Friday";
      this.Label46.AutoSize = true;
      this.Label46.Location = new System.Drawing.Point(28, 108);
      this.Label46.Name = "Label46";
      this.Label46.Size = new Size(60, 13);
      this.Label46.TabIndex = 3;
      this.Label46.Text = "Thursday";
      this.Label47.AutoSize = true;
      this.Label47.Location = new System.Drawing.Point(28, 82);
      this.Label47.Name = "Label47";
      this.Label47.Size = new Size(72, 13);
      this.Label47.TabIndex = 2;
      this.Label47.Text = "Wednesday";
      this.Label48.AutoSize = true;
      this.Label48.Location = new System.Drawing.Point(28, 56);
      this.Label48.Name = "Label48";
      this.Label48.Size = new Size(54, 13);
      this.Label48.TabIndex = 1;
      this.Label48.Text = "Tuesday";
      this.Label49.AutoSize = true;
      this.Label49.Location = new System.Drawing.Point(28, 30);
      this.Label49.Name = "Label49";
      this.Label49.Size = new Size(51, 13);
      this.Label49.TabIndex = 0;
      this.Label49.Text = "Monday";
      this.tpWages.Controls.Add((Control) this.GroupBox3);
      this.tpWages.Controls.Add((Control) this.GroupBox1);
      this.tpWages.Location = new System.Drawing.Point(4, 22);
      this.tpWages.Name = "tpWages";
      this.tpWages.Size = new Size(624, 622);
      this.tpWages.TabIndex = 1;
      this.tpWages.Text = "Wages";
      this.tpWages.Visible = false;
      this.GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox3.Controls.Add((Control) this.Label11);
      this.GroupBox3.Controls.Add((Control) this.txtCostToCompanyDouble);
      this.GroupBox3.Controls.Add((Control) this.Label12);
      this.GroupBox3.Controls.Add((Control) this.txtCostToCompanyTimeHalf);
      this.GroupBox3.Controls.Add((Control) this.Label13);
      this.GroupBox3.Controls.Add((Control) this.txtCostToCompanyNormal);
      this.GroupBox3.Location = new System.Drawing.Point(8, 136);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(608, 120);
      this.GroupBox3.TabIndex = 1;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Cost to Company";
      this.Label11.Location = new System.Drawing.Point(16, 24);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(88, 20);
      this.Label11.TabIndex = 55;
      this.Label11.Text = "Normal";
      this.txtCostToCompanyDouble.Location = new System.Drawing.Point(120, 88);
      this.txtCostToCompanyDouble.Name = "txtCostToCompanyDouble";
      this.txtCostToCompanyDouble.Size = new Size(144, 21);
      this.txtCostToCompanyDouble.TabIndex = 6;
      this.Label12.Location = new System.Drawing.Point(16, 88);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(88, 20);
      this.Label12.TabIndex = 54;
      this.Label12.Text = "Double";
      this.txtCostToCompanyTimeHalf.Location = new System.Drawing.Point(120, 56);
      this.txtCostToCompanyTimeHalf.Name = "txtCostToCompanyTimeHalf";
      this.txtCostToCompanyTimeHalf.Size = new Size(144, 21);
      this.txtCostToCompanyTimeHalf.TabIndex = 5;
      this.Label13.Location = new System.Drawing.Point(16, 56);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(88, 20);
      this.Label13.TabIndex = 53;
      this.Label13.Text = "Time && Half";
      this.txtCostToCompanyNormal.Location = new System.Drawing.Point(120, 24);
      this.txtCostToCompanyNormal.Name = "txtCostToCompanyNormal";
      this.txtCostToCompanyNormal.Size = new Size(144, 21);
      this.txtCostToCompanyNormal.TabIndex = 4;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtNINumber);
      this.GroupBox1.Controls.Add((Control) this.Label14);
      this.GroupBox1.Controls.Add((Control) this.cboPayGrade);
      this.GroupBox1.Controls.Add((Control) this.Label15);
      this.GroupBox1.Controls.Add((Control) this.txtAnnualSalary);
      this.GroupBox1.Controls.Add((Control) this.Label16);
      this.GroupBox1.Location = new System.Drawing.Point(8, 8);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(608, 120);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Wages Information";
      this.txtNINumber.Location = new System.Drawing.Point(120, 88);
      this.txtNINumber.Name = "txtNINumber";
      this.txtNINumber.Size = new Size(144, 21);
      this.txtNINumber.TabIndex = 3;
      this.txtNINumber.Tag = (object) "Engineer.Name";
      this.Label14.Location = new System.Drawing.Point(8, 88);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(87, 20);
      this.Label14.TabIndex = 54;
      this.Label14.Text = "NI Number";
      this.cboPayGrade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboPayGrade.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPayGrade.Location = new System.Drawing.Point(120, 28);
      this.cboPayGrade.Name = "cboPayGrade";
      this.cboPayGrade.Size = new Size(480, 21);
      this.cboPayGrade.TabIndex = 1;
      this.Label15.Location = new System.Drawing.Point(8, 24);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(100, 23);
      this.Label15.TabIndex = 51;
      this.Label15.Text = "Pay Grade";
      this.txtAnnualSalary.Location = new System.Drawing.Point(120, 56);
      this.txtAnnualSalary.Name = "txtAnnualSalary";
      this.txtAnnualSalary.Size = new Size(143, 21);
      this.txtAnnualSalary.TabIndex = 2;
      this.txtAnnualSalary.Tag = (object) "Engineer.Name";
      this.Label16.Location = new System.Drawing.Point(9, 56);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(87, 20);
      this.Label16.TabIndex = 50;
      this.Label16.Text = "Annual Salary";
      this.tpTrainingQualifications.Controls.Add((Control) this.GroupBox5);
      this.tpTrainingQualifications.Location = new System.Drawing.Point(4, 22);
      this.tpTrainingQualifications.Name = "tpTrainingQualifications";
      this.tpTrainingQualifications.Size = new Size(624, 622);
      this.tpTrainingQualifications.TabIndex = 3;
      this.tpTrainingQualifications.Text = "Training & Qualifications";
      this.tpTrainingQualifications.Visible = false;
      this.GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox5.Controls.Add((Control) this.Panel1);
      this.GroupBox5.Controls.Add((Control) this.btnRemoveTrainingQualifications);
      this.GroupBox5.Controls.Add((Control) this.dgTrainingQualifications);
      this.GroupBox5.Location = new System.Drawing.Point(8, 8);
      this.GroupBox5.Name = "GroupBox5";
      this.GroupBox5.Size = new Size(608, 608);
      this.GroupBox5.TabIndex = 13;
      this.GroupBox5.TabStop = false;
      this.GroupBox5.Text = "Training && Qualifications";
      this.Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel1.Controls.Add((Control) this.cboQualificationType);
      this.Panel1.Controls.Add((Control) this.lblQualificationType);
      this.Panel1.Controls.Add((Control) this.dtpQualificationBooked);
      this.Panel1.Controls.Add((Control) this.Label36);
      this.Panel1.Controls.Add((Control) this.cboQualification);
      this.Panel1.Controls.Add((Control) this.Label22);
      this.Panel1.Controls.Add((Control) this.txtQualificatioNote);
      this.Panel1.Controls.Add((Control) this.Label17);
      this.Panel1.Controls.Add((Control) this.btnSaveQualification);
      this.Panel1.Controls.Add((Control) this.dtpQualificationExpires);
      this.Panel1.Controls.Add((Control) this.Label18);
      this.Panel1.Controls.Add((Control) this.dtpQualificationPassed);
      this.Panel1.Controls.Add((Control) this.Label19);
      this.Panel1.Location = new System.Drawing.Point(5, 17);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(595, 225);
      this.Panel1.TabIndex = 42;
      this.cboQualificationType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboQualificationType.Location = new System.Drawing.Point(139, 8);
      this.cboQualificationType.Name = "cboQualificationType";
      this.cboQualificationType.Size = new Size(445, 21);
      this.cboQualificationType.TabIndex = 54;
      this.cboQualificationType.Text = "ComboBox1";
      this.lblQualificationType.Location = new System.Drawing.Point(7, 8);
      this.lblQualificationType.Name = "lblQualificationType";
      this.lblQualificationType.Size = new Size(126, 23);
      this.lblQualificationType.TabIndex = 55;
      this.lblQualificationType.Text = "Qualification Type";
      this.dtpQualificationBooked.Checked = false;
      this.dtpQualificationBooked.Location = new System.Drawing.Point(332, 68);
      this.dtpQualificationBooked.Name = "dtpQualificationBooked";
      this.dtpQualificationBooked.ShowCheckBox = true;
      this.dtpQualificationBooked.Size = new Size(152, 21);
      this.dtpQualificationBooked.TabIndex = 52;
      this.Label36.Location = new System.Drawing.Point(269, 74);
      this.Label36.Name = "Label36";
      this.Label36.Size = new Size(57, 23);
      this.Label36.TabIndex = 53;
      this.Label36.Text = "Booked";
      this.cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboQualification.Location = new System.Drawing.Point(96, 38);
      this.cboQualification.Name = "cboQualification";
      this.cboQualification.Size = new Size(488, 21);
      this.cboQualification.TabIndex = 1;
      this.cboQualification.Text = "ComboBox1";
      this.Label22.Location = new System.Drawing.Point(8, 38);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(100, 23);
      this.Label22.TabIndex = 48;
      this.Label22.Text = "Qualification";
      this.txtQualificatioNote.AcceptsReturn = true;
      this.txtQualificatioNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQualificatioNote.Location = new System.Drawing.Point(96, 132);
      this.txtQualificatioNote.Multiline = true;
      this.txtQualificatioNote.Name = "txtQualificatioNote";
      this.txtQualificatioNote.ScrollBars = ScrollBars.Vertical;
      this.txtQualificatioNote.Size = new Size(488, 61);
      this.txtQualificatioNote.TabIndex = 4;
      this.Label17.Location = new System.Drawing.Point(8, 132);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(67, 20);
      this.Label17.TabIndex = 47;
      this.Label17.Text = "Note";
      this.btnSaveQualification.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveQualification.Location = new System.Drawing.Point(496, 199);
      this.btnSaveQualification.Name = "btnSaveQualification";
      this.btnSaveQualification.Size = new Size(88, 23);
      this.btnSaveQualification.TabIndex = 5;
      this.btnSaveQualification.Text = "Save";
      this.dtpQualificationExpires.Checked = false;
      this.dtpQualificationExpires.Location = new System.Drawing.Point(96, 99);
      this.dtpQualificationExpires.Name = "dtpQualificationExpires";
      this.dtpQualificationExpires.ShowCheckBox = true;
      this.dtpQualificationExpires.Size = new Size(152, 21);
      this.dtpQualificationExpires.TabIndex = 3;
      this.Label18.Location = new System.Drawing.Point(8, 105);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(80, 23);
      this.Label18.TabIndex = 43;
      this.Label18.Text = "Expires";
      this.dtpQualificationPassed.Checked = false;
      this.dtpQualificationPassed.Location = new System.Drawing.Point(96, 68);
      this.dtpQualificationPassed.Name = "dtpQualificationPassed";
      this.dtpQualificationPassed.ShowCheckBox = true;
      this.dtpQualificationPassed.Size = new Size(152, 21);
      this.dtpQualificationPassed.TabIndex = 2;
      this.Label19.Location = new System.Drawing.Point(8, 74);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(80, 23);
      this.Label19.TabIndex = 41;
      this.Label19.Text = "Date Passed";
      this.btnRemoveTrainingQualifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveTrainingQualifications.Location = new System.Drawing.Point(10, 576);
      this.btnRemoveTrainingQualifications.Name = "btnRemoveTrainingQualifications";
      this.btnRemoveTrainingQualifications.Size = new Size(75, 21);
      this.btnRemoveTrainingQualifications.TabIndex = 7;
      this.btnRemoveTrainingQualifications.Text = "Delete";
      this.dgTrainingQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTrainingQualifications.DataMember = "";
      this.dgTrainingQualifications.HeaderForeColor = SystemColors.ControlText;
      this.dgTrainingQualifications.Location = new System.Drawing.Point(8, 248);
      this.dgTrainingQualifications.Name = "dgTrainingQualifications";
      this.dgTrainingQualifications.Size = new Size(592, 320);
      this.dgTrainingQualifications.TabIndex = 6;
      this.tpKit.Controls.Add((Control) this.GroupBox4);
      this.tpKit.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tpKit.Location = new System.Drawing.Point(4, 22);
      this.tpKit.Name = "tpKit";
      this.tpKit.Size = new Size(624, 622);
      this.tpKit.TabIndex = 4;
      this.tpKit.Text = "Equipment";
      this.tpKit.Visible = false;
      this.GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox4.Controls.Add((Control) this.Panel2);
      this.GroupBox4.Controls.Add((Control) this.btnRemoveEngineerEquipment);
      this.GroupBox4.Controls.Add((Control) this.dgEquipment);
      this.GroupBox4.Location = new System.Drawing.Point(8, 8);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(608, 608);
      this.GroupBox4.TabIndex = 13;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Specialised Equipment and Tools Issued";
      this.Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel2.Controls.Add((Control) this.txtEquipmentTool);
      this.Panel2.Controls.Add((Control) this.Label20);
      this.Panel2.Controls.Add((Control) this.btnSaveEquipment);
      this.Panel2.Location = new System.Drawing.Point(8, 16);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(592, 80);
      this.Panel2.TabIndex = 2;
      this.txtEquipmentTool.AcceptsReturn = true;
      this.txtEquipmentTool.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEquipmentTool.Location = new System.Drawing.Point(115, 4);
      this.txtEquipmentTool.MaxLength = (int) byte.MaxValue;
      this.txtEquipmentTool.Multiline = true;
      this.txtEquipmentTool.Name = "txtEquipmentTool";
      this.txtEquipmentTool.ScrollBars = ScrollBars.Vertical;
      this.txtEquipmentTool.Size = new Size(376, 68);
      this.txtEquipmentTool.TabIndex = 1;
      this.txtEquipmentTool.Tag = (object) "Engineer.Name";
      this.Label20.Location = new System.Drawing.Point(3, 4);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(112, 20);
      this.Label20.TabIndex = 55;
      this.Label20.Text = "Equipment\\Tool";
      this.btnSaveEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveEquipment.Location = new System.Drawing.Point(504, 48);
      this.btnSaveEquipment.Name = "btnSaveEquipment";
      this.btnSaveEquipment.Size = new Size(75, 23);
      this.btnSaveEquipment.TabIndex = 2;
      this.btnSaveEquipment.Text = "Save";
      this.btnRemoveEngineerEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveEngineerEquipment.Location = new System.Drawing.Point(8, 576);
      this.btnRemoveEngineerEquipment.Name = "btnRemoveEngineerEquipment";
      this.btnRemoveEngineerEquipment.Size = new Size(75, 23);
      this.btnRemoveEngineerEquipment.TabIndex = 4;
      this.btnRemoveEngineerEquipment.Text = "Delete";
      this.dgEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgEquipment.DataMember = "";
      this.dgEquipment.HeaderForeColor = SystemColors.ControlText;
      this.dgEquipment.Location = new System.Drawing.Point(8, 106);
      this.dgEquipment.Name = "dgEquipment";
      this.dgEquipment.Size = new Size(592, 462);
      this.dgEquipment.TabIndex = 3;
      this.tpDisciplinary.Controls.Add((Control) this.GroupBox6);
      this.tpDisciplinary.Location = new System.Drawing.Point(4, 22);
      this.tpDisciplinary.Name = "tpDisciplinary";
      this.tpDisciplinary.Size = new Size(624, 622);
      this.tpDisciplinary.TabIndex = 2;
      this.tpDisciplinary.Text = "Disciplinary";
      this.tpDisciplinary.Visible = false;
      this.GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox6.Controls.Add((Control) this.btnAddDisciplinaries);
      this.GroupBox6.Controls.Add((Control) this.Panel3);
      this.GroupBox6.Controls.Add((Control) this.btnRemoveDisciplinaries);
      this.GroupBox6.Controls.Add((Control) this.btnEditDisciplinaries);
      this.GroupBox6.Controls.Add((Control) this.dgDisciplinaries);
      this.GroupBox6.Location = new System.Drawing.Point(8, 8);
      this.GroupBox6.Name = "GroupBox6";
      this.GroupBox6.Size = new Size(608, 608);
      this.GroupBox6.TabIndex = 14;
      this.GroupBox6.TabStop = false;
      this.GroupBox6.Text = "Disciplinary Records";
      this.btnAddDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddDisciplinaries.Location = new System.Drawing.Point(8, 576);
      this.btnAddDisciplinaries.Name = "btnAddDisciplinaries";
      this.btnAddDisciplinaries.Size = new Size(75, 21);
      this.btnAddDisciplinaries.TabIndex = 6;
      this.btnAddDisciplinaries.Text = "Add";
      this.Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel3.Controls.Add((Control) this.txtDisciplinaryID);
      this.Panel3.Controls.Add((Control) this.cboDisciplinary);
      this.Panel3.Controls.Add((Control) this.btnSaveDisciplinaries);
      this.Panel3.Controls.Add((Control) this.Label21);
      this.Panel3.Controls.Add((Control) this.dtpDisciplinaryIssued);
      this.Panel3.Controls.Add((Control) this.Label23);
      this.Panel3.Controls.Add((Control) this.txtDisciplinary);
      this.Panel3.Controls.Add((Control) this.Label24);
      this.Panel3.Location = new System.Drawing.Point(5, 28);
      this.Panel3.Name = "Panel3";
      this.Panel3.Size = new Size(595, 80);
      this.Panel3.TabIndex = 42;
      this.txtDisciplinaryID.Location = new System.Drawing.Point(352, 31);
      this.txtDisciplinaryID.Name = "txtDisciplinaryID";
      this.txtDisciplinaryID.Size = new Size(100, 21);
      this.txtDisciplinaryID.TabIndex = 47;
      this.txtDisciplinaryID.TabStop = false;
      this.txtDisciplinaryID.Visible = false;
      this.cboDisciplinary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboDisciplinary.Location = new System.Drawing.Point(96, 53);
      this.cboDisciplinary.Name = "cboDisciplinary";
      this.cboDisciplinary.Size = new Size(392, 21);
      this.cboDisciplinary.TabIndex = 3;
      this.cboDisciplinary.Text = "ComboBox2";
      this.btnSaveDisciplinaries.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveDisciplinaries.Location = new System.Drawing.Point(496, 53);
      this.btnSaveDisciplinaries.Name = "btnSaveDisciplinaries";
      this.btnSaveDisciplinaries.Size = new Size(88, 21);
      this.btnSaveDisciplinaries.TabIndex = 4;
      this.btnSaveDisciplinaries.Text = "Save";
      this.Label21.Location = new System.Drawing.Point(8, 53);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(80, 23);
      this.Label21.TabIndex = 43;
      this.Label21.Text = "Status";
      this.dtpDisciplinaryIssued.Checked = false;
      this.dtpDisciplinaryIssued.Location = new System.Drawing.Point(96, 29);
      this.dtpDisciplinaryIssued.Name = "dtpDisciplinaryIssued";
      this.dtpDisciplinaryIssued.ShowCheckBox = true;
      this.dtpDisciplinaryIssued.Size = new Size(152, 21);
      this.dtpDisciplinaryIssued.TabIndex = 2;
      this.Label23.Location = new System.Drawing.Point(8, 29);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(80, 23);
      this.Label23.TabIndex = 41;
      this.Label23.Text = "Issued";
      this.txtDisciplinary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDisciplinary.Location = new System.Drawing.Point(96, 5);
      this.txtDisciplinary.Name = "txtDisciplinary";
      this.txtDisciplinary.Size = new Size(496, 21);
      this.txtDisciplinary.TabIndex = 1;
      this.Label24.Location = new System.Drawing.Point(8, 5);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(80, 20);
      this.Label24.TabIndex = 40;
      this.Label24.Text = "Disciplinary";
      this.btnRemoveDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveDisciplinaries.Location = new System.Drawing.Point(168, 576);
      this.btnRemoveDisciplinaries.Name = "btnRemoveDisciplinaries";
      this.btnRemoveDisciplinaries.Size = new Size(75, 21);
      this.btnRemoveDisciplinaries.TabIndex = 7;
      this.btnRemoveDisciplinaries.Text = "Delete";
      this.btnEditDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnEditDisciplinaries.Location = new System.Drawing.Point(88, 576);
      this.btnEditDisciplinaries.Name = "btnEditDisciplinaries";
      this.btnEditDisciplinaries.Size = new Size(75, 21);
      this.btnEditDisciplinaries.TabIndex = 6;
      this.btnEditDisciplinaries.Text = "Edit";
      this.dgDisciplinaries.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgDisciplinaries.DataMember = "";
      this.dgDisciplinaries.HeaderForeColor = SystemColors.ControlText;
      this.dgDisciplinaries.Location = new System.Drawing.Point(8, 116);
      this.dgDisciplinaries.Name = "dgDisciplinaries";
      this.dgDisciplinaries.Size = new Size(592, 452);
      this.dgDisciplinaries.TabIndex = 5;
      this.tpDocuments.Controls.Add((Control) this.pnlDocuments);
      this.tpDocuments.Location = new System.Drawing.Point(4, 22);
      this.tpDocuments.Name = "tpDocuments";
      this.tpDocuments.Size = new Size(624, 622);
      this.tpDocuments.TabIndex = 6;
      this.tpDocuments.Text = "Documents";
      this.tpDocuments.Visible = false;
      this.pnlDocuments.Dock = DockStyle.Fill;
      this.pnlDocuments.Location = new System.Drawing.Point(0, 0);
      this.pnlDocuments.Name = "pnlDocuments";
      this.pnlDocuments.Size = new Size(624, 622);
      this.pnlDocuments.TabIndex = 0;
      this.tpHolidayAbsences.Controls.Add((Control) this.grpAbsences);
      this.tpHolidayAbsences.Controls.Add((Control) this.GroupBox7);
      this.tpHolidayAbsences.Location = new System.Drawing.Point(4, 22);
      this.tpHolidayAbsences.Name = "tpHolidayAbsences";
      this.tpHolidayAbsences.Size = new Size(624, 622);
      this.tpHolidayAbsences.TabIndex = 5;
      this.tpHolidayAbsences.Text = "Holidays & Absences";
      this.tpHolidayAbsences.Visible = false;
      this.grpAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAbsences.Controls.Add((Control) this.dgAbsences);
      this.grpAbsences.Location = new System.Drawing.Point(8, 112);
      this.grpAbsences.Name = "grpAbsences";
      this.grpAbsences.Size = new Size(608, 504);
      this.grpAbsences.TabIndex = 4;
      this.grpAbsences.TabStop = false;
      this.grpAbsences.Text = "Absences";
      this.dgAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAbsences.DataMember = "";
      this.dgAbsences.HeaderForeColor = SystemColors.ControlText;
      this.dgAbsences.Location = new System.Drawing.Point(8, 24);
      this.dgAbsences.Name = "dgAbsences";
      this.dgAbsences.Size = new Size(592, 472);
      this.dgAbsences.TabIndex = 4;
      this.GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox7.Controls.Add((Control) this.txtDaysHolidayAllowed);
      this.GroupBox7.Controls.Add((Control) this.Label25);
      this.GroupBox7.Controls.Add((Control) this.txtHolidayYearEnd);
      this.GroupBox7.Controls.Add((Control) this.Label26);
      this.GroupBox7.Controls.Add((Control) this.txtHolidayYearStart);
      this.GroupBox7.Controls.Add((Control) this.Label27);
      this.GroupBox7.Location = new System.Drawing.Point(8, 8);
      this.GroupBox7.Name = "GroupBox7";
      this.GroupBox7.Size = new Size(608, 104);
      this.GroupBox7.TabIndex = 0;
      this.GroupBox7.TabStop = false;
      this.GroupBox7.Text = "Holiday Entitlement";
      this.txtDaysHolidayAllowed.Location = new System.Drawing.Point(144, 72);
      this.txtDaysHolidayAllowed.Name = "txtDaysHolidayAllowed";
      this.txtDaysHolidayAllowed.Size = new Size(176, 21);
      this.txtDaysHolidayAllowed.TabIndex = 3;
      this.Label25.Location = new System.Drawing.Point(16, 72);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(128, 23);
      this.Label25.TabIndex = 4;
      this.Label25.Text = "Holiday Entitlement";
      this.txtHolidayYearEnd.Location = new System.Drawing.Point(144, 48);
      this.txtHolidayYearEnd.Name = "txtHolidayYearEnd";
      this.txtHolidayYearEnd.Size = new Size(176, 21);
      this.txtHolidayYearEnd.TabIndex = 2;
      this.Label26.Location = new System.Drawing.Point(16, 48);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(128, 23);
      this.Label26.TabIndex = 2;
      this.Label26.Text = "End Period (dd/mm)";
      this.txtHolidayYearStart.Location = new System.Drawing.Point(144, 24);
      this.txtHolidayYearStart.Name = "txtHolidayYearStart";
      this.txtHolidayYearStart.Size = new Size(176, 21);
      this.txtHolidayYearStart.TabIndex = 1;
      this.Label27.Location = new System.Drawing.Point(16, 24);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(128, 23);
      this.Label27.TabIndex = 0;
      this.Label27.Text = "Start Period (dd/mm)";
      this.tpPostalRegions.Controls.Add((Control) this.GroupBox2);
      this.tpPostalRegions.Controls.Add((Control) this.grpPostalRegions);
      this.tpPostalRegions.Location = new System.Drawing.Point(4, 22);
      this.tpPostalRegions.Name = "tpPostalRegions";
      this.tpPostalRegions.Size = new Size(624, 622);
      this.tpPostalRegions.TabIndex = 7;
      this.tpPostalRegions.Text = "Postal Regions";
      this.tpPostalRegions.Visible = false;
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.Button1);
      this.GroupBox2.Controls.Add((Control) this.TextBox1);
      this.GroupBox2.Controls.Add((Control) this.Label1);
      this.GroupBox2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox2.Location = new System.Drawing.Point(3, 3);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(605, 80);
      this.GroupBox2.TabIndex = 15;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Home ";
      this.Button1.Location = new System.Drawing.Point(288, 24);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 43;
      this.Button1.Text = "Button1";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button1.Visible = false;
      this.TextBox1.Location = new System.Drawing.Point(132, 25);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(123, 21);
      this.TextBox1.TabIndex = 41;
      this.Label1.Location = new System.Drawing.Point(29, 28);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(97, 20);
      this.Label1.TabIndex = 42;
      this.Label1.Text = "Home Postcode";
      this.grpPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPostalRegions.Controls.Add((Control) this.Label38);
      this.grpPostalRegions.Controls.Add((Control) this.txtPCSearch);
      this.grpPostalRegions.Controls.Add((Control) this.Label2);
      this.grpPostalRegions.Controls.Add((Control) this.dgUnTicked);
      this.grpPostalRegions.Controls.Add((Control) this.dgPostalRegions);
      this.grpPostalRegions.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpPostalRegions.Location = new System.Drawing.Point(3, 89);
      this.grpPostalRegions.Name = "grpPostalRegions";
      this.grpPostalRegions.Size = new Size(618, 530);
      this.grpPostalRegions.TabIndex = 14;
      this.grpPostalRegions.TabStop = false;
      this.grpPostalRegions.Text = "Postal Regions";
      this.Label38.Font = new Font("Verdana", 10.25f);
      this.Label38.Location = new System.Drawing.Point(15, 26);
      this.Label38.Name = "Label38";
      this.Label38.Size = new Size(143, 20);
      this.Label38.TabIndex = 43;
      this.Label38.Text = "Assigned Areas";
      this.Label38.TextAlign = ContentAlignment.MiddleCenter;
      this.txtPCSearch.Location = new System.Drawing.Point(369, 28);
      this.txtPCSearch.Name = "txtPCSearch";
      this.txtPCSearch.Size = new Size(123, 21);
      this.txtPCSearch.TabIndex = 41;
      this.Label2.Location = new System.Drawing.Point(304, 26);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(59, 20);
      this.Label2.TabIndex = 42;
      this.Label2.Text = "Search";
      this.dgUnTicked.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgUnTicked.CaptionFont = new Font("Verdana", 8.25f, FontStyle.Bold);
      this.dgUnTicked.DataMember = "";
      this.dgUnTicked.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dgUnTicked.HeaderForeColor = SystemColors.ControlText;
      this.dgUnTicked.Location = new System.Drawing.Point(310, 62);
      this.dgUnTicked.Name = "dgUnTicked";
      this.dgUnTicked.Size = new Size(284, 450);
      this.dgUnTicked.TabIndex = 1;
      this.dgPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgPostalRegions.CaptionFont = new Font("Verdana", 8.25f, FontStyle.Bold);
      this.dgPostalRegions.DataMember = "";
      this.dgPostalRegions.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dgPostalRegions.HeaderForeColor = SystemColors.ControlText;
      this.dgPostalRegions.Location = new System.Drawing.Point(7, 62);
      this.dgPostalRegions.Name = "dgPostalRegions";
      this.dgPostalRegions.Size = new Size(284, 450);
      this.dgPostalRegions.TabIndex = 0;
      this.cboDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboDepartment.Cursor = Cursors.Hand;
      this.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDepartment.Location = new System.Drawing.Point(121, 99);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(470, 21);
      this.cboDepartment.TabIndex = 73;
      this.cboDepartment.Tag = (object) "Engineer.Department";
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCSubcontractor);
      this.Size = new Size(640, 652);
      this.TabControl1.ResumeLayout(false);
      this.tpContact.ResumeLayout(false);
      this.tpContact.PerformLayout();
      this.tpMain.ResumeLayout(false);
      this.grpEngineer.ResumeLayout(false);
      this.grpEngineer.PerformLayout();
      this.tabMaxSor.ResumeLayout(false);
      this.GroupBox8.ResumeLayout(false);
      this.GroupBox8.PerformLayout();
      this.tpWages.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox3.PerformLayout();
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.tpTrainingQualifications.ResumeLayout(false);
      this.GroupBox5.ResumeLayout(false);
      this.Panel1.ResumeLayout(false);
      this.Panel1.PerformLayout();
      this.dgTrainingQualifications.EndInit();
      this.tpKit.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.Panel2.ResumeLayout(false);
      this.Panel2.PerformLayout();
      this.dgEquipment.EndInit();
      this.tpDisciplinary.ResumeLayout(false);
      this.GroupBox6.ResumeLayout(false);
      this.Panel3.ResumeLayout(false);
      this.Panel3.PerformLayout();
      this.dgDisciplinaries.EndInit();
      this.tpDocuments.ResumeLayout(false);
      this.tpHolidayAbsences.ResumeLayout(false);
      this.grpAbsences.ResumeLayout(false);
      this.dgAbsences.EndInit();
      this.GroupBox7.ResumeLayout(false);
      this.GroupBox7.PerformLayout();
      this.tpPostalRegions.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.grpPostalRegions.ResumeLayout(false);
      this.grpPostalRegions.PerformLayout();
      this.dgUnTicked.EndInit();
      this.dgPostalRegions.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupPostalRegionsDataGrid();
      this.SetupPostalRegionsDataGridUnTicked();
      this.SetupTrainingQualificationsDataGrid();
      this.SetupEngineerEquipmentDataGrid();
      this.SetupDisciplinariesDataGrid();
      this.SetupAbsenceDataGridGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentSubcontractor;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Subcontractor CurrentSubcontractor
    {
      get
      {
        return this._currentSubcontractor;
      }
      set
      {
        this._currentSubcontractor = value;
        if (this._currentSubcontractor == null)
        {
          this._currentSubcontractor = new Subcontractor();
          this._currentSubcontractor.Engineer = new Engineer();
          this._currentSubcontractor.Engineer.Exists = false;
          this._currentSubcontractor.Exists = false;
        }
        this.txtHolidayYearStart.Text = this.CurrentSubcontractor.Engineer.HolidayYearStart;
        this.txtHolidayYearEnd.Text = this.CurrentSubcontractor.Engineer.HolidayYearEnd;
        if (this.CurrentSubcontractor.Exists)
        {
          this.Populate(0);
          this.btnVanHistory.Enabled = true;
          this.pnlDocuments.Controls.Clear();
          this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblEngineer, this.CurrentSubcontractor.EngineerID);
          this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
        }
        else
          this.btnVanHistory.Enabled = false;
        this.PopulatePostalRegions();
        this.PopulateTrainingQualifications();
        this.PopulateEngineerEquipment();
        this.PopulateDisciplinaries();
        this.PopulateAbsences();
      }
    }

    public MaxEngineerTime MaxTimes
    {
      get
      {
        return this._MaxTimes;
      }
      set
      {
        this._MaxTimes = value;
      }
    }

    public DataView PostalRegionsDataView
    {
      get
      {
        return this.postalRegionsDV;
      }
      set
      {
        this.postalRegionsDV = value;
        this.postalRegionsDV.Table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
        this.postalRegionsDV.AllowNew = false;
        this.postalRegionsDV.AllowEdit = false;
        this.postalRegionsDV.AllowDelete = false;
        this.dgPostalRegions.DataSource = (object) this.PostalRegionsDataView;
      }
    }

    private DataRow SelectedPostalRegionDataRow
    {
      get
      {
        return this.dgPostalRegions.CurrentRowIndex != -1 ? this.PostalRegionsDataView[this.dgPostalRegions.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView PostalRegionsDataViewUT
    {
      get
      {
        return this.postalRegionsDVUT;
      }
      set
      {
        this.postalRegionsDVUT = value;
        this.postalRegionsDVUT.Table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
        this.postalRegionsDVUT.AllowNew = false;
        this.postalRegionsDVUT.AllowEdit = false;
        this.postalRegionsDVUT.AllowDelete = false;
        this.dgUnTicked.DataSource = (object) this.PostalRegionsDataViewUT;
      }
    }

    private DataRow SelectedPostalRegionDataRowUT
    {
      get
      {
        return this.dgUnTicked.CurrentRowIndex != -1 ? this.PostalRegionsDataViewUT[this.dgUnTicked.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupPostalRegionsDataGridUnTicked()
    {
      Helper.SetUpDataGrid(this.dgUnTicked, false);
      DataGridTableStyle tableStyle = this.dgUnTicked.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgPostalRegions.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
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
      dataGridLabelColumn.HeaderText = "Postcode";
      dataGridLabelColumn.MappingName = "Name";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 200;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.MappingName = Enums.TableNames.tblEngineerPostalRegion.ToString();
      this.dgUnTicked.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgUnTicked);
    }

    private void UCSubcontractor_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgPostalRegions_Clicks(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedPostalRegionDataRow == null)
          return;
        this.dgPostalRegions[this.dgPostalRegions.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgPostalRegions[this.dgPostalRegions.CurrentRowIndex, 0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnVanHistory_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMVanHistory), true, new object[1]
      {
        (object) this.CurrentSubcontractor.EngineerID
      }, false);
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentSubcontractor = App.DB.SubContractor.Subcontractor_Get(ID);
      this.txtName.Text = this.CurrentSubcontractor.Name;
      this.txtAddress1.Text = this.CurrentSubcontractor.Address1;
      this.txtAddress2.Text = this.CurrentSubcontractor.Address2;
      this.txtAddress3.Text = this.CurrentSubcontractor.Address3;
      this.txtAddress4.Text = this.CurrentSubcontractor.Address4;
      this.txtAddress5.Text = this.CurrentSubcontractor.Address5;
      this.txtPostcode.Text = this.CurrentSubcontractor.Postcode;
      this.txtTelephoneNum.Text = this.CurrentSubcontractor.TelephoneNum;
      this.txtFaxNum.Text = this.CurrentSubcontractor.FaxNum;
      this.txtEmailAddress.Text = this.CurrentSubcontractor.EmailAddress;
      this.txtNotes.Text = this.CurrentSubcontractor.Notes;
      ComboBox cboLinkToSupplier = this.cboLinkToSupplier;
      Combo.SetSelectedComboItem_By_Value(ref cboLinkToSupplier, Conversions.ToString(this.CurrentSubcontractor.LinkToSupplierID));
      this.cboLinkToSupplier = cboLinkToSupplier;
      ComboBox cboTaxRate = this.cboTaxRate;
      Combo.SetSelectedComboItem_By_Value(ref cboTaxRate, Conversions.ToString(this.CurrentSubcontractor.TaxRate));
      this.cboTaxRate = cboTaxRate;
      this.txtEngineerID.Text = Conversions.ToString(this.CurrentSubcontractor.Engineer.EngineerID);
      this.txtGasSafeNo.Text = this.CurrentSubcontractor.Engineer.GasSafeNo;
      this.txtOftecNo.Text = this.CurrentSubcontractor.Engineer.OftecNo;
      ComboBox cboEngineerGroup = this.cboEngineerGroup;
      Combo.SetSelectedComboItem_By_Value(ref cboEngineerGroup, Conversions.ToString(this.CurrentSubcontractor.Engineer.EngineerGroupID));
      this.cboEngineerGroup = cboEngineerGroup;
      ComboBox cboDepartment = this.cboDepartment;
      Combo.SetSelectedComboItem_By_Value(ref cboDepartment, this.CurrentSubcontractor.Engineer.Department.Trim());
      this.cboDepartment = cboDepartment;
      this.txtTechnician.Text = this.CurrentSubcontractor.Engineer.Technician;
      ComboBox combo = this.cboUser;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentSubcontractor.Engineer.ManagerUserID));
      this.cboUser = combo;
      combo = this.cboRegion;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentSubcontractor.Engineer.RegionID));
      this.cboRegion = combo;
      if (!this.CurrentSubcontractor.Exists | !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
        this.cboRegion.Enabled = false;
      this.txtPDAID.Text = this.CurrentSubcontractor.Engineer.PDAID != 0 ? Conversions.ToString(this.CurrentSubcontractor.Engineer.PDAID) : string.Empty;
      this.txtStartingDetails.Text = this.CurrentSubcontractor.Engineer.StartingDetails;
      this.txtDrivingLicenceNo.Text = this.CurrentSubcontractor.Engineer.DrivingLicenceNo;
      if ((uint) DateTime.Compare(this.CurrentSubcontractor.Engineer.DrivingLicenceIssueDate, DateTime.MinValue) > 0U)
      {
        this.dtpDrivingLicenceIssueDate.Value = this.CurrentSubcontractor.Engineer.DrivingLicenceIssueDate;
        this.dtpDrivingLicenceIssueDate.Checked = true;
      }
      else
      {
        this.dtpDrivingLicenceIssueDate.Value = DateAndTime.Now.Date;
        this.dtpDrivingLicenceIssueDate.Checked = false;
      }
      this.chkApprentice.Checked = this.CurrentSubcontractor.Engineer.Apprentice;
      this.txtNextOfKinName.Text = this.CurrentSubcontractor.Engineer.NextOfKinName;
      this.txtNextOfKinContact.Text = this.CurrentSubcontractor.Engineer.NextOfKinContact;
      this.MaxTimes = App.DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(this.CurrentSubcontractor.Engineer.EngineerID);
      if (this.MaxTimes != null)
      {
        this.txtMondayValue.Text = Conversions.ToString(this.MaxTimes.MondayValue);
        this.txtTuesdayValue.Text = Conversions.ToString(this.MaxTimes.TuesdayValue);
        this.txtWednesdayValue.Text = Conversions.ToString(this.MaxTimes.WednesdayValue);
        this.txtThursdayValue.Text = Conversions.ToString(this.MaxTimes.ThursdayValue);
        this.txtFridayValue.Text = Conversions.ToString(this.MaxTimes.FridayValue);
        this.txtSaturdayValue.Text = Conversions.ToString(this.MaxTimes.SaturdayValue);
        this.txtSundayValue.Text = Conversions.ToString(this.MaxTimes.SundayValue);
      }
      else
        this.MaxTimes = new MaxEngineerTime();
      this.txtDailyServiceLimit.Text = Conversions.ToString(this.CurrentSubcontractor.Engineer.DailyServiceLimit);
      this.txtServPri.Text = Conversions.ToString(this.CurrentSubcontractor.Engineer.ServPri);
      this.txtBreakPri.Text = Conversions.ToString(this.CurrentSubcontractor.Engineer.BreakPri);
      combo = this.cboPayGrade;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentSubcontractor.Engineer.PayGradeID));
      this.cboPayGrade = combo;
      this.txtAnnualSalary.Text = Conversions.ToString(this.CurrentSubcontractor.Engineer.AnnualSalary);
      this.txtNINumber.Text = this.CurrentSubcontractor.Engineer.NINumber;
      this.txtCostToCompanyNormal.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentSubcontractor.Engineer.CostToCompanyNormal, "C");
      this.txtCostToCompanyTimeHalf.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentSubcontractor.Engineer.CostToCompanyTimeAndHalf, "C");
      this.txtCostToCompanyDouble.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentSubcontractor.Engineer.CostToCompanyDouble, "C");
      this.txtHolidayYearStart.Text = this.CurrentSubcontractor.Engineer.HolidayYearStart;
      this.txtHolidayYearEnd.Text = this.CurrentSubcontractor.Engineer.HolidayYearEnd;
      this.txtDaysHolidayAllowed.Text = Conversions.ToString(this.CurrentSubcontractor.Engineer.DaysHolidayAllowed);
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    private void PopulatePostalRegions()
    {
      this.PostalRegionsDataView = App.DB.EngineerPostalRegion.Get(this.CurrentSubcontractor.EngineerID);
      this.PostalRegionsDataViewUT = App.DB.EngineerPostalRegion.GetUnTicked(this.CurrentSubcontractor.EngineerID);
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentSubcontractor.IgnoreExceptionsOnSetMethods = true;
        this.CurrentSubcontractor.SetName = (object) this.txtName.Text.Trim();
        this.CurrentSubcontractor.SetAddress1 = (object) this.txtAddress1.Text.Trim();
        this.CurrentSubcontractor.SetAddress2 = (object) this.txtAddress2.Text.Trim();
        this.CurrentSubcontractor.SetAddress3 = (object) this.txtAddress3.Text.Trim();
        this.CurrentSubcontractor.SetAddress4 = (object) this.txtAddress4.Text.Trim();
        this.CurrentSubcontractor.SetAddress5 = (object) this.txtAddress5.Text.Trim();
        this.CurrentSubcontractor.SetPostcode = (object) this.txtPostcode.Text.Trim();
        this.CurrentSubcontractor.SetTelephoneNum = (object) this.txtTelephoneNum.Text.Trim();
        this.CurrentSubcontractor.SetFaxNum = (object) this.txtFaxNum.Text.Trim();
        this.CurrentSubcontractor.SetEmailAddress = (object) this.txtEmailAddress.Text.Trim();
        this.CurrentSubcontractor.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentSubcontractor.Engineer.IgnoreExceptionsOnSetMethods = true;
        if (!this.CurrentSubcontractor.Exists | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
          this.CurrentSubcontractor.Engineer.SetRegionID = (object) Combo.get_GetSelectedItemValue(this.cboRegion);
        this.CurrentSubcontractor.Engineer.SetEngineerGroupID = (object) Combo.get_GetSelectedItemValue(this.cboEngineerGroup);
        this.CurrentSubcontractor.Engineer.SetGasSafeNo = (object) this.txtGasSafeNo.Text.Trim();
        this.CurrentSubcontractor.Engineer.SetOftecNo = (object) this.txtOftecNo.Text.Trim();
        this.CurrentSubcontractor.Engineer.SetName = (object) ("SUBCONTRACTOR : " + this.txtName.Text.Trim());
        this.CurrentSubcontractor.Engineer.SetTelephoneNum = (object) this.txtTelephoneNum.Text.Trim();
        this.CurrentSubcontractor.Engineer.SetPDAID = this.txtPDAID.Text.Trim().Length != 0 ? (object) this.txtPDAID.Text.Trim() : (object) 0;
        this.CurrentSubcontractor.Engineer.SetApprentice = (object) this.chkApprentice.Checked;
        this.CurrentSubcontractor.Engineer.SetCostToCompanyNormal = (object) Microsoft.VisualBasic.Strings.Replace(this.txtCostToCompanyNormal.Text.Trim(), "£", "", 1, -1, CompareMethod.Binary);
        this.CurrentSubcontractor.Engineer.SetCostToCompanyTimeAndHalf = (object) Microsoft.VisualBasic.Strings.Replace(this.txtCostToCompanyTimeHalf.Text.Trim(), "£", "", 1, -1, CompareMethod.Binary);
        this.CurrentSubcontractor.Engineer.SetCostToCompanyDouble = (object) Microsoft.VisualBasic.Strings.Replace(this.txtCostToCompanyDouble.Text.Trim(), "£", "", 1, -1, CompareMethod.Binary);
        this.CurrentSubcontractor.Engineer.SetNextOfKinName = (object) this.txtNextOfKinName.Text;
        this.CurrentSubcontractor.Engineer.SetNextOfKinContact = (object) this.txtNextOfKinContact.Text;
        this.CurrentSubcontractor.Engineer.SetStartingDetails = (object) this.txtStartingDetails.Text;
        this.CurrentSubcontractor.Engineer.SetDrivingLicenceNo = (object) this.txtDrivingLicenceNo.Text;
        this.CurrentSubcontractor.Engineer.DrivingLicenceIssueDate = !this.dtpDrivingLicenceIssueDate.Checked ? DateTime.MinValue : this.dtpDrivingLicenceIssueDate.Value;
        this.CurrentSubcontractor.Engineer.SetPayGradeID = (object) Combo.get_GetSelectedItemValue(this.cboPayGrade);
        if (this.txtAnnualSalary.Text.Trim().Length > 0)
          this.CurrentSubcontractor.Engineer.SetAnnualSalary = (object) this.txtAnnualSalary.Text;
        this.CurrentSubcontractor.Engineer.SetNINumber = (object) this.txtNINumber.Text;
        this.CurrentSubcontractor.Engineer.SetHolidayYearStart = (object) this.txtHolidayYearStart.Text;
        this.CurrentSubcontractor.Engineer.SetHolidayYearEnd = (object) this.txtHolidayYearEnd.Text;
        if (this.txtDaysHolidayAllowed.Text.Trim().Length > 0)
          this.CurrentSubcontractor.Engineer.SetDaysHolidayAllowed = (object) this.txtDaysHolidayAllowed.Text;
        string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment));
        if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) > 0)
          this.CurrentSubcontractor.Engineer.SetDepartment = (object) str;
        else if (!Versioned.IsNumeric((object) str))
          this.CurrentSubcontractor.Engineer.SetDepartment = (object) str;
        this.CurrentSubcontractor.Engineer.SetServPri = (object) this.txtServPri.Text;
        this.CurrentSubcontractor.Engineer.SetBreakPri = (object) this.txtBreakPri.Text;
        this.CurrentSubcontractor.Engineer.SetDailyServiceLimit = (object) this.txtDailyServiceLimit.Text;
        this.CurrentSubcontractor.Engineer.SetHomePostcode = (object) this.txtPostcode.Text;
        new SubcontractorValidator().Validate(this.CurrentSubcontractor);
        this.CurrentSubcontractor.SetLinkToSupplierID = (object) Combo.get_GetSelectedItemValue(this.cboLinkToSupplier);
        this.CurrentSubcontractor.SetTaxRate = (object) Combo.get_GetSelectedItemValue(this.cboTaxRate);
        if (this.CurrentSubcontractor.Exists)
        {
          App.DB.SubContractor.Update(this.CurrentSubcontractor);
          App.DB.Engineer.Update(this.CurrentSubcontractor.Engineer);
          App.DB.EngineerPostalRegion.Delete(this.CurrentSubcontractor.EngineerID);
          IEnumerator enumerator;
          try
          {
            enumerator = this.PostalRegionsDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(current["Tick"]))
                App.DB.EngineerPostalRegion.Insert(this.CurrentSubcontractor.EngineerID, Conversions.ToInteger(current["ManagerID"]));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          App.DB.EngineerLevel.Insert(this.CurrentSubcontractor.EngineerID, this.TrainingQualificationsDataView.Table);
          App.DB.Engineer.SaveEquipmentRecords(this.CurrentSubcontractor.EngineerID, this.EngineerEquipmentDataView.Table);
          App.DB.Engineer.SaveDisciplinaryRecords(this.CurrentSubcontractor.EngineerID, this.DisciplinariesDataView.Table);
        }
        else
        {
          Engineer engineer = App.DB.Engineer.Insert(this.CurrentSubcontractor.Engineer);
          App.DB.EngineerPostalRegion.Delete(engineer.EngineerID);
          IEnumerator enumerator;
          try
          {
            enumerator = this.PostalRegionsDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(current["Tick"]))
                App.DB.EngineerPostalRegion.Insert(engineer.EngineerID, Conversions.ToInteger(current["ManagerID"]));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          App.DB.EngineerLevel.Insert(engineer.EngineerID, this.TrainingQualificationsDataView.Table);
          App.DB.Engineer.SaveEquipmentRecords(engineer.EngineerID, this.EngineerEquipmentDataView.Table);
          App.DB.Engineer.SaveDisciplinaryRecords(engineer.EngineerID, this.DisciplinariesDataView.Table);
          this.CurrentSubcontractor.Engineer = engineer;
          this.CurrentSubcontractor.SetEngineerID = (object) engineer.EngineerID;
          this.CurrentSubcontractor = App.DB.SubContractor.Insert(this.CurrentSubcontractor);
        }
        if (this.MaxTimes == null)
          this.MaxTimes = new MaxEngineerTime();
        this.MaxTimes.SetEngineerID = (object) this.CurrentSubcontractor.Engineer.EngineerID;
        this.MaxTimes.SetMondayValue = (object) Helper.MakeIntegerValid((object) this.txtMondayValue.Text.Trim());
        this.MaxTimes.SetTuesdayValue = (object) Helper.MakeIntegerValid((object) this.txtTuesdayValue.Text.Trim());
        this.MaxTimes.SetWednesdayValue = (object) Helper.MakeIntegerValid((object) this.txtWednesdayValue.Text.Trim());
        this.MaxTimes.SetThursdayValue = (object) Helper.MakeIntegerValid((object) this.txtThursdayValue.Text.Trim());
        this.MaxTimes.SetFridayValue = (object) Helper.MakeIntegerValid((object) this.txtFridayValue.Text.Trim());
        this.MaxTimes.SetSaturdayValue = (object) Helper.MakeIntegerValid((object) this.txtSaturdayValue.Text.Trim());
        this.MaxTimes.SetSundayValue = (object) Helper.MakeIntegerValid((object) this.txtSundayValue.Text.Trim());
        new MaxEngineerTimeValidator().Validate(this.MaxTimes);
        if (this.MaxTimes.Exists)
          App.DB.MaxEngineerTime.Update(this.MaxTimes);
        else
          App.DB.MaxEngineerTime.Insert(this.MaxTimes);
        // ISSUE: reference to a compiler-generated field
        IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
        if (recordsChangedEvent != null)
          recordsChangedEvent(App.DB.SubContractor.Subcontractor_GetAll(), Enums.PageViewing.Subcontractor, true, false, "");
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentSubcontractor.SubcontractorID);
        App.MainForm.RefreshEntity(this.CurrentSubcontractor.SubcontractorID, "");
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

    public void SetupPostalRegionsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgPostalRegions, false);
      DataGridTableStyle tableStyle = this.dgPostalRegions.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgPostalRegions.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
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
      dataGridLabelColumn.Width = 200;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.MappingName = Enums.TableNames.tblEngineerPostalRegion.ToString();
      this.dgPostalRegions.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgPostalRegions);
    }

    public void SetupTrainingQualificationsDataGrid()
    {
      try
      {
        this.dgTrainingQualifications.TableStyles.Add(new DataGridTableStyle());
        Helper.SetUpDataGrid(this.dgTrainingQualifications, false);
        DataGridTableStyle tableStyle = this.dgTrainingQualifications.TableStyles[0];
        DataGridTextBoxColumn gridTextBoxColumn1 = new DataGridTextBoxColumn();
        gridTextBoxColumn1.HeaderText = "Level\\Qualification";
        gridTextBoxColumn1.MappingName = "Level";
        gridTextBoxColumn1.NullText = "";
        gridTextBoxColumn1.Width = 150;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn1);
        DataGridTextBoxColumn gridTextBoxColumn2 = new DataGridTextBoxColumn();
        gridTextBoxColumn2.HeaderText = "Description";
        gridTextBoxColumn2.MappingName = "Description";
        gridTextBoxColumn2.NullText = "";
        gridTextBoxColumn2.Width = 200;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn2);
        DataGridTextBoxColumn gridTextBoxColumn3 = new DataGridTextBoxColumn();
        gridTextBoxColumn3.HeaderText = "Notes";
        gridTextBoxColumn3.MappingName = "Notes";
        gridTextBoxColumn3.NullText = "";
        gridTextBoxColumn3.Width = 400;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn3);
        DataGridTextBoxColumn gridTextBoxColumn4 = new DataGridTextBoxColumn();
        gridTextBoxColumn4.HeaderText = "Passed";
        gridTextBoxColumn4.MappingName = "DatePassed";
        gridTextBoxColumn4.Format = "dd/MM/yyyy";
        gridTextBoxColumn4.NullText = "";
        gridTextBoxColumn4.Width = 80;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn4);
        DataGridTextBoxColumn gridTextBoxColumn5 = new DataGridTextBoxColumn();
        gridTextBoxColumn5.HeaderText = "Expires";
        gridTextBoxColumn5.MappingName = "DateExpires";
        gridTextBoxColumn5.Format = "dd/MM/yyyy";
        gridTextBoxColumn5.NullText = "";
        gridTextBoxColumn5.Width = 80;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn5);
        DataGridTextBoxColumn gridTextBoxColumn6 = new DataGridTextBoxColumn();
        gridTextBoxColumn6.HeaderText = "Booked";
        gridTextBoxColumn6.MappingName = "DateBooked";
        gridTextBoxColumn6.Format = "dd/MM/yyyy";
        gridTextBoxColumn6.NullText = "";
        gridTextBoxColumn6.Width = 80;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn6);
        tableStyle.MappingName = Enums.TableNames.tblEngineerLevel.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private DataView TrainingQualificationsDataView
    {
      get
      {
        return this._trainingQualificationsDataView;
      }
      set
      {
        if (value != null)
        {
          this._trainingQualificationsDataView = value;
          this._trainingQualificationsDataView.Table.TableName = Enums.TableNames.tblEngineerLevel.ToString();
        }
        this.dgTrainingQualifications.DataSource = (object) this._trainingQualificationsDataView;
      }
    }

    public DataRow SelectedTrainingQualificationsRow
    {
      get
      {
        DataRow dataRow;
        if (this.TrainingQualificationsDataView != null)
          dataRow = this.TrainingQualificationsDataView.Table.Rows.Count <= 0 ? (DataRow) null : this.TrainingQualificationsDataView[this.dgTrainingQualifications.CurrentRowIndex].Row;
        return dataRow;
      }
    }

    private void PopulateTrainingQualifications()
    {
      try
      {
        this.TrainingQualificationsDataView = App.DB.EngineerLevel.GetForSetup(this.CurrentSubcontractor.EngineerID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ClearQualificationDetailPanel()
    {
      ComboBox cboQualification = this.cboQualification;
      Combo.SetSelectedComboItem_By_Value(ref cboQualification, Conversions.ToString(0));
      this.cboQualification = cboQualification;
      this.txtQualificatioNote.Text = "";
      this.dtpQualificationPassed.Checked = false;
      this.dtpQualificationExpires.Checked = false;
    }

    private void btnSaveQualification_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Qualifications))
        App.ShowSecurityError();
      try
      {
        DataRow row = this.TrainingQualificationsDataView.Table.NewRow();
        BaseValidator inValidator = new BaseValidator();
        DataRow dataRow = ((IEnumerable<DataRow>) this.TrainingQualificationsDataView.Table.Select("LevelID = " + Combo.get_GetSelectedItemValue(this.cboQualification))).FirstOrDefault<DataRow>();
        bool flag;
        if (dataRow != null)
        {
          if (App.ShowMessage("This will update the qualification. " + "Do you wish to Procceed.", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
            return;
          flag = true;
        }
        if (this.cboQualification.SelectedIndex == 0)
          inValidator.AddCriticalMessage("'Qualification' is required");
        if (!this.dtpQualificationPassed.Checked)
          inValidator.AddCriticalMessage("'Date Passed' must be specified.");
        if (inValidator.ValidatorMessages.CriticalMessages.Count > 0)
          throw new ValidationException(inValidator);
        row["LevelID"] = (object) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQualification));
        row["Level"] = (object) Combo.get_GetSelectedItemDescription(this.cboQualification).ToString().Split('*')[1].Trim();
        row["Description"] = (object) Combo.get_GetSelectedItemDescription(this.cboQualification).ToString().Split('*')[0].Trim();
        row["Notes"] = (object) this.txtQualificatioNote.Text;
        if (this.dtpQualificationPassed.Checked)
          row["DatePassed"] = (object) this.dtpQualificationPassed.Value;
        if (this.dtpQualificationExpires.Checked)
          row["DateExpires"] = (object) this.dtpQualificationExpires.Value;
        if (this.dtpQualificationBooked.Checked)
          row["DateBooked"] = (object) this.dtpQualificationBooked.Value;
        IEnumerator enumerator;
        if (flag)
        {
          try
          {
            enumerator = dataRow.Table.Columns.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataColumn current = (DataColumn) enumerator.Current;
              dataRow[current] = RuntimeHelpers.GetObjectValue(row[current]);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        else
          this.TrainingQualificationsDataView.Table.Rows.Add(row);
        this.ClearQualificationDetailPanel();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnRemoveTrainingQualifications_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Qualifications))
        App.ShowSecurityError();
      try
      {
        DataRow qualificationsRow = this.SelectedTrainingQualificationsRow;
        if (qualificationsRow != null && MessageBox.Show("Are you sure you want to delete this qualification?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          this.TrainingQualificationsDataView.Table.Rows.Remove(qualificationsRow);
        this.ClearQualificationDetailPanel();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void SetupEngineerEquipmentDataGrid()
    {
      try
      {
        this.dgEquipment.TableStyles.Add(new DataGridTableStyle());
        Helper.SetUpDataGrid(this.dgEquipment, false);
        DataGridTableStyle tableStyle = this.dgEquipment.TableStyles[0];
        DataGridTextBoxColumn gridTextBoxColumn = new DataGridTextBoxColumn();
        gridTextBoxColumn.HeaderText = "Equipment";
        gridTextBoxColumn.MappingName = "Equipment";
        gridTextBoxColumn.NullText = "";
        gridTextBoxColumn.Width = 250;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn);
        tableStyle.MappingName = "tblEngineerEquipment";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private DataView EngineerEquipmentDataView
    {
      get
      {
        return this._engineerEquipmentDataView;
      }
      set
      {
        if (value != null)
        {
          this._engineerEquipmentDataView = value;
          this._engineerEquipmentDataView.Table.TableName = "tblEngineerEquipment";
        }
        this.dgEquipment.DataSource = (object) this._engineerEquipmentDataView;
      }
    }

    public DataRow SelectedEngineerEquipmentRow
    {
      get
      {
        DataRow dataRow;
        if (this.EngineerEquipmentDataView != null)
          dataRow = this.EngineerEquipmentDataView.Table.Rows.Count <= 0 ? (DataRow) null : this.EngineerEquipmentDataView[this.dgEquipment.CurrentRowIndex].Row;
        return dataRow;
      }
    }

    private void PopulateEngineerEquipment()
    {
      try
      {
        this.EngineerEquipmentDataView = new DataView(App.DB.Engineer.GetEquipmentRecords(this.CurrentSubcontractor.EngineerID));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ClearEquipmentDetailPanel()
    {
      this.txtEquipmentTool.Text = "";
    }

    private void btnSaveEquipment_Click(object sender, EventArgs e)
    {
      try
      {
        DataRow row = this.EngineerEquipmentDataView.Table.NewRow();
        BaseValidator inValidator = new BaseValidator();
        if (this.txtEquipmentTool.Text.Length == 0)
          inValidator.AddCriticalMessage("'Equipment\\Tool' cannot be empty.");
        if (inValidator.ValidatorMessages.CriticalMessages.Count > 0)
          throw new ValidationException(inValidator);
        row["Equipment"] = (object) this.txtEquipmentTool.Text;
        this.EngineerEquipmentDataView.Table.Rows.Add(row);
        this.ClearEquipmentDetailPanel();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnRemoveEngineerEquipment_Click(object sender, EventArgs e)
    {
      try
      {
        DataRow engineerEquipmentRow = this.SelectedEngineerEquipmentRow;
        if (engineerEquipmentRow != null && MessageBox.Show("Are you sure you want to delete this equipment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          this.EngineerEquipmentDataView.Table.Rows.Remove(engineerEquipmentRow);
        this.ClearEquipmentDetailPanel();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void SetupDisciplinariesDataGrid()
    {
      try
      {
        this.dgDisciplinaries.TableStyles.Add(new DataGridTableStyle());
        Helper.SetUpDataGrid(this.dgDisciplinaries, false);
        DataGridTableStyle tableStyle = this.dgDisciplinaries.TableStyles[0];
        DataGridTextBoxColumn gridTextBoxColumn1 = new DataGridTextBoxColumn();
        gridTextBoxColumn1.HeaderText = "Disciplinary";
        gridTextBoxColumn1.MappingName = "Disciplinary";
        gridTextBoxColumn1.NullText = "";
        gridTextBoxColumn1.Width = 150;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn1);
        DataGridTextBoxColumn gridTextBoxColumn2 = new DataGridTextBoxColumn();
        gridTextBoxColumn2.HeaderText = "Status";
        gridTextBoxColumn2.MappingName = "DisciplinaryStatus";
        gridTextBoxColumn2.NullText = "";
        gridTextBoxColumn2.Width = 150;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn2);
        DataGridTextBoxColumn gridTextBoxColumn3 = new DataGridTextBoxColumn();
        gridTextBoxColumn3.HeaderText = "Date Issued";
        gridTextBoxColumn3.MappingName = "DateIssued";
        gridTextBoxColumn3.NullText = "";
        gridTextBoxColumn3.Width = 80;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn3);
        tableStyle.MappingName = "tblDisciplinaries";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private DataView DisciplinariesDataView
    {
      get
      {
        return this._disciplinariesDataView;
      }
      set
      {
        if (value != null)
        {
          this._disciplinariesDataView = value;
          this._disciplinariesDataView.Table.TableName = "tblDisciplinaries";
        }
        this.dgDisciplinaries.DataSource = (object) this._disciplinariesDataView;
      }
    }

    public DataRow SelectedDisciplinariesRow
    {
      get
      {
        DataRow dataRow;
        if (this.DisciplinariesDataView != null)
          dataRow = this.DisciplinariesDataView.Table.Rows.Count <= 0 ? (DataRow) null : this.DisciplinariesDataView[this.dgDisciplinaries.CurrentRowIndex].Row;
        return dataRow;
      }
    }

    private void ClearDisciplinaryDetailPanel()
    {
      this.txtDisciplinaryID.Text = "";
      this.txtDisciplinary.Text = "";
      this.dtpDisciplinaryIssued.Checked = false;
      this.cboDisciplinary.SelectedIndex = 0;
    }

    private void PopulateDisciplinaries()
    {
      try
      {
        this.DisciplinariesDataView = new DataView(App.DB.Engineer.GetDisciplinaryRecords(this.CurrentSubcontractor.EngineerID));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnSaveDisciplinaries_Click(object sender, EventArgs e)
    {
      try
      {
        DataRow row;
        if (this.txtDisciplinaryID.Text.Length == 0)
        {
          row = this.DisciplinariesDataView.Table.NewRow();
          row["DisciplinaryID"] = (object) checked (this.DisciplinariesDataView.Table.Rows.Count + 1);
        }
        else
          row = this.SelectedDisciplinariesRow;
        BaseValidator inValidator = new BaseValidator();
        if (this.txtDisciplinary.Text.Length == 0)
          inValidator.AddCriticalMessage("'Disciplinary' cannot be empty.");
        if (!this.dtpDisciplinaryIssued.Checked)
          inValidator.AddCriticalMessage("'Issued' must have a date.");
        if (this.cboDisciplinary.SelectedIndex == 0)
          inValidator.AddCriticalMessage("'Disciplinary Status' required.");
        if (inValidator.ValidatorMessages.CriticalMessages.Count > 0)
          throw new ValidationException(inValidator);
        if (row != null)
        {
          row["Disciplinary"] = (object) this.txtDisciplinary.Text;
          row["DateIssued"] = (object) this.dtpDisciplinaryIssued.Value;
          row["DisciplinaryStatusID"] = (object) Combo.get_GetSelectedItemValue(this.cboDisciplinary);
          row["DisciplinaryStatus"] = (object) Combo.get_GetSelectedItemDescription(this.cboDisciplinary);
        }
        if (this.txtDisciplinaryID.Text.Length == 0)
          this.DisciplinariesDataView.Table.Rows.Add(row);
        else
          row.AcceptChanges();
        this.ClearDisciplinaryDetailPanel();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddDisciplinaries_Click(object sender, EventArgs e)
    {
      try
      {
        this.ClearDisciplinaryDetailPanel();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnEditDisciplinaries_Click(object sender, EventArgs e)
    {
      try
      {
        DataRow disciplinariesRow = this.SelectedDisciplinariesRow;
        if (disciplinariesRow == null)
          return;
        this.txtDisciplinaryID.Text = Conversions.ToString(disciplinariesRow["DisciplinaryID"]);
        this.txtDisciplinary.Text = Conversions.ToString(disciplinariesRow["Disciplinary"]);
        this.dtpDisciplinaryIssued.Value = Conversions.ToDate(disciplinariesRow["DateIssued"]);
        ComboBox cboDisciplinary = this.cboDisciplinary;
        Combo.SetSelectedComboItem_By_Value(ref cboDisciplinary, Conversions.ToString(disciplinariesRow["DisciplinaryStatusID"]));
        this.cboDisciplinary = cboDisciplinary;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnRemoveDisciplinaries_Click(object sender, EventArgs e)
    {
      try
      {
        DataRow disciplinariesRow = this.SelectedDisciplinariesRow;
        if (disciplinariesRow != null && MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          this.DisciplinariesDataView.Table.Rows.Remove(disciplinariesRow);
        this.ClearDisciplinaryDetailPanel();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void SetupAbsenceDataGridGrid()
    {
      this.SuspendLayout();
      Helper.SetUpDataGrid(this.dgAbsences, false);
      DataGridTableStyle tableStyle = this.dgAbsences.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgAbsences.ReadOnly = true;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.MappingName = "Description";
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.Width = 110;
      dataGridLabelColumn1.NullText = "";
      dataGridLabelColumn1.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.MappingName = "DateFrom";
      dataGridLabelColumn2.HeaderText = "Date From";
      dataGridLabelColumn2.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      dataGridLabelColumn2.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.MappingName = "DateTo";
      dataGridLabelColumn3.HeaderText = "Date To";
      dataGridLabelColumn3.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn3.NullText = "";
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.MappingName = "Comments";
      dataGridLabelColumn4.HeaderText = "Comments";
      dataGridLabelColumn4.NullText = "";
      dataGridLabelColumn4.Width = 200;
      dataGridLabelColumn4.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.MappingName = "tblEngineerAbsence";
      this.dgAbsences.TableStyles.Add(tableStyle);
      this.ResumeLayout();
    }

    public DataView AbsencesDataView
    {
      get
      {
        return this._dvAbsences;
      }
      set
      {
        this._dvAbsences = value;
        this._dvAbsences.Table.TableName = "tblEngineerAbsence";
        this.dgAbsences.DataSource = (object) this._dvAbsences;
        this._dvAbsences.AllowNew = false;
        this._dvAbsences.AllowEdit = false;
        this._dvAbsences.AllowDelete = false;
      }
    }

    private void PopulateAbsences()
    {
      try
      {
        this.AbsencesDataView = new DataView(App.DB.EngineerAbsence.GetAbsencesForEngineer(this.CurrentSubcontractor.EngineerID));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgTrainingQualifications_CurrentCellChanged(object sender, EventArgs e)
    {
      try
      {
        ComboBox comboBox = this.cboQualificationType;
        Combo.SetUpCombo(ref comboBox, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
        this.cboQualificationType = comboBox;
        comboBox = this.cboQualification;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, this.SelectedTrainingQualificationsRow[0].ToString());
        this.cboQualification = comboBox;
        this.txtQualificatioNote.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedTrainingQualificationsRow[3]));
        this.dtpQualificationPassed.Value = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedTrainingQualificationsRow[4]));
        this.dtpQualificationExpires.Value = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedTrainingQualificationsRow[5]));
        this.dtpQualificationBooked.Value = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedTrainingQualificationsRow[6]));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void dgPostalRegions_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedPostalRegionDataRow == null)
          return;
        this.SelectedPostalRegionDataRow[0] = (object) !Conversions.ToBoolean(this.dgPostalRegions[this.dgPostalRegions.CurrentRowIndex, 0]);
        this.PostalRegionsDataViewUT.Table.ImportRow(this.SelectedPostalRegionDataRow);
        this.PostalRegionsDataView.Table.Rows.RemoveAt(this.dgPostalRegions.CurrentRowIndex);
        this.PostalRegionsDataViewUT.Table.Select("", "Name ASC");
        this.dgUnTicked.DataSource = (object) this.PostalRegionsDataViewUT;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgUnTicked_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedPostalRegionDataRowUT == null)
          return;
        this.SelectedPostalRegionDataRowUT[0] = (object) !Conversions.ToBoolean(this.dgUnTicked[this.dgUnTicked.CurrentRowIndex, 0]);
        this.PostalRegionsDataView.Table.ImportRow(this.SelectedPostalRegionDataRowUT);
        this.PostalRegionsDataViewUT.Table.Rows.Remove(this.SelectedPostalRegionDataRowUT);
        this.PostalRegionsDataView.Table.Select("", "Name ASC");
        this.dgPostalRegions.DataSource = (object) this.PostalRegionsDataView;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtPCSearch_TextChanged(object sender, EventArgs e)
    {
      this.PostalRegionsDataViewUT.RowFilter = "Name Like '%" + this.txtPCSearch.Text + "%'";
    }

    private void cboQualificationType_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        int skillTypeId = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboQualificationType));
        if (skillTypeId > 0)
        {
          ComboBox cboQualification = this.cboQualification;
          Combo.SetUpCombo(ref cboQualification, App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId).Table, "SkillID", "Skill", Enums.ComboValues.Please_Select);
          this.cboQualification = cboQualification;
        }
        else
        {
          ComboBox cboQualification = this.cboQualification;
          Combo.SetUpComboQual(ref cboQualification, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
          this.cboQualification = cboQualification;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }
  }
}
