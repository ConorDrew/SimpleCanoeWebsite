// Decompiled with JetBrains decompiler
// Type: FSM.UCEngineer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.Engineers.SiteSafetyAudits;
using FSM.Entity.Engineers.SiteSafetyAudits.Enums;
using FSM.Entity.MaxEngineerTimes;
using FSM.Entity.Sys;
using FSM.Entity.Users;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCEngineer : UCBase, IUserControl
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private string oldDepartment;
    private MaxEngineerTime _MaxTimes;
    private Engineer _currentEngineer;
    private DataView postalRegionsDV;
    private DataView postalRegionsDVUT;
    private DataView _trainingQualificationsDataView;
    private DataView _engineerEquipmentDataView;
    private DataView _disciplinariesDataView;
    private DataView _dvAbsences;
    private Engineer _auditor;
    private SiteSafetyAudit SiteSafetyAudit;
    private DataView _dvSiteSafetyAudits;

    public UCEngineer()
    {
      this.Load += new EventHandler(this.UCEngineer_Load);
      this.oldDepartment = string.Empty;
      this.postalRegionsDV = (DataView) null;
      this.postalRegionsDVUT = (DataView) null;
      this._dvAbsences = new DataView();
      this.InitializeComponent();
      this.TabControl1.TabPages.Clear();
      this.TabControl1.TabPages.Add(this.tpMain);
      this.TabControl1.TabPages.Add(this.tpPostalRegions);
      this.TabControl1.TabPages.Add(this.tpMaxTimes);
      this.TabControl1.TabPages.Add(this.tpTrainingQualifications);
      this.TabControl1.TabPages.Add(this.tpHolidayAbsences);
      this.TabControl1.TabPages.Add(this.tpDisciplinary);
      this.TabControl1.TabPages.Add(this.tpKit);
      this.TabControl1.TabPages.Add(this.tpDocuments);
      this.TabControl1.TabPages.Add(this.tpSiteSafetyAudits);
      ComboBox cboRegionId = this.cboRegionID;
      Combo.SetUpCombo(ref cboRegionId, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboRegionID = cboRegionId;
      ComboBox cboEngineerGroup = this.cboEngineerGroup;
      Combo.SetUpCombo(ref cboEngineerGroup, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.EngineerGroup, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboEngineerGroup = cboEngineerGroup;
      ComboBox cboDisciplinary = this.cboDisciplinary;
      Combo.SetUpCombo(ref cboDisciplinary, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.DisciplinaryStatus, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboDisciplinary = cboDisciplinary;
      ComboBox qualificationType = this.cboQualificationType;
      Combo.SetUpCombo(ref qualificationType, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQualificationType = qualificationType;
      ComboBox cboQualification = this.cboQualification;
      Combo.SetUpComboQual(ref cboQualification, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQualification = cboQualification;
      ComboBox cboUser = this.cboUser;
      Combo.SetUpCombo(ref cboUser, App.DB.User.GetAll().Table, "UserID", "FullName", FSM.Entity.Sys.Enums.ComboValues.Not_Applicable);
      this.cboUser = cboUser;
      ComboBox cboRagRating = this.cboRagRating;
      Combo.SetUpCombo(ref cboRagRating, App.DB.RagRating.Get_All().Table, "Id", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboRagRating = cboRagRating;
      ComboBox cboLinkToUser = this.cboLinkToUser;
      Combo.SetUpCombo(ref cboLinkToUser, App.DB.User.GetAll().Table, "UserID", "FullName", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboLinkToUser = cboLinkToUser;
      ComboBox cboEngineerRoleId = this.cboEngineerRoleId;
      Combo.SetUpCombo(ref cboEngineerRoleId, App.DB.EngineerRole.GetLookupData().Table, "Id", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboEngineerRoleId = cboEngineerRoleId;
      if (true == App.IsGasway)
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      else
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineerID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegionID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegionID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkApprentice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpDisciplinary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpTrainingQualifications { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpHolidayAbsences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNextOfKinName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNextOfKinContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpPostalRegions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpPostalRegions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPostalRegions
    {
      get
      {
        return this._dgPostalRegions;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgPostalRegions_Clicks);
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

    internal virtual TabPage tpKit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDrivingLicenceIssueDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDrivingLicenceNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtStartingDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDaysHolidayAllowed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHolidayYearEnd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHolidayYearStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationExpires { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationPassed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDisciplinary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDisciplinaryIssued { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDisciplinary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEquipmentTool { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgTrainingQualifications
    {
      get
      {
        return this._dgTrainingQualifications;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgTrainingQualifications_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgTrainingQualifications_Click);
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

    internal virtual DataGrid dgEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Panel pnlDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgDisciplinaries { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtDisciplinaryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQualificatioNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAbsences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineerGroup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGasSafeNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTechnician { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpMaxTimes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSundayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSaturdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFridayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtThursdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWednesdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTuesdayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMondayValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label33 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label31 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TxtOftec { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label35 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxShowOnJob { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationBooked { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label36 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPCSearch
    {
      get
      {
        return this._txtPCSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtFilter_TextChanged);
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

    internal virtual Label Label37 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgUnTicked
    {
      get
      {
        return this._dgUnTicked;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgPostalRegionsUnticked_Clicks);
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

    internal virtual Label Label38 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBreakPri { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label40 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtServPri { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label39 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label42 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDailyServiceLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label41 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWebAppPassword
    {
      get
      {
        return this._txtWebAppPassword;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox1_TextChanged);
        TextBox txtWebAppPassword1 = this._txtWebAppPassword;
        if (txtWebAppPassword1 != null)
          txtWebAppPassword1.TextChanged -= eventHandler;
        this._txtWebAppPassword = value;
        TextBox txtWebAppPassword2 = this._txtWebAppPassword;
        if (txtWebAppPassword2 == null)
          return;
        txtWebAppPassword2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lbllWebAppPassword
    {
      get
      {
        return this._lbllWebAppPassword;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Label43_Click);
        Label lbllWebAppPassword1 = this._lbllWebAppPassword;
        if (lbllWebAppPassword1 != null)
          lbllWebAppPassword1.Click -= eventHandler;
        this._lbllWebAppPassword = value;
        Label lbllWebAppPassword2 = this._lbllWebAppPassword;
        if (lbllWebAppPassword2 == null)
          return;
        lbllWebAppPassword2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboRagRating { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRagDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRagRating { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpRagDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpSiteSafetyAudits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSiteSafetyAudits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSiteSafetyAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveAudit
    {
      get
      {
        return this._btnSaveAudit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveAudit_Click);
        Button btnSaveAudit1 = this._btnSaveAudit;
        if (btnSaveAudit1 != null)
          btnSaveAudit1.Click -= eventHandler;
        this._btnSaveAudit = value;
        Button btnSaveAudit2 = this._btnSaveAudit;
        if (btnSaveAudit2 == null)
          return;
        btnSaveAudit2.Click += eventHandler;
      }
    }

    internal virtual BackgroundWorker BackgroundWorker1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSiteSafetyAudits
    {
      get
      {
        return this._dgSiteSafetyAudits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgSiteSafetyAudits_Click);
        DataGrid siteSafetyAudits1 = this._dgSiteSafetyAudits;
        if (siteSafetyAudits1 != null)
          siteSafetyAudits1.Click -= eventHandler;
        this._dgSiteSafetyAudits = value;
        DataGrid siteSafetyAudits2 = this._dgSiteSafetyAudits;
        if (siteSafetyAudits2 == null)
          return;
        siteSafetyAudits2.Click += eventHandler;
      }
    }

    internal virtual Button btnNewAudit
    {
      get
      {
        return this._btnNewAudit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNewAudit_Click);
        Button btnNewAudit1 = this._btnNewAudit;
        if (btnNewAudit1 != null)
          btnNewAudit1.Click -= eventHandler;
        this._btnNewAudit = value;
        Button btnNewAudit2 = this._btnNewAudit;
        if (btnNewAudit2 == null)
          return;
        btnNewAudit2.Click += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpAuditDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAuditDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVehicleSafetyCondition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVehicleCheck { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAsbestos { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAsbestos { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCOSSH { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCOSSH { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFirstAidWelfare { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFirstAidWelfare { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWorkingAtHeight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblWorkingAtHeight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtManualHandling { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblManualHandling { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMachineryEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMachineryEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHousekeeping { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblHousekeeping { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEnvironmentalConditions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEnvironmentalConditions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtUniformPPE { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblUniformPPE { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDocumentProcedures { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDocumentationProcedures { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDeleteAudit
    {
      get
      {
        return this._btnDeleteAudit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteAudit_Click);
        Button btnDeleteAudit1 = this._btnDeleteAudit;
        if (btnDeleteAudit1 != null)
          btnDeleteAudit1.Click -= eventHandler;
        this._btnDeleteAudit = value;
        Button btnDeleteAudit2 = this._btnDeleteAudit;
        if (btnDeleteAudit2 == null)
          return;
        btnDeleteAudit2.Click += eventHandler;
      }
    }

    internal virtual Label lblAuditor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtAuditor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVisitSpendLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitSpendLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSiteSafetyAuditInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLinkToUser
    {
      get
      {
        return this._cboLinkToUser;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboLinkToUser_SelectionChangeCommitted);
        ComboBox cboLinkToUser1 = this._cboLinkToUser;
        if (cboLinkToUser1 != null)
          cboLinkToUser1.SelectionChangeCommitted -= eventHandler;
        this._cboLinkToUser = value;
        ComboBox cboLinkToUser2 = this._cboLinkToUser;
        if (cboLinkToUser2 == null)
          return;
        cboLinkToUser2.SelectionChangeCommitted += eventHandler;
      }
    }

    internal virtual Label lblLinkToUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAssignEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineerRoleId { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAbsences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.TabControl1 = new TabControl();
      this.tpMain = new TabPage();
      this.grpEngineer = new GroupBox();
      this.txtEmailAddress = new TextBox();
      this.lblEmailAddress = new Label();
      this.lblAssignEngineerRole = new Label();
      this.cboEngineerRoleId = new ComboBox();
      this.txtVisitSpendLimit = new TextBox();
      this.lblVisitSpendLimit = new Label();
      this.cboLinkToUser = new ComboBox();
      this.lblLinkToUser = new Label();
      this.dtpRagDate = new DateTimePicker();
      this.cboRagRating = new ComboBox();
      this.lblRagDate = new Label();
      this.lblRagRating = new Label();
      this.txtWebAppPassword = new TextBox();
      this.lbllWebAppPassword = new Label();
      this.cboDepartment = new ComboBox();
      this.cboUser = new ComboBox();
      this.txtBreakPri = new TextBox();
      this.Label40 = new Label();
      this.txtServPri = new TextBox();
      this.Label39 = new Label();
      this.TxtOftec = new TextBox();
      this.Label35 = new Label();
      this.Label34 = new Label();
      this.Label26 = new Label();
      this.txtTechnician = new TextBox();
      this.Label25 = new Label();
      this.cboEngineerGroup = new ComboBox();
      this.Label24 = new Label();
      this.txtGasSafeNo = new TextBox();
      this.Label23 = new Label();
      this.dtpDrivingLicenceIssueDate = new DateTimePicker();
      this.Label9 = new Label();
      this.txtDrivingLicenceNo = new TextBox();
      this.Label8 = new Label();
      this.txtStartingDetails = new TextBox();
      this.Label7 = new Label();
      this.txtNextOfKinContact = new TextBox();
      this.Label6 = new Label();
      this.txtNextOfKinName = new TextBox();
      this.Label5 = new Label();
      this.btnVanHistory = new Button();
      this.txtEngineerID = new TextBox();
      this.cboRegionID = new ComboBox();
      this.lblRegionID = new Label();
      this.txtName = new TextBox();
      this.lblName = new Label();
      this.txtTelephoneNum = new TextBox();
      this.lblTelephoneNum = new Label();
      this.lblEngineerID = new Label();
      this.chkApprentice = new CheckBox();
      this.tpMaxTimes = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.txtDailyServiceLimit = new TextBox();
      this.Label41 = new Label();
      this.txtSundayValue = new TextBox();
      this.txtSaturdayValue = new TextBox();
      this.txtFridayValue = new TextBox();
      this.txtThursdayValue = new TextBox();
      this.txtWednesdayValue = new TextBox();
      this.txtTuesdayValue = new TextBox();
      this.txtMondayValue = new TextBox();
      this.Label33 = new Label();
      this.Label32 = new Label();
      this.Label31 = new Label();
      this.Label30 = new Label();
      this.Label29 = new Label();
      this.Label28 = new Label();
      this.Label27 = new Label();
      this.tpTrainingQualifications = new TabPage();
      this.GroupBox5 = new GroupBox();
      this.Panel1 = new Panel();
      this.cboQualificationType = new ComboBox();
      this.lblQualificationType = new Label();
      this.dtpQualificationBooked = new DateTimePicker();
      this.Label36 = new Label();
      this.cbxShowOnJob = new CheckBox();
      this.cboQualification = new ComboBox();
      this.Label22 = new Label();
      this.txtQualificatioNote = new TextBox();
      this.Label13 = new Label();
      this.btnSaveQualification = new Button();
      this.dtpQualificationExpires = new DateTimePicker();
      this.Label15 = new Label();
      this.dtpQualificationPassed = new DateTimePicker();
      this.Label14 = new Label();
      this.btnRemoveTrainingQualifications = new Button();
      this.dgTrainingQualifications = new DataGrid();
      this.tpKit = new TabPage();
      this.GroupBox4 = new GroupBox();
      this.Panel2 = new Panel();
      this.txtEquipmentTool = new TextBox();
      this.Label1 = new Label();
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
      this.Label16 = new Label();
      this.dtpDisciplinaryIssued = new DateTimePicker();
      this.Label17 = new Label();
      this.txtDisciplinary = new TextBox();
      this.Label18 = new Label();
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
      this.Label21 = new Label();
      this.txtHolidayYearEnd = new TextBox();
      this.Label20 = new Label();
      this.txtHolidayYearStart = new TextBox();
      this.Label19 = new Label();
      this.tpPostalRegions = new TabPage();
      this.GroupBox8 = new GroupBox();
      this.Button1 = new Button();
      this.txtPostcode = new TextBox();
      this.Label42 = new Label();
      this.grpPostalRegions = new GroupBox();
      this.Label38 = new Label();
      this.txtPCSearch = new TextBox();
      this.Label37 = new Label();
      this.dgUnTicked = new DataGrid();
      this.dgPostalRegions = new DataGrid();
      this.tpSiteSafetyAudits = new TabPage();
      this.grpSiteSafetyAudits = new GroupBox();
      this.dgSiteSafetyAudits = new DataGrid();
      this.grpSiteSafetyAudit = new GroupBox();
      this.lblSiteSafetyAuditInfo = new Label();
      this.btnfindEngineer = new Button();
      this.txtAuditor = new TextBox();
      this.lblAuditor = new Label();
      this.btnDeleteAudit = new Button();
      this.lblLine = new Label();
      this.txtTotal = new TextBox();
      this.lblTotal = new Label();
      this.txtAsbestos = new TextBox();
      this.lblAsbestos = new Label();
      this.txtCOSSH = new TextBox();
      this.lblCOSSH = new Label();
      this.txtFirstAidWelfare = new TextBox();
      this.lblFirstAidWelfare = new Label();
      this.txtWorkingAtHeight = new TextBox();
      this.lblWorkingAtHeight = new Label();
      this.txtManualHandling = new TextBox();
      this.lblManualHandling = new Label();
      this.txtMachineryEquipment = new TextBox();
      this.lblMachineryEquipment = new Label();
      this.txtHousekeeping = new TextBox();
      this.lblHousekeeping = new Label();
      this.txtEnvironmentalConditions = new TextBox();
      this.lblEnvironmentalConditions = new Label();
      this.txtUniformPPE = new TextBox();
      this.lblUniformPPE = new Label();
      this.txtDocumentProcedures = new TextBox();
      this.lblDocumentationProcedures = new Label();
      this.txtVehicleSafetyCondition = new TextBox();
      this.lblVehicleCheck = new Label();
      this.dtpAuditDate = new DateTimePicker();
      this.lblAuditDate = new Label();
      this.btnNewAudit = new Button();
      this.btnSaveAudit = new Button();
      this.BackgroundWorker1 = new BackgroundWorker();
      this.TabControl1.SuspendLayout();
      this.tpMain.SuspendLayout();
      this.grpEngineer.SuspendLayout();
      this.tpMaxTimes.SuspendLayout();
      this.GroupBox2.SuspendLayout();
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
      this.GroupBox8.SuspendLayout();
      this.grpPostalRegions.SuspendLayout();
      this.dgUnTicked.BeginInit();
      this.dgPostalRegions.BeginInit();
      this.tpSiteSafetyAudits.SuspendLayout();
      this.grpSiteSafetyAudits.SuspendLayout();
      this.dgSiteSafetyAudits.BeginInit();
      this.grpSiteSafetyAudit.SuspendLayout();
      this.SuspendLayout();
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tpMain);
      this.TabControl1.Controls.Add((Control) this.tpMaxTimes);
      this.TabControl1.Controls.Add((Control) this.tpTrainingQualifications);
      this.TabControl1.Controls.Add((Control) this.tpKit);
      this.TabControl1.Controls.Add((Control) this.tpDisciplinary);
      this.TabControl1.Controls.Add((Control) this.tpDocuments);
      this.TabControl1.Controls.Add((Control) this.tpHolidayAbsences);
      this.TabControl1.Controls.Add((Control) this.tpPostalRegions);
      this.TabControl1.Controls.Add((Control) this.tpSiteSafetyAudits);
      this.TabControl1.Location = new System.Drawing.Point(0, 0);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(512, 663);
      this.TabControl1.TabIndex = 1;
      this.tpMain.Controls.Add((Control) this.grpEngineer);
      this.tpMain.Location = new System.Drawing.Point(4, 22);
      this.tpMain.Name = "tpMain";
      this.tpMain.Size = new Size(504, 637);
      this.tpMain.TabIndex = 0;
      this.tpMain.Text = "Main";
      this.tpMain.UseVisualStyleBackColor = true;
      this.grpEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineer.Controls.Add((Control) this.txtEmailAddress);
      this.grpEngineer.Controls.Add((Control) this.lblEmailAddress);
      this.grpEngineer.Controls.Add((Control) this.lblAssignEngineerRole);
      this.grpEngineer.Controls.Add((Control) this.cboEngineerRoleId);
      this.grpEngineer.Controls.Add((Control) this.txtVisitSpendLimit);
      this.grpEngineer.Controls.Add((Control) this.lblVisitSpendLimit);
      this.grpEngineer.Controls.Add((Control) this.cboLinkToUser);
      this.grpEngineer.Controls.Add((Control) this.lblLinkToUser);
      this.grpEngineer.Controls.Add((Control) this.dtpRagDate);
      this.grpEngineer.Controls.Add((Control) this.cboRagRating);
      this.grpEngineer.Controls.Add((Control) this.lblRagDate);
      this.grpEngineer.Controls.Add((Control) this.lblRagRating);
      this.grpEngineer.Controls.Add((Control) this.txtWebAppPassword);
      this.grpEngineer.Controls.Add((Control) this.lbllWebAppPassword);
      this.grpEngineer.Controls.Add((Control) this.cboDepartment);
      this.grpEngineer.Controls.Add((Control) this.cboUser);
      this.grpEngineer.Controls.Add((Control) this.txtBreakPri);
      this.grpEngineer.Controls.Add((Control) this.Label40);
      this.grpEngineer.Controls.Add((Control) this.txtServPri);
      this.grpEngineer.Controls.Add((Control) this.Label39);
      this.grpEngineer.Controls.Add((Control) this.TxtOftec);
      this.grpEngineer.Controls.Add((Control) this.Label35);
      this.grpEngineer.Controls.Add((Control) this.Label34);
      this.grpEngineer.Controls.Add((Control) this.Label26);
      this.grpEngineer.Controls.Add((Control) this.txtTechnician);
      this.grpEngineer.Controls.Add((Control) this.Label25);
      this.grpEngineer.Controls.Add((Control) this.cboEngineerGroup);
      this.grpEngineer.Controls.Add((Control) this.Label24);
      this.grpEngineer.Controls.Add((Control) this.txtGasSafeNo);
      this.grpEngineer.Controls.Add((Control) this.Label23);
      this.grpEngineer.Controls.Add((Control) this.dtpDrivingLicenceIssueDate);
      this.grpEngineer.Controls.Add((Control) this.Label9);
      this.grpEngineer.Controls.Add((Control) this.txtDrivingLicenceNo);
      this.grpEngineer.Controls.Add((Control) this.Label8);
      this.grpEngineer.Controls.Add((Control) this.txtStartingDetails);
      this.grpEngineer.Controls.Add((Control) this.Label7);
      this.grpEngineer.Controls.Add((Control) this.txtNextOfKinContact);
      this.grpEngineer.Controls.Add((Control) this.Label6);
      this.grpEngineer.Controls.Add((Control) this.txtNextOfKinName);
      this.grpEngineer.Controls.Add((Control) this.Label5);
      this.grpEngineer.Controls.Add((Control) this.btnVanHistory);
      this.grpEngineer.Controls.Add((Control) this.txtEngineerID);
      this.grpEngineer.Controls.Add((Control) this.cboRegionID);
      this.grpEngineer.Controls.Add((Control) this.lblRegionID);
      this.grpEngineer.Controls.Add((Control) this.txtName);
      this.grpEngineer.Controls.Add((Control) this.lblName);
      this.grpEngineer.Controls.Add((Control) this.txtTelephoneNum);
      this.grpEngineer.Controls.Add((Control) this.lblTelephoneNum);
      this.grpEngineer.Controls.Add((Control) this.lblEngineerID);
      this.grpEngineer.Controls.Add((Control) this.chkApprentice);
      this.grpEngineer.Location = new System.Drawing.Point(8, 0);
      this.grpEngineer.Name = "grpEngineer";
      this.grpEngineer.Size = new Size(488, 631);
      this.grpEngineer.TabIndex = 0;
      this.grpEngineer.TabStop = false;
      this.grpEngineer.Text = "Details";
      this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmailAddress.Location = new System.Drawing.Point(120, 277);
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(359, 21);
      this.txtEmailAddress.TabIndex = 83;
      this.txtEmailAddress.Tag = (object) "";
      this.lblEmailAddress.Location = new System.Drawing.Point(4, 280);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(104, 20);
      this.lblEmailAddress.TabIndex = 84;
      this.lblEmailAddress.Text = "Email Address";
      this.lblAssignEngineerRole.AutoSize = true;
      this.lblAssignEngineerRole.Location = new System.Drawing.Point(4, 573);
      this.lblAssignEngineerRole.Name = "lblAssignEngineerRole";
      this.lblAssignEngineerRole.Size = new Size(73, 13);
      this.lblAssignEngineerRole.TabIndex = 82;
      this.lblAssignEngineerRole.Text = "Assign Role";
      this.cboEngineerRoleId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineerRoleId.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEngineerRoleId.FormattingEnabled = true;
      this.cboEngineerRoleId.Location = new System.Drawing.Point(117, 566);
      this.cboEngineerRoleId.Name = "cboEngineerRoleId";
      this.cboEngineerRoleId.Size = new Size(362, 21);
      this.cboEngineerRoleId.TabIndex = 81;
      this.txtVisitSpendLimit.Location = new System.Drawing.Point(120, 539);
      this.txtVisitSpendLimit.Name = "txtVisitSpendLimit";
      this.txtVisitSpendLimit.Size = new Size(64, 21);
      this.txtVisitSpendLimit.TabIndex = 80;
      this.lblVisitSpendLimit.AutoSize = true;
      this.lblVisitSpendLimit.Location = new System.Drawing.Point(4, 542);
      this.lblVisitSpendLimit.Name = "lblVisitSpendLimit";
      this.lblVisitSpendLimit.Size = new Size(113, 13);
      this.lblVisitSpendLimit.TabIndex = 79;
      this.lblVisitSpendLimit.Text = "Visit Spend Limit £";
      this.cboLinkToUser.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLinkToUser.FormattingEnabled = true;
      this.cboLinkToUser.Location = new System.Drawing.Point(120, 512);
      this.cboLinkToUser.Name = "cboLinkToUser";
      this.cboLinkToUser.Size = new Size(359, 21);
      this.cboLinkToUser.TabIndex = 69;
      this.lblLinkToUser.AutoSize = true;
      this.lblLinkToUser.Location = new System.Drawing.Point(4, 521);
      this.lblLinkToUser.Name = "lblLinkToUser";
      this.lblLinkToUser.Size = new Size(77, 13);
      this.lblLinkToUser.TabIndex = 68;
      this.lblLinkToUser.Text = "Link To User";
      this.dtpRagDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpRagDate.Location = new System.Drawing.Point(341, 481);
      this.dtpRagDate.Name = "dtpRagDate";
      this.dtpRagDate.Size = new Size(138, 21);
      this.dtpRagDate.TabIndex = 67;
      this.dtpRagDate.Tag = (object) "Van.InsuranceDue";
      this.cboRagRating.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboRagRating.Cursor = Cursors.Hand;
      this.cboRagRating.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRagRating.Location = new System.Drawing.Point(120, 481);
      this.cboRagRating.Name = "cboRagRating";
      this.cboRagRating.Size = new Size(112, 21);
      this.cboRagRating.TabIndex = 66;
      this.cboRagRating.Tag = (object) "";
      this.lblRagDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblRagDate.Location = new System.Drawing.Point(245, 484);
      this.lblRagDate.Name = "lblRagDate";
      this.lblRagDate.Size = new Size(68, 20);
      this.lblRagDate.TabIndex = 65;
      this.lblRagDate.Text = "Rag Date";
      this.lblRagRating.Location = new System.Drawing.Point(4, 480);
      this.lblRagRating.Name = "lblRagRating";
      this.lblRagRating.Size = new Size(112, 20);
      this.lblRagRating.TabIndex = 64;
      this.lblRagRating.Text = "Rag Rating";
      this.txtWebAppPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtWebAppPassword.Location = new System.Drawing.Point(120, 449);
      this.txtWebAppPassword.Name = "txtWebAppPassword";
      this.txtWebAppPassword.PasswordChar = '*';
      this.txtWebAppPassword.Size = new Size(359, 21);
      this.txtWebAppPassword.TabIndex = 60;
      this.txtWebAppPassword.Tag = (object) "Engineer.TelephoneNum";
      this.txtWebAppPassword.UseSystemPasswordChar = true;
      this.lbllWebAppPassword.Location = new System.Drawing.Point(4, 452);
      this.lbllWebAppPassword.Name = "lbllWebAppPassword";
      this.lbllWebAppPassword.Size = new Size(114, 20);
      this.lbllWebAppPassword.TabIndex = 61;
      this.lbllWebAppPassword.Text = "WebApp Password";
      this.cboDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboDepartment.Cursor = Cursors.Hand;
      this.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDepartment.Location = new System.Drawing.Point(120, 151);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(359, 21);
      this.cboDepartment.TabIndex = 59;
      this.cboDepartment.Tag = (object) "";
      this.cboUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboUser.Cursor = Cursors.Hand;
      this.cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboUser.Location = new System.Drawing.Point(120, 202);
      this.cboUser.Name = "cboUser";
      this.cboUser.Size = new Size(359, 21);
      this.cboUser.TabIndex = 58;
      this.cboUser.Tag = (object) "";
      this.txtBreakPri.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtBreakPri.Location = new System.Drawing.Point(292, 605);
      this.txtBreakPri.Name = "txtBreakPri";
      this.txtBreakPri.Size = new Size(41, 21);
      this.txtBreakPri.TabIndex = 57;
      this.txtBreakPri.Text = "1";
      this.Label40.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label40.Location = new System.Drawing.Point(186, 597);
      this.Label40.Name = "Label40";
      this.Label40.Size = new Size(95, 29);
      this.Label40.TabIndex = 56;
      this.Label40.Text = "Breakdown Priority (1-10)";
      this.txtServPri.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtServPri.Location = new System.Drawing.Point(117, 605);
      this.txtServPri.Name = "txtServPri";
      this.txtServPri.Size = new Size(41, 21);
      this.txtServPri.TabIndex = 55;
      this.txtServPri.Text = "1";
      this.Label39.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label39.Location = new System.Drawing.Point(5, 597);
      this.Label39.Name = "Label39";
      this.Label39.Size = new Size(112, 29);
      this.Label39.TabIndex = 54;
      this.Label39.Text = "Service Priority (1-10)";
      this.TxtOftec.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.TxtOftec.Location = new System.Drawing.Point(120, 97);
      this.TxtOftec.Name = "TxtOftec";
      this.TxtOftec.Size = new Size(359, 21);
      this.TxtOftec.TabIndex = 52;
      this.TxtOftec.Tag = (object) "Engineer.Name";
      this.Label35.Location = new System.Drawing.Point(4, 97);
      this.Label35.Name = "Label35";
      this.Label35.Size = new Size(104, 20);
      this.Label35.TabIndex = 53;
      this.Label35.Text = "Oftec No.";
      this.Label34.Location = new System.Drawing.Point(4, 151);
      this.Label34.Name = "Label34";
      this.Label34.Size = new Size(104, 20);
      this.Label34.TabIndex = 51;
      this.Label34.Text = "Department";
      this.Label26.Location = new System.Drawing.Point(4, 205);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(104, 20);
      this.Label26.TabIndex = 49;
      this.Label26.Text = "Manager";
      this.txtTechnician.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTechnician.Location = new System.Drawing.Point(120, 178);
      this.txtTechnician.Name = "txtTechnician";
      this.txtTechnician.Size = new Size(359, 21);
      this.txtTechnician.TabIndex = 5;
      this.txtTechnician.Tag = (object) "";
      this.Label25.Location = new System.Drawing.Point(4, 181);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(104, 20);
      this.Label25.TabIndex = 47;
      this.Label25.Text = "Technician";
      this.cboEngineerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineerGroup.Cursor = Cursors.Hand;
      this.cboEngineerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEngineerGroup.Location = new System.Drawing.Point(120, 124);
      this.cboEngineerGroup.Name = "cboEngineerGroup";
      this.cboEngineerGroup.Size = new Size(359, 21);
      this.cboEngineerGroup.TabIndex = 4;
      this.cboEngineerGroup.Tag = (object) "";
      this.Label24.Location = new System.Drawing.Point(4, 126);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(105, 20);
      this.Label24.TabIndex = 45;
      this.Label24.Text = "Engineer Group";
      this.txtGasSafeNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtGasSafeNo.Location = new System.Drawing.Point(120, 72);
      this.txtGasSafeNo.Name = "txtGasSafeNo";
      this.txtGasSafeNo.Size = new Size(359, 21);
      this.txtGasSafeNo.TabIndex = 3;
      this.txtGasSafeNo.Tag = (object) "Engineer.Name";
      this.Label23.Location = new System.Drawing.Point(4, 72);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(104, 20);
      this.Label23.TabIndex = 43;
      this.Label23.Text = "Gas Safe No.";
      this.dtpDrivingLicenceIssueDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpDrivingLicenceIssueDate.Checked = false;
      this.dtpDrivingLicenceIssueDate.Location = new System.Drawing.Point(319, 347);
      this.dtpDrivingLicenceIssueDate.Name = "dtpDrivingLicenceIssueDate";
      this.dtpDrivingLicenceIssueDate.ShowCheckBox = true;
      this.dtpDrivingLicenceIssueDate.Size = new Size(160, 21);
      this.dtpDrivingLicenceIssueDate.TabIndex = 11;
      this.Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label9.Location = new System.Drawing.Point(240, 352);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(112, 20);
      this.Label9.TabIndex = 41;
      this.Label9.Text = "Issued Date";
      this.txtDrivingLicenceNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDrivingLicenceNo.Location = new System.Drawing.Point(120, 348);
      this.txtDrivingLicenceNo.Name = "txtDrivingLicenceNo";
      this.txtDrivingLicenceNo.Size = new Size(112, 21);
      this.txtDrivingLicenceNo.TabIndex = 10;
      this.Label8.Location = new System.Drawing.Point(4, 347);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(112, 20);
      this.Label8.TabIndex = 39;
      this.Label8.Text = "Driving Licence No";
      this.txtStartingDetails.AcceptsReturn = true;
      this.txtStartingDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtStartingDetails.Location = new System.Drawing.Point(120, 312);
      this.txtStartingDetails.Multiline = true;
      this.txtStartingDetails.Name = "txtStartingDetails";
      this.txtStartingDetails.ScrollBars = ScrollBars.Vertical;
      this.txtStartingDetails.Size = new Size(359, 32);
      this.txtStartingDetails.TabIndex = 9;
      this.Label7.Location = new System.Drawing.Point(4, 315);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(112, 20);
      this.Label7.TabIndex = 37;
      this.Label7.Text = "Starting Details";
      this.txtNextOfKinContact.AcceptsReturn = true;
      this.txtNextOfKinContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNextOfKinContact.Location = new System.Drawing.Point(120, 412);
      this.txtNextOfKinContact.Multiline = true;
      this.txtNextOfKinContact.Name = "txtNextOfKinContact";
      this.txtNextOfKinContact.ScrollBars = ScrollBars.Vertical;
      this.txtNextOfKinContact.Size = new Size(359, 30);
      this.txtNextOfKinContact.TabIndex = 14;
      this.Label6.Location = new System.Drawing.Point(4, 408);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(112, 20);
      this.Label6.TabIndex = 35;
      this.Label6.Text = "Next of Kin Details";
      this.txtNextOfKinName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNextOfKinName.Location = new System.Drawing.Point(120, 388);
      this.txtNextOfKinName.Name = "txtNextOfKinName";
      this.txtNextOfKinName.Size = new Size(359, 21);
      this.txtNextOfKinName.TabIndex = 13;
      this.Label5.Location = new System.Drawing.Point(4, 384);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(112, 20);
      this.Label5.TabIndex = 33;
      this.Label5.Text = "Next of Kin Name";
      this.btnVanHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnVanHistory.Location = new System.Drawing.Point(341, 603);
      this.btnVanHistory.Name = "btnVanHistory";
      this.btnVanHistory.Size = new Size(139, 23);
      this.btnVanHistory.TabIndex = 15;
      this.btnVanHistory.Text = "Stock Profile History";
      this.txtEngineerID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEngineerID.Location = new System.Drawing.Point(120, 250);
      this.txtEngineerID.Name = "txtEngineerID";
      this.txtEngineerID.ReadOnly = true;
      this.txtEngineerID.Size = new Size(359, 21);
      this.txtEngineerID.TabIndex = 8;
      this.txtEngineerID.TabStop = false;
      this.cboRegionID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboRegionID.Cursor = Cursors.Hand;
      this.cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegionID.Location = new System.Drawing.Point(120, 24);
      this.cboRegionID.Name = "cboRegionID";
      this.cboRegionID.Size = new Size(359, 21);
      this.cboRegionID.TabIndex = 1;
      this.cboRegionID.Tag = (object) "Engineer.RegionID";
      this.lblRegionID.Location = new System.Drawing.Point(4, 28);
      this.lblRegionID.Name = "lblRegionID";
      this.lblRegionID.Size = new Size(64, 20);
      this.lblRegionID.TabIndex = 31;
      this.lblRegionID.Text = "Region";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(120, 48);
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(359, 21);
      this.txtName.TabIndex = 2;
      this.txtName.Tag = (object) "Engineer.Name";
      this.lblName.Location = new System.Drawing.Point(4, 48);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(48, 20);
      this.lblName.TabIndex = 31;
      this.lblName.Text = "Name";
      this.txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTelephoneNum.Location = new System.Drawing.Point(120, 226);
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.Size = new Size(359, 21);
      this.txtTelephoneNum.TabIndex = 7;
      this.txtTelephoneNum.Tag = (object) "Engineer.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(4, 229);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(104, 20);
      this.lblTelephoneNum.TabIndex = 31;
      this.lblTelephoneNum.Text = "Telephone";
      this.lblEngineerID.Location = new System.Drawing.Point(4, 253);
      this.lblEngineerID.Name = "lblEngineerID";
      this.lblEngineerID.Size = new Size(94, 20);
      this.lblEngineerID.TabIndex = 31;
      this.lblEngineerID.Text = "Engineer ID";
      this.chkApprentice.Font = new Font("Verdana", 8f);
      this.chkApprentice.Location = new System.Drawing.Point(120, 366);
      this.chkApprentice.Name = "chkApprentice";
      this.chkApprentice.Size = new Size(112, 24);
      this.chkApprentice.TabIndex = 12;
      this.chkApprentice.Tag = (object) "Engineer.Apprentice";
      this.chkApprentice.Text = "Apprentice";
      this.tpMaxTimes.Controls.Add((Control) this.GroupBox2);
      this.tpMaxTimes.Location = new System.Drawing.Point(4, 22);
      this.tpMaxTimes.Name = "tpMaxTimes";
      this.tpMaxTimes.Size = new Size(504, 637);
      this.tpMaxTimes.TabIndex = 8;
      this.tpMaxTimes.Text = "Max SOR Times";
      this.tpMaxTimes.UseVisualStyleBackColor = true;
      this.GroupBox2.Controls.Add((Control) this.txtDailyServiceLimit);
      this.GroupBox2.Controls.Add((Control) this.Label41);
      this.GroupBox2.Controls.Add((Control) this.txtSundayValue);
      this.GroupBox2.Controls.Add((Control) this.txtSaturdayValue);
      this.GroupBox2.Controls.Add((Control) this.txtFridayValue);
      this.GroupBox2.Controls.Add((Control) this.txtThursdayValue);
      this.GroupBox2.Controls.Add((Control) this.txtWednesdayValue);
      this.GroupBox2.Controls.Add((Control) this.txtTuesdayValue);
      this.GroupBox2.Controls.Add((Control) this.txtMondayValue);
      this.GroupBox2.Controls.Add((Control) this.Label33);
      this.GroupBox2.Controls.Add((Control) this.Label32);
      this.GroupBox2.Controls.Add((Control) this.Label31);
      this.GroupBox2.Controls.Add((Control) this.Label30);
      this.GroupBox2.Controls.Add((Control) this.Label29);
      this.GroupBox2.Controls.Add((Control) this.Label28);
      this.GroupBox2.Controls.Add((Control) this.Label27);
      this.GroupBox2.Location = new System.Drawing.Point(3, 3);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(498, 253);
      this.GroupBox2.TabIndex = 0;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Max Schedule Of Rate Times Per Day (In minutes)";
      this.txtDailyServiceLimit.Location = new System.Drawing.Point(163, 226);
      this.txtDailyServiceLimit.Name = "txtDailyServiceLimit";
      this.txtDailyServiceLimit.Size = new Size(131, 21);
      this.txtDailyServiceLimit.TabIndex = 15;
      this.txtDailyServiceLimit.Text = "0";
      this.Label41.AutoSize = true;
      this.Label41.Location = new System.Drawing.Point(29, 229);
      this.Label41.Name = "Label41";
      this.Label41.Size = new Size(114, 13);
      this.Label41.TabIndex = 14;
      this.Label41.Text = "Daily Service Limit";
      this.txtSundayValue.Location = new System.Drawing.Point(163, 175);
      this.txtSundayValue.Name = "txtSundayValue";
      this.txtSundayValue.Size = new Size(131, 21);
      this.txtSundayValue.TabIndex = 13;
      this.txtSundayValue.Text = "0";
      this.txtSaturdayValue.Location = new System.Drawing.Point(163, 150);
      this.txtSaturdayValue.Name = "txtSaturdayValue";
      this.txtSaturdayValue.Size = new Size(131, 21);
      this.txtSaturdayValue.TabIndex = 12;
      this.txtSaturdayValue.Text = "0";
      this.txtFridayValue.Location = new System.Drawing.Point(163, 125);
      this.txtFridayValue.Name = "txtFridayValue";
      this.txtFridayValue.Size = new Size(131, 21);
      this.txtFridayValue.TabIndex = 11;
      this.txtFridayValue.Text = "0";
      this.txtThursdayValue.Location = new System.Drawing.Point(163, 101);
      this.txtThursdayValue.Name = "txtThursdayValue";
      this.txtThursdayValue.Size = new Size(131, 21);
      this.txtThursdayValue.TabIndex = 10;
      this.txtThursdayValue.Text = "0";
      this.txtWednesdayValue.Location = new System.Drawing.Point(163, 77);
      this.txtWednesdayValue.Name = "txtWednesdayValue";
      this.txtWednesdayValue.Size = new Size(131, 21);
      this.txtWednesdayValue.TabIndex = 9;
      this.txtWednesdayValue.Text = "0";
      this.txtTuesdayValue.Location = new System.Drawing.Point(163, 54);
      this.txtTuesdayValue.Name = "txtTuesdayValue";
      this.txtTuesdayValue.Size = new Size(131, 21);
      this.txtTuesdayValue.TabIndex = 8;
      this.txtTuesdayValue.Text = "0";
      this.txtMondayValue.Location = new System.Drawing.Point(163, 30);
      this.txtMondayValue.Name = "txtMondayValue";
      this.txtMondayValue.Size = new Size(131, 21);
      this.txtMondayValue.TabIndex = 7;
      this.txtMondayValue.Text = "0";
      this.Label33.AutoSize = true;
      this.Label33.Location = new System.Drawing.Point(29, 178);
      this.Label33.Name = "Label33";
      this.Label33.Size = new Size(50, 13);
      this.Label33.TabIndex = 6;
      this.Label33.Text = "Sunday";
      this.Label32.AutoSize = true;
      this.Label32.Location = new System.Drawing.Point(28, 153);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(59, 13);
      this.Label32.TabIndex = 5;
      this.Label32.Text = "Saturday";
      this.Label31.AutoSize = true;
      this.Label31.Location = new System.Drawing.Point(28, 128);
      this.Label31.Name = "Label31";
      this.Label31.Size = new Size(42, 13);
      this.Label31.TabIndex = 4;
      this.Label31.Text = "Friday";
      this.Label30.AutoSize = true;
      this.Label30.Location = new System.Drawing.Point(28, 104);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(60, 13);
      this.Label30.TabIndex = 3;
      this.Label30.Text = "Thursday";
      this.Label29.AutoSize = true;
      this.Label29.Location = new System.Drawing.Point(28, 80);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(72, 13);
      this.Label29.TabIndex = 2;
      this.Label29.Text = "Wednesday";
      this.Label28.AutoSize = true;
      this.Label28.Location = new System.Drawing.Point(28, 57);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(54, 13);
      this.Label28.TabIndex = 1;
      this.Label28.Text = "Tuesday";
      this.Label27.AutoSize = true;
      this.Label27.Location = new System.Drawing.Point(28, 33);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(51, 13);
      this.Label27.TabIndex = 0;
      this.Label27.Text = "Monday";
      this.tpTrainingQualifications.Controls.Add((Control) this.GroupBox5);
      this.tpTrainingQualifications.Location = new System.Drawing.Point(4, 22);
      this.tpTrainingQualifications.Name = "tpTrainingQualifications";
      this.tpTrainingQualifications.Size = new Size(504, 637);
      this.tpTrainingQualifications.TabIndex = 3;
      this.tpTrainingQualifications.Text = "Training & Qualifications";
      this.tpTrainingQualifications.UseVisualStyleBackColor = true;
      this.GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox5.Controls.Add((Control) this.Panel1);
      this.GroupBox5.Controls.Add((Control) this.btnRemoveTrainingQualifications);
      this.GroupBox5.Controls.Add((Control) this.dgTrainingQualifications);
      this.GroupBox5.Location = new System.Drawing.Point(8, 8);
      this.GroupBox5.Name = "GroupBox5";
      this.GroupBox5.Size = new Size(488, 623);
      this.GroupBox5.TabIndex = 13;
      this.GroupBox5.TabStop = false;
      this.GroupBox5.Text = "Training && Qualifications";
      this.Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel1.Controls.Add((Control) this.cboQualificationType);
      this.Panel1.Controls.Add((Control) this.lblQualificationType);
      this.Panel1.Controls.Add((Control) this.dtpQualificationBooked);
      this.Panel1.Controls.Add((Control) this.Label36);
      this.Panel1.Controls.Add((Control) this.cbxShowOnJob);
      this.Panel1.Controls.Add((Control) this.cboQualification);
      this.Panel1.Controls.Add((Control) this.Label22);
      this.Panel1.Controls.Add((Control) this.txtQualificatioNote);
      this.Panel1.Controls.Add((Control) this.Label13);
      this.Panel1.Controls.Add((Control) this.btnSaveQualification);
      this.Panel1.Controls.Add((Control) this.dtpQualificationExpires);
      this.Panel1.Controls.Add((Control) this.Label15);
      this.Panel1.Controls.Add((Control) this.dtpQualificationPassed);
      this.Panel1.Controls.Add((Control) this.Label14);
      this.Panel1.Location = new System.Drawing.Point(5, 17);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(475, 212);
      this.Panel1.TabIndex = 42;
      this.cboQualificationType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboQualificationType.Location = new System.Drawing.Point(140, 4);
      this.cboQualificationType.Name = "cboQualificationType";
      this.cboQualificationType.Size = new Size(324, 21);
      this.cboQualificationType.TabIndex = 52;
      this.cboQualificationType.Text = "ComboBox1";
      this.lblQualificationType.Location = new System.Drawing.Point(8, 4);
      this.lblQualificationType.Name = "lblQualificationType";
      this.lblQualificationType.Size = new Size(126, 23);
      this.lblQualificationType.TabIndex = 53;
      this.lblQualificationType.Text = "Qualification Type";
      this.dtpQualificationBooked.Checked = false;
      this.dtpQualificationBooked.Location = new System.Drawing.Point(96, 107);
      this.dtpQualificationBooked.Name = "dtpQualificationBooked";
      this.dtpQualificationBooked.ShowCheckBox = true;
      this.dtpQualificationBooked.Size = new Size(152, 21);
      this.dtpQualificationBooked.TabIndex = 50;
      this.Label36.Location = new System.Drawing.Point(8, 107);
      this.Label36.Name = "Label36";
      this.Label36.Size = new Size(80, 23);
      this.Label36.TabIndex = 51;
      this.Label36.Text = "Booked";
      this.cbxShowOnJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbxShowOnJob.AutoSize = true;
      this.cbxShowOnJob.Enabled = false;
      this.cbxShowOnJob.Location = new System.Drawing.Point(96, 181);
      this.cbxShowOnJob.Name = "cbxShowOnJob";
      this.cbxShowOnJob.Size = new Size(98, 17);
      this.cbxShowOnJob.TabIndex = 49;
      this.cbxShowOnJob.Text = "Show on Job";
      this.cbxShowOnJob.TextAlign = ContentAlignment.MiddleRight;
      this.cbxShowOnJob.UseVisualStyleBackColor = true;
      this.cbxShowOnJob.Visible = false;
      this.cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboQualification.Location = new System.Drawing.Point(96, 30);
      this.cboQualification.Name = "cboQualification";
      this.cboQualification.Size = new Size(368, 21);
      this.cboQualification.TabIndex = 1;
      this.cboQualification.Text = "ComboBox1";
      this.Label22.Location = new System.Drawing.Point(8, 30);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(100, 23);
      this.Label22.TabIndex = 48;
      this.Label22.Text = "Qualification";
      this.txtQualificatioNote.AcceptsReturn = true;
      this.txtQualificatioNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQualificatioNote.Location = new System.Drawing.Point(96, 133);
      this.txtQualificatioNote.Multiline = true;
      this.txtQualificatioNote.Name = "txtQualificatioNote";
      this.txtQualificatioNote.ScrollBars = ScrollBars.Vertical;
      this.txtQualificatioNote.Size = new Size(368, 42);
      this.txtQualificatioNote.TabIndex = 4;
      this.Label13.Location = new System.Drawing.Point(8, 136);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(67, 20);
      this.Label13.TabIndex = 47;
      this.Label13.Text = "Note";
      this.btnSaveQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveQualification.Location = new System.Drawing.Point(327, 181);
      this.btnSaveQualification.Name = "btnSaveQualification";
      this.btnSaveQualification.Size = new Size(137, 23);
      this.btnSaveQualification.TabIndex = 5;
      this.btnSaveQualification.Text = "Add / Update";
      this.dtpQualificationExpires.Checked = false;
      this.dtpQualificationExpires.Location = new System.Drawing.Point(96, 80);
      this.dtpQualificationExpires.Name = "dtpQualificationExpires";
      this.dtpQualificationExpires.ShowCheckBox = true;
      this.dtpQualificationExpires.Size = new Size(152, 21);
      this.dtpQualificationExpires.TabIndex = 3;
      this.Label15.Location = new System.Drawing.Point(8, 80);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(80, 23);
      this.Label15.TabIndex = 43;
      this.Label15.Text = "Expires";
      this.dtpQualificationPassed.Checked = false;
      this.dtpQualificationPassed.Location = new System.Drawing.Point(96, 56);
      this.dtpQualificationPassed.Name = "dtpQualificationPassed";
      this.dtpQualificationPassed.ShowCheckBox = true;
      this.dtpQualificationPassed.Size = new Size(152, 21);
      this.dtpQualificationPassed.TabIndex = 2;
      this.Label14.Location = new System.Drawing.Point(8, 56);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(80, 23);
      this.Label14.TabIndex = 41;
      this.Label14.Text = "Date Passed";
      this.btnRemoveTrainingQualifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveTrainingQualifications.Location = new System.Drawing.Point(10, 591);
      this.btnRemoveTrainingQualifications.Name = "btnRemoveTrainingQualifications";
      this.btnRemoveTrainingQualifications.Size = new Size(75, 21);
      this.btnRemoveTrainingQualifications.TabIndex = 7;
      this.btnRemoveTrainingQualifications.Text = "Delete";
      this.dgTrainingQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTrainingQualifications.DataMember = "";
      this.dgTrainingQualifications.HeaderForeColor = SystemColors.ControlText;
      this.dgTrainingQualifications.Location = new System.Drawing.Point(8, 235);
      this.dgTrainingQualifications.Name = "dgTrainingQualifications";
      this.dgTrainingQualifications.Size = new Size(472, 348);
      this.dgTrainingQualifications.TabIndex = 6;
      this.tpKit.Controls.Add((Control) this.GroupBox4);
      this.tpKit.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tpKit.Location = new System.Drawing.Point(4, 22);
      this.tpKit.Name = "tpKit";
      this.tpKit.Size = new Size(504, 637);
      this.tpKit.TabIndex = 4;
      this.tpKit.Text = "Equipment";
      this.tpKit.UseVisualStyleBackColor = true;
      this.GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox4.Controls.Add((Control) this.Panel2);
      this.GroupBox4.Controls.Add((Control) this.btnRemoveEngineerEquipment);
      this.GroupBox4.Controls.Add((Control) this.dgEquipment);
      this.GroupBox4.Location = new System.Drawing.Point(8, 8);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(488, 623);
      this.GroupBox4.TabIndex = 13;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Specialised Equipment and Tools Issued";
      this.Panel2.Controls.Add((Control) this.txtEquipmentTool);
      this.Panel2.Controls.Add((Control) this.Label1);
      this.Panel2.Controls.Add((Control) this.btnSaveEquipment);
      this.Panel2.Location = new System.Drawing.Point(8, 16);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(472, 64);
      this.Panel2.TabIndex = 2;
      this.txtEquipmentTool.AcceptsReturn = true;
      this.txtEquipmentTool.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEquipmentTool.Location = new System.Drawing.Point(115, 4);
      this.txtEquipmentTool.MaxLength = (int) byte.MaxValue;
      this.txtEquipmentTool.Multiline = true;
      this.txtEquipmentTool.Name = "txtEquipmentTool";
      this.txtEquipmentTool.ScrollBars = ScrollBars.Vertical;
      this.txtEquipmentTool.Size = new Size(256, 56);
      this.txtEquipmentTool.TabIndex = 1;
      this.txtEquipmentTool.Tag = (object) "Engineer.Name";
      this.Label1.Location = new System.Drawing.Point(3, 4);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(112, 20);
      this.Label1.TabIndex = 55;
      this.Label1.Text = "Equipment\\Tool";
      this.btnSaveEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveEquipment.Location = new System.Drawing.Point(384, 36);
      this.btnSaveEquipment.Name = "btnSaveEquipment";
      this.btnSaveEquipment.Size = new Size(75, 23);
      this.btnSaveEquipment.TabIndex = 2;
      this.btnSaveEquipment.Text = "Save";
      this.btnRemoveEngineerEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveEngineerEquipment.Location = new System.Drawing.Point(8, 591);
      this.btnRemoveEngineerEquipment.Name = "btnRemoveEngineerEquipment";
      this.btnRemoveEngineerEquipment.Size = new Size(75, 23);
      this.btnRemoveEngineerEquipment.TabIndex = 4;
      this.btnRemoveEngineerEquipment.Text = "Delete";
      this.dgEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgEquipment.DataMember = "";
      this.dgEquipment.HeaderForeColor = SystemColors.ControlText;
      this.dgEquipment.Location = new System.Drawing.Point(8, 103);
      this.dgEquipment.Name = "dgEquipment";
      this.dgEquipment.Size = new Size(472, 480);
      this.dgEquipment.TabIndex = 3;
      this.tpDisciplinary.Controls.Add((Control) this.GroupBox6);
      this.tpDisciplinary.Location = new System.Drawing.Point(4, 22);
      this.tpDisciplinary.Name = "tpDisciplinary";
      this.tpDisciplinary.Size = new Size(504, 637);
      this.tpDisciplinary.TabIndex = 2;
      this.tpDisciplinary.Text = "Disciplinary";
      this.tpDisciplinary.UseVisualStyleBackColor = true;
      this.GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox6.Controls.Add((Control) this.btnAddDisciplinaries);
      this.GroupBox6.Controls.Add((Control) this.Panel3);
      this.GroupBox6.Controls.Add((Control) this.btnRemoveDisciplinaries);
      this.GroupBox6.Controls.Add((Control) this.btnEditDisciplinaries);
      this.GroupBox6.Controls.Add((Control) this.dgDisciplinaries);
      this.GroupBox6.Location = new System.Drawing.Point(8, 8);
      this.GroupBox6.Name = "GroupBox6";
      this.GroupBox6.Size = new Size(488, 519);
      this.GroupBox6.TabIndex = 14;
      this.GroupBox6.TabStop = false;
      this.GroupBox6.Text = "Disciplinary Records";
      this.btnAddDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddDisciplinaries.Location = new System.Drawing.Point(8, 487);
      this.btnAddDisciplinaries.Name = "btnAddDisciplinaries";
      this.btnAddDisciplinaries.Size = new Size(75, 21);
      this.btnAddDisciplinaries.TabIndex = 6;
      this.btnAddDisciplinaries.Text = "Add";
      this.Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel3.Controls.Add((Control) this.txtDisciplinaryID);
      this.Panel3.Controls.Add((Control) this.cboDisciplinary);
      this.Panel3.Controls.Add((Control) this.btnSaveDisciplinaries);
      this.Panel3.Controls.Add((Control) this.Label16);
      this.Panel3.Controls.Add((Control) this.dtpDisciplinaryIssued);
      this.Panel3.Controls.Add((Control) this.Label17);
      this.Panel3.Controls.Add((Control) this.txtDisciplinary);
      this.Panel3.Controls.Add((Control) this.Label18);
      this.Panel3.Location = new System.Drawing.Point(5, 25);
      this.Panel3.Name = "Panel3";
      this.Panel3.Size = new Size(475, 80);
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
      this.cboDisciplinary.Size = new Size(272, 21);
      this.cboDisciplinary.TabIndex = 3;
      this.cboDisciplinary.Text = "ComboBox2";
      this.btnSaveDisciplinaries.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveDisciplinaries.Location = new System.Drawing.Point(376, 53);
      this.btnSaveDisciplinaries.Name = "btnSaveDisciplinaries";
      this.btnSaveDisciplinaries.Size = new Size(88, 21);
      this.btnSaveDisciplinaries.TabIndex = 4;
      this.btnSaveDisciplinaries.Text = "Save";
      this.Label16.Location = new System.Drawing.Point(8, 53);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(80, 23);
      this.Label16.TabIndex = 43;
      this.Label16.Text = "Status";
      this.dtpDisciplinaryIssued.Checked = false;
      this.dtpDisciplinaryIssued.Location = new System.Drawing.Point(96, 29);
      this.dtpDisciplinaryIssued.Name = "dtpDisciplinaryIssued";
      this.dtpDisciplinaryIssued.ShowCheckBox = true;
      this.dtpDisciplinaryIssued.Size = new Size(152, 21);
      this.dtpDisciplinaryIssued.TabIndex = 2;
      this.Label17.Location = new System.Drawing.Point(8, 29);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(80, 23);
      this.Label17.TabIndex = 41;
      this.Label17.Text = "Issued";
      this.txtDisciplinary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDisciplinary.Location = new System.Drawing.Point(96, 5);
      this.txtDisciplinary.Name = "txtDisciplinary";
      this.txtDisciplinary.Size = new Size(376, 21);
      this.txtDisciplinary.TabIndex = 1;
      this.Label18.Location = new System.Drawing.Point(8, 5);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(80, 20);
      this.Label18.TabIndex = 40;
      this.Label18.Text = "Disciplinary";
      this.btnRemoveDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveDisciplinaries.Location = new System.Drawing.Point(168, 487);
      this.btnRemoveDisciplinaries.Name = "btnRemoveDisciplinaries";
      this.btnRemoveDisciplinaries.Size = new Size(75, 21);
      this.btnRemoveDisciplinaries.TabIndex = 7;
      this.btnRemoveDisciplinaries.Text = "Delete";
      this.btnEditDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnEditDisciplinaries.Location = new System.Drawing.Point(88, 487);
      this.btnEditDisciplinaries.Name = "btnEditDisciplinaries";
      this.btnEditDisciplinaries.Size = new Size(75, 21);
      this.btnEditDisciplinaries.TabIndex = 6;
      this.btnEditDisciplinaries.Text = "Edit";
      this.dgDisciplinaries.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgDisciplinaries.DataMember = "";
      this.dgDisciplinaries.HeaderForeColor = SystemColors.ControlText;
      this.dgDisciplinaries.Location = new System.Drawing.Point(8, 113);
      this.dgDisciplinaries.Name = "dgDisciplinaries";
      this.dgDisciplinaries.Size = new Size(472, 366);
      this.dgDisciplinaries.TabIndex = 5;
      this.tpDocuments.Controls.Add((Control) this.pnlDocuments);
      this.tpDocuments.Location = new System.Drawing.Point(4, 22);
      this.tpDocuments.Name = "tpDocuments";
      this.tpDocuments.Size = new Size(504, 637);
      this.tpDocuments.TabIndex = 6;
      this.tpDocuments.Text = "Documents";
      this.tpDocuments.UseVisualStyleBackColor = true;
      this.pnlDocuments.Dock = DockStyle.Fill;
      this.pnlDocuments.Location = new System.Drawing.Point(0, 0);
      this.pnlDocuments.Name = "pnlDocuments";
      this.pnlDocuments.Size = new Size(504, 637);
      this.pnlDocuments.TabIndex = 0;
      this.tpHolidayAbsences.Controls.Add((Control) this.grpAbsences);
      this.tpHolidayAbsences.Controls.Add((Control) this.GroupBox7);
      this.tpHolidayAbsences.Location = new System.Drawing.Point(4, 22);
      this.tpHolidayAbsences.Name = "tpHolidayAbsences";
      this.tpHolidayAbsences.Size = new Size(504, 637);
      this.tpHolidayAbsences.TabIndex = 5;
      this.tpHolidayAbsences.Text = "Holidays & Absences";
      this.tpHolidayAbsences.UseVisualStyleBackColor = true;
      this.grpAbsences.Controls.Add((Control) this.dgAbsences);
      this.grpAbsences.Location = new System.Drawing.Point(8, 112);
      this.grpAbsences.Name = "grpAbsences";
      this.grpAbsences.Size = new Size(488, 328);
      this.grpAbsences.TabIndex = 4;
      this.grpAbsences.TabStop = false;
      this.grpAbsences.Text = "Absences";
      this.dgAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAbsences.DataMember = "";
      this.dgAbsences.HeaderForeColor = SystemColors.ControlText;
      this.dgAbsences.Location = new System.Drawing.Point(8, 21);
      this.dgAbsences.Name = "dgAbsences";
      this.dgAbsences.Size = new Size(472, 299);
      this.dgAbsences.TabIndex = 4;
      this.GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox7.Controls.Add((Control) this.txtDaysHolidayAllowed);
      this.GroupBox7.Controls.Add((Control) this.Label21);
      this.GroupBox7.Controls.Add((Control) this.txtHolidayYearEnd);
      this.GroupBox7.Controls.Add((Control) this.Label20);
      this.GroupBox7.Controls.Add((Control) this.txtHolidayYearStart);
      this.GroupBox7.Controls.Add((Control) this.Label19);
      this.GroupBox7.Location = new System.Drawing.Point(8, 8);
      this.GroupBox7.Name = "GroupBox7";
      this.GroupBox7.Size = new Size(488, 104);
      this.GroupBox7.TabIndex = 0;
      this.GroupBox7.TabStop = false;
      this.GroupBox7.Text = "Holiday Entitlement";
      this.txtDaysHolidayAllowed.Location = new System.Drawing.Point(144, 72);
      this.txtDaysHolidayAllowed.Name = "txtDaysHolidayAllowed";
      this.txtDaysHolidayAllowed.Size = new Size(100, 21);
      this.txtDaysHolidayAllowed.TabIndex = 3;
      this.Label21.Location = new System.Drawing.Point(16, 72);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(128, 23);
      this.Label21.TabIndex = 4;
      this.Label21.Text = "Holiday Entitlement";
      this.txtHolidayYearEnd.Location = new System.Drawing.Point(144, 48);
      this.txtHolidayYearEnd.Name = "txtHolidayYearEnd";
      this.txtHolidayYearEnd.Size = new Size(100, 21);
      this.txtHolidayYearEnd.TabIndex = 2;
      this.Label20.Location = new System.Drawing.Point(16, 48);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(128, 23);
      this.Label20.TabIndex = 2;
      this.Label20.Text = "End Period (dd/mm)";
      this.txtHolidayYearStart.Location = new System.Drawing.Point(144, 24);
      this.txtHolidayYearStart.Name = "txtHolidayYearStart";
      this.txtHolidayYearStart.Size = new Size(100, 21);
      this.txtHolidayYearStart.TabIndex = 1;
      this.Label19.Location = new System.Drawing.Point(16, 24);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(128, 23);
      this.Label19.TabIndex = 0;
      this.Label19.Text = "Start Period (dd/mm)";
      this.tpPostalRegions.Controls.Add((Control) this.GroupBox8);
      this.tpPostalRegions.Controls.Add((Control) this.grpPostalRegions);
      this.tpPostalRegions.Location = new System.Drawing.Point(4, 22);
      this.tpPostalRegions.Name = "tpPostalRegions";
      this.tpPostalRegions.Size = new Size(504, 637);
      this.tpPostalRegions.TabIndex = 7;
      this.tpPostalRegions.Text = "Postal Regions";
      this.tpPostalRegions.UseVisualStyleBackColor = true;
      this.GroupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox8.Controls.Add((Control) this.Button1);
      this.GroupBox8.Controls.Add((Control) this.txtPostcode);
      this.GroupBox8.Controls.Add((Control) this.Label42);
      this.GroupBox8.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox8.Location = new System.Drawing.Point(8, 34);
      this.GroupBox8.Name = "GroupBox8";
      this.GroupBox8.Size = new Size(488, 70);
      this.GroupBox8.TabIndex = 13;
      this.GroupBox8.TabStop = false;
      this.GroupBox8.Text = "Home ";
      this.Button1.Location = new System.Drawing.Point(288, 24);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 43;
      this.Button1.Text = "Button1";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button1.Visible = false;
      this.txtPostcode.Location = new System.Drawing.Point(132, 25);
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(123, 21);
      this.txtPostcode.TabIndex = 41;
      this.Label42.Location = new System.Drawing.Point(29, 28);
      this.Label42.Name = "Label42";
      this.Label42.Size = new Size(97, 20);
      this.Label42.TabIndex = 42;
      this.Label42.Text = "Home Postcode";
      this.grpPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPostalRegions.Controls.Add((Control) this.Label38);
      this.grpPostalRegions.Controls.Add((Control) this.txtPCSearch);
      this.grpPostalRegions.Controls.Add((Control) this.Label37);
      this.grpPostalRegions.Controls.Add((Control) this.dgUnTicked);
      this.grpPostalRegions.Controls.Add((Control) this.dgPostalRegions);
      this.grpPostalRegions.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpPostalRegions.Location = new System.Drawing.Point(8, 110);
      this.grpPostalRegions.Name = "grpPostalRegions";
      this.grpPostalRegions.Size = new Size(488, 524);
      this.grpPostalRegions.TabIndex = 12;
      this.grpPostalRegions.TabStop = false;
      this.grpPostalRegions.Text = "Postal Regions";
      this.Label38.Font = new Font("Verdana", 10.25f);
      this.Label38.Location = new System.Drawing.Point(8, 56);
      this.Label38.Name = "Label38";
      this.Label38.Size = new Size(235, 20);
      this.Label38.TabIndex = 43;
      this.Label38.Text = "Assigned Areas";
      this.Label38.TextAlign = ContentAlignment.MiddleCenter;
      this.txtPCSearch.Location = new System.Drawing.Point(341, 55);
      this.txtPCSearch.Name = "txtPCSearch";
      this.txtPCSearch.Size = new Size(123, 21);
      this.txtPCSearch.TabIndex = 41;
      this.Label37.Location = new System.Drawing.Point(258, 58);
      this.Label37.Name = "Label37";
      this.Label37.Size = new Size(59, 20);
      this.Label37.TabIndex = 42;
      this.Label37.Text = "Search";
      this.dgUnTicked.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgUnTicked.CaptionFont = new Font("Verdana", 8.25f, FontStyle.Bold);
      this.dgUnTicked.DataMember = "";
      this.dgUnTicked.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dgUnTicked.HeaderForeColor = SystemColors.ControlText;
      this.dgUnTicked.Location = new System.Drawing.Point(249, 85);
      this.dgUnTicked.Name = "dgUnTicked";
      this.dgUnTicked.Size = new Size(233, 433);
      this.dgUnTicked.TabIndex = 1;
      this.dgPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgPostalRegions.CaptionFont = new Font("Verdana", 8.25f, FontStyle.Bold);
      this.dgPostalRegions.DataMember = "";
      this.dgPostalRegions.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dgPostalRegions.HeaderForeColor = SystemColors.ControlText;
      this.dgPostalRegions.Location = new System.Drawing.Point(8, 85);
      this.dgPostalRegions.Name = "dgPostalRegions";
      this.dgPostalRegions.Size = new Size(235, 433);
      this.dgPostalRegions.TabIndex = 0;
      this.tpSiteSafetyAudits.AccessibleRole = AccessibleRole.None;
      this.tpSiteSafetyAudits.Controls.Add((Control) this.grpSiteSafetyAudits);
      this.tpSiteSafetyAudits.Controls.Add((Control) this.grpSiteSafetyAudit);
      this.tpSiteSafetyAudits.Location = new System.Drawing.Point(4, 22);
      this.tpSiteSafetyAudits.Name = "tpSiteSafetyAudits";
      this.tpSiteSafetyAudits.Size = new Size(504, 637);
      this.tpSiteSafetyAudits.TabIndex = 9;
      this.tpSiteSafetyAudits.Text = "Site Safety Audits";
      this.tpSiteSafetyAudits.UseVisualStyleBackColor = true;
      this.grpSiteSafetyAudits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSiteSafetyAudits.Controls.Add((Control) this.dgSiteSafetyAudits);
      this.grpSiteSafetyAudits.Location = new System.Drawing.Point(3, 442);
      this.grpSiteSafetyAudits.Name = "grpSiteSafetyAudits";
      this.grpSiteSafetyAudits.Size = new Size(498, 192);
      this.grpSiteSafetyAudits.TabIndex = 1;
      this.grpSiteSafetyAudits.TabStop = false;
      this.grpSiteSafetyAudits.Text = "Site Safety Audits";
      this.dgSiteSafetyAudits.DataMember = "";
      this.dgSiteSafetyAudits.Dock = DockStyle.Fill;
      this.dgSiteSafetyAudits.HeaderForeColor = SystemColors.ControlText;
      this.dgSiteSafetyAudits.Location = new System.Drawing.Point(3, 17);
      this.dgSiteSafetyAudits.Name = "dgSiteSafetyAudits";
      this.dgSiteSafetyAudits.Size = new Size(492, 172);
      this.dgSiteSafetyAudits.TabIndex = 16;
      this.grpSiteSafetyAudit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblSiteSafetyAuditInfo);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.btnfindEngineer);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtAuditor);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblAuditor);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.btnDeleteAudit);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblLine);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtTotal);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblTotal);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtAsbestos);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblAsbestos);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtCOSSH);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblCOSSH);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtFirstAidWelfare);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblFirstAidWelfare);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtWorkingAtHeight);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblWorkingAtHeight);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtManualHandling);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblManualHandling);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtMachineryEquipment);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblMachineryEquipment);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtHousekeeping);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblHousekeeping);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtEnvironmentalConditions);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblEnvironmentalConditions);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtUniformPPE);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblUniformPPE);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtDocumentProcedures);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblDocumentationProcedures);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.txtVehicleSafetyCondition);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblVehicleCheck);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.dtpAuditDate);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.lblAuditDate);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.btnNewAudit);
      this.grpSiteSafetyAudit.Controls.Add((Control) this.btnSaveAudit);
      this.grpSiteSafetyAudit.Location = new System.Drawing.Point(3, 3);
      this.grpSiteSafetyAudit.Name = "grpSiteSafetyAudit";
      this.grpSiteSafetyAudit.Size = new Size(498, 433);
      this.grpSiteSafetyAudit.TabIndex = 0;
      this.grpSiteSafetyAudit.TabStop = false;
      this.grpSiteSafetyAudit.Text = "Site Safety Audit";
      this.lblSiteSafetyAuditInfo.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblSiteSafetyAuditInfo.Location = new System.Drawing.Point(6, 18);
      this.lblSiteSafetyAuditInfo.Name = "lblSiteSafetyAuditInfo";
      this.lblSiteSafetyAuditInfo.Size = new Size(486, 20);
      this.lblSiteSafetyAuditInfo.TabIndex = 98;
      this.lblSiteSafetyAuditInfo.Text = "Please Key In -1 For N/A sections";
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(460, 362);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 97;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtAuditor.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtAuditor.Location = new System.Drawing.Point(66, 362);
      this.txtAuditor.Name = "txtAuditor";
      this.txtAuditor.ReadOnly = true;
      this.txtAuditor.Size = new Size(388, 21);
      this.txtAuditor.TabIndex = 96;
      this.lblAuditor.Location = new System.Drawing.Point(6, 366);
      this.lblAuditor.Name = "lblAuditor";
      this.lblAuditor.Size = new Size(64, 21);
      this.lblAuditor.TabIndex = 95;
      this.lblAuditor.Text = "Auditor";
      this.btnDeleteAudit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDeleteAudit.Location = new System.Drawing.Point(93, 404);
      this.btnDeleteAudit.Name = "btnDeleteAudit";
      this.btnDeleteAudit.Size = new Size(75, 23);
      this.btnDeleteAudit.TabIndex = 94;
      this.btnDeleteAudit.Text = "Delete";
      this.btnDeleteAudit.UseVisualStyleBackColor = true;
      this.lblLine.Location = new System.Drawing.Point(9, 299);
      this.lblLine.Name = "lblLine";
      this.lblLine.Size = new Size(496, 15);
      this.lblLine.TabIndex = 93;
      this.lblLine.Text = "-----------------------------------------------------------------------------------------------------------------------";
      this.txtTotal.Location = new System.Drawing.Point(185, 326);
      this.txtTotal.Name = "txtTotal";
      this.txtTotal.Size = new Size(51, 21);
      this.txtTotal.TabIndex = 92;
      this.lblTotal.Location = new System.Drawing.Point(6, 329);
      this.lblTotal.Name = "lblTotal";
      this.lblTotal.Size = new Size(162, 20);
      this.lblTotal.TabIndex = 91;
      this.lblTotal.Text = "Total";
      this.txtAsbestos.Location = new System.Drawing.Point(185, 263);
      this.txtAsbestos.Name = "txtAsbestos";
      this.txtAsbestos.Size = new Size(51, 21);
      this.txtAsbestos.TabIndex = 90;
      this.lblAsbestos.Location = new System.Drawing.Point(6, 266);
      this.lblAsbestos.Name = "lblAsbestos";
      this.lblAsbestos.Size = new Size(162, 20);
      this.lblAsbestos.TabIndex = 89;
      this.lblAsbestos.Text = "Asbestos";
      this.txtCOSSH.Location = new System.Drawing.Point(185, 220);
      this.txtCOSSH.Name = "txtCOSSH";
      this.txtCOSSH.Size = new Size(51, 21);
      this.txtCOSSH.TabIndex = 88;
      this.lblCOSSH.Location = new System.Drawing.Point(6, 223);
      this.lblCOSSH.Name = "lblCOSSH";
      this.lblCOSSH.Size = new Size(162, 20);
      this.lblCOSSH.TabIndex = 87;
      this.lblCOSSH.Text = "COSSH";
      this.txtFirstAidWelfare.Location = new System.Drawing.Point(185, 177);
      this.txtFirstAidWelfare.Name = "txtFirstAidWelfare";
      this.txtFirstAidWelfare.Size = new Size(51, 21);
      this.txtFirstAidWelfare.TabIndex = 86;
      this.lblFirstAidWelfare.Location = new System.Drawing.Point(6, 180);
      this.lblFirstAidWelfare.Name = "lblFirstAidWelfare";
      this.lblFirstAidWelfare.Size = new Size(162, 20);
      this.lblFirstAidWelfare.TabIndex = 85;
      this.lblFirstAidWelfare.Text = "First Aid && Welfare";
      this.txtWorkingAtHeight.Location = new System.Drawing.Point(441, 220);
      this.txtWorkingAtHeight.Name = "txtWorkingAtHeight";
      this.txtWorkingAtHeight.Size = new Size(51, 21);
      this.txtWorkingAtHeight.TabIndex = 84;
      this.lblWorkingAtHeight.Location = new System.Drawing.Point((int) byte.MaxValue, 223);
      this.lblWorkingAtHeight.Name = "lblWorkingAtHeight";
      this.lblWorkingAtHeight.Size = new Size(162, 20);
      this.lblWorkingAtHeight.TabIndex = 83;
      this.lblWorkingAtHeight.Text = "Working At Height";
      this.txtManualHandling.Location = new System.Drawing.Point(441, 177);
      this.txtManualHandling.Name = "txtManualHandling";
      this.txtManualHandling.Size = new Size(51, 21);
      this.txtManualHandling.TabIndex = 82;
      this.lblManualHandling.Location = new System.Drawing.Point((int) byte.MaxValue, 180);
      this.lblManualHandling.Name = "lblManualHandling";
      this.lblManualHandling.Size = new Size(162, 20);
      this.lblManualHandling.TabIndex = 81;
      this.lblManualHandling.Text = "Manual Handling";
      this.txtMachineryEquipment.Location = new System.Drawing.Point(441, 134);
      this.txtMachineryEquipment.Name = "txtMachineryEquipment";
      this.txtMachineryEquipment.Size = new Size(51, 21);
      this.txtMachineryEquipment.TabIndex = 80;
      this.lblMachineryEquipment.Location = new System.Drawing.Point((int) byte.MaxValue, 137);
      this.lblMachineryEquipment.Name = "lblMachineryEquipment";
      this.lblMachineryEquipment.Size = new Size(162, 20);
      this.lblMachineryEquipment.TabIndex = 79;
      this.lblMachineryEquipment.Text = "Machinery && Equipment";
      this.txtHousekeeping.Location = new System.Drawing.Point(185, 134);
      this.txtHousekeeping.Name = "txtHousekeeping";
      this.txtHousekeeping.Size = new Size(51, 21);
      this.txtHousekeeping.TabIndex = 78;
      this.lblHousekeeping.Location = new System.Drawing.Point(6, 137);
      this.lblHousekeeping.Name = "lblHousekeeping";
      this.lblHousekeeping.Size = new Size(162, 20);
      this.lblHousekeeping.TabIndex = 77;
      this.lblHousekeeping.Text = "Housekeeping";
      this.txtEnvironmentalConditions.Location = new System.Drawing.Point(441, 91);
      this.txtEnvironmentalConditions.Name = "txtEnvironmentalConditions";
      this.txtEnvironmentalConditions.Size = new Size(51, 21);
      this.txtEnvironmentalConditions.TabIndex = 76;
      this.lblEnvironmentalConditions.Location = new System.Drawing.Point((int) byte.MaxValue, 94);
      this.lblEnvironmentalConditions.Name = "lblEnvironmentalConditions";
      this.lblEnvironmentalConditions.Size = new Size(162, 20);
      this.lblEnvironmentalConditions.TabIndex = 75;
      this.lblEnvironmentalConditions.Text = "Environmental Conditions";
      this.txtUniformPPE.Location = new System.Drawing.Point(185, 91);
      this.txtUniformPPE.Name = "txtUniformPPE";
      this.txtUniformPPE.Size = new Size(51, 21);
      this.txtUniformPPE.TabIndex = 74;
      this.lblUniformPPE.Location = new System.Drawing.Point(6, 94);
      this.lblUniformPPE.Name = "lblUniformPPE";
      this.lblUniformPPE.Size = new Size(162, 20);
      this.lblUniformPPE.TabIndex = 73;
      this.lblUniformPPE.Text = "Uniform && PPE";
      this.txtDocumentProcedures.Location = new System.Drawing.Point(441, 48);
      this.txtDocumentProcedures.Name = "txtDocumentProcedures";
      this.txtDocumentProcedures.Size = new Size(51, 21);
      this.txtDocumentProcedures.TabIndex = 72;
      this.lblDocumentationProcedures.Location = new System.Drawing.Point((int) byte.MaxValue, 51);
      this.lblDocumentationProcedures.Name = "lblDocumentationProcedures";
      this.lblDocumentationProcedures.Size = new Size(162, 20);
      this.lblDocumentationProcedures.TabIndex = 71;
      this.lblDocumentationProcedures.Text = "Document && Procedures";
      this.txtVehicleSafetyCondition.Location = new System.Drawing.Point(185, 46);
      this.txtVehicleSafetyCondition.Name = "txtVehicleSafetyCondition";
      this.txtVehicleSafetyCondition.Size = new Size(51, 21);
      this.txtVehicleSafetyCondition.TabIndex = 70;
      this.lblVehicleCheck.Location = new System.Drawing.Point(6, 49);
      this.lblVehicleCheck.Name = "lblVehicleCheck";
      this.lblVehicleCheck.Size = new Size(162, 20);
      this.lblVehicleCheck.TabIndex = 69;
      this.lblVehicleCheck.Text = "Vehicle Safety && Condition";
      this.dtpAuditDate.Location = new System.Drawing.Point(346, 326);
      this.dtpAuditDate.Name = "dtpAuditDate";
      this.dtpAuditDate.Size = new Size(146, 21);
      this.dtpAuditDate.TabIndex = 66;
      this.dtpAuditDate.Tag = (object) "";
      this.lblAuditDate.Location = new System.Drawing.Point((int) byte.MaxValue, 329);
      this.lblAuditDate.Name = "lblAuditDate";
      this.lblAuditDate.Size = new Size(85, 13);
      this.lblAuditDate.TabIndex = 67;
      this.lblAuditDate.Text = "Audit Date";
      this.btnNewAudit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnNewAudit.Location = new System.Drawing.Point(3, 404);
      this.btnNewAudit.Name = "btnNewAudit";
      this.btnNewAudit.Size = new Size(75, 23);
      this.btnNewAudit.TabIndex = 8;
      this.btnNewAudit.Text = "New";
      this.btnNewAudit.UseVisualStyleBackColor = true;
      this.btnSaveAudit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveAudit.Location = new System.Drawing.Point(417, 404);
      this.btnSaveAudit.Name = "btnSaveAudit";
      this.btnSaveAudit.Size = new Size(75, 23);
      this.btnSaveAudit.TabIndex = 3;
      this.btnSaveAudit.Text = "Save";
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCEngineer);
      this.Size = new Size(520, 679);
      this.TabControl1.ResumeLayout(false);
      this.tpMain.ResumeLayout(false);
      this.grpEngineer.ResumeLayout(false);
      this.grpEngineer.PerformLayout();
      this.tpMaxTimes.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
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
      this.GroupBox8.ResumeLayout(false);
      this.GroupBox8.PerformLayout();
      this.grpPostalRegions.ResumeLayout(false);
      this.grpPostalRegions.PerformLayout();
      this.dgUnTicked.EndInit();
      this.dgPostalRegions.EndInit();
      this.tpSiteSafetyAudits.ResumeLayout(false);
      this.grpSiteSafetyAudits.ResumeLayout(false);
      this.dgSiteSafetyAudits.EndInit();
      this.grpSiteSafetyAudit.ResumeLayout(false);
      this.grpSiteSafetyAudit.PerformLayout();
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
      this.SetupDgSiteSafetyAudit();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentEngineer;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

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

    public Engineer CurrentEngineer
    {
      get
      {
        return this._currentEngineer;
      }
      set
      {
        this._currentEngineer = value;
        if (this._currentEngineer == null)
        {
          this._currentEngineer = new Engineer();
          this._currentEngineer.Exists = false;
        }
        this.txtHolidayYearStart.Text = this._currentEngineer.HolidayYearStart;
        this.txtHolidayYearEnd.Text = this._currentEngineer.HolidayYearEnd;
        if (this._currentEngineer.Exists)
        {
          this.Populate(0);
          this.btnVanHistory.Enabled = true;
          this.pnlDocuments.Controls.Clear();
          this.DocumentsControl = new UCDocumentsList(FSM.Entity.Sys.Enums.TableNames.tblEngineer, this._currentEngineer.EngineerID);
          this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
        }
        else
          this.btnVanHistory.Enabled = false;
        this.PopulatePostalRegions();
        this.PopulateTrainingQualifications();
        this.PopulateEngineerEquipment();
        this.PopulateDisciplinaries();
        this.PopulateAbsences();
        this.PopulateSiteSafetyAuditDataGrid();
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
        this.postalRegionsDV.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
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
        this.postalRegionsDVUT.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
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

    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void RunFilter()
    {
      this.PostalRegionsDataViewUT.RowFilter = "Name Like '%" + this.txtPCSearch.Text + "%'";
    }

    private void UCEngineer_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgPostalRegions_Clicks(object sender, EventArgs e)
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

    private void dgPostalRegionsUnticked_Clicks(object sender, EventArgs e)
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

    private void btnVanHistory_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMVanHistory), true, new object[1]
      {
        (object) this.CurrentEngineer.EngineerID
      }, false);
    }

    private void dgTrainingQualifications_Click(object sender, EventArgs e)
    {
      try
      {
        ComboBox comboBox = this.cboQualificationType;
        Combo.SetUpCombo(ref comboBox, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
        this.cboQualificationType = comboBox;
        comboBox = this.cboQualification;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, this.SelectedTrainingQualificationsRow[0].ToString());
        this.cboQualification = comboBox;
        this.txtQualificatioNote.Text = Conversions.ToString(this.SelectedTrainingQualificationsRow[3]);
        this.dtpQualificationPassed.Value = Conversions.ToDate(this.SelectedTrainingQualificationsRow[4]);
        this.dtpQualificationExpires.Value = Conversions.ToDate(this.SelectedTrainingQualificationsRow[5]);
        this.dtpQualificationBooked.Value = Conversions.ToDate(this.SelectedTrainingQualificationsRow[6]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentEngineer = App.DB.Engineer.Engineer_Get(ID);
      if (!App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Qualifications))
      {
        this.txtGasSafeNo.ReadOnly = true;
        this.TxtOftec.ReadOnly = true;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.CurrentEngineer.Department, "", false) == 0)
        this.CurrentEngineer.SetDepartment = (object) "0";
      this.oldDepartment = this.CurrentEngineer.Department;
      ComboBox combo = this.cboRegionID;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEngineer.RegionID));
      this.cboRegionID = combo;
      if (!this.CurrentEngineer.Exists | !App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Region))
        this.cboRegionID.Enabled = false;
      combo = this.cboEngineerGroup;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEngineer.EngineerGroupID));
      this.cboEngineerGroup = combo;
      combo = this.cboLinkToUser;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEngineer.UserID));
      this.cboLinkToUser = combo;
      combo = this.cboEngineerRoleId;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEngineer.EngineerRoleId));
      this.cboEngineerRoleId = combo;
      combo = this.cboDepartment;
      Combo.SetSelectedComboItem_By_Value(ref combo, this.CurrentEngineer.Department.Trim());
      this.cboDepartment = combo;
      this.txtGasSafeNo.Text = this.CurrentEngineer.GasSafeNo;
      this.TxtOftec.Text = this.CurrentEngineer.OftecNo;
      this.txtName.Text = this.CurrentEngineer.Name;
      this.txtTelephoneNum.Text = this.CurrentEngineer.TelephoneNum;
      this.txtEmailAddress.Text = this.CurrentEngineer.EmailAddress;
      this.txtEngineerID.Text = this.CurrentEngineer.EngineerID != 0 ? Conversions.ToString(this.CurrentEngineer.EngineerID) : "<Not Set>";
      this.chkApprentice.Checked = this.CurrentEngineer.Apprentice;
      this.MaxTimes = App.DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(this.CurrentEngineer.EngineerID);
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
      this.txtTechnician.Text = this.CurrentEngineer.Technician;
      combo = this.cboUser;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEngineer.ManagerUserID));
      this.cboUser = combo;
      this.txtNextOfKinName.Text = this.CurrentEngineer.NextOfKinName;
      this.txtNextOfKinContact.Text = this.CurrentEngineer.NextOfKinContact;
      this.txtStartingDetails.Text = this.CurrentEngineer.StartingDetails;
      this.txtDrivingLicenceNo.Text = this.CurrentEngineer.DrivingLicenceNo;
      if ((uint) DateTime.Compare(this.CurrentEngineer.DrivingLicenceIssueDate, DateTime.MinValue) > 0U)
      {
        this.dtpDrivingLicenceIssueDate.Value = this.CurrentEngineer.DrivingLicenceIssueDate;
        this.dtpDrivingLicenceIssueDate.Checked = true;
      }
      else
      {
        this.dtpDrivingLicenceIssueDate.Value = DateAndTime.Now.Date;
        this.dtpDrivingLicenceIssueDate.Checked = false;
      }
      this.txtHolidayYearStart.Text = this.CurrentEngineer.HolidayYearStart;
      this.txtHolidayYearEnd.Text = this.CurrentEngineer.HolidayYearEnd;
      this.txtDaysHolidayAllowed.Text = Conversions.ToString(this.CurrentEngineer.DaysHolidayAllowed);
      if (this.CurrentEngineer.Name.Trim().StartsWith("SUBCONTRACTOR : "))
      {
        this.txtName.ReadOnly = true;
        this.txtTelephoneNum.ReadOnly = true;
      }
      this.txtServPri.Text = Conversions.ToString(this.CurrentEngineer.ServPri);
      this.txtBreakPri.Text = Conversions.ToString(this.CurrentEngineer.BreakPri);
      this.txtPostcode.Text = this.CurrentEngineer.HomePostcode;
      this.txtDailyServiceLimit.Text = Conversions.ToString(this.CurrentEngineer.DailyServiceLimit);
      combo = this.cboRagRating;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEngineer.RagRating));
      this.cboRagRating = combo;
      this.dtpRagDate.Value = this.CurrentEngineer.RagDate;
      this.txtVisitSpendLimit.Text = Conversions.ToString(this.CurrentEngineer.VisitSpendLimit);
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    private void PopulatePostalRegions()
    {
      this.PostalRegionsDataView = App.DB.EngineerPostalRegion.GetTicked(this.CurrentEngineer.EngineerID);
      this.PostalRegionsDataViewUT = App.DB.EngineerPostalRegion.GetUnTicked(this.CurrentEngineer.EngineerID);
    }

    public bool Save()
    {
      bool flag1;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentEngineer.IgnoreExceptionsOnSetMethods = true;
        if (!this.CurrentEngineer.Exists | App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Region))
          this.CurrentEngineer.SetRegionID = (object) Combo.get_GetSelectedItemValue(this.cboRegionID);
        this.CurrentEngineer.SetUserID = (object) Combo.get_GetSelectedItemValue(this.cboLinkToUser);
        this.CurrentEngineer.SetEngineerGroupID = (object) Combo.get_GetSelectedItemValue(this.cboEngineerGroup);
        this.CurrentEngineer.SetGasSafeNo = (object) this.txtGasSafeNo.Text.Trim();
        this.CurrentEngineer.SetOftecNo = (object) this.TxtOftec.Text.Trim();
        this.CurrentEngineer.SetName = (object) this.txtName.Text.Trim();
        this.CurrentEngineer.SetTelephoneNum = (object) this.txtTelephoneNum.Text.Trim();
        this.CurrentEngineer.SetEmailAddress = (object) this.txtEmailAddress.Text.Trim();
        this.CurrentEngineer.SetPDAID = (object) 0;
        this.CurrentEngineer.SetTechnician = (object) this.txtTechnician.Text.Trim();
        this.CurrentEngineer.SetSupervisor = (object) Combo.get_GetSelectedItemDescription(this.cboUser);
        this.CurrentEngineer.SetManagerUserID = (object) Combo.get_GetSelectedItemValue(this.cboUser);
        this.CurrentEngineer.SetNextOfKinName = (object) this.txtNextOfKinName.Text;
        this.CurrentEngineer.SetNextOfKinContact = (object) this.txtNextOfKinContact.Text;
        this.CurrentEngineer.SetStartingDetails = (object) this.txtStartingDetails.Text;
        this.CurrentEngineer.SetDrivingLicenceNo = (object) this.txtDrivingLicenceNo.Text;
        this.CurrentEngineer.DrivingLicenceIssueDate = !this.dtpDrivingLicenceIssueDate.Checked ? DateTime.MinValue : this.dtpDrivingLicenceIssueDate.Value;
        this.CurrentEngineer.SetHolidayYearStart = (object) this.txtHolidayYearStart.Text;
        this.CurrentEngineer.SetHolidayYearEnd = (object) this.txtHolidayYearEnd.Text;
        if (this.txtDaysHolidayAllowed.Text.Trim().Length > 0)
          this.CurrentEngineer.SetDaysHolidayAllowed = (object) this.txtDaysHolidayAllowed.Text;
        string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment));
        if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) > 0)
          this.CurrentEngineer.SetDepartment = (object) str;
        else if (!Versioned.IsNumeric((object) str))
          this.CurrentEngineer.SetDepartment = (object) str;
        this.CurrentEngineer.SetServPri = (object) this.txtServPri.Text;
        this.CurrentEngineer.SetBreakPri = (object) this.txtBreakPri.Text;
        this.CurrentEngineer.SetDailyServiceLimit = (object) this.txtDailyServiceLimit.Text;
        this.CurrentEngineer.SetHomePostcode = (object) this.txtPostcode.Text;
        if (this.txtWebAppPassword.Text.Trim().Length > 0)
          this.CurrentEngineer.SetWebAppPassword = (object) this.txtWebAppPassword.Text.Trim();
        if (this.CurrentEngineer.Exists)
        {
          this.CurrentEngineer.SetRagRating = (object) Combo.get_GetSelectedItemValue(this.cboRagRating);
          this.CurrentEngineer.RagDate = this.dtpRagDate.Value;
        }
        else
        {
          this.CurrentEngineer.SetRagRating = (object) 2;
          this.CurrentEngineer.RagDate = DateAndTime.Now;
        }
        try
        {
          JObject longLat = (JObject) new FSM.LocationServices.LocationServices().GetLongLat(this.txtPostcode.Text);
          this.CurrentEngineer.SetLongitude = (object) longLat.SelectToken("result.longitude").ToString();
          this.CurrentEngineer.SetLatitude = (object) longLat.SelectToken("result.latitude").ToString();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        if (this.txtVisitSpendLimit.Text.Trim().Length > 0)
          this.CurrentEngineer.SetVisitSpendLimit = (object) Helper.MakeDoubleValid((object) this.txtVisitSpendLimit.Text.Trim());
        this.CurrentEngineer.SetEngineerRoleId = (object) Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboEngineerRoleId));
        new EngineerValidator().Validate(this.CurrentEngineer);
        if (this.CurrentEngineer.Exists)
        {
          App.DB.Engineer.Update(this.CurrentEngineer);
          App.DB.EngineerPostalRegion.Delete(this.CurrentEngineer.EngineerID);
          IEnumerator enumerator;
          try
          {
            enumerator = this.PostalRegionsDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(current["Tick"]))
                App.DB.EngineerPostalRegion.Insert(this.CurrentEngineer.EngineerID, Conversions.ToInteger(current["ManagerID"]));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (this.MaxTimes == null)
            this.MaxTimes = new MaxEngineerTime();
          this.MaxTimes.SetEngineerID = (object) this.CurrentEngineer.EngineerID;
          this.MaxTimes.SetMondayValue = (object) this.txtMondayValue.Text;
          this.MaxTimes.SetTuesdayValue = (object) this.txtTuesdayValue.Text;
          this.MaxTimes.SetWednesdayValue = (object) this.txtWednesdayValue.Text;
          this.MaxTimes.SetThursdayValue = (object) this.txtThursdayValue.Text;
          this.MaxTimes.SetFridayValue = (object) this.txtFridayValue.Text;
          this.MaxTimes.SetSaturdayValue = (object) this.txtSaturdayValue.Text;
          this.MaxTimes.SetSundayValue = (object) this.txtSundayValue.Text;
          new MaxEngineerTimeValidator().Validate(this.MaxTimes);
          if (this.MaxTimes.Exists)
            App.DB.MaxEngineerTime.Update(this.MaxTimes);
          else
            App.DB.MaxEngineerTime.Insert(this.MaxTimes);
          App.DB.EngineerLevel.Insert(this.CurrentEngineer.EngineerID, this.TrainingQualificationsDataView.Table);
          App.DB.Engineer.SaveEquipmentRecords(this.CurrentEngineer.EngineerID, this.EngineerEquipmentDataView.Table);
          App.DB.Engineer.SaveDisciplinaryRecords(this.CurrentEngineer.EngineerID, this.DisciplinariesDataView.Table);
          if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.CurrentEngineer.Department, this.oldDepartment, false) > 0U)
          {
            User user = App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboUser)), false);
            if (user != null && user.EmailAddress.Length > 2)
            {
              string message = "The engineer " + this.CurrentEngineer.Name + " has been Ammended. They have been moved from department " + this.oldDepartment + " to department " + this.CurrentEngineer.Department + " you have been marked as his line manager. Please ensure all necessary records are updated.";
              this.Email2(App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboUser)), false).EmailAddress, message, App.loggedInUser.Fullname, EmailAddress.StockFinancials);
            }
            else
            {
              string message = "The engineer " + this.CurrentEngineer.Name + " has been Ammended. They have been moved from department " + this.oldDepartment + " to department " + this.CurrentEngineer.Department + ". Please ensure all necessary records are updated.";
              this.Email2(EmailAddress.StockFinancials, message, App.loggedInUser.Fullname, "");
            }
          }
        }
        else
        {
          Engineer engineer = App.DB.Engineer.Insert(this.CurrentEngineer);
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
          if (this.MaxTimes == null)
            this.MaxTimes = new MaxEngineerTime();
          this.MaxTimes.SetEngineerID = (object) engineer.EngineerID;
          this.MaxTimes.SetMondayValue = (object) this.txtMondayValue.Text;
          this.MaxTimes.SetTuesdayValue = (object) this.txtTuesdayValue.Text;
          this.MaxTimes.SetWednesdayValue = (object) this.txtWednesdayValue.Text;
          this.MaxTimes.SetThursdayValue = (object) this.txtThursdayValue.Text;
          this.MaxTimes.SetFridayValue = (object) this.txtFridayValue.Text;
          this.MaxTimes.SetSaturdayValue = (object) this.txtSaturdayValue.Text;
          this.MaxTimes.SetSundayValue = (object) this.txtSundayValue.Text;
          new MaxEngineerTimeValidator().Validate(this.MaxTimes);
          App.DB.MaxEngineerTime.Insert(this.MaxTimes);
          App.DB.EngineerLevel.Insert(engineer.EngineerID, this.TrainingQualificationsDataView.Table);
          App.DB.Engineer.SaveEquipmentRecords(engineer.EngineerID, this.EngineerEquipmentDataView.Table);
          App.DB.Engineer.SaveDisciplinaryRecords(engineer.EngineerID, this.DisciplinariesDataView.Table);
          this.CurrentEngineer = engineer;
          bool flag2 = false;
          bool flag3 = false;
          if (this.TxtOftec.Text.Length > 0 & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.TxtOftec.Text, "tbc", false) > 0U)
            flag3 = true;
          if (this.txtGasSafeNo.Text.Length > 0 & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtGasSafeNo.Text, "tbc", false) > 0U)
            flag2 = true;
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboUser)) > 0.0 && App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboUser)), false).EmailAddress.Length > 3)
          {
            string message = "The engineer " + this.CurrentEngineer.Name + " has been added for department " + this.CurrentEngineer.Department + " you have been marked as his line manager.<br/><br/>Please ensure all necessary records are updated.";
            if (!flag3)
              message += "<br/>No oftec registered reference has been added.";
            if (!flag2)
              message += "<br/>No Gas Safe registered reference has been added.";
            if (!flag3 | !flag2)
              message += "<br/>Engineer CANNOT work on gas or oil until the GSR or OFTEC number has been filled in!";
            this.Email(App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboUser)), false).EmailAddress, message, App.loggedInUser.Fullname, EmailAddress.HR + ", " + EmailAddress.Compliance);
          }
          else
          {
            string message = "The engineer " + this.CurrentEngineer.Name + " has been added for department " + this.CurrentEngineer.Department + ".<br/><br/>Please ensure all necessary records are updated.";
            if (!flag3)
              message += "<br/>No oftec registered reference has been added.";
            if (!flag2)
              message += "<br/>No Gas Safe registered reference has been added.";
            if (!flag3 | !flag2)
              message += "<br/>Engineer CANNOT work on gas Or oil until the GSR Or OFTEC number has been filled in!";
            this.Email(EmailAddress.HR + ", " + EmailAddress.Compliance, message, App.loggedInUser.Fullname, "");
          }
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
        if (recordsChangedEvent != null)
          recordsChangedEvent(App.DB.Engineer.Engineer_GetAll_NoSub(), FSM.Entity.Sys.Enums.PageViewing.Engineer, true, false, "");
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentEngineer.EngineerID);
        App.MainForm.RefreshEntity(this.CurrentEngineer.EngineerID, "");
        flag1 = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag1;
    }

    private void Email(string emailadd, string message, string addinguser, string cc)
    {
      if (!new Emails()
      {
        From = EmailAddress.Gabriel,
        To = emailadd,
        CC = cc,
        Subject = "A New Engineer Has been added",
        Body = ("<span style='font-family: Calibri, Sans-Serif'><p>Hi</p><p>User : " + addinguser + " has added a new engineer</p><p>" + message + "</p><p>King Regards</p><p>" + App.TheSystem.Configuration.CompanyName + "</p></span>"),
        SendMe = true
      }.Send())
        ;
    }

    private void Email2(string emailadd, string message, string addinguser, string cc)
    {
      if (!new Emails()
      {
        From = EmailAddress.Gabriel,
        To = emailadd,
        CC = cc,
        Subject = "An Engineers department has changed",
        Body = ("<span style='font-family: Calibri, Sans-Serif'><p>Hi</p><p>User : " + addinguser + " has ammended an engineer</p><p>" + message + "</p><p>King Regards</p><p>" + App.TheSystem.Configuration.CompanyName + "</p></span>"),
        SendMe = true
      }.Send())
        ;
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
      dataGridLabelColumn.HeaderText = "Postcode";
      dataGridLabelColumn.MappingName = "Name";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 200;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
      this.dgPostalRegions.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgPostalRegions);
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
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
      this.dgUnTicked.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgUnTicked);
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
        tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString();
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
          this._trainingQualificationsDataView.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString();
        }
        this.dgTrainingQualifications.DataSource = (object) this._trainingQualificationsDataView;
      }
    }

    public DataRow SelectedTrainingQualificationsRow
    {
      get
      {
        return this.TrainingQualificationsDataView != null && this.TrainingQualificationsDataView.Table.Rows.Count > 0 ? this.TrainingQualificationsDataView[this.dgTrainingQualifications.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void PopulateTrainingQualifications()
    {
      try
      {
        this.TrainingQualificationsDataView = App.DB.EngineerLevel.GetForSetup(this.CurrentEngineer.EngineerID);
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
      if (!App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Qualifications))
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
        row["Description"] = (object) Combo.get_GetSelectedItemDescription(this.cboQualification).ToString().Split('*')[0].Trim();
        row["Level"] = (object) Combo.get_GetSelectedItemDescription(this.cboQualification).ToString().Split('*')[1].Trim();
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
      if (!App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Qualifications))
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
        return this.EngineerEquipmentDataView != null && this.EngineerEquipmentDataView.Table.Rows.Count > 0 ? this.EngineerEquipmentDataView[this.dgEquipment.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void PopulateEngineerEquipment()
    {
      try
      {
        this.EngineerEquipmentDataView = new DataView(App.DB.Engineer.GetEquipmentRecords(this.CurrentEngineer.EngineerID));
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
        return this.DisciplinariesDataView != null && this.DisciplinariesDataView.Table.Rows.Count > 0 ? this.DisciplinariesDataView[this.dgDisciplinaries.CurrentRowIndex].Row : (DataRow) null;
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
        this.DisciplinariesDataView = new DataView(App.DB.Engineer.GetDisciplinaryRecords(this.CurrentEngineer.EngineerID));
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
        this.AbsencesDataView = new DataView(App.DB.EngineerAbsence.GetAbsencesForEngineer(this.CurrentEngineer.EngineerID));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void cboQualificationType_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        int skillTypeId = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboQualificationType));
        if (skillTypeId > 0)
        {
          ComboBox cboQualification = this.cboQualification;
          Combo.SetUpCombo(ref cboQualification, App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId).Table, "SkillID", "Skill", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
          this.cboQualification = cboQualification;
        }
        else
        {
          ComboBox cboQualification = this.cboQualification;
          Combo.SetUpComboQual(ref cboQualification, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
          this.cboQualification = cboQualification;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void Label43_Click(object sender, EventArgs e)
    {
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }

    public Engineer Auditor
    {
      get
      {
        return this._auditor;
      }
      set
      {
        this._auditor = value;
        if (this._auditor != null)
          this.txtAuditor.Text = this.Auditor.Name;
        else
          this.txtAuditor.Text = "<Not Set>";
      }
    }

    private DataView DvSiteSafetyAudits
    {
      get
      {
        return this._dvSiteSafetyAudits;
      }
      set
      {
        this._dvSiteSafetyAudits = value;
        this._dvSiteSafetyAudits.AllowNew = false;
        this._dvSiteSafetyAudits.AllowEdit = false;
        this._dvSiteSafetyAudits.AllowDelete = false;
        this._dvSiteSafetyAudits.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblEngineer.ToString();
        this.dgSiteSafetyAudits.DataSource = (object) this.DvSiteSafetyAudits;
      }
    }

    private DataRow DrSelectedSiteSafetyAudit
    {
      get
      {
        return this.dgSiteSafetyAudits.CurrentRowIndex != -1 ? this.DvSiteSafetyAudits[this.dgSiteSafetyAudits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupDgSiteSafetyAudit()
    {
      Helper.SetUpDataGrid(this.dgSiteSafetyAudits, false);
      DataGridTableStyle tableStyle = this.dgSiteSafetyAudits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridSiteSafetyAuditColumn safetyAuditColumn1 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn1.Format = "dd/MM/yyyy";
      safetyAuditColumn1.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn1.HeaderText = "Audit Date";
      safetyAuditColumn1.MappingName = "AuditDate";
      safetyAuditColumn1.ReadOnly = true;
      safetyAuditColumn1.Width = 100;
      safetyAuditColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn1);
      DataGridSiteSafetyAuditColumn safetyAuditColumn2 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn2.Format = "";
      safetyAuditColumn2.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn2.HeaderText = "Auditor";
      safetyAuditColumn2.MappingName = "Auditor";
      safetyAuditColumn2.ReadOnly = true;
      safetyAuditColumn2.Width = 120;
      safetyAuditColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn2);
      DataGridSiteSafetyAuditColumn safetyAuditColumn3 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn3.Format = "";
      safetyAuditColumn3.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn3.HeaderText = "Vehicle Safety & Condition";
      safetyAuditColumn3.MappingName = "Question1";
      safetyAuditColumn3.ReadOnly = true;
      safetyAuditColumn3.Width = 120;
      safetyAuditColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn3);
      DataGridSiteSafetyAuditColumn safetyAuditColumn4 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn4.Format = "";
      safetyAuditColumn4.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn4.HeaderText = "Document & Procedures";
      safetyAuditColumn4.MappingName = "Question2";
      safetyAuditColumn4.ReadOnly = true;
      safetyAuditColumn4.Width = 120;
      safetyAuditColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn4);
      DataGridSiteSafetyAuditColumn safetyAuditColumn5 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn5.Format = "";
      safetyAuditColumn5.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn5.HeaderText = "Uniform & PPE";
      safetyAuditColumn5.MappingName = "question3";
      safetyAuditColumn5.ReadOnly = true;
      safetyAuditColumn5.Width = 120;
      safetyAuditColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn5);
      DataGridSiteSafetyAuditColumn safetyAuditColumn6 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn6.Format = "";
      safetyAuditColumn6.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn6.HeaderText = "Environmental Conditions";
      safetyAuditColumn6.MappingName = "question4";
      safetyAuditColumn6.ReadOnly = true;
      safetyAuditColumn6.Width = 120;
      safetyAuditColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn6);
      DataGridSiteSafetyAuditColumn safetyAuditColumn7 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn7.Format = "";
      safetyAuditColumn7.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn7.HeaderText = "Housekeeping";
      safetyAuditColumn7.MappingName = "question5";
      safetyAuditColumn7.ReadOnly = true;
      safetyAuditColumn7.Width = 120;
      safetyAuditColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn7);
      DataGridSiteSafetyAuditColumn safetyAuditColumn8 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn8.Format = "";
      safetyAuditColumn8.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn8.HeaderText = "Machinery & Equipment";
      safetyAuditColumn8.MappingName = "question6";
      safetyAuditColumn8.ReadOnly = true;
      safetyAuditColumn8.Width = 120;
      safetyAuditColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn8);
      DataGridSiteSafetyAuditColumn safetyAuditColumn9 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn9.Format = "";
      safetyAuditColumn9.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn9.HeaderText = "First Aid & Welfare";
      safetyAuditColumn9.MappingName = "question7";
      safetyAuditColumn9.ReadOnly = true;
      safetyAuditColumn9.Width = 120;
      safetyAuditColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn9);
      DataGridSiteSafetyAuditColumn safetyAuditColumn10 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn10.Format = "";
      safetyAuditColumn10.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn10.HeaderText = "Manual Handling";
      safetyAuditColumn10.MappingName = "question8";
      safetyAuditColumn10.ReadOnly = true;
      safetyAuditColumn10.Width = 120;
      safetyAuditColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn10);
      DataGridSiteSafetyAuditColumn safetyAuditColumn11 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn11.Format = "";
      safetyAuditColumn11.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn11.HeaderText = "COSSH";
      safetyAuditColumn11.MappingName = "question9";
      safetyAuditColumn11.ReadOnly = true;
      safetyAuditColumn11.Width = 120;
      safetyAuditColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn11);
      DataGridSiteSafetyAuditColumn safetyAuditColumn12 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn12.Format = "";
      safetyAuditColumn12.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn12.HeaderText = "Working At Height";
      safetyAuditColumn12.MappingName = "question10";
      safetyAuditColumn12.ReadOnly = true;
      safetyAuditColumn12.Width = 120;
      safetyAuditColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn12);
      DataGridSiteSafetyAuditColumn safetyAuditColumn13 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn13.Format = "";
      safetyAuditColumn13.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn13.HeaderText = "Asbestos";
      safetyAuditColumn13.MappingName = "question11";
      safetyAuditColumn13.ReadOnly = true;
      safetyAuditColumn13.Width = 120;
      safetyAuditColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn13);
      DataGridSiteSafetyAuditColumn safetyAuditColumn14 = new DataGridSiteSafetyAuditColumn();
      safetyAuditColumn14.Format = "";
      safetyAuditColumn14.FormatInfo = (IFormatProvider) null;
      safetyAuditColumn14.HeaderText = "Total";
      safetyAuditColumn14.MappingName = "result";
      safetyAuditColumn14.ReadOnly = true;
      safetyAuditColumn14.Width = 120;
      safetyAuditColumn14.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) safetyAuditColumn14);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblEngineer.ToString();
      this.dgSiteSafetyAudits.TableStyles.Add(tableStyle);
    }

    public void PopulateSiteSafetyAuditDataGrid()
    {
      try
      {
        this.DvSiteSafetyAudits = App.DB.SiteSafteyAudit.Get_As_DataView((object) this.CurrentEngineer.EngineerID, GetBy.EngineerId);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot load datagrid: \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnSaveAudit_Click(object sender, EventArgs e)
    {
      if (this.CurrentEngineer == null || App.ShowMessage("Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      if (this.SiteSafetyAudit == null)
        this.SiteSafetyAudit = new SiteSafetyAudit();
      SiteSafetyAudit siteSafetyAudit = this.SiteSafetyAudit;
      siteSafetyAudit.EngineerId = this.CurrentEngineer.EngineerID;
      siteSafetyAudit.Department = this.CurrentEngineer.Department;
      siteSafetyAudit.AuditDate = this.dtpAuditDate.Value;
      siteSafetyAudit.Question1 = Helper.MakeDoubleValid((object) this.txtVehicleSafetyCondition.Text);
      siteSafetyAudit.Question2 = Helper.MakeDoubleValid((object) this.txtDocumentProcedures.Text);
      siteSafetyAudit.Question3 = Helper.MakeDoubleValid((object) this.txtUniformPPE.Text);
      siteSafetyAudit.Question4 = Helper.MakeDoubleValid((object) this.txtEnvironmentalConditions.Text);
      siteSafetyAudit.Question5 = Helper.MakeDoubleValid((object) this.txtHousekeeping.Text);
      siteSafetyAudit.Question6 = Helper.MakeDoubleValid((object) this.txtMachineryEquipment.Text);
      siteSafetyAudit.Question7 = Helper.MakeDoubleValid((object) this.txtFirstAidWelfare.Text);
      siteSafetyAudit.Question8 = Helper.MakeDoubleValid((object) this.txtManualHandling.Text);
      siteSafetyAudit.Question9 = Helper.MakeDoubleValid((object) this.txtCOSSH.Text);
      siteSafetyAudit.Question10 = Helper.MakeDoubleValid((object) this.txtWorkingAtHeight.Text);
      siteSafetyAudit.Question11 = Helper.MakeDoubleValid((object) this.txtAsbestos.Text);
      siteSafetyAudit.Result = Helper.MakeDoubleValid((object) this.txtTotal.Text);
      siteSafetyAudit.AuditorId = Helper.MakeIntegerValid((object) this.Auditor?.EngineerID);
      bool flag = true;
      PropertyInfo[] properties = this.SiteSafetyAudit.GetType().GetProperties();
      int index = 0;
      while (index < properties.Length)
      {
        PropertyInfo propertyInfo = properties[index];
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(propertyInfo.PropertyType.Name, typeof (double).Name, false) == 0)
        {
          double num = Conversions.ToDouble(propertyInfo.GetValue((object) this.SiteSafetyAudit, (object[]) null));
          if (num < -1.0 | num > 100.0)
            flag = false;
        }
        checked { ++index; }
      }
      if (!flag)
      {
        int num1 = (int) App.ShowMessage("Please ensure values are between 0 & 100!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (DateTime.Compare(this.SiteSafetyAudit.AuditDate, DateAndTime.Now) > 0)
      {
        int num2 = (int) App.ShowMessage("Audit date cannot be in the future!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (this.SiteSafetyAudit.Id > 0)
          App.DB.SiteSafteyAudit.Update(this.SiteSafetyAudit);
        else
          this.SiteSafetyAudit = App.DB.SiteSafteyAudit.Insert(this.SiteSafetyAudit);
        this.PopulateSiteSafetyAuditDataGrid();
        this.ClearAuditForm();
      }
    }

    private void btnNewAudit_Click(object sender, EventArgs e)
    {
      this.ClearAuditForm();
    }

    private void ClearAuditForm()
    {
      this.SiteSafetyAudit = (SiteSafetyAudit) null;
      this.dtpAuditDate.Value = DateAndTime.Now;
      this.txtVehicleSafetyCondition.Text = "";
      this.txtDocumentProcedures.Text = "";
      this.txtUniformPPE.Text = "";
      this.txtEnvironmentalConditions.Text = "";
      this.txtHousekeeping.Text = "";
      this.txtMachineryEquipment.Text = "";
      this.txtFirstAidWelfare.Text = "";
      this.txtManualHandling.Text = "";
      this.txtCOSSH.Text = "";
      this.txtWorkingAtHeight.Text = "";
      this.txtAsbestos.Text = "";
      this.txtTotal.Text = "";
      this.Auditor = (Engineer) null;
    }

    private void btnDeleteAudit_Click(object sender, EventArgs e)
    {
      if (this.DrSelectedSiteSafetyAudit == null)
      {
        int num1 = (int) App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          App.DB.SiteSafteyAudit.Delete(Conversions.ToInteger(this.DrSelectedSiteSafetyAudit["Id"]));
          this.PopulateSiteSafetyAuditDataGrid();
          this.ClearAuditForm();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Error deleting: \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void dgSiteSafetyAudits_Click(object sender, EventArgs e)
    {
      if (this.DrSelectedSiteSafetyAudit == null)
        return;
      List<SiteSafetyAudit> asEntity = App.DB.SiteSafteyAudit.Get_As_Entity(RuntimeHelpers.GetObjectValue(this.DrSelectedSiteSafetyAudit["Id"]), GetBy.Id);
      this.SiteSafetyAudit = asEntity != null ? asEntity.FirstOrDefault<SiteSafetyAudit>() : (SiteSafetyAudit) null;
      if (this.SiteSafetyAudit != null)
      {
        SiteSafetyAudit siteSafetyAudit = this.SiteSafetyAudit;
        this.dtpAuditDate.Value = siteSafetyAudit.AuditDate;
        this.txtVehicleSafetyCondition.Text = Conversions.ToString(siteSafetyAudit.Question1);
        this.txtDocumentProcedures.Text = Conversions.ToString(siteSafetyAudit.Question2);
        this.txtUniformPPE.Text = Conversions.ToString(siteSafetyAudit.Question3);
        this.txtEnvironmentalConditions.Text = Conversions.ToString(siteSafetyAudit.Question4);
        this.txtHousekeeping.Text = Conversions.ToString(siteSafetyAudit.Question5);
        this.txtMachineryEquipment.Text = Conversions.ToString(siteSafetyAudit.Question6);
        this.txtFirstAidWelfare.Text = Conversions.ToString(siteSafetyAudit.Question7);
        this.txtManualHandling.Text = Conversions.ToString(siteSafetyAudit.Question8);
        this.txtCOSSH.Text = Conversions.ToString(siteSafetyAudit.Question9);
        this.txtWorkingAtHeight.Text = Conversions.ToString(siteSafetyAudit.Question10);
        this.txtAsbestos.Text = Conversions.ToString(siteSafetyAudit.Question11);
        this.txtTotal.Text = Conversions.ToString(siteSafetyAudit.Result);
        this.Auditor = App.DB.Engineer.Engineer_Get(siteSafetyAudit.AuditorId);
      }
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Auditor = App.DB.Engineer.Engineer_Get(integer);
    }

    private void cboLinkToUser_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (this.cboLinkToUser.SelectedValue != null)
        return;
      int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLinkToUser));
      if (App.DB.Engineer.UserIsLinkedToEngineer(integer))
      {
        int num = (int) App.ShowMessage("This user is already linked to an engineer. Please try another user.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.cboLinkToUser.SelectedIndex = 0;
      }
    }
  }
}
