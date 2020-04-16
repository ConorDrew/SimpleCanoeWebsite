// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteJob
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CostCentres;
using FSM.Entity.CustomerCharges;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.EngineerVisits;
using FSM.Entity.QuoteJobAssets;
using FSM.Entity.QuoteJobItems;
using FSM.Entity.QuoteJobOfWorks;
using FSM.Entity.QuoteJobs;
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
  public class UCQuoteJob : UCBase, IUserControl
  {
    private IContainer components;
    private FSM.Entity.Sites.Site _CurrentSite;
    private CustomerCharge _CustomerCharge;
    private QuoteJob _CurrentQuoteJob;
    private DataView _AssetsTable;
    private DataView _PartsAndProducts;
    private DataView _JobItemsTable;
    private FSM.Entity.Sys.Enums.FormState _JobItemState;
    private bool _loading;
    private int _PartProductID;
    private bool _QuoteNumberUsed;
    private JobNumber _QuoteNumber;
    private double _TotalCosts;

    public UCQuoteJob()
    {
      this.Load += new EventHandler(this.UCQuoteJob_Load);
      this._AssetsTable = (DataView) null;
      this._PartsAndProducts = (DataView) null;
      this._JobItemsTable = (DataView) null;
      this._JobItemState = FSM.Entity.Sys.Enums.FormState.Insert;
      this._loading = false;
      this._PartProductID = 0;
      this._QuoteNumberUsed = false;
      this._QuoteNumber = new JobNumber();
      this.InitializeComponent();
      ComboBox cboQuoteStatus = this.cboQuoteStatus;
      Combo.SetUpCombo(ref cboQuoteStatus, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Quote_Status, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboQuoteStatus = cboQuoteStatus;
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Not_Applicable);
      this.cboJobType = cboJobType;
      ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
      Combo.SetUpCombo(ref ofRatesCategoryId, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
      ComboBox cboVat = this.cboVAT;
      Combo.SetUpCombo(ref cboVat, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboVAT = cboVat;
      ComboBox cboAsbestos = this.cboAsbestos;
      Combo.SetUpCombo(ref cboAsbestos, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Quote_Asbestos, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboAsbestos = cboAsbestos;
      ComboBox cboAccess = this.cboAccess;
      Combo.SetUpCombo(ref cboAccess, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Quote_AccessEquipment, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboAccess = cboAccess;
      ComboBox cboElectricalPack = this.cboElectricalPack;
      Combo.SetUpCombo(ref cboElectricalPack, DynamicDataTables.Quote_ElectricianPack, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboElectricalPack = cboElectricalPack;
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

    internal virtual Label lblQuoteStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuoteDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQuoteStatus
    {
      get
      {
        return this._cboQuoteStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboQuoteStatus_SelectedIndexChanged);
        ComboBox cboQuoteStatus1 = this._cboQuoteStatus;
        if (cboQuoteStatus1 != null)
          cboQuoteStatus1.SelectedIndexChanged -= eventHandler;
        this._cboQuoteStatus = value;
        ComboBox cboQuoteStatus2 = this._cboQuoteStatus;
        if (cboQuoteStatus2 == null)
          return;
        cboQuoteStatus2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpJobItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBOC { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPartsCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemovePartProduct
    {
      get
      {
        return this._btnRemovePartProduct;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemovePartProduct_Click);
        Button removePartProduct1 = this._btnRemovePartProduct;
        if (removePartProduct1 != null)
          removePartProduct1.Click -= eventHandler;
        this._btnRemovePartProduct = value;
        Button removePartProduct2 = this._btnRemovePartProduct;
        if (removePartProduct2 == null)
          return;
        removePartProduct2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindPart
    {
      get
      {
        return this._btnFindPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindPart_Click);
        Button btnFindPart1 = this._btnFindPart;
        if (btnFindPart1 != null)
          btnFindPart1.Click -= eventHandler;
        this._btnFindPart = value;
        Button btnFindPart2 = this._btnFindPart;
        if (btnFindPart2 == null)
          return;
        btnFindPart2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgPartsAndProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQuoteDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSiteName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProperty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuoteRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgScheduleOfRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

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

    internal virtual Button btnSiteScheduleOfRates
    {
      get
      {
        return this._btnSiteScheduleOfRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSiteScheduleOfRates_Click);
        Button siteScheduleOfRates1 = this._btnSiteScheduleOfRates;
        if (siteScheduleOfRates1 != null)
          siteScheduleOfRates1.Click -= eventHandler;
        this._btnSiteScheduleOfRates = value;
        Button siteScheduleOfRates2 = this._btnSiteScheduleOfRates;
        if (siteScheduleOfRates2 == null)
          return;
        siteScheduleOfRates2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsCost
    {
      get
      {
        return this._txtPartsCost;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartsTotal_LostFocus);
        TextBox txtPartsCost1 = this._txtPartsCost;
        if (txtPartsCost1 != null)
          txtPartsCost1.LostFocus -= eventHandler;
        this._txtPartsCost = value;
        TextBox txtPartsCost2 = this._txtPartsCost;
        if (txtPartsCost2 == null)
          return;
        txtPartsCost2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblPartsMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsProductsMarkup
    {
      get
      {
        return this._txtPartsProductsMarkup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartsTotal_LostFocus);
        TextBox partsProductsMarkup1 = this._txtPartsProductsMarkup;
        if (partsProductsMarkup1 != null)
          partsProductsMarkup1.LostFocus -= eventHandler;
        this._txtPartsProductsMarkup = value;
        TextBox partsProductsMarkup2 = this._txtPartsProductsMarkup;
        if (partsProductsMarkup2 == null)
          return;
        partsProductsMarkup2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblTotalPartsCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsCostTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSORCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtScheduleRatesCost
    {
      get
      {
        return this._txtScheduleRatesCost;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartsTotal_LostFocus);
        TextBox scheduleRatesCost1 = this._txtScheduleRatesCost;
        if (scheduleRatesCost1 != null)
          scheduleRatesCost1.LostFocus -= eventHandler;
        this._txtScheduleRatesCost = value;
        TextBox scheduleRatesCost2 = this._txtScheduleRatesCost;
        if (scheduleRatesCost2 == null)
          return;
        scheduleRatesCost2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblSORMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtScheduleRateMarkup
    {
      get
      {
        return this._txtScheduleRateMarkup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartsTotal_LostFocus);
        TextBox scheduleRateMarkup1 = this._txtScheduleRateMarkup;
        if (scheduleRateMarkup1 != null)
          scheduleRateMarkup1.LostFocus -= eventHandler;
        this._txtScheduleRateMarkup = value;
        TextBox scheduleRateMarkup2 = this._txtScheduleRateMarkup;
        if (scheduleRateMarkup2 == null)
          return;
        scheduleRateMarkup2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblTotalSORCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtScheduleRatesCostTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTimeInMins { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAsbestosNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAsbestos { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAsbestos { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAsbestosStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInstallerNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInstallerNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpOtherLabour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtElectricianCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTotalElectricianCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtElectricianMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectricianMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtElectricianCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectricianCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTotalInstallerCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInstallerMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInstallerMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInstallerCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInstallerCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuilderCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTotalBuilderCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuilderMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBuilderMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuilderCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBuilderCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInstallerCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccess { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAccess { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAccessEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInstallerLabourDays { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInstallerDays { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtElectricianHours { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectricianPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtElectricianNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectricianNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectricianPackHours { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectOr { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboElectricalPack
    {
      get
      {
        return this._cboElectricalPack;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboElectricalPack_SelectedIndexChanged);
        ComboBox cboElectricalPack1 = this._cboElectricalPack;
        if (cboElectricalPack1 != null)
          cboElectricalPack1.SelectedIndexChanged -= eventHandler;
        this._cboElectricalPack = value;
        ComboBox cboElectricalPack2 = this._cboElectricalPack;
        if (cboElectricalPack2 == null)
          return;
        cboElectricalPack2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtElectricianArrivalHour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectricianHour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtElectricianArrivalDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblElectricianArrivalDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuilderArrivalHour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBuilderHour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuilderArrivalDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblArrivalDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuilderHours
    {
      get
      {
        return this._txtBuilderHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtBuilderHours_TextChanged);
        TextBox txtBuilderHours1 = this._txtBuilderHours;
        if (txtBuilderHours1 != null)
          txtBuilderHours1.TextChanged -= eventHandler;
        this._txtBuilderHours = value;
        TextBox txtBuilderHours2 = this._txtBuilderHours;
        if (txtBuilderHours2 == null)
          return;
        txtBuilderHours2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtBuilderNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBuilderNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBuilderLabourHours { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBuilderLabour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBOC { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDeposit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDeposit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtincVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblIncVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVAT
    {
      get
      {
        return this._cboVAT;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartsTotal_LostFocus);
        ComboBox cboVat1 = this._cboVAT;
        if (cboVat1 != null)
          cboVat1.SelectedIndexChanged -= eventHandler;
        this._cboVAT = value;
        ComboBox cboVat2 = this._cboVAT;
        if (cboVat2 == null)
          return;
        cboVat2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGrandTotal
    {
      get
      {
        return this._txtGrandTotal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtGrandTotal_TextChanged);
        TextBox txtGrandTotal1 = this._txtGrandTotal;
        if (txtGrandTotal1 != null)
          txtGrandTotal1.TextChanged -= eventHandler;
        this._txtGrandTotal = value;
        TextBox txtGrandTotal2 = this._txtGrandTotal;
        if (txtGrandTotal2 == null)
          return;
        txtGrandTotal2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtTotalCosts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSale { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitPound { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProfitSlash { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitPerc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProfit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTotalCosts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSORCharge
    {
      get
      {
        return this._chkSORCharge;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSORCharge_CheckedChanged);
        CheckBox chkSorCharge1 = this._chkSORCharge;
        if (chkSorCharge1 != null)
          chkSorCharge1.CheckedChanged -= eventHandler;
        this._chkSORCharge = value;
        CheckBox chkSorCharge2 = this._chkSORCharge;
        if (chkSorCharge2 == null)
          return;
        chkSorCharge2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtSurveyor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSurveyor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLastChangedOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtChangedDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblChangedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtChangedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNA { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEstStartDAte { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpestStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPurchaseDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkService { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkHOver { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOriginalQuote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOriginalQuote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEmailSOR
    {
      get
      {
        return this._btnEmailSOR;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEmailSOR_Click);
        Button btnEmailSor1 = this._btnEmailSOR;
        if (btnEmailSor1 != null)
          btnEmailSor1.Click -= eventHandler;
        this._btnEmailSOR = value;
        Button btnEmailSor2 = this._btnEmailSOR;
        if (btnEmailSor2 == null)
          return;
        btnEmailSor2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpTotals { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpRates = new GroupBox();
      this.btnEmailSOR = new Button();
      this.txtTimeInMins = new TextBox();
      this.lblTime = new Label();
      this.btnSiteScheduleOfRates = new Button();
      this.btnRemove = new Button();
      this.cboScheduleOfRatesCategoryID = new ComboBox();
      this.lblScheduleOfRatesCategoryID = new Label();
      this.txtCode = new TextBox();
      this.lblCode = new Label();
      this.txtDescription = new TextBox();
      this.lblDescription = new Label();
      this.dgScheduleOfRates = new DataGrid();
      this.txtPrice = new TextBox();
      this.lblPrice = new Label();
      this.lblQuantity = new Label();
      this.txtQuantity = new TextBox();
      this.btnAdd = new Button();
      this.lblQuoteStatus = new Label();
      this.lblQuoteDate = new Label();
      this.cboQuoteStatus = new ComboBox();
      this.grpJobItems = new GroupBox();
      this.lblNA = new Label();
      this.lblEstStartDAte = new Label();
      this.txtInstallerLabourDays = new TextBox();
      this.dtpestStartDate = new DateTimePicker();
      this.lblInstallerDays = new Label();
      this.txtAccess = new TextBox();
      this.lblAddCharges = new Label();
      this.cboAccess = new ComboBox();
      this.lblAccessEquipment = new Label();
      this.lblAsbestosNotes = new Label();
      this.txtAsbestos = new TextBox();
      this.cboAsbestos = new ComboBox();
      this.lblAsbestosStatus = new Label();
      this.lblInstallerNotes = new Label();
      this.txtInstallerNotes = new TextBox();
      this.txtReference = new TextBox();
      this.cboJobType = new ComboBox();
      this.lblJobType = new Label();
      this.lblCustomer = new Label();
      this.grpTotals = new GroupBox();
      this.txtOriginalQuote = new TextBox();
      this.lblOriginalQuote = new Label();
      this.txtGrandTotal = new TextBox();
      this.chkSORCharge = new CheckBox();
      this.lblBOC = new Label();
      this.txtDeposit = new TextBox();
      this.lblDeposit = new Label();
      this.txtincVAT = new TextBox();
      this.lblIncVAT = new Label();
      this.cboVAT = new ComboBox();
      this.lblVAT = new Label();
      this.txtTotalCosts = new TextBox();
      this.lblSale = new Label();
      this.txtProfitPound = new TextBox();
      this.lblProfitSlash = new Label();
      this.txtProfitPerc = new TextBox();
      this.lblProfit = new Label();
      this.lblTotalCosts = new Label();
      this.txtPartsCostTotal = new TextBox();
      this.txtBuilderCharge = new TextBox();
      this.lblTotalBuilderCharge = new Label();
      this.txtBuilderMarkup = new TextBox();
      this.lblBuilderMarkup = new Label();
      this.txtBuilderCost = new TextBox();
      this.lblBuilderCost = new Label();
      this.txtElectricianCharge = new TextBox();
      this.lblTotalElectricianCharge = new Label();
      this.txtElectricianMarkup = new TextBox();
      this.lblElectricianMarkup = new Label();
      this.txtElectricianCost = new TextBox();
      this.lblElectricianCost = new Label();
      this.txtInstallerCharge = new TextBox();
      this.lblTotalInstallerCharge = new Label();
      this.txtInstallerMarkup = new TextBox();
      this.lblInstallerMarkup = new Label();
      this.txtInstallerCost = new TextBox();
      this.lblInstallerCost = new Label();
      this.txtScheduleRatesCostTotal = new TextBox();
      this.lblTotalSORCharge = new Label();
      this.txtScheduleRateMarkup = new TextBox();
      this.lblSORMarkup = new Label();
      this.txtScheduleRatesCost = new TextBox();
      this.lblSORCost = new Label();
      this.lblTotalPartsCharge = new Label();
      this.txtPartsProductsMarkup = new TextBox();
      this.lblPartsMarkup = new Label();
      this.txtBOC = new TextBox();
      this.txtPartsCost = new TextBox();
      this.lblPartsCost = new Label();
      this.grpParts = new GroupBox();
      this.btnRemovePartProduct = new Button();
      this.btnFindPart = new Button();
      this.dgPartsAndProducts = new DataGrid();
      this.dtpQuoteDate = new DateTimePicker();
      this.txtSiteName = new TextBox();
      this.lblProperty = new Label();
      this.lblQuoteRef = new Label();
      this.txtCustomerName = new TextBox();
      this.gpOtherLabour = new GroupBox();
      this.txtBuilderArrivalHour = new TextBox();
      this.lblBuilderHour = new Label();
      this.txtBuilderArrivalDay = new TextBox();
      this.lblArrivalDay = new Label();
      this.txtBuilderHours = new TextBox();
      this.txtBuilderNotes = new TextBox();
      this.lblBuilderNotes = new Label();
      this.lblBuilderLabourHours = new Label();
      this.lblBuilderLabour = new Label();
      this.txtElectricianArrivalHour = new TextBox();
      this.lblElectricianHour = new Label();
      this.txtElectricianArrivalDay = new TextBox();
      this.lblElectricianArrivalDay = new Label();
      this.txtElectricianHours = new TextBox();
      this.txtElectricianNotes = new TextBox();
      this.lblElectricianNotes = new Label();
      this.lblElectricianPackHours = new Label();
      this.lblElectOr = new Label();
      this.cboElectricalPack = new ComboBox();
      this.lblElectricianPack = new Label();
      this.txtSurveyor = new TextBox();
      this.lblSurveyor = new Label();
      this.lblLastChangedOn = new Label();
      this.txtChangedDate = new TextBox();
      this.lblChangedBy = new Label();
      this.txtChangedBy = new TextBox();
      this.lblPurchaseDept = new Label();
      this.cboDept = new ComboBox();
      this.chkService = new CheckBox();
      this.chkHOver = new CheckBox();
      this.grpRates.SuspendLayout();
      this.dgScheduleOfRates.BeginInit();
      this.grpJobItems.SuspendLayout();
      this.grpTotals.SuspendLayout();
      this.grpParts.SuspendLayout();
      this.dgPartsAndProducts.BeginInit();
      this.gpOtherLabour.SuspendLayout();
      this.SuspendLayout();
      this.grpRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpRates.Controls.Add((Control) this.btnEmailSOR);
      this.grpRates.Controls.Add((Control) this.txtTimeInMins);
      this.grpRates.Controls.Add((Control) this.lblTime);
      this.grpRates.Controls.Add((Control) this.btnSiteScheduleOfRates);
      this.grpRates.Controls.Add((Control) this.btnRemove);
      this.grpRates.Controls.Add((Control) this.cboScheduleOfRatesCategoryID);
      this.grpRates.Controls.Add((Control) this.lblScheduleOfRatesCategoryID);
      this.grpRates.Controls.Add((Control) this.txtCode);
      this.grpRates.Controls.Add((Control) this.lblCode);
      this.grpRates.Controls.Add((Control) this.txtDescription);
      this.grpRates.Controls.Add((Control) this.lblDescription);
      this.grpRates.Controls.Add((Control) this.dgScheduleOfRates);
      this.grpRates.Controls.Add((Control) this.txtPrice);
      this.grpRates.Controls.Add((Control) this.lblPrice);
      this.grpRates.Controls.Add((Control) this.lblQuantity);
      this.grpRates.Controls.Add((Control) this.txtQuantity);
      this.grpRates.Controls.Add((Control) this.btnAdd);
      this.grpRates.Font = new Font("Verdana", 8.25f);
      this.grpRates.Location = new System.Drawing.Point(8, 339);
      this.grpRates.Name = "grpRates";
      this.grpRates.Size = new Size(539, 358);
      this.grpRates.TabIndex = 6;
      this.grpRates.TabStop = false;
      this.grpRates.Text = "Schedule Of  Rates";
      this.btnEmailSOR.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnEmailSOR.Font = new Font("Verdana", 8.25f);
      this.btnEmailSOR.Location = new System.Drawing.Point(6, 164);
      this.btnEmailSOR.Name = "btnEmailSOR";
      this.btnEmailSOR.Size = new Size(111, 23);
      this.btnEmailSOR.TabIndex = 17;
      this.btnEmailSOR.Text = "Email SOR List";
      this.txtTimeInMins.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTimeInMins.Font = new Font("Verdana", 8.25f);
      this.txtTimeInMins.Location = new System.Drawing.Point(176, 270);
      this.txtTimeInMins.MaxLength = 9;
      this.txtTimeInMins.Name = "txtTimeInMins";
      this.txtTimeInMins.Size = new Size(355, 21);
      this.txtTimeInMins.TabIndex = 10;
      this.txtTimeInMins.Tag = (object) "SystemScheduleOfRate.Price";
      this.lblTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblTime.Font = new Font("Verdana", 8.25f);
      this.lblTime.Location = new System.Drawing.Point(8, 271);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new Size(136, 20);
      this.lblTime.TabIndex = 9;
      this.lblTime.Text = "Time (in Minutes)";
      this.btnSiteScheduleOfRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSiteScheduleOfRates.Font = new Font("Verdana", 8.25f);
      this.btnSiteScheduleOfRates.Location = new System.Drawing.Point(307, 326);
      this.btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates";
      this.btnSiteScheduleOfRates.Size = new Size(224, 23);
      this.btnSiteScheduleOfRates.TabIndex = 16;
      this.btnSiteScheduleOfRates.Text = "Add Site Schedule Of Rates";
      this.btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemove.Font = new Font("Verdana", 8.25f);
      this.btnRemove.Location = new System.Drawing.Point(451, 164);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(80, 23);
      this.btnRemove.TabIndex = 2;
      this.btnRemove.Text = "Remove";
      this.cboScheduleOfRatesCategoryID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
      this.cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboScheduleOfRatesCategoryID.Font = new Font("Verdana", 8.25f);
      this.cboScheduleOfRatesCategoryID.Location = new System.Drawing.Point(176, 198);
      this.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
      this.cboScheduleOfRatesCategoryID.Size = new Size(355, 21);
      this.cboScheduleOfRatesCategoryID.TabIndex = 4;
      this.cboScheduleOfRatesCategoryID.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblScheduleOfRatesCategoryID.Font = new Font("Verdana", 8.25f);
      this.lblScheduleOfRatesCategoryID.Location = new System.Drawing.Point(8, 198);
      this.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Size = new Size(179, 20);
      this.lblScheduleOfRatesCategoryID.TabIndex = 3;
      this.lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category";
      this.txtCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCode.Font = new Font("Verdana", 8.25f);
      this.txtCode.Location = new System.Drawing.Point(176, 222);
      this.txtCode.MaxLength = 50;
      this.txtCode.Name = "txtCode";
      this.txtCode.Size = new Size(355, 21);
      this.txtCode.TabIndex = 6;
      this.txtCode.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblCode.Font = new Font("Verdana", 8.25f);
      this.lblCode.Location = new System.Drawing.Point(8, 222);
      this.lblCode.Name = "lblCode";
      this.lblCode.Size = new Size(72, 20);
      this.lblCode.TabIndex = 5;
      this.lblCode.Text = "Code";
      this.txtDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDescription.Font = new Font("Verdana", 8.25f);
      this.txtDescription.Location = new System.Drawing.Point(176, 246);
      this.txtDescription.MaxLength = 0;
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ScrollBars = ScrollBars.Vertical;
      this.txtDescription.Size = new Size(355, 20);
      this.txtDescription.TabIndex = 8;
      this.txtDescription.Tag = (object) "SystemScheduleOfRate.Description";
      this.lblDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblDescription.Font = new Font("Verdana", 8.25f);
      this.lblDescription.Location = new System.Drawing.Point(8, 246);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(112, 20);
      this.lblDescription.TabIndex = 7;
      this.lblDescription.Text = "Description";
      this.dgScheduleOfRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgScheduleOfRates.DataMember = "";
      this.dgScheduleOfRates.Font = new Font("Verdana", 8.25f);
      this.dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
      this.dgScheduleOfRates.Location = new System.Drawing.Point(8, 20);
      this.dgScheduleOfRates.Name = "dgScheduleOfRates";
      this.dgScheduleOfRates.Size = new Size(523, 138);
      this.dgScheduleOfRates.TabIndex = 0;
      this.txtPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtPrice.Font = new Font("Verdana", 8.25f);
      this.txtPrice.Location = new System.Drawing.Point(48, 294);
      this.txtPrice.MaxLength = 9;
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new Size(122, 21);
      this.txtPrice.TabIndex = 12;
      this.txtPrice.Tag = (object) "SystemScheduleOfRate.Price";
      this.lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPrice.Font = new Font("Verdana", 8.25f);
      this.lblPrice.Location = new System.Drawing.Point(8, 294);
      this.lblPrice.Name = "lblPrice";
      this.lblPrice.Size = new Size(40, 20);
      this.lblPrice.TabIndex = 11;
      this.lblPrice.Text = "Price";
      this.lblQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblQuantity.Font = new Font("Verdana", 8.25f);
      this.lblQuantity.Location = new System.Drawing.Point(176, 294);
      this.lblQuantity.Name = "lblQuantity";
      this.lblQuantity.Size = new Size(56, 20);
      this.lblQuantity.TabIndex = 13;
      this.lblQuantity.Text = "Quantity";
      this.txtQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQuantity.Font = new Font("Verdana", 8.25f);
      this.txtQuantity.Location = new System.Drawing.Point(256, 294);
      this.txtQuantity.MaxLength = 9;
      this.txtQuantity.Name = "txtQuantity";
      this.txtQuantity.Size = new Size(275, 21);
      this.txtQuantity.TabIndex = 14;
      this.txtQuantity.Tag = (object) "";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Font = new Font("Verdana", 8.25f);
      this.btnAdd.Location = new System.Drawing.Point(8, 326);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(80, 23);
      this.btnAdd.TabIndex = 15;
      this.btnAdd.Text = "Add";
      this.lblQuoteStatus.Font = new Font("Verdana", 8.25f);
      this.lblQuoteStatus.Location = new System.Drawing.Point(474, 38);
      this.lblQuoteStatus.Name = "lblQuoteStatus";
      this.lblQuoteStatus.Size = new Size(88, 23);
      this.lblQuoteStatus.TabIndex = 61;
      this.lblQuoteStatus.Text = "Quote Status:";
      this.lblQuoteDate.Font = new Font("Verdana", 8.25f);
      this.lblQuoteDate.Location = new System.Drawing.Point(475, 3);
      this.lblQuoteDate.Name = "lblQuoteDate";
      this.lblQuoteDate.Size = new Size(80, 23);
      this.lblQuoteDate.TabIndex = 60;
      this.lblQuoteDate.Text = "Quote Date:";
      this.cboQuoteStatus.Font = new Font("Verdana", 8.25f);
      this.cboQuoteStatus.ItemHeight = 13;
      this.cboQuoteStatus.Location = new System.Drawing.Point(560, 37);
      this.cboQuoteStatus.Name = "cboQuoteStatus";
      this.cboQuoteStatus.Size = new Size(151, 21);
      this.cboQuoteStatus.TabIndex = 4;
      this.grpJobItems.Controls.Add((Control) this.lblNA);
      this.grpJobItems.Controls.Add((Control) this.lblEstStartDAte);
      this.grpJobItems.Controls.Add((Control) this.txtInstallerLabourDays);
      this.grpJobItems.Controls.Add((Control) this.dtpestStartDate);
      this.grpJobItems.Controls.Add((Control) this.lblInstallerDays);
      this.grpJobItems.Controls.Add((Control) this.txtAccess);
      this.grpJobItems.Controls.Add((Control) this.lblAddCharges);
      this.grpJobItems.Controls.Add((Control) this.cboAccess);
      this.grpJobItems.Controls.Add((Control) this.lblAccessEquipment);
      this.grpJobItems.Controls.Add((Control) this.lblAsbestosNotes);
      this.grpJobItems.Controls.Add((Control) this.txtAsbestos);
      this.grpJobItems.Controls.Add((Control) this.cboAsbestos);
      this.grpJobItems.Controls.Add((Control) this.lblAsbestosStatus);
      this.grpJobItems.Controls.Add((Control) this.lblInstallerNotes);
      this.grpJobItems.Controls.Add((Control) this.txtInstallerNotes);
      this.grpJobItems.Font = new Font("Verdana", 8.25f);
      this.grpJobItems.Location = new System.Drawing.Point(8, 66);
      this.grpJobItems.Name = "grpJobItems";
      this.grpJobItems.Size = new Size(539, 266);
      this.grpJobItems.TabIndex = 5;
      this.grpJobItems.TabStop = false;
      this.grpJobItems.Text = "Job Details";
      this.lblNA.Font = new Font("Verdana", 8.25f);
      this.lblNA.Location = new System.Drawing.Point(120, 245);
      this.lblNA.Name = "lblNA";
      this.lblNA.Size = new Size(73, 19);
      this.lblNA.TabIndex = 72;
      this.lblNA.Text = "N/A";
      this.lblNA.Visible = false;
      this.lblEstStartDAte.Font = new Font("Verdana", 8.25f);
      this.lblEstStartDAte.Location = new System.Drawing.Point(8, 246);
      this.lblEstStartDAte.Name = "lblEstStartDAte";
      this.lblEstStartDAte.Size = new Size(109, 17);
      this.lblEstStartDAte.TabIndex = 73;
      this.lblEstStartDAte.Text = "Est Start Date";
      this.txtInstallerLabourDays.Font = new Font("Verdana", 8.25f);
      this.txtInstallerLabourDays.Location = new System.Drawing.Point(123, 147);
      this.txtInstallerLabourDays.MaxLength = 50;
      this.txtInstallerLabourDays.Name = "txtInstallerLabourDays";
      this.txtInstallerLabourDays.Size = new Size(143, 21);
      this.txtInstallerLabourDays.TabIndex = 20;
      this.txtInstallerLabourDays.Tag = (object) "SystemScheduleOfRate.Code";
      this.dtpestStartDate.CalendarFont = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpestStartDate.Font = new Font("Verdana", 8.25f);
      this.dtpestStartDate.Location = new System.Drawing.Point(123, 242);
      this.dtpestStartDate.Name = "dtpestStartDate";
      this.dtpestStartDate.Size = new Size(167, 21);
      this.dtpestStartDate.TabIndex = 72;
      this.dtpestStartDate.Value = new DateTime(2007, 8, 13, 15, 56, 20, 616);
      this.lblInstallerDays.Font = new Font("Verdana", 8.25f);
      this.lblInstallerDays.Location = new System.Drawing.Point(8, 150);
      this.lblInstallerDays.Name = "lblInstallerDays";
      this.lblInstallerDays.Size = new Size(98, 20);
      this.lblInstallerDays.TabIndex = 19;
      this.lblInstallerDays.Text = "Installer Days";
      this.txtAccess.AcceptsReturn = true;
      this.txtAccess.Font = new Font("Verdana", 8.25f);
      this.txtAccess.Location = new System.Drawing.Point(460, 216);
      this.txtAccess.MaxLength = 50;
      this.txtAccess.Name = "txtAccess";
      this.txtAccess.Size = new Size(71, 21);
      this.txtAccess.TabIndex = 18;
      this.txtAccess.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblAddCharges.Font = new Font("Verdana", 8.25f);
      this.lblAddCharges.Location = new System.Drawing.Point(328, 219);
      this.lblAddCharges.Name = "lblAddCharges";
      this.lblAddCharges.Size = new Size(134, 20);
      this.lblAddCharges.TabIndex = 17;
      this.lblAddCharges.Text = "Access / Add Charges";
      this.cboAccess.Cursor = Cursors.Hand;
      this.cboAccess.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAccess.Font = new Font("Verdana", 8.25f);
      this.cboAccess.Location = new System.Drawing.Point(123, 216);
      this.cboAccess.Name = "cboAccess";
      this.cboAccess.Size = new Size(201, 21);
      this.cboAccess.TabIndex = 14;
      this.cboAccess.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblAccessEquipment.Font = new Font("Verdana", 8.25f);
      this.lblAccessEquipment.Location = new System.Drawing.Point(6, 216);
      this.lblAccessEquipment.Name = "lblAccessEquipment";
      this.lblAccessEquipment.Size = new Size(114, 20);
      this.lblAccessEquipment.TabIndex = 13;
      this.lblAccessEquipment.Text = "Access Equipment";
      this.lblAsbestosNotes.Font = new Font("Verdana", 8.25f);
      this.lblAsbestosNotes.Location = new System.Drawing.Point(8, 174);
      this.lblAsbestosNotes.Name = "lblAsbestosNotes";
      this.lblAsbestosNotes.Size = new Size(112, 20);
      this.lblAsbestosNotes.TabIndex = 12;
      this.lblAsbestosNotes.Text = "Asbestos Notes";
      this.txtAsbestos.Font = new Font("Verdana", 8.25f);
      this.txtAsbestos.Location = new System.Drawing.Point(123, 174);
      this.txtAsbestos.MaxLength = 50;
      this.txtAsbestos.Multiline = true;
      this.txtAsbestos.Name = "txtAsbestos";
      this.txtAsbestos.Size = new Size(410, 36);
      this.txtAsbestos.TabIndex = 11;
      this.txtAsbestos.Tag = (object) "SystemScheduleOfRate.Code";
      this.cboAsbestos.Cursor = Cursors.Hand;
      this.cboAsbestos.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAsbestos.Font = new Font("Verdana", 8.25f);
      this.cboAsbestos.Location = new System.Drawing.Point(397, 147);
      this.cboAsbestos.Name = "cboAsbestos";
      this.cboAsbestos.Size = new Size(136, 21);
      this.cboAsbestos.TabIndex = 10;
      this.cboAsbestos.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblAsbestosStatus.Font = new Font("Verdana", 8.25f);
      this.lblAsbestosStatus.Location = new System.Drawing.Point(272, 150);
      this.lblAsbestosStatus.Name = "lblAsbestosStatus";
      this.lblAsbestosStatus.Size = new Size(114, 20);
      this.lblAsbestosStatus.TabIndex = 9;
      this.lblAsbestosStatus.Text = "Asbestos Status";
      this.lblInstallerNotes.Font = new Font("Verdana", 8.25f);
      this.lblInstallerNotes.Location = new System.Drawing.Point(8, 23);
      this.lblInstallerNotes.Name = "lblInstallerNotes";
      this.lblInstallerNotes.Size = new Size(98, 20);
      this.lblInstallerNotes.TabIndex = 8;
      this.lblInstallerNotes.Text = "Installer Notes";
      this.txtInstallerNotes.Font = new Font("Verdana", 8.25f);
      this.txtInstallerNotes.Location = new System.Drawing.Point(123, 23);
      this.txtInstallerNotes.MaxLength = 50;
      this.txtInstallerNotes.Multiline = true;
      this.txtInstallerNotes.Name = "txtInstallerNotes";
      this.txtInstallerNotes.Size = new Size(410, 118);
      this.txtInstallerNotes.TabIndex = 7;
      this.txtInstallerNotes.Tag = (object) "SystemScheduleOfRate.Code";
      this.txtReference.Font = new Font("Verdana", 8.25f);
      this.txtReference.Location = new System.Drawing.Point(316, 37);
      this.txtReference.MaxLength = 50;
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(154, 21);
      this.txtReference.TabIndex = 3;
      this.cboJobType.Font = new Font("Verdana", 8.25f);
      this.cboJobType.ItemHeight = 13;
      this.cboJobType.Location = new System.Drawing.Point(316, 1);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(154, 21);
      this.cboJobType.TabIndex = 1;
      this.lblJobType.Font = new Font("Verdana", 8.25f);
      this.lblJobType.Location = new System.Drawing.Point(252, 3);
      this.lblJobType.Name = "lblJobType";
      this.lblJobType.Size = new Size(72, 23);
      this.lblJobType.TabIndex = 56;
      this.lblJobType.Text = "Job Type:";
      this.lblCustomer.Font = new Font("Verdana", 8.25f);
      this.lblCustomer.Location = new System.Drawing.Point(8, 4);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new Size(80, 23);
      this.lblCustomer.TabIndex = 54;
      this.lblCustomer.Text = "Customer:";
      this.grpTotals.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.grpTotals.Controls.Add((Control) this.txtOriginalQuote);
      this.grpTotals.Controls.Add((Control) this.lblOriginalQuote);
      this.grpTotals.Controls.Add((Control) this.txtGrandTotal);
      this.grpTotals.Controls.Add((Control) this.chkSORCharge);
      this.grpTotals.Controls.Add((Control) this.lblBOC);
      this.grpTotals.Controls.Add((Control) this.txtDeposit);
      this.grpTotals.Controls.Add((Control) this.lblDeposit);
      this.grpTotals.Controls.Add((Control) this.txtincVAT);
      this.grpTotals.Controls.Add((Control) this.lblIncVAT);
      this.grpTotals.Controls.Add((Control) this.cboVAT);
      this.grpTotals.Controls.Add((Control) this.lblVAT);
      this.grpTotals.Controls.Add((Control) this.txtTotalCosts);
      this.grpTotals.Controls.Add((Control) this.lblSale);
      this.grpTotals.Controls.Add((Control) this.txtProfitPound);
      this.grpTotals.Controls.Add((Control) this.lblProfitSlash);
      this.grpTotals.Controls.Add((Control) this.txtProfitPerc);
      this.grpTotals.Controls.Add((Control) this.lblProfit);
      this.grpTotals.Controls.Add((Control) this.lblTotalCosts);
      this.grpTotals.Controls.Add((Control) this.txtPartsCostTotal);
      this.grpTotals.Controls.Add((Control) this.txtBuilderCharge);
      this.grpTotals.Controls.Add((Control) this.lblTotalBuilderCharge);
      this.grpTotals.Controls.Add((Control) this.txtBuilderMarkup);
      this.grpTotals.Controls.Add((Control) this.lblBuilderMarkup);
      this.grpTotals.Controls.Add((Control) this.txtBuilderCost);
      this.grpTotals.Controls.Add((Control) this.lblBuilderCost);
      this.grpTotals.Controls.Add((Control) this.txtElectricianCharge);
      this.grpTotals.Controls.Add((Control) this.lblTotalElectricianCharge);
      this.grpTotals.Controls.Add((Control) this.txtElectricianMarkup);
      this.grpTotals.Controls.Add((Control) this.lblElectricianMarkup);
      this.grpTotals.Controls.Add((Control) this.txtElectricianCost);
      this.grpTotals.Controls.Add((Control) this.lblElectricianCost);
      this.grpTotals.Controls.Add((Control) this.txtInstallerCharge);
      this.grpTotals.Controls.Add((Control) this.lblTotalInstallerCharge);
      this.grpTotals.Controls.Add((Control) this.txtInstallerMarkup);
      this.grpTotals.Controls.Add((Control) this.lblInstallerMarkup);
      this.grpTotals.Controls.Add((Control) this.txtInstallerCost);
      this.grpTotals.Controls.Add((Control) this.lblInstallerCost);
      this.grpTotals.Controls.Add((Control) this.txtScheduleRatesCostTotal);
      this.grpTotals.Controls.Add((Control) this.lblTotalSORCharge);
      this.grpTotals.Controls.Add((Control) this.txtScheduleRateMarkup);
      this.grpTotals.Controls.Add((Control) this.lblSORMarkup);
      this.grpTotals.Controls.Add((Control) this.txtScheduleRatesCost);
      this.grpTotals.Controls.Add((Control) this.lblSORCost);
      this.grpTotals.Controls.Add((Control) this.lblTotalPartsCharge);
      this.grpTotals.Controls.Add((Control) this.txtPartsProductsMarkup);
      this.grpTotals.Controls.Add((Control) this.lblPartsMarkup);
      this.grpTotals.Controls.Add((Control) this.txtBOC);
      this.grpTotals.Controls.Add((Control) this.txtPartsCost);
      this.grpTotals.Controls.Add((Control) this.lblPartsCost);
      this.grpTotals.Font = new Font("Verdana", 8.25f);
      this.grpTotals.Location = new System.Drawing.Point(579, 490);
      this.grpTotals.Name = "grpTotals";
      this.grpTotals.Size = new Size(592, 207);
      this.grpTotals.TabIndex = 64;
      this.grpTotals.TabStop = false;
      this.grpTotals.Text = "Summary Of Quote";
      this.txtOriginalQuote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtOriginalQuote.Enabled = false;
      this.txtOriginalQuote.Font = new Font("Verdana", 8.25f);
      this.txtOriginalQuote.Location = new System.Drawing.Point(292, 10);
      this.txtOriginalQuote.MaxLength = 50;
      this.txtOriginalQuote.Name = "txtOriginalQuote";
      this.txtOriginalQuote.ReadOnly = true;
      this.txtOriginalQuote.Size = new Size(99, 21);
      this.txtOriginalQuote.TabIndex = 94;
      this.lblOriginalQuote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblOriginalQuote.Font = new Font("Verdana", 8.25f);
      this.lblOriginalQuote.Location = new System.Drawing.Point(136, 9);
      this.lblOriginalQuote.Name = "lblOriginalQuote";
      this.lblOriginalQuote.Size = new Size(172, 23);
      this.lblOriginalQuote.TabIndex = 95;
      this.lblOriginalQuote.Text = "Original Quote (ex VAT)";
      this.lblOriginalQuote.TextAlign = ContentAlignment.MiddleLeft;
      this.txtGrandTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtGrandTotal.Enabled = false;
      this.txtGrandTotal.Font = new Font("Verdana", 8.25f);
      this.txtGrandTotal.Location = new System.Drawing.Point(41, 183);
      this.txtGrandTotal.MaxLength = 50;
      this.txtGrandTotal.Name = "txtGrandTotal";
      this.txtGrandTotal.Size = new Size(70, 21);
      this.txtGrandTotal.TabIndex = 87;
      this.chkSORCharge.AutoSize = true;
      this.chkSORCharge.Location = new System.Drawing.Point(9, 17);
      this.chkSORCharge.Name = "chkSORCharge";
      this.chkSORCharge.Size = new Size(97, 17);
      this.chkSORCharge.TabIndex = 93;
      this.chkSORCharge.Text = "SOR Charge";
      this.chkSORCharge.UseVisualStyleBackColor = true;
      this.lblBOC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBOC.Font = new Font("Verdana", 8.25f);
      this.lblBOC.Location = new System.Drawing.Point(461, 183);
      this.lblBOC.Name = "lblBOC";
      this.lblBOC.Size = new Size(51, 19);
      this.lblBOC.TabIndex = 92;
      this.lblBOC.Text = "B.O.C";
      this.lblBOC.TextAlign = ContentAlignment.MiddleLeft;
      this.txtDeposit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtDeposit.Enabled = false;
      this.txtDeposit.Font = new Font("Verdana", 8.25f);
      this.txtDeposit.Location = new System.Drawing.Point(397, 183);
      this.txtDeposit.MaxLength = 50;
      this.txtDeposit.Name = "txtDeposit";
      this.txtDeposit.Size = new Size(64, 21);
      this.txtDeposit.TabIndex = 91;
      this.lblDeposit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblDeposit.Font = new Font("Verdana", 8.25f);
      this.lblDeposit.Location = new System.Drawing.Point(346, 184);
      this.lblDeposit.Name = "lblDeposit";
      this.lblDeposit.Size = new Size(51, 19);
      this.lblDeposit.TabIndex = 90;
      this.lblDeposit.Text = "Deposit";
      this.lblDeposit.TextAlign = ContentAlignment.MiddleLeft;
      this.txtincVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtincVAT.Enabled = false;
      this.txtincVAT.Font = new Font("Verdana", 8.25f);
      this.txtincVAT.Location = new System.Drawing.Point(275, 183);
      this.txtincVAT.MaxLength = 50;
      this.txtincVAT.Name = "txtincVAT";
      this.txtincVAT.ReadOnly = true;
      this.txtincVAT.Size = new Size(65, 21);
      this.txtincVAT.TabIndex = 89;
      this.lblIncVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblIncVAT.Font = new Font("Verdana", 8.25f);
      this.lblIncVAT.Location = new System.Drawing.Point(218, 184);
      this.lblIncVAT.Name = "lblIncVAT";
      this.lblIncVAT.Size = new Size(68, 17);
      this.lblIncVAT.TabIndex = 88;
      this.lblIncVAT.Text = "inc VAT:";
      this.lblIncVAT.TextAlign = ContentAlignment.MiddleLeft;
      this.cboVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboVAT.Cursor = Cursors.Hand;
      this.cboVAT.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVAT.Font = new Font("Verdana", 8.25f);
      this.cboVAT.Location = new System.Drawing.Point(138, 183);
      this.cboVAT.Name = "cboVAT";
      this.cboVAT.Size = new Size(78, 21);
      this.cboVAT.TabIndex = 22;
      this.cboVAT.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblVAT.Font = new Font("Verdana", 8.25f);
      this.lblVAT.Location = new System.Drawing.Point(111, 185);
      this.lblVAT.Name = "lblVAT";
      this.lblVAT.Size = new Size(37, 15);
      this.lblVAT.TabIndex = 21;
      this.lblVAT.Text = "VAT";
      this.txtTotalCosts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtTotalCosts.Enabled = false;
      this.txtTotalCosts.Font = new Font("Verdana", 8.25f);
      this.txtTotalCosts.Location = new System.Drawing.Point(138, 159);
      this.txtTotalCosts.MaxLength = 50;
      this.txtTotalCosts.Name = "txtTotalCosts";
      this.txtTotalCosts.ReadOnly = true;
      this.txtTotalCosts.Size = new Size(78, 21);
      this.txtTotalCosts.TabIndex = 81;
      this.lblSale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblSale.Font = new Font("Verdana", 8.25f);
      this.lblSale.Location = new System.Drawing.Point(9, 183);
      this.lblSale.Name = "lblSale";
      this.lblSale.Size = new Size(33, 19);
      this.lblSale.TabIndex = 86;
      this.lblSale.Text = "Sale";
      this.lblSale.TextAlign = ContentAlignment.MiddleLeft;
      this.txtProfitPound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtProfitPound.Enabled = false;
      this.txtProfitPound.Font = new Font("Verdana", 8.25f);
      this.txtProfitPound.Location = new System.Drawing.Point(365, 159);
      this.txtProfitPound.MaxLength = 50;
      this.txtProfitPound.Name = "txtProfitPound";
      this.txtProfitPound.ReadOnly = true;
      this.txtProfitPound.Size = new Size(64, 21);
      this.txtProfitPound.TabIndex = 85;
      this.lblProfitSlash.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblProfitSlash.Font = new Font("Verdana", 8.25f);
      this.lblProfitSlash.Location = new System.Drawing.Point(347, 157);
      this.lblProfitSlash.Name = "lblProfitSlash";
      this.lblProfitSlash.Size = new Size(10, 23);
      this.lblProfitSlash.TabIndex = 84;
      this.lblProfitSlash.Text = "/";
      this.lblProfitSlash.TextAlign = ContentAlignment.MiddleLeft;
      this.txtProfitPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtProfitPerc.Enabled = false;
      this.txtProfitPerc.Font = new Font("Verdana", 8.25f);
      this.txtProfitPerc.Location = new System.Drawing.Point(292, 158);
      this.txtProfitPerc.MaxLength = 50;
      this.txtProfitPerc.Name = "txtProfitPerc";
      this.txtProfitPerc.ReadOnly = true;
      this.txtProfitPerc.Size = new Size(48, 21);
      this.txtProfitPerc.TabIndex = 83;
      this.lblProfit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblProfit.Font = new Font("Verdana", 8.25f);
      this.lblProfit.Location = new System.Drawing.Point(218, 156);
      this.lblProfit.Name = "lblProfit";
      this.lblProfit.Size = new Size(45, 23);
      this.lblProfit.TabIndex = 82;
      this.lblProfit.Text = "Profit";
      this.lblProfit.TextAlign = ContentAlignment.MiddleLeft;
      this.lblTotalCosts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblTotalCosts.Font = new Font("Verdana", 8.25f);
      this.lblTotalCosts.Location = new System.Drawing.Point(9, 156);
      this.lblTotalCosts.Name = "lblTotalCosts";
      this.lblTotalCosts.Size = new Size(102, 23);
      this.lblTotalCosts.TabIndex = 80;
      this.lblTotalCosts.Text = "Total Costs";
      this.lblTotalCosts.TextAlign = ContentAlignment.MiddleLeft;
      this.txtPartsCostTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPartsCostTotal.Enabled = false;
      this.txtPartsCostTotal.Font = new Font("Verdana", 8.25f);
      this.txtPartsCostTotal.Location = new System.Drawing.Point(512, 39);
      this.txtPartsCostTotal.Name = "txtPartsCostTotal";
      this.txtPartsCostTotal.ReadOnly = true;
      this.txtPartsCostTotal.Size = new Size(72, 21);
      this.txtPartsCostTotal.TabIndex = 9;
      this.txtBuilderCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBuilderCharge.Enabled = false;
      this.txtBuilderCharge.Font = new Font("Verdana", 8.25f);
      this.txtBuilderCharge.Location = new System.Drawing.Point(512, 135);
      this.txtBuilderCharge.Name = "txtBuilderCharge";
      this.txtBuilderCharge.ReadOnly = true;
      this.txtBuilderCharge.Size = new Size(72, 21);
      this.txtBuilderCharge.TabIndex = 76;
      this.lblTotalBuilderCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblTotalBuilderCharge.Font = new Font("Verdana", 8.25f);
      this.lblTotalBuilderCharge.Location = new System.Drawing.Point(344, 133);
      this.lblTotalBuilderCharge.Name = "lblTotalBuilderCharge";
      this.lblTotalBuilderCharge.Size = new Size(168, 23);
      this.lblTotalBuilderCharge.TabIndex = 79;
      this.lblTotalBuilderCharge.Text = "Total Builder Charge";
      this.lblTotalBuilderCharge.TextAlign = ContentAlignment.MiddleLeft;
      this.txtBuilderMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBuilderMarkup.Font = new Font("Verdana", 8.25f);
      this.txtBuilderMarkup.Location = new System.Drawing.Point(292, 135);
      this.txtBuilderMarkup.Name = "txtBuilderMarkup";
      this.txtBuilderMarkup.Size = new Size(48, 21);
      this.txtBuilderMarkup.TabIndex = 75;
      this.lblBuilderMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBuilderMarkup.Font = new Font("Verdana", 8.25f);
      this.lblBuilderMarkup.Location = new System.Drawing.Point(219, 135);
      this.lblBuilderMarkup.Name = "lblBuilderMarkup";
      this.lblBuilderMarkup.Size = new Size(80, 20);
      this.lblBuilderMarkup.TabIndex = 78;
      this.lblBuilderMarkup.Text = "Markup (%)";
      this.lblBuilderMarkup.TextAlign = ContentAlignment.MiddleLeft;
      this.txtBuilderCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBuilderCost.Enabled = false;
      this.txtBuilderCost.Font = new Font("Verdana", 8.25f);
      this.txtBuilderCost.Location = new System.Drawing.Point(138, 135);
      this.txtBuilderCost.MaxLength = 50;
      this.txtBuilderCost.Name = "txtBuilderCost";
      this.txtBuilderCost.Size = new Size(78, 21);
      this.txtBuilderCost.TabIndex = 74;
      this.lblBuilderCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBuilderCost.Font = new Font("Verdana", 8.25f);
      this.lblBuilderCost.Location = new System.Drawing.Point(9, 133);
      this.lblBuilderCost.Name = "lblBuilderCost";
      this.lblBuilderCost.Size = new Size(147, 23);
      this.lblBuilderCost.TabIndex = 77;
      this.lblBuilderCost.Text = "Builder Cost";
      this.lblBuilderCost.TextAlign = ContentAlignment.MiddleLeft;
      this.txtElectricianCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtElectricianCharge.Enabled = false;
      this.txtElectricianCharge.Font = new Font("Verdana", 8.25f);
      this.txtElectricianCharge.Location = new System.Drawing.Point(512, 112);
      this.txtElectricianCharge.Name = "txtElectricianCharge";
      this.txtElectricianCharge.ReadOnly = true;
      this.txtElectricianCharge.Size = new Size(72, 21);
      this.txtElectricianCharge.TabIndex = 67;
      this.lblTotalElectricianCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblTotalElectricianCharge.Font = new Font("Verdana", 8.25f);
      this.lblTotalElectricianCharge.Location = new System.Drawing.Point(344, 109);
      this.lblTotalElectricianCharge.Name = "lblTotalElectricianCharge";
      this.lblTotalElectricianCharge.Size = new Size(168, 23);
      this.lblTotalElectricianCharge.TabIndex = 73;
      this.lblTotalElectricianCharge.Text = "Total Electrician Charge";
      this.lblTotalElectricianCharge.TextAlign = ContentAlignment.MiddleLeft;
      this.txtElectricianMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtElectricianMarkup.Font = new Font("Verdana", 8.25f);
      this.txtElectricianMarkup.Location = new System.Drawing.Point(292, 112);
      this.txtElectricianMarkup.Name = "txtElectricianMarkup";
      this.txtElectricianMarkup.Size = new Size(48, 21);
      this.txtElectricianMarkup.TabIndex = 66;
      this.lblElectricianMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectricianMarkup.Font = new Font("Verdana", 8.25f);
      this.lblElectricianMarkup.Location = new System.Drawing.Point(219, 109);
      this.lblElectricianMarkup.Name = "lblElectricianMarkup";
      this.lblElectricianMarkup.Size = new Size(80, 23);
      this.lblElectricianMarkup.TabIndex = 72;
      this.lblElectricianMarkup.Text = "Markup (%)";
      this.lblElectricianMarkup.TextAlign = ContentAlignment.MiddleLeft;
      this.txtElectricianCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtElectricianCost.Enabled = false;
      this.txtElectricianCost.Font = new Font("Verdana", 8.25f);
      this.txtElectricianCost.Location = new System.Drawing.Point(138, 112);
      this.txtElectricianCost.MaxLength = 50;
      this.txtElectricianCost.Name = "txtElectricianCost";
      this.txtElectricianCost.Size = new Size(78, 21);
      this.txtElectricianCost.TabIndex = 65;
      this.lblElectricianCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectricianCost.Font = new Font("Verdana", 8.25f);
      this.lblElectricianCost.Location = new System.Drawing.Point(9, 110);
      this.lblElectricianCost.Name = "lblElectricianCost";
      this.lblElectricianCost.Size = new Size(147, 23);
      this.lblElectricianCost.TabIndex = 71;
      this.lblElectricianCost.Text = "Electrician Cost";
      this.lblElectricianCost.TextAlign = ContentAlignment.MiddleLeft;
      this.txtInstallerCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInstallerCharge.Enabled = false;
      this.txtInstallerCharge.Font = new Font("Verdana", 8.25f);
      this.txtInstallerCharge.Location = new System.Drawing.Point(512, 88);
      this.txtInstallerCharge.Name = "txtInstallerCharge";
      this.txtInstallerCharge.ReadOnly = true;
      this.txtInstallerCharge.Size = new Size(72, 21);
      this.txtInstallerCharge.TabIndex = 64;
      this.lblTotalInstallerCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblTotalInstallerCharge.Font = new Font("Verdana", 8.25f);
      this.lblTotalInstallerCharge.Location = new System.Drawing.Point(344, 86);
      this.lblTotalInstallerCharge.Name = "lblTotalInstallerCharge";
      this.lblTotalInstallerCharge.Size = new Size(160, 23);
      this.lblTotalInstallerCharge.TabIndex = 70;
      this.lblTotalInstallerCharge.Text = "Total Installer Charge";
      this.lblTotalInstallerCharge.TextAlign = ContentAlignment.MiddleLeft;
      this.txtInstallerMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInstallerMarkup.Font = new Font("Verdana", 8.25f);
      this.txtInstallerMarkup.Location = new System.Drawing.Point(292, 88);
      this.txtInstallerMarkup.Name = "txtInstallerMarkup";
      this.txtInstallerMarkup.Size = new Size(48, 21);
      this.txtInstallerMarkup.TabIndex = 63;
      this.lblInstallerMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblInstallerMarkup.Font = new Font("Verdana", 8.25f);
      this.lblInstallerMarkup.Location = new System.Drawing.Point(219, 86);
      this.lblInstallerMarkup.Name = "lblInstallerMarkup";
      this.lblInstallerMarkup.Size = new Size(80, 23);
      this.lblInstallerMarkup.TabIndex = 69;
      this.lblInstallerMarkup.Text = "Markup (%)";
      this.lblInstallerMarkup.TextAlign = ContentAlignment.MiddleLeft;
      this.txtInstallerCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInstallerCost.Enabled = false;
      this.txtInstallerCost.Font = new Font("Verdana", 8.25f);
      this.txtInstallerCost.Location = new System.Drawing.Point(138, 88);
      this.txtInstallerCost.MaxLength = 50;
      this.txtInstallerCost.Name = "txtInstallerCost";
      this.txtInstallerCost.Size = new Size(78, 21);
      this.txtInstallerCost.TabIndex = 62;
      this.lblInstallerCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblInstallerCost.Font = new Font("Verdana", 8.25f);
      this.lblInstallerCost.Location = new System.Drawing.Point(9, 86);
      this.lblInstallerCost.Name = "lblInstallerCost";
      this.lblInstallerCost.Size = new Size(136, 23);
      this.lblInstallerCost.TabIndex = 68;
      this.lblInstallerCost.Text = "Installer Cost";
      this.lblInstallerCost.TextAlign = ContentAlignment.MiddleLeft;
      this.txtScheduleRatesCostTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtScheduleRatesCostTotal.Enabled = false;
      this.txtScheduleRatesCostTotal.Font = new Font("Verdana", 8.25f);
      this.txtScheduleRatesCostTotal.Location = new System.Drawing.Point(512, 63);
      this.txtScheduleRatesCostTotal.Name = "txtScheduleRatesCostTotal";
      this.txtScheduleRatesCostTotal.ReadOnly = true;
      this.txtScheduleRatesCostTotal.Size = new Size(72, 21);
      this.txtScheduleRatesCostTotal.TabIndex = 12;
      this.lblTotalSORCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblTotalSORCharge.Font = new Font("Verdana", 8.25f);
      this.lblTotalSORCharge.Location = new System.Drawing.Point(344, 62);
      this.lblTotalSORCharge.Name = "lblTotalSORCharge";
      this.lblTotalSORCharge.Size = new Size(168, 23);
      this.lblTotalSORCharge.TabIndex = 61;
      this.lblTotalSORCharge.Text = "Total SOR Charge";
      this.lblTotalSORCharge.TextAlign = ContentAlignment.MiddleLeft;
      this.txtScheduleRateMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtScheduleRateMarkup.Font = new Font("Verdana", 8.25f);
      this.txtScheduleRateMarkup.Location = new System.Drawing.Point(292, 63);
      this.txtScheduleRateMarkup.Name = "txtScheduleRateMarkup";
      this.txtScheduleRateMarkup.Size = new Size(48, 21);
      this.txtScheduleRateMarkup.TabIndex = 11;
      this.lblSORMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblSORMarkup.Font = new Font("Verdana", 8.25f);
      this.lblSORMarkup.Location = new System.Drawing.Point(219, 60);
      this.lblSORMarkup.Name = "lblSORMarkup";
      this.lblSORMarkup.Size = new Size(80, 23);
      this.lblSORMarkup.TabIndex = 59;
      this.lblSORMarkup.Text = "Markup (%)";
      this.lblSORMarkup.TextAlign = ContentAlignment.MiddleLeft;
      this.txtScheduleRatesCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtScheduleRatesCost.Enabled = false;
      this.txtScheduleRatesCost.Font = new Font("Verdana", 8.25f);
      this.txtScheduleRatesCost.Location = new System.Drawing.Point(138, 63);
      this.txtScheduleRatesCost.MaxLength = 50;
      this.txtScheduleRatesCost.Name = "txtScheduleRatesCost";
      this.txtScheduleRatesCost.Size = new Size(78, 21);
      this.txtScheduleRatesCost.TabIndex = 10;
      this.lblSORCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblSORCost.Font = new Font("Verdana", 8.25f);
      this.lblSORCost.Location = new System.Drawing.Point(9, 60);
      this.lblSORCost.Name = "lblSORCost";
      this.lblSORCost.Size = new Size(147, 23);
      this.lblSORCost.TabIndex = 57;
      this.lblSORCost.Text = "SOR Cost";
      this.lblSORCost.TextAlign = ContentAlignment.MiddleLeft;
      this.lblTotalPartsCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblTotalPartsCharge.Font = new Font("Verdana", 8.25f);
      this.lblTotalPartsCharge.Location = new System.Drawing.Point(344, 39);
      this.lblTotalPartsCharge.Name = "lblTotalPartsCharge";
      this.lblTotalPartsCharge.Size = new Size(181, 23);
      this.lblTotalPartsCharge.TabIndex = 54;
      this.lblTotalPartsCharge.Text = "Total Parts Charge";
      this.lblTotalPartsCharge.TextAlign = ContentAlignment.MiddleLeft;
      this.txtPartsProductsMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPartsProductsMarkup.Font = new Font("Verdana", 8.25f);
      this.txtPartsProductsMarkup.Location = new System.Drawing.Point(292, 39);
      this.txtPartsProductsMarkup.Name = "txtPartsProductsMarkup";
      this.txtPartsProductsMarkup.Size = new Size(48, 21);
      this.txtPartsProductsMarkup.TabIndex = 8;
      this.lblPartsMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblPartsMarkup.Font = new Font("Verdana", 8.25f);
      this.lblPartsMarkup.Location = new System.Drawing.Point(219, 37);
      this.lblPartsMarkup.Name = "lblPartsMarkup";
      this.lblPartsMarkup.Size = new Size(80, 23);
      this.lblPartsMarkup.TabIndex = 52;
      this.lblPartsMarkup.Text = "Markup (%)";
      this.lblPartsMarkup.TextAlign = ContentAlignment.MiddleLeft;
      this.txtBOC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBOC.Font = new Font("Verdana", 8.25f);
      this.txtBOC.Location = new System.Drawing.Point(512, 183);
      this.txtBOC.MaxLength = 50;
      this.txtBOC.Name = "txtBOC";
      this.txtBOC.ReadOnly = true;
      this.txtBOC.Size = new Size(72, 21);
      this.txtBOC.TabIndex = 16;
      this.txtPartsCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPartsCost.Enabled = false;
      this.txtPartsCost.Font = new Font("Verdana", 8.25f);
      this.txtPartsCost.Location = new System.Drawing.Point(138, 39);
      this.txtPartsCost.MaxLength = 50;
      this.txtPartsCost.Name = "txtPartsCost";
      this.txtPartsCost.Size = new Size(78, 21);
      this.txtPartsCost.TabIndex = 7;
      this.lblPartsCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblPartsCost.Font = new Font("Verdana", 8.25f);
      this.lblPartsCost.Location = new System.Drawing.Point(9, 37);
      this.lblPartsCost.Name = "lblPartsCost";
      this.lblPartsCost.Size = new Size(136, 23);
      this.lblPartsCost.TabIndex = 50;
      this.lblPartsCost.Text = "Parts Cost";
      this.lblPartsCost.TextAlign = ContentAlignment.MiddleLeft;
      this.grpParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.grpParts.Controls.Add((Control) this.btnRemovePartProduct);
      this.grpParts.Controls.Add((Control) this.btnFindPart);
      this.grpParts.Controls.Add((Control) this.dgPartsAndProducts);
      this.grpParts.Font = new Font("Verdana", 8.25f);
      this.grpParts.Location = new System.Drawing.Point(579, 230);
      this.grpParts.Name = "grpParts";
      this.grpParts.Size = new Size(592, 254);
      this.grpParts.TabIndex = 8;
      this.grpParts.TabStop = false;
      this.grpParts.Text = "Parts && Products Required";
      this.btnRemovePartProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemovePartProduct.Font = new Font("Verdana", 8.25f);
      this.btnRemovePartProduct.Location = new System.Drawing.Point(481, 226);
      this.btnRemovePartProduct.Name = "btnRemovePartProduct";
      this.btnRemovePartProduct.Size = new Size(96, 22);
      this.btnRemovePartProduct.TabIndex = 3;
      this.btnRemovePartProduct.Text = "Remove";
      this.btnFindPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnFindPart.Font = new Font("Verdana", 8.25f);
      this.btnFindPart.Location = new System.Drawing.Point(9, 226);
      this.btnFindPart.Name = "btnFindPart";
      this.btnFindPart.Size = new Size(88, 22);
      this.btnFindPart.TabIndex = 1;
      this.btnFindPart.Text = "Add Part";
      this.dgPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartsAndProducts.DataMember = "";
      this.dgPartsAndProducts.Font = new Font("Verdana", 8.25f);
      this.dgPartsAndProducts.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsAndProducts.Location = new System.Drawing.Point(12, 25);
      this.dgPartsAndProducts.Name = "dgPartsAndProducts";
      this.dgPartsAndProducts.Size = new Size(564, 195);
      this.dgPartsAndProducts.TabIndex = 10;
      this.dtpQuoteDate.CalendarFont = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpQuoteDate.Font = new Font("Verdana", 8.25f);
      this.dtpQuoteDate.Location = new System.Drawing.Point(560, 2);
      this.dtpQuoteDate.Name = "dtpQuoteDate";
      this.dtpQuoteDate.Size = new Size(151, 21);
      this.dtpQuoteDate.TabIndex = 2;
      this.dtpQuoteDate.Value = new DateTime(2007, 8, 13, 15, 56, 20, 616);
      this.txtSiteName.Font = new Font("Verdana", 8.25f);
      this.txtSiteName.Location = new System.Drawing.Point(77, 38);
      this.txtSiteName.Name = "txtSiteName";
      this.txtSiteName.ReadOnly = true;
      this.txtSiteName.Size = new Size(172, 21);
      this.txtSiteName.TabIndex = 49;
      this.txtSiteName.TabStop = false;
      this.lblProperty.Font = new Font("Verdana", 8.25f);
      this.lblProperty.Location = new System.Drawing.Point(8, 37);
      this.lblProperty.Name = "lblProperty";
      this.lblProperty.Size = new Size(80, 23);
      this.lblProperty.TabIndex = 55;
      this.lblProperty.Text = "Property:";
      this.lblQuoteRef.Font = new Font("Verdana", 8.25f);
      this.lblQuoteRef.Location = new System.Drawing.Point(251, 37);
      this.lblQuoteRef.Name = "lblQuoteRef";
      this.lblQuoteRef.Size = new Size(73, 23);
      this.lblQuoteRef.TabIndex = 57;
      this.lblQuoteRef.Text = "Quote Ref:";
      this.txtCustomerName.Font = new Font("Verdana", 8.25f);
      this.txtCustomerName.Location = new System.Drawing.Point(77, 3);
      this.txtCustomerName.Name = "txtCustomerName";
      this.txtCustomerName.ReadOnly = true;
      this.txtCustomerName.Size = new Size(172, 21);
      this.txtCustomerName.TabIndex = 48;
      this.txtCustomerName.TabStop = false;
      this.gpOtherLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.gpOtherLabour.Controls.Add((Control) this.txtBuilderArrivalHour);
      this.gpOtherLabour.Controls.Add((Control) this.lblBuilderHour);
      this.gpOtherLabour.Controls.Add((Control) this.txtBuilderArrivalDay);
      this.gpOtherLabour.Controls.Add((Control) this.lblArrivalDay);
      this.gpOtherLabour.Controls.Add((Control) this.txtBuilderHours);
      this.gpOtherLabour.Controls.Add((Control) this.txtBuilderNotes);
      this.gpOtherLabour.Controls.Add((Control) this.lblBuilderNotes);
      this.gpOtherLabour.Controls.Add((Control) this.lblBuilderLabourHours);
      this.gpOtherLabour.Controls.Add((Control) this.lblBuilderLabour);
      this.gpOtherLabour.Controls.Add((Control) this.txtElectricianArrivalHour);
      this.gpOtherLabour.Controls.Add((Control) this.lblElectricianHour);
      this.gpOtherLabour.Controls.Add((Control) this.txtElectricianArrivalDay);
      this.gpOtherLabour.Controls.Add((Control) this.lblElectricianArrivalDay);
      this.gpOtherLabour.Controls.Add((Control) this.txtElectricianHours);
      this.gpOtherLabour.Controls.Add((Control) this.txtElectricianNotes);
      this.gpOtherLabour.Controls.Add((Control) this.lblElectricianNotes);
      this.gpOtherLabour.Controls.Add((Control) this.lblElectricianPackHours);
      this.gpOtherLabour.Controls.Add((Control) this.lblElectOr);
      this.gpOtherLabour.Controls.Add((Control) this.cboElectricalPack);
      this.gpOtherLabour.Controls.Add((Control) this.lblElectricianPack);
      this.gpOtherLabour.Font = new Font("Verdana", 8.25f);
      this.gpOtherLabour.Location = new System.Drawing.Point(579, 72);
      this.gpOtherLabour.Name = "gpOtherLabour";
      this.gpOtherLabour.Size = new Size(592, 152);
      this.gpOtherLabour.TabIndex = 65;
      this.gpOtherLabour.TabStop = false;
      this.gpOtherLabour.Text = "Other Labour";
      this.txtBuilderArrivalHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBuilderArrivalHour.Font = new Font("Verdana", 8.25f);
      this.txtBuilderArrivalHour.Location = new System.Drawing.Point(543, 83);
      this.txtBuilderArrivalHour.MaxLength = 50;
      this.txtBuilderArrivalHour.Name = "txtBuilderArrivalHour";
      this.txtBuilderArrivalHour.Size = new Size(33, 21);
      this.txtBuilderArrivalHour.TabIndex = 40;
      this.txtBuilderArrivalHour.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblBuilderHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBuilderHour.Font = new Font("Verdana", 8.25f);
      this.lblBuilderHour.Location = new System.Drawing.Point(503, 86);
      this.lblBuilderHour.Name = "lblBuilderHour";
      this.lblBuilderHour.Size = new Size(40, 20);
      this.lblBuilderHour.TabIndex = 39;
      this.lblBuilderHour.Text = "Hour";
      this.txtBuilderArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBuilderArrivalDay.Font = new Font("Verdana", 8.25f);
      this.txtBuilderArrivalDay.Location = new System.Drawing.Point(467, 83);
      this.txtBuilderArrivalDay.MaxLength = 50;
      this.txtBuilderArrivalDay.Name = "txtBuilderArrivalDay";
      this.txtBuilderArrivalDay.Size = new Size(33, 21);
      this.txtBuilderArrivalDay.TabIndex = 38;
      this.txtBuilderArrivalDay.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblArrivalDay.Font = new Font("Verdana", 8.25f);
      this.lblArrivalDay.Location = new System.Drawing.Point(394, 86);
      this.lblArrivalDay.Name = "lblArrivalDay";
      this.lblArrivalDay.Size = new Size(77, 20);
      this.lblArrivalDay.TabIndex = 37;
      this.lblArrivalDay.Text = "Arrival Day";
      this.txtBuilderHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBuilderHours.Font = new Font("Verdana", 8.25f);
      this.txtBuilderHours.Location = new System.Drawing.Point(123, 82);
      this.txtBuilderHours.MaxLength = 50;
      this.txtBuilderHours.Name = "txtBuilderHours";
      this.txtBuilderHours.Size = new Size(58, 21);
      this.txtBuilderHours.TabIndex = 33;
      this.txtBuilderHours.Tag = (object) "SystemScheduleOfRate.Code";
      this.txtBuilderNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtBuilderNotes.Font = new Font("Verdana", 8.25f);
      this.txtBuilderNotes.Location = new System.Drawing.Point(123, 109);
      this.txtBuilderNotes.MaxLength = 50;
      this.txtBuilderNotes.Multiline = true;
      this.txtBuilderNotes.Name = "txtBuilderNotes";
      this.txtBuilderNotes.Size = new Size(453, 30);
      this.txtBuilderNotes.TabIndex = 30;
      this.txtBuilderNotes.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblBuilderNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBuilderNotes.Font = new Font("Verdana", 8.25f);
      this.lblBuilderNotes.Location = new System.Drawing.Point(8, 110);
      this.lblBuilderNotes.Name = "lblBuilderNotes";
      this.lblBuilderNotes.Size = new Size(109, 20);
      this.lblBuilderNotes.TabIndex = 36;
      this.lblBuilderNotes.Text = "Builder Notes";
      this.lblBuilderLabourHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBuilderLabourHours.Font = new Font("Verdana", 8.25f);
      this.lblBuilderLabourHours.Location = new System.Drawing.Point(184, 85);
      this.lblBuilderLabourHours.Name = "lblBuilderLabourHours";
      this.lblBuilderLabourHours.Size = new Size(32, 20);
      this.lblBuilderLabourHours.TabIndex = 35;
      this.lblBuilderLabourHours.Text = "Hrs";
      this.lblBuilderLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBuilderLabour.Font = new Font("Verdana", 8.25f);
      this.lblBuilderLabour.Location = new System.Drawing.Point(8, 85);
      this.lblBuilderLabour.Name = "lblBuilderLabour";
      this.lblBuilderLabour.Size = new Size(109, 20);
      this.lblBuilderLabour.TabIndex = 32;
      this.lblBuilderLabour.Text = "Builder Labour";
      this.txtElectricianArrivalHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtElectricianArrivalHour.Font = new Font("Verdana", 8.25f);
      this.txtElectricianArrivalHour.Location = new System.Drawing.Point(543, 15);
      this.txtElectricianArrivalHour.MaxLength = 50;
      this.txtElectricianArrivalHour.Name = "txtElectricianArrivalHour";
      this.txtElectricianArrivalHour.Size = new Size(33, 21);
      this.txtElectricianArrivalHour.TabIndex = 29;
      this.txtElectricianArrivalHour.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblElectricianHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectricianHour.Font = new Font("Verdana", 8.25f);
      this.lblElectricianHour.Location = new System.Drawing.Point(503, 18);
      this.lblElectricianHour.Name = "lblElectricianHour";
      this.lblElectricianHour.Size = new Size(40, 20);
      this.lblElectricianHour.TabIndex = 28;
      this.lblElectricianHour.Text = "Hour";
      this.txtElectricianArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtElectricianArrivalDay.Font = new Font("Verdana", 8.25f);
      this.txtElectricianArrivalDay.Location = new System.Drawing.Point(467, 15);
      this.txtElectricianArrivalDay.MaxLength = 50;
      this.txtElectricianArrivalDay.Name = "txtElectricianArrivalDay";
      this.txtElectricianArrivalDay.Size = new Size(33, 21);
      this.txtElectricianArrivalDay.TabIndex = 27;
      this.txtElectricianArrivalDay.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblElectricianArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectricianArrivalDay.Font = new Font("Verdana", 8.25f);
      this.lblElectricianArrivalDay.Location = new System.Drawing.Point(394, 18);
      this.lblElectricianArrivalDay.Name = "lblElectricianArrivalDay";
      this.lblElectricianArrivalDay.Size = new Size(77, 20);
      this.lblElectricianArrivalDay.TabIndex = 26;
      this.lblElectricianArrivalDay.Text = "Arrival Day";
      this.txtElectricianHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtElectricianHours.Font = new Font("Verdana", 8.25f);
      this.txtElectricianHours.Location = new System.Drawing.Point(265, 15);
      this.txtElectricianHours.MaxLength = 50;
      this.txtElectricianHours.Name = "txtElectricianHours";
      this.txtElectricianHours.Size = new Size(58, 21);
      this.txtElectricianHours.TabIndex = 22;
      this.txtElectricianHours.Tag = (object) "SystemScheduleOfRate.Code";
      this.txtElectricianNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtElectricianNotes.Font = new Font("Verdana", 8.25f);
      this.txtElectricianNotes.Location = new System.Drawing.Point(123, 41);
      this.txtElectricianNotes.MaxLength = 50;
      this.txtElectricianNotes.Multiline = true;
      this.txtElectricianNotes.Name = "txtElectricianNotes";
      this.txtElectricianNotes.Size = new Size(453, 36);
      this.txtElectricianNotes.TabIndex = 21;
      this.txtElectricianNotes.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblElectricianNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectricianNotes.Font = new Font("Verdana", 8.25f);
      this.lblElectricianNotes.Location = new System.Drawing.Point(8, 42);
      this.lblElectricianNotes.Name = "lblElectricianNotes";
      this.lblElectricianNotes.Size = new Size(109, 20);
      this.lblElectricianNotes.TabIndex = 25;
      this.lblElectricianNotes.Text = "Electrician Notes";
      this.lblElectricianPackHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectricianPackHours.Font = new Font("Verdana", 8.25f);
      this.lblElectricianPackHours.Location = new System.Drawing.Point(326, 18);
      this.lblElectricianPackHours.Name = "lblElectricianPackHours";
      this.lblElectricianPackHours.Size = new Size(32, 20);
      this.lblElectricianPackHours.TabIndex = 24;
      this.lblElectricianPackHours.Text = "Hrs";
      this.lblElectOr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectOr.Font = new Font("Verdana", 8.25f);
      this.lblElectOr.Location = new System.Drawing.Point(241, 18);
      this.lblElectOr.Name = "lblElectOr";
      this.lblElectOr.Size = new Size(31, 20);
      this.lblElectOr.TabIndex = 23;
      this.lblElectOr.Text = "Or";
      this.cboElectricalPack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboElectricalPack.Cursor = Cursors.Hand;
      this.cboElectricalPack.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboElectricalPack.Font = new Font("Verdana", 8.25f);
      this.cboElectricalPack.Location = new System.Drawing.Point(123, 16);
      this.cboElectricalPack.Name = "cboElectricalPack";
      this.cboElectricalPack.Size = new Size(116, 21);
      this.cboElectricalPack.TabIndex = 21;
      this.cboElectricalPack.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblElectricianPack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblElectricianPack.Font = new Font("Verdana", 8.25f);
      this.lblElectricianPack.Location = new System.Drawing.Point(8, 17);
      this.lblElectricianPack.Name = "lblElectricianPack";
      this.lblElectricianPack.Size = new Size(109, 20);
      this.lblElectricianPack.TabIndex = 21;
      this.lblElectricianPack.Text = "Electrician Pack";
      this.txtSurveyor.Font = new Font("Verdana", 8.25f);
      this.txtSurveyor.Location = new System.Drawing.Point(821, 2);
      this.txtSurveyor.MaxLength = 50;
      this.txtSurveyor.Name = "txtSurveyor";
      this.txtSurveyor.ReadOnly = true;
      this.txtSurveyor.Size = new Size(204, 21);
      this.txtSurveyor.TabIndex = 66;
      this.lblSurveyor.Font = new Font("Verdana", 8.25f);
      this.lblSurveyor.Location = new System.Drawing.Point(715, 6);
      this.lblSurveyor.Name = "lblSurveyor";
      this.lblSurveyor.Size = new Size(76, 23);
      this.lblSurveyor.TabIndex = 67;
      this.lblSurveyor.Text = "Surveyor";
      this.lblLastChangedOn.Font = new Font("Verdana", 8.25f);
      this.lblLastChangedOn.Location = new System.Drawing.Point(714, 40);
      this.lblLastChangedOn.Name = "lblLastChangedOn";
      this.lblLastChangedOn.Size = new Size(106, 23);
      this.lblLastChangedOn.TabIndex = 68;
      this.lblLastChangedOn.Text = "Last Changed On";
      this.txtChangedDate.Font = new Font("Verdana", 8.25f);
      this.txtChangedDate.Location = new System.Drawing.Point(821, 38);
      this.txtChangedDate.MaxLength = 50;
      this.txtChangedDate.Name = "txtChangedDate";
      this.txtChangedDate.ReadOnly = true;
      this.txtChangedDate.Size = new Size(66, 21);
      this.txtChangedDate.TabIndex = 69;
      this.lblChangedBy.Font = new Font("Verdana", 8.25f);
      this.lblChangedBy.Location = new System.Drawing.Point(890, 39);
      this.lblChangedBy.Name = "lblChangedBy";
      this.lblChangedBy.Size = new Size(29, 23);
      this.lblChangedBy.TabIndex = 70;
      this.lblChangedBy.Text = "by";
      this.txtChangedBy.Font = new Font("Verdana", 8.25f);
      this.txtChangedBy.Location = new System.Drawing.Point(914, 38);
      this.txtChangedBy.MaxLength = 50;
      this.txtChangedBy.Name = "txtChangedBy";
      this.txtChangedBy.ReadOnly = true;
      this.txtChangedBy.Size = new Size(111, 21);
      this.txtChangedBy.TabIndex = 71;
      this.lblPurchaseDept.Font = new Font("Verdana", 8.25f);
      this.lblPurchaseDept.Location = new System.Drawing.Point(1031, 26);
      this.lblPurchaseDept.Name = "lblPurchaseDept";
      this.lblPurchaseDept.Size = new Size(125, 16);
      this.lblPurchaseDept.TabIndex = 72;
      this.lblPurchaseDept.Text = "Purchase Dept";
      this.lblPurchaseDept.TextAlign = ContentAlignment.TopCenter;
      this.cboDept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboDept.Cursor = Cursors.Hand;
      this.cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDept.Font = new Font("Verdana", 8.25f);
      this.cboDept.Location = new System.Drawing.Point(1039, 39);
      this.cboDept.Name = "cboDept";
      this.cboDept.Size = new Size(116, 21);
      this.cboDept.TabIndex = 41;
      this.cboDept.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.chkService.AutoSize = true;
      this.chkService.Checked = true;
      this.chkService.CheckState = CheckState.Checked;
      this.chkService.Location = new System.Drawing.Point(1039, 5);
      this.chkService.Name = "chkService";
      this.chkService.Size = new Size(53, 17);
      this.chkService.TabIndex = 73;
      this.chkService.Text = "Serv";
      this.chkService.UseVisualStyleBackColor = true;
      this.chkHOver.AutoSize = true;
      this.chkHOver.Checked = true;
      this.chkHOver.CheckState = CheckState.Checked;
      this.chkHOver.Location = new System.Drawing.Point(1098, 5);
      this.chkHOver.Name = "chkHOver";
      this.chkHOver.Size = new Size(66, 17);
      this.chkHOver.TabIndex = 74;
      this.chkHOver.Text = "H.Over";
      this.chkHOver.UseVisualStyleBackColor = true;
      this.Controls.Add((Control) this.chkHOver);
      this.Controls.Add((Control) this.chkService);
      this.Controls.Add((Control) this.cboDept);
      this.Controls.Add((Control) this.txtCustomerName);
      this.Controls.Add((Control) this.cboQuoteStatus);
      this.Controls.Add((Control) this.lblPurchaseDept);
      this.Controls.Add((Control) this.txtChangedBy);
      this.Controls.Add((Control) this.lblChangedBy);
      this.Controls.Add((Control) this.txtChangedDate);
      this.Controls.Add((Control) this.lblLastChangedOn);
      this.Controls.Add((Control) this.txtSurveyor);
      this.Controls.Add((Control) this.lblSurveyor);
      this.Controls.Add((Control) this.gpOtherLabour);
      this.Controls.Add((Control) this.grpRates);
      this.Controls.Add((Control) this.lblQuoteStatus);
      this.Controls.Add((Control) this.lblQuoteDate);
      this.Controls.Add((Control) this.grpJobItems);
      this.Controls.Add((Control) this.txtReference);
      this.Controls.Add((Control) this.cboJobType);
      this.Controls.Add((Control) this.lblJobType);
      this.Controls.Add((Control) this.lblCustomer);
      this.Controls.Add((Control) this.grpTotals);
      this.Controls.Add((Control) this.grpParts);
      this.Controls.Add((Control) this.dtpQuoteDate);
      this.Controls.Add((Control) this.txtSiteName);
      this.Controls.Add((Control) this.lblProperty);
      this.Controls.Add((Control) this.lblQuoteRef);
      this.Name = nameof (UCQuoteJob);
      this.Size = new Size(1179, 705);
      this.grpRates.ResumeLayout(false);
      this.grpRates.PerformLayout();
      this.dgScheduleOfRates.EndInit();
      this.grpJobItems.ResumeLayout(false);
      this.grpJobItems.PerformLayout();
      this.grpTotals.ResumeLayout(false);
      this.grpTotals.PerformLayout();
      this.grpParts.ResumeLayout(false);
      this.dgPartsAndProducts.EndInit();
      this.gpOtherLabour.ResumeLayout(false);
      this.gpOtherLabour.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupPartsAndProductsDataGrid();
      this.SetupScheduleOfRatesDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentQuoteJob;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public event UCQuoteJob.RefreshButtonEventHandler RefreshButton;

    public FSM.Entity.Sites.Site CurrentSite
    {
      get
      {
        return this._CurrentSite;
      }
      set
      {
        this._CurrentSite = value;
        this.CurrentQuoteJob.SetSiteID = (object) this.CurrentSite.SiteID;
        if (!this.CurrentQuoteJob.Exists)
        {
          this.CustomerCharge = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(this.CurrentSite.CustomerID);
          if (!Information.IsNothing((object) this.CustomerCharge))
          {
            this.txtPartsProductsMarkup.Text = Conversions.ToString(this.CustomerCharge.PartsMarkup) + "%";
            this.txtScheduleRateMarkup.Text = Conversions.ToString(this.CustomerCharge.RatesMarkup) + "%";
          }
          this.QuoteNumber = App.DB.QuoteJob.GetNextQuoteNumber();
          if (!Information.IsNothing((object) this.QuoteNumber))
            this.txtReference.Text = this.QuoteNumber.Prefix + Conversions.ToString(this.QuoteNumber.JobNumber);
        }
        this.txtSiteName.Text = this.CurrentSite.Address1 + " " + this.CurrentSite.Address2 + ", " + this.CurrentSite.Postcode;
        this.txtCustomerName.Text = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID).Name;
        if (this.AssetsDataView != null)
          return;
        this.AssetsDataView = App.DB.Asset.Asset_GetForSite(this.CurrentSite.SiteID);
      }
    }

    public CustomerCharge CustomerCharge
    {
      get
      {
        return this._CustomerCharge;
      }
      set
      {
        this._CustomerCharge = value;
      }
    }

    public QuoteJob CurrentQuoteJob
    {
      get
      {
        return this._CurrentQuoteJob;
      }
      set
      {
        this._CurrentQuoteJob = value;
        if (this._CurrentQuoteJob == null)
        {
          this._CurrentQuoteJob = new QuoteJob();
          this._CurrentQuoteJob.Exists = false;
          this._CurrentQuoteJob.ScheduleOfRates = this.BuildUpScheduleOfRatesDataview();
        }
        this.dtpQuoteDate.Value = DateAndTime.Now;
        this.Loading = true;
        this.Populate(0);
        this.Loading = false;
        this.PartsAndProducts = this.CurrentQuoteJob.QuoteJobPartsAndProducts;
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
        this._AssetsTable.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblQuoteJobAssets.ToString();
        this._AssetsTable.AllowNew = false;
        this._AssetsTable.AllowEdit = false;
        this._AssetsTable.AllowDelete = false;
      }
    }

    public DataView PartsAndProducts
    {
      get
      {
        return this._PartsAndProducts;
      }
      set
      {
        this._PartsAndProducts = value;
        this._PartsAndProducts.Table.TableName = FSM.Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
        this._PartsAndProducts.AllowNew = false;
        this._PartsAndProducts.AllowEdit = false;
        this._PartsAndProducts.AllowDelete = false;
        this.dgPartsAndProducts.DataSource = (object) this.PartsAndProducts;
      }
    }

    private DataRow SelectedAssetDataRow
    {
      get
      {
        return (DataRow) null;
      }
    }

    private DataRow SelectedRatesDataRow
    {
      get
      {
        return this.dgScheduleOfRates.CurrentRowIndex != -1 ? this.CurrentQuoteJob.ScheduleOfRates[this.dgScheduleOfRates.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView JobItemsDataView
    {
      get
      {
        return this._JobItemsTable;
      }
      set
      {
        this._JobItemsTable = value;
        this._JobItemsTable.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblQuoteJobItem.ToString();
        this._JobItemsTable.AllowNew = false;
        this._JobItemsTable.AllowEdit = false;
        this._JobItemsTable.AllowDelete = false;
      }
    }

    private DataRow SelectedItemDataRow
    {
      get
      {
        return (DataRow) null;
      }
    }

    private bool Loading
    {
      get
      {
        return this._loading;
      }
      set
      {
        this._loading = value;
      }
    }

    public int PartProductID
    {
      get
      {
        return this._PartProductID;
      }
      set
      {
        this._PartProductID = value;
      }
    }

    public bool QuoteNumberUsed
    {
      get
      {
        return this._QuoteNumberUsed;
      }
      set
      {
        this._QuoteNumberUsed = value;
      }
    }

    public JobNumber QuoteNumber
    {
      get
      {
        return this._QuoteNumber;
      }
      set
      {
        this._QuoteNumber = value;
      }
    }

    public double TotalCosts
    {
      get
      {
        return this._TotalCosts;
      }
      set
      {
        this._TotalCosts = value;
      }
    }

    private void UCQuoteJob_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void txtPartsTotal_LostFocus(object sender, EventArgs e)
    {
      if (this.CurrentQuoteJob == null)
        return;
      this.WorkOutGrandTotal();
    }

    private void cboQuoteStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading | this.CurrentQuoteJob == null)
        return;
      if (!this.CurrentQuoteJob.Exists & (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteStatus)) == 70903 | Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteStatus)) == 70904))
      {
        int num = (int) App.ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ComboBox cboQuoteStatus = this.cboQuoteStatus;
        Combo.SetSelectedComboItem_By_Value(ref cboQuoteStatus, Conversions.ToString(Helper.MakeIntegerValid((object) FSM.Entity.Sys.Enums.QuoteContractStatus.Generated)));
        this.cboQuoteStatus = cboQuoteStatus;
      }
      else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteStatus)) == 70903)
      {
        this.QuoteJob_Create_InstallJob();
      }
      else
      {
        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteStatus)) != 70904)
          return;
        App.ShowForm(typeof (FRMQuoteRejection), true, new object[2]
        {
          (object) this,
          (object) ""
        }, false);
        this.Populate(this.CurrentQuoteJob.QuoteJobID);
      }
    }

    public string QuoteJob_Create_InstallJob()
    {
      switch ((MsgBoxResult) App.ShowMessage("You are converting this quote to a live job.\r\nDo you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case MsgBoxResult.Cancel:
          ComboBox cboQuoteStatus1 = this.cboQuoteStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboQuoteStatus1, Conversions.ToString(this.CurrentQuoteJob.StatusEnumID));
          this.cboQuoteStatus = cboQuoteStatus1;
          return "";
        case MsgBoxResult.Yes:
          if (!this.Save())
            return "";
          break;
        case MsgBoxResult.No:
          this.CurrentQuoteJob = App.DB.QuoteJob.Update(this.CurrentQuoteJob);
          return "";
      }
      this.Loading = true;
      string str1 = "";
      bool flag = false;
      List<int> intList = new List<int>();
      List<string> stringList = new List<string>();
      int PartID = 607573;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.PartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (current["Extra"].ToString().Contains("Rad:"))
            str1 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str1, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (current["Extra"].ToString().Replace("Rad: ", "") + " : "), current["Name"]), (object) ", ")));
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Supplier"], (object) "No Supplier", false))
            flag = true;
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["SupplierID"])))
          {
            intList.Add(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["SupplierID"])));
            if (!stringList.Contains(Conversions.ToString(current["Supplier"])))
              stringList.Add(Conversions.ToString(current["Supplier"]));
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (flag)
      {
        FRMGenDropBox frmGenDropBox1 = new FRMGenDropBox();
        DataTable table = App.DB.Supplier.Supplier_GetAll().Table;
        frmGenDropBox1.cbo2.Items.Clear();
        DataTable DT = new DataTable();
        DT.Columns.Add(new DataColumn("ValueMember"));
        DT.Columns.Add(new DataColumn("DisplayMember"));
        DT.Columns.Add(new DataColumn("Deleted"));
        IEnumerator enumerator2;
        try
        {
          enumerator2 = table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (intList.Contains(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["SupplierID"]))))
              DT.Rows.Add((object[]) new string[3]
              {
                Conversions.ToString(current["SupplierID"]),
                Conversions.ToString(current["Name"]),
                "0"
              });
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        FRMGenDropBox frmGenDropBox2 = frmGenDropBox1;
        ComboBox cbo2 = frmGenDropBox2.cbo2;
        Combo.SetUpCombo(ref cbo2, DT, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
        frmGenDropBox2.cbo2 = cbo2;
        frmGenDropBox1.cbo1.Visible = false;
        frmGenDropBox1.cbo2.Visible = true;
        frmGenDropBox1.lblTop.Text = "Please select the Supplier for specials";
        frmGenDropBox1.lblMiddle.Text = "";
        frmGenDropBox1.lblref.Text = "";
        frmGenDropBox1.txtref.Visible = false;
        int num1 = (int) frmGenDropBox1.ShowDialog();
        if (frmGenDropBox1.DialogResult == DialogResult.Cancel)
          return "";
        int integer1 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(frmGenDropBox1.cbo2));
        int integer2 = Conversions.ToInteger(App.DB.PartSupplier.Get_ByPartIDAndSupplierID(PartID, integer1).Table.Rows[0]["PartSupplierID"]);
        IEnumerator enumerator3;
        try
        {
          enumerator3 = this.PartsAndProducts.Table.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            DataRow current = (DataRow) enumerator3.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Supplier"], (object) "No Supplier", false))
            {
              current["PartSupplierID"] = (object) integer2;
              current["SpecialDescription"] = RuntimeHelpers.GetObjectValue(current["Name"]);
              current["SpecialCost"] = (object) 0.01;
            }
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
        string jobNumber = App.DB.Job.Job_Get_For_Quote_ID(this.CurrentQuoteJob.QuoteJobID)?.JobNumber;
        if (!string.IsNullOrEmpty(jobNumber))
        {
          int num2 = (int) Interaction.MsgBox((object) ("Quote has already been converted, Install JobNumber : " + jobNumber), MsgBoxStyle.OkOnly, (object) null);
          return jobNumber;
        }
        this.Save();
      }
      string str2 = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
      if (Helper.IsValidInteger((object) str2) && Helper.MakeIntegerValid((object) str2) <= 0)
      {
        int num = (int) Interaction.MsgBox((object) "Please select the department for the purchase", MsgBoxStyle.OkOnly, (object) null);
        return "";
      }
      if (this.txtElectricianCost.Text.Length < 1)
        this.txtElectricianCost.Text = "£0";
      string NotesToengineer = "" + "WHO SURVEYED JOB - " + this.txtSurveyor.Text + "\r\n" + "JOB LENGTH IN DAYS - " + this.txtInstallerLabourDays.Text + "\r\n" + "SUPPLIERS - " + string.Join(",", stringList.ToArray()) + "RADIATOR POSITIONS - " + str1 + "\r\n" + "ASBESTOS - " + Combo.get_GetSelectedItemDescription(this.cboAsbestos) + " : " + this.txtAsbestos.Text + "\r\n" + "ADDITIONAL JOB NOTES - " + this.txtInstallerNotes.Text + "\r\n" + "BUILDING WORK INVOLVED - " + this.txtBuilderNotes.Text + "\r\n" + "BUILDER ARRIVAL DAY / HOUR - " + this.txtBuilderArrivalDay.Text + "/" + this.txtBuilderArrivalHour.Text + "\r\n" + "ACCESS EQUIPTMENT REQUIRED - " + Combo.get_GetSelectedItemDescription(this.cboAccess) + "\r\n" + "ELECTRICIAN ARRIVAL DAY / HOUR - " + this.txtElectricianArrivalDay.Text + "/" + this.txtElectricianArrivalHour.Text + "\r\n" + "BALANCE ON COMPLETION - " + this.txtBOC.Text + "\r\n";
      string NotesToElectrician = "" + "ELECTRICIAN NOTES - " + this.txtElectricianNotes.Text + "\r\n" + "ELECTRICIAN PACK / LABOUR  - " + Combo.get_GetSelectedItemDescription(this.cboElectricalPack) + " / " + this.txtElectricianHours.Text + "HRS\r\n" + "ASBESTOS - " + Combo.get_GetSelectedItemDescription(this.cboAsbestos) + " : " + this.txtAsbestos.Text + "\r\n" + "ELECTRICIAN ARRIVAL DAY / HOUR - " + this.txtElectricianArrivalDay.Text + "/" + this.txtElectricianArrivalHour.Text + "\r\n" + "ELECTRICIAN COSTS - " + this.txtElectricianCost.Text + "\r\n";
      string NotesToBuilder = "" + "BUILDER NOTES - " + this.txtBuilderNotes.Text + "\r\n" + "BUILDER LABOUR  - " + this.txtBuilderHours.Text + "HRS\r\n" + "ASBESTOS - " + Combo.get_GetSelectedItemDescription(this.cboAsbestos) + " : " + this.txtAsbestos.Text + "\r\n" + "BUILDER ARRIVAL DAY / HOUR - " + this.txtBuilderArrivalDay.Text + "/" + this.txtBuilderArrivalHour.Text + "\r\n" + "ACCESS EQUIPTMENT REQUIRED - " + Combo.get_GetSelectedItemDescription(this.cboAccess) + "\r\n";
      if (this.txtBuilderArrivalDay.Text.Length == 0)
        this.txtBuilderArrivalDay.Text = "0";
      if (this.txtElectricianArrivalDay.Text.Length == 0)
        this.txtElectricianArrivalDay.Text = "0";
      bool Builder = Helper.MakeDoubleValid((object) this.txtBuilderCost.Text) > 0.0 | Helper.MakeIntegerValid((object) this.txtBuilderArrivalDay.Text) > 0;
      bool Electrician = Helper.MakeDoubleValid((object) this.txtElectricianCost.Text) > 0.0 | Helper.MakeIntegerValid((object) this.txtElectricianArrivalDay.Text) > 0;
      string jobNumber1 = App.DB.Job.Job_Get_For_Quote_ID(this.CurrentQuoteJob.QuoteJobID)?.JobNumber;
      if (!string.IsNullOrEmpty(jobNumber1))
      {
        int num = (int) Interaction.MsgBox((object) ("Quote has already been converted, Install JobNumber : " + jobNumber1), MsgBoxStyle.OkOnly, (object) null);
        return jobNumber1;
      }
      string install = App.DB.QuoteJob.QuoteJob_Create_Install(this.CurrentQuoteJob.SiteID, this.txtSurveyor.Text, NotesToengineer, NotesToBuilder, NotesToElectrician, Combo.get_GetSelectedItemValue(this.cboDept), this.CurrentQuoteJob.QuoteJobID, Electrician, Builder, this.chkService.Checked, this.chkHOver.Checked, Helper.MakeDoubleValid((object) this.txtElectricianCost.Text), Helper.MakeDoubleValid((object) this.txtBuilderCost.Text));
      ComboBox cboQuoteStatus2 = this.cboQuoteStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboQuoteStatus2, Conversions.ToString(70903));
      this.cboQuoteStatus = cboQuoteStatus2;
      this.Loading = false;
      this.Save();
      this.Populate(this.CurrentQuoteJob.QuoteJobID);
      int num3 = (int) Interaction.MsgBox((object) ("Quote Successfully Converted, Install JobNumber : C" + install), MsgBoxStyle.OkOnly, (object) null);
      return "C" + install;
    }

    private void btnFindPart_Click(object sender, EventArgs e)
    {
      FRMFindPart frmFindPart = (FRMFindPart) App.checkIfExists(typeof (FRMFindPart).Name, true) ?? (FRMFindPart) Activator.CreateInstance(typeof (FRMFindPart));
      frmFindPart.ShowInTaskbar = false;
      frmFindPart.TableToSearch = FSM.Entity.Sys.Enums.TableNames.NOT_IN_Database_tblPartSupplierQty;
      int num1 = (int) frmFindPart.ShowDialog();
      if (frmFindPart.DialogResult != DialogResult.OK)
        return;
      DataRow[] datarows = frmFindPart.Datarows;
      int index = 0;
      while (index < datarows.Length)
      {
        DataRow dataRow = datarows[index];
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["IsPartPack"])))
        {
          int SupplierID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["SupplierID"]));
          int PackID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["PartID"]));
          DataView dataView = App.DB.Part.PartPack_Get(PackID);
          int integer = Conversions.ToInteger(dataRow["Qty"]);
          IEnumerator enumerator;
          try
          {
            enumerator = dataView.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator.Current;
              DataRow row = this.CurrentQuoteJob.QuoteJobPartsAndProducts.Table.NewRow();
              int PartID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["PartID"]));
              DataView partIdAndSupplierId = App.DB.PartSupplier.Get_ByPartIDAndSupplierID(PartID, SupplierID);
              row["SellPrice"] = (object) 0.0;
              row["Extra"] = (object) "";
              row["ID"] = RuntimeHelpers.GetObjectValue(current["PartID"]);
              row["Number"] = RuntimeHelpers.GetObjectValue(current["PartNumber"]);
              row["PartSupplierID"] = RuntimeHelpers.GetObjectValue(partIdAndSupplierId[0]["PartSupplierID"]);
              row["Name"] = RuntimeHelpers.GetObjectValue(current["PartName"]);
              row["Quantity"] = Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Qty"], (object) integer);
              row["BuyPrice"] = RuntimeHelpers.GetObjectValue(partIdAndSupplierId[0]["Price"]);
              row["Total"] = Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(row["Quantity"], row["BuyPrice"]);
              row["Type"] = (object) "Part";
              row["Supplier"] = RuntimeHelpers.GetObjectValue(partIdAndSupplierId[0]["SupplierName"]);
              this.CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        else
        {
          DataRow row = this.CurrentQuoteJob.QuoteJobPartsAndProducts.Table.NewRow();
          row["SellPrice"] = (object) 0.0;
          row["Extra"] = (object) "";
          row["ID"] = RuntimeHelpers.GetObjectValue(dataRow["PartID"]);
          row["Number"] = RuntimeHelpers.GetObjectValue(dataRow["PartNumber"]);
          row["PartSupplierID"] = RuntimeHelpers.GetObjectValue(dataRow["PartSupplierID"]);
          row["Name"] = RuntimeHelpers.GetObjectValue(dataRow["PartName"]);
          row["Quantity"] = RuntimeHelpers.GetObjectValue(dataRow["Qty"]);
          row["BuyPrice"] = RuntimeHelpers.GetObjectValue(dataRow["Price"]);
          row["Total"] = Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(row["Quantity"], row["BuyPrice"]);
          row["Type"] = (object) "Part";
          row["Supplier"] = RuntimeHelpers.GetObjectValue(dataRow["SupplierName"]);
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["IsSpecialPart"], (object) 1, false))
          {
            FRMSpecialOrder frmSpecialOrder = new FRMSpecialOrder(0, 0.0, 0);
            int num2 = (int) frmSpecialOrder.ShowDialog();
            if (frmSpecialOrder.DialogResult == DialogResult.OK)
            {
              row["Quantity"] = (object) frmSpecialOrder.Quantity;
              row["BuyPrice"] = (object) frmSpecialOrder.Price;
              row["SpecialCost"] = (object) frmSpecialOrder.Price;
              row["Name"] = (object) frmSpecialOrder.PartName;
              row["SpecialDescription"] = (object) frmSpecialOrder.PartName;
              row["Number"] = (object) frmSpecialOrder.SPN;
              row["Extra"] = (object) frmSpecialOrder.SPN;
              row["Total"] = Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(row["Quantity"], row["BuyPrice"]);
            }
          }
          this.CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.Add(row);
        }
        checked { ++index; }
      }
      this.SetupPartsTotals();
    }

    private void btnSiteScheduleOfRates_Click(object sender, EventArgs e)
    {
      int siteId = this.CurrentQuoteJob.SiteID;
      QuoteJob currentQuoteJob;
      DataView scheduleOfRates = (currentQuoteJob = this.CurrentQuoteJob).ScheduleOfRates;
      ref DataView local = ref scheduleOfRates;
      FRMSiteScheduleOfRateList scheduleOfRateList1 = new FRMSiteScheduleOfRateList(siteId, ref local, true, false);
      currentQuoteJob.ScheduleOfRates = scheduleOfRates;
      using (FRMSiteScheduleOfRateList scheduleOfRateList2 = scheduleOfRateList1)
      {
        int num = (int) scheduleOfRateList2.ShowDialog();
      }
      this.dgScheduleOfRates.DataSource = (object) this.CurrentQuoteJob.ScheduleOfRates;
      this.SetupSORTotals();
    }

    private void btnRemovePartProduct_Click(object sender, EventArgs e)
    {
      if (this.dgPartsAndProducts.CurrentRowIndex > -1)
      {
        this.CurrentQuoteJob.QuoteJobPartsAndProducts.Table.AcceptChanges();
        this.CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.RemoveAt(this.dgPartsAndProducts.CurrentRowIndex);
        this.SetupPartsTotals();
      }
      else
      {
        int num = (int) App.ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      bool flag = true;
      string str = "";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboScheduleOfRatesCategoryID)) <= 0.0)
      {
        str = "* Category is missing\r\n";
        flag = false;
      }
      if (this.txtDescription.Text.Trim().Length == 0)
      {
        str += "* Description is missing\r\n";
        flag = false;
      }
      if (this.txtPrice.Text.Trim().Length == 0)
      {
        str += "* Price is missing\r\n";
        flag = false;
      }
      else if (!Versioned.IsNumeric((object) this.txtPrice.Text))
      {
        str += "* Price must be numeric\r\n";
        flag = false;
      }
      if (this.txtQuantity.Text.Trim().Length == 0)
      {
        str += "* Quantity is missing\r\n";
        flag = false;
      }
      else if (!Versioned.IsNumeric((object) this.txtQuantity.Text))
      {
        str += "* Quantity must be numeric\r\n";
        flag = false;
      }
      if (flag)
      {
        CustomerScheduleOfRate customerScheduleOfRate = App.DB.CustomerScheduleOfRate.Insert(new CustomerScheduleOfRate()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetScheduleOfRatesCategoryID = (object) Combo.get_GetSelectedItemValue(this.cboScheduleOfRatesCategoryID),
          SetCode = (object) this.txtCode.Text,
          SetDescription = (object) this.txtDescription.Text,
          SetPrice = (object) this.txtPrice.Text,
          SetTimeInMins = (object) this.txtTimeInMins.Text
        });
        App.DB.CustomerScheduleOfRate.Delete(customerScheduleOfRate.CustomerScheduleOfRateID);
        DataRow row = this.CurrentQuoteJob.ScheduleOfRates.Table.NewRow();
        row["RateID"] = (object) customerScheduleOfRate.CustomerScheduleOfRateID;
        row["ScheduleOfRatesCategoryID"] = (object) customerScheduleOfRate.ScheduleOfRatesCategoryID;
        row["Category"] = (object) Combo.get_GetSelectedItemDescription(this.cboScheduleOfRatesCategoryID);
        row["Code"] = (object) customerScheduleOfRate.Code;
        row["Description"] = (object) customerScheduleOfRate.Description;
        row["Price"] = (object) customerScheduleOfRate.Price;
        row["TimeInMins"] = (object) customerScheduleOfRate.TimeInMins;
        row["Quantity"] = (object) this.txtQuantity.Text;
        row["Total"] = (object) (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["Price"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["Quantity"])));
        this.CurrentQuoteJob.ScheduleOfRates.Table.Rows.Add(row);
        ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
        Combo.SetSelectedComboItem_By_Value(ref ofRatesCategoryId, "0");
        this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
        this.txtCode.Text = "";
        this.txtDescription.Text = "";
        this.txtPrice.Text = "";
        this.txtQuantity.Text = "";
        this.txtTimeInMins.Text = "";
        this.dgScheduleOfRates.DataSource = (object) this.CurrentQuoteJob.ScheduleOfRates;
        this.SetupSORTotals();
      }
      else
      {
        int num = (int) MessageBox.Show("Please correct the following:\r\n" + str, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.SelectedRatesDataRow == null)
        return;
      if (MessageBox.Show(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE :", this.SelectedRatesDataRow["Description"])), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        this.CurrentQuoteJob.ScheduleOfRates.Table.Rows.Remove(this.SelectedRatesDataRow);
        this.SetupSORTotals();
      }
    }

    private void btnAddToJobItems_Click(object sender, EventArgs e)
    {
      if (this.SelectedRatesDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select rate to add description to job item list", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this.JobItemsDataView.Table.AcceptChanges();
        DataRow row = this.JobItemsDataView.Table.NewRow();
        row["Summary"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedRatesDataRow["Description"]));
        row["RateID"] = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedRatesDataRow["RateID"]));
        row["Qty"] = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.SelectedRatesDataRow["Quantity"]));
        this.JobItemsDataView.Table.Rows.Add(row);
      }
    }

    public void SetupPartsAndProductsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgPartsAndProducts, false);
      DataGridTableStyle tableStyle = this.dgPartsAndProducts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Number";
      dataGridLabelColumn1.MappingName = "number";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 160;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Qty";
      dataGridLabelColumn3.MappingName = "quantity";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 50;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Buy Price";
      dataGridLabelColumn4.MappingName = "BuyPrice";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Extra";
      dataGridLabelColumn5.MappingName = "Extra";
      dataGridLabelColumn5.ReadOnly = false;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Supplier";
      dataGridLabelColumn6.MappingName = "Supplier";
      dataGridLabelColumn6.ReadOnly = false;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      this.dgPartsAndProducts.TableStyles.Add(tableStyle);
    }

    public void SetupScheduleOfRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgScheduleOfRates, false);
      DataGridTableStyle tableStyle = this.dgScheduleOfRates.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 90;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Code";
      dataGridLabelColumn2.MappingName = "Code";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Time";
      dataGridLabelColumn4.MappingName = "TimeInMins";
      dataGridLabelColumn4.ReadOnly = false;
      dataGridLabelColumn4.Width = 50;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Unit Price";
      dataGridLabelColumn5.MappingName = "Price";
      dataGridLabelColumn5.ReadOnly = false;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Unit Qty";
      dataGridLabelColumn6.MappingName = "Quantity";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Total";
      dataGridLabelColumn7.MappingName = "Total";
      dataGridLabelColumn7.ReadOnly = false;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
      this.dgScheduleOfRates.TableStyles.Add(tableStyle);
    }

    private void WorkOutGrandTotal()
    {
      this.txtPartsCost.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtPartsCost.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtPartsCost.Text.Trim().Replace("£", "")) ? Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) this.txtPartsCost.Text.Trim().Replace("£", "")), "C") : "£0.00") : "£0.00";
      this.txtPartsProductsMarkup.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtPartsProductsMarkup.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtPartsProductsMarkup.Text.Trim().Replace("%", "")) ? this.txtPartsProductsMarkup.Text.Trim().Replace("%", "") + "%" : "0%") : "0%";
      this.txtScheduleRatesCost.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtScheduleRatesCost.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtScheduleRatesCost.Text.Trim().Replace("£", "")) ? Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) this.txtScheduleRatesCost.Text.Trim().Replace("£", "")), "C") : "£0.00") : "£0.00";
      this.txtScheduleRateMarkup.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtScheduleRateMarkup.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtScheduleRateMarkup.Text.Trim().Replace("%", "")) ? this.txtScheduleRateMarkup.Text.Trim().Replace("%", "") + "%" : "0%") : "0%";
      this.txtInstallerCost.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtInstallerCost.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtInstallerCost.Text.Trim().Replace("£", "")) ? Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) this.txtInstallerCost.Text.Trim().Replace("£", "")), "C") : "£0.00") : "£0.00";
      this.txtInstallerMarkup.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtInstallerMarkup.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtInstallerMarkup.Text.Trim().Replace("%", "")) ? this.txtInstallerMarkup.Text.Trim().Replace("%", "") + "%" : "0%") : "0%";
      this.txtBuilderCost.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtBuilderCost.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtBuilderCost.Text.Trim().Replace("£", "")) ? Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) this.txtBuilderCost.Text.Trim().Replace("£", "")), "C") : "£0.00") : "£0.00";
      this.txtBuilderMarkup.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtBuilderMarkup.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtBuilderMarkup.Text.Trim().Replace("%", "")) ? this.txtBuilderMarkup.Text.Trim().Replace("%", "") + "%" : "0%") : "0%";
      this.txtElectricianCost.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtElectricianCost.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtElectricianCost.Text.Trim().Replace("£", "")) ? Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) this.txtElectricianCost.Text.Trim().Replace("£", "")), "C") : "£0.00") : "£0.00";
      this.txtElectricianMarkup.Text = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtElectricianMarkup.Text, "", false) != 0 ? (Versioned.IsNumeric((object) this.txtElectricianMarkup.Text.Trim().Replace("%", "")) ? this.txtElectricianMarkup.Text.Trim().Replace("%", "") + "%" : "0%") : "0%";
      double num1 = Helper.MakeDoubleValid((object) this.txtPartsCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) (Conversions.ToDouble(this.txtPartsCost.Text.Replace("£", "")) / 100.0)) * Helper.MakeDoubleValid((object) this.txtPartsProductsMarkup.Text.Replace("%", ""));
      this.txtPartsCostTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num1, "C");
      double num2 = Helper.MakeDoubleValid((object) this.txtScheduleRatesCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) (Conversions.ToDouble(this.txtScheduleRatesCost.Text.Replace("£", "")) / 100.0)) * Helper.MakeDoubleValid((object) this.txtScheduleRateMarkup.Text.Replace("%", ""));
      this.txtScheduleRatesCostTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num2, "C");
      this.txtInstallerCharge.Text = Microsoft.VisualBasic.Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtInstallerCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) (Conversions.ToDouble(this.txtInstallerCost.Text.Replace("£", "")) / 100.0)) * Helper.MakeDoubleValid((object) this.txtInstallerMarkup.Text.Replace("%", ""))), "C");
      this.txtBuilderCharge.Text = Microsoft.VisualBasic.Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtBuilderCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) (Conversions.ToDouble(this.txtBuilderCost.Text.Replace("£", "")) / 100.0)) * Helper.MakeDoubleValid((object) this.txtBuilderMarkup.Text.Replace("%", ""))), "C");
      double num3 = Helper.MakeDoubleValid((object) this.txtElectricianCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) (Conversions.ToDouble(this.txtElectricianCost.Text.Replace("£", "")) / 100.0)) * Helper.MakeDoubleValid((object) this.txtElectricianMarkup.Text.Replace("%", ""));
      this.txtElectricianCharge.Text = Microsoft.VisualBasic.Strings.Format((object) num3, "C");
      double num4 = Helper.MakeDoubleValid((object) this.txtAccess.Text.Replace("£", ""));
      if (this.chkSORCharge.Checked)
      {
        this.txtInstallerCharge.Text = Conversions.ToString(0);
        this.txtElectricianCharge.Text = Conversions.ToString(0);
        this.txtBuilderCharge.Text = Conversions.ToString(0);
        this.txtPartsCostTotal.Text = Conversions.ToString(0);
        num4 = 0.0;
      }
      else
        this.txtScheduleRatesCostTotal.Text = Conversions.ToString(0);
      double num5 = Helper.MakeDoubleValid((object) this.txtPartsCostTotal.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtScheduleRatesCostTotal.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtInstallerCharge.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtElectricianCharge.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtBuilderCharge.Text.Replace("£", "")) + num4;
      this.txtGrandTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num5, "C");
      if (this.CurrentQuoteJob != null)
      {
        QuoteJob currentQuoteJob = this.CurrentQuoteJob;
        currentQuoteJob.SetPartsAndProductsTotal = (object) num1;
        currentQuoteJob.SetScheduleOfRatesTotal = (object) num2;
        currentQuoteJob.SetScheduleOfRatesTotal = (object) num3;
        currentQuoteJob.SetGrandTotal = (object) num5;
      }
      this.TotalCosts = Helper.MakeDoubleValid((object) this.txtBuilderCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtElectricianCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtInstallerCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtPartsCost.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtAccess.Text.Replace("£", ""));
      this.txtTotalCosts.Text = Microsoft.VisualBasic.Strings.Format((object) this.TotalCosts, "C");
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVAT)) <= 0.0)
        return;
      double vatRate = App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVAT))).VATRate;
      this.txtProfitPound.Text = Microsoft.VisualBasic.Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtGrandTotal.Text.Replace("£", "")) - this.TotalCosts), "C");
      this.txtProfitPerc.Text = Conversions.ToString(Math.Round(Helper.MakeDoubleValid((object) this.txtProfitPound.Text) / Helper.MakeDoubleValid((object) this.txtGrandTotal.Text.Replace("£", "")) * 100.0, 2)) + "%";
      this.txtGrandTotal.Text = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) this.txtGrandTotal.Text.Replace("£", "")), "C");
      this.txtincVAT.Text = Microsoft.VisualBasic.Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtGrandTotal.Text.Replace("£", "")) * (1.0 + vatRate / 100.0)), "C");
      this.txtBOC.Text = Microsoft.VisualBasic.Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtGrandTotal.Text.Replace("£", "")) * (1.0 + vatRate / 100.0) - Helper.MakeDoubleValid((object) this.txtDeposit.Text.Replace("£", ""))), "C");
    }

    void IUserControl.Populate(int ID = 0)
    {
      this.JobItemsDataView = new DataView(new DataTable()
      {
        Columns = {
          new DataColumn("Summary"),
          new DataColumn("RateID"),
          new DataColumn("Qty")
        }
      });
      if (this.CurrentQuoteJob.Exists)
      {
        if (this.CurrentQuoteJob.StatusEnumID == -1)
        {
          Helper.MakeReadOnly(this.grpJobItems, true);
          this.cboJobType.Enabled = false;
          this.txtReference.Enabled = false;
          this.dtpQuoteDate.Enabled = false;
          this.cboQuoteStatus.Enabled = false;
          this.grpParts.Enabled = false;
          this.grpRates.Enabled = false;
          this.grpTotals.Enabled = false;
        }
        else
        {
          Helper.MakeReadOnly(this.grpJobItems, false);
          this.cboJobType.Enabled = true;
          this.txtReference.Enabled = true;
          this.dtpQuoteDate.Enabled = true;
          this.cboQuoteStatus.Enabled = true;
          this.grpParts.Enabled = true;
          this.grpRates.Enabled = true;
          this.grpTotals.Enabled = true;
        }
        ComboBox cboJobType = this.cboJobType;
        Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(this.CurrentQuoteJob.JobTypeID));
        this.cboJobType = cboJobType;
        ComboBox cboQuoteStatus = this.cboQuoteStatus;
        Combo.SetSelectedComboItem_By_Value(ref cboQuoteStatus, Conversions.ToString(this.CurrentQuoteJob.StatusEnumID));
        this.cboQuoteStatus = cboQuoteStatus;
        this.txtReference.Text = this.CurrentQuoteJob.Reference;
        this.dtpQuoteDate.Value = this.CurrentQuoteJob.DateCreated;
        this.txtPartsCost.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.PartsCost, "C");
        this.txtPartsProductsMarkup.Text = Conversions.ToString(this.CurrentQuoteJob.PartsAndProductsMarkup) + "%";
        this.txtPartsCostTotal.Text = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) (this.CurrentQuoteJob.PartsCost + this.CurrentQuoteJob.PartsCost / 100.0 * Convert.ToDouble(this.CurrentQuoteJob.PartsAndProductsMarkup))), "C");
        this.dgScheduleOfRates.DataSource = (object) this.CurrentQuoteJob.ScheduleOfRates;
        this.txtScheduleRatesCost.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.ScheduleOfRatesTotal, "C");
        this.txtScheduleRateMarkup.Text = Conversions.ToString(this.CurrentQuoteJob.ScheduleOfRatesMarkup) + "%";
        this.txtScheduleRatesCostTotal.Text = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) Decimal.Add(this.CurrentQuoteJob.ScheduleOfRatesTotal, Decimal.Multiply(Decimal.Divide(this.CurrentQuoteJob.ScheduleOfRatesTotal, new Decimal(100L)), this.CurrentQuoteJob.ScheduleOfRatesMarkup))), "C");
        this.txtElectricianCost.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.ElectricianCost, "C");
        this.txtElectricianMarkup.Text = Conversions.ToString(this.CurrentQuoteJob.ElectricianMarkUp) + "%";
        this.txtElectricianCharge.Text = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) (Helper.MakeDoubleValid((object) this.txtElectricianCost.Text) + Helper.MakeDoubleValid((object) this.txtElectricianCost.Text) / 100.0 * this.CurrentQuoteJob.ElectricianMarkUp)), "C");
        this.txtInstallerCost.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.EngineerCost, "C");
        this.txtInstallerMarkup.Text = Conversions.ToString(this.CurrentQuoteJob.EngineerMarkUp) + "%";
        this.txtInstallerCharge.Text = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) (this.CurrentQuoteJob.EngineerCost + this.CurrentQuoteJob.EngineerCost / 100.0 * this.CurrentQuoteJob.EngineerMarkUp)), "C");
        this.txtBuilderCost.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.BuilderCost, "C");
        this.txtBuilderMarkup.Text = Conversions.ToString(this.CurrentQuoteJob.BuilderMarkUp) + "%";
        this.txtBuilderCharge.Text = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid((object) (this.CurrentQuoteJob.BuilderCost + this.CurrentQuoteJob.BuilderCost / 100.0 * this.CurrentQuoteJob.BuilderMarkUp)), "C");
        this.chkSORCharge.Checked = this.CurrentQuoteJob.SORCharge != 0.0;
        ComboBox combo = this.cboVAT;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentQuoteJob.VatRateID));
        this.cboVAT = combo;
        combo = this.cboElectricalPack;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentQuoteJob.ElectricianPackTypeID));
        this.cboElectricalPack = combo;
        this.txtAccess.Text = Conversions.ToString(this.CurrentQuoteJob.AdditionalCosts);
        this.txtInstallerNotes.Text = this.CurrentQuoteJob.NotesToEngineer;
        this.txtInstallerLabourDays.Text = Conversions.ToString(this.CurrentQuoteJob.EngineerLabourHrs);
        combo = this.cboAsbestos;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentQuoteJob.AsbestosID));
        this.cboAsbestos = combo;
        this.txtAsbestos.Text = this.CurrentQuoteJob.AsbestosComment;
        combo = this.cboAccess;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentQuoteJob.AccessEquipmentID));
        this.cboAccess = combo;
        this.txtElectricianHours.Text = Conversions.ToString(this.CurrentQuoteJob.ElectricianLabourHrs);
        this.txtElectricianArrivalDay.Text = Conversions.ToString(this.CurrentQuoteJob.ElectricianArrivalDayNo);
        this.txtElectricianArrivalHour.Text = Conversions.ToString(this.CurrentQuoteJob.ElectricianArrivalHour);
        this.txtElectricianNotes.Text = this.CurrentQuoteJob.NotesToElectrician;
        this.txtBuilderHours.Text = Conversions.ToString(this.CurrentQuoteJob.BuilderLabourHrs);
        this.txtBuilderArrivalDay.Text = Conversions.ToString(this.CurrentQuoteJob.BuilderArrivalDayNo);
        this.txtBuilderArrivalHour.Text = Conversions.ToString(this.CurrentQuoteJob.BuilderArrivalHour);
        this.txtBuilderNotes.Text = this.CurrentQuoteJob.NotesToBuilder;
        this.txtOriginalQuote.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.OriginalQuotedAmount, "C");
        this.TotalCosts = this.CurrentQuoteJob.BuilderCost + this.CurrentQuoteJob.ElectricianCost + this.CurrentQuoteJob.EngineerCost + this.CurrentQuoteJob.PartsCost + this.CurrentQuoteJob.AdditionalCosts;
        this.txtTotalCosts.Text = Microsoft.VisualBasic.Strings.Format((object) this.TotalCosts, "C");
        this.txtDeposit.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.DepositAmount, "C");
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVAT)) > 0.0)
        {
          double vatRate = App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVAT))).VATRate;
          this.txtProfitPound.Text = Microsoft.VisualBasic.Strings.Format((object) (this.CurrentQuoteJob.QuotedAmount - this.TotalCosts), "C");
          this.txtProfitPerc.Text = Conversions.ToString(Math.Round(Helper.MakeDoubleValid((object) this.txtProfitPound.Text.Replace("£", "")) / this.CurrentQuoteJob.QuotedAmount * 100.0, 2)) + "%";
          this.txtGrandTotal.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.QuotedAmount, "C");
          this.txtincVAT.Text = Microsoft.VisualBasic.Strings.Format((object) (this.CurrentQuoteJob.QuotedAmount * (1.0 + vatRate / 100.0)), "C");
          this.txtBOC.Text = Microsoft.VisualBasic.Strings.Format((object) (this.CurrentQuoteJob.QuotedAmount * (1.0 + vatRate / 100.0) - this.CurrentQuoteJob.DepositAmount), "C");
        }
        if (DateTime.Compare(this.CurrentQuoteJob.EstStartDate, DateTime.MinValue) > 0)
        {
          this.lblNA.Visible = false;
          this.dtpestStartDate.Visible = true;
          this.dtpestStartDate.Value = this.CurrentQuoteJob.EstStartDate;
        }
        else
        {
          this.lblNA.Visible = true;
          this.dtpestStartDate.Visible = false;
        }
        try
        {
          EngineerVisit newAsObject = App.DB.EngineerVisits.EngineerVisits_Get_New_As_Object(this.CurrentQuoteJob.SurveyVisitID);
          this.txtSurveyor.Text = App.DB.Engineer.Engineer_Get(newAsObject.EngineerID).Name;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.txtSurveyor.Text = "N/A";
          ProjectData.ClearProjectError();
        }
        this.txtChangedDate.Text = this.CurrentQuoteJob.ChangedDateTime.ToString("dd/MM/yyyy");
        this.txtChangedBy.Text = App.DB.User.Get(this.CurrentQuoteJob.ChangedByUserID, false).Fullname;
        ComboBox cboDept = this.cboDept;
        Combo.SetSelectedComboItem_By_Value(ref cboDept, this.CurrentQuoteJob.Department.Trim());
        this.cboDept = cboDept;
      }
      else
      {
        this.txtInstallerCost.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtElectricianCost.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtBuilderCost.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtGrandTotal.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtDeposit.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtPartsCost.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtBOC.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtScheduleRatesCost.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtProfitPound.Text = Microsoft.VisualBasic.Strings.Format((object) 0, "C");
        this.txtOriginalQuote.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentQuoteJob.OriginalQuotedAmount, "C");
        this.CurrentQuoteJob.QuoteJobPartsAndProducts = App.DB.QuoteJob.Get_Parts_And_Products_For_QuoteJobID(this.CurrentQuoteJob.QuoteJobID);
      }
      // ISSUE: reference to a compiler-generated field
      UCQuoteJob.RefreshButtonEventHandler refreshButtonEvent = this.RefreshButtonEvent;
      if (refreshButtonEvent == null)
        return;
      refreshButtonEvent();
    }

    public void LoadDepartment()
    {
      string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
      if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) > 0)
      {
        List<CostCentre> source = App.DB.CostCentre.Get(this.CurrentQuoteJob?.JobTypeID.Value, this.CurrentSite?.CustomerID.Value, FSM.Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId);
        CostCentre costCentre = source != null ? source.FirstOrDefault<CostCentre>() : (CostCentre) null;
        ComboBox cboDept = this.cboDept;
        Combo.SetSelectedComboItem_By_Value(ref cboDept, Conversions.ToString(costCentre?.Name.Value));
        this.cboDept = cboDept;
      }
      else
      {
        if (Versioned.IsNumeric((object) str))
          return;
        List<CostCentre> source = App.DB.CostCentre.Get(this.CurrentQuoteJob?.JobTypeID.Value, this.CurrentSite?.CustomerID.Value, FSM.Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId);
        CostCentre costCentre = source != null ? source.FirstOrDefault<CostCentre>() : (CostCentre) null;
        ComboBox cboDept = this.cboDept;
        Combo.SetSelectedComboItem_By_Value(ref cboDept, Helper.MakeStringValid((object) costCentre?.Name));
        this.cboDept = cboDept;
      }
    }

    private void SetupPartsTotals()
    {
      double num = 0.0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          num = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Quantity"], current["BuyPrice"])));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.CurrentQuoteJob.SetPartsAndProductsTotal = (object) num;
      this.txtPartsCost.Text = Microsoft.VisualBasic.Strings.Format((object) num, "C");
      this.WorkOutGrandTotal();
    }

    private void SetupSORTotals()
    {
      double num = 0.0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.CurrentQuoteJob.ScheduleOfRates.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          num = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num, current["Total"]));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.CurrentQuoteJob.SetScheduleOfRatesTotal = (object) num;
      this.txtScheduleRatesCost.Text = Microsoft.VisualBasic.Strings.Format((object) num, "C");
      this.WorkOutGrandTotal();
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentQuoteJob.IgnoreExceptionsOnSetMethods = true;
        this.CurrentQuoteJob.SetJobDefinitionEnumID = (object) Helper.MakeIntegerValid((object) FSM.Entity.Sys.Enums.JobDefinition.Quoted);
        this.CurrentQuoteJob.SetJobTypeID = (object) Combo.get_GetSelectedItemValue(this.cboJobType);
        this.CurrentQuoteJob.SetStatusEnumID = (object) Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboQuoteStatus));
        this.CurrentQuoteJob.SetReference = (object) this.txtReference.Text.Trim();
        this.CurrentQuoteJob.DateCreated = this.dtpQuoteDate.Value;
        this.CurrentQuoteJob.SetPartsAndProductsTotal = (object) this.txtPartsCost.Text.Trim().Replace("£", "");
        this.CurrentQuoteJob.SetPartsAndProductsMarkup = (object) this.txtPartsProductsMarkup.Text.Trim().Replace("%", "");
        this.CurrentQuoteJob.SetGrandTotal = (object) this.txtBOC.Text.Trim().Replace("£", "");
        this.CurrentQuoteJob.SetScheduleOfRatesMarkup = (object) this.txtScheduleRateMarkup.Text.Trim().Replace("%", "");
        this.CurrentQuoteJob.SetScheduleOfRatesTotal = (object) this.txtScheduleRatesCost.Text.Trim().Replace("£", "");
        this.CurrentQuoteJob.SetMileageRate = (object) 0;
        this.CurrentQuoteJob.SetEstimatedMileage = (object) 0;
        this.CurrentQuoteJob.SetNotesToEngineer = (object) this.txtInstallerNotes.Text;
        this.CurrentQuoteJob.SetNotesToElectrician = (object) this.txtElectricianNotes.Text;
        this.CurrentQuoteJob.SetNotesToBuilder = (object) this.txtBuilderNotes.Text;
        this.CurrentQuoteJob.SetEngineerLabourHrs = (object) Helper.MakeDoubleValid((object) this.txtInstallerLabourDays.Text);
        this.CurrentQuoteJob.SetElectricianLabourHrs = (object) Helper.MakeDoubleValid((object) this.txtElectricianHours.Text);
        this.CurrentQuoteJob.SetBuilderLabourHrs = (object) Helper.MakeDoubleValid((object) this.txtBuilderHours.Text);
        this.CurrentQuoteJob.SetEngineerMarkUp = (object) Helper.MakeDoubleValid((object) this.txtInstallerMarkup.Text.Replace("%", ""));
        this.CurrentQuoteJob.SetElectricianMarkUp = (object) Helper.MakeDoubleValid((object) this.txtElectricianMarkup.Text.Replace("%", ""));
        this.CurrentQuoteJob.SetBuilderMarkUp = (object) Helper.MakeDoubleValid((object) this.txtBuilderMarkup.Text.Replace("%", ""));
        this.CurrentQuoteJob.SetElectricianArrivalDayNo = (object) Helper.MakeIntegerValid((object) this.txtElectricianArrivalDay.Text);
        this.CurrentQuoteJob.SetElectricianArrivalHour = (object) Helper.MakeIntegerValid((object) this.txtElectricianArrivalHour.Text);
        this.CurrentQuoteJob.SetBuilderArrivalDayNo = (object) Helper.MakeIntegerValid((object) this.txtBuilderArrivalDay.Text);
        this.CurrentQuoteJob.SetBuilderArrivalHour = (object) Helper.MakeIntegerValid((object) this.txtBuilderArrivalHour.Text);
        this.CurrentQuoteJob.SetPartsCost = (object) Helper.MakeDoubleValid((object) this.txtPartsCost.Text);
        this.CurrentQuoteJob.SetEngineerCost = (object) Helper.MakeDoubleValid((object) this.txtInstallerCost.Text);
        this.CurrentQuoteJob.SetBuilderCost = (object) Helper.MakeDoubleValid((object) this.txtBuilderCost.Text);
        this.CurrentQuoteJob.SetElectricianCost = (object) Helper.MakeDoubleValid((object) this.txtElectricianCost.Text);
        this.CurrentQuoteJob.SetQuotedAmount = (object) Helper.MakeDoubleValid((object) this.txtGrandTotal.Text);
        this.CurrentQuoteJob.SetDepositAmount = (object) Helper.MakeDoubleValid((object) this.txtDeposit.Text);
        this.CurrentQuoteJob.SetVatRateID = (object) Combo.get_GetSelectedItemValue(this.cboVAT);
        this.CurrentQuoteJob.ChangedDateTime = DateAndTime.Now;
        this.CurrentQuoteJob.SetChangedByUserID = (object) App.loggedInUser.UserID;
        this.CurrentQuoteJob.SetOriginalQuotedAmount = (object) this.CurrentQuoteJob.OriginalQuotedAmount;
        this.CurrentQuoteJob.SetElectricianPackTypeID = (object) Combo.get_GetSelectedItemValue(this.cboElectricalPack);
        this.CurrentQuoteJob.SetSORCharge = (object) this.chkSORCharge.Checked;
        this.CurrentQuoteJob.SetAccessEquipmentID = (object) Combo.get_GetSelectedItemValue(this.cboAccess);
        this.CurrentQuoteJob.SetAsbestosID = (object) Combo.get_GetSelectedItemValue(this.cboAsbestos);
        this.CurrentQuoteJob.SetAdditionalCosts = (object) Helper.MakeDoubleValid((object) this.txtAccess.Text);
        this.CurrentQuoteJob.SetAsbestosComment = (object) this.txtAsbestos.Text;
        this.CurrentQuoteJob.EstStartDate = Helper.MakeDateTimeValid((object) this.dtpQuoteDate.Value);
        this.CurrentQuoteJob.SetSurveyVisitID = (object) this.CurrentQuoteJob.SurveyVisitID;
        this.CurrentQuoteJob.SetDepartment = (object) Combo.get_GetSelectedItemValue(this.cboDept);
        this.CurrentQuoteJob.QuoteAssets.Clear();
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.AssetsDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Conversions.ToBoolean(current["Tick"]))
              this.CurrentQuoteJob.QuoteAssets.Add((object) new QuoteJobAsset()
              {
                SetAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["AssetID"]))
              });
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        QuoteJobOfWork quoteJobOfWork;
        if (this.CurrentQuoteJob.QuoteJobOfWorks.Count > 0)
        {
          quoteJobOfWork = (QuoteJobOfWork) this.CurrentQuoteJob.QuoteJobOfWorks[0];
          quoteJobOfWork.QuoteJobItems.Clear();
        }
        else
          quoteJobOfWork = new QuoteJobOfWork();
        quoteJobOfWork.IgnoreExceptionsOnSetMethods = true;
        this.CurrentQuoteJob.QuoteJobOfWorks.Clear();
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.CurrentQuoteJob.ScheduleOfRates.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            QuoteJobItem quoteJobItem = new QuoteJobItem();
            quoteJobItem.IgnoreExceptionsOnSetMethods = true;
            quoteJobItem.SetSummary = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Description"]));
            quoteJobItem.SetRateID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["RateID"]));
            if (current.Table.Columns.Contains("SystemLinkID"))
              quoteJobItem.SetSystemLinkID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["SystemLinkID"]));
            quoteJobItem.SetQty = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Quantity"]));
            quoteJobOfWork.QuoteJobItems.Add((object) quoteJobItem);
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        this.CurrentQuoteJob.QuoteJobOfWorks.Add((object) quoteJobOfWork);
        new QuoteJobValidator().Validate(this.CurrentQuoteJob, this.JobItemsDataView);
        if (this.CurrentQuoteJob.Exists)
        {
          this.CurrentQuoteJob = App.DB.QuoteJob.Update(this.CurrentQuoteJob);
        }
        else
        {
          this.CurrentQuoteJob = App.DB.QuoteJob.Insert(this.CurrentQuoteJob);
          this.QuoteNumberUsed = true;
          int num = (int) App.ShowMessage("Quote added : " + this.CurrentQuoteJob.Reference, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentQuoteJob.QuoteJobID);
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

    public void RejectReasonChanged(string Reason, int ReasonID)
    {
      this.CurrentQuoteJob.SetReasonForReject = (object) Reason;
      this.CurrentQuoteJob.SetReasonForRejectID = (object) ReasonID;
      this.Save();
    }

    private DataView BuildUpScheduleOfRatesDataview()
    {
      return new DataView(new DataTable()
      {
        Columns = {
          "ScheduleOfRatesCategoryID",
          "Category",
          "Code",
          "Description",
          {
            "Price",
            System.Type.GetType("System.Double")
          },
          {
            "Quantity",
            System.Type.GetType("System.Double")
          },
          {
            "Total",
            System.Type.GetType("System.Double")
          },
          {
            "RateID",
            System.Type.GetType("System.Int32")
          },
          {
            "TimeInMins",
            System.Type.GetType("System.Int32")
          }
        },
        TableName = FSM.Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString()
      });
    }

    private void cboElectricalPack_SelectedIndexChanged(object sender, EventArgs e)
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboElectricalPack);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0)
        this.txtElectricianCost.Text = Microsoft.VisualBasic.Strings.Format((object) (Helper.MakeDoubleValid((object) this.CurrentQuoteJob?.ElectricianLabourHrs) * 27.5), "C");
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        this.txtElectricianCost.Text = Microsoft.VisualBasic.Strings.Format((object) 100, "C");
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        this.txtElectricianCost.Text = Microsoft.VisualBasic.Strings.Format((object) 155, "C");
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        this.txtElectricianCost.Text = Microsoft.VisualBasic.Strings.Format((object) 500, "C");
      this.WorkOutGrandTotal();
    }

    private void chkSORCharge_CheckedChanged(object sender, EventArgs e)
    {
      this.WorkOutGrandTotal();
    }

    private void txtBuilderHours_TextChanged(object sender, EventArgs e)
    {
      try
      {
        this.txtBuilderCost.Text = Microsoft.VisualBasic.Strings.Format((object) (Math.Ceiling(Helper.MakeDoubleValid((object) this.txtBuilderHours.Text) / 8.0 / 0.5) * 0.5 * 200.0), "C");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.WorkOutGrandTotal();
    }

    private void txtGrandTotal_TextChanged(object sender, EventArgs e)
    {
    }

    private string EmailBody(DataTable dt)
    {
      string str = "<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns:m=\"http://schemas.microsoft.com/office/2004/12/omml\" xmlns=\"http://www.w3.org/TR/REC-html40\"><head><meta http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\"><meta name=Generator content=\"Microsoft Word 15 (filtered medium)\"><style><!--\r\n                        /* Font Definitions */\r\n                        @font-face\r\n                            {font-family:\"Cambria Math\";\r\n                            panose-1:2 4 5 3 5 4 6 3 2 4;}\r\n                        @font-face\r\n                            {font-family:Calibri;\r\n                            panose-1:2 15 5 2 2 2 4 3 2 4;}\r\n                        /* Style Definitions */\r\n                        p.MsoNormal, li.MsoNormal, div.MsoNormal\r\n                            {margin:0cm;\r\n                            margin-bottom:.0001pt;\r\n                            font-size:11.0pt;\r\n                            font-family:\"Calibri\",sans-serif;\r\n                            mso-fareast-language:EN-US;}\r\n                        a:link, span.MsoHyperlink\r\n                            {mso-style-priority:99;\r\n                            color:#0563C1;\r\n                            text-decoration:underline;}\r\n                        a:visited, span.MsoHyperlinkFollowed\r\n                            {mso-style-priority:99;\r\n                            color:#954F72;\r\n                            text-decoration:underline;}\r\n                        span.EmailStyle17\r\n                            {mso-style-type:personal-compose;\r\n                            font-family:\"Calibri\",sans-serif;\r\n                            color:windowtext;}\r\n                        .MsoChpDefault\r\n                            {mso-style-type:export-only;\r\n                            font-family:\"Calibri\",sans-serif;\r\n                            mso-fareast-language:EN-US;}\r\n                        @page WordSection1\r\n                            {size:612.0pt 792.0pt;\r\n                            margin:72.0pt 72.0pt 72.0pt 72.0pt;}\r\n                        div.WordSection1\r\n                            {page:WordSection1;}\r\n                        --></style><!--[if gte mso 9]><xml>\r\n                        <o:shapedefaults v:ext=\"edit\" spidmax=\"1026\" />\r\n                        </xml><![endif]--><!--[if gte mso 9]><xml>\r\n                        <o:shapelayout v:ext=\"edit\">\r\n                        <o:idmap v:ext=\"edit\" data=\"1\" />\r\n                        </o:shapelayout></xml><![endif]--></head><body lang=EN-GB link=\"#0563C1\" vlink=\"#954F72\">\r\n                        <div class=WordSection1><p class=MsoNormal>Dear Sir/Madam,<o:p></o:p></p>\r\n                        <p class=MsoNormal><o:p>&nbsp;</o:p></p>\r\n                        <table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 align=left width=799 style='width:599.15pt;border-collapse:collapse;margin-left:6.75pt;margin-right:6.75pt'>\r\n                        <tr style='height:15.0pt'>\r\n                        <td width=115 nowrap valign=bottom style='width:86.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>\r\n                        <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>\r\n                        <b><span style='color:black;mso-fareast-language:EN-GB'>SOR CODE<o:p></o:p></span></b></p>\r\n                        </td>\r\n                        <td width=487 nowrap valign=bottom style='width:365.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>\r\n                        <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Description<o:p></o:p></span></b></p>\r\n                        </td>\r\n                        <td width=64 nowrap valign=bottom style='width:48.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>\r\n                        <p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Qty<o:p></o:p></span></b></p>\r\n                        </td>\r\n                        <td width=70 nowrap valign=bottom style='width:52.15pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>\r\n                        <p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>UnitPrice<o:p></o:p></span></b></p>\r\n                        </td>\r\n                        <td width=64 nowrap valign=bottom style='width:70.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Line Total<o:p></o:p></span></b></p>\r\n                        </td>\r\n                        </tr>";
      IEnumerator enumerator;
      try
      {
        enumerator = dt.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "\r\n            <tr style='height:15.0pt'>\r\n            <td width=115 nowrap valign=bottom style='width:86.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>\r\n            <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>\r\n            <span style='color:black;mso-fareast-language:EN-GB'>", current["Code"]), (object) "<o:p></o:p></span></p>\r\n            </td>\r\n            <td width=487 nowrap valign=bottom style='width:365.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>\r\n            <span style='color:black;mso-fareast-language:EN-GB'>"), current["Description"]), (object) "<o:p></o:p>\r\n            </span></p>\r\n            </td>\r\n            <td width=64 nowrap valign=bottom style='width:48.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>\r\n            <span style='color:black;mso-fareast-language:EN-GB'>"), current["quantity"]), (object) "<o:p></o:p>\r\n            </span></p>\r\n            </td>\r\n            <td width=70 nowrap valign=bottom style='width:52.15pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>\r\n            <span style='color:black;mso-fareast-language:EN-GB'>£"), current["Price"]), (object) "<o:p></o:p></span>\r\n            </p></td>\r\n            <td width=64 nowrap valign=bottom style='width:55.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>\r\n            <span style='color:black;mso-fareast-language:EN-GB'>£"), current["Total"]), (object) "<o:p></o:p></span>\r\n            </p>\r\n            </td>\r\n            </tr>")));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return str + "</table>\r\n                <p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p>\r\n                <p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p>\r\n                <p class=MsoNormal><o:p></o:p></p></div>";
    }

    private void btnEmailSOR_Click(object sender, EventArgs e)
    {
      if (Helper.IsEmailValid(App.loggedInUser.EmailAddress))
      {
        string str = this.EmailBody(this.CurrentQuoteJob.ScheduleOfRates.Table);
        new Emails()
        {
          Body = str,
          From = EmailAddress.FSM,
          To = App.loggedInUser.EmailAddress,
          Subject = "SOR List",
          SendMe = true
        }.Send();
      }
      else
      {
        int num = (int) App.ShowMessage("Your email address has not been added to your account, please contact IT", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public delegate void RefreshButtonEventHandler();
  }
}
