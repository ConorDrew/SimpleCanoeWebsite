Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.CostCentres
Imports FSM.Entity.Engineers
Imports FSM.Entity.EngineerVisitCharges
Imports FSM.Entity.EngineerVisits
Imports FSM.Entity.EngineerVisits.EngineerVisitEngineers
Imports FSM.Entity.EngineerVisits.EngineerVisitEngineers.Enums
Imports FSM.Entity.Sys

Public Class FRMEngineerVisit : Inherits FRMBaseForm : Implements IForm
    'SEE LAST REGION FOR ALL CHARGE PAGE CODE - ALP

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboInvType, DB.Picklists.GetAll(65).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPaidBy, DB.Picklists.GetAll(66).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboEngineer, dtEngineerGetAll, "EngineerID", "Name", Enums.ComboValues.Not_Applicable)
        Combo.SetUpCombo(Me.cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboGasInstallationTightnessTest, dtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboEmergencyControlAccessible, dtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboBonding, dtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPropertyRented, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPaymentMethod, DB.Picklists.GetAll(Enums.PickListTypes.PaymentMethods).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSignatureSelected, DB.Picklists.GetAll(Enums.PickListTypes.Signature).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        '
        'QC Comboboxes
        '
        Combo.SetUpCombo(Me.cboQCAppliance, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCCustSig, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCCustomerDetails, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCEngineerPaymentRecieved, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCJobType, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCJobUploadTimescale, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCLabourTime, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCLGSR, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCOrderNo, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCParts, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCPaymentCollection, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCPaymentMethod, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCPaymentSelection, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQCScheduleOfRate, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboRecall, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboRecallEngineer, dtEngineerGetAll, "EngineerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFTFCode, DB.Picklists.GetAll(Enums.PickListTypes.FTFCodes).Table, "ManagerID", "Description", Enums.ComboValues.Please_Select)
        '
        '
        '

        Combo.SetUpCombo(Me.cboVATRate, DB.VATRatesSQL.VATRates_GetAll_InputOrOutput("O").Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCorrectMaterialsUsedID, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboInstallationPipeWorkCorrectID, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboInstallationSafeToUseID, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboStrainerFittedID, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboStrainerInspectedID, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboHeatingSystemTypeID, DB.Picklists.GetAll(Enums.PickListTypes.HeatingSystemType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPartialHeatingID, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboCylinderTypeID, DB.Picklists.GetAll(Enums.PickListTypes.CylinderType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCertificateTypeID, DB.Picklists.GetAll(Enums.PickListTypes.CertificateType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboJacketID, DB.Picklists.GetAll(Enums.PickListTypes.Jacket).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboImmersionID, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCODetectorFittedID, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboFillDisc, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSITimer, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboVisualInspectionSatisfactoryID, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboRecharge, DB.Picklists.GetAll(Enums.PickListTypes.Recharge).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboNccRad, DB.Picklists.GetAll(Enums.PickListTypes.NccRad).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboMeterLocation, DB.Picklists.GetAll(Enums.PickListTypes.MeterLocation).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboMeterCapped, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents tcWorkSheet As System.Windows.Forms.TabControl

    Friend WithEvents tpMainDetails As System.Windows.Forms.TabPage
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tpPartsAndProducts As System.Windows.Forms.TabPage
    Friend WithEvents tpTimesheets As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtScheduledTime As System.Windows.Forms.TextBox
    Friend WithEvents grpTimesheets As System.Windows.Forms.GroupBox
    Friend WithEvents grpUsed As System.Windows.Forms.GroupBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents cboEngineer As System.Windows.Forms.ComboBox
    Friend WithEvents txtNotesFromEngineer As System.Windows.Forms.TextBox
    Friend WithEvents cboOutcome As System.Windows.Forms.ComboBox
    Friend WithEvents txtOutcomeDetails As System.Windows.Forms.TextBox
    Friend WithEvents txtUploadedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtNotesToEngineer As System.Windows.Forms.TextBox
    Friend WithEvents mnuAddChecklist As System.Windows.Forms.ContextMenu
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgJobItems As System.Windows.Forms.DataGrid
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgPartsAndProductsUsed As System.Windows.Forms.DataGrid
    Friend WithEvents txtNameUsed As System.Windows.Forms.TextBox
    Friend WithEvents btnRemovePartProductUsed As System.Windows.Forms.Button
    Friend WithEvents btnFindProductUsed As System.Windows.Forms.Button
    Friend WithEvents btnFindPartUsed As System.Windows.Forms.Button
    Friend WithEvents btnAddPartProductUsed As System.Windows.Forms.Button
    Friend WithEvents nudQuantityUsed As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtNumberUsed As System.Windows.Forms.TextBox
    Friend WithEvents btnAddTimeSheet As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnRemoveTimeSheet As System.Windows.Forms.Button
    Friend WithEvents dgTimeSheets As System.Windows.Forms.DataGrid
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboTimeSheetType As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents gpbScheduleOfRates As System.Windows.Forms.GroupBox
    Friend WithEvents gpbTimesheets As System.Windows.Forms.GroupBox
    Friend WithEvents gpbAdditionalCharges As System.Windows.Forms.GroupBox
    Friend WithEvents gpbPartsAndProducts As System.Windows.Forms.GroupBox
    Friend WithEvents dgScheduleOfRateCharges As System.Windows.Forms.DataGrid
    Friend WithEvents txtScheduleOfRatesTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtTimesheetTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dgTimesheetCharges As System.Windows.Forms.DataGrid
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtAdditionalChargeDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveAdditionalCharge As System.Windows.Forms.Button
    Friend WithEvents btnAddAdditionalCharge As System.Windows.Forms.Button
    Friend WithEvents tpCharges As System.Windows.Forms.TabPage
    Friend WithEvents dgPartsProductCharging As System.Windows.Forms.DataGrid
    Friend WithEvents txtAdditionalChargeTotal As System.Windows.Forms.TextBox
    Friend WithEvents dgAdditionalCharges As System.Windows.Forms.DataGrid
    Friend WithEvents txtAdditionalCharge As System.Windows.Forms.TextBox
    Friend WithEvents cbxVisitLockDown As System.Windows.Forms.CheckBox
    Friend WithEvents lblSellPrice As System.Windows.Forms.Label
    Friend WithEvents lblStatusWarning As System.Windows.Forms.Label
    Friend WithEvents gpbCharges As System.Windows.Forms.GroupBox
    Friend WithEvents txtJobValue As System.Windows.Forms.TextBox
    Friend WithEvents rdoJobValue As System.Windows.Forms.RadioButton
    Friend WithEvents rdoChargeOther As System.Windows.Forms.RadioButton
    Friend WithEvents txtPercentOfQuote As System.Windows.Forms.TextBox
    Friend WithEvents rdoPercentageOfQuoteValue As System.Windows.Forms.RadioButton
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents gpbInvoice As System.Windows.Forms.GroupBox
    Friend WithEvents cbxReadyToBeInvoiced As System.Windows.Forms.CheckBox
    Friend WithEvents txtCharge As System.Windows.Forms.TextBox
    Friend WithEvents lblEquals As System.Windows.Forms.Label
    Friend WithEvents lblQuotePercentageTotal As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblOR As System.Windows.Forms.Label
    Friend WithEvents lblRaiseInvoiceOn As System.Windows.Forms.Label
    Friend WithEvents dtpRaiseInvoiceOn As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEngineerCostTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnOrders As System.Windows.Forms.Button
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
    Friend WithEvents grpAllocated As System.Windows.Forms.GroupBox
    Friend WithEvents dgPartsProductsAllocated As System.Windows.Forms.DataGrid
    Friend WithEvents btnAllocatedNotUsed As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents btnAllUsed As System.Windows.Forms.Button
    Friend WithEvents lblContractPerVisit As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnAddSoR As System.Windows.Forms.Button
    Friend WithEvents txtCurrentContract As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents tpWorksheets As System.Windows.Forms.TabPage
    Friend WithEvents grpVisitWorksheet As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cboGasInstallationTightnessTest As System.Windows.Forms.ComboBox
    Friend WithEvents cboEmergencyControlAccessible As System.Windows.Forms.ComboBox
    Friend WithEvents cboBonding As System.Windows.Forms.ComboBox
    Friend WithEvents cboPropertyRented As System.Windows.Forms.ComboBox
    Friend WithEvents cboSignatureSelected As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmountCollected As System.Windows.Forms.TextBox
    Friend WithEvents grpApplianceWorksheet As System.Windows.Forms.GroupBox
    Friend WithEvents grpVisitDefects As System.Windows.Forms.GroupBox
    Friend WithEvents dgApplianceWorkSheets As System.Windows.Forms.DataGrid
    Friend WithEvents dgVisitDefects As System.Windows.Forms.DataGrid
    Friend WithEvents btnRemoveVisitDefect As System.Windows.Forms.Button
    Friend WithEvents btnAddVisitDefect As System.Windows.Forms.Button
    Friend WithEvents btnRemoveApplianceWorkSheet As System.Windows.Forms.Button
    Friend WithEvents PrintMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuGasSafetyInspectionBoilerServiceRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblInvoiceAddressDetails As System.Windows.Forms.Label
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents txtNominalCode As System.Windows.Forms.TextBox
    Friend WithEvents lblNominalCode As System.Windows.Forms.Label
    Friend WithEvents btnPrintGSR As System.Windows.Forms.Button
    Friend WithEvents tpAppliances As System.Windows.Forms.TabPage
    Friend WithEvents gpAppliances As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents tpOutcomes As System.Windows.Forms.TabPage
    Friend WithEvents chkGasServiceCompleted As System.Windows.Forms.CheckBox
    Friend WithEvents grpOutcomes As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintSVR As System.Windows.Forms.Button
    Friend WithEvents tpQC As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxEmailReceiptToCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountCode As System.Windows.Forms.Label
    Friend WithEvents btnJob As System.Windows.Forms.Button
    Friend WithEvents txtPriceIncVAT As System.Windows.Forms.TextBox
    Friend WithEvents lblPriceInvVAT As System.Windows.Forms.Label
    Friend WithEvents nudPartAllocatedQty As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAllocatedQuantity As System.Windows.Forms.Label
    Friend WithEvents pbCustomerSignature As System.Windows.Forms.PictureBox
    Friend WithEvents pbEngineerSignature As System.Windows.Forms.PictureBox
    Friend WithEvents lblEquipment As System.Windows.Forms.Label
    Friend WithEvents grpVisitWorksheetExtended As System.Windows.Forms.GroupBox
    Friend WithEvents cboStrainerInspectedID As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents cboStrainerFittedID As System.Windows.Forms.ComboBox
    Friend WithEvents cboInstallationSafeToUseID As System.Windows.Forms.ComboBox
    Friend WithEvents cboInstallationPipeWorkCorrectID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCorrectMaterialsUsedID As System.Windows.Forms.ComboBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtVisualInspectionReason As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents cboCertificateTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCODetectorFittedID As System.Windows.Forms.ComboBox
    Friend WithEvents cboImmersionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboJacketID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCylinderTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartialHeatingID As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeatingSystemTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtApproxAgeOfBoiler As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents chkRecharge As System.Windows.Forms.CheckBox
    Friend WithEvents txtRadiators As System.Windows.Forms.TextBox
    Friend WithEvents cboVisualInspectionSatisfactoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblRechargeTicked As System.Windows.Forms.Label
    Friend WithEvents tpDocuments As System.Windows.Forms.TabPage
    Friend WithEvents btnChangeOutcome As System.Windows.Forms.Button
    Friend WithEvents txtScheduledTime2 As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents btnShowVisits As System.Windows.Forms.Button
    Friend WithEvents CostsToOption3 As System.Windows.Forms.RadioButton
    Friend WithEvents CostsToOption2 As System.Windows.Forms.RadioButton
    Friend WithEvents CostsToOption1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents grpAlarmInfo As System.Windows.Forms.GroupBox
    Friend WithEvents tpPhotos As System.Windows.Forms.TabPage
    Friend WithEvents flPhotos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cboFTFCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents dgAdditional As System.Windows.Forms.DataGrid
    Friend WithEvents cboRecharge As System.Windows.Forms.ComboBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents cboNccRad As System.Windows.Forms.ComboBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents cboSITimer As System.Windows.Forms.ComboBox
    Friend WithEvents cboFillDisc As System.Windows.Forms.ComboBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtCustEmail As System.Windows.Forms.TextBox
    Friend WithEvents btnEditInvoiceNotes As System.Windows.Forms.Button
    Friend WithEvents cboVATRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblVAT As System.Windows.Forms.Label
    Friend WithEvents cboPaidBy As System.Windows.Forms.ComboBox
    Friend WithEvents lblPaidBy As System.Windows.Forms.Label
    Friend WithEvents cboInvType As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvType As System.Windows.Forms.Label
    Friend WithEvents lblcredit As System.Windows.Forms.Label
    Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblInvNo As System.Windows.Forms.Label
    Friend WithEvents txtInvNo As System.Windows.Forms.TextBox
    Friend WithEvents lblInvAmount As System.Windows.Forms.Label
    Friend WithEvents txtInvAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateServ As System.Windows.Forms.Button
    Friend WithEvents chkSORDesc As System.Windows.Forms.CheckBox
    Friend WithEvents grpAdditionalWorksheet As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveAdd As System.Windows.Forms.Button
    Friend WithEvents btnAddAdd As System.Windows.Forms.Button
    Friend WithEvents DGSmokeComo As System.Windows.Forms.DataGrid
    Friend WithEvents btnRemoveSmokeComo As System.Windows.Forms.Button
    Friend WithEvents btnAddSmokeComo As System.Windows.Forms.Button
    Friend WithEvents SVRs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents svrmenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JobSheetMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DomesticGSRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WarningNoticeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommercialGSRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QCResultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElectricalMinorWorksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllGasPaperworkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommercialCateringToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaffronUnventedWorkshhetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropertyMaintenanceWorksheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ASHPWorksheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cboMeterCapped As ComboBox
    Friend WithEvents Label73 As Label
    Friend WithEvents cboMeterLocation As ComboBox
    Friend WithEvents Label72 As Label
    Friend WithEvents Label82 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents txtProfitPerc As TextBox
    Friend WithEvents txtProfit As TextBox
    Friend WithEvents txtCosts As TextBox
    Friend WithEvents txtSale As TextBox
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents chkShowJobCharges As CheckBox
    Friend WithEvents txtPartProductCost As TextBox
    Friend WithEvents lblPPTotalCost As Label
    Friend WithEvents txtPartsProductTotal As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents rbStandard As RadioButton
    Friend WithEvents rbSite As RadioButton
    Friend WithEvents lblQuantityWarning As Label
    Friend WithEvents btnRevertUsed As Button
    Friend WithEvents grpOfficeQC As GroupBox
    Friend WithEvents cboQCJobType As ComboBox
    Friend WithEvents lblJobTypeCorrect As Label
    Friend WithEvents grpQCField As GroupBox
    Friend WithEvents lblQCPoorJobNotes As Label
    Friend WithEvents cboQCEngineerPaymentRecieved As ComboBox
    Friend WithEvents lblQCEngineerMonies As Label
    Friend WithEvents cboQCPaymentSelection As ComboBox
    Friend WithEvents lblQCEngPaymentMethod As Label
    Friend WithEvents cboQCAppliance As ComboBox
    Friend WithEvents cboQCPaymentCollection As ComboBox
    Friend WithEvents lblQCPaymentCollection As Label
    Friend WithEvents cboQCJobUploadTimescale As ComboBox
    Friend WithEvents lblQCAppliance As Label
    Friend WithEvents cboQCParts As ComboBox
    Friend WithEvents lblJobUploadTimescale As Label
    Friend WithEvents lblQCParts As Label
    Friend WithEvents cboQCLGSR As ComboBox
    Friend WithEvents lblQCLGSR As Label
    Friend WithEvents cboQCLabourTime As ComboBox
    Friend WithEvents lblQCLabourTime As Label
    Friend WithEvents cboQCPaymentMethod As ComboBox
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents cboQCOrderNo As ComboBox
    Friend WithEvents lblOrderNo As Label
    Friend WithEvents cboQCScheduleOfRate As ComboBox
    Friend WithEvents lblScheduleRate As Label
    Friend WithEvents cboQCCustomerDetails As ComboBox
    Friend WithEvents lblCustomerDetails As Label
    Friend WithEvents dtpQCDocumentsRecieved As DateTimePicker
    Friend WithEvents chkQCDocumentsRecieved As CheckBox
    Friend WithEvents txtQCPoorJobNotes As TextBox
    Friend WithEvents btnUnselectAllPPA As Button
    Friend WithEvents btnSelectAllPPA As Button
    Friend WithEvents grpSiteFuels As GroupBox
    Friend WithEvents dgSiteFuel As DataGrid
    Friend WithEvents txtActualTimeSpent As TextBox
    Friend WithEvents txtDifference As TextBox
    Friend WithEvents txtSORTimeAllowance As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents cboRecallEngineer As ComboBox
    Friend WithEvents Label49 As Label
    Friend WithEvents cboRecall As ComboBox
    Friend WithEvents Label48 As Label
    Friend WithEvents cboQCCustSig As ComboBox
    Friend WithEvents lblQCCustSig As Label
    Friend WithEvents CommissioningChecklistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents chkPartsSelectAll As CheckBox
    Friend WithEvents txtPartsMarkUp As TextBox
    Friend WithEvents chkTimesheetSelectAll As CheckBox
    Friend WithEvents lblPartsMarkUp As Label
    Friend WithEvents lblAdditionalCharge As Label
    Friend WithEvents HotWorksPermitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAddApplianceWorksheet As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tcWorkSheet = New System.Windows.Forms.TabControl()
        Me.tpMainDetails = New System.Windows.Forms.TabPage()
        Me.chkSORDesc = New System.Windows.Forms.CheckBox()
        Me.btnEditInvoiceNotes = New System.Windows.Forms.Button()
        Me.txtScheduledTime2 = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.btnChangeOutcome = New System.Windows.Forms.Button()
        Me.pbCustomerSignature = New System.Windows.Forms.PictureBox()
        Me.pbEngineerSignature = New System.Windows.Forms.PictureBox()
        Me.cbxEmailReceiptToCustomer = New System.Windows.Forms.CheckBox()
        Me.cboSignatureSelected = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.dgJobItems = New System.Windows.Forms.DataGrid()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNotesToEngineer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.cboEngineer = New System.Windows.Forms.ComboBox()
        Me.txtNotesFromEngineer = New System.Windows.Forms.TextBox()
        Me.cboOutcome = New System.Windows.Forms.ComboBox()
        Me.txtOutcomeDetails = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtUploadedBy = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpAppliances = New System.Windows.Forms.TabPage()
        Me.gpAppliances = New System.Windows.Forms.GroupBox()
        Me.dgAssets = New System.Windows.Forms.DataGrid()
        Me.tpWorksheets = New System.Windows.Forms.TabPage()
        Me.grpAdditionalWorksheet = New System.Windows.Forms.GroupBox()
        Me.btnRemoveAdd = New System.Windows.Forms.Button()
        Me.btnAddAdd = New System.Windows.Forms.Button()
        Me.dgAdditional = New System.Windows.Forms.DataGrid()
        Me.grpAlarmInfo = New System.Windows.Forms.GroupBox()
        Me.btnRemoveSmokeComo = New System.Windows.Forms.Button()
        Me.btnAddSmokeComo = New System.Windows.Forms.Button()
        Me.DGSmokeComo = New System.Windows.Forms.DataGrid()
        Me.grpVisitWorksheetExtended = New System.Windows.Forms.GroupBox()
        Me.cboSITimer = New System.Windows.Forms.ComboBox()
        Me.cboFillDisc = New System.Windows.Forms.ComboBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtRadiators = New System.Windows.Forms.TextBox()
        Me.txtVisualInspectionReason = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.cboCertificateTypeID = New System.Windows.Forms.ComboBox()
        Me.cboCODetectorFittedID = New System.Windows.Forms.ComboBox()
        Me.cboVisualInspectionSatisfactoryID = New System.Windows.Forms.ComboBox()
        Me.cboImmersionID = New System.Windows.Forms.ComboBox()
        Me.cboJacketID = New System.Windows.Forms.ComboBox()
        Me.cboCylinderTypeID = New System.Windows.Forms.ComboBox()
        Me.cboPartialHeatingID = New System.Windows.Forms.ComboBox()
        Me.cboHeatingSystemTypeID = New System.Windows.Forms.ComboBox()
        Me.txtApproxAgeOfBoiler = New System.Windows.Forms.TextBox()
        Me.cboStrainerInspectedID = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.cboStrainerFittedID = New System.Windows.Forms.ComboBox()
        Me.cboInstallationSafeToUseID = New System.Windows.Forms.ComboBox()
        Me.cboInstallationPipeWorkCorrectID = New System.Windows.Forms.ComboBox()
        Me.cboCorrectMaterialsUsedID = New System.Windows.Forms.ComboBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.grpVisitDefects = New System.Windows.Forms.GroupBox()
        Me.btnAddVisitDefect = New System.Windows.Forms.Button()
        Me.btnRemoveVisitDefect = New System.Windows.Forms.Button()
        Me.dgVisitDefects = New System.Windows.Forms.DataGrid()
        Me.grpApplianceWorksheet = New System.Windows.Forms.GroupBox()
        Me.btnRemoveApplianceWorkSheet = New System.Windows.Forms.Button()
        Me.dgApplianceWorkSheets = New System.Windows.Forms.DataGrid()
        Me.btnAddApplianceWorksheet = New System.Windows.Forms.Button()
        Me.grpVisitWorksheet = New System.Windows.Forms.GroupBox()
        Me.cboMeterCapped = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.cboMeterLocation = New System.Windows.Forms.ComboBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtAmountCollected = New System.Windows.Forms.TextBox()
        Me.cboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cboPropertyRented = New System.Windows.Forms.ComboBox()
        Me.cboBonding = New System.Windows.Forms.ComboBox()
        Me.cboEmergencyControlAccessible = New System.Windows.Forms.ComboBox()
        Me.cboGasInstallationTightnessTest = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tpTimesheets = New System.Windows.Forms.TabPage()
        Me.grpTimesheets = New System.Windows.Forms.GroupBox()
        Me.txtActualTimeSpent = New System.Windows.Forms.TextBox()
        Me.txtDifference = New System.Windows.Forms.TextBox()
        Me.txtSORTimeAllowance = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboTimeSheetType = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dgTimeSheets = New System.Windows.Forms.DataGrid()
        Me.btnAddTimeSheet = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnRemoveTimeSheet = New System.Windows.Forms.Button()
        Me.txtScheduledTime = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tpPartsAndProducts = New System.Windows.Forms.TabPage()
        Me.grpAllocated = New System.Windows.Forms.GroupBox()
        Me.btnUnselectAllPPA = New System.Windows.Forms.Button()
        Me.btnSelectAllPPA = New System.Windows.Forms.Button()
        Me.btnRevertUsed = New System.Windows.Forms.Button()
        Me.nudPartAllocatedQty = New System.Windows.Forms.NumericUpDown()
        Me.lblAllocatedQuantity = New System.Windows.Forms.Label()
        Me.btnAllUsed = New System.Windows.Forms.Button()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAllocatedNotUsed = New System.Windows.Forms.Button()
        Me.dgPartsProductsAllocated = New System.Windows.Forms.DataGrid()
        Me.lblQuantityWarning = New System.Windows.Forms.Label()
        Me.grpUsed = New System.Windows.Forms.GroupBox()
        Me.lblEquipment = New System.Windows.Forms.Label()
        Me.lblSellPrice = New System.Windows.Forms.Label()
        Me.dgPartsAndProductsUsed = New System.Windows.Forms.DataGrid()
        Me.btnAddPartProductUsed = New System.Windows.Forms.Button()
        Me.nudQuantityUsed = New System.Windows.Forms.NumericUpDown()
        Me.txtNameUsed = New System.Windows.Forms.TextBox()
        Me.txtNumberUsed = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnRemovePartProductUsed = New System.Windows.Forms.Button()
        Me.btnFindProductUsed = New System.Windows.Forms.Button()
        Me.btnFindPartUsed = New System.Windows.Forms.Button()
        Me.tpOutcomes = New System.Windows.Forms.TabPage()
        Me.grpOutcomes = New System.Windows.Forms.GroupBox()
        Me.grpSiteFuels = New System.Windows.Forms.GroupBox()
        Me.dgSiteFuel = New System.Windows.Forms.DataGrid()
        Me.cboNccRad = New System.Windows.Forms.ComboBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.cboRecharge = New System.Windows.Forms.ComboBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.chkRecharge = New System.Windows.Forms.CheckBox()
        Me.chkGasServiceCompleted = New System.Windows.Forms.CheckBox()
        Me.tpQC = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grpQCField = New System.Windows.Forms.GroupBox()
        Me.cboQCCustSig = New System.Windows.Forms.ComboBox()
        Me.lblQCCustSig = New System.Windows.Forms.Label()
        Me.cboRecallEngineer = New System.Windows.Forms.ComboBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.cboRecall = New System.Windows.Forms.ComboBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.dtpQCDocumentsRecieved = New System.Windows.Forms.DateTimePicker()
        Me.chkQCDocumentsRecieved = New System.Windows.Forms.CheckBox()
        Me.txtQCPoorJobNotes = New System.Windows.Forms.TextBox()
        Me.lblQCPoorJobNotes = New System.Windows.Forms.Label()
        Me.cboQCEngineerPaymentRecieved = New System.Windows.Forms.ComboBox()
        Me.lblQCEngineerMonies = New System.Windows.Forms.Label()
        Me.cboQCPaymentSelection = New System.Windows.Forms.ComboBox()
        Me.lblQCEngPaymentMethod = New System.Windows.Forms.Label()
        Me.cboQCAppliance = New System.Windows.Forms.ComboBox()
        Me.cboQCPaymentCollection = New System.Windows.Forms.ComboBox()
        Me.lblQCPaymentCollection = New System.Windows.Forms.Label()
        Me.cboQCJobUploadTimescale = New System.Windows.Forms.ComboBox()
        Me.lblQCAppliance = New System.Windows.Forms.Label()
        Me.cboQCParts = New System.Windows.Forms.ComboBox()
        Me.lblJobUploadTimescale = New System.Windows.Forms.Label()
        Me.lblQCParts = New System.Windows.Forms.Label()
        Me.cboQCLGSR = New System.Windows.Forms.ComboBox()
        Me.lblQCLGSR = New System.Windows.Forms.Label()
        Me.cboQCLabourTime = New System.Windows.Forms.ComboBox()
        Me.lblQCLabourTime = New System.Windows.Forms.Label()
        Me.grpOfficeQC = New System.Windows.Forms.GroupBox()
        Me.cboQCPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.lblPaymentMethod = New System.Windows.Forms.Label()
        Me.cboQCOrderNo = New System.Windows.Forms.ComboBox()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.cboQCScheduleOfRate = New System.Windows.Forms.ComboBox()
        Me.lblScheduleRate = New System.Windows.Forms.Label()
        Me.cboQCCustomerDetails = New System.Windows.Forms.ComboBox()
        Me.lblCustomerDetails = New System.Windows.Forms.Label()
        Me.cboQCJobType = New System.Windows.Forms.ComboBox()
        Me.lblJobTypeCorrect = New System.Windows.Forms.Label()
        Me.cboFTFCode = New System.Windows.Forms.ComboBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.tpCharges = New System.Windows.Forms.TabPage()
        Me.gpbInvoice = New System.Windows.Forms.GroupBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.btnCreateServ = New System.Windows.Forms.Button()
        Me.txtInvAmount = New System.Windows.Forms.TextBox()
        Me.txtCreditAmount = New System.Windows.Forms.TextBox()
        Me.txtInvNo = New System.Windows.Forms.TextBox()
        Me.cboPaidBy = New System.Windows.Forms.ComboBox()
        Me.cboInvType = New System.Windows.Forms.ComboBox()
        Me.cboVATRate = New System.Windows.Forms.ComboBox()
        Me.txtPriceIncVAT = New System.Windows.Forms.TextBox()
        Me.txtAccountCode = New System.Windows.Forms.TextBox()
        Me.lblInvoiceAddressDetails = New System.Windows.Forms.Label()
        Me.txtNominalCode = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtpRaiseInvoiceOn = New System.Windows.Forms.DateTimePicker()
        Me.cbxReadyToBeInvoiced = New System.Windows.Forms.CheckBox()
        Me.lblInvAmount = New System.Windows.Forms.Label()
        Me.lblcredit = New System.Windows.Forms.Label()
        Me.lblInvNo = New System.Windows.Forms.Label()
        Me.lblPaidBy = New System.Windows.Forms.Label()
        Me.lblInvType = New System.Windows.Forms.Label()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.lblNominalCode = New System.Windows.Forms.Label()
        Me.lblAccountCode = New System.Windows.Forms.Label()
        Me.lblPriceInvVAT = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblRaiseInvoiceOn = New System.Windows.Forms.Label()
        Me.gpbCharges = New System.Windows.Forms.GroupBox()
        Me.chkShowJobCharges = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.txtProfitPerc = New System.Windows.Forms.TextBox()
        Me.txtProfit = New System.Windows.Forms.TextBox()
        Me.CostsToOption1 = New System.Windows.Forms.RadioButton()
        Me.txtCosts = New System.Windows.Forms.TextBox()
        Me.CostsToOption3 = New System.Windows.Forms.RadioButton()
        Me.txtSale = New System.Windows.Forms.TextBox()
        Me.CostsToOption2 = New System.Windows.Forms.RadioButton()
        Me.lblContractPerVisit = New System.Windows.Forms.Label()
        Me.lblOR = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblQuotePercentageTotal = New System.Windows.Forms.Label()
        Me.lblEquals = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rbStandard = New System.Windows.Forms.RadioButton()
        Me.rbSite = New System.Windows.Forms.RadioButton()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.txtPercentOfQuote = New System.Windows.Forms.TextBox()
        Me.rdoPercentageOfQuoteValue = New System.Windows.Forms.RadioButton()
        Me.txtCharge = New System.Windows.Forms.TextBox()
        Me.rdoChargeOther = New System.Windows.Forms.RadioButton()
        Me.rdoJobValue = New System.Windows.Forms.RadioButton()
        Me.txtJobValue = New System.Windows.Forms.TextBox()
        Me.gpbAdditionalCharges = New System.Windows.Forms.GroupBox()
        Me.lblAdditionalCharge = New System.Windows.Forms.Label()
        Me.btnAddAdditionalCharge = New System.Windows.Forms.Button()
        Me.txtAdditionalCharge = New System.Windows.Forms.TextBox()
        Me.btnRemoveAdditionalCharge = New System.Windows.Forms.Button()
        Me.txtAdditionalChargeDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtAdditionalChargeTotal = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dgAdditionalCharges = New System.Windows.Forms.DataGrid()
        Me.gpbPartsAndProducts = New System.Windows.Forms.GroupBox()
        Me.txtPartsMarkUp = New System.Windows.Forms.TextBox()
        Me.chkPartsSelectAll = New System.Windows.Forms.CheckBox()
        Me.txtPartProductCost = New System.Windows.Forms.TextBox()
        Me.txtPartsProductTotal = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblPPTotalCost = New System.Windows.Forms.Label()
        Me.lblPartsMarkUp = New System.Windows.Forms.Label()
        Me.dgPartsProductCharging = New System.Windows.Forms.DataGrid()
        Me.gpbTimesheets = New System.Windows.Forms.GroupBox()
        Me.chkTimesheetSelectAll = New System.Windows.Forms.CheckBox()
        Me.txtEngineerCostTotal = New System.Windows.Forms.TextBox()
        Me.txtTimesheetTotal = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.dgTimesheetCharges = New System.Windows.Forms.DataGrid()
        Me.gpbScheduleOfRates = New System.Windows.Forms.GroupBox()
        Me.btnAddSoR = New System.Windows.Forms.Button()
        Me.txtScheduleOfRatesTotal = New System.Windows.Forms.TextBox()
        Me.dgScheduleOfRateCharges = New System.Windows.Forms.DataGrid()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tpDocuments = New System.Windows.Forms.TabPage()
        Me.tpPhotos = New System.Windows.Forms.TabPage()
        Me.flPhotos = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.mnuAddChecklist = New System.Windows.Forms.ContextMenu()
        Me.cbxVisitLockDown = New System.Windows.Forms.CheckBox()
        Me.lblStatusWarning = New System.Windows.Forms.Label()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.btnInvoice = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.PrintMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuGasSafetyInspectionBoilerServiceRecord = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtCurrentContract = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.btnPrintGSR = New System.Windows.Forms.Button()
        Me.btnPrintSVR = New System.Windows.Forms.Button()
        Me.btnJob = New System.Windows.Forms.Button()
        Me.lblRechargeTicked = New System.Windows.Forms.Label()
        Me.btnShowVisits = New System.Windows.Forms.Button()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCustEmail = New System.Windows.Forms.TextBox()
        Me.SVRs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AllGasPaperworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.svrmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobSheetMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.DomesticGSRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarningNoticeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommercialGSRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QCResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElectricalMinorWorksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommercialCateringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaffronUnventedWorkshhetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertyMaintenanceWorksheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ASHPWorksheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommissioningChecklistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HotWorksPermitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcWorkSheet.SuspendLayout()
        Me.tpMainDetails.SuspendLayout()
        CType(Me.pbCustomerSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEngineerSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgJobItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAppliances.SuspendLayout()
        Me.gpAppliances.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpWorksheets.SuspendLayout()
        Me.grpAdditionalWorksheet.SuspendLayout()
        CType(Me.dgAdditional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAlarmInfo.SuspendLayout()
        CType(Me.DGSmokeComo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVisitWorksheetExtended.SuspendLayout()
        Me.grpVisitDefects.SuspendLayout()
        CType(Me.dgVisitDefects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpApplianceWorksheet.SuspendLayout()
        CType(Me.dgApplianceWorkSheets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVisitWorksheet.SuspendLayout()
        Me.tpTimesheets.SuspendLayout()
        Me.grpTimesheets.SuspendLayout()
        CType(Me.dgTimeSheets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPartsAndProducts.SuspendLayout()
        Me.grpAllocated.SuspendLayout()
        CType(Me.nudPartAllocatedQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPartsProductsAllocated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpUsed.SuspendLayout()
        CType(Me.dgPartsAndProductsUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudQuantityUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpOutcomes.SuspendLayout()
        Me.grpOutcomes.SuspendLayout()
        Me.grpSiteFuels.SuspendLayout()
        CType(Me.dgSiteFuel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpQC.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpQCField.SuspendLayout()
        Me.grpOfficeQC.SuspendLayout()
        Me.tpCharges.SuspendLayout()
        Me.gpbInvoice.SuspendLayout()
        Me.gpbCharges.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.gpbAdditionalCharges.SuspendLayout()
        CType(Me.dgAdditionalCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbPartsAndProducts.SuspendLayout()
        CType(Me.dgPartsProductCharging, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbTimesheets.SuspendLayout()
        CType(Me.dgTimesheetCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbScheduleOfRates.SuspendLayout()
        CType(Me.dgScheduleOfRateCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPhotos.SuspendLayout()
        Me.PrintMenu.SuspendLayout()
        Me.SVRs.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcWorkSheet
        '
        Me.tcWorkSheet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcWorkSheet.Controls.Add(Me.tpMainDetails)
        Me.tcWorkSheet.Controls.Add(Me.tpAppliances)
        Me.tcWorkSheet.Controls.Add(Me.tpWorksheets)
        Me.tcWorkSheet.Controls.Add(Me.tpTimesheets)
        Me.tcWorkSheet.Controls.Add(Me.tpPartsAndProducts)
        Me.tcWorkSheet.Controls.Add(Me.tpOutcomes)
        Me.tcWorkSheet.Controls.Add(Me.tpQC)
        Me.tcWorkSheet.Controls.Add(Me.tpCharges)
        Me.tcWorkSheet.Controls.Add(Me.tpDocuments)
        Me.tcWorkSheet.Controls.Add(Me.tpPhotos)
        Me.tcWorkSheet.Location = New System.Drawing.Point(0, 64)
        Me.tcWorkSheet.Name = "tcWorkSheet"
        Me.tcWorkSheet.SelectedIndex = 0
        Me.tcWorkSheet.Size = New System.Drawing.Size(1255, 678)
        Me.tcWorkSheet.TabIndex = 1
        '
        'tpMainDetails
        '
        Me.tpMainDetails.Controls.Add(Me.chkSORDesc)
        Me.tpMainDetails.Controls.Add(Me.btnEditInvoiceNotes)
        Me.tpMainDetails.Controls.Add(Me.txtScheduledTime2)
        Me.tpMainDetails.Controls.Add(Me.Label71)
        Me.tpMainDetails.Controls.Add(Me.btnChangeOutcome)
        Me.tpMainDetails.Controls.Add(Me.pbCustomerSignature)
        Me.tpMainDetails.Controls.Add(Me.pbEngineerSignature)
        Me.tpMainDetails.Controls.Add(Me.cbxEmailReceiptToCustomer)
        Me.tpMainDetails.Controls.Add(Me.cboSignatureSelected)
        Me.tpMainDetails.Controls.Add(Me.Label42)
        Me.tpMainDetails.Controls.Add(Me.dgJobItems)
        Me.tpMainDetails.Controls.Add(Me.Label12)
        Me.tpMainDetails.Controls.Add(Me.txtNotesToEngineer)
        Me.tpMainDetails.Controls.Add(Me.Label6)
        Me.tpMainDetails.Controls.Add(Me.txtCustomer)
        Me.tpMainDetails.Controls.Add(Me.cboEngineer)
        Me.tpMainDetails.Controls.Add(Me.txtNotesFromEngineer)
        Me.tpMainDetails.Controls.Add(Me.cboOutcome)
        Me.tpMainDetails.Controls.Add(Me.txtOutcomeDetails)
        Me.tpMainDetails.Controls.Add(Me.Label11)
        Me.tpMainDetails.Controls.Add(Me.txtUploadedBy)
        Me.tpMainDetails.Controls.Add(Me.txtStatus)
        Me.tpMainDetails.Controls.Add(Me.Label9)
        Me.tpMainDetails.Controls.Add(Me.Label5)
        Me.tpMainDetails.Controls.Add(Me.Label4)
        Me.tpMainDetails.Controls.Add(Me.Label3)
        Me.tpMainDetails.Controls.Add(Me.Label2)
        Me.tpMainDetails.Controls.Add(Me.Label1)
        Me.tpMainDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpMainDetails.Name = "tpMainDetails"
        Me.tpMainDetails.Size = New System.Drawing.Size(1247, 652)
        Me.tpMainDetails.TabIndex = 0
        Me.tpMainDetails.Text = "Main Details"
        Me.tpMainDetails.UseVisualStyleBackColor = True
        '
        'chkSORDesc
        '
        Me.chkSORDesc.AutoSize = True
        Me.chkSORDesc.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSORDesc.Location = New System.Drawing.Point(128, 413)
        Me.chkSORDesc.Name = "chkSORDesc"
        Me.chkSORDesc.Size = New System.Drawing.Size(394, 30)
        Me.chkSORDesc.TabIndex = 35
        Me.chkSORDesc.Text = "Use SOR Descriptions for Invoice"
        Me.chkSORDesc.UseVisualStyleBackColor = True
        '
        'btnEditInvoiceNotes
        '
        Me.btnEditInvoiceNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditInvoiceNotes.Location = New System.Drawing.Point(11, 384)
        Me.btnEditInvoiceNotes.Name = "btnEditInvoiceNotes"
        Me.btnEditInvoiceNotes.Size = New System.Drawing.Size(97, 23)
        Me.btnEditInvoiceNotes.TabIndex = 34
        Me.btnEditInvoiceNotes.Text = "Edit Inv Notes"
        Me.btnEditInvoiceNotes.Visible = False
        '
        'txtScheduledTime2
        '
        Me.txtScheduledTime2.Location = New System.Drawing.Point(128, 204)
        Me.txtScheduledTime2.Name = "txtScheduledTime2"
        Me.txtScheduledTime2.ReadOnly = True
        Me.txtScheduledTime2.Size = New System.Drawing.Size(510, 21)
        Me.txtScheduledTime2.TabIndex = 32
        '
        'Label71
        '
        Me.Label71.Location = New System.Drawing.Point(8, 207)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(104, 16)
        Me.Label71.TabIndex = 33
        Me.Label71.Text = "Scheduled"
        '
        'btnChangeOutcome
        '
        Me.btnChangeOutcome.Location = New System.Drawing.Point(128, 171)
        Me.btnChangeOutcome.Name = "btnChangeOutcome"
        Me.btnChangeOutcome.Size = New System.Drawing.Size(114, 23)
        Me.btnChangeOutcome.TabIndex = 31
        Me.btnChangeOutcome.Text = "Change Outcome"
        Me.btnChangeOutcome.UseVisualStyleBackColor = True
        '
        'pbCustomerSignature
        '
        Me.pbCustomerSignature.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCustomerSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbCustomerSignature.Location = New System.Drawing.Point(647, 207)
        Me.pbCustomerSignature.Name = "pbCustomerSignature"
        Me.pbCustomerSignature.Size = New System.Drawing.Size(592, 119)
        Me.pbCustomerSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCustomerSignature.TabIndex = 30
        Me.pbCustomerSignature.TabStop = False
        '
        'pbEngineerSignature
        '
        Me.pbEngineerSignature.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbEngineerSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbEngineerSignature.Location = New System.Drawing.Point(647, 44)
        Me.pbEngineerSignature.Name = "pbEngineerSignature"
        Me.pbEngineerSignature.Size = New System.Drawing.Size(592, 121)
        Me.pbEngineerSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEngineerSignature.TabIndex = 29
        Me.pbEngineerSignature.TabStop = False
        '
        'cbxEmailReceiptToCustomer
        '
        Me.cbxEmailReceiptToCustomer.AutoSize = True
        Me.cbxEmailReceiptToCustomer.Location = New System.Drawing.Point(647, 390)
        Me.cbxEmailReceiptToCustomer.Name = "cbxEmailReceiptToCustomer"
        Me.cbxEmailReceiptToCustomer.Size = New System.Drawing.Size(180, 17)
        Me.cbxEmailReceiptToCustomer.TabIndex = 28
        Me.cbxEmailReceiptToCustomer.Text = "Email Receipt To Customer"
        Me.cbxEmailReceiptToCustomer.UseVisualStyleBackColor = True
        '
        'cboSignatureSelected
        '
        Me.cboSignatureSelected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSignatureSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSignatureSelected.Location = New System.Drawing.Point(714, 332)
        Me.cboSignatureSelected.Name = "cboSignatureSelected"
        Me.cboSignatureSelected.Size = New System.Drawing.Size(525, 21)
        Me.cboSignatureSelected.TabIndex = 27
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(644, 335)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(64, 23)
        Me.Label42.TabIndex = 26
        Me.Label42.Text = "Signature"
        '
        'dgJobItems
        '
        Me.dgJobItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobItems.DataMember = ""
        Me.dgJobItems.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobItems.Location = New System.Drawing.Point(128, 450)
        Me.dgJobItems.Name = "dgJobItems"
        Me.dgJobItems.Size = New System.Drawing.Size(1111, 196)
        Me.dgJobItems.TabIndex = 9
        Me.dgJobItems.TabStop = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 450)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Job Items"
        '
        'txtNotesToEngineer
        '
        Me.txtNotesToEngineer.Location = New System.Drawing.Point(128, 44)
        Me.txtNotesToEngineer.Multiline = True
        Me.txtNotesToEngineer.Name = "txtNotesToEngineer"
        Me.txtNotesToEngineer.ReadOnly = True
        Me.txtNotesToEngineer.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotesToEngineer.Size = New System.Drawing.Size(510, 66)
        Me.txtNotesToEngineer.TabIndex = 10
        Me.txtNotesToEngineer.TabStop = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Notes"
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Location = New System.Drawing.Point(714, 173)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(525, 21)
        Me.txtCustomer.TabIndex = 6
        '
        'cboEngineer
        '
        Me.cboEngineer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineer.Location = New System.Drawing.Point(714, 14)
        Me.cboEngineer.Name = "cboEngineer"
        Me.cboEngineer.Size = New System.Drawing.Size(525, 21)
        Me.cboEngineer.TabIndex = 4
        '
        'txtNotesFromEngineer
        '
        Me.txtNotesFromEngineer.Location = New System.Drawing.Point(128, 335)
        Me.txtNotesFromEngineer.Multiline = True
        Me.txtNotesFromEngineer.Name = "txtNotesFromEngineer"
        Me.txtNotesFromEngineer.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotesFromEngineer.Size = New System.Drawing.Size(510, 72)
        Me.txtNotesFromEngineer.TabIndex = 3
        '
        'cboOutcome
        '
        Me.cboOutcome.Location = New System.Drawing.Point(128, 144)
        Me.cboOutcome.Name = "cboOutcome"
        Me.cboOutcome.Size = New System.Drawing.Size(510, 21)
        Me.cboOutcome.TabIndex = 1
        '
        'txtOutcomeDetails
        '
        Me.txtOutcomeDetails.Location = New System.Drawing.Point(128, 231)
        Me.txtOutcomeDetails.Multiline = True
        Me.txtOutcomeDetails.Name = "txtOutcomeDetails"
        Me.txtOutcomeDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutcomeDetails.Size = New System.Drawing.Size(510, 95)
        Me.txtOutcomeDetails.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Details"
        '
        'txtUploadedBy
        '
        Me.txtUploadedBy.Location = New System.Drawing.Point(128, 116)
        Me.txtUploadedBy.Name = "txtUploadedBy"
        Me.txtUploadedBy.ReadOnly = True
        Me.txtUploadedBy.Size = New System.Drawing.Size(510, 21)
        Me.txtUploadedBy.TabIndex = 2
        Me.txtUploadedBy.TabStop = False
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(128, 14)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(510, 21)
        Me.txtStatus.TabIndex = 1
        Me.txtStatus.TabStop = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 147)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 19)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Outcome"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(644, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Uploaded by"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Status"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Invoice Notes"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(644, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Engineer"
        '
        'tpAppliances
        '
        Me.tpAppliances.Controls.Add(Me.gpAppliances)
        Me.tpAppliances.Location = New System.Drawing.Point(4, 22)
        Me.tpAppliances.Name = "tpAppliances"
        Me.tpAppliances.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAppliances.Size = New System.Drawing.Size(1247, 652)
        Me.tpAppliances.TabIndex = 6
        Me.tpAppliances.Text = "Appliances"
        Me.tpAppliances.UseVisualStyleBackColor = True
        '
        'gpAppliances
        '
        Me.gpAppliances.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpAppliances.Controls.Add(Me.dgAssets)
        Me.gpAppliances.Location = New System.Drawing.Point(6, 6)
        Me.gpAppliances.Name = "gpAppliances"
        Me.gpAppliances.Size = New System.Drawing.Size(1235, 640)
        Me.gpAppliances.TabIndex = 0
        Me.gpAppliances.TabStop = False
        Me.gpAppliances.Text = "Appliances"
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(6, 20)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(1223, 614)
        Me.dgAssets.TabIndex = 2
        '
        'tpWorksheets
        '
        Me.tpWorksheets.Controls.Add(Me.grpAdditionalWorksheet)
        Me.tpWorksheets.Controls.Add(Me.grpAlarmInfo)
        Me.tpWorksheets.Controls.Add(Me.grpVisitWorksheetExtended)
        Me.tpWorksheets.Controls.Add(Me.grpVisitDefects)
        Me.tpWorksheets.Controls.Add(Me.grpApplianceWorksheet)
        Me.tpWorksheets.Controls.Add(Me.grpVisitWorksheet)
        Me.tpWorksheets.Location = New System.Drawing.Point(4, 22)
        Me.tpWorksheets.Name = "tpWorksheets"
        Me.tpWorksheets.Size = New System.Drawing.Size(1247, 652)
        Me.tpWorksheets.TabIndex = 5
        Me.tpWorksheets.Text = "Worksheets"
        Me.tpWorksheets.UseVisualStyleBackColor = True
        '
        'grpAdditionalWorksheet
        '
        Me.grpAdditionalWorksheet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpAdditionalWorksheet.Controls.Add(Me.btnRemoveAdd)
        Me.grpAdditionalWorksheet.Controls.Add(Me.btnAddAdd)
        Me.grpAdditionalWorksheet.Controls.Add(Me.dgAdditional)
        Me.grpAdditionalWorksheet.Location = New System.Drawing.Point(515, 259)
        Me.grpAdditionalWorksheet.Name = "grpAdditionalWorksheet"
        Me.grpAdditionalWorksheet.Size = New System.Drawing.Size(360, 247)
        Me.grpAdditionalWorksheet.TabIndex = 29
        Me.grpAdditionalWorksheet.TabStop = False
        Me.grpAdditionalWorksheet.Text = "Additional Worksheets"
        '
        'btnRemoveAdd
        '
        Me.btnRemoveAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveAdd.Location = New System.Drawing.Point(8, 218)
        Me.btnRemoveAdd.Name = "btnRemoveAdd"
        Me.btnRemoveAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveAdd.TabIndex = 3
        Me.btnRemoveAdd.Text = "Remove"
        '
        'btnAddAdd
        '
        Me.btnAddAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddAdd.Location = New System.Drawing.Point(275, 218)
        Me.btnAddAdd.Name = "btnAddAdd"
        Me.btnAddAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAddAdd.TabIndex = 4
        Me.btnAddAdd.Text = "Add"
        '
        'dgAdditional
        '
        Me.dgAdditional.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAdditional.DataMember = ""
        Me.dgAdditional.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAdditional.Location = New System.Drawing.Point(6, 20)
        Me.dgAdditional.Name = "dgAdditional"
        Me.dgAdditional.Size = New System.Drawing.Size(344, 192)
        Me.dgAdditional.TabIndex = 0
        '
        'grpAlarmInfo
        '
        Me.grpAlarmInfo.Controls.Add(Me.btnRemoveSmokeComo)
        Me.grpAlarmInfo.Controls.Add(Me.btnAddSmokeComo)
        Me.grpAlarmInfo.Controls.Add(Me.DGSmokeComo)
        Me.grpAlarmInfo.Location = New System.Drawing.Point(515, 8)
        Me.grpAlarmInfo.Name = "grpAlarmInfo"
        Me.grpAlarmInfo.Size = New System.Drawing.Size(360, 242)
        Me.grpAlarmInfo.TabIndex = 4
        Me.grpAlarmInfo.TabStop = False
        Me.grpAlarmInfo.Text = "Alarm Info"
        '
        'btnRemoveSmokeComo
        '
        Me.btnRemoveSmokeComo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveSmokeComo.Location = New System.Drawing.Point(12, 202)
        Me.btnRemoveSmokeComo.Name = "btnRemoveSmokeComo"
        Me.btnRemoveSmokeComo.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveSmokeComo.TabIndex = 30
        Me.btnRemoveSmokeComo.Text = "Remove"
        '
        'btnAddSmokeComo
        '
        Me.btnAddSmokeComo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddSmokeComo.Location = New System.Drawing.Point(275, 202)
        Me.btnAddSmokeComo.Name = "btnAddSmokeComo"
        Me.btnAddSmokeComo.Size = New System.Drawing.Size(75, 23)
        Me.btnAddSmokeComo.TabIndex = 31
        Me.btnAddSmokeComo.Text = "Add"
        '
        'DGSmokeComo
        '
        Me.DGSmokeComo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGSmokeComo.DataMember = ""
        Me.DGSmokeComo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DGSmokeComo.Location = New System.Drawing.Point(12, 17)
        Me.DGSmokeComo.Name = "DGSmokeComo"
        Me.DGSmokeComo.Size = New System.Drawing.Size(338, 181)
        Me.DGSmokeComo.TabIndex = 29
        '
        'grpVisitWorksheetExtended
        '
        Me.grpVisitWorksheetExtended.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboSITimer)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboFillDisc)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label81)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label80)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label79)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.txtRadiators)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.txtVisualInspectionReason)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label68)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label69)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label70)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label62)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label63)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label64)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label65)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label66)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label67)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboCertificateTypeID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboCODetectorFittedID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboVisualInspectionSatisfactoryID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboImmersionID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboJacketID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboCylinderTypeID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboPartialHeatingID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboHeatingSystemTypeID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.txtApproxAgeOfBoiler)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboStrainerInspectedID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label56)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label57)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboStrainerFittedID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboInstallationSafeToUseID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboInstallationPipeWorkCorrectID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.cboCorrectMaterialsUsedID)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label58)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label59)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label60)
        Me.grpVisitWorksheetExtended.Controls.Add(Me.Label61)
        Me.grpVisitWorksheetExtended.Location = New System.Drawing.Point(881, 8)
        Me.grpVisitWorksheetExtended.Name = "grpVisitWorksheetExtended"
        Me.grpVisitWorksheetExtended.Size = New System.Drawing.Size(358, 636)
        Me.grpVisitWorksheetExtended.TabIndex = 3
        Me.grpVisitWorksheetExtended.TabStop = False
        Me.grpVisitWorksheetExtended.Text = "Visit Worksheet - Extended"
        '
        'cboSITimer
        '
        Me.cboSITimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSITimer.Location = New System.Drawing.Point(192, 449)
        Me.cboSITimer.Name = "cboSITimer"
        Me.cboSITimer.Size = New System.Drawing.Size(160, 21)
        Me.cboSITimer.TabIndex = 33
        '
        'cboFillDisc
        '
        Me.cboFillDisc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFillDisc.Location = New System.Drawing.Point(192, 422)
        Me.cboFillDisc.Name = "cboFillDisc"
        Me.cboFillDisc.Size = New System.Drawing.Size(160, 21)
        Me.cboFillDisc.TabIndex = 32
        '
        'Label81
        '
        Me.Label81.Location = New System.Drawing.Point(6, 477)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(180, 21)
        Me.Label81.TabIndex = 31
        Me.Label81.Text = "Flue/Tank In loft details"
        '
        'Label80
        '
        Me.Label80.Location = New System.Drawing.Point(6, 423)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(180, 21)
        Me.Label80.TabIndex = 30
        Me.Label80.Text = "Filling Loop Disconnected?"
        '
        'Label79
        '
        Me.Label79.Location = New System.Drawing.Point(6, 449)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(180, 21)
        Me.Label79.TabIndex = 29
        Me.Label79.Text = "SI Timer Reset"
        '
        'txtRadiators
        '
        Me.txtRadiators.Location = New System.Drawing.Point(192, 287)
        Me.txtRadiators.Name = "txtRadiators"
        Me.txtRadiators.Size = New System.Drawing.Size(160, 21)
        Me.txtRadiators.TabIndex = 10
        Me.txtRadiators.Text = "0"
        '
        'txtVisualInspectionReason
        '
        Me.txtVisualInspectionReason.Location = New System.Drawing.Point(192, 476)
        Me.txtVisualInspectionReason.Multiline = True
        Me.txtVisualInspectionReason.Name = "txtVisualInspectionReason"
        Me.txtVisualInspectionReason.Size = New System.Drawing.Size(160, 43)
        Me.txtVisualInspectionReason.TabIndex = 15
        '
        'Label68
        '
        Me.Label68.Location = New System.Drawing.Point(6, 397)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(180, 21)
        Me.Label68.TabIndex = 28
        Me.Label68.Text = "Flue/Tank In Loft Satisfactory" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label69
        '
        Me.Label69.Location = New System.Drawing.Point(6, 371)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(180, 23)
        Me.Label69.TabIndex = 27
        Me.Label69.Text = "Certificate Type"
        '
        'Label70
        '
        Me.Label70.Location = New System.Drawing.Point(6, 344)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(180, 23)
        Me.Label70.TabIndex = 26
        Me.Label70.Text = "Approx. Age Of Boiler"
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(6, 317)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(180, 23)
        Me.Label62.TabIndex = 25
        Me.Label62.Text = "CO Detector Fitted "
        '
        'Label63
        '
        Me.Label63.Location = New System.Drawing.Point(6, 290)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(180, 23)
        Me.Label63.TabIndex = 24
        Me.Label63.Text = "Radiators"
        '
        'Label64
        '
        Me.Label64.Location = New System.Drawing.Point(6, 128)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(180, 23)
        Me.Label64.TabIndex = 23
        Me.Label64.Text = "Is Strainer Inspected"
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(6, 101)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(180, 23)
        Me.Label65.TabIndex = 22
        Me.Label65.Text = "Is Strainer Fitted"
        '
        'Label66
        '
        Me.Label66.Location = New System.Drawing.Point(6, 263)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(180, 23)
        Me.Label66.TabIndex = 21
        Me.Label66.Text = "Immersion"
        '
        'Label67
        '
        Me.Label67.Location = New System.Drawing.Point(6, 236)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(180, 23)
        Me.Label67.TabIndex = 20
        Me.Label67.Text = "Jacket"
        '
        'cboCertificateTypeID
        '
        Me.cboCertificateTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCertificateTypeID.Location = New System.Drawing.Point(192, 368)
        Me.cboCertificateTypeID.Name = "cboCertificateTypeID"
        Me.cboCertificateTypeID.Size = New System.Drawing.Size(160, 21)
        Me.cboCertificateTypeID.TabIndex = 13
        '
        'cboCODetectorFittedID
        '
        Me.cboCODetectorFittedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCODetectorFittedID.Location = New System.Drawing.Point(192, 314)
        Me.cboCODetectorFittedID.Name = "cboCODetectorFittedID"
        Me.cboCODetectorFittedID.Size = New System.Drawing.Size(160, 21)
        Me.cboCODetectorFittedID.TabIndex = 11
        '
        'cboVisualInspectionSatisfactoryID
        '
        Me.cboVisualInspectionSatisfactoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualInspectionSatisfactoryID.Location = New System.Drawing.Point(192, 395)
        Me.cboVisualInspectionSatisfactoryID.Name = "cboVisualInspectionSatisfactoryID"
        Me.cboVisualInspectionSatisfactoryID.Size = New System.Drawing.Size(160, 21)
        Me.cboVisualInspectionSatisfactoryID.TabIndex = 14
        '
        'cboImmersionID
        '
        Me.cboImmersionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImmersionID.Location = New System.Drawing.Point(192, 260)
        Me.cboImmersionID.Name = "cboImmersionID"
        Me.cboImmersionID.Size = New System.Drawing.Size(160, 21)
        Me.cboImmersionID.TabIndex = 9
        '
        'cboJacketID
        '
        Me.cboJacketID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJacketID.Location = New System.Drawing.Point(192, 233)
        Me.cboJacketID.Name = "cboJacketID"
        Me.cboJacketID.Size = New System.Drawing.Size(160, 21)
        Me.cboJacketID.TabIndex = 8
        '
        'cboCylinderTypeID
        '
        Me.cboCylinderTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCylinderTypeID.Location = New System.Drawing.Point(192, 206)
        Me.cboCylinderTypeID.Name = "cboCylinderTypeID"
        Me.cboCylinderTypeID.Size = New System.Drawing.Size(160, 21)
        Me.cboCylinderTypeID.TabIndex = 7
        '
        'cboPartialHeatingID
        '
        Me.cboPartialHeatingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPartialHeatingID.Location = New System.Drawing.Point(192, 179)
        Me.cboPartialHeatingID.Name = "cboPartialHeatingID"
        Me.cboPartialHeatingID.Size = New System.Drawing.Size(160, 21)
        Me.cboPartialHeatingID.TabIndex = 6
        '
        'cboHeatingSystemTypeID
        '
        Me.cboHeatingSystemTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHeatingSystemTypeID.Location = New System.Drawing.Point(192, 152)
        Me.cboHeatingSystemTypeID.Name = "cboHeatingSystemTypeID"
        Me.cboHeatingSystemTypeID.Size = New System.Drawing.Size(160, 21)
        Me.cboHeatingSystemTypeID.TabIndex = 5
        '
        'txtApproxAgeOfBoiler
        '
        Me.txtApproxAgeOfBoiler.Location = New System.Drawing.Point(192, 341)
        Me.txtApproxAgeOfBoiler.Name = "txtApproxAgeOfBoiler"
        Me.txtApproxAgeOfBoiler.Size = New System.Drawing.Size(160, 21)
        Me.txtApproxAgeOfBoiler.TabIndex = 12
        Me.txtApproxAgeOfBoiler.Text = "0"
        '
        'cboStrainerInspectedID
        '
        Me.cboStrainerInspectedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStrainerInspectedID.Location = New System.Drawing.Point(192, 125)
        Me.cboStrainerInspectedID.Name = "cboStrainerInspectedID"
        Me.cboStrainerInspectedID.Size = New System.Drawing.Size(160, 21)
        Me.cboStrainerInspectedID.TabIndex = 4
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(6, 209)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(180, 23)
        Me.Label56.TabIndex = 9
        Me.Label56.Text = "Cylinder type "
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(6, 182)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(180, 23)
        Me.Label57.TabIndex = 8
        Me.Label57.Text = "Partial Heating"
        '
        'cboStrainerFittedID
        '
        Me.cboStrainerFittedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStrainerFittedID.Location = New System.Drawing.Point(192, 98)
        Me.cboStrainerFittedID.Name = "cboStrainerFittedID"
        Me.cboStrainerFittedID.Size = New System.Drawing.Size(160, 21)
        Me.cboStrainerFittedID.TabIndex = 3
        '
        'cboInstallationSafeToUseID
        '
        Me.cboInstallationSafeToUseID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstallationSafeToUseID.Location = New System.Drawing.Point(192, 71)
        Me.cboInstallationSafeToUseID.Name = "cboInstallationSafeToUseID"
        Me.cboInstallationSafeToUseID.Size = New System.Drawing.Size(160, 21)
        Me.cboInstallationSafeToUseID.TabIndex = 2
        '
        'cboInstallationPipeWorkCorrectID
        '
        Me.cboInstallationPipeWorkCorrectID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstallationPipeWorkCorrectID.Location = New System.Drawing.Point(192, 44)
        Me.cboInstallationPipeWorkCorrectID.Name = "cboInstallationPipeWorkCorrectID"
        Me.cboInstallationPipeWorkCorrectID.Size = New System.Drawing.Size(160, 21)
        Me.cboInstallationPipeWorkCorrectID.TabIndex = 1
        '
        'cboCorrectMaterialsUsedID
        '
        Me.cboCorrectMaterialsUsedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorrectMaterialsUsedID.Location = New System.Drawing.Point(192, 17)
        Me.cboCorrectMaterialsUsedID.Name = "cboCorrectMaterialsUsedID"
        Me.cboCorrectMaterialsUsedID.Size = New System.Drawing.Size(160, 21)
        Me.cboCorrectMaterialsUsedID.TabIndex = 0
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(6, 155)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(180, 23)
        Me.Label58.TabIndex = 3
        Me.Label58.Text = "Heating System Type"
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(6, 74)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(180, 23)
        Me.Label59.TabIndex = 2
        Me.Label59.Text = "Installation Safe To Use "
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(6, 47)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(180, 23)
        Me.Label60.TabIndex = 1
        Me.Label60.Text = "Installation Pipework Correct"
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(6, 20)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(180, 23)
        Me.Label61.TabIndex = 0
        Me.Label61.Text = "Correct Materials Used In Installation "
        '
        'grpVisitDefects
        '
        Me.grpVisitDefects.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpVisitDefects.Controls.Add(Me.btnAddVisitDefect)
        Me.grpVisitDefects.Controls.Add(Me.btnRemoveVisitDefect)
        Me.grpVisitDefects.Controls.Add(Me.dgVisitDefects)
        Me.grpVisitDefects.Location = New System.Drawing.Point(8, 503)
        Me.grpVisitDefects.Name = "grpVisitDefects"
        Me.grpVisitDefects.Size = New System.Drawing.Size(501, 141)
        Me.grpVisitDefects.TabIndex = 2
        Me.grpVisitDefects.TabStop = False
        Me.grpVisitDefects.Text = "Visit Defects"
        '
        'btnAddVisitDefect
        '
        Me.btnAddVisitDefect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddVisitDefect.Location = New System.Drawing.Point(421, 109)
        Me.btnAddVisitDefect.Name = "btnAddVisitDefect"
        Me.btnAddVisitDefect.Size = New System.Drawing.Size(75, 23)
        Me.btnAddVisitDefect.TabIndex = 3
        Me.btnAddVisitDefect.Text = "Add"
        '
        'btnRemoveVisitDefect
        '
        Me.btnRemoveVisitDefect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveVisitDefect.Location = New System.Drawing.Point(8, 109)
        Me.btnRemoveVisitDefect.Name = "btnRemoveVisitDefect"
        Me.btnRemoveVisitDefect.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveVisitDefect.TabIndex = 2
        Me.btnRemoveVisitDefect.Text = "Remove"
        '
        'dgVisitDefects
        '
        Me.dgVisitDefects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVisitDefects.DataMember = ""
        Me.dgVisitDefects.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVisitDefects.Location = New System.Drawing.Point(8, 20)
        Me.dgVisitDefects.Name = "dgVisitDefects"
        Me.dgVisitDefects.Size = New System.Drawing.Size(485, 83)
        Me.dgVisitDefects.TabIndex = 1
        '
        'grpApplianceWorksheet
        '
        Me.grpApplianceWorksheet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpApplianceWorksheet.Controls.Add(Me.btnRemoveApplianceWorkSheet)
        Me.grpApplianceWorksheet.Controls.Add(Me.dgApplianceWorkSheets)
        Me.grpApplianceWorksheet.Controls.Add(Me.btnAddApplianceWorksheet)
        Me.grpApplianceWorksheet.Location = New System.Drawing.Point(8, 256)
        Me.grpApplianceWorksheet.Name = "grpApplianceWorksheet"
        Me.grpApplianceWorksheet.Size = New System.Drawing.Size(501, 247)
        Me.grpApplianceWorksheet.TabIndex = 1
        Me.grpApplianceWorksheet.TabStop = False
        Me.grpApplianceWorksheet.Text = "Appliance Worksheets"
        '
        'btnRemoveApplianceWorkSheet
        '
        Me.btnRemoveApplianceWorkSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveApplianceWorkSheet.Location = New System.Drawing.Point(8, 218)
        Me.btnRemoveApplianceWorkSheet.Name = "btnRemoveApplianceWorkSheet"
        Me.btnRemoveApplianceWorkSheet.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveApplianceWorkSheet.TabIndex = 3
        Me.btnRemoveApplianceWorkSheet.Text = "Remove"
        '
        'dgApplianceWorkSheets
        '
        Me.dgApplianceWorkSheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgApplianceWorkSheets.DataMember = ""
        Me.dgApplianceWorkSheets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgApplianceWorkSheets.Location = New System.Drawing.Point(8, 20)
        Me.dgApplianceWorkSheets.Name = "dgApplianceWorkSheets"
        Me.dgApplianceWorkSheets.Size = New System.Drawing.Size(485, 192)
        Me.dgApplianceWorkSheets.TabIndex = 0
        '
        'btnAddApplianceWorksheet
        '
        Me.btnAddApplianceWorksheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddApplianceWorksheet.Location = New System.Drawing.Point(413, 218)
        Me.btnAddApplianceWorksheet.Name = "btnAddApplianceWorksheet"
        Me.btnAddApplianceWorksheet.Size = New System.Drawing.Size(75, 23)
        Me.btnAddApplianceWorksheet.TabIndex = 4
        Me.btnAddApplianceWorksheet.Text = "Add"
        '
        'grpVisitWorksheet
        '
        Me.grpVisitWorksheet.Controls.Add(Me.cboMeterCapped)
        Me.grpVisitWorksheet.Controls.Add(Me.Label73)
        Me.grpVisitWorksheet.Controls.Add(Me.cboMeterLocation)
        Me.grpVisitWorksheet.Controls.Add(Me.Label72)
        Me.grpVisitWorksheet.Controls.Add(Me.txtAmountCollected)
        Me.grpVisitWorksheet.Controls.Add(Me.cboPaymentMethod)
        Me.grpVisitWorksheet.Controls.Add(Me.Label44)
        Me.grpVisitWorksheet.Controls.Add(Me.Label43)
        Me.grpVisitWorksheet.Controls.Add(Me.cboPropertyRented)
        Me.grpVisitWorksheet.Controls.Add(Me.cboBonding)
        Me.grpVisitWorksheet.Controls.Add(Me.cboEmergencyControlAccessible)
        Me.grpVisitWorksheet.Controls.Add(Me.cboGasInstallationTightnessTest)
        Me.grpVisitWorksheet.Controls.Add(Me.Label41)
        Me.grpVisitWorksheet.Controls.Add(Me.Label40)
        Me.grpVisitWorksheet.Controls.Add(Me.Label8)
        Me.grpVisitWorksheet.Controls.Add(Me.Label7)
        Me.grpVisitWorksheet.Location = New System.Drawing.Point(8, 8)
        Me.grpVisitWorksheet.Name = "grpVisitWorksheet"
        Me.grpVisitWorksheet.Size = New System.Drawing.Size(501, 242)
        Me.grpVisitWorksheet.TabIndex = 0
        Me.grpVisitWorksheet.TabStop = False
        Me.grpVisitWorksheet.Text = "Visit Worksheet"
        '
        'cboMeterCapped
        '
        Me.cboMeterCapped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMeterCapped.Location = New System.Drawing.Point(216, 211)
        Me.cboMeterCapped.Name = "cboMeterCapped"
        Me.cboMeterCapped.Size = New System.Drawing.Size(276, 21)
        Me.cboMeterCapped.TabIndex = 15
        '
        'Label73
        '
        Me.Label73.Location = New System.Drawing.Point(16, 214)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(120, 23)
        Me.Label73.TabIndex = 14
        Me.Label73.Text = "Meter Capped"
        '
        'cboMeterLocation
        '
        Me.cboMeterLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMeterLocation.Location = New System.Drawing.Point(216, 182)
        Me.cboMeterLocation.Name = "cboMeterLocation"
        Me.cboMeterLocation.Size = New System.Drawing.Size(276, 21)
        Me.cboMeterLocation.TabIndex = 13
        '
        'Label72
        '
        Me.Label72.Location = New System.Drawing.Point(16, 185)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(120, 23)
        Me.Label72.TabIndex = 12
        Me.Label72.Text = "Meter Location"
        '
        'txtAmountCollected
        '
        Me.txtAmountCollected.Location = New System.Drawing.Point(216, 155)
        Me.txtAmountCollected.Name = "txtAmountCollected"
        Me.txtAmountCollected.Size = New System.Drawing.Size(276, 21)
        Me.txtAmountCollected.TabIndex = 11
        '
        'cboPaymentMethod
        '
        Me.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMethod.Location = New System.Drawing.Point(216, 128)
        Me.cboPaymentMethod.Name = "cboPaymentMethod"
        Me.cboPaymentMethod.Size = New System.Drawing.Size(276, 21)
        Me.cboPaymentMethod.TabIndex = 10
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(16, 158)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(120, 23)
        Me.Label44.TabIndex = 9
        Me.Label44.Text = "Amount Collected"
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(16, 131)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(100, 23)
        Me.Label43.TabIndex = 8
        Me.Label43.Text = "Payment Method"
        '
        'cboPropertyRented
        '
        Me.cboPropertyRented.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropertyRented.Location = New System.Drawing.Point(216, 101)
        Me.cboPropertyRented.Name = "cboPropertyRented"
        Me.cboPropertyRented.Size = New System.Drawing.Size(276, 21)
        Me.cboPropertyRented.TabIndex = 7
        '
        'cboBonding
        '
        Me.cboBonding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBonding.Location = New System.Drawing.Point(216, 74)
        Me.cboBonding.Name = "cboBonding"
        Me.cboBonding.Size = New System.Drawing.Size(276, 21)
        Me.cboBonding.TabIndex = 6
        '
        'cboEmergencyControlAccessible
        '
        Me.cboEmergencyControlAccessible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmergencyControlAccessible.Location = New System.Drawing.Point(216, 47)
        Me.cboEmergencyControlAccessible.Name = "cboEmergencyControlAccessible"
        Me.cboEmergencyControlAccessible.Size = New System.Drawing.Size(276, 21)
        Me.cboEmergencyControlAccessible.TabIndex = 5
        '
        'cboGasInstallationTightnessTest
        '
        Me.cboGasInstallationTightnessTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGasInstallationTightnessTest.Location = New System.Drawing.Point(216, 20)
        Me.cboGasInstallationTightnessTest.Name = "cboGasInstallationTightnessTest"
        Me.cboGasInstallationTightnessTest.Size = New System.Drawing.Size(276, 21)
        Me.cboGasInstallationTightnessTest.TabIndex = 4
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(16, 104)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(128, 23)
        Me.Label41.TabIndex = 3
        Me.Label41.Text = "Property Rented"
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(16, 77)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(64, 23)
        Me.Label40.TabIndex = 2
        Me.Label40.Text = "Bonding"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 23)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Emergency Control Accessible"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Gas Installation Tightness Test"
        '
        'tpTimesheets
        '
        Me.tpTimesheets.Controls.Add(Me.grpTimesheets)
        Me.tpTimesheets.Controls.Add(Me.txtScheduledTime)
        Me.tpTimesheets.Controls.Add(Me.Label10)
        Me.tpTimesheets.Location = New System.Drawing.Point(4, 22)
        Me.tpTimesheets.Name = "tpTimesheets"
        Me.tpTimesheets.Size = New System.Drawing.Size(1247, 652)
        Me.tpTimesheets.TabIndex = 2
        Me.tpTimesheets.Text = "Timesheets"
        Me.tpTimesheets.UseVisualStyleBackColor = True
        '
        'grpTimesheets
        '
        Me.grpTimesheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTimesheets.Controls.Add(Me.txtActualTimeSpent)
        Me.grpTimesheets.Controls.Add(Me.txtDifference)
        Me.grpTimesheets.Controls.Add(Me.txtSORTimeAllowance)
        Me.grpTimesheets.Controls.Add(Me.Label52)
        Me.grpTimesheets.Controls.Add(Me.Label51)
        Me.grpTimesheets.Controls.Add(Me.Label50)
        Me.grpTimesheets.Controls.Add(Me.Label22)
        Me.grpTimesheets.Controls.Add(Me.cboTimeSheetType)
        Me.grpTimesheets.Controls.Add(Me.Label14)
        Me.grpTimesheets.Controls.Add(Me.txtComments)
        Me.grpTimesheets.Controls.Add(Me.dtpEndDate)
        Me.grpTimesheets.Controls.Add(Me.dtpStartDate)
        Me.grpTimesheets.Controls.Add(Me.dgTimeSheets)
        Me.grpTimesheets.Controls.Add(Me.btnAddTimeSheet)
        Me.grpTimesheets.Controls.Add(Me.Label20)
        Me.grpTimesheets.Controls.Add(Me.Label21)
        Me.grpTimesheets.Controls.Add(Me.btnRemoveTimeSheet)
        Me.grpTimesheets.Location = New System.Drawing.Point(8, 48)
        Me.grpTimesheets.Name = "grpTimesheets"
        Me.grpTimesheets.Size = New System.Drawing.Size(1231, 598)
        Me.grpTimesheets.TabIndex = 3
        Me.grpTimesheets.TabStop = False
        Me.grpTimesheets.Text = "TimeSheets"
        '
        'txtActualTimeSpent
        '
        Me.txtActualTimeSpent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtActualTimeSpent.Location = New System.Drawing.Point(348, 541)
        Me.txtActualTimeSpent.Name = "txtActualTimeSpent"
        Me.txtActualTimeSpent.ReadOnly = True
        Me.txtActualTimeSpent.Size = New System.Drawing.Size(136, 21)
        Me.txtActualTimeSpent.TabIndex = 70
        '
        'txtDifference
        '
        Me.txtDifference.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDifference.Location = New System.Drawing.Point(348, 571)
        Me.txtDifference.Name = "txtDifference"
        Me.txtDifference.ReadOnly = True
        Me.txtDifference.Size = New System.Drawing.Size(136, 21)
        Me.txtDifference.TabIndex = 72
        '
        'txtSORTimeAllowance
        '
        Me.txtSORTimeAllowance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSORTimeAllowance.Location = New System.Drawing.Point(348, 509)
        Me.txtSORTimeAllowance.Name = "txtSORTimeAllowance"
        Me.txtSORTimeAllowance.ReadOnly = True
        Me.txtSORTimeAllowance.Size = New System.Drawing.Size(136, 21)
        Me.txtSORTimeAllowance.TabIndex = 68
        '
        'Label52
        '
        Me.Label52.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(203, 577)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(71, 13)
        Me.Label52.TabIndex = 71
        Me.Label52.Text = "Difference:"
        '
        'Label51
        '
        Me.Label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(203, 544)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(103, 13)
        Me.Label51.TabIndex = 69
        Me.Label51.Text = "Act. Time Spent:"
        '
        'Label50
        '
        Me.Label50.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(203, 512)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(130, 13)
        Me.Label50.TabIndex = 67
        Me.Label50.Text = "SOR Time Allowance:"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.Location = New System.Drawing.Point(506, 512)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 23)
        Me.Label22.TabIndex = 66
        Me.Label22.Text = "Comments"
        '
        'cboTimeSheetType
        '
        Me.cboTimeSheetType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboTimeSheetType.Location = New System.Drawing.Point(46, 509)
        Me.cboTimeSheetType.Name = "cboTimeSheetType"
        Me.cboTimeSheetType.Size = New System.Drawing.Size(136, 21)
        Me.cboTimeSheetType.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.Location = New System.Drawing.Point(5, 512)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 23)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "Type"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(584, 509)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(404, 83)
        Me.txtComments.TabIndex = 4
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(46, 571)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpEndDate.TabIndex = 2
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(46, 540)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpStartDate.TabIndex = 1
        '
        'dgTimeSheets
        '
        Me.dgTimeSheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTimeSheets.DataMember = ""
        Me.dgTimeSheets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTimeSheets.Location = New System.Drawing.Point(8, 30)
        Me.dgTimeSheets.Name = "dgTimeSheets"
        Me.dgTimeSheets.Size = New System.Drawing.Size(1215, 466)
        Me.dgTimeSheets.TabIndex = 7
        Me.dgTimeSheets.TabStop = False
        '
        'btnAddTimeSheet
        '
        Me.btnAddTimeSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTimeSheet.Location = New System.Drawing.Point(1151, 569)
        Me.btnAddTimeSheet.Name = "btnAddTimeSheet"
        Me.btnAddTimeSheet.Size = New System.Drawing.Size(72, 23)
        Me.btnAddTimeSheet.TabIndex = 5
        Me.btnAddTimeSheet.Text = "Add"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.Location = New System.Drawing.Point(5, 573)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 23)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "End"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.Location = New System.Drawing.Point(5, 544)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 23)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Start Date/Time"
        '
        'btnRemoveTimeSheet
        '
        Me.btnRemoveTimeSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTimeSheet.Location = New System.Drawing.Point(1151, 534)
        Me.btnRemoveTimeSheet.Name = "btnRemoveTimeSheet"
        Me.btnRemoveTimeSheet.Size = New System.Drawing.Size(72, 23)
        Me.btnRemoveTimeSheet.TabIndex = 6
        Me.btnRemoveTimeSheet.Text = "Remove"
        '
        'txtScheduledTime
        '
        Me.txtScheduledTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScheduledTime.Location = New System.Drawing.Point(112, 16)
        Me.txtScheduledTime.Name = "txtScheduledTime"
        Me.txtScheduledTime.ReadOnly = True
        Me.txtScheduledTime.Size = New System.Drawing.Size(1127, 21)
        Me.txtScheduledTime.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Scheduled time"
        '
        'tpPartsAndProducts
        '
        Me.tpPartsAndProducts.Controls.Add(Me.grpAllocated)
        Me.tpPartsAndProducts.Controls.Add(Me.grpUsed)
        Me.tpPartsAndProducts.Location = New System.Drawing.Point(4, 22)
        Me.tpPartsAndProducts.Name = "tpPartsAndProducts"
        Me.tpPartsAndProducts.Size = New System.Drawing.Size(1247, 652)
        Me.tpPartsAndProducts.TabIndex = 1
        Me.tpPartsAndProducts.Text = "Parts && Products"
        Me.tpPartsAndProducts.UseVisualStyleBackColor = True
        '
        'grpAllocated
        '
        Me.grpAllocated.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAllocated.Controls.Add(Me.btnUnselectAllPPA)
        Me.grpAllocated.Controls.Add(Me.btnSelectAllPPA)
        Me.grpAllocated.Controls.Add(Me.btnRevertUsed)
        Me.grpAllocated.Controls.Add(Me.nudPartAllocatedQty)
        Me.grpAllocated.Controls.Add(Me.lblAllocatedQuantity)
        Me.grpAllocated.Controls.Add(Me.btnAllUsed)
        Me.grpAllocated.Controls.Add(Me.Label35)
        Me.grpAllocated.Controls.Add(Me.Panel2)
        Me.grpAllocated.Controls.Add(Me.Label34)
        Me.grpAllocated.Controls.Add(Me.Panel1)
        Me.grpAllocated.Controls.Add(Me.btnAllocatedNotUsed)
        Me.grpAllocated.Controls.Add(Me.dgPartsProductsAllocated)
        Me.grpAllocated.Controls.Add(Me.lblQuantityWarning)
        Me.grpAllocated.Location = New System.Drawing.Point(8, 8)
        Me.grpAllocated.Name = "grpAllocated"
        Me.grpAllocated.Size = New System.Drawing.Size(1231, 275)
        Me.grpAllocated.TabIndex = 1
        Me.grpAllocated.TabStop = False
        Me.grpAllocated.Text = "Parts && Products Allocated"
        '
        'btnUnselectAllPPA
        '
        Me.btnUnselectAllPPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUnselectAllPPA.Location = New System.Drawing.Point(438, 244)
        Me.btnUnselectAllPPA.Name = "btnUnselectAllPPA"
        Me.btnUnselectAllPPA.Size = New System.Drawing.Size(98, 23)
        Me.btnUnselectAllPPA.TabIndex = 34
        Me.btnUnselectAllPPA.Text = "Deselect All"
        '
        'btnSelectAllPPA
        '
        Me.btnSelectAllPPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAllPPA.Location = New System.Drawing.Point(334, 244)
        Me.btnSelectAllPPA.Name = "btnSelectAllPPA"
        Me.btnSelectAllPPA.Size = New System.Drawing.Size(98, 23)
        Me.btnSelectAllPPA.TabIndex = 33
        Me.btnSelectAllPPA.Text = "Select All"
        '
        'btnRevertUsed
        '
        Me.btnRevertUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRevertUsed.Location = New System.Drawing.Point(234, 244)
        Me.btnRevertUsed.Name = "btnRevertUsed"
        Me.btnRevertUsed.Size = New System.Drawing.Size(96, 23)
        Me.btnRevertUsed.TabIndex = 32
        Me.btnRevertUsed.Text = "Revert Used"
        '
        'nudPartAllocatedQty
        '
        Me.nudPartAllocatedQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudPartAllocatedQty.Location = New System.Drawing.Point(937, 243)
        Me.nudPartAllocatedQty.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudPartAllocatedQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPartAllocatedQty.Name = "nudPartAllocatedQty"
        Me.nudPartAllocatedQty.Size = New System.Drawing.Size(64, 21)
        Me.nudPartAllocatedQty.TabIndex = 29
        Me.nudPartAllocatedQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblAllocatedQuantity
        '
        Me.lblAllocatedQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAllocatedQuantity.Location = New System.Drawing.Point(873, 243)
        Me.lblAllocatedQuantity.Name = "lblAllocatedQuantity"
        Me.lblAllocatedQuantity.Size = New System.Drawing.Size(64, 23)
        Me.lblAllocatedQuantity.TabIndex = 30
        Me.lblAllocatedQuantity.Text = "Quantity"
        '
        'btnAllUsed
        '
        Me.btnAllUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllUsed.Location = New System.Drawing.Point(1015, 243)
        Me.btnAllUsed.Name = "btnAllUsed"
        Me.btnAllUsed.Size = New System.Drawing.Size(96, 23)
        Me.btnAllUsed.TabIndex = 2
        Me.btnAllUsed.Text = "Used"
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label35.Location = New System.Drawing.Point(160, 249)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(104, 16)
        Me.Label35.TabIndex = 28
        Me.Label35.Text = "Distributed"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Lime
        Me.Panel2.Location = New System.Drawing.Point(136, 247)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 16)
        Me.Panel2.TabIndex = 27
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label34.Location = New System.Drawing.Point(32, 249)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(104, 16)
        Me.Label34.TabIndex = 26
        Me.Label34.Text = "Not Distributed"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Location = New System.Drawing.Point(8, 246)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(16, 16)
        Me.Panel1.TabIndex = 25
        '
        'btnAllocatedNotUsed
        '
        Me.btnAllocatedNotUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllocatedNotUsed.Location = New System.Drawing.Point(1119, 243)
        Me.btnAllocatedNotUsed.Name = "btnAllocatedNotUsed"
        Me.btnAllocatedNotUsed.Size = New System.Drawing.Size(96, 23)
        Me.btnAllocatedNotUsed.TabIndex = 3
        Me.btnAllocatedNotUsed.Text = "Not Used"
        '
        'dgPartsProductsAllocated
        '
        Me.dgPartsProductsAllocated.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPartsProductsAllocated.DataMember = ""
        Me.dgPartsProductsAllocated.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartsProductsAllocated.Location = New System.Drawing.Point(8, 18)
        Me.dgPartsProductsAllocated.Name = "dgPartsProductsAllocated"
        Me.dgPartsProductsAllocated.Size = New System.Drawing.Size(1215, 222)
        Me.dgPartsProductsAllocated.TabIndex = 1
        Me.dgPartsProductsAllocated.TabStop = False
        '
        'lblQuantityWarning
        '
        Me.lblQuantityWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuantityWarning.AutoSize = True
        Me.lblQuantityWarning.Location = New System.Drawing.Point(603, 249)
        Me.lblQuantityWarning.Name = "lblQuantityWarning"
        Me.lblQuantityWarning.Size = New System.Drawing.Size(241, 13)
        Me.lblQuantityWarning.TabIndex = 31
        Me.lblQuantityWarning.Text = "The quantity ordered will be carried over"
        Me.lblQuantityWarning.Visible = False
        '
        'grpUsed
        '
        Me.grpUsed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpUsed.Controls.Add(Me.lblEquipment)
        Me.grpUsed.Controls.Add(Me.lblSellPrice)
        Me.grpUsed.Controls.Add(Me.dgPartsAndProductsUsed)
        Me.grpUsed.Controls.Add(Me.btnAddPartProductUsed)
        Me.grpUsed.Controls.Add(Me.nudQuantityUsed)
        Me.grpUsed.Controls.Add(Me.txtNameUsed)
        Me.grpUsed.Controls.Add(Me.txtNumberUsed)
        Me.grpUsed.Controls.Add(Me.Label13)
        Me.grpUsed.Controls.Add(Me.Label15)
        Me.grpUsed.Controls.Add(Me.Label16)
        Me.grpUsed.Controls.Add(Me.btnRemovePartProductUsed)
        Me.grpUsed.Controls.Add(Me.btnFindProductUsed)
        Me.grpUsed.Controls.Add(Me.btnFindPartUsed)
        Me.grpUsed.Location = New System.Drawing.Point(8, 289)
        Me.grpUsed.Name = "grpUsed"
        Me.grpUsed.Size = New System.Drawing.Size(1231, 360)
        Me.grpUsed.TabIndex = 2
        Me.grpUsed.TabStop = False
        Me.grpUsed.Text = "Parts && Products Used"
        '
        'lblEquipment
        '
        Me.lblEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEquipment.Location = New System.Drawing.Point(853, 296)
        Me.lblEquipment.Name = "lblEquipment"
        Me.lblEquipment.Size = New System.Drawing.Size(100, 23)
        Me.lblEquipment.TabIndex = 24
        Me.lblEquipment.Text = "Equipment?"
        Me.lblEquipment.Visible = False
        '
        'lblSellPrice
        '
        Me.lblSellPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSellPrice.Location = New System.Drawing.Point(1007, 296)
        Me.lblSellPrice.Name = "lblSellPrice"
        Me.lblSellPrice.Size = New System.Drawing.Size(100, 23)
        Me.lblSellPrice.TabIndex = 23
        Me.lblSellPrice.Text = "SELL PRICE"
        Me.lblSellPrice.Visible = False
        '
        'dgPartsAndProductsUsed
        '
        Me.dgPartsAndProductsUsed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPartsAndProductsUsed.DataMember = ""
        Me.dgPartsAndProductsUsed.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartsAndProductsUsed.Location = New System.Drawing.Point(8, 13)
        Me.dgPartsAndProductsUsed.Name = "dgPartsAndProductsUsed"
        Me.dgPartsAndProductsUsed.Size = New System.Drawing.Size(1215, 283)
        Me.dgPartsAndProductsUsed.TabIndex = 1
        Me.dgPartsAndProductsUsed.TabStop = False
        '
        'btnAddPartProductUsed
        '
        Me.btnAddPartProductUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddPartProductUsed.Enabled = False
        Me.btnAddPartProductUsed.Location = New System.Drawing.Point(1119, 328)
        Me.btnAddPartProductUsed.Name = "btnAddPartProductUsed"
        Me.btnAddPartProductUsed.Size = New System.Drawing.Size(96, 23)
        Me.btnAddPartProductUsed.TabIndex = 5
        Me.btnAddPartProductUsed.Text = "PICK ITEM"
        '
        'nudQuantityUsed
        '
        Me.nudQuantityUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudQuantityUsed.Location = New System.Drawing.Point(1047, 328)
        Me.nudQuantityUsed.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudQuantityUsed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQuantityUsed.Name = "nudQuantityUsed"
        Me.nudQuantityUsed.Size = New System.Drawing.Size(64, 21)
        Me.nudQuantityUsed.TabIndex = 4
        Me.nudQuantityUsed.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtNameUsed
        '
        Me.txtNameUsed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNameUsed.Location = New System.Drawing.Point(312, 328)
        Me.txtNameUsed.Name = "txtNameUsed"
        Me.txtNameUsed.ReadOnly = True
        Me.txtNameUsed.Size = New System.Drawing.Size(671, 21)
        Me.txtNameUsed.TabIndex = 8
        '
        'txtNumberUsed
        '
        Me.txtNumberUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNumberUsed.Location = New System.Drawing.Point(72, 328)
        Me.txtNumberUsed.Name = "txtNumberUsed"
        Me.txtNumberUsed.ReadOnly = True
        Me.txtNumberUsed.Size = New System.Drawing.Size(184, 21)
        Me.txtNumberUsed.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Location = New System.Drawing.Point(983, 328)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 23)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Quantity"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(264, 328)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 23)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Name"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.Location = New System.Drawing.Point(8, 328)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Number"
        '
        'btnRemovePartProductUsed
        '
        Me.btnRemovePartProductUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemovePartProductUsed.Location = New System.Drawing.Point(1119, 296)
        Me.btnRemovePartProductUsed.Name = "btnRemovePartProductUsed"
        Me.btnRemovePartProductUsed.Size = New System.Drawing.Size(96, 23)
        Me.btnRemovePartProductUsed.TabIndex = 6
        Me.btnRemovePartProductUsed.Text = "Remove"
        '
        'btnFindProductUsed
        '
        Me.btnFindProductUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindProductUsed.Location = New System.Drawing.Point(104, 296)
        Me.btnFindProductUsed.Name = "btnFindProductUsed"
        Me.btnFindProductUsed.Size = New System.Drawing.Size(88, 23)
        Me.btnFindProductUsed.TabIndex = 3
        Me.btnFindProductUsed.Text = "Find Product"
        '
        'btnFindPartUsed
        '
        Me.btnFindPartUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindPartUsed.Location = New System.Drawing.Point(8, 296)
        Me.btnFindPartUsed.Name = "btnFindPartUsed"
        Me.btnFindPartUsed.Size = New System.Drawing.Size(88, 23)
        Me.btnFindPartUsed.TabIndex = 2
        Me.btnFindPartUsed.Text = "Find Part"
        '
        'tpOutcomes
        '
        Me.tpOutcomes.Controls.Add(Me.grpOutcomes)
        Me.tpOutcomes.Location = New System.Drawing.Point(4, 22)
        Me.tpOutcomes.Name = "tpOutcomes"
        Me.tpOutcomes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOutcomes.Size = New System.Drawing.Size(1247, 652)
        Me.tpOutcomes.TabIndex = 7
        Me.tpOutcomes.Text = "Outcomes"
        Me.tpOutcomes.UseVisualStyleBackColor = True
        '
        'grpOutcomes
        '
        Me.grpOutcomes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOutcomes.Controls.Add(Me.grpSiteFuels)
        Me.grpOutcomes.Controls.Add(Me.cboNccRad)
        Me.grpOutcomes.Controls.Add(Me.Label76)
        Me.grpOutcomes.Controls.Add(Me.cboRecharge)
        Me.grpOutcomes.Controls.Add(Me.Label75)
        Me.grpOutcomes.Controls.Add(Me.chkRecharge)
        Me.grpOutcomes.Controls.Add(Me.chkGasServiceCompleted)
        Me.grpOutcomes.Location = New System.Drawing.Point(8, 6)
        Me.grpOutcomes.Name = "grpOutcomes"
        Me.grpOutcomes.Size = New System.Drawing.Size(1231, 640)
        Me.grpOutcomes.TabIndex = 2
        Me.grpOutcomes.TabStop = False
        Me.grpOutcomes.Text = "Tick those that have been completed on this visit"
        '
        'grpSiteFuels
        '
        Me.grpSiteFuels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteFuels.Controls.Add(Me.dgSiteFuel)
        Me.grpSiteFuels.Location = New System.Drawing.Point(3, 17)
        Me.grpSiteFuels.Margin = New System.Windows.Forms.Padding(0)
        Me.grpSiteFuels.Name = "grpSiteFuels"
        Me.grpSiteFuels.Padding = New System.Windows.Forms.Padding(0)
        Me.grpSiteFuels.Size = New System.Drawing.Size(437, 390)
        Me.grpSiteFuels.TabIndex = 15
        Me.grpSiteFuels.TabStop = False
        Me.grpSiteFuels.Text = "Site Fuel"
        '
        'dgSiteFuel
        '
        Me.dgSiteFuel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSiteFuel.DataMember = ""
        Me.dgSiteFuel.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSiteFuel.Location = New System.Drawing.Point(5, 19)
        Me.dgSiteFuel.Name = "dgSiteFuel"
        Me.dgSiteFuel.Size = New System.Drawing.Size(429, 366)
        Me.dgSiteFuel.TabIndex = 11
        '
        'cboNccRad
        '
        Me.cboNccRad.FormattingEnabled = True
        Me.cboNccRad.Location = New System.Drawing.Point(649, 108)
        Me.cboNccRad.Name = "cboNccRad"
        Me.cboNccRad.Size = New System.Drawing.Size(180, 21)
        Me.cboNccRad.TabIndex = 9
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(458, 111)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(172, 13)
        Me.Label76.TabIndex = 8
        Me.Label76.Text = "Ncc Radiator Removal / Refit"
        '
        'cboRecharge
        '
        Me.cboRecharge.FormattingEnabled = True
        Me.cboRecharge.Location = New System.Drawing.Point(649, 81)
        Me.cboRecharge.Name = "cboRecharge"
        Me.cboRecharge.Size = New System.Drawing.Size(180, 21)
        Me.cboRecharge.TabIndex = 7
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(458, 84)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(83, 13)
        Me.Label75.TabIndex = 6
        Me.Label75.Text = "Recharge To:"
        '
        'chkRecharge
        '
        Me.chkRecharge.AutoSize = True
        Me.chkRecharge.Location = New System.Drawing.Point(458, 59)
        Me.chkRecharge.Name = "chkRecharge"
        Me.chkRecharge.Size = New System.Drawing.Size(80, 17)
        Me.chkRecharge.TabIndex = 2
        Me.chkRecharge.Text = "Recharge"
        Me.chkRecharge.UseVisualStyleBackColor = True
        '
        'chkGasServiceCompleted
        '
        Me.chkGasServiceCompleted.AutoSize = True
        Me.chkGasServiceCompleted.Location = New System.Drawing.Point(458, 36)
        Me.chkGasServiceCompleted.Name = "chkGasServiceCompleted"
        Me.chkGasServiceCompleted.Size = New System.Drawing.Size(135, 17)
        Me.chkGasServiceCompleted.TabIndex = 1
        Me.chkGasServiceCompleted.Text = "Service Completed"
        Me.chkGasServiceCompleted.UseVisualStyleBackColor = True
        '
        'tpQC
        '
        Me.tpQC.Controls.Add(Me.GroupBox4)
        Me.tpQC.Location = New System.Drawing.Point(4, 22)
        Me.tpQC.Name = "tpQC"
        Me.tpQC.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQC.Size = New System.Drawing.Size(1247, 652)
        Me.tpQC.TabIndex = 8
        Me.tpQC.Text = "QC"
        Me.tpQC.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.grpQCField)
        Me.GroupBox4.Controls.Add(Me.grpOfficeQC)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1235, 646)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "QC"
        '
        'grpQCField
        '
        Me.grpQCField.Controls.Add(Me.cboQCCustSig)
        Me.grpQCField.Controls.Add(Me.lblQCCustSig)
        Me.grpQCField.Controls.Add(Me.cboRecallEngineer)
        Me.grpQCField.Controls.Add(Me.Label49)
        Me.grpQCField.Controls.Add(Me.cboRecall)
        Me.grpQCField.Controls.Add(Me.Label48)
        Me.grpQCField.Controls.Add(Me.dtpQCDocumentsRecieved)
        Me.grpQCField.Controls.Add(Me.chkQCDocumentsRecieved)
        Me.grpQCField.Controls.Add(Me.txtQCPoorJobNotes)
        Me.grpQCField.Controls.Add(Me.lblQCPoorJobNotes)
        Me.grpQCField.Controls.Add(Me.cboQCEngineerPaymentRecieved)
        Me.grpQCField.Controls.Add(Me.lblQCEngineerMonies)
        Me.grpQCField.Controls.Add(Me.cboQCPaymentSelection)
        Me.grpQCField.Controls.Add(Me.lblQCEngPaymentMethod)
        Me.grpQCField.Controls.Add(Me.cboQCAppliance)
        Me.grpQCField.Controls.Add(Me.cboQCPaymentCollection)
        Me.grpQCField.Controls.Add(Me.lblQCPaymentCollection)
        Me.grpQCField.Controls.Add(Me.cboQCJobUploadTimescale)
        Me.grpQCField.Controls.Add(Me.lblQCAppliance)
        Me.grpQCField.Controls.Add(Me.cboQCParts)
        Me.grpQCField.Controls.Add(Me.lblJobUploadTimescale)
        Me.grpQCField.Controls.Add(Me.lblQCParts)
        Me.grpQCField.Controls.Add(Me.cboQCLGSR)
        Me.grpQCField.Controls.Add(Me.lblQCLGSR)
        Me.grpQCField.Controls.Add(Me.cboQCLabourTime)
        Me.grpQCField.Controls.Add(Me.lblQCLabourTime)
        Me.grpQCField.Location = New System.Drawing.Point(9, 158)
        Me.grpQCField.Name = "grpQCField"
        Me.grpQCField.Size = New System.Drawing.Size(1220, 342)
        Me.grpQCField.TabIndex = 38
        Me.grpQCField.TabStop = False
        Me.grpQCField.Text = "Field"
        '
        'cboQCCustSig
        '
        Me.cboQCCustSig.FormattingEnabled = True
        Me.cboQCCustSig.Location = New System.Drawing.Point(251, 198)
        Me.cboQCCustSig.Name = "cboQCCustSig"
        Me.cboQCCustSig.Size = New System.Drawing.Size(277, 21)
        Me.cboQCCustSig.TabIndex = 84
        '
        'lblQCCustSig
        '
        Me.lblQCCustSig.AutoSize = True
        Me.lblQCCustSig.Location = New System.Drawing.Point(12, 201)
        Me.lblQCCustSig.Name = "lblQCCustSig"
        Me.lblQCCustSig.Size = New System.Drawing.Size(111, 13)
        Me.lblQCCustSig.TabIndex = 83
        Me.lblQCCustSig.Text = "Customer Signed:"
        '
        'cboRecallEngineer
        '
        Me.cboRecallEngineer.FormattingEnabled = True
        Me.cboRecallEngineer.Location = New System.Drawing.Point(847, 27)
        Me.cboRecallEngineer.Name = "cboRecallEngineer"
        Me.cboRecallEngineer.Size = New System.Drawing.Size(353, 21)
        Me.cboRecallEngineer.TabIndex = 82
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(584, 27)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(100, 13)
        Me.Label49.TabIndex = 81
        Me.Label49.Text = "Recall Engineer:"
        '
        'cboRecall
        '
        Me.cboRecall.FormattingEnabled = True
        Me.cboRecall.Location = New System.Drawing.Point(251, 24)
        Me.cboRecall.Name = "cboRecall"
        Me.cboRecall.Size = New System.Drawing.Size(277, 21)
        Me.cboRecall.TabIndex = 80
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(12, 27)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(46, 13)
        Me.Label48.TabIndex = 79
        Me.Label48.Text = "Recall:"
        '
        'dtpQCDocumentsRecieved
        '
        Me.dtpQCDocumentsRecieved.Location = New System.Drawing.Point(251, 236)
        Me.dtpQCDocumentsRecieved.Name = "dtpQCDocumentsRecieved"
        Me.dtpQCDocumentsRecieved.Size = New System.Drawing.Size(180, 21)
        Me.dtpQCDocumentsRecieved.TabIndex = 78
        Me.dtpQCDocumentsRecieved.Visible = False
        '
        'chkQCDocumentsRecieved
        '
        Me.chkQCDocumentsRecieved.AutoSize = True
        Me.chkQCDocumentsRecieved.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkQCDocumentsRecieved.Location = New System.Drawing.Point(15, 236)
        Me.chkQCDocumentsRecieved.Name = "chkQCDocumentsRecieved"
        Me.chkQCDocumentsRecieved.Size = New System.Drawing.Size(164, 17)
        Me.chkQCDocumentsRecieved.TabIndex = 77
        Me.chkQCDocumentsRecieved.Text = "All documents recieved:"
        Me.chkQCDocumentsRecieved.UseVisualStyleBackColor = True
        '
        'txtQCPoorJobNotes
        '
        Me.txtQCPoorJobNotes.Location = New System.Drawing.Point(759, 198)
        Me.txtQCPoorJobNotes.Multiline = True
        Me.txtQCPoorJobNotes.Name = "txtQCPoorJobNotes"
        Me.txtQCPoorJobNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQCPoorJobNotes.Size = New System.Drawing.Size(441, 111)
        Me.txtQCPoorJobNotes.TabIndex = 76
        Me.txtQCPoorJobNotes.Tag = ""
        '
        'lblQCPoorJobNotes
        '
        Me.lblQCPoorJobNotes.AutoSize = True
        Me.lblQCPoorJobNotes.Location = New System.Drawing.Point(584, 198)
        Me.lblQCPoorJobNotes.Name = "lblQCPoorJobNotes"
        Me.lblQCPoorJobNotes.Size = New System.Drawing.Size(95, 13)
        Me.lblQCPoorJobNotes.TabIndex = 40
        Me.lblQCPoorJobNotes.Text = "Poor job notes:"
        '
        'cboQCEngineerPaymentRecieved
        '
        Me.cboQCEngineerPaymentRecieved.FormattingEnabled = True
        Me.cboQCEngineerPaymentRecieved.Location = New System.Drawing.Point(847, 162)
        Me.cboQCEngineerPaymentRecieved.Name = "cboQCEngineerPaymentRecieved"
        Me.cboQCEngineerPaymentRecieved.Size = New System.Drawing.Size(353, 21)
        Me.cboQCEngineerPaymentRecieved.TabIndex = 39
        '
        'lblQCEngineerMonies
        '
        Me.lblQCEngineerMonies.AutoSize = True
        Me.lblQCEngineerMonies.Location = New System.Drawing.Point(584, 162)
        Me.lblQCEngineerMonies.Name = "lblQCEngineerMonies"
        Me.lblQCEngineerMonies.Size = New System.Drawing.Size(251, 13)
        Me.lblQCEngineerMonies.TabIndex = 38
        Me.lblQCEngineerMonies.Text = "Engineer Cash/Cheque payment recieved:"
        '
        'cboQCPaymentSelection
        '
        Me.cboQCPaymentSelection.FormattingEnabled = True
        Me.cboQCPaymentSelection.Location = New System.Drawing.Point(847, 130)
        Me.cboQCPaymentSelection.Name = "cboQCPaymentSelection"
        Me.cboQCPaymentSelection.Size = New System.Drawing.Size(353, 21)
        Me.cboQCPaymentSelection.TabIndex = 37
        '
        'lblQCEngPaymentMethod
        '
        Me.lblQCEngPaymentMethod.AutoSize = True
        Me.lblQCEngPaymentMethod.Location = New System.Drawing.Point(584, 130)
        Me.lblQCEngPaymentMethod.Name = "lblQCEngPaymentMethod"
        Me.lblQCEngPaymentMethod.Size = New System.Drawing.Size(207, 13)
        Me.lblQCEngPaymentMethod.TabIndex = 36
        Me.lblQCEngPaymentMethod.Text = "Correct payment method selected:"
        '
        'cboQCAppliance
        '
        Me.cboQCAppliance.FormattingEnabled = True
        Me.cboQCAppliance.Location = New System.Drawing.Point(847, 96)
        Me.cboQCAppliance.Name = "cboQCAppliance"
        Me.cboQCAppliance.Size = New System.Drawing.Size(353, 21)
        Me.cboQCAppliance.TabIndex = 35
        '
        'cboQCPaymentCollection
        '
        Me.cboQCPaymentCollection.FormattingEnabled = True
        Me.cboQCPaymentCollection.Location = New System.Drawing.Point(251, 159)
        Me.cboQCPaymentCollection.Name = "cboQCPaymentCollection"
        Me.cboQCPaymentCollection.Size = New System.Drawing.Size(277, 21)
        Me.cboQCPaymentCollection.TabIndex = 16
        '
        'lblQCPaymentCollection
        '
        Me.lblQCPaymentCollection.AutoSize = True
        Me.lblQCPaymentCollection.Location = New System.Drawing.Point(12, 162)
        Me.lblQCPaymentCollection.Name = "lblQCPaymentCollection"
        Me.lblQCPaymentCollection.Size = New System.Drawing.Size(116, 13)
        Me.lblQCPaymentCollection.TabIndex = 15
        Me.lblQCPaymentCollection.Text = "Payment collected:"
        '
        'cboQCJobUploadTimescale
        '
        Me.cboQCJobUploadTimescale.FormattingEnabled = True
        Me.cboQCJobUploadTimescale.Location = New System.Drawing.Point(251, 127)
        Me.cboQCJobUploadTimescale.Name = "cboQCJobUploadTimescale"
        Me.cboQCJobUploadTimescale.Size = New System.Drawing.Size(277, 21)
        Me.cboQCJobUploadTimescale.TabIndex = 14
        '
        'lblQCAppliance
        '
        Me.lblQCAppliance.AutoSize = True
        Me.lblQCAppliance.Location = New System.Drawing.Point(584, 96)
        Me.lblQCAppliance.Name = "lblQCAppliance"
        Me.lblQCAppliance.Size = New System.Drawing.Size(122, 13)
        Me.lblQCAppliance.TabIndex = 34
        Me.lblQCAppliance.Text = "Appliance recorded:"
        '
        'cboQCParts
        '
        Me.cboQCParts.FormattingEnabled = True
        Me.cboQCParts.Location = New System.Drawing.Point(251, 93)
        Me.cboQCParts.Name = "cboQCParts"
        Me.cboQCParts.Size = New System.Drawing.Size(277, 21)
        Me.cboQCParts.TabIndex = 33
        '
        'lblJobUploadTimescale
        '
        Me.lblJobUploadTimescale.AutoSize = True
        Me.lblJobUploadTimescale.Location = New System.Drawing.Point(12, 130)
        Me.lblJobUploadTimescale.Name = "lblJobUploadTimescale"
        Me.lblJobUploadTimescale.Size = New System.Drawing.Size(159, 13)
        Me.lblJobUploadTimescale.TabIndex = 13
        Me.lblJobUploadTimescale.Text = "Job uploaded in timescale:"
        '
        'lblQCParts
        '
        Me.lblQCParts.AutoSize = True
        Me.lblQCParts.Location = New System.Drawing.Point(12, 96)
        Me.lblQCParts.Name = "lblQCParts"
        Me.lblQCParts.Size = New System.Drawing.Size(102, 13)
        Me.lblQCParts.TabIndex = 32
        Me.lblQCParts.Text = "Parts confirmed:"
        '
        'cboQCLGSR
        '
        Me.cboQCLGSR.FormattingEnabled = True
        Me.cboQCLGSR.Location = New System.Drawing.Point(847, 62)
        Me.cboQCLGSR.Name = "cboQCLGSR"
        Me.cboQCLGSR.Size = New System.Drawing.Size(353, 21)
        Me.cboQCLGSR.TabIndex = 31
        '
        'lblQCLGSR
        '
        Me.lblQCLGSR.AutoSize = True
        Me.lblQCLGSR.Location = New System.Drawing.Point(584, 62)
        Me.lblQCLGSR.Name = "lblQCLGSR"
        Me.lblQCLGSR.Size = New System.Drawing.Size(90, 13)
        Me.lblQCLGSR.TabIndex = 30
        Me.lblQCLGSR.Text = "LGSR missing:"
        '
        'cboQCLabourTime
        '
        Me.cboQCLabourTime.FormattingEnabled = True
        Me.cboQCLabourTime.Location = New System.Drawing.Point(251, 59)
        Me.cboQCLabourTime.Name = "cboQCLabourTime"
        Me.cboQCLabourTime.Size = New System.Drawing.Size(277, 21)
        Me.cboQCLabourTime.TabIndex = 29
        '
        'lblQCLabourTime
        '
        Me.lblQCLabourTime.AutoSize = True
        Me.lblQCLabourTime.Location = New System.Drawing.Point(12, 62)
        Me.lblQCLabourTime.Name = "lblQCLabourTime"
        Me.lblQCLabourTime.Size = New System.Drawing.Size(167, 13)
        Me.lblQCLabourTime.TabIndex = 28
        Me.lblQCLabourTime.Text = "Labour/Travel time missing:"
        '
        'grpOfficeQC
        '
        Me.grpOfficeQC.Controls.Add(Me.cboQCPaymentMethod)
        Me.grpOfficeQC.Controls.Add(Me.lblPaymentMethod)
        Me.grpOfficeQC.Controls.Add(Me.cboQCOrderNo)
        Me.grpOfficeQC.Controls.Add(Me.lblOrderNo)
        Me.grpOfficeQC.Controls.Add(Me.cboQCScheduleOfRate)
        Me.grpOfficeQC.Controls.Add(Me.lblScheduleRate)
        Me.grpOfficeQC.Controls.Add(Me.cboQCCustomerDetails)
        Me.grpOfficeQC.Controls.Add(Me.lblCustomerDetails)
        Me.grpOfficeQC.Controls.Add(Me.cboQCJobType)
        Me.grpOfficeQC.Controls.Add(Me.lblJobTypeCorrect)
        Me.grpOfficeQC.Controls.Add(Me.cboFTFCode)
        Me.grpOfficeQC.Controls.Add(Me.Label74)
        Me.grpOfficeQC.Location = New System.Drawing.Point(9, 20)
        Me.grpOfficeQC.Name = "grpOfficeQC"
        Me.grpOfficeQC.Size = New System.Drawing.Size(1220, 132)
        Me.grpOfficeQC.TabIndex = 30
        Me.grpOfficeQC.TabStop = False
        Me.grpOfficeQC.Text = "Office"
        '
        'cboQCPaymentMethod
        '
        Me.cboQCPaymentMethod.FormattingEnabled = True
        Me.cboQCPaymentMethod.Location = New System.Drawing.Point(251, 90)
        Me.cboQCPaymentMethod.Name = "cboQCPaymentMethod"
        Me.cboQCPaymentMethod.Size = New System.Drawing.Size(277, 21)
        Me.cboQCPaymentMethod.TabIndex = 37
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.AutoSize = True
        Me.lblPaymentMethod.Location = New System.Drawing.Point(12, 93)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(158, 13)
        Me.lblPaymentMethod.TabIndex = 36
        Me.lblPaymentMethod.Text = "Payment method detailed:"
        '
        'cboQCOrderNo
        '
        Me.cboQCOrderNo.FormattingEnabled = True
        Me.cboQCOrderNo.Location = New System.Drawing.Point(759, 57)
        Me.cboQCOrderNo.Name = "cboQCOrderNo"
        Me.cboQCOrderNo.Size = New System.Drawing.Size(441, 21)
        Me.cboQCOrderNo.TabIndex = 35
        '
        'lblOrderNo
        '
        Me.lblOrderNo.AutoSize = True
        Me.lblOrderNo.Location = New System.Drawing.Point(584, 60)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(150, 13)
        Me.lblOrderNo.TabIndex = 34
        Me.lblOrderNo.Text = "Order number attached: "
        '
        'cboQCScheduleOfRate
        '
        Me.cboQCScheduleOfRate.FormattingEnabled = True
        Me.cboQCScheduleOfRate.Location = New System.Drawing.Point(251, 54)
        Me.cboQCScheduleOfRate.Name = "cboQCScheduleOfRate"
        Me.cboQCScheduleOfRate.Size = New System.Drawing.Size(277, 21)
        Me.cboQCScheduleOfRate.TabIndex = 33
        '
        'lblScheduleRate
        '
        Me.lblScheduleRate.AutoSize = True
        Me.lblScheduleRate.Location = New System.Drawing.Point(12, 57)
        Me.lblScheduleRate.Name = "lblScheduleRate"
        Me.lblScheduleRate.Size = New System.Drawing.Size(208, 13)
        Me.lblScheduleRate.TabIndex = 32
        Me.lblScheduleRate.Text = "Correct schedule of rates selected:"
        '
        'cboQCCustomerDetails
        '
        Me.cboQCCustomerDetails.FormattingEnabled = True
        Me.cboQCCustomerDetails.Location = New System.Drawing.Point(759, 20)
        Me.cboQCCustomerDetails.Name = "cboQCCustomerDetails"
        Me.cboQCCustomerDetails.Size = New System.Drawing.Size(441, 21)
        Me.cboQCCustomerDetails.TabIndex = 31
        '
        'lblCustomerDetails
        '
        Me.lblCustomerDetails.AutoSize = True
        Me.lblCustomerDetails.Location = New System.Drawing.Point(584, 23)
        Me.lblCustomerDetails.Name = "lblCustomerDetails"
        Me.lblCustomerDetails.Size = New System.Drawing.Size(157, 13)
        Me.lblCustomerDetails.TabIndex = 30
        Me.lblCustomerDetails.Text = "Correct customer details: "
        '
        'cboQCJobType
        '
        Me.cboQCJobType.FormattingEnabled = True
        Me.cboQCJobType.Location = New System.Drawing.Point(251, 20)
        Me.cboQCJobType.Name = "cboQCJobType"
        Me.cboQCJobType.Size = New System.Drawing.Size(277, 21)
        Me.cboQCJobType.TabIndex = 29
        '
        'lblJobTypeCorrect
        '
        Me.lblJobTypeCorrect.AutoSize = True
        Me.lblJobTypeCorrect.Location = New System.Drawing.Point(12, 23)
        Me.lblJobTypeCorrect.Name = "lblJobTypeCorrect"
        Me.lblJobTypeCorrect.Size = New System.Drawing.Size(157, 13)
        Me.lblJobTypeCorrect.TabIndex = 28
        Me.lblJobTypeCorrect.Text = "Correct job type selected:"
        '
        'cboFTFCode
        '
        Me.cboFTFCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFTFCode.FormattingEnabled = True
        Me.cboFTFCode.Location = New System.Drawing.Point(759, 90)
        Me.cboFTFCode.Name = "cboFTFCode"
        Me.cboFTFCode.Size = New System.Drawing.Size(441, 21)
        Me.cboFTFCode.TabIndex = 27
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(584, 93)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(65, 13)
        Me.Label74.TabIndex = 26
        Me.Label74.Text = "FTF Code:"
        '
        'tpCharges
        '
        Me.tpCharges.Controls.Add(Me.gpbInvoice)
        Me.tpCharges.Controls.Add(Me.gpbCharges)
        Me.tpCharges.Controls.Add(Me.gpbAdditionalCharges)
        Me.tpCharges.Controls.Add(Me.gpbPartsAndProducts)
        Me.tpCharges.Controls.Add(Me.gpbTimesheets)
        Me.tpCharges.Controls.Add(Me.gpbScheduleOfRates)
        Me.tpCharges.Location = New System.Drawing.Point(4, 22)
        Me.tpCharges.Name = "tpCharges"
        Me.tpCharges.Size = New System.Drawing.Size(1247, 652)
        Me.tpCharges.TabIndex = 4
        Me.tpCharges.Text = "Visit Charges"
        Me.tpCharges.UseVisualStyleBackColor = True
        '
        'gpbInvoice
        '
        Me.gpbInvoice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbInvoice.Controls.Add(Me.cboDept)
        Me.gpbInvoice.Controls.Add(Me.btnCreateServ)
        Me.gpbInvoice.Controls.Add(Me.txtInvAmount)
        Me.gpbInvoice.Controls.Add(Me.txtCreditAmount)
        Me.gpbInvoice.Controls.Add(Me.txtInvNo)
        Me.gpbInvoice.Controls.Add(Me.cboPaidBy)
        Me.gpbInvoice.Controls.Add(Me.cboInvType)
        Me.gpbInvoice.Controls.Add(Me.cboVATRate)
        Me.gpbInvoice.Controls.Add(Me.txtPriceIncVAT)
        Me.gpbInvoice.Controls.Add(Me.txtAccountCode)
        Me.gpbInvoice.Controls.Add(Me.lblInvoiceAddressDetails)
        Me.gpbInvoice.Controls.Add(Me.txtNominalCode)
        Me.gpbInvoice.Controls.Add(Me.btnSearch)
        Me.gpbInvoice.Controls.Add(Me.dtpRaiseInvoiceOn)
        Me.gpbInvoice.Controls.Add(Me.cbxReadyToBeInvoiced)
        Me.gpbInvoice.Controls.Add(Me.lblInvAmount)
        Me.gpbInvoice.Controls.Add(Me.lblcredit)
        Me.gpbInvoice.Controls.Add(Me.lblInvNo)
        Me.gpbInvoice.Controls.Add(Me.lblPaidBy)
        Me.gpbInvoice.Controls.Add(Me.lblInvType)
        Me.gpbInvoice.Controls.Add(Me.lblVAT)
        Me.gpbInvoice.Controls.Add(Me.lblNominalCode)
        Me.gpbInvoice.Controls.Add(Me.lblAccountCode)
        Me.gpbInvoice.Controls.Add(Me.lblPriceInvVAT)
        Me.gpbInvoice.Controls.Add(Me.lblDepartment)
        Me.gpbInvoice.Controls.Add(Me.lblRaiseInvoiceOn)
        Me.gpbInvoice.Location = New System.Drawing.Point(717, 425)
        Me.gpbInvoice.Name = "gpbInvoice"
        Me.gpbInvoice.Size = New System.Drawing.Size(522, 221)
        Me.gpbInvoice.TabIndex = 6
        Me.gpbInvoice.TabStop = False
        Me.gpbInvoice.Text = "Ready To Be Invoiced"
        '
        'cboDept
        '
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(315, 26)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(98, 21)
        Me.cboDept.TabIndex = 32
        '
        'btnCreateServ
        '
        Me.btnCreateServ.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateServ.Location = New System.Drawing.Point(8, 192)
        Me.btnCreateServ.Name = "btnCreateServ"
        Me.btnCreateServ.Size = New System.Drawing.Size(159, 23)
        Me.btnCreateServ.TabIndex = 31
        Me.btnCreateServ.Text = "Create Multiple Services"
        '
        'txtInvAmount
        '
        Me.txtInvAmount.Location = New System.Drawing.Point(340, 190)
        Me.txtInvAmount.Name = "txtInvAmount"
        Me.txtInvAmount.ReadOnly = True
        Me.txtInvAmount.Size = New System.Drawing.Size(74, 21)
        Me.txtInvAmount.TabIndex = 27
        Me.txtInvAmount.Visible = False
        '
        'txtCreditAmount
        '
        Me.txtCreditAmount.Location = New System.Drawing.Point(425, 190)
        Me.txtCreditAmount.Name = "txtCreditAmount"
        Me.txtCreditAmount.ReadOnly = True
        Me.txtCreditAmount.Size = New System.Drawing.Size(91, 21)
        Me.txtCreditAmount.TabIndex = 25
        Me.txtCreditAmount.Visible = False
        '
        'txtInvNo
        '
        Me.txtInvNo.Location = New System.Drawing.Point(251, 190)
        Me.txtInvNo.Name = "txtInvNo"
        Me.txtInvNo.ReadOnly = True
        Me.txtInvNo.Size = New System.Drawing.Size(76, 21)
        Me.txtInvNo.TabIndex = 23
        Me.txtInvNo.Visible = False
        '
        'cboPaidBy
        '
        Me.cboPaidBy.FormattingEnabled = True
        Me.cboPaidBy.Location = New System.Drawing.Point(249, 106)
        Me.cboPaidBy.Name = "cboPaidBy"
        Me.cboPaidBy.Size = New System.Drawing.Size(164, 21)
        Me.cboPaidBy.TabIndex = 19
        Me.cboPaidBy.Visible = False
        '
        'cboInvType
        '
        Me.cboInvType.FormattingEnabled = True
        Me.cboInvType.Location = New System.Drawing.Point(249, 64)
        Me.cboInvType.Name = "cboInvType"
        Me.cboInvType.Size = New System.Drawing.Size(164, 21)
        Me.cboInvType.TabIndex = 17
        Me.cboInvType.Visible = False
        '
        'cboVATRate
        '
        Me.cboVATRate.FormattingEnabled = True
        Me.cboVATRate.Location = New System.Drawing.Point(425, 63)
        Me.cboVATRate.Name = "cboVATRate"
        Me.cboVATRate.Size = New System.Drawing.Size(90, 21)
        Me.cboVATRate.TabIndex = 13
        Me.cboVATRate.Visible = False
        '
        'txtPriceIncVAT
        '
        Me.txtPriceIncVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPriceIncVAT.Location = New System.Drawing.Point(425, 106)
        Me.txtPriceIncVAT.Name = "txtPriceIncVAT"
        Me.txtPriceIncVAT.ReadOnly = True
        Me.txtPriceIncVAT.Size = New System.Drawing.Size(91, 21)
        Me.txtPriceIncVAT.TabIndex = 3
        Me.txtPriceIncVAT.Visible = False
        '
        'txtAccountCode
        '
        Me.txtAccountCode.Location = New System.Drawing.Point(425, 24)
        Me.txtAccountCode.Name = "txtAccountCode"
        Me.txtAccountCode.Size = New System.Drawing.Size(91, 21)
        Me.txtAccountCode.TabIndex = 12
        Me.txtAccountCode.Visible = False
        '
        'lblInvoiceAddressDetails
        '
        Me.lblInvoiceAddressDetails.Location = New System.Drawing.Point(8, 43)
        Me.lblInvoiceAddressDetails.Name = "lblInvoiceAddressDetails"
        Me.lblInvoiceAddressDetails.Size = New System.Drawing.Size(231, 127)
        Me.lblInvoiceAddressDetails.TabIndex = 4
        Me.lblInvoiceAddressDetails.Visible = False
        '
        'txtNominalCode
        '
        Me.txtNominalCode.Location = New System.Drawing.Point(249, 24)
        Me.txtNominalCode.Name = "txtNominalCode"
        Me.txtNominalCode.Size = New System.Drawing.Size(47, 21)
        Me.txtNominalCode.TabIndex = 9
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(177, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(62, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Change"
        Me.btnSearch.Visible = False
        '
        'dtpRaiseInvoiceOn
        '
        Me.dtpRaiseInvoiceOn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRaiseInvoiceOn.Location = New System.Drawing.Point(425, 148)
        Me.dtpRaiseInvoiceOn.Name = "dtpRaiseInvoiceOn"
        Me.dtpRaiseInvoiceOn.Size = New System.Drawing.Size(91, 21)
        Me.dtpRaiseInvoiceOn.TabIndex = 6
        Me.dtpRaiseInvoiceOn.Visible = False
        '
        'cbxReadyToBeInvoiced
        '
        Me.cbxReadyToBeInvoiced.Location = New System.Drawing.Point(8, 22)
        Me.cbxReadyToBeInvoiced.Name = "cbxReadyToBeInvoiced"
        Me.cbxReadyToBeInvoiced.Size = New System.Drawing.Size(180, 16)
        Me.cbxReadyToBeInvoiced.TabIndex = 0
        Me.cbxReadyToBeInvoiced.Text = "Ready To Be Invoiced To:"
        '
        'lblInvAmount
        '
        Me.lblInvAmount.Location = New System.Drawing.Point(338, 172)
        Me.lblInvAmount.Name = "lblInvAmount"
        Me.lblInvAmount.Size = New System.Drawing.Size(76, 17)
        Me.lblInvAmount.TabIndex = 28
        Me.lblInvAmount.Text = "Inv Ex VAT"
        Me.lblInvAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInvAmount.Visible = False
        '
        'lblcredit
        '
        Me.lblcredit.Location = New System.Drawing.Point(420, 173)
        Me.lblcredit.Name = "lblcredit"
        Me.lblcredit.Size = New System.Drawing.Size(92, 14)
        Me.lblcredit.TabIndex = 26
        Me.lblcredit.Text = "Credit Ex VAT"
        Me.lblcredit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblcredit.Visible = False
        '
        'lblInvNo
        '
        Me.lblInvNo.Location = New System.Drawing.Point(249, 170)
        Me.lblInvNo.Name = "lblInvNo"
        Me.lblInvNo.Size = New System.Drawing.Size(91, 17)
        Me.lblInvNo.TabIndex = 24
        Me.lblInvNo.Text = "Invoice No."
        Me.lblInvNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInvNo.Visible = False
        '
        'lblPaidBy
        '
        Me.lblPaidBy.Location = New System.Drawing.Point(248, 89)
        Me.lblPaidBy.Name = "lblPaidBy"
        Me.lblPaidBy.Size = New System.Drawing.Size(130, 17)
        Me.lblPaidBy.TabIndex = 20
        Me.lblPaidBy.Text = "Paid By"
        Me.lblPaidBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPaidBy.Visible = False
        '
        'lblInvType
        '
        Me.lblInvType.Location = New System.Drawing.Point(248, 48)
        Me.lblInvType.Name = "lblInvType"
        Me.lblInvType.Size = New System.Drawing.Size(130, 17)
        Me.lblInvType.TabIndex = 18
        Me.lblInvType.Text = "Invoice Type"
        Me.lblInvType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInvType.Visible = False
        '
        'lblVAT
        '
        Me.lblVAT.Location = New System.Drawing.Point(420, 48)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(94, 17)
        Me.lblVAT.TabIndex = 14
        Me.lblVAT.Text = "VAT Rate"
        Me.lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVAT.Visible = False
        '
        'lblNominalCode
        '
        Me.lblNominalCode.Location = New System.Drawing.Point(246, 9)
        Me.lblNominalCode.Name = "lblNominalCode"
        Me.lblNominalCode.Size = New System.Drawing.Size(60, 14)
        Me.lblNominalCode.TabIndex = 7
        Me.lblNominalCode.Text = "Nominal"
        Me.lblNominalCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccountCode
        '
        Me.lblAccountCode.Location = New System.Drawing.Point(420, 8)
        Me.lblAccountCode.Name = "lblAccountCode"
        Me.lblAccountCode.Size = New System.Drawing.Size(107, 14)
        Me.lblAccountCode.TabIndex = 11
        Me.lblAccountCode.Text = "Account Code"
        Me.lblAccountCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountCode.Visible = False
        '
        'lblPriceInvVAT
        '
        Me.lblPriceInvVAT.Location = New System.Drawing.Point(420, 87)
        Me.lblPriceInvVAT.Name = "lblPriceInvVAT"
        Me.lblPriceInvVAT.Size = New System.Drawing.Size(92, 16)
        Me.lblPriceInvVAT.TabIndex = 2
        Me.lblPriceInvVAT.Text = "Price Inc VAT"
        Me.lblPriceInvVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPriceInvVAT.Visible = False
        '
        'lblDepartment
        '
        Me.lblDepartment.Location = New System.Drawing.Point(312, 7)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(79, 16)
        Me.lblDepartment.TabIndex = 8
        Me.lblDepartment.Text = "Cost Centre"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRaiseInvoiceOn
        '
        Me.lblRaiseInvoiceOn.Location = New System.Drawing.Point(423, 130)
        Me.lblRaiseInvoiceOn.Name = "lblRaiseInvoiceOn"
        Me.lblRaiseInvoiceOn.Size = New System.Drawing.Size(99, 16)
        Me.lblRaiseInvoiceOn.TabIndex = 5
        Me.lblRaiseInvoiceOn.Text = "Raise Inv Date:"
        Me.lblRaiseInvoiceOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRaiseInvoiceOn.Visible = False
        '
        'gpbCharges
        '
        Me.gpbCharges.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpbCharges.Controls.Add(Me.chkShowJobCharges)
        Me.gpbCharges.Controls.Add(Me.GroupBox6)
        Me.gpbCharges.Controls.Add(Me.lblContractPerVisit)
        Me.gpbCharges.Controls.Add(Me.lblOR)
        Me.gpbCharges.Controls.Add(Me.Label30)
        Me.gpbCharges.Controls.Add(Me.lblQuotePercentageTotal)
        Me.gpbCharges.Controls.Add(Me.lblEquals)
        Me.gpbCharges.Controls.Add(Me.GroupBox9)
        Me.gpbCharges.Controls.Add(Me.lblPercent)
        Me.gpbCharges.Controls.Add(Me.txtPercentOfQuote)
        Me.gpbCharges.Controls.Add(Me.rdoPercentageOfQuoteValue)
        Me.gpbCharges.Controls.Add(Me.txtCharge)
        Me.gpbCharges.Controls.Add(Me.rdoChargeOther)
        Me.gpbCharges.Controls.Add(Me.rdoJobValue)
        Me.gpbCharges.Controls.Add(Me.txtJobValue)
        Me.gpbCharges.Location = New System.Drawing.Point(8, 425)
        Me.gpbCharges.Name = "gpbCharges"
        Me.gpbCharges.Size = New System.Drawing.Size(603, 221)
        Me.gpbCharges.TabIndex = 3
        Me.gpbCharges.TabStop = False
        Me.gpbCharges.Text = "Charges"
        '
        'chkShowJobCharges
        '
        Me.chkShowJobCharges.AutoSize = True
        Me.chkShowJobCharges.Location = New System.Drawing.Point(41, 187)
        Me.chkShowJobCharges.Name = "chkShowJobCharges"
        Me.chkShowJobCharges.Size = New System.Drawing.Size(183, 17)
        Me.chkShowJobCharges.TabIndex = 17
        Me.chkShowJobCharges.Text = "Show All Charges From Job"
        Me.chkShowJobCharges.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label82)
        Me.GroupBox6.Controls.Add(Me.Label78)
        Me.GroupBox6.Controls.Add(Me.Label77)
        Me.GroupBox6.Controls.Add(Me.txtProfitPerc)
        Me.GroupBox6.Controls.Add(Me.txtProfit)
        Me.GroupBox6.Controls.Add(Me.CostsToOption1)
        Me.GroupBox6.Controls.Add(Me.txtCosts)
        Me.GroupBox6.Controls.Add(Me.CostsToOption3)
        Me.GroupBox6.Controls.Add(Me.txtSale)
        Me.GroupBox6.Controls.Add(Me.CostsToOption2)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 93)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(583, 82)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Costs To:"
        '
        'Label82
        '
        Me.Label82.Location = New System.Drawing.Point(266, 17)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(101, 16)
        Me.Label82.TabIndex = 23
        Me.Label82.Text = "Sale"
        '
        'Label78
        '
        Me.Label78.Location = New System.Drawing.Point(266, 57)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(101, 19)
        Me.Label78.TabIndex = 22
        Me.Label78.Text = "Profit"
        '
        'Label77
        '
        Me.Label77.Location = New System.Drawing.Point(266, 36)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(101, 20)
        Me.Label77.TabIndex = 21
        Me.Label77.Text = "Costs"
        '
        'txtProfitPerc
        '
        Me.txtProfitPerc.Location = New System.Drawing.Point(501, 57)
        Me.txtProfitPerc.Name = "txtProfitPerc"
        Me.txtProfitPerc.ReadOnly = True
        Me.txtProfitPerc.Size = New System.Drawing.Size(76, 21)
        Me.txtProfitPerc.TabIndex = 20
        '
        'txtProfit
        '
        Me.txtProfit.Location = New System.Drawing.Point(373, 57)
        Me.txtProfit.Name = "txtProfit"
        Me.txtProfit.ReadOnly = True
        Me.txtProfit.Size = New System.Drawing.Size(120, 21)
        Me.txtProfit.TabIndex = 19
        '
        'CostsToOption1
        '
        Me.CostsToOption1.AutoSize = True
        Me.CostsToOption1.Location = New System.Drawing.Point(33, 16)
        Me.CostsToOption1.Name = "CostsToOption1"
        Me.CostsToOption1.Size = New System.Drawing.Size(74, 17)
        Me.CostsToOption1.TabIndex = 13
        Me.CostsToOption1.TabStop = True
        Me.CostsToOption1.Text = "Contract"
        Me.CostsToOption1.UseVisualStyleBackColor = True
        '
        'txtCosts
        '
        Me.txtCosts.Location = New System.Drawing.Point(373, 34)
        Me.txtCosts.Name = "txtCosts"
        Me.txtCosts.ReadOnly = True
        Me.txtCosts.Size = New System.Drawing.Size(120, 21)
        Me.txtCosts.TabIndex = 18
        '
        'CostsToOption3
        '
        Me.CostsToOption3.AutoSize = True
        Me.CostsToOption3.Location = New System.Drawing.Point(33, 62)
        Me.CostsToOption3.Name = "CostsToOption3"
        Me.CostsToOption3.Size = New System.Drawing.Size(77, 17)
        Me.CostsToOption3.TabIndex = 15
        Me.CostsToOption3.TabStop = True
        Me.CostsToOption3.Text = "Warranty"
        Me.CostsToOption3.UseVisualStyleBackColor = True
        '
        'txtSale
        '
        Me.txtSale.Location = New System.Drawing.Point(373, 12)
        Me.txtSale.Name = "txtSale"
        Me.txtSale.ReadOnly = True
        Me.txtSale.Size = New System.Drawing.Size(120, 21)
        Me.txtSale.TabIndex = 17
        '
        'CostsToOption2
        '
        Me.CostsToOption2.AutoSize = True
        Me.CostsToOption2.Location = New System.Drawing.Point(33, 39)
        Me.CostsToOption2.Name = "CostsToOption2"
        Me.CostsToOption2.Size = New System.Drawing.Size(91, 17)
        Me.CostsToOption2.TabIndex = 14
        Me.CostsToOption2.TabStop = True
        Me.CostsToOption2.Text = "Chargeable"
        Me.CostsToOption2.UseVisualStyleBackColor = True
        '
        'lblContractPerVisit
        '
        Me.lblContractPerVisit.BackColor = System.Drawing.SystemColors.Info
        Me.lblContractPerVisit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContractPerVisit.Location = New System.Drawing.Point(507, 14)
        Me.lblContractPerVisit.Name = "lblContractPerVisit"
        Me.lblContractPerVisit.Size = New System.Drawing.Size(85, 56)
        Me.lblContractPerVisit.TabIndex = 3
        Me.lblContractPerVisit.Text = "Contract Job - Invoicing Per Visit"
        Me.lblContractPerVisit.Visible = False
        '
        'lblOR
        '
        Me.lblOR.Location = New System.Drawing.Point(8, 58)
        Me.lblOR.Name = "lblOR"
        Me.lblOR.Size = New System.Drawing.Size(27, 26)
        Me.lblOR.TabIndex = 5
        Me.lblOR.Text = "OR"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(8, 34)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(27, 18)
        Me.Label30.TabIndex = 2
        Me.Label30.Text = "OR"
        '
        'lblQuotePercentageTotal
        '
        Me.lblQuotePercentageTotal.Location = New System.Drawing.Point(537, 73)
        Me.lblQuotePercentageTotal.Name = "lblQuotePercentageTotal"
        Me.lblQuotePercentageTotal.Size = New System.Drawing.Size(34, 16)
        Me.lblQuotePercentageTotal.TabIndex = 11
        Me.lblQuotePercentageTotal.Text = "N/A"
        '
        'lblEquals
        '
        Me.lblEquals.Location = New System.Drawing.Point(522, 73)
        Me.lblEquals.Name = "lblEquals"
        Me.lblEquals.Size = New System.Drawing.Size(24, 16)
        Me.lblEquals.TabIndex = 10
        Me.lblEquals.Text = "="
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rbStandard)
        Me.GroupBox9.Controls.Add(Me.rbSite)
        Me.GroupBox9.Location = New System.Drawing.Point(354, 177)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(238, 31)
        Me.GroupBox9.TabIndex = 83
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Visible = False
        '
        'rbStandard
        '
        Me.rbStandard.AutoSize = True
        Me.rbStandard.Checked = True
        Me.rbStandard.Location = New System.Drawing.Point(114, 10)
        Me.rbStandard.Name = "rbStandard"
        Me.rbStandard.Size = New System.Drawing.Size(123, 17)
        Me.rbStandard.TabIndex = 1
        Me.rbStandard.TabStop = True
        Me.rbStandard.Text = "Standard Markup"
        Me.rbStandard.UseVisualStyleBackColor = True
        '
        'rbSite
        '
        Me.rbSite.AutoSize = True
        Me.rbSite.Location = New System.Drawing.Point(11, 11)
        Me.rbSite.Name = "rbSite"
        Me.rbSite.Size = New System.Drawing.Size(95, 17)
        Me.rbSite.TabIndex = 0
        Me.rbSite.Text = "Site markup"
        Me.rbSite.UseVisualStyleBackColor = True
        '
        'lblPercent
        '
        Me.lblPercent.Location = New System.Drawing.Point(506, 73)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(24, 16)
        Me.lblPercent.TabIndex = 9
        Me.lblPercent.Text = "%"
        '
        'txtPercentOfQuote
        '
        Me.txtPercentOfQuote.Location = New System.Drawing.Point(381, 69)
        Me.txtPercentOfQuote.Name = "txtPercentOfQuote"
        Me.txtPercentOfQuote.Size = New System.Drawing.Size(120, 21)
        Me.txtPercentOfQuote.TabIndex = 8
        '
        'rdoPercentageOfQuoteValue
        '
        Me.rdoPercentageOfQuoteValue.Location = New System.Drawing.Point(41, 66)
        Me.rdoPercentageOfQuoteValue.Name = "rdoPercentageOfQuoteValue"
        Me.rdoPercentageOfQuoteValue.Size = New System.Drawing.Size(175, 24)
        Me.rdoPercentageOfQuoteValue.TabIndex = 7
        Me.rdoPercentageOfQuoteValue.Text = "Charge % of Quote Value"
        '
        'txtCharge
        '
        Me.txtCharge.Location = New System.Drawing.Point(381, 44)
        Me.txtCharge.Name = "txtCharge"
        Me.txtCharge.ReadOnly = True
        Me.txtCharge.Size = New System.Drawing.Size(120, 21)
        Me.txtCharge.TabIndex = 6
        '
        'rdoChargeOther
        '
        Me.rdoChargeOther.Location = New System.Drawing.Point(41, 41)
        Me.rdoChargeOther.Name = "rdoChargeOther"
        Me.rdoChargeOther.Size = New System.Drawing.Size(171, 24)
        Me.rdoChargeOther.TabIndex = 4
        Me.rdoChargeOther.Text = "Charge Other"
        '
        'rdoJobValue
        '
        Me.rdoJobValue.Location = New System.Drawing.Point(41, 16)
        Me.rdoJobValue.Name = "rdoJobValue"
        Me.rdoJobValue.Size = New System.Drawing.Size(149, 24)
        Me.rdoJobValue.TabIndex = 0
        Me.rdoJobValue.Text = "Charge Visit Value"
        '
        'txtJobValue
        '
        Me.txtJobValue.Location = New System.Drawing.Point(381, 19)
        Me.txtJobValue.Name = "txtJobValue"
        Me.txtJobValue.ReadOnly = True
        Me.txtJobValue.Size = New System.Drawing.Size(120, 21)
        Me.txtJobValue.TabIndex = 1
        '
        'gpbAdditionalCharges
        '
        Me.gpbAdditionalCharges.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbAdditionalCharges.Controls.Add(Me.lblAdditionalCharge)
        Me.gpbAdditionalCharges.Controls.Add(Me.btnAddAdditionalCharge)
        Me.gpbAdditionalCharges.Controls.Add(Me.txtAdditionalCharge)
        Me.gpbAdditionalCharges.Controls.Add(Me.btnRemoveAdditionalCharge)
        Me.gpbAdditionalCharges.Controls.Add(Me.txtAdditionalChargeDescription)
        Me.gpbAdditionalCharges.Controls.Add(Me.lblDescription)
        Me.gpbAdditionalCharges.Controls.Add(Me.txtAdditionalChargeTotal)
        Me.gpbAdditionalCharges.Controls.Add(Me.Label29)
        Me.gpbAdditionalCharges.Controls.Add(Me.dgAdditionalCharges)
        Me.gpbAdditionalCharges.Location = New System.Drawing.Point(617, 184)
        Me.gpbAdditionalCharges.Name = "gpbAdditionalCharges"
        Me.gpbAdditionalCharges.Size = New System.Drawing.Size(622, 233)
        Me.gpbAdditionalCharges.TabIndex = 5
        Me.gpbAdditionalCharges.TabStop = False
        Me.gpbAdditionalCharges.Text = "Additional Charges"
        '
        'lblAdditionalCharge
        '
        Me.lblAdditionalCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAdditionalCharge.Location = New System.Drawing.Point(8, 206)
        Me.lblAdditionalCharge.Name = "lblAdditionalCharge"
        Me.lblAdditionalCharge.Size = New System.Drawing.Size(74, 20)
        Me.lblAdditionalCharge.TabIndex = 9
        Me.lblAdditionalCharge.Text = "Charge"
        '
        'btnAddAdditionalCharge
        '
        Me.btnAddAdditionalCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddAdditionalCharge.Location = New System.Drawing.Point(539, 204)
        Me.btnAddAdditionalCharge.Name = "btnAddAdditionalCharge"
        Me.btnAddAdditionalCharge.Size = New System.Drawing.Size(75, 23)
        Me.btnAddAdditionalCharge.TabIndex = 8
        Me.btnAddAdditionalCharge.Text = "Add"
        Me.btnAddAdditionalCharge.UseVisualStyleBackColor = True
        '
        'txtAdditionalCharge
        '
        Me.txtAdditionalCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAdditionalCharge.Location = New System.Drawing.Point(88, 203)
        Me.txtAdditionalCharge.Name = "txtAdditionalCharge"
        Me.txtAdditionalCharge.Size = New System.Drawing.Size(96, 21)
        Me.txtAdditionalCharge.TabIndex = 7
        '
        'btnRemoveAdditionalCharge
        '
        Me.btnRemoveAdditionalCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveAdditionalCharge.Location = New System.Drawing.Point(8, 129)
        Me.btnRemoveAdditionalCharge.Name = "btnRemoveAdditionalCharge"
        Me.btnRemoveAdditionalCharge.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveAdditionalCharge.TabIndex = 1
        Me.btnRemoveAdditionalCharge.Text = "Remove"
        Me.btnRemoveAdditionalCharge.UseVisualStyleBackColor = True
        '
        'txtAdditionalChargeDescription
        '
        Me.txtAdditionalChargeDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdditionalChargeDescription.Location = New System.Drawing.Point(88, 157)
        Me.txtAdditionalChargeDescription.Multiline = True
        Me.txtAdditionalChargeDescription.Name = "txtAdditionalChargeDescription"
        Me.txtAdditionalChargeDescription.Size = New System.Drawing.Size(526, 40)
        Me.txtAdditionalChargeDescription.TabIndex = 5
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.Location = New System.Drawing.Point(8, 161)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(74, 23)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'txtAdditionalChargeTotal
        '
        Me.txtAdditionalChargeTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdditionalChargeTotal.Location = New System.Drawing.Point(541, 131)
        Me.txtAdditionalChargeTotal.Name = "txtAdditionalChargeTotal"
        Me.txtAdditionalChargeTotal.ReadOnly = True
        Me.txtAdditionalChargeTotal.Size = New System.Drawing.Size(71, 21)
        Me.txtAdditionalChargeTotal.TabIndex = 3
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.Location = New System.Drawing.Point(492, 131)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(40, 23)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "Total"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgAdditionalCharges
        '
        Me.dgAdditionalCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAdditionalCharges.DataMember = ""
        Me.dgAdditionalCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAdditionalCharges.Location = New System.Drawing.Point(8, 20)
        Me.dgAdditionalCharges.Name = "dgAdditionalCharges"
        Me.dgAdditionalCharges.Size = New System.Drawing.Size(606, 109)
        Me.dgAdditionalCharges.TabIndex = 0
        '
        'gpbPartsAndProducts
        '
        Me.gpbPartsAndProducts.Controls.Add(Me.txtPartsMarkUp)
        Me.gpbPartsAndProducts.Controls.Add(Me.chkPartsSelectAll)
        Me.gpbPartsAndProducts.Controls.Add(Me.txtPartProductCost)
        Me.gpbPartsAndProducts.Controls.Add(Me.txtPartsProductTotal)
        Me.gpbPartsAndProducts.Controls.Add(Me.Label28)
        Me.gpbPartsAndProducts.Controls.Add(Me.lblPPTotalCost)
        Me.gpbPartsAndProducts.Controls.Add(Me.lblPartsMarkUp)
        Me.gpbPartsAndProducts.Controls.Add(Me.dgPartsProductCharging)
        Me.gpbPartsAndProducts.Location = New System.Drawing.Point(8, 184)
        Me.gpbPartsAndProducts.Name = "gpbPartsAndProducts"
        Me.gpbPartsAndProducts.Size = New System.Drawing.Size(603, 233)
        Me.gpbPartsAndProducts.TabIndex = 1
        Me.gpbPartsAndProducts.TabStop = False
        Me.gpbPartsAndProducts.Text = "Parts && Products"
        '
        'txtPartsMarkUp
        '
        Me.txtPartsMarkUp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsMarkUp.Enabled = False
        Me.txtPartsMarkUp.Location = New System.Drawing.Point(405, 203)
        Me.txtPartsMarkUp.Name = "txtPartsMarkUp"
        Me.txtPartsMarkUp.Size = New System.Drawing.Size(37, 21)
        Me.txtPartsMarkUp.TabIndex = 81
        Me.txtPartsMarkUp.Visible = False
        '
        'chkPartsSelectAll
        '
        Me.chkPartsSelectAll.AutoCheck = False
        Me.chkPartsSelectAll.AutoSize = True
        Me.chkPartsSelectAll.Location = New System.Drawing.Point(6, 205)
        Me.chkPartsSelectAll.Name = "chkPartsSelectAll"
        Me.chkPartsSelectAll.Size = New System.Drawing.Size(79, 17)
        Me.chkPartsSelectAll.TabIndex = 80
        Me.chkPartsSelectAll.Text = "Select All"
        Me.chkPartsSelectAll.UseVisualStyleBackColor = True
        '
        'txtPartProductCost
        '
        Me.txtPartProductCost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartProductCost.Location = New System.Drawing.Point(252, 203)
        Me.txtPartProductCost.Name = "txtPartProductCost"
        Me.txtPartProductCost.ReadOnly = True
        Me.txtPartProductCost.Size = New System.Drawing.Size(71, 21)
        Me.txtPartProductCost.TabIndex = 2
        '
        'txtPartsProductTotal
        '
        Me.txtPartsProductTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsProductTotal.Location = New System.Drawing.Point(525, 202)
        Me.txtPartsProductTotal.Name = "txtPartsProductTotal"
        Me.txtPartsProductTotal.ReadOnly = True
        Me.txtPartsProductTotal.Size = New System.Drawing.Size(71, 21)
        Me.txtPartsProductTotal.TabIndex = 4
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(448, 202)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 21)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Total Price"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPPTotalCost
        '
        Me.lblPPTotalCost.Location = New System.Drawing.Point(174, 203)
        Me.lblPPTotalCost.Name = "lblPPTotalCost"
        Me.lblPPTotalCost.Size = New System.Drawing.Size(72, 21)
        Me.lblPPTotalCost.TabIndex = 79
        Me.lblPPTotalCost.Text = "Total Cost"
        Me.lblPPTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartsMarkUp
        '
        Me.lblPartsMarkUp.Location = New System.Drawing.Point(329, 202)
        Me.lblPartsMarkUp.Name = "lblPartsMarkUp"
        Me.lblPartsMarkUp.Size = New System.Drawing.Size(70, 21)
        Me.lblPartsMarkUp.TabIndex = 82
        Me.lblPartsMarkUp.Text = "Mark Up %"
        Me.lblPartsMarkUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPartsMarkUp.Visible = False
        '
        'dgPartsProductCharging
        '
        Me.dgPartsProductCharging.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPartsProductCharging.DataMember = ""
        Me.dgPartsProductCharging.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartsProductCharging.Location = New System.Drawing.Point(9, 16)
        Me.dgPartsProductCharging.Name = "dgPartsProductCharging"
        Me.dgPartsProductCharging.Size = New System.Drawing.Size(587, 181)
        Me.dgPartsProductCharging.TabIndex = 0
        '
        'gpbTimesheets
        '
        Me.gpbTimesheets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbTimesheets.Controls.Add(Me.chkTimesheetSelectAll)
        Me.gpbTimesheets.Controls.Add(Me.txtEngineerCostTotal)
        Me.gpbTimesheets.Controls.Add(Me.txtTimesheetTotal)
        Me.gpbTimesheets.Controls.Add(Me.Label27)
        Me.gpbTimesheets.Controls.Add(Me.Label32)
        Me.gpbTimesheets.Controls.Add(Me.dgTimesheetCharges)
        Me.gpbTimesheets.Location = New System.Drawing.Point(617, 8)
        Me.gpbTimesheets.Name = "gpbTimesheets"
        Me.gpbTimesheets.Size = New System.Drawing.Size(622, 170)
        Me.gpbTimesheets.TabIndex = 4
        Me.gpbTimesheets.TabStop = False
        Me.gpbTimesheets.Text = "Timesheets"
        '
        'chkTimesheetSelectAll
        '
        Me.chkTimesheetSelectAll.AutoCheck = False
        Me.chkTimesheetSelectAll.AutoSize = True
        Me.chkTimesheetSelectAll.Location = New System.Drawing.Point(6, 142)
        Me.chkTimesheetSelectAll.Name = "chkTimesheetSelectAll"
        Me.chkTimesheetSelectAll.Size = New System.Drawing.Size(79, 17)
        Me.chkTimesheetSelectAll.TabIndex = 81
        Me.chkTimesheetSelectAll.Text = "Select All"
        Me.chkTimesheetSelectAll.UseVisualStyleBackColor = True
        '
        'txtEngineerCostTotal
        '
        Me.txtEngineerCostTotal.Location = New System.Drawing.Point(382, 140)
        Me.txtEngineerCostTotal.Name = "txtEngineerCostTotal"
        Me.txtEngineerCostTotal.ReadOnly = True
        Me.txtEngineerCostTotal.Size = New System.Drawing.Size(71, 21)
        Me.txtEngineerCostTotal.TabIndex = 2
        '
        'txtTimesheetTotal
        '
        Me.txtTimesheetTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTimesheetTotal.Location = New System.Drawing.Point(540, 140)
        Me.txtTimesheetTotal.Name = "txtTimesheetTotal"
        Me.txtTimesheetTotal.ReadOnly = True
        Me.txtTimesheetTotal.Size = New System.Drawing.Size(71, 21)
        Me.txtTimesheetTotal.TabIndex = 4
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(462, 140)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 21)
        Me.Label27.TabIndex = 3
        Me.Label27.Text = "Total Price"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(308, 139)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(68, 23)
        Me.Label32.TabIndex = 1
        Me.Label32.Text = "Total Cost"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgTimesheetCharges
        '
        Me.dgTimesheetCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTimesheetCharges.DataMember = ""
        Me.dgTimesheetCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTimesheetCharges.Location = New System.Drawing.Point(6, 17)
        Me.dgTimesheetCharges.Name = "dgTimesheetCharges"
        Me.dgTimesheetCharges.Size = New System.Drawing.Size(606, 118)
        Me.dgTimesheetCharges.TabIndex = 0
        '
        'gpbScheduleOfRates
        '
        Me.gpbScheduleOfRates.Controls.Add(Me.btnAddSoR)
        Me.gpbScheduleOfRates.Controls.Add(Me.txtScheduleOfRatesTotal)
        Me.gpbScheduleOfRates.Controls.Add(Me.dgScheduleOfRateCharges)
        Me.gpbScheduleOfRates.Controls.Add(Me.Label26)
        Me.gpbScheduleOfRates.Location = New System.Drawing.Point(8, 8)
        Me.gpbScheduleOfRates.Name = "gpbScheduleOfRates"
        Me.gpbScheduleOfRates.Size = New System.Drawing.Size(603, 170)
        Me.gpbScheduleOfRates.TabIndex = 0
        Me.gpbScheduleOfRates.TabStop = False
        Me.gpbScheduleOfRates.Text = "Schedule Of Rates"
        '
        'btnAddSoR
        '
        Me.btnAddSoR.Location = New System.Drawing.Point(6, 141)
        Me.btnAddSoR.Name = "btnAddSoR"
        Me.btnAddSoR.Size = New System.Drawing.Size(75, 23)
        Me.btnAddSoR.TabIndex = 1
        Me.btnAddSoR.Text = "Add"
        '
        'txtScheduleOfRatesTotal
        '
        Me.txtScheduleOfRatesTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScheduleOfRatesTotal.Location = New System.Drawing.Point(521, 143)
        Me.txtScheduleOfRatesTotal.Name = "txtScheduleOfRatesTotal"
        Me.txtScheduleOfRatesTotal.ReadOnly = True
        Me.txtScheduleOfRatesTotal.Size = New System.Drawing.Size(71, 21)
        Me.txtScheduleOfRatesTotal.TabIndex = 3
        '
        'dgScheduleOfRateCharges
        '
        Me.dgScheduleOfRateCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgScheduleOfRateCharges.DataMember = ""
        Me.dgScheduleOfRateCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgScheduleOfRateCharges.Location = New System.Drawing.Point(8, 17)
        Me.dgScheduleOfRateCharges.Name = "dgScheduleOfRateCharges"
        Me.dgScheduleOfRateCharges.Size = New System.Drawing.Size(585, 121)
        Me.dgScheduleOfRateCharges.TabIndex = 0
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(481, 141)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(39, 23)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Total"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpDocuments
        '
        Me.tpDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tpDocuments.Name = "tpDocuments"
        Me.tpDocuments.Size = New System.Drawing.Size(1247, 652)
        Me.tpDocuments.TabIndex = 9
        Me.tpDocuments.Text = "Documents"
        Me.tpDocuments.UseVisualStyleBackColor = True
        '
        'tpPhotos
        '
        Me.tpPhotos.Controls.Add(Me.flPhotos)
        Me.tpPhotos.Location = New System.Drawing.Point(4, 22)
        Me.tpPhotos.Name = "tpPhotos"
        Me.tpPhotos.Size = New System.Drawing.Size(1247, 652)
        Me.tpPhotos.TabIndex = 10
        Me.tpPhotos.Text = "Photos"
        Me.tpPhotos.UseVisualStyleBackColor = True
        '
        'flPhotos
        '
        Me.flPhotos.AutoScroll = True
        Me.flPhotos.AutoSize = True
        Me.flPhotos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flPhotos.Location = New System.Drawing.Point(0, 0)
        Me.flPhotos.Name = "flPhotos"
        Me.flPhotos.Size = New System.Drawing.Size(1247, 652)
        Me.flPhotos.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(8, 750)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(1183, 750)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        '
        'cbxVisitLockDown
        '
        Me.cbxVisitLockDown.BackColor = System.Drawing.SystemColors.Info
        Me.cbxVisitLockDown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxVisitLockDown.Location = New System.Drawing.Point(8, 32)
        Me.cbxVisitLockDown.Name = "cbxVisitLockDown"
        Me.cbxVisitLockDown.Size = New System.Drawing.Size(296, 24)
        Me.cbxVisitLockDown.TabIndex = 5
        Me.cbxVisitLockDown.Text = "Visit locked down and ready for charging"
        Me.cbxVisitLockDown.UseVisualStyleBackColor = False
        '
        'lblStatusWarning
        '
        Me.lblStatusWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusWarning.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusWarning.ForeColor = System.Drawing.Color.Red
        Me.lblStatusWarning.Location = New System.Drawing.Point(312, 32)
        Me.lblStatusWarning.Name = "lblStatusWarning"
        Me.lblStatusWarning.Size = New System.Drawing.Size(736, 23)
        Me.lblStatusWarning.TabIndex = 6
        Me.lblStatusWarning.Text = "Reversing this status will result in the lost of charge changes"
        Me.lblStatusWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStatusWarning.Visible = False
        '
        'btnOrders
        '
        Me.btnOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOrders.Location = New System.Drawing.Point(148, 750)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(64, 23)
        Me.btnOrders.TabIndex = 4
        Me.btnOrders.Text = "Orders"
        '
        'btnInvoice
        '
        Me.btnInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInvoice.Location = New System.Drawing.Point(289, 750)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(64, 23)
        Me.btnInvoice.TabIndex = 5
        Me.btnInvoice.Text = "Invoice"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(1064, 750)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(103, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print QC"
        '
        'PrintMenu
        '
        Me.PrintMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGasSafetyInspectionBoilerServiceRecord})
        Me.PrintMenu.Name = "PrintMenu"
        Me.PrintMenu.Size = New System.Drawing.Size(302, 26)
        '
        'mnuGasSafetyInspectionBoilerServiceRecord
        '
        Me.mnuGasSafetyInspectionBoilerServiceRecord.Name = "mnuGasSafetyInspectionBoilerServiceRecord"
        Me.mnuGasSafetyInspectionBoilerServiceRecord.Size = New System.Drawing.Size(301, 22)
        Me.mnuGasSafetyInspectionBoilerServiceRecord.Text = "Gas Safety Inspection/Boiler Service Record"
        '
        'txtCurrentContract
        '
        Me.txtCurrentContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentContract.Location = New System.Drawing.Point(1116, 38)
        Me.txtCurrentContract.Name = "txtCurrentContract"
        Me.txtCurrentContract.ReadOnly = True
        Me.txtCurrentContract.Size = New System.Drawing.Size(135, 21)
        Me.txtCurrentContract.TabIndex = 27
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.Location = New System.Drawing.Point(1054, 39)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(63, 16)
        Me.Label39.TabIndex = 26
        Me.Label39.Text = "Contract:"
        '
        'btnPrintGSR
        '
        Me.btnPrintGSR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintGSR.Location = New System.Drawing.Point(1064, 750)
        Me.btnPrintGSR.Name = "btnPrintGSR"
        Me.btnPrintGSR.Size = New System.Drawing.Size(105, 23)
        Me.btnPrintGSR.TabIndex = 29
        Me.btnPrintGSR.Text = "Print GSR"
        '
        'btnPrintSVR
        '
        Me.btnPrintSVR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintSVR.Location = New System.Drawing.Point(1057, 750)
        Me.btnPrintSVR.Name = "btnPrintSVR"
        Me.btnPrintSVR.Size = New System.Drawing.Size(112, 23)
        Me.btnPrintSVR.TabIndex = 30
        Me.btnPrintSVR.Text = "Print..."
        '
        'btnJob
        '
        Me.btnJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnJob.Location = New System.Drawing.Point(78, 750)
        Me.btnJob.Name = "btnJob"
        Me.btnJob.Size = New System.Drawing.Size(64, 23)
        Me.btnJob.TabIndex = 31
        Me.btnJob.Text = "Job"
        '
        'lblRechargeTicked
        '
        Me.lblRechargeTicked.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRechargeTicked.ForeColor = System.Drawing.Color.Red
        Me.lblRechargeTicked.Location = New System.Drawing.Point(75, 4)
        Me.lblRechargeTicked.Name = "lblRechargeTicked"
        Me.lblRechargeTicked.Size = New System.Drawing.Size(457, 23)
        Me.lblRechargeTicked.TabIndex = 32
        Me.lblRechargeTicked.Text = "Recharge is Selected"
        Me.lblRechargeTicked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRechargeTicked.Visible = False
        '
        'btnShowVisits
        '
        Me.btnShowVisits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowVisits.Location = New System.Drawing.Point(687, 750)
        Me.btnShowVisits.Name = "btnShowVisits"
        Me.btnShowVisits.Size = New System.Drawing.Size(99, 23)
        Me.btnShowVisits.TabIndex = 33
        Me.btnShowVisits.Text = "Show History"
        Me.btnShowVisits.UseVisualStyleBackColor = True
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 150)
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(218, 750)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Cust"
        '
        'txtCustEmail
        '
        Me.txtCustEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCustEmail.Location = New System.Drawing.Point(718, 8)
        Me.txtCustEmail.Name = "txtCustEmail"
        Me.txtCustEmail.ReadOnly = True
        Me.txtCustEmail.Size = New System.Drawing.Size(533, 14)
        Me.txtCustEmail.TabIndex = 36
        '
        'SVRs
        '
        Me.SVRs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllGasPaperworkToolStripMenuItem, Me.svrmenu, Me.JobSheetMenu, Me.DomesticGSRToolStripMenuItem, Me.WarningNoticeToolStripMenuItem, Me.CommercialGSRToolStripMenuItem, Me.QCResultsToolStripMenuItem, Me.ElectricalMinorWorksToolStripMenuItem, Me.CommercialCateringToolStripMenuItem, Me.SaffronUnventedWorkshhetToolStripMenuItem, Me.PropertyMaintenanceWorksheetToolStripMenuItem, Me.ASHPWorksheetToolStripMenuItem, Me.CommissioningChecklistToolStripMenuItem, Me.HotWorksPermitToolStripMenuItem})
        Me.SVRs.Name = "SVRs"
        Me.SVRs.Size = New System.Drawing.Size(251, 312)
        '
        'AllGasPaperworkToolStripMenuItem
        '
        Me.AllGasPaperworkToolStripMenuItem.Name = "AllGasPaperworkToolStripMenuItem"
        Me.AllGasPaperworkToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.AllGasPaperworkToolStripMenuItem.Text = "All Safety Paperwork"
        '
        'svrmenu
        '
        Me.svrmenu.Name = "svrmenu"
        Me.svrmenu.Size = New System.Drawing.Size(250, 22)
        Me.svrmenu.Text = "SVR"
        '
        'JobSheetMenu
        '
        Me.JobSheetMenu.Name = "JobSheetMenu"
        Me.JobSheetMenu.Size = New System.Drawing.Size(250, 22)
        Me.JobSheetMenu.Text = "Job Sheet"
        '
        'DomesticGSRToolStripMenuItem
        '
        Me.DomesticGSRToolStripMenuItem.Name = "DomesticGSRToolStripMenuItem"
        Me.DomesticGSRToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.DomesticGSRToolStripMenuItem.Text = "Domestic LSR"
        '
        'WarningNoticeToolStripMenuItem
        '
        Me.WarningNoticeToolStripMenuItem.Name = "WarningNoticeToolStripMenuItem"
        Me.WarningNoticeToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.WarningNoticeToolStripMenuItem.Text = "Warning Notice"
        '
        'CommercialGSRToolStripMenuItem
        '
        Me.CommercialGSRToolStripMenuItem.Name = "CommercialGSRToolStripMenuItem"
        Me.CommercialGSRToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.CommercialGSRToolStripMenuItem.Text = "Commercial LSR"
        '
        'QCResultsToolStripMenuItem
        '
        Me.QCResultsToolStripMenuItem.Name = "QCResultsToolStripMenuItem"
        Me.QCResultsToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.QCResultsToolStripMenuItem.Text = "QC Results"
        '
        'ElectricalMinorWorksToolStripMenuItem
        '
        Me.ElectricalMinorWorksToolStripMenuItem.Name = "ElectricalMinorWorksToolStripMenuItem"
        Me.ElectricalMinorWorksToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ElectricalMinorWorksToolStripMenuItem.Text = "Electrical Minor Works"
        '
        'CommercialCateringToolStripMenuItem
        '
        Me.CommercialCateringToolStripMenuItem.Name = "CommercialCateringToolStripMenuItem"
        Me.CommercialCateringToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.CommercialCateringToolStripMenuItem.Text = "Commercial Catering"
        '
        'SaffronUnventedWorkshhetToolStripMenuItem
        '
        Me.SaffronUnventedWorkshhetToolStripMenuItem.Name = "SaffronUnventedWorkshhetToolStripMenuItem"
        Me.SaffronUnventedWorkshhetToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.SaffronUnventedWorkshhetToolStripMenuItem.Text = "Saffron Unvented Worksheet"
        '
        'PropertyMaintenanceWorksheetToolStripMenuItem
        '
        Me.PropertyMaintenanceWorksheetToolStripMenuItem.Name = "PropertyMaintenanceWorksheetToolStripMenuItem"
        Me.PropertyMaintenanceWorksheetToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.PropertyMaintenanceWorksheetToolStripMenuItem.Text = "Property Maintenance Worksheet"
        '
        'ASHPWorksheetToolStripMenuItem
        '
        Me.ASHPWorksheetToolStripMenuItem.Name = "ASHPWorksheetToolStripMenuItem"
        Me.ASHPWorksheetToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ASHPWorksheetToolStripMenuItem.Text = "Waveney ASHP Worksheet"
        '
        'CommissioningChecklistToolStripMenuItem
        '
        Me.CommissioningChecklistToolStripMenuItem.Name = "CommissioningChecklistToolStripMenuItem"
        Me.CommissioningChecklistToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.CommissioningChecklistToolStripMenuItem.Text = "Commissioning Checklist"
        '
        'HotWorksPermitToolStripMenuItem
        '
        Me.HotWorksPermitToolStripMenuItem.Name = "HotWorksPermitToolStripMenuItem"
        Me.HotWorksPermitToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.HotWorksPermitToolStripMenuItem.Text = "Hot Works Permit"
        '
        'FRMEngineerVisit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1255, 780)
        Me.Controls.Add(Me.btnPrintSVR)
        Me.Controls.Add(Me.txtCustEmail)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnShowVisits)
        Me.Controls.Add(Me.lblRechargeTicked)
        Me.Controls.Add(Me.btnJob)
        Me.Controls.Add(Me.btnPrintGSR)
        Me.Controls.Add(Me.txtCurrentContract)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnInvoice)
        Me.Controls.Add(Me.btnOrders)
        Me.Controls.Add(Me.lblStatusWarning)
        Me.Controls.Add(Me.cbxVisitLockDown)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tcWorkSheet)
        Me.MinimumSize = New System.Drawing.Size(936, 664)
        Me.Name = "FRMEngineerVisit"
        Me.Text = "Engineer Visit"
        Me.Controls.SetChildIndex(Me.tcWorkSheet, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.cbxVisitLockDown, 0)
        Me.Controls.SetChildIndex(Me.lblStatusWarning, 0)
        Me.Controls.SetChildIndex(Me.btnOrders, 0)
        Me.Controls.SetChildIndex(Me.btnInvoice, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentContract, 0)
        Me.Controls.SetChildIndex(Me.btnPrintGSR, 0)
        Me.Controls.SetChildIndex(Me.btnJob, 0)
        Me.Controls.SetChildIndex(Me.lblRechargeTicked, 0)
        Me.Controls.SetChildIndex(Me.btnShowVisits, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.txtCustEmail, 0)
        Me.Controls.SetChildIndex(Me.btnPrintSVR, 0)
        Me.tcWorkSheet.ResumeLayout(False)
        Me.tpMainDetails.ResumeLayout(False)
        Me.tpMainDetails.PerformLayout()
        CType(Me.pbCustomerSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEngineerSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgJobItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAppliances.ResumeLayout(False)
        Me.gpAppliances.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpWorksheets.ResumeLayout(False)
        Me.grpAdditionalWorksheet.ResumeLayout(False)
        CType(Me.dgAdditional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAlarmInfo.ResumeLayout(False)
        CType(Me.DGSmokeComo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVisitWorksheetExtended.ResumeLayout(False)
        Me.grpVisitWorksheetExtended.PerformLayout()
        Me.grpVisitDefects.ResumeLayout(False)
        CType(Me.dgVisitDefects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpApplianceWorksheet.ResumeLayout(False)
        CType(Me.dgApplianceWorkSheets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVisitWorksheet.ResumeLayout(False)
        Me.grpVisitWorksheet.PerformLayout()
        Me.tpTimesheets.ResumeLayout(False)
        Me.tpTimesheets.PerformLayout()
        Me.grpTimesheets.ResumeLayout(False)
        Me.grpTimesheets.PerformLayout()
        CType(Me.dgTimeSheets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPartsAndProducts.ResumeLayout(False)
        Me.grpAllocated.ResumeLayout(False)
        Me.grpAllocated.PerformLayout()
        CType(Me.nudPartAllocatedQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPartsProductsAllocated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpUsed.ResumeLayout(False)
        Me.grpUsed.PerformLayout()
        CType(Me.dgPartsAndProductsUsed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudQuantityUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpOutcomes.ResumeLayout(False)
        Me.grpOutcomes.ResumeLayout(False)
        Me.grpOutcomes.PerformLayout()
        Me.grpSiteFuels.ResumeLayout(False)
        CType(Me.dgSiteFuel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpQC.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.grpQCField.ResumeLayout(False)
        Me.grpQCField.PerformLayout()
        Me.grpOfficeQC.ResumeLayout(False)
        Me.grpOfficeQC.PerformLayout()
        Me.tpCharges.ResumeLayout(False)
        Me.gpbInvoice.ResumeLayout(False)
        Me.gpbInvoice.PerformLayout()
        Me.gpbCharges.ResumeLayout(False)
        Me.gpbCharges.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.gpbAdditionalCharges.ResumeLayout(False)
        Me.gpbAdditionalCharges.PerformLayout()
        CType(Me.dgAdditionalCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbPartsAndProducts.ResumeLayout(False)
        Me.gpbPartsAndProducts.PerformLayout()
        CType(Me.dgPartsProductCharging, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbTimesheets.ResumeLayout(False)
        Me.gpbTimesheets.PerformLayout()
        CType(Me.dgTimesheetCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbScheduleOfRates.ResumeLayout(False)
        Me.gpbScheduleOfRates.PerformLayout()
        CType(Me.dgScheduleOfRateCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPhotos.ResumeLayout(False)
        Me.tpPhotos.PerformLayout()
        Me.PrintMenu.ResumeLayout(False)
        Me.SVRs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "ComboBoxes Data Tables"

    Dim dtEngineerGetAll As DataTable = DB.Engineer.Engineer_GetAll().Table
    Dim dtPassFailNA As DataTable = DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table
    Dim dtYesNoNA As DataTable = DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA).Table
    Dim dtYesNo As DataTable = DB.Picklists.GetAll(Enums.PickListTypes.YesNo).Table

#End Region

#Region "Classes"

    Private Class CheckListMenuItem : Inherits MenuItem

        Private _Section As String = ""

        Public Property Section() As String
            Get
                Return _Section
            End Get
            Set(ByVal Value As String)
                _Section = Value
            End Set
        End Property

        Private _SectionID As Integer = 0

        Public Property SectionID() As Integer
            Get
                Return _SectionID
            End Get
            Set(ByVal Value As Integer)
                _SectionID = Value
            End Set
        End Property

        Private _EngineerVisitID As Integer = 0

        Public Property EngineerVisitID() As Integer
            Get
                Return _EngineerVisitID
            End Get
            Set(ByVal Value As Integer)
                _EngineerVisitID = Value
            End Set
        End Property

        Private _ChecklistDatagrid As DataGrid

        Public Property ChecklistDatagrid() As DataGrid
            Get
                Return _ChecklistDatagrid
            End Get
            Set(ByVal Value As DataGrid)
                _ChecklistDatagrid = Value
            End Set
        End Property

        Private _ChecklistDataview As DataView

        Public Property ChecklistDataview() As DataView
            Get
                Return _ChecklistDataview
            End Get
            Set(ByVal Value As DataView)
                _ChecklistDataview = Value
            End Set
        End Property

        Public Sub New(ByVal SectionIn As String, ByVal SectionIDIn As Integer,
                            ByVal EngineerVisitIDIn As Integer,
                            ByRef ChecklistDataviewIn As DataView, ByRef ChecklistDatagridIn As DataGrid)
            Section = SectionIn
            SectionID = SectionIDIn
            EngineerVisitID = EngineerVisitIDIn
            ChecklistDataview = ChecklistDataviewIn
            ChecklistDatagrid = ChecklistDatagridIn

            Me.Text = "Check List : " & Section

            AddHandler Me.Click, AddressOf OpenChecklist
        End Sub

        Private Sub OpenChecklist(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowForm(GetType(FRMAnswers), True, New Object() {EngineerVisitID, SectionID, 0})
            ChecklistDataview = DB.Checklists.GetAll_For_Engineer_Visit(EngineerVisitID)
            ChecklistDatagrid.DataSource = ChecklistDataview
        End Sub

    End Class

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe

        LoadForm(sender, e, Me)

        SetupJobItemsDataGrid()
        SetupPartsAndProductsDataGrid()
        SetupTimesheetDataGrid()
        SetupAdditionalChargeDataGrid()
        SetupSoRChargeDataGrid()
        SetupPartProductDataGrid()
        SetupTimeSheetChargeDataGrid()
        SetupVisitDefectDataGrid()
        SetupApplianceWorksheetDataGrid()
        SetupAssetDataGrid()
        SetupAdditionalDataGrid()
        SetupSmokeComoDG()
        SetupSiteFuelsDatagrid()

        EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_New_As_Object(Helper.MakeIntegerValid(GetParameter(0)))

        Me.mnuAddChecklist.MenuItems.Clear()

        Dim timesheetTypesDT As DataTable = DB.Picklists.GetAll(Enums.PickListTypes.TimeSheetTypes).Table
        For i As Integer = timesheetTypesDT.Rows.Count - 1 To 0 Step -1
            If Not (timesheetTypesDT.Rows(i).Item("Name") = "Travelling" Or timesheetTypesDT.Rows(i).Item("Name") = "Working") Then
                timesheetTypesDT.Rows.RemoveAt(i)
            End If
        Next
        Combo.SetUpCombo(cboTimeSheetType, timesheetTypesDT, "ManagerID", "Name", Enums.ComboValues.Please_Select)

        Try
            If Not GetParameter(1) Is Nothing Then
                LogCalloutForm = CType(CType(CType(GetParameter(1), UCVisitBreakdown).OnControl, UCCalloutBreakdown).OnContol, UCLogCallout).OnForm
            Else
                LogCalloutForm = Nothing
            End If
        Catch
            LogCalloutForm = Nothing
        End Try

        If Job.JobTypeID = Enums.JobTypes.Installation Then
            btnCreateServ.Visible = True
        Else
            btnCreateServ.Visible = False
        End If

        If IsRFT Then

            Me.tcWorkSheet.TabPages.Remove(tpAppliances)
            Me.tcWorkSheet.TabPages.Remove(tpWorksheets)
            Me.tcWorkSheet.TabPages.Remove(tpOutcomes)

        End If

        If loggedInUser.Admin = False Then
            'Only admin users can edit info
            For Each c As Control In Me.tpMainDetails.Controls
                c.Enabled = False
            Next
            Me.txtOutcomeDetails.ReadOnly = True
            Me.txtNotesFromEngineer.ReadOnly = True
            Me.txtOutcomeDetails.Enabled = True
            Me.txtNotesFromEngineer.Enabled = True
            For Each c As Control In Me.tpCharges.Controls
                c.Enabled = False
            Next
            For Each c As Control In Me.tpTimesheets.Controls
                c.Enabled = False
            Next
            btnAddAdd.Visible = False
            btnAddApplianceWorksheet.Visible = False
            btnAddVisitDefect.Visible = False
            btnRemoveAdd.Visible = False
            btnRemoveApplianceWorkSheet.Visible = False
            btnRemoveVisitDefect.Visible = False
            Me.tcWorkSheet.TabPages.Remove(tpQC)
        End If

    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private DocumentsControl As UCDocumentsList

#Region "Visit Defects"

    Private _VisitDefectDataview As DataView

    Public Property VisitDefectDataview() As DataView
        Get
            Return _VisitDefectDataview
        End Get
        Set(ByVal value As DataView)
            _VisitDefectDataview = value
            _VisitDefectDataview.AllowNew = False
            _VisitDefectDataview.AllowEdit = False
            _VisitDefectDataview.AllowDelete = False
            _VisitDefectDataview.Table.TableName = Enums.TableNames.tblEngineerVisitDefects.ToString
            Me.dgVisitDefects.DataSource = VisitDefectDataview
        End Set
    End Property

    Private ReadOnly Property SelectedVisitDefectDataRow() As DataRow
        Get
            If Not Me.dgVisitDefects.CurrentRowIndex = -1 Then
                Return VisitDefectDataview(Me.dgVisitDefects.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Appliance Worksheets"

    Private _ApplianceWorkSheetDataview As DataView

    Public Property ApplianceWorkSheetDataview() As DataView
        Get
            Return _ApplianceWorkSheetDataview
        End Get
        Set(ByVal value As DataView)
            _ApplianceWorkSheetDataview = value
            _ApplianceWorkSheetDataview.AllowNew = False
            _ApplianceWorkSheetDataview.AllowEdit = False
            _ApplianceWorkSheetDataview.AllowDelete = False
            _ApplianceWorkSheetDataview.Table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
            Me.dgApplianceWorkSheets.DataSource = ApplianceWorkSheetDataview
        End Set
    End Property

    Private _AdditionalWorkSheetDataview As DataView

    Public Property AdditionalWorkSheetDataview() As DataView
        Get
            Return _AdditionalWorkSheetDataview
        End Get
        Set(ByVal value As DataView)
            _AdditionalWorkSheetDataview = value
            _AdditionalWorkSheetDataview.AllowNew = False
            _AdditionalWorkSheetDataview.AllowEdit = False
            _AdditionalWorkSheetDataview.AllowDelete = False
            _AdditionalWorkSheetDataview.Table.TableName = Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString
            Me.dgAdditional.DataSource = AdditionalWorkSheetDataview
        End Set
    End Property

    Private _SmokeComoDataview As DataView

    Public Property SmokeComoDataview() As DataView
        Get
            Return _SmokeComoDataview
        End Get
        Set(ByVal value As DataView)
            _SmokeComoDataview = value
            _SmokeComoDataview.AllowNew = False
            _SmokeComoDataview.AllowEdit = False
            _SmokeComoDataview.AllowDelete = False
            _SmokeComoDataview.Table.TableName = "Alarms"
            Me.DGSmokeComo.DataSource = SmokeComoDataview
        End Set
    End Property

    Private ReadOnly Property SelectedApplianceWorkSheetDataRow() As DataRow
        Get
            If Not Me.dgApplianceWorkSheets.CurrentRowIndex = -1 Then
                Return ApplianceWorkSheetDataview(Me.dgApplianceWorkSheets.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelectedAdditionalWorkSheetDataRow() As DataRow
        Get
            If Not Me.dgAdditional.CurrentRowIndex = -1 Then
                Return AdditionalWorkSheetDataview(Me.dgAdditional.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelectedSmokeComoDataRow() As DataRow
        Get
            If Not Me.DGSmokeComo.CurrentRowIndex = -1 Then
                Return SmokeComoDataview(Me.DGSmokeComo.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

    Private _LogCalloutForm As FRMLogCallout = Nothing

    Public Property LogCalloutForm() As FRMLogCallout
        Get
            Return _LogCalloutForm
        End Get
        Set(ByVal Value As FRMLogCallout)
            _LogCalloutForm = Value
        End Set
    End Property

    Private _updating As Boolean = True

    Public Property Updating() As Boolean
        Get
            Return _updating
        End Get
        Set(ByVal Value As Boolean)
            _updating = Value
        End Set
    End Property

    Private _Loading As Boolean = True

    Public Property Loading() As Boolean
        Get
            Return _Loading
        End Get
        Set(ByVal Value As Boolean)
            _Loading = Value
        End Set
    End Property

    Private _EngineerVisit As Entity.EngineerVisits.EngineerVisit

    Public Property EngineerVisit() As Entity.EngineerVisits.EngineerVisit
        Get
            Return _EngineerVisit
        End Get
        Set(ByVal Value As Entity.EngineerVisits.EngineerVisit)
            _EngineerVisit = Value

            Populate()

            Me.tpDocuments.Controls.Clear()
            DocumentsControl = New UCDocumentsList(Enums.TableNames.tblEngineerVisit, EngineerVisit.EngineerVisitID)
            Me.tpDocuments.Controls.Add(DocumentsControl)

        End Set
    End Property

    Private _JobItems As DataView

    Private Property JobItems() As DataView
        Get
            Return _JobItems
        End Get
        Set(ByVal value As DataView)
            _JobItems = value
            _JobItems.AllowNew = False
            _JobItems.AllowEdit = True
            _JobItems.AllowDelete = False
            _JobItems.Table.TableName = Enums.TableNames.tblJobItem.ToString
            Me.dgJobItems.DataSource = JobItems
        End Set
    End Property

    Private _PartProductIDUsed As Integer = 0

    Public Property PartProductIDUsed() As Integer
        Get
            Return _PartProductIDUsed
        End Get
        Set(ByVal Value As Integer)
            _PartProductIDUsed = Value
        End Set
    End Property

    Private _PartProductReferenceUsed As String = ""

    Public Property PartProductReferenceUsed() As String
        Get
            Return _PartProductReferenceUsed
        End Get
        Set(ByVal Value As String)
            _PartProductReferenceUsed = Value
        End Set
    End Property

    Private _theSite As Entity.Sites.Site

    Private Property theSite() As Entity.Sites.Site
        Get
            Return _theSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _theSite = Value
            Dim currentContract As Entity.ContractsOriginal.ContractOriginal = DB.ContractOriginal.Get_Current_ForSite(theSite.SiteID)
            If currentContract Is Nothing Then
                txtCurrentContract.Text = "Not on contract"
            Else
                txtCurrentContract.Text = currentContract.ContractType & " - Expires " & Format(currentContract.ContractEndDate, "dd/MM/yyyy")
            End If
        End Set
    End Property

    Private _AssetsTable As DataView = Nothing

    Public Property AssetsDataView() As DataView
        Get
            Return _AssetsTable
        End Get
        Set(ByVal Value As DataView)
            _AssetsTable = Value
            _AssetsTable.Table.TableName = Enums.TableNames.tblAsset.ToString
            _AssetsTable.AllowNew = False
            _AssetsTable.AllowEdit = False
            _AssetsTable.AllowDelete = False
            Me.dgAssets.DataSource = AssetsDataView
        End Set
    End Property

    Private _QC As Entity.EngineerVisitQCs.EngineerVisitQC

    Private Property QC() As Entity.EngineerVisitQCs.EngineerVisitQC
        Get
            Return _QC
        End Get
        Set(ByVal value As Entity.EngineerVisitQCs.EngineerVisitQC)
            _QC = value
        End Set
    End Property

    Private _JobLock As Entity.JobLock.JobLock

    Private Property JobLock() As Entity.JobLock.JobLock
        Get
            Return _JobLock
        End Get
        Set(ByVal value As Entity.JobLock.JobLock)
            _JobLock = value
        End Set
    End Property

    Private _customerCharge As Entity.CustomerCharges.CustomerCharge

    Public Property CustomerCharge() As Entity.CustomerCharges.CustomerCharge
        Get
            Return _customerCharge
        End Get
        Set(ByVal value As Entity.CustomerCharges.CustomerCharge)
            _customerCharge = value
            If Not Helper.MakeIntegerValid(_customerCharge?.CustomerChargeID) > 0 Then
                Dim settings As Entity.Management.Settings = DB.Manager.Get()
                _customerCharge.SetMileageRate = Helper.MakeDoubleValid(settings?.MileageRate)
                _customerCharge.SetPartsMarkup = Helper.MakeDoubleValid(settings?.PartsMarkup)
                _customerCharge.SetRatesMarkup = Helper.MakeDoubleValid(settings?.RatesMarkup)
            End If
        End Set
    End Property

    Dim loops As Integer = 0
    Dim isSpecialPart As Boolean = False

#End Region

#Region "Setup"

    Private Sub SetupVisitDefectDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgVisitDefects.TableStyles(0)

        Dim Product As New DataGridLabelColumn
        Product.Format = ""
        Product.FormatInfo = Nothing
        Product.HeaderText = "Product"
        Product.MappingName = "typemakemodel"
        Product.ReadOnly = True
        Product.Width = 100
        Product.NullText = ""
        tbStyle.GridColumnStyles.Add(Product)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial Num"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 100
        SerialNum.NullText = ""
        tbStyle.GridColumnStyles.Add(SerialNum)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 100
        Location.NullText = ""
        tbStyle.GridColumnStyles.Add(Location)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 100
        Category.NullText = ""
        tbStyle.GridColumnStyles.Add(Category)

        Dim WarningNoticeIssued As New DataGridLabelColumn
        WarningNoticeIssued.Format = ""
        WarningNoticeIssued.FormatInfo = Nothing
        WarningNoticeIssued.HeaderText = "Warning Notice Issued"
        WarningNoticeIssued.MappingName = "WarningNoticeIssued"
        WarningNoticeIssued.ReadOnly = True
        WarningNoticeIssued.Width = 80
        WarningNoticeIssued.NullText = ""
        tbStyle.GridColumnStyles.Add(WarningNoticeIssued)

        Dim Disconnected As New DataGridLabelColumn
        Disconnected.Format = ""
        Disconnected.FormatInfo = Nothing
        Disconnected.HeaderText = "Disconnected"
        Disconnected.MappingName = "Disconnected"
        Disconnected.ReadOnly = True
        Disconnected.Width = 80
        Disconnected.NullText = ""
        tbStyle.GridColumnStyles.Add(Disconnected)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Enums.TableNames.tblEngineerVisitDefects.ToString
        Me.dgVisitDefects.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetupApplianceWorksheetDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgApplianceWorkSheets.TableStyles(0)

        Dim Product As New DataGridLabelColumn
        Product.Format = ""
        Product.FormatInfo = Nothing
        Product.HeaderText = "Product"
        Product.MappingName = "typemakemodel"
        Product.ReadOnly = True
        Product.Width = 100
        Product.NullText = ""
        tbStyle.GridColumnStyles.Add(Product)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial Num"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 100
        SerialNum.NullText = ""
        tbStyle.GridColumnStyles.Add(SerialNum)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 100
        Location.NullText = ""
        tbStyle.GridColumnStyles.Add(Location)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
        Me.dgApplianceWorkSheets.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetupSmokeComoDG()

        Dim tbStyle As DataGridTableStyle = Me.DGSmokeComo.TableStyles(0)

        Dim Comments As New DataGridLabelColumn
        Comments.Format = ""
        Comments.FormatInfo = Nothing
        Comments.HeaderText = "Location"
        Comments.MappingName = "Location"
        Comments.ReadOnly = True
        Comments.Width = 120
        Comments.NullText = ""
        tbStyle.GridColumnStyles.Add(Comments)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 80
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim PowerType As New DataGridLabelColumn
        PowerType.Format = ""
        PowerType.FormatInfo = Nothing
        PowerType.HeaderText = "Power Type"
        PowerType.MappingName = "PowerType"
        PowerType.ReadOnly = True
        PowerType.Width = 100
        PowerType.NullText = ""
        tbStyle.GridColumnStyles.Add(PowerType)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yyyy HH:mm"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Date"
        StartDateTime.MappingName = "Date"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 100
        StartDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Dim DateType As New DataGridLabelColumn
        DateType.Format = ""
        DateType.FormatInfo = Nothing
        DateType.HeaderText = "Date Type"
        DateType.MappingName = "DateType"
        DateType.ReadOnly = True
        DateType.Width = 80
        DateType.NullText = ""
        tbStyle.GridColumnStyles.Add(DateType)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = "Alarms"
        Me.DGSmokeComo.TableStyles.Add(tbStyle)

    End Sub

    Private Sub SetupAdditionalDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgAdditional.TableStyles(0)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 250
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString
        Me.dgAdditional.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetupJobItemsDataGrid()
        Helper.SetUpDataGrid(dgJobItems)
        Dim tStyle As DataGridTableStyle = Me.dgJobItems.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgJobItems.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Summary As New DataGridLabelColumn
        Summary.Format = ""
        Summary.FormatInfo = Nothing
        Summary.HeaderText = "Summary"
        Summary.MappingName = "Summary"
        Summary.ReadOnly = True
        Summary.Width = 600
        Summary.NullText = ""
        tStyle.GridColumnStyles.Add(Summary)

        Dim NumAllocated As New DataGridLabelColumn
        NumAllocated.Format = ""
        NumAllocated.FormatInfo = Nothing
        NumAllocated.HeaderText = "No. Of Units Allocated to Job"
        NumAllocated.MappingName = "NumAllocated"
        NumAllocated.ReadOnly = True
        NumAllocated.Width = 75
        NumAllocated.NullText = ""
        tStyle.GridColumnStyles.Add(NumAllocated)

        Dim NumUnitsUsed As New DataGridEditableTextBoxColumn
        NumUnitsUsed.Format = "G"
        NumUnitsUsed.FormatInfo = Nothing
        NumUnitsUsed.HeaderText = "No.Of Units Used (Type value in cell)"
        NumUnitsUsed.MappingName = "NumUnitsUsed"
        NumUnitsUsed.ReadOnly = False
        NumUnitsUsed.Width = 75
        NumUnitsUsed.NullText = ""
        tStyle.GridColumnStyles.Add(NumUnitsUsed)

        tStyle.MappingName = Enums.TableNames.tblJobItem.ToString
        Me.dgJobItems.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPartsAndProductsDataGrid()

        Helper.SetUpDataGrid(Me.dgPartsAndProductsUsed)
        Dim tStyle As DataGridTableStyle = Me.dgPartsAndProductsUsed.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "type"
        type.ReadOnly = True
        type.Width = 100
        type.NullText = ""
        tStyle.GridColumnStyles.Add(type)

        Dim number As New DataGridLabelColumn
        number.Format = ""
        number.FormatInfo = Nothing
        number.HeaderText = "Number"
        number.MappingName = "number"
        number.ReadOnly = True
        number.Width = 250
        number.NullText = ""
        tStyle.GridColumnStyles.Add(number)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 300
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim quantity As New DataGridLabelColumn
        quantity.Format = ""
        quantity.FormatInfo = Nothing
        quantity.HeaderText = "Qty"
        quantity.MappingName = "quantity"
        quantity.ReadOnly = True
        quantity.Width = 60
        quantity.NullText = ""
        tStyle.GridColumnStyles.Add(quantity)

        Dim reference As New DataGridLabelColumn
        reference.Format = ""
        reference.FormatInfo = Nothing
        reference.HeaderText = "Reference"
        reference.MappingName = "reference"
        reference.ReadOnly = True
        reference.Width = 100
        reference.NullText = ""
        tStyle.GridColumnStyles.Add(reference)

        Dim asset As New DataGridLabelColumn
        asset.Format = ""
        asset.FormatInfo = Nothing
        asset.HeaderText = "Appliance"
        asset.MappingName = "asset"
        asset.ReadOnly = True
        asset.Width = 75
        asset.NullText = ""
        tStyle.GridColumnStyles.Add(asset)

        Dim BuyPrice As New DataGridLabelColumn
        BuyPrice.Format = "C"
        BuyPrice.FormatInfo = Nothing
        BuyPrice.HeaderText = "Buy Price"
        BuyPrice.MappingName = "BuyPrice"
        BuyPrice.ReadOnly = True
        BuyPrice.Width = 75
        BuyPrice.NullText = "0"
        tStyle.GridColumnStyles.Add(BuyPrice)

        Dim SellPrice As New DataGridLabelColumn
        SellPrice.Format = "C"
        SellPrice.FormatInfo = Nothing
        SellPrice.HeaderText = "Sell Price"
        SellPrice.MappingName = "SellPrice"
        SellPrice.ReadOnly = True
        SellPrice.Width = 75
        SellPrice.NullText = "0"
        tStyle.GridColumnStyles.Add(SellPrice)

        Dim OrderPartID As New DataGridLabelColumn
        OrderPartID.Format = ""
        OrderPartID.FormatInfo = Nothing
        OrderPartID.HeaderText = ""
        OrderPartID.MappingName = "OrderPartID"
        OrderPartID.ReadOnly = True

        OrderPartID.Width = 5
        OrderPartID.NullText = ""
        tStyle.GridColumnStyles.Add(OrderPartID)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
        Me.dgPartsAndProductsUsed.TableStyles.Add(tStyle)
    End Sub

    Private Sub SetupTimesheetDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgTimeSheets.TableStyles(0)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yyyy HH:mm"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Start Date&Time"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 180
        StartDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Dim EndDateTime As New DataGridLabelColumn
        EndDateTime.Format = "dd/MM/yyyy HH:mm"
        EndDateTime.FormatInfo = Nothing
        EndDateTime.HeaderText = "End Date&Time"
        EndDateTime.MappingName = "EndDateTime"
        EndDateTime.ReadOnly = True
        EndDateTime.Width = 180
        EndDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(EndDateTime)

        Dim TimeSheetType As New DataGridLabelColumn
        TimeSheetType.Format = ""
        TimeSheetType.FormatInfo = Nothing
        TimeSheetType.HeaderText = "Timesheet Type"
        TimeSheetType.MappingName = "TimeSheetType"
        TimeSheetType.ReadOnly = True
        TimeSheetType.Width = 180
        TimeSheetType.NullText = ""
        tbStyle.GridColumnStyles.Add(TimeSheetType)

        Dim Comments As New DataGridLabelColumn
        Comments.Format = ""
        Comments.FormatInfo = Nothing
        Comments.HeaderText = "Comments"
        Comments.MappingName = "Comments"
        Comments.ReadOnly = True
        Comments.Width = 180
        Comments.NullText = ""
        tbStyle.GridColumnStyles.Add(Comments)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Enums.TableNames.tblEngineerVisitTimesheet.ToString
        Me.dgTimeSheets.TableStyles.Add(tbStyle)
    End Sub

    Public Sub SetupAssetDataGrid()

        Helper.SetUpDataGrid(Me.dgAssets)
        Dim tStyle As DataGridTableStyle = Me.dgAssets.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgAssets.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Product As New DataGridLabelColumn
        Product.Format = ""
        Product.FormatInfo = Nothing
        Product.HeaderText = "Product"
        Product.MappingName = "Product"
        Product.ReadOnly = True
        Product.Width = 250
        Product.NullText = ""
        tStyle.GridColumnStyles.Add(Product)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 75
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 75
        SerialNum.NullText = ""
        tStyle.GridColumnStyles.Add(SerialNum)

        Dim GCNum As New DataGridLabelColumn
        GCNum.Format = ""
        GCNum.FormatInfo = Nothing
        GCNum.HeaderText = "GC Number"
        GCNum.MappingName = "GCNumber"
        GCNum.ReadOnly = True
        GCNum.Width = 75
        GCNum.NullText = ""
        tStyle.GridColumnStyles.Add(GCNum)

        Dim YearOfManufacture As New DataGridLabelColumn
        YearOfManufacture.Format = ""
        YearOfManufacture.FormatInfo = Nothing
        YearOfManufacture.HeaderText = "Year Of Manufacture"
        YearOfManufacture.MappingName = "YearOfManufacture"
        YearOfManufacture.ReadOnly = True
        YearOfManufacture.Width = 75
        YearOfManufacture.NullText = ""
        tStyle.GridColumnStyles.Add(YearOfManufacture)

        Dim ApproxValue As New DataGridLabelColumn
        ApproxValue.Format = "C"
        ApproxValue.FormatInfo = Nothing
        ApproxValue.HeaderText = "Approx.Value"
        ApproxValue.MappingName = "ApproximateValue"
        ApproxValue.ReadOnly = True
        ApproxValue.Width = 75
        ApproxValue.NullText = ""
        tStyle.GridColumnStyles.Add(ApproxValue)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblAsset.ToString
        Me.dgAssets.TableStyles.Add(tStyle)

        Helper.RemoveEventHandlers(Me.dgAssets)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMEngineerVisit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not EngVisitCharge Is Nothing Then
            If cbxReadyToBeInvoiced.Checked = True Then

                Dim errorMsg As String = ""
                If EngVisitCharge.NominalCode.Trim.Length = 0 Then
                    errorMsg += "* Nominal Code is Mandatory" & vbCrLf
                End If
                If EngVisitCharge.ForSageAccountCode.Trim.Length = 0 Then
                    errorMsg += "* Account Code is Mandatory" & vbCrLf
                End If
                If EngVisitCharge.Department.Trim.Length = 0 Then
                    errorMsg += "* Department is Mandatory" & vbCrLf
                End If

                If errorMsg.Length > 0 Then
                    e.Cancel = True
                    ShowMessage("Cannot close for the following reasons:" & vbCrLf & errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If chkShowJobCharges.Checked Then
            ShutdownNonChargableVisits(e)
            If e.Cancel Then
                Exit Sub
            End If
        End If

        If Not JobLock Is Nothing Then
            If JobLock.UserID = loggedInUser.UserID Then
                DB.JobLock.Delete(JobLock.JobLockID)
            End If
            _readOnly = False
        End If
    End Sub

    Private Sub FRMEngineerVisit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnInvoice.Visible = False
        LoadMe(sender, e)

        Me.tcWorkSheet.TabPages.Remove(Me.tpCharges)
        Me.tcWorkSheet.SelectedTab = Me.tpMainDetails
        Loading = True
        Me.cbxVisitLockDown.Checked = EngineerVisit.VisitLocked

        If cbxVisitLockDown.Checked = True Then
            PopulateCharges(True)
        End If

        Loading = False

        If Not Job Is Nothing Then
            If Job.StatusEnumID >= CInt(Enums.JobStatus.Complete) Then
                Me.cbxVisitLockDown.Enabled = False
                Me.cbxReadyToBeInvoiced.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnFindPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPartUsed.Click
        Dim partID As Integer = FindRecord(Enums.TableNames.tblPart)
        If Not partID = 0 Then
            Dim part As Entity.Parts.Part = DB.Part.Part_Get(partID)
            PartProductIDUsed = partID
            PartProductReferenceUsed = part.Reference
            isSpecialPart = part.IsSpecialPart
            Me.txtNumberUsed.Text = part.Number
            Me.txtNameUsed.Text = part.Name
            Me.nudQuantityUsed.Value = 1
            Me.lblSellPrice.Text = part.SellPrice
            Me.btnAddPartProductUsed.Text = "Add Part"
            Me.btnAddPartProductUsed.Enabled = True
            lblEquipment.Text = "False"
        End If
    End Sub

    Private Sub btnFindProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindProductUsed.Click
        Dim productID As Integer = FindRecord(Enums.TableNames.tblProduct)
        If Not productID = 0 Then
            Dim product As Entity.Products.Product = DB.Product.Product_Get(productID)
            PartProductIDUsed = productID
            PartProductReferenceUsed = product.Reference
            Me.txtNumberUsed.Text = product.Number
            Me.txtNameUsed.Text = product.Name
            Me.nudQuantityUsed.Value = 1
            Me.lblSellPrice.Text = product.SellPrice
            Me.btnAddPartProductUsed.Text = "Add Product"
            Me.btnAddPartProductUsed.Enabled = True
        End If
    End Sub

    Private Sub btnRemovePartProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemovePartProductUsed.Click

        If Me.dgPartsAndProductsUsed.CurrentRowIndex > -1 Then

            If EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("LocationID") = 0 And
                    (EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("AllocatedID") Is DBNull.Value OrElse
            EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("AllocatedID") = 0) Then
                ' wasn't got from anywhere in the first place.

                If EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Type") = "Part" Then
                    DB.EngineerVisitsPartsAndProducts.PartsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("UniqueID")))
                Else
                    DB.EngineerVisitsPartsAndProducts.ProductsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("UniqueID")))
                End If

                EngineerVisit.PartsAndProductsUsed.Table.AcceptChanges()
                EngineerVisit.PartsAndProductsUsed.Table.Rows.RemoveAt(Me.dgPartsAndProductsUsed.CurrentRowIndex)
            Else

                If RemovePart(EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Quantity"), EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Name"), EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Type"), EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("ID")) Then
                    'REMOVE FROM DB
                    If EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Type") = "Part" Then
                        DB.EngineerVisitsPartsAndProducts.PartsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("UniqueID")))
                    Else
                        DB.EngineerVisitsPartsAndProducts.ProductsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("UniqueID")))
                    End If

                    EngineerVisit.PartsAndProductsUsed.Table.AcceptChanges()
                    EngineerVisit.PartsAndProductsUsed.Table.Rows.RemoveAt(Me.dgPartsAndProductsUsed.CurrentRowIndex)
                End If

            End If
        Else
            ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAddPartProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPartProductUsed.Click
        If PartProductIDUsed = 0 Then
            ShowMessage("Part / Product not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Me.nudQuantityUsed.Value = 0 Then
            ShowMessage("Quantity not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim newRow As DataRow = EngineerVisit.PartsAndProductsUsed.Table.NewRow()

        newRow.Item("ID") = PartProductIDUsed
        If Me.btnAddPartProductUsed.Text = "Add Part" Then
            newRow.Item("Type") = "Part"

            Dim dialogue As FRMChooseAsset
            dialogue = checkIfExists(GetType(FRMChooseAsset).Name, True)
            If dialogue Is Nothing Then
                dialogue = Activator.CreateInstance(GetType(FRMChooseAsset))
            End If
            '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = False
            dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID
            dialogue.ShowDialog()

            dialogue.Close()
        Else
            newRow.Item("Type") = "Product"
        End If
        newRow.Item("Number") = Me.txtNumberUsed.Text
        newRow.Item("Name") = Me.txtNameUsed.Text
        newRow.Item("Quantity") = Me.nudQuantityUsed.Value
        newRow.Item("Reference") = PartProductReferenceUsed
        newRow.Item("SellPrice") = Me.lblSellPrice.Text
        newRow.Item("BuyPrice") = Me.lblSellPrice.Text
        newRow.Item("UniqueID") = 0

        If isSpecialPart Then

            Dim f As New FRMSpecialOrder(0, 0, 0)
            f.ShowDialog()
            If f.DialogResult = DialogResult.OK Then
                newRow.Item("Quantity") = f.Quantity
                newRow.Item("SellPrice") = f.Price
                newRow.Item("BuyPrice") = f.Price
                newRow.Item("SpecialPrice") = f.Price
                newRow.Item("Name") = f.PartName
                newRow.Item("SpecialDescription") = f.PartName
                newRow.Item("Number") = f.SPN
                newRow.Item("SpecialPartNumber") = f.SPN
                newRow.Item("LocationID") = 0
                newRow.Item("AllocatedID") = 0
            Else
                Exit Sub
            End If

        End If

        If Me.btnAddPartProductUsed.Text = "Add Part" And lblEquipment.Text = True Then
            EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow)

            PartProductIDUsed = 0
            Me.txtNumberUsed.Text = ""
            Me.txtNameUsed.Text = ""
            Me.nudQuantityUsed.Value = 1

            Me.btnAddPartProductUsed.Text = "PICK ITEM"
            Me.btnAddPartProductUsed.Enabled = False
        Else
            If DeclareWhereGotFrom(newRow.Item("Quantity"), newRow.Item("Name"), newRow.Item("Type"), newRow.Item("ID")) Then
                EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow)

                PartProductIDUsed = 0
                Me.txtNumberUsed.Text = ""
                Me.txtNameUsed.Text = ""
                Me.nudQuantityUsed.Value = 1

                Me.btnAddPartProductUsed.Text = "PICK ITEM"
                Me.btnAddPartProductUsed.Enabled = False
            End If
        End If
    End Sub

    Private Sub dtpStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        dtpEndDate.Value = dtpStartDate.Value.AddMinutes(1)
    End Sub

    Private Sub btnAddTimeSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTimeSheet.Click

        If Not dtpEndDate.Value.Date = dtpStartDate.Value.Date Then
            MessageBox.Show("Start Day must be the same as the End Day", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not dtpEndDate.Value > dtpStartDate.Value Then
            MessageBox.Show("End date & time must be after Start date & time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not CInt(Combo.GetSelectedItemValue(cboTimeSheetType)) > 0 Then
            MessageBox.Show("Select a Timesheet Type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Exit Sub
        End If

        For Each timesheet As DataRow In EngineerVisit.TimeSheets.Table.Rows
            If dtpStartDate.Value >= timesheet("StartDateTime") And
                                    dtpStartDate.Value <= timesheet("EndDateTime") Then
                MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If dtpEndDate.Value >= timesheet("StartDateTime") And
                                    dtpEndDate.Value <= timesheet("EndDateTime") Then
                MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If dtpStartDate.Value <= timesheet("StartDateTime") And
                                  dtpEndDate.Value >= timesheet("EndDateTime") Then
                MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        Next timesheet

        Dim newRow As DataRow = EngineerVisit.TimeSheets.Table.NewRow()
        'TIMESHHETS ADD
        newRow.Item("StartDateTime") = CDate(Format(dtpStartDate.Value, "dd/MMM/yyyy HH:mm") & ":00")
        newRow.Item("EndDateTime") = CDate(Format(dtpEndDate.Value, "dd/MMM/yyyy HH:mm") & ":00")
        newRow.Item("Comments") = Me.txtComments.Text
        newRow.Item("TimesheetTypeID") = Combo.GetSelectedItemValue(cboTimeSheetType)
        newRow.Item("TimesheetType") = Combo.GetSelectedItemDescription(cboTimeSheetType)

        EngineerVisit.TimeSheets.Table.Rows.Add(newRow)

        dtpStartDate.Value = Now
        dtpEndDate.Value = Now.AddMinutes(1)
        Me.txtComments.Text = ""
        Combo.SetSelectedComboItem_By_Value(cboTimeSheetType, "0")

    End Sub

    Private Sub btnRemoveTimeSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTimeSheet.Click
        If Me.dgTimeSheets.CurrentRowIndex > -1 Then
            EngineerVisit.TimeSheets.Table.AcceptChanges()
            EngineerVisit.TimeSheets.Table.Rows.RemoveAt(Me.dgTimeSheets.CurrentRowIndex)
        Else
            ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cbxVisitLockDown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxVisitLockDown.CheckedChanged
        If loops = 0 Then
            If Not Loading Then
                If cbxVisitLockDown.Checked Then
                    If PartsAndProductsAllocated.Table.Select("Status = " & False).Length > 0 Then
                        loops = 1
                        cbxVisitLockDown.Checked = False
                        ShowMessage("All allocated parts must be distributed before locking the visit down", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If (Combo.GetSelectedItemValue(Me.cboOutcome) = Enums.EngineerVisitOutcomes.Complete) Then
                        If (Me.Job?.JobTypeID = Enums.JobTypes.Commission) Then
                            If MessageBox.Show("Have You" & vbCrLf & "- Changed fuels?" & vbCrLf & "- Changed last service date?" & vbCrLf &
                                               "- Deactivated old Assets?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                                ShowMessage("Please complete the tasks and then try again.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                cbxVisitLockDown.Checked = False
                                Exit Sub
                            End If
                        End If
                    End If

                    'This will : save any changes, lock visit down AND enable the visit charge tab-are you sure
                    If MessageBox.Show("Any changes will now be saved, the visit details will be locked and the visit charges made available" & vbCrLf &
                                        "Do you want to continue?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                        If Save() Then
                            lblStatusWarning.Visible = True
                            Me.tcWorkSheet.TabPages.Add(Me.tpCharges)
                            Me.tpCharges.Visible = True
                            Me.tcWorkSheet.SelectedTab = Me.tpCharges
                            PopulateCharges(True)
                            Me.tpPartsAndProducts.Enabled = False
                            Me.tpTimesheets.Enabled = True
                            Me.tpAppliances.Enabled = False
                            Me.tpOutcomes.Enabled = False

                            ' Me.tpMainDetails.Enabled = False
                            cboOutcome.Enabled = False
                            txtOutcomeDetails.ReadOnly = True
                            txtNotesFromEngineer.ReadOnly = True
                            '   dgJobItems.ReadOnly = True
                            cboEngineer.Enabled = False
                            txtCustomer.Enabled = False
                            cboSignatureSelected.Enabled = False
                            cbxEmailReceiptToCustomer.Enabled = False

                            btnEditInvoiceNotes.Visible = True
                        Else
                            cbxVisitLockDown.Checked = False
                        End If
                    Else
                        cbxVisitLockDown.Checked = False
                    End If
                Else
                    If DB.EngineerVisitCharge.EngineerVisitCharge_Check(EngineerVisit.EngineerVisitID) > 0 Then
                        loops = 1
                        cbxVisitLockDown.Checked = True
                        cbxVisitLockDown.Enabled = False
                        Exit Sub
                    End If
                    If CurrentCustomerID <> 2846 Then
                        If EnterOverridePasswordINV() Then
                        Else
                            loops = 1
                            cbxVisitLockDown.Checked = True
                            cbxVisitLockDown.Enabled = False
                            Exit Sub

                        End If
                    End If

                    DeleteCharges()
                    lblStatusWarning.Visible = False
                    Me.tcWorkSheet.TabPages.Remove(Me.tpCharges)
                    Me.tcWorkSheet.SelectedTab = Me.tpMainDetails
                    Me.tpPartsAndProducts.Enabled = True
                    Me.tpTimesheets.Enabled = True
                    Me.tpAppliances.Enabled = True
                    Me.tpOutcomes.Enabled = True

                    'Me.tpMainDetails.Enabled = True
                    cboOutcome.Enabled = True
                    txtOutcomeDetails.ReadOnly = False
                    txtNotesFromEngineer.ReadOnly = False
                    dgJobItems.ReadOnly = False
                    cboEngineer.Enabled = True
                    txtCustomer.Enabled = True
                    cboSignatureSelected.Enabled = True
                    cbxEmailReceiptToCustomer.Enabled = True
                    btnEditInvoiceNotes.Visible = False
                End If
            Else
                If cbxVisitLockDown.Checked Then
                    lblStatusWarning.Visible = True
                    Me.tcWorkSheet.TabPages.Add(Me.tpCharges)
                    Me.tpCharges.Visible = True
                    Me.tcWorkSheet.SelectedTab = Me.tpCharges
                    Me.tpPartsAndProducts.Enabled = False
                    Me.tpTimesheets.Enabled = True
                    Me.tpAppliances.Enabled = False
                    Me.tpOutcomes.Enabled = False

                    '  Me.tpMainDetails.Enabled = False
                    cboOutcome.Enabled = False
                    txtOutcomeDetails.ReadOnly = True
                    txtNotesFromEngineer.ReadOnly = True
                    '     dgJobItems.ReadOnly = True
                    cboEngineer.Enabled = False
                    txtCustomer.Enabled = False
                    cboSignatureSelected.Enabled = False
                    cbxEmailReceiptToCustomer.Enabled = False

                    btnEditInvoiceNotes.Visible = True
                Else

                    If DB.EngineerVisitCharge.EngineerVisitCharge_Check(EngineerVisit.EngineerVisitID) > 0 Then

                        loops = 1
                        cbxVisitLockDown.Checked = True
                        cbxVisitLockDown.Enabled = False

                        Exit Sub
                    End If
                    lblStatusWarning.Visible = False
                    Me.tcWorkSheet.TabPages.Remove(Me.tpCharges)
                    Me.tcWorkSheet.SelectedTab = Me.tpMainDetails
                    Me.tpPartsAndProducts.Enabled = True
                    Me.tpTimesheets.Enabled = True
                    Me.tpOutcomes.Enabled = True

                    'Me.tpMainDetails.Enabled = True
                    cboOutcome.Enabled = True
                    txtOutcomeDetails.ReadOnly = False
                    txtNotesFromEngineer.ReadOnly = False
                    dgJobItems.ReadOnly = False
                    cboEngineer.Enabled = True
                    txtCustomer.Enabled = True
                    cboSignatureSelected.Enabled = True
                    cbxEmailReceiptToCustomer.Enabled = True
                    btnEditInvoiceNotes.Visible = False

                End If
            End If
        Else
            loops = 0
        End If

    End Sub

    Private Sub btnOrders_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrders.Click
        If ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Navigation.Navigate(Enums.MenuTypes.Spares) = True Then
                If Me.Modal Then
                    Me.Close()
                Else
                    Me.Dispose()
                End If

                If Not LogCalloutForm Is Nothing Then
                    LogCalloutForm.CloseForm()
                End If

                ShowForm(GetType(FRMOrderManager), False, New Object() {DB.Order.Orders_GetForEngineerVisit(EngineerVisit.EngineerVisitID), Nothing})
            End If
        End If
    End Sub

    Private Sub btnInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        Dim errorMsg As String = ""
        If cbxReadyToBeInvoiced.Checked = False Then
            errorMsg += "* Visit is not ready to be invoiced" & vbCrLf
        End If

        If EngVisitCharge.NominalCode.Trim.Length = 0 Then

        End If
        If EngVisitCharge.ForSageAccountCode.Trim.Length = 0 Then
            errorMsg += "* Account Code is Mandatory" & vbCrLf
        End If
        If EngVisitCharge.Department.Trim.Length = 0 Then
            errorMsg += "* Department is Mandatory" & vbCrLf
        End If

        If errorMsg.Length > 0 Then
            '  e.Cancel = True
            ShowMessage("Cannot close for the following reasons:" & vbCrLf & errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Navigation.Navigate(Enums.MenuTypes.Invoicing) = True Then
                If Me.Modal Then
                    Me.Close()
                Else
                    Me.Dispose()
                End If

                If Not LogCalloutForm Is Nothing Then
                    LogCalloutForm.CloseForm()
                End If

                Dim dv As DataView = DB.InvoiceToBeRaised.Invoices_GetAll_For_EngineerVisitChargeID(EngVisitCharge.EngineerVisitChargeID)

                Dim checked As Boolean = True
                If dv.Table.Rows.Count > 0 Then
                    If DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(dv.Table.Rows(0).Item("InvoiceToBeRaisedID")).Table.Rows.Count > 0 Then
                        checked = False
                    End If
                End If

                If checked = False Then
                    ShowForm(GetType(FRMInvoicedManager), False, New Object() {dv, checked, GetParameter(1)})
                Else
                    ShowForm(GetType(FRMInvoiceManager), False, New Object() {dv, checked, GetParameter(1)})
                End If

            End If
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Save() Then

            Dim dt As DataTable = DB.ExecuteWithReturn("Select TestType From tblEngineerVisitAdditionalChecks Where EngineerVisitID = " & EngineerVisit.EngineerVisitID)
            For Each dr As DataRow In dt.Rows
                If dr("TestType") = 69318 Or dr("TestType") = 69319 Or dr("TestType") = 69473 Or dr("TestType") = 69592 Then
                    Dim details As New ArrayList
                    details.Add(EngineerVisit.EngineerVisitID)
                    details.Add(dr("TestType"))
                    Dim oPrint As New Printing(details, "QC Results", Enums.SystemDocumentType.QCPrint)
                End If

            Next

        End If
    End Sub

    Private Sub dgVisitDefects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVisitDefects.DoubleClick

        If Me.SelectedVisitDefectDataRow Is Nothing Then
            Exit Sub
        End If

        Dim dialogue As DLGEngineerVisitDefect
        dialogue = checkIfExists(GetType(DLGEngineerVisitDefect).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGEngineerVisitDefect))
        End If

        '    dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.Defect = DB.EngineerVisitDefects.EngineerVisitDefects_Get(SelectedVisitDefectDataRow.Item("EngineerVisitDefectID"))
        dialogue.EngineerVisit = EngineerVisit
        dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID()
        dialogue.Updating = True
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.VisitDefectDataview = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID)
        End If

        dialogue.Close()

    End Sub

    Private Sub dgApplianceWorkSheets_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgApplianceWorkSheets.DoubleClick
        If Me.SelectedApplianceWorkSheetDataRow Is Nothing Then
            Exit Sub
        End If

        Dim dialogue As DLGVisitAssetWorkSheet
        dialogue = checkIfExists(GetType(DLGVisitAssetWorkSheet).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGVisitAssetWorkSheet))
        End If

        '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.Worksheet = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_Get(SelectedApplianceWorkSheetDataRow.Item("EngineerVisitAssetWorkSheetID"))
        dialogue.EngineerVisit = EngineerVisit
        dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID()
        dialogue.Updating = True
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.ApplianceWorkSheetDataview = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID)
        End If

        dialogue.Close()
    End Sub

    Private Sub dgAdditionalWorkSheets_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAdditional.DoubleClick
        If Me.SelectedAdditionalWorkSheetDataRow Is Nothing Then
            Exit Sub
        End If

        Dim dialogue As DLGVisitAdditionalWorkSheet
        dialogue = checkIfExists(GetType(DLGVisitAdditionalWorkSheet).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGVisitAdditionalWorkSheet))
        End If

        '    dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.Worksheet = DB.EngineerVisitAdditional.EngineerVisitAdditional_Get(SelectedAdditionalWorkSheetDataRow.Item("EngineerVisitAdditionalID"))
        dialogue.EngineerVisit = EngineerVisit
        dialogue.TheSite = theSite
        dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID()
        dialogue.Updating = True
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.AdditionalWorkSheetDataview = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID, 0)
        End If

        dialogue.Close()
    End Sub

    Private Sub dgSmokeComoWorkSheets_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGSmokeComo.DoubleClick
        If Me.SelectedSmokeComoDataRow Is Nothing Then
            Exit Sub
        End If

        Dim dialogue As FRMSmokeComo
        dialogue = checkIfExists(GetType(FRMSmokeComo).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(FRMSmokeComo))
        End If

        '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False

        Combo.SetUpCombo(dialogue.cboDetType, DB.Picklists.GetAll(Enums.PickListTypes.TestType).Table.Select("PercentageRate = 1.00").CopyToDataTable, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(dialogue.cboPower, DB.Picklists.GetAll(55).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(dialogue.cboDateType, DynamicDataTables.ComoDateType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)

        dialogue.AdditionalID = SelectedSmokeComoDataRow.Item("EngineerVisitAdditionalID")
        dialogue.EngineerVisitID = EngineerVisit.EngineerVisitID
        Try
            dialogue.dtpDate.Value = CDate(SelectedSmokeComoDataRow.Item("Date"))
        Catch ex As Exception
            '  dialogue.dtpDate.Enabled = False
            dialogue.chkNA.Checked = True
            dialogue.dtpDate.Enabled = False
        End Try

        Combo.SetSelectedComboItem_By_Description(dialogue.cboDetType, SelectedSmokeComoDataRow.Item("Type"))
        Combo.SetSelectedComboItem_By_Description(dialogue.cboPower, SelectedSmokeComoDataRow.Item("PowerType"))
        Combo.SetSelectedComboItem_By_Description(dialogue.cboDateType, SelectedSmokeComoDataRow.Item("DateType"))

        dialogue.txtLocation.Text = SelectedSmokeComoDataRow.Item("Location")

        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.SmokeComoDataview = DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID)
        End If

        dialogue.Close()
    End Sub

    Private Sub btnAddSmokeComo_Click(sender As Object, e As EventArgs) Handles btnAddSmokeComo.Click

        Dim dialogue As FRMSmokeComo
        dialogue = checkIfExists(GetType(FRMSmokeComo).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(FRMSmokeComo))
        End If
        dialogue.ShowInTaskbar = False

        Combo.SetUpCombo(dialogue.cboDetType, DB.Picklists.GetAll(Enums.PickListTypes.TestType).Table.Select("PercentageRate = 1.00").CopyToDataTable, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(dialogue.cboPower, DB.Picklists.GetAll(55).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(dialogue.cboDateType, DynamicDataTables.ComoDateType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)

        dialogue.EngineerVisitID = EngineerVisit.EngineerVisitID
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.SmokeComoDataview = DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID)
        End If

        dialogue.Close()

    End Sub

    Private Sub btnRemoveSmokeComo_Click(sender As Object, e As EventArgs) Handles btnRemoveSmokeComo.Click

        If Me.SelectedSmokeComoDataRow Is Nothing Then
            Exit Sub
        End If

        DB.EngineerVisitAdditional.Delete(SelectedSmokeComoDataRow.Item("EngineerVisitAdditionalID"))

        Me.SmokeComoDataview = DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID)

    End Sub

    Private Sub btnAddVisitDefect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVisitDefect.Click

        Dim dialogue As DLGEngineerVisitDefect
        dialogue = checkIfExists(GetType(DLGEngineerVisitDefect).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGEngineerVisitDefect))
        End If

        '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.Defect = New Entity.EngineerVisitDefectss.EngineerVisitDefects
        dialogue.EngineerVisit = EngineerVisit
        dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID()
        dialogue.Updating = False
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.VisitDefectDataview = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID)
        End If

        dialogue.Close()

    End Sub

    Private Sub btnAddApplianceWorksheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddApplianceWorksheet.Click

        Dim dialogue As DLGVisitAssetWorkSheet
        dialogue = checkIfExists(GetType(DLGVisitAssetWorkSheet).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGVisitAssetWorkSheet))
        End If

        '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.Worksheet = New Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet
        dialogue.EngineerVisit = EngineerVisit
        dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID()
        dialogue.Updating = False
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.ApplianceWorkSheetDataview = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID)
        End If

        dialogue.Close()

    End Sub

    Private Sub btnAddAdd_Click(sender As Object, e As EventArgs)

        Dim dialogue As DLGVisitAdditionalWorkSheet
        dialogue = checkIfExists(GetType(DLGVisitAdditionalWorkSheet).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGVisitAdditionalWorkSheet))
        End If

        '  dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.Worksheet = New Entity.EngineerVisitAdditionals.EngineerVisitAdditional
        dialogue.EngineerVisit = EngineerVisit
        dialogue.TheSite = theSite
        dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID()
        dialogue.Updating = False
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Me.AdditionalWorkSheetDataview = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID)
        End If

        dialogue.Close()

    End Sub

    Private Sub btnRemoveVisitDefect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveVisitDefect.Click

        If Me.SelectedVisitDefectDataRow Is Nothing Then
            Exit Sub
        End If

        DB.EngineerVisitDefects.Delete(SelectedVisitDefectDataRow.Item("EngineerVisitDefectID"))

        Me.VisitDefectDataview = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID)

    End Sub

    Private Sub btnRemoveApplianceWorkSheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveApplianceWorkSheet.Click

        If Me.SelectedApplianceWorkSheetDataRow Is Nothing Then
            Exit Sub
        End If

        DB.EngineerVisitAssetWorkSheet.Delete(SelectedApplianceWorkSheetDataRow.Item("EngineerVisitAssetWorkSheetID"))

        Me.ApplianceWorkSheetDataview = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID)

    End Sub

    Private Sub btnRemoveAdd_Click(sender As Object, e As EventArgs)
        If Me.SelectedAdditionalWorkSheetDataRow Is Nothing Then
            Exit Sub
        End If

        DB.EngineerVisitAdditional.Delete(SelectedAdditionalWorkSheetDataRow.Item("EngineerVisitAdditionalID"))

        Me.ApplianceWorkSheetDataview = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID)

    End Sub

    Private Sub btnPrintGSR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintGSR.Click
        If Save() Then

            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            Dim oPrint As New Printing(details, "Gas Safety Record ", Enums.SystemDocumentType.GSR)

            DocumentsControl.Populate()

        End If

    End Sub

    Private Sub btnPrintSVR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSVR.Click
        SVRs.Show(btnPrintSVR, New Point(0, 0))

    End Sub

    Private Sub dgJobItems_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgJobItems.CurrentCellChanged

    End Sub

    Private Sub cboRecall_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecall.SelectedIndexChanged
        Select Case Combo.GetSelectedItemValue(cboRecall)
            Case 0, 387
                Combo.SetSelectedComboItem_By_Value(Me.cboRecallEngineer, 0)
                Me.cboRecallEngineer.Enabled = False
            Case Else
                Me.cboRecallEngineer.Enabled = True
        End Select
    End Sub

    Private Sub btnJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJob.Click
        Dim showJob As Boolean = True
        Select Case ShowMessage("This form will reload when the job form is closed. Do you want to save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Case DialogResult.Yes
                showJob = Save()
            Case DialogResult.Cancel
                showJob = False
        End Select

        If showJob Then
            ShowForm(GetType(FRMLogCallout), True, New Object() {Job.JobID, theSite.SiteID, Me, Nothing, EngineerVisit.EngineerVisitID})
            EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_New_As_Object(Helper.MakeIntegerValid(GetParameter(0)))
        End If
    End Sub

    Private Sub chkRecharge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecharge.CheckedChanged
        lblRechargeTicked.Visible = chkRecharge.Checked
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        Job = DB.Job.Get(EngineerVisit.EngineerVisitID, Entity.Jobs.GetBy.EngineerVisitId)
        theSite = DB.Sites.Get(Job.PropertyID)

        If loggedInUser.UserRegions.Count > 0 Then
            If loggedInUser.UserRegions.Table.Select("RegionID = " & theSite.RegionID).Length < 1 Then
                Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        Else
            Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        Dim customer As Entity.Customers.Customer = DB.Customer.Customer_Get_ForSiteID(theSite.SiteID)
        Dim ho As Entity.Sites.Site = DB.Sites.Get(customer.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq)

        Me.Text = String.Format("Engineer Visit ID: {0}, Job No: {1}, Property: {2}, Customer: {3}",
        EngineerVisit.EngineerVisitID, Job.JobNumber, theSite.Name, customer.Name)
        CurrentCustomerID = customer.CustomerID

        If Not ho Is Nothing AndAlso ho.EmailAddress.Length > 0 Then
            txtCustEmail.Text = "Customer Email: " & ho.EmailAddress
        Else
            txtCustEmail.Text = ""
        End If

        Dim closeMe As Boolean = False

        Select Case CInt(EngineerVisit.StatusEnumID)
            Case CInt(Enums.VisitStatus.NOT_SET)
                ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                closeMe = True
            Case CInt(Enums.VisitStatus.Parts_Need_Ordering)
                ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                closeMe = True
            Case CInt(Enums.VisitStatus.Waiting_For_Parts)
                ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                closeMe = True
            Case CInt(Enums.VisitStatus.Ready_For_Schedule)
                Me.txtStatus.Text = "Ready For Schedule"
                Me.txtUploadedBy.Text = "Not Set"
            Case CInt(Enums.VisitStatus.Scheduled)
                Me.txtStatus.Text = "Scheduled"
                Me.txtUploadedBy.Text = "Not Set"
            Case CInt(Enums.VisitStatus.Downloaded)
                ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                closeMe = True
            Case Else
                Me.txtStatus.Text = EngineerVisit.VisitStatus
                If EngineerVisit.ManualEntryByUserID = 0 Then
                    Me.txtUploadedBy.Text = "Engineer via PDA (See timesheets for date)"
                Else
                    Me.txtUploadedBy.Text = DB.User.Get(EngineerVisit.ManualEntryByUserID).Fullname & " via PC @ " & Format(EngineerVisit.ManualEntryOn, "dddd dd MMMM yyyy HH:mm:ss")
                End If
        End Select

        If closeMe Then
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        Else

            If EngineerVisit.OutcomeEnumID = 0 Then
                Updating = False
                Me.cboOutcome.Enabled = True
            Else
                Me.cboEngineer.Enabled = False
                Me.cboOutcome.Enabled = False
            End If

            Combo.SetSelectedComboItem_By_Value(Me.cboOutcome, EngineerVisit.OutcomeEnumID)
            Select Case CType(EngineerVisit.OutcomeEnumID, Enums.EngineerVisitOutcomes)
                Case Enums.EngineerVisitOutcomes.Carded
                    Me.btnChangeOutcome.Visible = True
                Case Enums.EngineerVisitOutcomes.Complete
                    Me.btnChangeOutcome.Visible = True
                Case Enums.EngineerVisitOutcomes.Further_Works
                    Me.btnChangeOutcome.Visible = True
                Case Enums.EngineerVisitOutcomes.Could_Not_Start
                    Me.btnChangeOutcome.Visible = True
                Case Else
                    Me.btnChangeOutcome.Visible = loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Servicing)
            End Select

            Me.txtOutcomeDetails.Text = EngineerVisit.OutcomeDetails
            Combo.SetSelectedComboItem_By_Value(Me.cboEngineer, EngineerVisit.EngineerID)

            If Combo.GetSelectedItemValue(cboEngineer) = 0 And EngineerVisit.EngineerID Then
                Dim nc As New Combo(DB.Engineer.Engineer_Get(EngineerVisit.EngineerID).Name, EngineerVisit.EngineerID)

                cboEngineer.Items.Add(nc)
                Combo.SetSelectedComboItem_By_Value(Me.cboEngineer, EngineerVisit.EngineerID)
            End If

            If Not EngineerVisit.CustomerSignature Is Nothing Then
                pbCustomerSignature.Image = New Bitmap(New IO.MemoryStream(EngineerVisit.CustomerSignature))
            End If
            Me.txtCustomer.Text = EngineerVisit.CustomerName
            If Not EngineerVisit.EngineerSignature Is Nothing Then
                pbEngineerSignature.Image = New Bitmap(New IO.MemoryStream(EngineerVisit.EngineerSignature))
            End If
            Me.txtNotesToEngineer.Text = EngineerVisit.NotesToEngineer
            Me.txtNotesFromEngineer.Text = EngineerVisit.NotesFromEngineer
            Me.txtScheduledTime.Text = "From "
            If EngineerVisit.StartDateTime = Nothing Then
                Me.txtScheduledTime.Text += "'Not Set' "
            Else
                Me.txtScheduledTime.Text += Format(EngineerVisit.StartDateTime, "dddd dd MMMM yyyy HH:mm:ss")
            End If
            Me.txtScheduledTime.Text += " to "
            If EngineerVisit.EndDateTime = Nothing Then
                Me.txtScheduledTime.Text += "'Not Set' "
            Else
                Me.txtScheduledTime.Text += Format(EngineerVisit.EndDateTime, "dddd dd MMMM yyyy HH:mm:ss")
            End If

            '-------------------------------

            If EngineerVisit.StartDateTime = Nothing Then
                Me.txtScheduledTime2.Text += "'Not Set' "
            Else
                Me.txtScheduledTime2.Text += Format(EngineerVisit.StartDateTime, "ddd dd/MM/yyyy HH:mm:ss")
            End If
            Me.txtScheduledTime2.Text += "-"
            If EngineerVisit.EndDateTime = Nothing Then
                Me.txtScheduledTime2.Text += "'Not Set' "
            Else
                Me.txtScheduledTime2.Text += Format(EngineerVisit.EndDateTime, "ddd dd/MM/yyyy HH:mm:ss")
            End If
            '--------------------------------

            JobItems = DB.EngineerVisits.EngineerVisitUnitsUsed_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID)
            dgPartsAndProductsUsed.DataSource = EngineerVisit.PartsAndProductsUsed
            dgTimeSheets.DataSource = EngineerVisit.TimeSheets
            TimesheetCalc()

            SmokeComoDataview = DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID)

            ApplianceWorkSheetDataview = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID)
            VisitDefectDataview = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID)
            AdditionalWorkSheetDataview = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID)

            Combo.SetSelectedComboItem_By_Value(Me.cboEmergencyControlAccessible, EngineerVisit.EmergencyControlAccessibleID)
            Combo.SetSelectedComboItem_By_Value(Me.cboBonding, EngineerVisit.BondingID)
            Combo.SetSelectedComboItem_By_Value(Me.cboGasInstallationTightnessTest, EngineerVisit.GasInstallationTightnessTestID)
            Combo.SetSelectedComboItem_By_Value(Me.cboPropertyRented, EngineerVisit.PropertyRented)
            Combo.SetSelectedComboItem_By_Value(Me.cboSignatureSelected, EngineerVisit.SignatureSelectedID)
            Combo.SetSelectedComboItem_By_Value(Me.cboPaymentMethod, EngineerVisit.PaymentMethodID)
            Combo.SetSelectedComboItem_By_Value(Me.cboRecharge, EngineerVisit.RechargeTypeID)
            Combo.SetSelectedComboItem_By_Value(Me.cboNccRad, EngineerVisit.NccRadID)
            Combo.SetSelectedComboItem_By_Value(Me.cboMeterLocation, EngineerVisit.MeterLocationID)
            Combo.SetSelectedComboItem_By_Value(Me.cboMeterCapped, EngineerVisit.MeterCappedID)

            Me.txtAmountCollected.Text = EngineerVisit.AmountCollected

            Me.chkGasServiceCompleted.Checked = EngineerVisit.GasServiceCompleted

            PopulateSiteFuelDataGrid()
            Me.chkRecharge.Checked = EngineerVisit.Recharge

            PartsAndProductsAllocated = EngineerVisit.PartsAndProductsAllocated

            ' If AssetsDataView Is Nothing Then
            AssetsDataView = DB.Asset.Asset_GetForSite(Job.PropertyID)
            'End If

            For Each row As DataRow In AssetsDataView.Table.Rows
                For Each dr As DataRow In DB.JobAsset.JobAsset_Get_For_Job(Job.JobID).Table.Rows
                    If CInt(row.Item("AssetID")) = dr("AssetID") Then
                        row.Item("Tick") = True
                        Exit For
                    End If
                Next
            Next

            Me.cbxEmailReceiptToCustomer.Checked = EngineerVisit.EmailReceipt

            QC = DB.EngineerVisitQCSQL.EngineerVisitQC_Get_EngineerVisitID(EngineerVisit.EngineerVisitID)
            If QC Is Nothing Then
                QC = New Entity.EngineerVisitQCs.EngineerVisitQC
            End If

            Combo.SetSelectedComboItem_By_Value(cboQCAppliance, QC.ApplianceRecorded)
            Combo.SetSelectedComboItem_By_Value(cboQCCustSig, QC.CustomerSigned)
            Combo.SetSelectedComboItem_By_Value(cboQCCustomerDetails, QC.CustomerDetailsIncorrect)
            Combo.SetSelectedComboItem_By_Value(cboQCEngineerPaymentRecieved, QC.EngineerPaymentReceived)
            Combo.SetSelectedComboItem_By_Value(cboQCJobType, QC.JobTypeIncorrect)
            Combo.SetSelectedComboItem_By_Value(cboQCJobUploadTimescale, QC.JobUploadInTimeScale)
            Combo.SetSelectedComboItem_By_Value(cboQCLabourTime, QC.LabourTimeMissing)
            Combo.SetSelectedComboItem_By_Value(cboQCLGSR, QC.LGSRMissing)
            Combo.SetSelectedComboItem_By_Value(cboQCOrderNo, QC.OrderNumberAttached)
            Combo.SetSelectedComboItem_By_Value(cboQCParts, QC.PartsConfirmation)
            Combo.SetSelectedComboItem_By_Value(cboQCPaymentCollection, QC.PaymentCollection)
            Combo.SetSelectedComboItem_By_Value(cboQCPaymentMethod, QC.PaymentMethodDetailed)
            Combo.SetSelectedComboItem_By_Value(cboQCPaymentSelection, QC.PaymentMethodSelectionIncorrect)
            Combo.SetSelectedComboItem_By_Value(cboQCScheduleOfRate, QC.SorIncorrect)
            Combo.SetSelectedComboItem_By_Value(cboFTFCode, QC.FTFCode)
            Combo.SetSelectedComboItem_By_Value(cboRecall, QC.Recall)
            Combo.SetSelectedComboItem_By_Value(cboRecallEngineer, QC.EngineerID)
            Me.txtQCPoorJobNotes.Text = QC.PoorJobNotes
            chkQCDocumentsRecieved.Checked = QC.DocumentsRecieved
            dtpQCDocumentsRecieved.Value = IIf(QC.DateDocumentsRecieved <> Nothing, QC.DateDocumentsRecieved, Now)

            Profitable()

            If Not EngineerVisit.EngineerVisitNCCGSR Is Nothing Then
                txtApproxAgeOfBoiler.Text = EngineerVisit.EngineerVisitNCCGSR.ApproxAgeOfBoiler
                txtRadiators.Text = EngineerVisit.EngineerVisitNCCGSR.Radiators
                txtVisualInspectionReason.Text = EngineerVisit.EngineerVisitNCCGSR.VisualInspectionReason

                Combo.SetSelectedComboItem_By_Value(cboCertificateTypeID, EngineerVisit.EngineerVisitNCCGSR.CertificateTypeID)
                Combo.SetSelectedComboItem_By_Value(cboCODetectorFittedID, EngineerVisit.EngineerVisitNCCGSR.CODetectorFittedID)
                Combo.SetSelectedComboItem_By_Value(cboCorrectMaterialsUsedID, EngineerVisit.EngineerVisitNCCGSR.CorrectMaterialsUsedID)
                Combo.SetSelectedComboItem_By_Value(cboCylinderTypeID, EngineerVisit.EngineerVisitNCCGSR.CylinderTypeID)
                Combo.SetSelectedComboItem_By_Value(cboHeatingSystemTypeID, EngineerVisit.EngineerVisitNCCGSR.HeatingSystemTypeID)
                Combo.SetSelectedComboItem_By_Value(cboImmersionID, EngineerVisit.EngineerVisitNCCGSR.ImmersionID)
                Combo.SetSelectedComboItem_By_Value(cboInstallationPipeWorkCorrectID, EngineerVisit.EngineerVisitNCCGSR.InstallationPipeWorkCorrectID)
                Combo.SetSelectedComboItem_By_Value(cboInstallationSafeToUseID, EngineerVisit.EngineerVisitNCCGSR.InstallationSafeToUseID)
                Combo.SetSelectedComboItem_By_Value(cboJacketID, EngineerVisit.EngineerVisitNCCGSR.JacketID)
                Combo.SetSelectedComboItem_By_Value(cboPartialHeatingID, EngineerVisit.EngineerVisitNCCGSR.PartialHeatingID)
                Combo.SetSelectedComboItem_By_Value(cboStrainerFittedID, EngineerVisit.EngineerVisitNCCGSR.StrainerFittedID)
                Combo.SetSelectedComboItem_By_Value(cboStrainerInspectedID, EngineerVisit.EngineerVisitNCCGSR.StrainerInspectedID)
                Combo.SetSelectedComboItem_By_Value(cboVisualInspectionSatisfactoryID, EngineerVisit.EngineerVisitNCCGSR.VisualInspectionSatisfactoryID)

                Combo.SetSelectedComboItem_By_Value(cboSITimer, EngineerVisit.EngineerVisitNCCGSR.SITimerID)
                Combo.SetSelectedComboItem_By_Value(cboFillDisc, EngineerVisit.EngineerVisitNCCGSR.FillDiscID)

            End If
            Dim AdditionalDT As DataTable = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID).Table

            '   Dim AdditionalDT As Integer = DB.ExecuteWithReturn("SELECT COUNT(*) FROM tblEngineerVisitAdditionalChecks where (TestType = 69318 OR TestType = 69319 OR TestType = 69473 OR TestType = 69592) AND EngineerVisitID = " & EngineerVisit.EngineerVisitID & "")
            ASHPWorksheetToolStripMenuItem.Visible = False
            CommercialGSRToolStripMenuItem.Visible = False
            DomesticGSRToolStripMenuItem.Visible = False
            WarningNoticeToolStripMenuItem.Visible = False
            QCResultsToolStripMenuItem.Visible = False
            ElectricalMinorWorksToolStripMenuItem.Visible = False
            AllGasPaperworkToolStripMenuItem.Visible = True
            CommercialCateringToolStripMenuItem.Visible = False
            SaffronUnventedWorkshhetToolStripMenuItem.Visible = False
            PropertyMaintenanceWorksheetToolStripMenuItem.Visible = False
            CommissioningChecklistToolStripMenuItem.Visible = False
            HotWorksPermitToolStripMenuItem.Visible = False

            For Each dr As DataRow In AdditionalDT.Rows
                Select Case CInt(dr("TestType"))
                    Case Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork, Enums.AdditionalChecksTypes.PostCompleteAuditDomWork,
                         Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork, Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork,
                         Enums.AdditionalChecksTypes.ElectricalAudit
                        QCResultsToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.CommercialStrengthTestCP16, Enums.AdditionalChecksTypes.CommercialPurgingTestCP16,
                         Enums.AdditionalChecksTypes.CommercialSiteChecksCP17, Enums.AdditionalChecksTypes.CommercialTightnessTestCP16
                        CommercialGSRToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet, Enums.AdditionalChecksTypes.SolarThermalReport
                        ASHPWorksheetToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist
                        PropertyMaintenanceWorksheetToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.SaffronUnventedReport
                        SaffronUnventedWorkshhetToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.CommercialCateringCP42
                        CommercialCateringToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert
                        ElectricalMinorWorksToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.CommissioningChecklist
                        CommissioningChecklistToolStripMenuItem.Visible = True
                    Case Enums.AdditionalChecksTypes.HotWorksPermit
                        HotWorksPermitToolStripMenuItem.Visible = True
                End Select
            Next

            If ApplianceWorkSheetDataview.Count > 0 Or VisitDefectDataview.Count > 0 Then
                DomesticGSRToolStripMenuItem.Visible = True
            End If

            Dim drWarningNotices As DataRow() = (From x In VisitDefectDataview.Table.AsEnumerable() Where Helper.MakeBooleanValid(x("WarningNoticeIssued")) = True Select x).ToArray()
            If drWarningNotices.Length > 0 Then WarningNoticeToolStripMenuItem.Visible = True

        End If

        If JobLock Is Nothing Then JobLock = DB.JobLock.JobLock(Job.JobID)
        If JobLock?.UserID <> loggedInUser.UserID Then
            Dim message As String = "The job is currently being viewed by: " & JobLock.NameOfUserWhoLocked
            MessageBox.Show(message, "READ ONLY - JOB LOCKED!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MakeReadOnly()
            Me.Text += " Job Locked by: " & JobLock.NameOfUserWhoLocked
        End If

    End Sub

    Private Sub TimesheetCalc()
        Dim allowance As Double = 0
        For Each itm As DataRow In JobItems.Table.Rows
            allowance += Helper.MakeDoubleValid(itm("NumAllocated")) * Helper.MakeDoubleValid(itm("TimeInMins"))
        Next

        Dim spent As Double = 0
        If Not EngineerVisit.TimeSheets Is Nothing Then
            If Not EngineerVisit.TimeSheets.Table Is Nothing Then
                For Each row As DataRow In EngineerVisit.TimeSheets.Table.Rows
                    spent += Helper.MakeDateTimeValid(row("EndDateTime")).Subtract(Helper.MakeDateTimeValid(row("StartDateTime"))).TotalMinutes
                Next
            End If
        End If

        Me.txtSORTimeAllowance.Text = allowance
        Me.txtActualTimeSpent.Text = spent
        Me.txtDifference.Text = allowance - spent
    End Sub

    Private Sub Profitable()
        If EngVisitCharge IsNot Nothing Then
            Dim totalCost As Double = 0
            totalCost += Helper.MakeDoubleValid(Me.txtEngineerCostTotal.Text)
            '   totalCost += Helper.MakeDoubleValid(Me.txtAdditionalChargeTotal.Text)
            totalCost += Helper.MakeDoubleValid(Me.txtPartProductCost.Text)

            txtSale.Text = (Me.txtJobValue.Text)
            txtCosts.Text = Format(totalCost, "C")
            txtProfit.Text = Format(CDbl(txtSale.Text) - CDbl(txtCosts.Text), "C")

            If txtSale.Text.Length > 0 Then
                txtProfitPerc.Text = Math.Round((CDbl(txtProfit.Text) / txtSale.Text) * 100, 2) & "%"
            Else
                txtProfitPerc.Text = "N/A"
            End If

            Dim totalCharge As Double = 0
            Select Case CType(EngVisitCharge.ChargeTypeID, Enums.JobChargingType)
                Case Enums.JobChargingType.JobValue
                    totalCharge = Helper.MakeDoubleValid(Me.txtJobValue.Text)
                Case Enums.JobChargingType.NoChargeCallout, Enums.JobChargingType.NoChargeContractInvoice, Enums.JobChargingType.NoChargeMisc
                    totalCharge = 0
                Case Enums.JobChargingType.PercentageOfQuote
                    totalCharge = Helper.MakeDoubleValid(lblQuotePercentageTotal.Text)
                Case Enums.JobChargingType.QuoteValue
                    totalCharge = Helper.MakeDoubleValid(Me.txtCharge.Text)
            End Select
        End If
    End Sub

    Private Function Save() As Boolean
        Try
            If _readOnly Then Return True
            Me.Cursor = Cursors.WaitCursor

            If loggedInUser.UserRegions.Count > 0 Then
                If loggedInUser.UserRegions.Table.Select("RegionID = " & theSite.RegionID).Length < 1 Then
                    Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                End If
            Else
                Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If

            Dim fuelId As Integer = 0
            If SiteFuelsDataView.Table.Select("tick = 1").Length > 0 Then fuelId = SiteFuelsDataView.Table.Select("tick = 1")(0)("ManagerID")
            If chkGasServiceCompleted.Checked AndAlso fuelId = CInt(Enums.FuelTypes.NA) Then
                ShowMessage("Please select correct fuel type." & vbCrLf & "Cannot find fuel, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            EngineerVisit.IgnoreExceptionsOnSetMethods = True
            EngineerVisit.SetEngineerID = Combo.GetSelectedItemValue(Me.cboEngineer)
            EngineerVisit.SetNotesFromEngineer = Me.txtNotesFromEngineer.Text.Trim
            EngineerVisit.SetOutcomeEnumID = Combo.GetSelectedItemValue(Me.cboOutcome)
            EngineerVisit.SetOutcomeDetails = Me.txtOutcomeDetails.Text.Trim
            EngineerVisit.SetCustomerName = Me.txtCustomer.Text.Trim
            EngineerVisit.SetVisitLocked = Me.cbxVisitLockDown.Checked
            EngineerVisit.SetAmountCollected = Me.txtAmountCollected.Text
            EngineerVisit.SetPaymentMethodID = Combo.GetSelectedItemValue(Me.cboPaymentMethod)
            EngineerVisit.SetPropertyRented = Combo.GetSelectedItemValue(Me.cboPropertyRented)
            EngineerVisit.SetBondingID = Combo.GetSelectedItemValue(Me.cboBonding)
            EngineerVisit.SetEmergencyControlAccessibleID = Combo.GetSelectedItemValue(Me.cboEmergencyControlAccessible)
            EngineerVisit.SetSignatureSelectedID = Combo.GetSelectedItemValue(Me.cboSignatureSelected)
            EngineerVisit.SetGasInstallationTightnessTestID = Combo.GetSelectedItemValue(Me.cboGasInstallationTightnessTest)
            EngineerVisit.SetGasServiceCompleted = Me.chkGasServiceCompleted.Checked
            EngineerVisit.SetFuelID = fuelId
            EngineerVisit.SetEmailReceipt = Me.cbxEmailReceiptToCustomer.Checked
            EngineerVisit.SetRecharge = Me.chkRecharge.Checked
            EngineerVisit.setRechargeTypeID = Combo.GetSelectedItemValue(Me.cboRecharge)
            EngineerVisit.setNccRadID = Combo.GetSelectedItemValue(Me.cboNccRad)
            EngineerVisit.SetMeterCappedID = Combo.GetSelectedItemValue(Me.cboMeterCapped)
            EngineerVisit.SetMeterLocationID = Combo.GetSelectedItemValue(Me.cboMeterLocation)
            EngineerVisit.SetUseSORDescription = Me.chkSORDesc.Checked

            If Not ScheduleOfRateCharges Is Nothing AndAlso (chkSORDesc.Checked And ScheduleOfRateCharges.Table.Select("tick <> 0").Length = 0 And cbxReadyToBeInvoiced.Checked) Then
                ShowMessage("You Can not use SOR Descriptions for Invoicing without selecting chargeable SORS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            If EngineerVisit.EngineerVisitNCCGSR Is Nothing Then
                EngineerVisit.EngineerVisitNCCGSR = New Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSR
            End If

            EngineerVisit.EngineerVisitNCCGSR.SetApproxAgeOfBoiler = txtApproxAgeOfBoiler.Text
            EngineerVisit.EngineerVisitNCCGSR.SetCertificateTypeID = Combo.GetSelectedItemValue(cboCertificateTypeID)
            EngineerVisit.EngineerVisitNCCGSR.SetCODetectorFittedID = Combo.GetSelectedItemValue(cboCODetectorFittedID)
            EngineerVisit.EngineerVisitNCCGSR.SetCorrectMaterialsUsedID = Combo.GetSelectedItemValue(cboCorrectMaterialsUsedID)
            EngineerVisit.EngineerVisitNCCGSR.SetCylinderTypeID = Combo.GetSelectedItemValue(cboCylinderTypeID)
            EngineerVisit.EngineerVisitNCCGSR.SetEngineerVisitID = EngineerVisit.EngineerVisitID
            EngineerVisit.EngineerVisitNCCGSR.SetHeatingSystemTypeID = Combo.GetSelectedItemValue(cboHeatingSystemTypeID)
            EngineerVisit.EngineerVisitNCCGSR.SetImmersionID = Combo.GetSelectedItemValue(cboImmersionID)
            EngineerVisit.EngineerVisitNCCGSR.SetInstallationPipeWorkCorrectID = Combo.GetSelectedItemValue(cboInstallationPipeWorkCorrectID)
            EngineerVisit.EngineerVisitNCCGSR.SetInstallationSafeToUseID = Combo.GetSelectedItemValue(cboInstallationSafeToUseID)
            EngineerVisit.EngineerVisitNCCGSR.SetJacketID = Combo.GetSelectedItemValue(cboJacketID)
            EngineerVisit.EngineerVisitNCCGSR.SetPartialHeatingID = Combo.GetSelectedItemValue(cboPartialHeatingID)
            EngineerVisit.EngineerVisitNCCGSR.SetRadiators = txtRadiators.Text
            EngineerVisit.EngineerVisitNCCGSR.SetStrainerFittedID = Combo.GetSelectedItemValue(cboStrainerFittedID)
            EngineerVisit.EngineerVisitNCCGSR.SetStrainerInspectedID = Combo.GetSelectedItemValue(cboStrainerInspectedID)
            EngineerVisit.EngineerVisitNCCGSR.SetVisualInspectionReason = txtVisualInspectionReason.Text
            EngineerVisit.EngineerVisitNCCGSR.SetVisualInspectionSatisfactoryID = Combo.GetSelectedItemValue(cboVisualInspectionSatisfactoryID)

            EngineerVisit.EngineerVisitNCCGSR.SetFillDiscID = Combo.GetSelectedItemValue(cboFillDisc)
            EngineerVisit.EngineerVisitNCCGSR.SetSITimerID = Combo.GetSelectedItemValue(cboSITimer)

            If EngineerVisit.EngineerVisitSMOKE Is Nothing Then
                EngineerVisit.EngineerVisitSMOKE = New Entity.EngineerVisitAdditionals.EngineerVisitAdditional
            End If
            If EngineerVisit.EngineerVisitCOMO Is Nothing Then
                EngineerVisit.EngineerVisitCOMO = New Entity.EngineerVisitAdditionals.EngineerVisitAdditional
            End If

            Dim jV As New Entity.EngineerVisits.EngineerVisitValidator
            jV.Validate(EngineerVisit, theSite.CustomerID)

            Select Case CInt(EngineerVisit.StatusEnumID)
                Case CInt(Enums.VisitStatus.Ready_For_Schedule),
                     CInt(Enums.VisitStatus.Scheduled)
                    If ShowMessage("Are you sure you wish to manually complete this visit? (The outcome can not be altered from this point)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Return False
                    End If
            End Select

            QC.SetApplianceRecorded = Combo.GetSelectedItemValue(cboQCAppliance)
            QC.SetCustomerSigned = Combo.GetSelectedItemValue(cboQCCustSig)
            QC.SetCustomerDetailsIncorrect = Combo.GetSelectedItemValue(cboQCCustomerDetails)
            QC.SetEngineerPaymentReceived = Combo.GetSelectedItemValue(cboQCEngineerPaymentRecieved)
            QC.SetJobTypeIncorrect = Combo.GetSelectedItemValue(cboQCJobType)
            QC.SetJobUploadInTimeScale = Combo.GetSelectedItemValue(cboQCJobUploadTimescale)
            QC.SetLabourTimeMissing = Combo.GetSelectedItemValue(cboQCLabourTime)
            QC.SetLGSRMissing = Combo.GetSelectedItemValue(cboQCLGSR)
            QC.SetOrderNumberAttached = Combo.GetSelectedItemValue(cboQCOrderNo)
            QC.SetPartsConfirmation = Combo.GetSelectedItemValue(cboQCParts)
            QC.SetPaymentCollection = Combo.GetSelectedItemValue(cboQCPaymentCollection)
            QC.SetPaymentMethodDetailed = Combo.GetSelectedItemValue(cboQCPaymentMethod)
            QC.SetPaymentMethodSelectionIncorrect = Combo.GetSelectedItemValue(cboQCPaymentSelection)
            QC.SetSorIncorrect = Combo.GetSelectedItemValue(cboQCScheduleOfRate)
            QC.SetFTFCode = Combo.GetSelectedItemValue(cboFTFCode)
            QC.SetRecall = Combo.GetSelectedItemValue(cboRecall)
            QC.SetEngineerID = Combo.GetSelectedItemValue(cboRecallEngineer)
            QC.SetPoorJobNotes = Me.txtQCPoorJobNotes.Text
            QC.SetDocumentsRecieved = chkQCDocumentsRecieved.Checked
            QC.DateDocumentsRecieved = IIf(chkQCDocumentsRecieved.Checked, dtpQCDocumentsRecieved.Value, Nothing)
            QC.SetEngineerVisitID = EngineerVisit.EngineerVisitID
            If QC.Exists Then
                DB.EngineerVisitQCSQL.Update(QC)
            Else
                DB.EngineerVisitQCSQL.Insert(QC)
            End If

            'GET JOW Priority
            Dim jow As Entity.JobOfWorks.JobOfWork = DB.JobOfWorks.JobOfWork_Get(EngineerVisit.JobOfWorkID)
            'GET picklist wording for priority
            Dim pk As Entity.PickLists.PickList = DB.Picklists.Get_One_As_Object(jow.Priority)
            'GET Recall Picklist ID
            Dim recallID As Integer = 0

            Dim dtPriorities As DataTable = DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table
            For Each drPriority As DataRow In dtPriorities.Rows
                If drPriority.Item("Name") = "RC - Recall" Then
                    recallID = drPriority.Item("ManagerID")
                    Exit For
                End If
            Next

            ' if the user selects Recall = Yes, and the JOW Priority does not = Recall, it will be set to Recall.
            If Combo.GetSelectedItemDescription(cboRecall) = "Yes" Then
                If pk Is Nothing Then
                    'Set to Recall
                    jow.SetPriority = recallID
                    jow.PriorityDateSet = Now
                    DB.JobOfWorks.Update_Priority(jow)
                ElseIf pk.Name <> "RC - Recall" Then
                    'Set to Recall
                    jow.SetPriority = recallID
                    jow.PriorityDateSet = Now
                    DB.JobOfWorks.Update_Priority(jow)
                End If
            End If

            ' if the user selects Recall = No, and the JOW Priority = Recall, the user will be asked what they would like to change this to.
            If Combo.GetSelectedItemDescription(cboRecall) = "No" Then
                If Not pk Is Nothing Then
                    If pk.Name = "RC - Recall" Then
                        'Select a Job Priority to set it too
                        Dim f As New FRMChangePriority
                        f.ShowDialog()
                        jow.SetPriority = Combo.GetSelectedItemValue(f.cboJobType)
                        jow.PriorityDateSet = Now
                        DB.JobOfWorks.Update_Priority(jow)
                    End If
                End If
            End If

            EngineerVisit = DB.EngineerVisits.ManuallyComplete(EngineerVisit, JobItems, PartsAndProductsDistribution)
            Updating = True
            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Error saving details : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Function

#End Region

#Region " Visit Charging "

#Region "Charge Properties"

    Private _AdditionalCharges As DataView

    Private Property AdditionalCharges() As DataView
        Get
            Return _AdditionalCharges
        End Get
        Set(ByVal value As DataView)
            _AdditionalCharges = value
            _AdditionalCharges.AllowNew = False
            _AdditionalCharges.AllowEdit = False
            _AdditionalCharges.AllowDelete = False
            _AdditionalCharges.Table.TableName = Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString
            Me.dgAdditionalCharges.DataSource = AdditionalCharges
        End Set
    End Property

    Private ReadOnly Property SelectedAdditionalChargesDataRow() As DataRow
        Get
            If Not Me.dgAdditionalCharges.CurrentRowIndex = -1 Then
                Return AdditionalCharges(Me.dgAdditionalCharges.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _ScheduleOfRateCharges As DataView

    Private Property ScheduleOfRateCharges() As DataView
        Get
            Return _ScheduleOfRateCharges
        End Get
        Set(ByVal value As DataView)
            _ScheduleOfRateCharges = value
            _ScheduleOfRateCharges.AllowNew = False
            _ScheduleOfRateCharges.AllowEdit = True
            _ScheduleOfRateCharges.AllowDelete = False
            _ScheduleOfRateCharges.Table.TableName = Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString
            Me.dgScheduleOfRateCharges.DataSource = ScheduleOfRateCharges
        End Set
    End Property

    Private ReadOnly Property SelectedScheduleOfRateChargesDataRow() As DataRow
        Get
            If Not Me.dgScheduleOfRateCharges.CurrentRowIndex = -1 Then
                Return ScheduleOfRateCharges(Me.dgScheduleOfRateCharges.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _engVisitCharge As Entity.EngineerVisitCharges.EngineerVisitCharge

    Private Property EngVisitCharge() As Entity.EngineerVisitCharges.EngineerVisitCharge
        Get
            Return _engVisitCharge
        End Get
        Set(ByVal Value As Entity.EngineerVisitCharges.EngineerVisitCharge)
            _engVisitCharge = Value

            If EngVisitCharge Is Nothing Then
                Me.btnInvoice.Visible = False
            Else
                If EngVisitCharge.InvoiceReadyID = CInt(Enums.InvoiceReady.Ready) Then
                    Me.btnInvoice.Visible = True
                Else
                    Me.btnInvoice.Visible = False
                End If
            End If
        End Set
    End Property

    Private _PartProductsCharges As DataView

    Private Property PartProductsCharges() As DataView
        Get
            Return _PartProductsCharges
        End Get
        Set(ByVal value As DataView)
            _PartProductsCharges = value
            _PartProductsCharges.AllowNew = False
            _PartProductsCharges.AllowEdit = False
            _PartProductsCharges.AllowDelete = False
            _PartProductsCharges.Table.TableName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString
            Me.dgPartsProductCharging.DataSource = PartProductsCharges
        End Set
    End Property

    Private ReadOnly Property SelectedPartProductsChargesDataRow() As DataRow
        Get
            If Not Me.dgPartsProductCharging.CurrentRowIndex = -1 Then
                Return PartProductsCharges(Me.dgPartsProductCharging.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _Job As Entity.Jobs.Job

    Private Property Job() As Entity.Jobs.Job
        Get
            Return _Job
        End Get
        Set(ByVal Value As Entity.Jobs.Job)
            _Job = Value
        End Set
    End Property

    Private _readOnly As Boolean = False

    Private Sub MakeReadOnly()
        Me.tpMainDetails.Enabled = False
        Me.tpAppliances.Enabled = False
        Me.grpVisitWorksheet.Enabled = False
        Me.grpVisitWorksheetExtended.Enabled = False
        Me.grpAlarmInfo.Enabled = False
        Me.grpVisitDefects.Enabled = False
        Me.grpApplianceWorksheet.Enabled = False
        Me.grpAdditionalWorksheet.Enabled = False
        Me.tpTimesheets.Enabled = False
        Me.grpTimesheets.Enabled = False
        Me.tpPartsAndProducts.Enabled = False
        Me.tpOutcomes.Enabled = False
        Me.tpQC.Enabled = False
        Me.tpCharges.Enabled = False
        Me.btnSave.Enabled = False
        Me.cbxVisitLockDown.Enabled = False
        _readOnly = True
    End Sub

    Private _TimeSheetCharges As DataView

    Private Property TimeSheetCharges() As DataView
        Get
            Return _TimeSheetCharges
        End Get
        Set(ByVal value As DataView)
            _TimeSheetCharges = value
            _TimeSheetCharges.AllowNew = False
            _TimeSheetCharges.AllowEdit = True
            _TimeSheetCharges.AllowDelete = False
            _TimeSheetCharges.Table.TableName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString
            Me.dgTimesheetCharges.DataSource = TimeSheetCharges
        End Set
    End Property

    Private ReadOnly Property SelectedTimeSheetChargesDataRow() As DataRow
        Get
            If Not Me.dgTimesheetCharges.CurrentRowIndex = -1 Then
                Return TimeSheetCharges(Me.dgTimesheetCharges.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _invoiceToBeRaised As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised = Nothing

    Public Property InvoiceToBeRaised() As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
        Get
            Return _invoiceToBeRaised
        End Get
        Set(ByVal Value As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised)
            _invoiceToBeRaised = Value
        End Set
    End Property

#End Region

#Region "Charge Setup"

    Public Sub SetupAdditionalChargeDataGrid()

        Helper.SetUpDataGrid(Me.dgAdditionalCharges)
        Dim tStyle As DataGridTableStyle = Me.dgAdditionalCharges.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "ChargeDescription"
        Description.ReadOnly = True
        Description.Width = 320
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim Charge As New DataGridLabelColumn
        Charge.Format = "C"
        Charge.FormatInfo = Nothing
        Charge.HeaderText = "Charge"
        Charge.MappingName = "Charge"
        Charge.ReadOnly = True
        Charge.Width = 100
        Charge.NullText = ""
        tStyle.GridColumnStyles.Add(Charge)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString
        Me.dgAdditionalCharges.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupSoRChargeDataGrid()

        Helper.SetUpDataGrid(Me.dgScheduleOfRateCharges)
        Dim tStyle As DataGridTableStyle = Me.dgScheduleOfRateCharges.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgScheduleOfRateCharges.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 65
        Code.NullText = ""
        tStyle.GridColumnStyles.Add(Code)

        Dim category As New DataGridLabelColumn
        category.Format = ""
        category.FormatInfo = Nothing
        category.HeaderText = "Category"
        category.MappingName = "category"
        category.ReadOnly = True
        category.Width = 75
        category.NullText = ""
        tStyle.GridColumnStyles.Add(category)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Summary"
        Description.ReadOnly = True
        Description.Width = 85
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim NumUnitsUsed As New DataGridLabelColumn
        NumUnitsUsed.Format = ""
        NumUnitsUsed.FormatInfo = Nothing
        NumUnitsUsed.HeaderText = "# Used"
        NumUnitsUsed.MappingName = "NumUnitsUsed"
        NumUnitsUsed.ReadOnly = True
        NumUnitsUsed.Width = 52
        NumUnitsUsed.NullText = "0"
        tStyle.GridColumnStyles.Add(NumUnitsUsed)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 60
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim Charge As New DataGridLabelColumn
        Charge.Format = "C"
        Charge.FormatInfo = Nothing
        Charge.HeaderText = "Charge"
        Charge.MappingName = "Total"
        Charge.ReadOnly = True
        Charge.Width = 65
        Charge.NullText = "ï¿½0.00"
        tStyle.GridColumnStyles.Add(Charge)

        tStyle.MappingName = Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString
        Me.dgScheduleOfRateCharges.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPartProductDataGrid()

        Helper.SetUpDataGrid(Me.dgPartsProductCharging)
        Dim tStyle As DataGridTableStyle = Me.dgPartsProductCharging.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgScheduleOfRateCharges.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 40
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim PartProduct As New DataGridLabelColumn
        PartProduct.Format = ""
        PartProduct.FormatInfo = Nothing
        PartProduct.HeaderText = "Part/Product"
        PartProduct.MappingName = "Part/Product"
        PartProduct.ReadOnly = True
        PartProduct.Width = 75
        PartProduct.NullText = ""
        tStyle.GridColumnStyles.Add(PartProduct)

        Dim Asset As New DataGridLabelColumn
        Asset.Format = ""
        Asset.FormatInfo = Nothing
        Asset.HeaderText = "Appliance (part applied to)"
        Asset.MappingName = "Asset"
        Asset.ReadOnly = True
        Asset.Width = 60
        Asset.NullText = ""
        tStyle.GridColumnStyles.Add(Asset)

        Dim Warranty As New DataGridLabelColumn
        Warranty.Format = ""
        Warranty.FormatInfo = Nothing
        Warranty.HeaderText = "Warranty? (Appliance on)"
        Warranty.MappingName = "Warranty"
        Warranty.ReadOnly = True
        Warranty.Width = 55
        Warranty.NullText = ""
        tStyle.GridColumnStyles.Add(Warranty)

        Dim Cost As New DataGridLabelColumn
        Cost.Format = "C"
        Cost.FormatInfo = Nothing
        Cost.HeaderText = "Cost"
        Cost.MappingName = "Rate"
        Cost.ReadOnly = True
        Cost.Width = 45
        Cost.NullText = ""
        tStyle.GridColumnStyles.Add(Cost)

        Dim Quantity As New DataGridLabelColumn
        Quantity.Format = ""
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Qty"
        Quantity.MappingName = "Quantity"
        Quantity.ReadOnly = True
        Quantity.Width = 40
        Quantity.NullText = ""
        tStyle.GridColumnStyles.Add(Quantity)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 45
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim Charge As New DataGridLabelColumn
        Charge.Format = "C"
        Charge.FormatInfo = Nothing
        Charge.HeaderText = "Charge"
        Charge.MappingName = "Total"
        Charge.ReadOnly = True
        Charge.Width = 65
        Charge.NullText = "ï¿½0.00"
        tStyle.GridColumnStyles.Add(Charge)

        tStyle.MappingName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString
        Me.dgPartsProductCharging.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupTimeSheetChargeDataGrid()

        Helper.SetUpDataGrid(Me.dgTimesheetCharges)
        Dim tStyle As DataGridTableStyle = Me.dgTimesheetCharges.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgTimesheetCharges.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yy HH:mm"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Start "
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 95
        StartDateTime.NullText = ""
        tStyle.GridColumnStyles.Add(StartDateTime)

        Dim EndDateTime As New DataGridLabelColumn
        EndDateTime.Format = "dd/MM/yy HH:mm"
        EndDateTime.FormatInfo = Nothing
        EndDateTime.HeaderText = "End"
        EndDateTime.MappingName = "EndDateTime"
        EndDateTime.ReadOnly = True
        EndDateTime.Width = 95
        EndDateTime.NullText = ""
        tStyle.GridColumnStyles.Add(EndDateTime)

        Dim EngineerCost As New DataGridLabelColumn
        EngineerCost.Format = "C"
        EngineerCost.FormatInfo = Nothing
        EngineerCost.HeaderText = "Eng. Cost"
        EngineerCost.MappingName = "EngineerCost"
        EngineerCost.ReadOnly = True
        EngineerCost.Width = 80
        EngineerCost.NullText = ""
        tStyle.GridColumnStyles.Add(EngineerCost)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 60
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim TimesheetID As New DataGridLabelColumn
        TimesheetID.Format = ""
        TimesheetID.FormatInfo = Nothing
        TimesheetID.HeaderText = "TimesheetID"
        TimesheetID.MappingName = "TimesheetID"
        TimesheetID.ReadOnly = True
        TimesheetID.Width = 5
        TimesheetID.NullText = ""
        tStyle.GridColumnStyles.Add(TimesheetID)

        tStyle.MappingName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString
        Me.dgTimesheetCharges.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Charge Events"

    Private Sub btnAddAdditionalCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAdditionalCharge.Click
        Dim errMsg As String = ""

        If Not (Me.txtAdditionalChargeDescription.Text.Trim.Length > 0) Then
            errMsg += "* Charge Description Required" & vbCrLf
        End If

        If Not (Me.txtAdditionalCharge.Text.Trim.Length > 0) Then
            errMsg += "* Charge Required" & vbCrLf
        ElseIf Not IsNumeric(Me.txtAdditionalCharge.Text) Then
            errMsg += "* Charge Must Be Numeric" & vbCrLf
        End If

        If errMsg.Length > 0 Then
            errMsg = "Please correct the following errors:" & vbCrLf & errMsg
            MessageBox.Show(errMsg, "Additional Charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Insert(EngineerVisit.EngineerVisitID,
                                                                    Me.txtAdditionalChargeDescription.Text,
                                                                    Me.txtAdditionalCharge.Text)
            Me.txtAdditionalCharge.Text = ""
            Me.txtAdditionalChargeDescription.Text = ""
            PopulateAdditionalCharges()
        End If

    End Sub

    Private Sub btnRemoveAdditionalCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAdditionalCharge.Click
        If Not (SelectedAdditionalChargesDataRow Is Nothing) Then
            DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete(SelectedAdditionalChargesDataRow("EngineerVisitAdditionalChargeID"))
            PopulateAdditionalCharges()
        End If
    End Sub

    Private Sub dgScheduleOfRateCharges_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgScheduleOfRateCharges.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgScheduleOfRateCharges.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgScheduleOfRateCharges.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedScheduleOfRateChargesDataRow Is Nothing Then
                Exit Sub
            End If

            DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete(SelectedScheduleOfRateChargesDataRow("EngineerVisitScheduleOfRateChargesID"))

            If SelectedScheduleOfRateChargesDataRow("tick") = 0 Then
                DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, SelectedScheduleOfRateChargesDataRow("jobitemID"), SelectedScheduleOfRateChargesDataRow("Price"), 1)
            Else
                DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, SelectedScheduleOfRateChargesDataRow("jobitemID"), SelectedScheduleOfRateChargesDataRow("Price"), 0)
            End If

            PopulateScheduleOfRateCharges()
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNominalCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominalCode.TextChanged
        SaveVisitCharge()
    End Sub

    Private Sub cboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        SaveVisitCharge()
    End Sub

    Private Sub txtAccountCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountCode.TextChanged
        If txtAccountCode.Text.Trim.Length = 0 Then
            ShowMessage("Account code cannot be blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtAccountCode.Text = EngVisitCharge.ForSageAccountCode
            Exit Sub
        End If
        SaveVisitCharge()
    End Sub

    Private Sub dgPartsProductCharging_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgPartsProductCharging.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgPartsProductCharging.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgPartsProductCharging.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedPartProductsChargesDataRow Is Nothing Then
                Exit Sub
            End If

            Dim price As Double = SelectedPartProductsChargesDataRow("Rate") * (1 + (Helper.MakeIntegerValid(txtPartsMarkUp.Text) / 100))
            If SelectedPartProductsChargesDataRow("Type") = "Part" Then
                Try   ' loosing the plot
                    DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(SelectedPartProductsChargesDataRow("ChargeID"))
                Catch ex As Exception
                End Try
                If SelectedPartProductsChargesDataRow("tick") = 0 Then
                    DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, SelectedPartProductsChargesDataRow("UniqueID"), price, 1, SelectedPartProductsChargesDataRow("Rate"), SelectedPartProductsChargesDataRow("PartUsedID"))
                Else
                    DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, SelectedPartProductsChargesDataRow("UniqueID"), price, 0, SelectedPartProductsChargesDataRow("Rate"), SelectedPartProductsChargesDataRow("PartUsedID"))
                End If
            Else
                DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Helper.MakeIntegerValid(SelectedPartProductsChargesDataRow("ChargeID")))

                If SelectedPartProductsChargesDataRow("tick") = 0 Then
                    DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, SelectedPartProductsChargesDataRow("UniqueID"), price, 1, SelectedPartProductsChargesDataRow("Rate"))
                Else
                    DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, SelectedPartProductsChargesDataRow("UniqueID"), price, 0, SelectedPartProductsChargesDataRow("Rate"))
                End If

            End If

            PopulatePartsProductsCharges(False, True)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rdoJobValue_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoJobValue.CheckedChanged
        'The Job Value
        If Me.rdoJobValue.Checked = True Then
            'Will always produce an invoice
            gpbInvoice.Enabled = True
            ShowEditableVisitCharges()
            cbxReadyToBeInvoiced.Enabled = True
            'Check we have the VisitCharges
            If Not EngVisitCharge Is Nothing Then
                'Make sure we're not overwriting status alreay set - shouldn't be possible
                If CType(EngVisitCharge.InvoiceReadyID, Enums.InvoiceReady) = Enums.InvoiceReady.Ready Then
                    cbxReadyToBeInvoiced.Checked = True
                Else
                    cbxReadyToBeInvoiced.Checked = False
                End If
            End If
            txtPercentOfQuote.ReadOnly = True
        End If
        SaveVisitCharge()
    End Sub

    Private Sub rdoChargeOther_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoChargeOther.CheckedChanged
        'Other Charges
        If Me.rdoChargeOther.Checked = True Then
            'Check we've got the job
            If Not Job Is Nothing Then
                'If it a quote we invoice
                If CType(Job.JobDefinitionEnumID, Enums.JobDefinition) = Enums.JobDefinition.Quoted Then
                    gpbInvoice.Enabled = True
                    ShowEditableVisitCharges()
                    'Check we have the VisitCharges
                    If Not EngVisitCharge Is Nothing Then
                        'Make sure we're not overwriting status alreay set - shouldn't be possible
                        If CType(EngVisitCharge.InvoiceReadyID, Enums.InvoiceReady) = Enums.InvoiceReady.Ready Then
                            cbxReadyToBeInvoiced.Checked = True
                        Else
                            cbxReadyToBeInvoiced.Checked = False
                        End If
                    End If
                Else 'Anthing else won't invoice
                    gpbInvoice.Enabled = False
                    cbxReadyToBeInvoiced.Checked = False
                    txtPartsMarkUp.Visible = False
                    lblPartsMarkUp.Visible = False
                    txtPartsMarkUp.Enabled = False
                    txtPartsProductTotal.ReadOnly = True
                    txtTimesheetTotal.ReadOnly = True
                End If
            End If
            txtPercentOfQuote.ReadOnly = True
        End If
        SaveVisitCharge()
    End Sub

    Private Sub rdoPercentageOfQuoteValue_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoPercentageOfQuoteValue.CheckedChanged
        'The Percentage of the quote
        If Me.rdoPercentageOfQuoteValue.Checked = True Then
            'Will always produce an invoice
            gpbInvoice.Enabled = True
            ShowEditableVisitCharges()
            'Check we have the VisitCharges
            If Not EngVisitCharge Is Nothing Then
                'Make sure we're not overwriting status alreay set - shouldn't be possible
                If CType(EngVisitCharge.InvoiceReadyID, Enums.InvoiceReady) = Enums.InvoiceReady.Ready Then
                    cbxReadyToBeInvoiced.Checked = True
                Else
                    cbxReadyToBeInvoiced.Checked = False
                End If
            End If
            txtPercentOfQuote.ReadOnly = False
        End If
        SaveVisitCharge()
    End Sub

    Private Sub txtPercentOfQuote_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPercentOfQuote.TextChanged
        Dim percentage As Double = 0.0
        Dim percentTotal As Double = 0.0

        If Not (txtPercentOfQuote.Text.Trim.Length = 0) Then
            If IsNumeric(txtPercentOfQuote.Text) Then
                percentage = txtPercentOfQuote.Text
                percentTotal = (Helper.MakeDoubleValid(txtCharge.Text) / 100) * percentage
                Me.lblQuotePercentageTotal.Text = Format(percentTotal, "C")
                SaveVisitCharge()
            Else
                Me.lblQuotePercentageTotal.Text = "ERROR"
            End If
        Else
            Me.lblQuotePercentageTotal.Text = "ERROR"
        End If

    End Sub

    Private Sub dgTimesheetCharges_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgTimesheetCharges.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgTimesheetCharges.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgTimesheetCharges.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedTimeSheetChargesDataRow Is Nothing Then
                Exit Sub
            End If

            If SelectedTimeSheetChargesDataRow("tick") = 0 Then
                If SelectedTimeSheetChargesDataRow("EngineerVisitTimesheetChargeID") = 0 Then
                    InsertEngineerTimnesheetCharge(SelectedTimeSheetChargesDataRow("StartDateTime"), SelectedTimeSheetChargesDataRow("EndDateTime"),
                                                    SelectedTimeSheetChargesDataRow("TimesheetID"), SelectedTimeSheetChargesDataRow("TimeSheetTypeID"),
                                                    SelectedTimeSheetChargesDataRow("EngineerCost"), 1, SelectedTimeSheetChargesDataRow("EngineerVisitID"))
                Else
                    DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(SelectedTimeSheetChargesDataRow("EngineerVisitTimesheetChargeID"), 1)
                End If
            Else
                DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(SelectedTimeSheetChargesDataRow("EngineerVisitTimesheetChargeID"), 0)
            End If
            PopulateTimeSheetCharges(False, True)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbxReadyToBeInvoiced_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxReadyToBeInvoiced.CheckedChanged
        If EngVisitCharge Is Nothing Then
            Exit Sub
        End If

        'If its checked then lock down the charging boxes
        If cbxReadyToBeInvoiced.Checked Then
            Dim chargeableAmount As Double = 0.0
            If Job.JobDefinitionEnumID = Enums.JobDefinition.Quoted Then
                Select Case CType(EngVisitCharge.ChargeTypeID, Enums.JobChargingType)
                    Case Enums.JobChargingType.JobValue
                        chargeableAmount = EngVisitCharge.JobValue
                    Case Enums.JobChargingType.PercentageOfQuote
                        chargeableAmount = EngVisitCharge.Charge
                    Case Enums.JobChargingType.QuoteValue
                        chargeableAmount = Helper.MakeDoubleValid(txtCharge.Text)
                End Select
            Else
                chargeableAmount = EngVisitCharge.JobValue
            End If

            If chargeableAmount > 0 Then
                SetPriceIncVAT()
                gpbScheduleOfRates.Enabled = False
                gpbPartsAndProducts.Enabled = False
                gpbTimesheets.Enabled = False
                gpbAdditionalCharges.Enabled = False
                'gpbMileage.Enabled = False
                gpbCharges.Enabled = False
                cbxVisitLockDown.Enabled = False
                btnSave.Enabled = False
            Else
                ShowMessage("Charge Amount must be greater than zero", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cbxReadyToBeInvoiced.Checked = False
            End If
        Else
            gpbScheduleOfRates.Enabled = True
            gpbPartsAndProducts.Enabled = True
            gpbTimesheets.Enabled = True
            gpbAdditionalCharges.Enabled = True
            'gpbMileage.Enabled = True
            gpbCharges.Enabled = True
            cbxVisitLockDown.Enabled = True
            btnSave.Enabled = True
        End If
        SaveVisitCharge()
        LoadReadyToBeInvoicedDetails()
    End Sub

    Private Sub SetPriceIncVAT()
        If Not EngVisitCharge Is Nothing Then

            Dim vatRate As Entity.VATRatess.VATRates
            If Combo.GetSelectedItemValue(cboVATRate) < 1 Then

                vatRate = DB.VATRatesSQL.VATRates_Get(DB.VATRatesSQL.VATRates_Get_ByDate(dtpRaiseInvoiceOn.Value))
            Else
                vatRate = DB.VATRatesSQL.VATRates_Get(Combo.GetSelectedItemValue(cboVATRate))
            End If

            If Not vatRate Is Nothing Then
                Me.txtPriceIncVAT.Text = Format(EngVisitCharge.JobValue * (1 + (vatRate.VATRate / 100)), "C")
            End If

        End If
    End Sub

    Private Sub dtpRaiseInvoiceOn_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpRaiseInvoiceOn.ValueChanged
        If InvoiceToBeRaised Is Nothing Then
            Exit Sub
        End If
        SetPriceIncVAT()
        SaveInvoiceToBeRaisedDetails()
    End Sub

    Private Sub btnAddSoR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSoR.Click
        Dim SoR As New DataTable
        SoR.Columns.Add("ScheduleOfRatesCategoryID")
        SoR.Columns.Add("Category")
        SoR.Columns.Add("Code")
        SoR.Columns.Add("Description")
        SoR.Columns.Add("Price")
        SoR.Columns.Add("Quantity")
        SoR.Columns.Add("Total")
        SoR.Columns.Add("RateID")
        SoR.Columns.Add("TimeInMins")
        SoR.Columns.Add("SystemLinkID")

        Using f As New FRMSiteScheduleOfRateList(theSite.SiteID, New DataView(SoR), True, False)
            f.ShowDialog()
        End Using

        For Each newSoR As DataRow In SoR.Rows
            Dim newJbItm As New Entity.JobItems.JobItem

            newJbItm.SetJobOfWorkID = EngineerVisit.JobOfWorkID
            newJbItm.SetQty = newSoR("Quantity")
            newJbItm.SetRateID = newSoR("RateID")
            newJbItm.SetSummary = newSoR("Description")
            newJbItm.SetSystemLinkID = newSoR("SystemLinkID")

            'SAVE TO JOB
            newJbItm = DB.JobItems.Insert(newJbItm)

            'SAVE VISIT UNITS USED
            DB.EngineerVisits.EngineerVisitUnitsUsed_Insert(EngineerVisit.EngineerVisitID, newJbItm.JobItemID, newJbItm.Qty)

            'SAVE TO ENGINEER VISIT SCHEDULE RATES CHARGES
            DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, newJbItm.JobItemID, Helper.MakeDoubleValid(newSoR("Price")), 1)

        Next
        JobItems = DB.EngineerVisits.EngineerVisitUnitsUsed_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID)
        dgJobItems.DataSource = JobItems

        PopulateScheduleOfRateCharges()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If InvoiceToBeRaised Is Nothing Then
            Exit Sub
        End If

        Dim frm As New FRMSelectInvoiceAddress(theSite.SiteID)
        If Not frm.ShowDialog = DialogResult.OK Then
            frm.Dispose()
            Exit Sub
        End If

        InvoiceToBeRaised.SetAddressLinkID = frm.AddressLinkID
        InvoiceToBeRaised.SetAddressTypeID = frm.AddressTypeID

        frm.Dispose()

        SaveInvoiceToBeRaisedDetails()

    End Sub

    Private Sub ShowEditableVisitCharges()
        If loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.VisitCharge) Then
            txtPartsMarkUp.Visible = True
            lblPartsMarkUp.Visible = True
            txtPartsMarkUp.Enabled = True
            txtPartsProductTotal.ReadOnly = False
            txtTimesheetTotal.ReadOnly = False
        End If
    End Sub

#End Region

#Region "Charge Functions"

    Private Sub InsertCharges(ByVal jbQuote As Entity.QuoteJobs.QuoteJob)

        EngVisitCharge = New Entity.EngineerVisitCharges.EngineerVisitCharge

        'MileageRate
        Select Case CType(Job.JobDefinitionEnumID, Enums.JobDefinition)
            Case Enums.JobDefinition.Quoted

                If jbQuote Is Nothing Then
                    EngVisitCharge.SetLabourRate = DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID)
                    EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.JobValue)
                    EngVisitCharge.SetCharge = 0
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Not_Ready)
                Else
                    EngVisitCharge.SetLabourRate = Helper.MakeDoubleValid(jbQuote.MileageRate)
                    EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.QuoteValue)
                    EngVisitCharge.SetCharge = 0
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Not_Ready)
                End If

            Case Enums.JobDefinition.Contract
                'NEED TO SEE IF WE ARE INVOICING PER VISIT OR NOT?
                Dim invoiceFreqID As Integer = DB.EngineerVisitCharge.EngineerVisitCharge_GetContractInvoiceFrequency(EngineerVisit.EngineerVisitID)
                EngVisitCharge.SetLabourRate = DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_ContractJob(Job.JobID)

                If CType(invoiceFreqID, Enums.InvoiceFrequency) = Enums.InvoiceFrequency.Per_Visit Then
                    'IF IS THEN LETS CHARGE FOR THE VISIT
                    EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.JobValue)
                    EngVisitCharge.SetCharge = 0
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Not_Ready)
                    lblContractPerVisit.Visible = True
                Else
                    EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.NoChargeContractInvoice)
                    EngVisitCharge.SetCharge = 0
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Never)
                    lblContractPerVisit.Visible = False
                End If

            Case Enums.JobDefinition.Misc
                EngVisitCharge.SetLabourRate = DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID)
                EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.NoChargeMisc)
                EngVisitCharge.SetCharge = 0
                EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Never)

            Case Enums.JobDefinition.Callout
                EngVisitCharge.SetLabourRate = DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID)
                EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.JobValue)
                EngVisitCharge.SetCharge = 0
                EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Not_Ready)

        End Select

        CustomerCharge = DB.CustomerCharge.CustomerCharge_GetForCustomer(theSite.CustomerID)

        Dim CustomerNominal As String = ""
        CustomerNominal = DB.Customer.Customer_Get_ForSiteID(theSite.SiteID).Nominal
        EngVisitCharge.SetNominalCode = CustomerNominal

        Dim visitEngineer As Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)

        Dim cc As Integer = GetCostCentre()
        EngVisitCharge.SetDepartment = If(cc <> -1, cc.ToString(), visitEngineer?.Department)
        EngVisitCharge.SetForSageAccountCode = ""
        EngVisitCharge.SetMainContractorDiscount = DB.EngineerVisitCharge.EngineerVisit_Get_CustomerContractorDiscount(EngineerVisit.EngineerVisitID)
        EngVisitCharge.SetEngineerVisitID = EngineerVisit.EngineerVisitID
        EngVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Insert(EngVisitCharge)

        'Schedule OF Rates
        Dim scheduleOfRatesTotal As Double = 0.0
        For Each jobItemDR As DataRow In JobItems.Table.Rows
            DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, jobItemDR("JobItemID"), Helper.MakeDoubleValid(jobItemDR("Price")), 1)
            scheduleOfRatesTotal += Helper.MakeDoubleValid(jobItemDR("Price"))
        Next jobItemDR

        'Part&Products

        Me.txtPartsMarkUp.Text = CustomerCharge.PartsMarkup
        For Each row As DataRow In EngineerVisit.PartsAndProductsUsed.Table.Rows
            If row.Item("Type") = "Part" Then
                DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, row.Item("ID"), row.Item("SellPrice"), 1, GetPartProductCost(row), row("UniqueID"))
            Else
                DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, row.Item("ID"), row.Item("SellPrice"), 1, GetPartProductCost(row))
            End If
        Next row

        Dim tick As Boolean = True
        If scheduleOfRatesTotal > 0 Then
            tick = False ' Don't want both timesheets and schedule of rates - charging twice
        End If

        'GET correct labour rates for a site
        Dim normalRate As Double = 0.0
        Dim timeNHalfRate As Double = 0.0
        Dim doubleRate As Double = 0.0
        Dim engineerCostNormal As Double = 0.0
        Dim engineerCostTimeHalf As Double = 0.0
        Dim engineerCostDouble As Double = 0.0

        If visitEngineer IsNot Nothing Then
            engineerCostNormal = visitEngineer.CostToCompanyNormal
            engineerCostTimeHalf = visitEngineer.CostToCompanyTimeAndHalf
            engineerCostDouble = visitEngineer.CostToCompanyDouble

            InsertVisitEngineer(visitEngineer)
        End If
        If CustomerCharge IsNot Nothing Then
            Dim TradeLabourRate As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate
            Dim custSorTable As DataTable = DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Get(theSite.CustomerID, Job.JobTypeID).Table
            If custSorTable.Rows.Count > 0 Then
                Dim id As Integer = custSorTable.Rows(0)("CustomerScheduleOfRateID")
                TradeLabourRate = DB.CustomerScheduleOfRate.Get(id)  ' Using a trade rate for a linked type of work
                normalRate = TradeLabourRate.Price
                timeNHalfRate = TradeLabourRate.Price
                doubleRate = TradeLabourRate.Price
            End If

            For Each timeSheet As DataRow In EngineerVisit.TimeSheets.Table.Rows
                InsertEngineerTimnesheetCharge(timeSheet("StartDateTime"), timeSheet("EndDateTime"), timeSheet("EngineerVisitTimeSheetID"), timeSheet("TimeSheetTypeID"), 0, tick, EngineerVisit.EngineerVisitID)
            Next
        End If

    End Sub

    Private Sub InsertVisitEngineer(ByVal engineer As Engineer)
        Dim evEngineer As EngineerVisitEngineer = New EngineerVisitEngineer() With {
            .EngineerVisitId = EngineerVisit.EngineerVisitID,
            .EngineerId = engineer.EngineerID,
            .Department = Helper.MakeIntegerValid(engineer.Department),
            .OftecNo = engineer.OftecNo,
            .GasSafeNo = engineer.GasSafeNo,
            .ManagerId = engineer.ManagerUserID,
            .CostToCompany = engineer.CostToCompanyNormal
        }

        evEngineer = DB.EvEngineer.Insert(evEngineer)
    End Sub

    Private Sub InsertEngineerTimnesheetCharge(ByVal StartDateTime As DateTime, ByVal EndDateTime As DateTime, ByVal TimesheetID As Integer, ByVal TimesheettypeID As Integer, ByVal EngCost As Double, ByVal Tick As Boolean, ByVal EngineerVisitID As Integer)

        Dim normalRate As Double = 0.0
        Dim timeNHalfRate As Double = 0.0
        Dim doubleRate As Double = 0.0
        Dim engineerCostNormal As Double = 0.0
        Dim engineerCostTimeHalf As Double = 0.0
        Dim engineerCostDouble As Double = 0.0
        Dim eng As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)

        If Not eng Is Nothing Then
            engineerCostNormal = eng.CostToCompanyNormal
            engineerCostTimeHalf = eng.CostToCompanyTimeAndHalf
            engineerCostDouble = eng.CostToCompanyDouble
        End If

        Dim TradeLabourRate As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate
        Dim custSorTable As DataTable = DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Get(theSite.CustomerID, Job.JobTypeID).Table
        If custSorTable.Rows.Count > 0 Then
            Dim id As Integer = custSorTable.Rows(0)("CustomerScheduleOfRateID")
            TradeLabourRate = DB.CustomerScheduleOfRate.Get(id)  ' Using a trade rate for a linked type of work
            normalRate = TradeLabourRate.Price
            timeNHalfRate = TradeLabourRate.Price
            doubleRate = TradeLabourRate.Price
        End If

        Dim totalPrice As Double = 0.0
        Dim summaryStr As String = ""
        Dim bankHolidayRate As Integer = False
        Dim engineerCostTotal As Double = 0.0

        ' see if bank holiday first
        bankHolidayRate = DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_BankHoliday(StartDateTime)

        If bankHolidayRate = 0 Then
            Dim timeSheetRates As New DataView
            timeSheetRates = DB.EngineerVisitCharge.EngineerVisitTimesheetCharge_ByTimeSheet(TimesheetID)

            For Each rate As DataRow In timeSheetRates.Table.Rows
                Select Case CType(rate("rate"), Enums.LabourTypes)
                    Case Enums.LabourTypes.Basic
                        totalPrice += (rate("Total") / 60) * normalRate
                        summaryStr += "Basic: " & rate("Total") & "mins@" & Format(normalRate, "C") & "/hr; "
                        engineerCostTotal += (rate("Total") / 60) * engineerCostNormal

                    Case Enums.LabourTypes.Time_And_Half
                        totalPrice += (rate("Total") / 60) * timeNHalfRate
                        summaryStr += "Time&Half: " & rate("Total") & "mins@" & Format(timeNHalfRate, "C") & "/hr; "
                        engineerCostTotal += (rate("Total") / 60) * engineerCostTimeHalf

                    Case Enums.LabourTypes.Double
                        totalPrice += (rate("Total") / 60) * doubleRate
                        summaryStr += "Double: " & rate("Total") & "mins@" & Format(doubleRate, "C") & "/hr; "
                        engineerCostTotal += (rate("Total") / 60) * engineerCostDouble

                End Select

            Next
        Else
            Select Case CType(bankHolidayRate, Enums.LabourTypes)
                Case Enums.LabourTypes.Basic
                    totalPrice = (DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / 60) * normalRate
                    summaryStr += "Bank Holiday Rate (Basic): " & DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) & "mins@" & Format(normalRate, "C") & "/hr; "
                    engineerCostTotal += (DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / 60) * engineerCostNormal

                Case Enums.LabourTypes.Time_And_Half
                    totalPrice = (DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / 60) * timeNHalfRate
                    summaryStr += "Bank Holiday Rate (Time&Half): " & DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) & "mins@" & Format(timeNHalfRate, "C") & "/hr; "
                    engineerCostTotal += (DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / 60) * engineerCostTimeHalf

                Case Enums.LabourTypes.Double
                    totalPrice = (DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / 60) * doubleRate
                    summaryStr += "Bank Holiday Rate (Double): " & DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) & "mins@" & Format(doubleRate, "C") & "/hr; "
                    engineerCostTotal += (DateDiff(DateInterval.Minute, StartDateTime, EndDateTime) / 60) * engineerCostDouble

            End Select
        End If

        If EngCost > 0 Then
            engineerCostTotal = EngCost
        End If

        DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Insert(EngineerVisitID, Tick, StartDateTime, EndDateTime, totalPrice, TimesheettypeID, summaryStr, engineerCostTotal)

    End Sub

    Private Sub DeleteCharges()
        'Delete Charges
        If Not EngVisitCharge Is Nothing Then
            DB.EngineerVisitCharge.EngineerVisitCharge_Delete(EngVisitCharge.EngineerVisitChargeID)
        End If

        'Delete Additonal Charges
        If Not AdditionalCharges Is Nothing Then
            For Each addCharge As DataRow In AdditionalCharges.Table.Rows
                DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete(addCharge("EngineerVisitAdditionalChargeID"))
            Next addCharge
        End If

        'Delete Schedule OF Rate
        If Not ScheduleOfRateCharges Is Nothing Then
            For Each SofR As DataRow In ScheduleOfRateCharges.Table.Rows
                DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete(SofR("EngineerVisitScheduleOfRateChargesID"))
            Next SofR
        End If

        DB.EvEngineer.Delete(EngineerVisit.EngineerVisitID, DeleteBy.EngineerVisitId)

        'Parts & Products
        DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID(EngineerVisit.EngineerVisitID)

        'Timesheets
        DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Delete(EngineerVisit.EngineerVisitID)
        'Save()
    End Sub

    Private Sub PopulateCharges(Optional ByVal initialLoad As Boolean = False)
        Loading = True

        Dim jbQuote As New Entity.QuoteJobs.QuoteJob
        'If its quoted work get the quote
        If Job.JobDefinitionEnumID = CInt(Enums.JobDefinition.Quoted) Then
            jbQuote = DB.QuoteJob.Get(Job.QuoteID)
        End If

        'See the charge reocrd alreay exists
        EngVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisit.EngineerVisitID)

        'if doesn't exist - insert
        If EngVisitCharge Is Nothing Then
            InsertCharges(jbQuote)
        End If

        If Helper.MakeDoubleValid(txtPartsMarkUp.Text) = 0 Then txtPartsMarkUp.Text = EngVisitCharge.PartsMarkUp

        'Make all additional quote labels invisible
        rdoPercentageOfQuoteValue.Visible = False
        lblPercent.Visible = False
        txtPercentOfQuote.Visible = False
        txtCharge.Visible = False
        lblEquals.Visible = False
        lblQuotePercentageTotal.Visible = False
        lblOR.Visible = False

        'Check the radio button for the type of job charge
        Select Case CType(EngVisitCharge.ChargeTypeID, Enums.JobChargingType)
            Case Enums.JobChargingType.JobValue
                rdoJobValue.Checked = True

            Case Enums.JobChargingType.PercentageOfQuote
                rdoPercentageOfQuoteValue.Checked = True
                txtPercentOfQuote.Text = EngVisitCharge.Charge

            Case Else
                rdoChargeOther.Checked = True

        End Select

        'Now show other controls/text dependent on job definition
        Select Case CType(Job.JobDefinitionEnumID, Enums.JobDefinition)
            Case Enums.JobDefinition.Quoted
                rdoChargeOther.Text = "No Charge For Callout Work"

            Case Enums.JobDefinition.Contract
                rdoChargeOther.Text = "No Charge - included On Contract Invoice"

            Case Enums.JobDefinition.Misc
                rdoChargeOther.Text = "No Charge For Miscellaneous Work"

            Case Enums.JobDefinition.Callout
                rdoChargeOther.Text = "No Charge For Callout Work"

        End Select

        Select Case CType(EngVisitCharge.InvoiceReadyID, Enums.InvoiceReady)
            Case Enums.InvoiceReady.Never
                cbxReadyToBeInvoiced.Checked = False
                cbxReadyToBeInvoiced.Enabled = False
            Case Enums.InvoiceReady.Not_Ready
                cbxReadyToBeInvoiced.Checked = False
                cbxReadyToBeInvoiced.Enabled = True
            Case Enums.InvoiceReady.Ready
                cbxReadyToBeInvoiced.Checked = True
                cbxReadyToBeInvoiced.Enabled = True
        End Select

        PopulateCostsTo()

        PopulateSageDetails()
        PopulateAdditionalCharges(True)
        PopulateScheduleOfRateCharges(True)
        PopulatePartsProductsCharges(True)
        PopulateTimeSheetCharges(True)
        CalculateJobValue()
        InvoiceToBeRaised = DB.InvoiceToBeRaised.InvoiceToBeRaised_Get_By_LinkID(EngVisitCharge.EngineerVisitChargeID, Enums.InvoiceType.Visit)

        Dim taxrateid As New DataTable
        If Not InvoiceToBeRaised Is Nothing Then 'at least we know this is past the stage of being readied for an invoice if not fully invoiced -  we need to check next if it is at ready to be invoiced or invoiced
            DisplayInvoiceAddress(InvoiceToBeRaised.AddressLinkID, InvoiceToBeRaised.AddressTypeID)
            taxrateid = DB.ExecuteWithReturn("Select TOP(1) i.VATRateID, i.InvoiceNumber, i.TermID, i.PaidByID,il.Amount,il.CreditAmount from tblInvoiced i inner  JOIN (Select SUM(Amount) Amount , ISNULL(SUM(CreditAmount),0) CreditAmount, InvoicedID,InvoiceToBeRaisedID from tblInvoicedLines il2 LEFT JOIN tblInvoicedLinesCredit ilc On ilc.InvoicedLineID = il2.InvoicedLineID   Group by InvoicedID,InvoiceToBeRaisedID) il On il.invoicedid = i.InvoicedID  where InvoiceToBeRaisedID =  " & InvoiceToBeRaised.InvoiceToBeRaisedID)
            Dim readytobe As DataTable = DB.ExecuteWithReturn("Select PaymentTermID,TaxrateID from tblInvoiceToBeRaised where InvoiceToBeRaisedID =  " & InvoiceToBeRaised.InvoiceToBeRaisedID)
            ' brought in two tables to compare and use values ready to be invoice and invoiced
            If taxrateid.Rows.Count = 0 OrElse IsDBNull(taxrateid.Rows(0)("VATRateID")) Then ' Check invoice details first if fail go looking for ready to be invoiced details..

                Combo.SetUpCombo(Me.cboVATRate, DB.VATRatesSQL.VATRates_GetAll_InputOrOutput("O").Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select)
                If readytobe Is Nothing OrElse IsDBNull(readytobe.Rows(0)("TaxrateID")) Then ' if not check if we have a rerady to be invoiced detailed if fail use default values..

                    Combo.SetSelectedComboItem_By_Value(cboVATRate, 6)
                    Combo.SetSelectedComboItem_By_Value(cboInvType, 69482)
                Else ' if they do exist use the ready to be invoiced details

                    Combo.SetSelectedComboItem_By_Value(cboVATRate, readytobe.Rows(0)("TaxrateID"))
                    Combo.SetSelectedComboItem_By_Value(cboInvType, readytobe.Rows(0)("PaymentTermID"))
                End If
            Else ' if there are invoice details (an invoice has been raised) use the invoice details
                Combo.SetUpCombo(Me.cboVATRate, DB.VATRatesSQL.VATRates_GetAll_InputOrOutput("O").Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select)
                Combo.SetSelectedComboItem_By_Value(cboVATRate, taxrateid.Rows(0)("VATRateID"))
                If Not IsDBNull(taxrateid.Rows(0)("TermID")) Then
                    Combo.SetSelectedComboItem_By_Value(cboInvType, taxrateid.Rows(0)("TermID"))

                    If (Not IsDBNull(taxrateid.Rows(0)("PaidByID"))) AndAlso taxrateid.Rows(0)("TermID") = 69491 Then

                        Combo.SetSelectedComboItem_By_Value(cboPaidBy, taxrateid.Rows(0)("PaidByID"))

                    End If
                Else
                    Combo.SetSelectedComboItem_By_Value(cboInvType, 69482)
                End If

                txtInvNo.Text = taxrateid.Rows(0)("InvoiceNumber")
                txtInvAmount.Text = Format(taxrateid.Rows(0)("Amount"), "C")
                txtCreditAmount.Text = Format(taxrateid.Rows(0)("CreditAmount"), "C")

            End If

            dtpRaiseInvoiceOn.Value = InvoiceToBeRaised.RaiseDate
            Dim i As Integer = 0
            If DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(InvoiceToBeRaised.InvoiceToBeRaisedID).Table.Rows.Count > 0 Then
                Me.gpbInvoice.Enabled = False
            Else
                Me.gpbInvoice.Enabled = True
            End If
        Else
            Combo.SetUpCombo(Me.cboVATRate, DB.VATRatesSQL.VATRates_GetAll_Valid().Table, "VATRateID", "Description", Enums.ComboValues.Please_Select)
            Combo.SetSelectedComboItem_By_Value(cboVATRate, 6)
            Combo.SetSelectedComboItem_By_Value(cboInvType, 69482)
        End If
        Loading = False

        chkSORDesc.Checked = EngineerVisit.UseSORDescription
        If initialLoad Then
            chkShowJobCharges.Checked = EngVisitCharge.HasChargesFromJob
        End If

        If chkSORDesc.Checked Then
            txtNotesFromEngineer.Enabled = False
        Else
            txtNotesFromEngineer.Enabled = True
        End If

        SaveVisitCharge(initialLoad)
        ShowEditableVisitCharges()
    End Sub

    Private Sub PopulateAdditionalCharges(Optional ByVal batchRun As Boolean = False)
        AdditionalCharges = DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_GetAll(EngineerVisit.EngineerVisitID)
        Dim additionalChargeTotal As Double = 0.0

        For Each charge As DataRow In AdditionalCharges.Table.Rows
            additionalChargeTotal += Helper.MakeDoubleValid(charge("Charge"))
        Next charge

        Me.txtAdditionalChargeTotal.Text = Format(additionalChargeTotal, "C")
        If Not batchRun Then CalculateJobValue()
    End Sub

    Private Sub PopulateScheduleOfRateCharges(Optional ByVal batchRun As Boolean = False)
        ScheduleOfRateCharges = DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID)
        Dim SORChargeTotal As Double = 0.0

        For Each charge As DataRow In ScheduleOfRateCharges.Table.Rows
            If Helper.MakeBooleanValid(charge("Tick")) Then
                SORChargeTotal += Helper.MakeDoubleValid(charge("Total"))
            End If
        Next charge

        Me.txtScheduleOfRatesTotal.Text = Format(SORChargeTotal, "C")
        If Not batchRun Then CalculateJobValue()
    End Sub

    Private Sub PopulateSageDetails()
        Dim cc As Integer = GetCostCentre()

        If Not EngVisitCharge Is Nothing Then
            Me.txtNominalCode.Text = EngVisitCharge.NominalCode
            If String.IsNullOrEmpty(EngVisitCharge.Department) Then
                Combo.SetSelectedComboItem_By_Value(cboDept, cc)
            Else
                Combo.SetSelectedComboItem_By_Value(cboDept, EngVisitCharge.Department)
            End If
            Me.txtAccountCode.Text = EngVisitCharge.ForSageAccountCode
        Else
            Me.txtNominalCode.Text = ""
            Combo.SetSelectedComboItem_By_Value(cboDept, cc)
            Me.txtAccountCode.Text = ""
        End If
    End Sub

    Private Sub PopulatePartsProductsCharges(Optional ByVal batchRun As Boolean = False, Optional ByVal recalc As Boolean = False)

        If chkShowJobCharges.Checked Then
            PartProductsCharges = DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_JobID(Job.JobID, EngineerVisit.EngineerVisitID)
        Else
            PartProductsCharges = DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID)
        End If

        Dim PPChargeTotal As Decimal = 0.0
        Dim PPCostTotal As Decimal = 0.0

        For Each charge As DataRow In PartProductsCharges.Table.Rows
            PPCostTotal += (Helper.MakeDoubleValid(charge("Rate")) * Helper.MakeDoubleValid(charge("Quantity")))
        Next charge

        If EngVisitCharge.PartsPrice > 0 Then PPChargeTotal = EngVisitCharge.PartsPrice
        If recalc Or EngVisitCharge.PartsPrice = 0 Then
            PPChargeTotal = 0
            For Each charge As DataRow In PartProductsCharges.Table.Rows
                If Helper.MakeBooleanValid(charge("Tick")) Then
                    PPChargeTotal += Helper.MakeDoubleValid(charge("Total"))
                End If
            Next charge
        End If

        Me.txtPartsProductTotal.Text = Format(PPChargeTotal, "C")
        Me.txtPartProductCost.Text = Format(PPCostTotal, "C")
        Dim tickCount As Integer = PartProductsCharges.Table.Select("Tick = " & True)?.Count
        If tickCount = PartProductsCharges.Count Then chkPartsSelectAll.Checked = True
        If tickCount = 0 Then chkPartsSelectAll.Checked = False
        If Not batchRun Then CalculateJobValue()
    End Sub

    Private Sub PopulateTimeSheetCharges(Optional ByVal batchRun As Boolean = False, Optional ByVal recalc As Boolean = False)
        If chkShowJobCharges.Checked Then
            TimeSheetCharges = DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get_ForJob(Job.JobID)
        Else
            TimeSheetCharges = DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get(EngineerVisit.EngineerVisitID)
        End If

        Dim tSChargeTotal As Double = 0.0
        Dim tsCostTotal As Double = 0.0
        For Each charge As DataRow In TimeSheetCharges.Table.Rows
            tsCostTotal += Helper.MakeDoubleValid(charge("EngineerCost"))
        Next charge

        If EngVisitCharge.LabourPrice > 0 Then tSChargeTotal = EngVisitCharge.LabourPrice
        If recalc Or EngVisitCharge.LabourPrice = 0 Then
            tSChargeTotal = 0
            For Each charge As DataRow In TimeSheetCharges.Table.Rows
                If Helper.MakeBooleanValid(charge("Tick")) Then
                    tSChargeTotal += Helper.MakeDoubleValid(charge("Price"))
                End If
            Next charge
        End If

        Me.txtTimesheetTotal.Text = Format(tSChargeTotal, "C")
        Me.txtEngineerCostTotal.Text = Format(tsCostTotal, "C")
        Dim tickCount As Integer = TimeSheetCharges.Table.Select("Tick = " & True)?.Count
        If tickCount = TimeSheetCharges.Count Then chkTimesheetSelectAll.Checked = True
        If tickCount = 0 Then chkTimesheetSelectAll.Checked = False
        If Not batchRun Then CalculateJobValue()
    End Sub

    Private Sub CalculateJobValue()

        Dim JobValue As Double = 0.0
        JobValue += Helper.MakeDoubleValid(Me.txtScheduleOfRatesTotal.Text.Replace("£", ""))

        JobValue += Helper.MakeDoubleValid(Me.txtAdditionalChargeTotal.Text.Replace("£", ""))

        JobValue += Helper.MakeDoubleValid(Me.txtPartsProductTotal.Text.Replace("£", ""))

        JobValue += Helper.MakeDoubleValid(Me.txtTimesheetTotal.Text.Replace("£", ""))

        'MINUS OFF THE DISCOUNT
        Me.txtJobValue.Text = Format(JobValue, "C")

        If EngVisitCharge Is Nothing Then
            EngVisitCharge = New Entity.EngineerVisitCharges.EngineerVisitCharge
        End If

        SaveVisitCharge()
        Profitable()
    End Sub

    Private Sub SaveVisitCharge(Optional ByVal initialLoad As Boolean = False)
        If Not Loading Then
            If EngVisitCharge Is Nothing Then
                EngVisitCharge = New Entity.EngineerVisitCharges.EngineerVisitCharge
            End If

            Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(Me.cboDept))

            If Helper.IsValidInteger(department) AndAlso Helper.MakeIntegerValid(department) < 0 Then
                ShowMessage("Please select a department!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            EngVisitCharge.SetNominalCode = Me.txtNominalCode.Text.Trim
            EngVisitCharge.SetDepartment = Combo.GetSelectedItemValue(cboDept)
            EngVisitCharge.SetForSageAccountCode = Me.txtAccountCode.Text.Trim
            EngVisitCharge.SetMainContractorDiscount = 0
            EngVisitCharge.SetEngineerVisitID = EngineerVisit.EngineerVisitID
            EngVisitCharge.SetJobValue = Helper.MakeDoubleValid(Me.txtJobValue.Text.Replace("£", ""))
            EngVisitCharge.SetTaxRateID = Combo.GetSelectedItemValue(cboVATRate)

            If rdoJobValue.Checked = True Then ' Job Value
                EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.JobValue)
                EngVisitCharge.SetCharge = 0
                If cbxReadyToBeInvoiced.Checked Then
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Ready)
                Else
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Not_Ready)
                End If
            ElseIf rdoPercentageOfQuoteValue.Checked = True Then ' Charging a percentage of a quote
                EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.PercentageOfQuote)
                EngVisitCharge.SetCharge = Helper.MakeDoubleValid(txtPercentOfQuote.Text.Trim)
                If cbxReadyToBeInvoiced.Checked Then
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Ready)
                Else
                    EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Not_Ready)
                End If
            Else

                Select Case CType(Job.JobDefinitionEnumID, Enums.JobDefinition)
                    Case Enums.JobDefinition.Quoted
                        EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.QuoteValue)
                        EngVisitCharge.SetCharge = 0
                        EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Never)
                    Case Enums.JobDefinition.Contract
                        EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.NoChargeContractInvoice)
                        EngVisitCharge.SetCharge = 0
                        EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Never)
                    Case Enums.JobDefinition.Misc
                        EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.NoChargeMisc)
                        EngVisitCharge.SetCharge = 0 ' No charge
                        EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Never)
                    Case Enums.JobDefinition.Callout
                        EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.NoChargeCallout)
                        EngVisitCharge.SetCharge = 0 ' No charge
                        EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Never)
                End Select
            End If
            EngVisitCharge.SetPartsMarkUp = Helper.MakeIntegerValid(txtPartsMarkUp.Text)
            EngVisitCharge.SetPartsPrice = Helper.MakeDoubleValid(txtPartsProductTotal.Text)
            EngVisitCharge.SetLabourPrice = Helper.MakeDoubleValid(txtTimesheetTotal.Text)
            EngVisitCharge.SetHasChargesFromJob = chkShowJobCharges.Checked

            If EngVisitCharge.Exists Then
                DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge, Job)
            Else
                EngVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Insert(EngVisitCharge)

                If cbxReadyToBeInvoiced.Checked Then
                    ' Status Changed enter Job Audit
                    Dim jA As New Entity.JobAudits.JobAudit
                    jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID
                    jA.SetActionChange = "Visit Status changed to Ready to be Invoiced (Unique Visit ID: " & EngineerVisit.EngineerVisitID & ")"
                    DB.JobAudit.Insert(jA)
                End If
            End If

            If InvoiceToBeRaised Is Nothing And initialLoad Then
                AutoInvoice()
            End If
        End If
    End Sub

    Private Sub AutoInvoice()
        Dim ibcs As DataView = DB.Ibc.GetAll()
        If ibcs.Table.Rows.Count = 0 Then Exit Sub
        Dim ibcSupplierIds As List(Of Integer) = (From x In ibcs.Table.AsEnumerable() Select x.Field(Of Integer)("SupplierId")).Distinct().ToList()
        Dim specialPartIds As New List(Of Integer) From {Consts.IbcPoPartID, Consts.SpecialOrderPartNumber}
        Dim drIBCs As DataRow() = EngineerVisit.PartsAndProductsAllocated.Table.Select("PartProductID IN (" & String.Join(",", specialPartIds.ToArray) & ") AND SupplierID IN (" & String.Join(",", ibcSupplierIds.ToArray) & ")")

        If drIBCs.Length = 1 And EngineerVisit.OutcomeEnumID = CInt(Enums.EngineerVisitOutcomes.Complete) Then
            Dim poValue As Double = Helper.MakeDoubleValid(drIBCs(0)("SellPrice"))
            Dim supplierId As Integer = Helper.MakeIntegerValid(drIBCs(0)("SupplierID"))
            If poValue <= 0 Then Exit Sub

            If ShowMessage("Auto Invoice Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Cursor.Current = Cursors.WaitCursor
                UnCheckAllCharges()
                Dim drIbc As DataRow = (From x In ibcs.Table.AsEnumerable() Where x.Field(Of Integer)("SupplierId") = supplierId Select x).FirstOrDefault()
                Dim department As Integer = Helper.MakeIntegerValid(drIbc("Department"))

                Dim costCentre As Integer = GetCostCentre()
                If Me.txtNotesFromEngineer.Text.Contains("IBC") And costCentre < 0 Then
                    Dim invoiceNotes As List(Of String) = Me.txtNotesFromEngineer.Text.Split(New Char() {" "c}).ToList()
                    Dim ibcDetails As String = invoiceNotes.Where(Function(x) x.Contains("IBC")).FirstOrDefault()
                    Dim ibcCostCentre As Integer = Helper.GetNumber(ibcDetails)
                    Dim departments As DataView = DB.Picklists.GetAll(Enums.PickListTypes.Department)
                    If (From x In departments.Table.AsEnumerable() Where x.Field(Of String)("Name") = ibcCostCentre Select x).Count > 0 Then
                        costCentre = ibcCostCentre
                    End If
                End If

                If costCentre = -1 Then
                    ShowMessage("Could not determine cost centre!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim nominal As String = Helper.MakeStringValid(drIbc("Nominal"))

                DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Insert(EngineerVisit.EngineerVisitID, "IBC" & costCentre & " - " & poValue.ToString("C"), poValue)
                EngVisitCharge.SetChargeTypeID = CInt(Enums.JobChargingType.JobValue)
                EngVisitCharge.SetInvoiceReadyID = CInt(Enums.InvoiceReady.Ready)
                EngVisitCharge.SetDepartment = department
                EngVisitCharge.SetCharge = poValue
                EngVisitCharge.SetJobValue = poValue
                EngVisitCharge.SetForSageAccountCode = "IBC" & costCentre
                EngVisitCharge.SetPartsPrice = 0
                EngVisitCharge.SetLabourPrice = 0
                If Not String.IsNullOrWhiteSpace(nominal) Then
                    EngVisitCharge.SetNominalCode = nominal
                End If

                DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge, Job)

                Dim invoiceAddress As New Entity.InvoiceAddresss.InvoiceAddress
                With invoiceAddress
                    .SetAddress1 = "DEPT " & Combo.GetSelectedItemValue(cboDept)
                    .SetAddress2 = TheSystem.Configuration.CompanyName
                    .SetAddress3 = TheSystem.Configuration.CompanyAddres1
                    .SetAddress4 = TheSystem.Configuration.CompanyAddres3
                    .SetAddress5 = String.Empty
                    .SetPostcode = TheSystem.Configuration.CompanyPostcode
                    .SetSiteID = Job.PropertyID
                End With

                Dim invoiceAddressId As Integer = DB.InvoiceAddress.Insert(invoiceAddress)?.InvoiceAddressID
                Dim invoiceAddressTypeId As Integer = CInt(Enums.InvoiceAddressType.Invoice)
                Dim invoiceRaiseDate As DateTime = EngineerVisit.StartDateTime

                If invoiceRaiseDate = Nothing OrElse DateHelper.GetFirstDayOfMonth(invoiceRaiseDate) < DateHelper.GetFirstDayOfMonth(Now) Then
                    Dim f As New FRMContractUpgradeDowngrade()
                    f.Text = "Select Date"
                    f.lblText.Text = "Please select invoice date"
                    f.ShowDialog()
                    If f.DialogResult = DialogResult.OK Then
                        invoiceRaiseDate = f.EffDate
                    End If
                End If

                InvoiceToBeRaised = New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
                With InvoiceToBeRaised
                    .SetAddressLinkID = invoiceAddressId
                    .SetAddressTypeID = invoiceAddressTypeId
                    .RaiseDate = If(invoiceRaiseDate = Nothing, Now, invoiceRaiseDate)
                    .SetInvoiceTypeID = CInt(Enums.InvoiceType.Visit)
                    .SetLinkID = EngVisitCharge.EngineerVisitChargeID
                    .SetCustomerID = theSite.CustomerID
                    .SetTaxRateID = 7
                    .SetPaymentTermID = 69482
                End With

                InvoiceToBeRaised = DB.InvoiceToBeRaised.Insert(InvoiceToBeRaised)
                DisplayInvoiceAddress(InvoiceToBeRaised.AddressLinkID, InvoiceToBeRaised.AddressTypeID)

                Dim invoice As New Entity.Invoiceds.Invoiced
                Dim invoiceNumber As New JobNumber
                invoiceNumber = DB.Job.GetNextJobNumber(5)
                With invoice
                    .SetInvoiceNumber = invoiceNumber.Prefix & invoiceNumber.JobNumber
                    .SetRaisedByUserID = loggedInUser.UserID
                    .RaisedDate = InvoiceToBeRaised.RaiseDate
                    .SetVATRateID = InvoiceToBeRaised.TaxRateID
                    .SetPaymentTermID = InvoiceToBeRaised.PaymentTermID
                    .SetPaidByID = InvoiceToBeRaised.PaidByID
                End With
                invoice = DB.Invoiced.Insert(invoice)

                Dim invoiceLines As New Entity.InvoicedLiness.InvoicedLines
                With invoiceLines
                    .SetAmount = EngVisitCharge.Charge
                    .SetInvoicedID = invoice.InvoicedID
                    .SetInvoiceToBeRaisedID = InvoiceToBeRaised.InvoiceToBeRaisedID
                End With
                invoiceLines = DB.InvoicedLines.Insert(invoiceLines)

                If ShowMessage("Do you want to view the invoice document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim details As New ArrayList From {New ArrayList From {New ArrayList From {invoice.InvoicedID, theSite.RegionID}}}
                    Dim oPrint As New Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, True)
                End If
                PopulateCharges()
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SetInvoiceControls()
        lblPriceInvVAT.Visible = cbxReadyToBeInvoiced.Checked
        txtPriceIncVAT.Visible = cbxReadyToBeInvoiced.Checked
        lblRaiseInvoiceOn.Visible = cbxReadyToBeInvoiced.Checked
        dtpRaiseInvoiceOn.Visible = cbxReadyToBeInvoiced.Checked
        lblInvoiceAddressDetails.Visible = cbxReadyToBeInvoiced.Checked
        lblAccountCode.Visible = cbxReadyToBeInvoiced.Checked
        txtAccountCode.Visible = cbxReadyToBeInvoiced.Checked
        btnSearch.Visible = cbxReadyToBeInvoiced.Checked

        lblVAT.Visible = cbxReadyToBeInvoiced.Checked
        cboVATRate.Visible = cbxReadyToBeInvoiced.Checked
        lblInvType.Visible = cbxReadyToBeInvoiced.Checked
        cboInvType.Visible = cbxReadyToBeInvoiced.Checked
        lblInvNo.Visible = cbxReadyToBeInvoiced.Checked
        txtInvNo.Visible = cbxReadyToBeInvoiced.Checked
        lblInvAmount.Visible = cbxReadyToBeInvoiced.Checked
        txtInvAmount.Visible = cbxReadyToBeInvoiced.Checked
        lblcredit.Visible = cbxReadyToBeInvoiced.Checked
        txtCreditAmount.Visible = cbxReadyToBeInvoiced.Checked

        If EngVisitCharge.InvoiceReadyID = CInt(Enums.InvoiceReady.Ready) Then
            Me.btnInvoice.Visible = True
        Else
            Me.btnInvoice.Visible = False
        End If
    End Sub

    Private Sub LoadReadyToBeInvoicedDetails()
        Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID)

        If Loading = False Then
            dtpRaiseInvoiceOn.Value = Now

            If Not EngineerVisit.StartDateTime = Nothing Then
                dtpRaiseInvoiceOn.Value = EngineerVisit.StartDateTime
            End If

            If cbxReadyToBeInvoiced.Checked Then
                SaveInvoiceToBeRaisedDetails()
            Else
                If Not InvoiceToBeRaised Is Nothing Then
                    DeleteInvoiceToBeRaiseDetails()
                End If
            End If
        End If
        SetInvoiceControls()
    End Sub

    Private Sub SaveInvoiceToBeRaisedDetails()
        If Loading = False Then

            If InvoiceToBeRaised Is Nothing Then
                Dim frm As New FRMSelectInvoiceAddress(theSite.SiteID)
                If Not frm.ShowDialog = DialogResult.OK Then
                    frm.Dispose()
                    cbxReadyToBeInvoiced.Checked = False
                    ShowMessage("An invoice address must be selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                InvoiceToBeRaised = New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
                InvoiceToBeRaised.SetAddressLinkID = frm.AddressLinkID
                InvoiceToBeRaised.SetAddressTypeID = frm.AddressTypeID

                frm.Dispose()
            End If

            InvoiceToBeRaised.RaiseDate = dtpRaiseInvoiceOn.Value
            InvoiceToBeRaised.SetInvoiceTypeID = CInt(Enums.InvoiceType.Visit)
            InvoiceToBeRaised.SetLinkID = EngVisitCharge.EngineerVisitChargeID
            InvoiceToBeRaised.SetCustomerID = DB.Customer.Customer_Get_ForSiteID(theSite.SiteID).CustomerID
            InvoiceToBeRaised.SetTaxRateID = Combo.GetSelectedItemValue(cboVATRate)
            InvoiceToBeRaised.SetPaymentTermID = Combo.GetSelectedItemValue(cboInvType)
            InvoiceToBeRaised.SetPaidByID = Combo.GetSelectedItemValue(cboPaidBy)

            If InvoiceToBeRaised.Exists = False Then
                InvoiceToBeRaised = DB.InvoiceToBeRaised.Insert(InvoiceToBeRaised)
            Else
                DB.InvoiceToBeRaised.Update(InvoiceToBeRaised)
            End If

            DisplayInvoiceAddress(InvoiceToBeRaised.AddressLinkID, InvoiceToBeRaised.AddressTypeID)
        End If
    End Sub

    Private Sub DeleteInvoiceToBeRaiseDetails()
        DB.InvoiceToBeRaised.Delete(InvoiceToBeRaised.InvoiceToBeRaisedID)
        InvoiceToBeRaised = Nothing
    End Sub

    Private Function GetPartProductCost(ByVal dr As DataRow) As Double

        Dim partProductColumnName As String = "ID"

        Dim Type As String = dr("Type")

        'WAS THE PART/PRODUCT ALLOCATED TO THE JOB ?
        '  Dim sR As DataRow() = EngineerVisit.PartsAndProductsAllocated.Table.Select("Type='" & Type & "' AND PartProductID=" & dr(partProductColumnName))

        Dim Sr As DataRow() = EngineerVisit.PartsAndProductsAllocated.Table.Select("Type='" & Type & "' AND  ID=" & Helper.MakeIntegerValid(dr("AllocatedID")))

        If Sr.Length > 0 Then

            'WAS IT ORDERED
            If Helper.MakeIntegerValid(Sr(0).Item("OrderID")) > 0 Then
                Dim dv As DataView = DB.Order.Order_ItemsGetAll(Sr(0).Item("OrderID"))
                Dim pR As DataRow()
                'WAS IT SOURCED FROM SUPPLIER
                If CType(Sr(0).Item("OrderLocationTypeID"), Enums.LocationType) = Enums.LocationType.Supplier Then
                    pR = dv.Table.Select("Type='Order" & Type & "' AND PartProductID=" & dr(partProductColumnName))
                Else  ' FROM WAREHOUSE OR VAN
                    Return GetSupplierBuyPrice(dr)
                    '   pR = dv.Table.Select("Type='OrderLocation" & Type & "' AND PartProductID=" & dr(partProductColumnName))
                End If

                'FOUND PART
                If pR.Length > 0 Then
                    Return Helper.MakeDoubleValid(pR(0).Item("BuyPrice") * dr("Quantity"))
                Else
                    'NOT FOUND TRY GET A BUY PRICE FROM SUPPLIER
                    Return GetSupplierBuyPrice(dr)
                End If
            Else
                'NOT ORDERED TRY GET A BUY PRICE FROM SUPPLIER
                Return GetSupplierBuyPrice(dr)
            End If
        Else
            'NOT ALLOCATED TRY GET A BUY PRICE FROM SUPPLIER
            Return GetSupplierBuyPrice(dr)
        End If

    End Function

    Private Function GetSupplierBuyPrice(ByVal dr As DataRow) As Double
        Dim dt As DataTable

        If Helper.MakeStringValid(dr("Type")).ToLower = "part" Then

            dt = DB.PartSupplier.Get_ByPartID(dr("ID")).Table
            Dim drPre() As DataRow = dt.Select("Preferred=1")
            If drPre.Length > 0 Then
                Return drPre(0).Item("Price") * Helper.MakeDoubleValid(dr("Quantity"))
            End If

            Dim lowest As Double = 0
            If dt.Rows.Count > 0 Then
                lowest = dt.Rows(0).Item("Price")
                For Each r As DataRow In dt.Rows
                    If r("Price") < lowest Then
                        lowest = r("Price")
                    End If
                Next r
            End If
            Return lowest * Helper.MakeDoubleValid(dr("Quantity"))
        Else
            dt = DB.ProductSupplier.Get_ByProductID(dr("ID")).Table
        End If
        If dt.Rows.Count > 0 Then
            Return Helper.MakeDoubleValid(dt.Rows(0).Item("Price")) * Helper.MakeDoubleValid(dr("Quantity"))
        Else
            Return 0
        End If

    End Function

    Private Sub DisplayInvoiceAddress(ByVal AddressLinkID As Integer, ByVal AddressTypeID As Integer)
        Dim address As String = ""

        Select Case AddressTypeID
            Case CInt(Enums.InvoiceAddressType.HQ), CInt(Enums.InvoiceAddressType.Site)
                With DB.Sites.Get(AddressLinkID)
                    If .Name.Trim.Length > 0 Then
                        address += .Name & vbCrLf
                    End If
                    If .Address1.Trim.Length > 0 Then
                        address += .Address1 & vbCrLf
                    End If
                    If .Address2.Trim.Length > 0 Then
                        address += .Address2 & vbCrLf
                    End If
                    If .Address3.Trim.Length > 0 Then
                        address += .Address3 & vbCrLf
                    End If
                    If .Address4.Trim.Length > 0 Then
                        address += .Address4 & vbCrLf
                    End If
                    If .Address5.Trim.Length > 0 Then
                        address += .Address5 & vbCrLf
                    End If
                    If .Postcode.Trim.Length > 0 Then
                        address += .Postcode & vbCrLf
                    End If
                End With

                Me.lblInvoiceAddressDetails.Text = address
            Case CInt(Enums.InvoiceAddressType.Invoice)
                With DB.InvoiceAddress.InvoiceAddress_Get(AddressLinkID)
                    If .Address1.Trim.Length > 0 Then
                        address += .Address1 & vbCrLf
                    End If
                    If .Address2.Trim.Length > 0 Then
                        address += .Address2 & vbCrLf
                    End If
                    If .Address3.Trim.Length > 0 Then
                        address += .Address3 & vbCrLf
                    End If
                    If .Address4.Trim.Length > 0 Then
                        address += .Address4 & vbCrLf
                    End If
                    If .Address5.Trim.Length > 0 Then
                        address += .Address5 & vbCrLf
                    End If
                    If .Postcode.Trim.Length > 0 Then
                        address += .Postcode & vbCrLf
                    End If
                End With
            Case Else
                address += "Not selected"
        End Select

        Me.lblInvoiceAddressDetails.Text = address
    End Sub

    Public Function GetCostCentre() As Integer
        Dim cc As CostCentre = DB.CostCentre.Get(Job?.JobTypeID, theSite.CustomerID, Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault()
        Return If(cc IsNot Nothing, cc.CostCentre, -1)
    End Function

    Private Sub ShutdownNonChargableVisits(ByVal e As FormClosingEventArgs)
        Dim visits As DataView = DB.EngineerVisits.EngineerVisits_Get_All_JobID(Job?.JobID)
        If visits.Count = 0 Then Exit Sub

        Dim openVisits As DataRow() = visits.Table.Select("StatusEnumID = " & CInt(Enums.VisitStatus.Uploaded))
        If openVisits.Length = 0 Then Exit Sub

        Dim msg As String = "This current visit has job releated charges." & vbCrLf & vbCrLf &
            "There are open relating visits, do you want to cost them off as non-chargeable?"

        Dim dialogResult As DialogResult = ShowMessage(msg, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        Select Case dialogResult
            Case DialogResult.Yes
                For Each visit As DataRow In openVisits
                    Dim evId As Integer = Helper.MakeIntegerValid(visit("EngineerVisitID"))
                    Dim ev As EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(evId)
                    If ev Is Nothing Then Continue For

                    ev.SetVisitLocked = True
                    ev.SetStatusEnumID = CInt(Enums.VisitStatus.Not_To_Be_Invoiced)
                    DB.EngineerVisits.Update(ev, 0, True)

                    Dim evc As New EngineerVisitCharge
                    With evc
                        .SetEngineerVisitID = ev.EngineerVisitID
                        .SetNominalCode = Me.txtNominalCode.Text.Trim
                        .SetDepartment = Combo.GetSelectedItemValue(cboDept).Trim()
                        .SetForSageAccountCode = Me.txtAccountCode.Text.Trim
                        .SetInvoiceReadyID = CInt(Enums.InvoiceReady.Never)
                        .SetPartsMarkUp = Helper.MakeIntegerValid(txtPartsMarkUp.Text)
                        .SetMainContractorDiscount = 0
                        .SetJobValue = 0
                        .SetTaxRateID = 0
                        .SetCharge = 0
                        .SetPartsPrice = 0
                        .SetLabourPrice = 0
                        .SetHasChargesFromJob = False
                    End With
                    evc = DB.EngineerVisitCharge.EngineerVisitCharge_Insert(evc)
                Next
            Case DialogResult.Cancel
                e.Cancel = True
                Exit Sub
            Case Else
                Exit Sub
        End Select
    End Sub

#End Region

#End Region

#Region "Allocated Parts"

    Public Class AllocatedStatusColourColumn : Inherits DataGridLabelColumn

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            'set the color required dependant on the column value
            Dim brush As Brush
            If Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("Status")) Then
                brush = Brushes.Lime
            Else
                brush = Brushes.Red
            End If
            'color the row cell
            Dim rect As Rectangle = bounds
            g.FillRectangle(brush, rect)
            g.DrawString("", Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
        End Sub

    End Class

    Public Sub SetupAllocatedDG()
        Helper.SetUpDataGrid(Me.dgPartsProductsAllocated)
        Dim tStyle As DataGridTableStyle = Me.dgPartsProductsAllocated.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim status As New AllocatedStatusColourColumn
        status.Format = ""
        status.FormatInfo = Nothing
        status.HeaderText = ""
        status.MappingName = "Status"
        status.ReadOnly = True
        status.Width = 15
        status.NullText = ""
        tStyle.GridColumnStyles.Add(status)

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "type"
        type.ReadOnly = True
        type.Width = 60
        type.NullText = ""
        tStyle.GridColumnStyles.Add(type)

        Dim number As New DataGridLabelColumn
        number.Format = ""
        number.FormatInfo = Nothing
        number.HeaderText = "Number"
        number.MappingName = "number"
        number.ReadOnly = True
        number.Width = 80
        number.NullText = ""
        tStyle.GridColumnStyles.Add(number)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 300
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim quantity As New DataGridLabelColumn
        quantity.Format = ""
        quantity.FormatInfo = Nothing
        quantity.HeaderText = "Qty Allocated"
        quantity.MappingName = "Quantity"
        quantity.ReadOnly = True
        quantity.Width = 50
        quantity.NullText = ""
        tStyle.GridColumnStyles.Add(quantity)

        Dim quantityRemaining As New DataGridLabelColumn
        quantityRemaining.Format = ""
        quantityRemaining.FormatInfo = Nothing
        quantityRemaining.HeaderText = "Quantity Unallocated"
        quantityRemaining.MappingName = "QtyRemaining"
        quantityRemaining.ReadOnly = True
        quantityRemaining.Width = 60
        quantityRemaining.NullText = ""
        tStyle.GridColumnStyles.Add(quantityRemaining)

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order Ref."
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 75
        OrderReference.NullText = "N/A"
        tStyle.GridColumnStyles.Add(OrderReference)

        Dim OrderStatus As New DataGridLabelColumn
        OrderStatus.Format = ""
        OrderStatus.FormatInfo = Nothing
        OrderStatus.HeaderText = "Order Status"
        OrderStatus.MappingName = "OrderStatus"
        OrderStatus.ReadOnly = True
        OrderStatus.Width = 75
        OrderStatus.NullText = "N/A"
        tStyle.GridColumnStyles.Add(OrderStatus)

        Dim QuantityReceived As New DataGridLabelColumn
        QuantityReceived.Format = ""
        QuantityReceived.FormatInfo = Nothing
        QuantityReceived.HeaderText = "Order Qty Received"
        QuantityReceived.MappingName = "QuantityReceived"
        QuantityReceived.ReadOnly = True
        QuantityReceived.Width = 75
        QuantityReceived.NullText = "N/A"
        tStyle.GridColumnStyles.Add(QuantityReceived)

        Dim CreditQty As New DataGridLabelColumn
        CreditQty.Format = ""
        CreditQty.FormatInfo = Nothing
        CreditQty.HeaderText = "Qty Credit"
        CreditQty.MappingName = "CreditQty"
        CreditQty.ReadOnly = True
        CreditQty.Width = 75
        CreditQty.NullText = "0"
        tStyle.GridColumnStyles.Add(CreditQty)

        Dim BuyPrice As New DataGridLabelColumn
        BuyPrice.Format = "C"
        BuyPrice.FormatInfo = Nothing
        BuyPrice.HeaderText = "Buy Price"
        BuyPrice.MappingName = "SellPrice"
        BuyPrice.ReadOnly = True
        BuyPrice.Width = 75
        BuyPrice.NullText = "0"
        tStyle.GridColumnStyles.Add(BuyPrice)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsAllocated.ToString
        Me.dgPartsProductsAllocated.TableStyles.Add(tStyle)
    End Sub

    Private _PartsAndProductsAllocated As DataView = Nothing

    Public Property PartsAndProductsAllocated() As DataView
        Get
            Return _PartsAndProductsAllocated
        End Get
        Set(ByVal Value As DataView)
            PartsAndProductsDistribution = DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit(EngineerVisit.EngineerVisitID)
            PartsAndProductsDistribution.Table.Constraints.Clear()
            Value.Table.AcceptChanges()
            Value.Table.Columns.Add(New DataColumn("Status", System.Type.GetType("System.Boolean")))
            Value.Table.Columns.Add(New DataColumn("Tick", GetType(Boolean)))
            'Value.Table.Columns("Tick").DefaultValue = False

            For Each row As DataRow In Value.Table.Rows
                row.Item("Tick") = False
                Dim distributed As Integer = 0
                Dim creditcolumn As Boolean = False
                Dim creditamt As Integer = 0
                For Each distrow As DataRow In PartsAndProductsDistribution.Table.Select("Type = '" & row.Item("Type") & "'")
                    If distrow.Item("AllocatedID") = row.Item("ID") Then
                        distributed += distrow.Item("Quantity")
                    End If
                Next

                For Each c As DataColumn In Value.Table.Columns
                    If c.ColumnName = "CreditQty" Then
                        creditcolumn = True
                        Exit For
                    End If
                Next

                If creditcolumn = False Then
                    creditamt = 0
                Else
                    If row.Item("CreditQty") Is DBNull.Value Then
                        creditamt = 0
                    Else
                        creditamt = row.Item("CreditQty")
                    End If
                End If

                If row.Item("OrderItemID") = 0 Then
                    row.Item("Status") = True
                ElseIf (distributed + creditamt) >= row.Item("QtyRemaining") Then
                    row.Item("Status") = True
                Else
                    row.Item("Status") = False
                End If
            Next

            Value.Table.PrimaryKey = New DataColumn() {Value.Table.Columns("ID")}
            _PartsAndProductsAllocated = Value
            _PartsAndProductsAllocated.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsAllocated.ToString
            _PartsAndProductsAllocated.AllowNew = False
            _PartsAndProductsAllocated.AllowEdit = False
            _PartsAndProductsAllocated.AllowDelete = False
            Me.dgPartsProductsAllocated.DataSource = PartsAndProductsAllocated

            SetupAllocatedDG()
        End Set
    End Property

    Private ReadOnly Property SelectedPartProductAllocatedDataRow() As DataRow
        Get
            If Not Me.dgPartsProductsAllocated.CurrentRowIndex = -1 Then
                Return PartsAndProductsAllocated(Me.dgPartsProductsAllocated.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelectedPartProductUsedDataRow() As DataRow
        Get
            If Not Me.dgPartsAndProductsUsed.CurrentRowIndex = -1 Then
                Return PartsAndProductsUsed(Me.dgPartsAndProductsUsed.CurrentRowIndex).Row
            Else

                Return Nothing
            End If
        End Get
    End Property

    Private _PartsAndProductsUsed As DataView = Nothing

    Public Property PartsAndProductsUsed() As DataView
        Get
            Return _PartsAndProductsUsed
        End Get
        Set(ByVal Value As DataView)
            _PartsAndProductsUsed = Value
        End Set
    End Property

    Private _PartsAndProductsDistribution As DataView = Nothing

    Public Property PartsAndProductsDistribution() As DataView
        Get
            Return _PartsAndProductsDistribution
        End Get
        Set(ByVal Value As DataView)
            _PartsAndProductsDistribution = Value
        End Set
    End Property

    Private Sub btnAllocatedNotUsed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllocatedNotUsed.Click
        If SelectedPartProductAllocatedDataRow Is Nothing Then
            ShowMessage("Please select a part or product to mark as not used", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim distributed As Integer = 0
        For Each row As DataRow In PartsAndProductsDistribution.Table.Select("Type = '" & SelectedPartProductAllocatedDataRow.Item("Type") & "'")
            If row.Item("AllocatedID") = SelectedPartProductAllocatedDataRow.Item("ID") Then
                distributed += row.Item("Quantity")
            End If
        Next

        If distributed = SelectedPartProductAllocatedDataRow("Quantity") Then
            ShowMessage("Distribution is complete for this " & SelectedPartProductAllocatedDataRow("Type"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim msg As String = "Are you sure the remaining"
        msg += " " & SelectedPartProductAllocatedDataRow("Quantity") - distributed & ", " & SelectedPartProductAllocatedDataRow("Name") & "'s have not been used? This action cannot be reversed once the job details have been saved"

        If ShowMessage(msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        If Helper.MakeIntegerValid(SelectedPartProductAllocatedDataRow.Item("OrderID")) = 0 Then
            PartsAndProductsDistribution.Table.AcceptChanges()

            Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
            r("Type") = SelectedPartProductAllocatedDataRow("Type")
            r("DistributedID") = 0
            r("LocationID") = 0
            r("AllocatedID") = SelectedPartProductAllocatedDataRow("ID")
            r("Other") = False
            r("Quantity") = SelectedPartProductAllocatedDataRow("Quantity") - distributed
            r("PartProductID") = SelectedPartProductAllocatedDataRow("PartProductID")
            r("OrderPartProductID") = 0
            r("StockTransactionType") = CInt(Enums.Transaction.StockIn)
            PartsAndProductsDistribution.Table.Rows.Add(r)

            SelectedPartProductAllocatedDataRow.Item("Status") = True
        Else
            Dim qtyReturned As Integer = 0
            'IS THE PART ON A SUPPLIER PO THAT IS COMPLETE
            Dim flagComleted As Boolean = False
            If SelectedPartProductAllocatedDataRow("OrderStatusID") = CInt(Enums.OrderStatus.Confirmed) Then
                If ShowMessage("This order is still confirmed! Would you like to make it as complete now?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    CompleteOrder(SelectedPartProductAllocatedDataRow("OrderItemID"))
                    flagComleted = True
                End If
            End If

            If SelectedPartProductAllocatedDataRow("OrderLocationTypeID") = CInt(Enums.LocationType.Supplier) And
                (SelectedPartProductAllocatedDataRow("OrderStatusID") >= CInt(Enums.OrderStatus.Complete) Or flagComleted = True) Then

                Dim fAddPartToBeCredited As New FRMAddPartToBeCredited(SelectedPartProductAllocatedDataRow("Quantity") - distributed)
                If fAddPartToBeCredited.ShowDialog = DialogResult.OK Then
                    qtyReturned = Helper.MakeIntegerValid(fAddPartToBeCredited.txtQtyToReturn.Text)
                End If
                If qtyReturned > 0 Then
                    'ADD TO DISTRIBUTION TABLE
                    Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
                    r("Type") = SelectedPartProductAllocatedDataRow("Type")
                    r("DistributedID") = 0
                    r("LocationID") = 0
                    r("AllocatedID") = SelectedPartProductAllocatedDataRow("ID")
                    r("Other") = False
                    r("Quantity") = qtyReturned
                    r("PartProductID") = SelectedPartProductAllocatedDataRow("PartProductID")
                    r("OrderPartProductID") = SelectedPartProductAllocatedDataRow("OrderItemID")
                    r("StockTransactionType") = -1 'FOR A PART CREDIT
                    PartsAndProductsDistribution.Table.Rows.Add(r)
                    'ADD CREDITED TO DISTRIBUTED
                    distributed += qtyReturned
                    SelectedPartProductAllocatedDataRow.Item("Status") = True
                End If
            End If

            If SelectedPartProductAllocatedDataRow("Quantity") - distributed > 0 Then

                Dim frmDistribution As New FRMDistributeAllocated(False, SelectedPartProductAllocatedDataRow("Quantity") - distributed, SelectedPartProductAllocatedDataRow.Item("Name"), SelectedPartProductAllocatedDataRow("Type"), SelectedPartProductAllocatedDataRow("PartProductID"), Nothing)
                If frmDistribution.ShowDialog = DialogResult.OK Then
                    PartsAndProductsDistribution.Table.AcceptChanges()

                    For Each row As DataRow In frmDistribution.Locations.Table.Rows
                        If row.Item("Quantity") > 0 Then
                            Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
                            r("Type") = SelectedPartProductAllocatedDataRow("Type")
                            r("DistributedID") = 0
                            r("LocationID") = row.Item("LocationID")
                            r("AllocatedID") = SelectedPartProductAllocatedDataRow("ID")
                            r("Other") = False
                            r("Quantity") = row.Item("Quantity")
                            r("PartProductID") = SelectedPartProductAllocatedDataRow("PartProductID")
                            r("OrderPartProductID") = SelectedPartProductAllocatedDataRow("OrderItemID")
                            r("StockTransactionType") = CInt(Enums.Transaction.StockIn)
                            PartsAndProductsDistribution.Table.Rows.Add(r)
                        End If
                    Next

                    SelectedPartProductAllocatedDataRow.Item("Status") = True
                End If
            End If
        End If
    End Sub

    Private Sub CompleteOrder(ByVal OrderPartID As Integer)

        Dim OrderPartz As Entity.OrderParts.OrderPart = DB.OrderPart.OrderPart_Get(OrderPartID)
        If OrderPartz Is Nothing Then Exit Sub
        Dim CurrentOrder As Entity.Orders.Order = DB.Order.Order_Get(OrderPartz.OrderID)

        If Not CurrentOrder.OrderStatusID = CInt(Enums.OrderStatus.Confirmed) Then
            ShowMessage("Order must be confirmed to Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim ItemsIncludedDataView As DataView = DB.Order.Order_ItemsGetAll(OrderPartz.OrderID)

        For Each itemRow As DataRow In ItemsIncludedDataView.Table.Rows

            If Not CInt(itemRow.Item("QuantityOnOrder")) = CInt(itemRow.Item("QuantityReceived")) Then

                Dim quantityInput As Integer = (CInt(itemRow.Item("QuantityOnOrder")) - CInt(itemRow.Item("QuantityReceived")))

                Select Case CStr(itemRow.Item("Type"))
                    Case "OrderProduct"

                        Dim OrderProduct As New Entity.OrderProducts.OrderProduct
                        Dim oProduct As New Entity.Products.Product

                        OrderProduct = DB.OrderProduct.OrderProduct_Get(CInt(itemRow("ID")))
                        Dim oProductSupplier As Entity.ProductSuppliers.ProductSupplier = DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID)
                        oProduct = DB.Product.Product_Get(oProductSupplier.ProductID)

                        OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + quantityInput
                        DB.OrderProduct.Update(OrderProduct)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID)

                                Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                                oProductTransaction.SetLocationID = oOrderLocation.LocationID
                                oProductTransaction.SetProductID = oProductSupplier.ProductID
                                oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID
                                oProductTransaction.SetAmount = quantityInput * oProductSupplier.QuantityInPack
                                oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                DB.ProductTransaction.Insert(oProductTransaction)
                        End Select
                    Case "OrderPart"

                        Dim OrderPart As New Entity.OrderParts.OrderPart
                        OrderPart = DB.OrderPart.OrderPart_Get(CInt(itemRow("ID")))

                        OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + quantityInput
                        DB.OrderPart.Update(OrderPart)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID)
                                Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID)

                                Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                oPartTransaction.SetLocationID = oOrderLocation.LocationID
                                oPartTransaction.SetPartID = oPartSupplier.PartID
                                oPartTransaction.SetOrderPartID = OrderPart.OrderPartID
                                oPartTransaction.SetAmount = quantityInput * oPartSupplier.QuantityInPack
                                oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                DB.PartTransaction.Insert(oPartTransaction)
                        End Select
                    Case "OrderLocationProduct"
                        Dim OrderLocationProduct As Entity.OrderLocationProduct.OrderLocationProduct = DB.OrderLocationProduct.OrderLocationProduct_Get(CInt(itemRow("ID")))
                        Dim oProductTransaction As Entity.ProductTransactions.ProductTransaction = DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(OrderLocationProduct.OrderLocationProductID)

                        oProductTransaction.SetAmount = oProductTransaction.Amount + quantityInput
                        DB.ProductTransaction.Update(oProductTransaction)

                        oProductTransaction.SetLocationID = OrderLocationProduct.LocationID
                        oProductTransaction.SetProductID = OrderLocationProduct.ProductID
                        oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID
                        oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockOut)
                        oProductTransaction.SetAmount = -quantityInput
                        DB.ProductTransaction.Insert(oProductTransaction)

                        OrderLocationProduct.SetQuantityReceived = OrderLocationProduct.QuantityReceived + quantityInput
                        DB.OrderLocationProduct.Update(OrderLocationProduct)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation
                                oOrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationProduct.OrderID)
                                oProductTransaction.SetLocationID = oOrderLocation.LocationID
                                oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID
                                oProductTransaction.SetAmount = quantityInput
                                oProductTransaction.SetProductID = OrderLocationProduct.ProductID
                                DB.ProductTransaction.Insert(oProductTransaction)
                        End Select

                    Case "OrderLocationPart"
                        Dim OrderLocationPart As Entity.OrderLocationPart.OrderLocationPart = DB.OrderLocationPart.OrderLocationPart_Get(CInt(itemRow("ID")))
                        Dim oPartTransaction As Entity.PartTransactions.PartTransaction = DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID)

                        oPartTransaction.SetAmount = oPartTransaction.Amount + quantityInput
                        DB.PartTransaction.Update(oPartTransaction)

                        oPartTransaction.SetLocationID = OrderLocationPart.LocationID
                        oPartTransaction.SetPartID = OrderLocationPart.PartID
                        oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID
                        oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockOut)
                        oPartTransaction.SetAmount = -quantityInput
                        DB.PartTransaction.Insert(oPartTransaction)

                        OrderLocationPart.SetQuantityReceived = OrderLocationPart.QuantityReceived + quantityInput
                        DB.OrderLocationPart.Update(OrderLocationPart)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation
                                oOrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID)
                                oPartTransaction.SetLocationID = oOrderLocation.LocationID
                                oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID
                                oPartTransaction.SetAmount = quantityInput
                                oPartTransaction.SetPartID = OrderLocationPart.PartID
                                DB.PartTransaction.Insert(oPartTransaction)
                        End Select
                End Select

            End If
        Next

        '    Populate(CurrentOrder.OrderID)

        CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Complete)
        DB.Order.Update(CurrentOrder)

    End Sub

    Private Function DeclareWhereGotFrom(ByVal Quantity As Integer, ByVal NameIn As String, ByVal TypeIn As String, ByVal IDIn As Integer) As Boolean
        Dim frmDistribution As New FRMDistributeAllocated(True, Quantity, NameIn, TypeIn, IDIn, BuildAllocatedArray(IDIn, TypeIn))
        If frmDistribution.ShowDialog = DialogResult.OK Then
            PartsAndProductsDistribution.Table.AcceptChanges()

            For Each row As DataRow In frmDistribution.Locations.Table.Rows
                If row.Item("Quantity") > 0 Then
                    Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
                    r("Type") = TypeIn
                    r("DistributedID") = 0
                    r("LocationID") = row.Item("LocationID")
                    r("AllocatedID") = row.Item("AllocatedID")
                    If row.Item("LocationID") = 0 And row.Item("AllocatedID") = 0 Then
                        r("Other") = True
                    Else
                        r("Other") = False
                    End If
                    r("Quantity") = row.Item("Quantity")
                    r("PartProductID") = IDIn
                    r("OrderPartProductID") = row.Item("OrderPartProductID")
                    r("StockTransactionType") = row.Item("StockTransactionType")
                    PartsAndProductsDistribution.Table.Rows.Add(r)
                End If
            Next

            For Each row As DataRow In PartsAndProductsAllocated.Table.Rows
                Dim distributed As Integer = 0
                For Each distrow As DataRow In PartsAndProductsDistribution.Table.Select("Type = '" & row.Item("Type") & "'")
                    If distrow.Item("AllocatedID") = row.Item("ID") Then
                        distributed += distrow.Item("Quantity")
                    End If
                Next

                If distributed >= row.Item("Quantity") Then
                    row.Item("Status") = True
                Else
                    row.Item("Status") = False
                End If
            Next

            Return True
        Else
            Return False
        End If
    End Function

    Private Function BuildAllocatedArray(ByVal PartProductIDIn As Integer, ByVal TypeIn As String) As ArrayList
        Dim arr As New ArrayList

        For Each row As DataRow In PartsAndProductsAllocated.Table.Rows
            If row.Item("Status") = False And row.Item("PartProductID") = PartProductIDIn And row.Item("Type") = TypeIn And Helper.MakeIntegerValid(row.Item("OrderID")) <> 0 Then
                Dim distributed As Integer = 0
                For Each dist As DataRow In PartsAndProductsDistribution.Table.Select("Type = '" & TypeIn & "'")
                    If dist.Item("AllocatedID") = row.Item("ID") Then
                        distributed += dist.Item("Quantity")
                    End If
                Next

                Dim amountAvailable As Integer = row.Item("Quantity") - distributed

                If amountAvailable >= 0 Then
                    Dim a As New ArrayList
                    a.Add(row.Item("ID"))
                    a.Add(amountAvailable)
                    a.Add(row.Item("OrderItemID"))
                    arr.Add(a)
                End If
            End If
        Next

        Return arr
    End Function

    Private Function RemovePart(ByVal Quantity As Integer, ByVal PartProductName As String, ByVal Type As String, ByVal PartProductID As Integer) As Boolean

        'IS THIS A PIECE OF EQUIPMENT?
        Dim equipment As Boolean = False
        If Type = "Part" Then
            Dim oPart As Entity.Parts.Part = DB.Part.Part_Get(PartProductID)
            If oPart.Equipment = True Then
                equipment = True
            End If
        End If

        If equipment = False Then
            Dim qtyReturned As Integer = 0
            Dim distributed As Integer = 0

            If Not Me.dgPartsProductsAllocated.CurrentRowIndex = -1 Then

                Dim fAddPartToBeCredited As New FRMAddPartToBeCredited(SelectedPartProductAllocatedDataRow("Quantity") - distributed)
                If fAddPartToBeCredited.ShowDialog = DialogResult.OK Then
                    qtyReturned = Helper.MakeIntegerValid(fAddPartToBeCredited.txtQtyToReturn.Text)
                End If
                If qtyReturned > 0 Then
                    'ADD TO DISTRIBUTION TABLE
                    Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
                    r("Type") = SelectedPartProductAllocatedDataRow("Type")
                    r("DistributedID") = 0
                    r("LocationID") = 0
                    r("AllocatedID") = SelectedPartProductAllocatedDataRow("ID")
                    r("Other") = False
                    r("Quantity") = qtyReturned
                    r("PartProductID") = SelectedPartProductAllocatedDataRow("PartProductID")
                    r("OrderPartProductID") = SelectedPartProductAllocatedDataRow("OrderItemID")
                    r("StockTransactionType") = -1 'FOR A PART CREDIT
                    PartsAndProductsDistribution.Table.Rows.Add(r)
                    'ADD CREDITED TO DISTRIBUTED
                    distributed += qtyReturned
                    SelectedPartProductAllocatedDataRow.Item("Status") = True
                End If

                If SelectedPartProductAllocatedDataRow("Quantity") - distributed > 0 Then

                    Dim frmDistribution As New FRMDistributeAllocated(False, Quantity, PartProductName, Type, PartProductID, Nothing)
                    If frmDistribution.ShowDialog = DialogResult.OK Then
                        PartsAndProductsDistribution.Table.AcceptChanges()

                        For Each row As DataRow In frmDistribution.Locations.Table.Rows
                            If row.Item("Quantity") > 0 Then
                                Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
                                r("Type") = Type
                                r("DistributedID") = 0
                                r("LocationID") = row.Item("LocationID")
                                r("AllocatedID") = 0
                                r("Other") = False
                                r("Quantity") = row.Item("Quantity")
                                r("PartProductID") = PartProductID
                                r("OrderPartProductID") = 0
                                r("StockTransactionType") = CInt(Enums.Transaction.StockIn)
                                PartsAndProductsDistribution.Table.Rows.Add(r)
                            End If
                        Next

                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return True
                End If

            ElseIf Not Me.dgPartsAndProductsUsed.CurrentRowIndex = -1 Then ' PArtsUsed

                If EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("OrderPartID") > 0 Then
                    Dim fAddPartToBeCredited As New FRMAddPartToBeCredited(EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Quantity") - distributed)
                    If fAddPartToBeCredited.ShowDialog = DialogResult.OK Then
                        qtyReturned = Helper.MakeIntegerValid(fAddPartToBeCredited.txtQtyToReturn.Text)
                    End If
                End If

                If qtyReturned > 0 Then
                    'ADD TO DISTRIBUTION TABLE
                    Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
                    r("Type") = EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Type")
                    r("DistributedID") = 0
                    r("LocationID") = 0
                    r("AllocatedID") = EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("AllocatedID")
                    r("Other") = False
                    r("Quantity") = qtyReturned
                    r("PartProductID") = EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("ID")
                    r("OrderPartProductID") = EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("OrderItemID")
                    r("StockTransactionType") = -1 'FOR A PART CREDIT
                    PartsAndProductsDistribution.Table.Rows.Add(r)
                    'ADD CREDITED TO DISTRIBUTED
                    distributed += qtyReturned
                    '  SelectedPartProductUsedDataRow.Item("Status") = True
                End If

                If EngineerVisit.PartsAndProductsUsed.Table.Rows(Me.dgPartsAndProductsUsed.CurrentRowIndex).Item("Quantity") - distributed > 0 Then

                    Dim frmDistribution As New FRMDistributeAllocated(False, Quantity, PartProductName, Type, PartProductID, Nothing)
                    If frmDistribution.ShowDialog = DialogResult.OK Then
                        PartsAndProductsDistribution.Table.AcceptChanges()

                        For Each row As DataRow In frmDistribution.Locations.Table.Rows
                            If row.Item("Quantity") > 0 Then
                                Dim r As DataRow = PartsAndProductsDistribution.Table.NewRow
                                r("Type") = Type
                                r("DistributedID") = 0
                                r("LocationID") = row.Item("LocationID")
                                r("AllocatedID") = 0
                                r("Other") = False
                                r("Quantity") = row.Item("Quantity")
                                r("PartProductID") = PartProductID
                                r("OrderPartProductID") = 0
                                r("StockTransactionType") = CInt(Enums.Transaction.StockIn)
                                PartsAndProductsDistribution.Table.Rows.Add(r)
                            End If
                        Next

                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return True
                End If

            End If
        Else
            Return True
        End If

    End Function

    Private Sub btnAllUsed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllUsed.Click
        If SelectedPartProductAllocatedDataRow Is Nothing Then
            ShowMessage("Please select a part or product to mark as fully used", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'lets check to see if we are moving multiple or individual part
        Dim mulitple As Boolean = False
        Dim selectedCount As Integer = 0
        For Each dr As DataRow In PartsAndProductsAllocated.Table.Rows
            If dr("Tick") = True Then
                selectedCount += 1
                If selectedCount > 1 Then
                    mulitple = True
                    Exit For
                End If
            End If
        Next

        If mulitple Then
            For Each dr As DataRow In PartsAndProductsAllocated.Table.Rows
                If dr("Tick") = True And dr("QtyRemaining") > 0 Then
                    UsePart(dr, dr("QtyRemaining"))
                End If
            Next
        Else
            For Each dr As DataRow In PartsAndProductsAllocated.Table.Rows
                If dr("Tick") = True Then
                    UsePart(dr, nudPartAllocatedQty.Value)
                End If
            Next
        End If

    End Sub

    Public Sub UsePart(dr As DataRow, qty As Integer)
        Dim addUsed As Boolean = False
        Dim LocationID As Integer = 0

        Dim distributed As Integer = 0
        For Each row As DataRow In PartsAndProductsDistribution.Table.Select(
            "Type = '" & dr("Type") & "'")
            If row.Item("AllocatedID") = dr("ID") Then
                distributed += row.Item("Quantity")
            End If
        Next

        If distributed >= dr("Quantity") Then
            ShowMessage("Distribution is complete for this " & dr("Type"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Helper.MakeIntegerValid(dr.Item("OrderID")) = 0 Then

            Dim frmDistribution As New FRMDistributeAllocated(
                True, qty, dr("Name"), dr("Type"), dr("PartProductID"),
                BuildAllocatedArray(dr("PartProductID"), dr("Type")))
            If frmDistribution.ShowDialog = DialogResult.OK Then
                PartsAndProductsDistribution.Table.AcceptChanges()

                For Each row As DataRow In frmDistribution.Locations.Table.Rows
                    If row.Item("QtyRemaining") > 0 Then
                        Dim drA() As DataRow =
                            PartsAndProductsDistribution.Table.Select("AllocatedID = " & dr("ID"))

                        For Each r As DataRow In drA
                            If r Is Nothing Then
                                r = PartsAndProductsDistribution.Table.NewRow
                                r("Type") = dr("Type")
                                r("DistributedID") = 0
                                r("LocationID") = row.Item("LocationID")
                                r("AllocatedID") = dr("ID")
                                If row.Item("LocationID") = 0 Then
                                    r("Other") = True
                                Else
                                    r("Other") = False
                                End If
                                r("Quantity") = qty
                                r("PartProductID") = dr("PartProductID")
                                r("OrderPartProductID") = 0
                                r("StockTransactionType") = CInt(Enums.Transaction.StockOut)
                                PartsAndProductsDistribution.Table.Rows.Add(r)

                                LocationID = row.Item("LocationID")
                            Else
                                r("Quantity") += qty
                            End If
                        Next
                    End If
                Next

                dr("QtyRemaining") -= qty
                If dr("Quantity") - dr("QtyRemaining") = dr("Quantity") Then
                    dr("Status") = True
                End If

                addUsed = True
            End If
        Else
            'HAS THE ORDER BEEN RECEIVED?
            Dim flagComleted As Boolean = False
            If dr("OrderStatusID") = CInt(Enums.OrderStatus.Confirmed) Then
                If ShowMessage("This order is still confirmed! Would you like to make it as complete now?",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) =
                               DialogResult.Yes Then
                    CompleteOrder(dr("OrderItemID"))
                    flagComleted = True
                End If
            End If

            If Helper.MakeIntegerValid(dr("QuantityOrdered")) =
                Helper.MakeIntegerValid(dr("QuantityReceived")) Or flagComleted = True Then
                PartsAndProductsDistribution.Table.AcceptChanges()

                Dim drA() As DataRow =
                    PartsAndProductsDistribution.Table.Select("AllocatedID = " & dr("ID"))

                For Each r As DataRow In drA
                    If r Is Nothing Then
                        r = PartsAndProductsDistribution.Table.NewRow
                        r("Type") = dr("Type")
                        r("DistributedID") = 0
                        r("LocationID") = 0
                        r("AllocatedID") = dr("ID")
                        r("Other") = False
                        r("Quantity") = qty
                        r("PartProductID") = dr("PartProductID")
                        r("OrderPartProductID") = dr("OrderItemID")
                        r("StockTransactionType") = 0
                        PartsAndProductsDistribution.Table.Rows.Add(r)
                    Else
                        r("Quantity") += qty
                    End If
                Next

                dr("QtyRemaining") -= qty
                If dr("Quantity") - dr("QtyRemaining") = dr("Quantity") Then
                    dr("Status") = True
                End If

                addUsed = True
            Else
                If ShowMessage("This is part that has been ordered but not fully received." & vbCrLf &
                           "Would you like to continue and select stock from another location?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim frmDistribution As New FRMDistributeAllocated(
                        True, qty, dr("Name"), dr("Type"), dr("PartProductID"),
                        BuildAllocatedArray(dr("PartProductID"), dr("Type")))

                    If frmDistribution.ShowDialog = DialogResult.OK Then
                        PartsAndProductsDistribution.Table.AcceptChanges()

                        For Each row As DataRow In frmDistribution.Locations.Table.Rows
                            If row.Item("QtyRemaining") > 0 Then
                                Dim drA() As DataRow =
                                    PartsAndProductsDistribution.Table.Select("AllocatedID = " & dr("ID"))

                                For Each r As DataRow In drA
                                    If r Is Nothing Then
                                        r = PartsAndProductsDistribution.Table.NewRow
                                        r("Type") = dr("Type")
                                        r("DistributedID") = 0
                                        r("LocationID") = row.Item("LocationID")
                                        r("AllocatedID") = dr("ID")
                                        If row.Item("LocationID") = 0 Then
                                            r("Other") = True
                                        Else
                                            r("Other") = False
                                        End If
                                        r("Quantity") = qty
                                        r("PartProductID") = dr("PartProductID")
                                        r("OrderPartProductID") = 0
                                        r("StockTransactionType") = CInt(Enums.Transaction.StockOut)
                                        PartsAndProductsDistribution.Table.Rows.Add(r)

                                        LocationID = row.Item("LocationID")
                                    Else
                                        r("Quantity") += qty
                                    End If
                                Next
                            End If
                        Next

                        dr("QtyRemaining") -= qty
                        If dr("Quantity") - dr("QtyRemaining") = dr("Quantity") Then
                            dr("Status") = True
                        End If

                        addUsed = True
                    End If
                End If
            End If
        End If

        If addUsed Then
            Dim newRow As DataRow = EngineerVisit.PartsAndProductsUsed.Table.NewRow()
            newRow.Item("ID") = dr("PartProductID")
            newRow.Item("AllocatedID") = dr("ID")
            newRow.Item("Type") = dr("Type")
            newRow.Item("Quantity") = qty

            If dr("Type") = "Part" Then
                Dim dialogue As FRMChooseAsset
                dialogue = checkIfExists(GetType(FRMChooseAsset).Name, True)
                If dialogue Is Nothing Then
                    dialogue = Activator.CreateInstance(GetType(FRMChooseAsset))
                End If
                '    dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                dialogue.ShowInTaskbar = False
                dialogue.JobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID
                dialogue.Part = dr("Name")
                dialogue.ShowDialog()
                dialogue.Close()

                Dim part As Entity.Parts.Part = DB.Part.Part_Get(dr("PartProductID"))
                newRow.Item("Number") = part.Number
                newRow.Item("Name") = dr("Name")
                newRow.Item("Reference") = part.Reference
                newRow.Item("SellPrice") = dr("SellPrice")
                If part.IsSpecialPart Then

                    newRow.Item("SpecialPrice") = dr("SellPrice")
                    newRow.Item("BuyPrice") = dr("SellPrice")
                    newRow.Item("SpecialDescription") = dr("Name")
                    newRow.Item("Number") = dr("Number")
                    newRow.Item("SpecialPartNumber") = dr("Number")

                End If
            Else
                Dim product As Entity.Products.Product = DB.Product.Product_Get(dr("PartProductID"))
                newRow.Item("Number") = product.Number
                newRow.Item("Name") = product.Name
                newRow.Item("Reference") = product.Reference
                newRow.Item("SellPrice") = product.SellPrice
            End If

            EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow)
        End If
    End Sub

#End Region

#Region "Photos"

    Private _PhotoDataview As DataView

    Public Property PhotoDataview() As DataView
        Get
            Return _PhotoDataview
        End Get
        Set(ByVal value As DataView)
            _PhotoDataview = value
            _PhotoDataview.AllowNew = False
            _PhotoDataview.AllowEdit = False
            _PhotoDataview.AllowDelete = False

            LoadPhotoControls()
        End Set
    End Property

    Private Sub tpPhotos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpPhotos.Enter
        If EngineerVisit.Photos.Count < 1 Then
            EngineerVisit.Photos = DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisit.EngineerVisitID)
            PhotoDataview = EngineerVisit.Photos
        End If
    End Sub

    Private Sub LoadPhotoControls()
        flPhotos.SuspendLayout()
        flPhotos.Controls.Clear()

        For Each photoRow As DataRow In PhotoDataview.Table.Rows

            Dim ucPhotoControl As New ucEngineerVisitPhoto

            ucPhotoControl.Photo = Bitmap.FromStream(New IO.MemoryStream(CType(photoRow("Photo"), Byte())))
            ucPhotoControl.Caption = photoRow("Caption")
            ucPhotoControl.EngineerVisitPhotoID = photoRow("EngineerVisitPhotoID")

            AddHandler ucPhotoControl.PhotoDeleteClicked, AddressOf PhotoDeleteClicked
            AddHandler ucPhotoControl.PhotoCaptionChanged, AddressOf PhotoCaptionChanged

            flPhotos.Controls.Add(ucPhotoControl)
        Next

        flPhotos.ResumeLayout()

    End Sub

    Private Sub PhotoCaptionChanged(ByVal EngineerVisitPhotoID As Integer, ByVal Caption As String)

        Dim evPhoto As New Entity.EngineerVisitPhotos.EngineerVisitPhoto
        evPhoto = DB.EngineerVisitPhotos.EngineerVisitPhoto_Get(EngineerVisitPhotoID)

        evPhoto.SetCaption = Caption
        DB.EngineerVisitPhotos.Update(evPhoto)

    End Sub

    Private Sub PhotoDeleteClicked(ByVal EngineerVisitPhotoID As Integer)
        If MessageBox.Show("Are you sure you want to delete this photo?", "Delete Photo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            DB.EngineerVisitPhotos.Delete(EngineerVisitPhotoID)
        End If

        EngineerVisit.Photos = DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisit.EngineerVisitID)
        PhotoDataview = EngineerVisit.Photos
    End Sub

#End Region

    Private Sub btnChangeOutcome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeOutcome.Click
        If loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) Then
            Me.cboOutcome.Enabled = True
        End If
    End Sub

    Private Sub cboOutcome_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOutcome.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboOutcome) = CInt(Enums.EngineerVisitOutcomes.Complete) Then
            chkGasServiceCompleted.Enabled = True
            If Job.JobTypeID = CInt(Enums.JobTypes.ServiceCertificate) Or
               Job.JobTypeID = CInt(Enums.JobTypes.Service) Then
                chkGasServiceCompleted.Checked = True
            Else
                chkGasServiceCompleted.Checked = False
            End If
        Else
            chkGasServiceCompleted.Enabled = False
            chkGasServiceCompleted.Checked = False
        End If
    End Sub

    Private Sub btnShowVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowVisits.Click
        ShowForm(GetType(FRMSiteVisitManager), True, New Object() {Job.PropertyID})
    End Sub

    Private Sub radioButtonCostsTo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CostsToOption1.CheckedChanged, CostsToOption2.CheckedChanged, CostsToOption3.CheckedChanged

        Dim rb As RadioButton = TryCast(sender, RadioButton)

        If rb Is Nothing Then
            MessageBox.Show("Sender is not a RadioButton")
            Return
        End If

        ' Ensure that the RadioButton.Checked property is true.
        If rb.Checked Then
            If Not rb.Text = EngineerVisit.CostsTo Then
                ' Keep track of the selected RadioButton by saving a reference to it' value.
                EngineerVisit.SetCostsTo = rb.Text
            End If
        End If
    End Sub

    Private Sub PopulateCostsTo()
        Select Case EngineerVisit.CostsTo
            Case "Contract"
                CostsToOption1.Checked = True
            Case "Chargeable"
                CostsToOption2.Checked = True
            Case "Warranty"
                CostsToOption3.Checked = True
            Case Else
        End Select
    End Sub

    Private Sub cboRecharge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRecharge.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboRecharge) > 0 Then
            lblRechargeTicked.Visible = True
        Else
            lblRechargeTicked.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShowForm(GetType(FRMCustomer), True, New Object() {CurrentCustomerID})
    End Sub

    Private Sub btnEditInvoiceNotes_Click(sender As Object, e As EventArgs) Handles btnEditInvoiceNotes.Click
        If loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Invoicing) Then
            txtNotesFromEngineer.ReadOnly = False
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub cboVATRate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVATRate.SelectedIndexChanged
        SetPriceIncVAT()
        SaveInvoiceToBeRaisedDetails()
    End Sub

    Private Sub cboInvType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInvType.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboInvType) = 69491 Then
            lblPaidBy.Visible = True
            cboPaidBy.Visible = True
        Else
            lblPaidBy.Visible = False
            cboPaidBy.Visible = False
        End If
        SaveInvoiceToBeRaisedDetails()
    End Sub

    Private Sub cboPaidBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaidBy.SelectedIndexChanged
        SaveInvoiceToBeRaisedDetails()
    End Sub

    Private Sub btnCreateServ_Click(sender As Object, e As EventArgs) Handles btnCreateServ.Click
        Dim f As New FRMCreateServices
        f.SiteID = theSite.SiteID
        f.ShowDialog()
    End Sub

    Private Sub chkSORDesc_CheckedChanged(sender As Object, e As EventArgs) Handles chkSORDesc.CheckedChanged
        If chkSORDesc.Checked Then
            txtNotesFromEngineer.Enabled = False
        Else
            txtNotesFromEngineer.Enabled = True
        End If
    End Sub

    Private Sub svrmenu_Click(sender As Object, e As EventArgs) Handles svrmenu.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            Dim oPrint As New Printing(details, "Site Visit Report ", Enums.SystemDocumentType.SVR)
        End If
    End Sub

    Private Sub JobSheetMenu_Click(sender As Object, e As EventArgs) Handles JobSheetMenu.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            Dim oPrint As New Printing(details, "JobSheet Report ", Enums.SystemDocumentType.JobSheet)
        End If
    End Sub

    Private Sub DomesticGSRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DomesticGSRToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            Dim oPrint As New Printing(details,
                                                  "Domestic GSR",
                                                  Enums.SystemDocumentType.DomGSR)
            DocumentsControl.Populate()
        End If
    End Sub

    Private Sub WarningNoticeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarningNoticeToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(VisitDefectDataview)
            Dim oPrint As New Printing(details, "Warning Notice", Enums.SystemDocumentType.Warn)
        End If
    End Sub

    Private Sub CommercialGSRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommercialGSRToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            Dim oPrint As New Printing(details, "Commercial GSR", Enums.SystemDocumentType.ComGSR)
            DocumentsControl.Populate()
        End If
    End Sub

    Private Sub QCResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QCResultsToolStripMenuItem.Click
        Dim dt As DataTable = DB.ExecuteWithReturn("Select TestType From tblEngineerVisitAdditionalChecks Where EngineerVisitID = " & EngineerVisit.EngineerVisitID)
        For Each dr As DataRow In dt.Rows
            Select Case Helper.MakeIntegerValid(dr("TestType"))
                Case Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork, Enums.AdditionalChecksTypes.PostCompleteAuditDomWork,
                     Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork, Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork,
                     Enums.AdditionalChecksTypes.ElectricalAudit
                    Dim details As New ArrayList
                    details.Add(EngineerVisit.EngineerVisitID)
                    details.Add(dr("TestType"))
                    Dim oPrint As New Printing(details, "QC Results", Enums.SystemDocumentType.QCPrint)
            End Select
        Next
    End Sub

    Private Sub ElectricalMinorWorksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElectricalMinorWorksToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            Dim oPrint As New Printing(details, "Electrical Minor Works", Enums.SystemDocumentType.ElecMinor)
        End If
    End Sub

    Private Sub AllGasPaperworkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllGasPaperworkToolStripMenuItem.Click
        If Save() Then

            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            details.Add(VisitDefectDataview)
            Dim oPrint As New Printing(details, "Gas Safety Record ", Enums.SystemDocumentType.GSR)
            DocumentsControl.Populate()

        End If
    End Sub

    Private Sub CommercialCateringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommercialCateringToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            Dim oPrint As New Printing(details, "Commercial Catering",
                                                  Enums.SystemDocumentType.ComCat)
            DocumentsControl.Populate()
        End If
    End Sub

    Private Sub SaffronUnventedWorkshhetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaffronUnventedWorkshhetToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            Dim oPrint As New Printing(details, "Saffron Unvented Worksheet",
                                                  Enums.SystemDocumentType.SaffUnv)
            DocumentsControl.Populate()
        End If
    End Sub

    Private Sub PropertyMaintenanceWorksheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertyMaintenanceWorksheetToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            Dim oPrint As New Printing(details, "Property Maintenance Worksheer",
                                                  Enums.SystemDocumentType.PropMaint)
            DocumentsControl.Populate()
        End If
    End Sub

    Private Sub CommissioningChecklistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommissioningChecklistToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            Dim oPrint As New Entity.Sys.Printing(details, "Commissioning Checklist", Entity.Sys.Enums.SystemDocumentType.CommissioningChecklist)
        End If
    End Sub

    Private Sub HotWorksPermitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HotWorksPermitToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            Dim oPrint As New Entity.Sys.Printing(details, "Hot Works Permit", Entity.Sys.Enums.SystemDocumentType.HotWorksPermit)
        End If
    End Sub

    Private Sub ASHPWorksheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ASHPWorksheetToolStripMenuItem.Click
        If Save() Then
            Dim details As New ArrayList
            details.Add(EngineerVisit)
            details.Add(theSite.CustomerID)
            Dim oPrint As New Printing(details, "ASHP Worksheet",
                                                  Enums.SystemDocumentType.ASHP)
            DocumentsControl.Populate()
        End If
    End Sub

    Private Sub rbSite_CheckedChanged(sender As Object, e As EventArgs)
        PopulateCharges()
    End Sub

    Private Sub chkShowJobCharges_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowJobCharges.CheckedChanged
        If Not EngineerVisit Is Nothing Then
            PopulateCharges()
        End If
    End Sub

    Private Sub lblcredit_Click(sender As Object, e As EventArgs) Handles lblcredit.Click
    End Sub

    Private Sub dgPartsProductsAllocated_Click(sender As Object, e As EventArgs) Handles dgPartsProductsAllocated.Click
        lblAllocatedQuantity.Visible = True
        nudPartAllocatedQty.Visible = True
        lblQuantityWarning.Visible = False
        If SelectedPartProductAllocatedDataRow Is Nothing Then
            Exit Sub
        End If

        Dim selected As Boolean = Not CBool(Me.dgPartsProductsAllocated(Me.dgPartsProductsAllocated.CurrentRowIndex, 1))
        Me.dgPartsProductsAllocated(Me.dgPartsProductsAllocated.CurrentRowIndex, 1) = selected

        Dim selectedCount As Integer = 0
        For Each dr As DataRow In PartsAndProductsAllocated.Table.Rows
            If dr("Tick") Then
                selectedCount += 1
                If selectedCount > 1 Then
                    lblAllocatedQuantity.Visible = False
                    nudPartAllocatedQty.Visible = False
                    lblQuantityWarning.Visible = True
                End If
            End If
        Next
    End Sub

    Private Sub btnRevertUsed_Click(sender As Object, e As EventArgs) Handles btnRevertUsed.Click
        If ShowMessage("You are about to revert the parts and products used! Do you wish to continue?",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EngineerVisit.PartsAndProductsAllocated =
                DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(
                EngineerVisit.EngineerVisitID)
            PartsAndProductsAllocated = EngineerVisit.PartsAndProductsAllocated

            EngineerVisit.PartsAndProductsUsed =
                 DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(
                  EngineerVisit.EngineerVisitID)
            dgPartsAndProductsUsed.DataSource = EngineerVisit.PartsAndProductsUsed
        End If
    End Sub

    Private Sub chkQCDocumentsRecieved_CheckedChanged(sender As Object, e As EventArgs) Handles chkQCDocumentsRecieved.CheckedChanged
        dtpQCDocumentsRecieved.Visible = chkQCDocumentsRecieved.Checked
    End Sub

    Private Sub btnUnselectAllPPA_Click(sender As Object, e As EventArgs) Handles btnUnselectAllPPA.Click
        For Each dr As DataRow In PartsAndProductsAllocated.Table.Rows
            dr("Tick") = False
            lblAllocatedQuantity.Visible = True
            nudPartAllocatedQty.Visible = True
            lblQuantityWarning.Visible = False
        Next
    End Sub

    Private Sub btnSelectAllPPA_Click(sender As Object, e As EventArgs) Handles btnSelectAllPPA.Click
        For Each dr As DataRow In PartsAndProductsAllocated.Table.Rows
            dr("Tick") = True
            lblAllocatedQuantity.Visible = False
            nudPartAllocatedQty.Visible = False
            lblQuantityWarning.Visible = True
        Next
    End Sub

    Public Sub SetupSiteFuelsDatagrid()
        Helper.SetUpDataGrid(Me.dgSiteFuel)
        Dim tStyle As DataGridTableStyle = Me.dgSiteFuel.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        dgSiteFuel.ReadOnly = False
        dgSiteFuel.AllowSorting = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 110
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim serviceDue As New DataGridSiteFuelColumn
        serviceDue.Format = "dd/MM/yyyy"
        serviceDue.FormatInfo = Nothing
        serviceDue.HeaderText = "Service Due"
        serviceDue.MappingName = "ServiceDue"
        serviceDue.ReadOnly = True
        serviceDue.Width = 105
        serviceDue.NullText = ""
        tStyle.GridColumnStyles.Add(serviceDue)

        Dim lastServiceDate As New DataGridSiteFuelColumn
        lastServiceDate.Format = "dd/MM/yyyy"
        lastServiceDate.FormatInfo = Nothing
        lastServiceDate.HeaderText = "Service Date"
        lastServiceDate.MappingName = "ActualServiceDate"
        lastServiceDate.ReadOnly = True
        lastServiceDate.Width = 105
        lastServiceDate.NullText = ""
        tStyle.GridColumnStyles.Add(lastServiceDate)

        tStyle.MappingName = Enums.TableNames.tblSiteFuel.ToString
        Me.dgSiteFuel.TableStyles.Add(tStyle)

    End Sub

    Private _dvSiteFuels As DataView = Nothing

    Public Property SiteFuelsDataView() As DataView
        Get
            Return _dvSiteFuels
        End Get
        Set(ByVal Value As DataView)
            _dvSiteFuels = Value
            _dvSiteFuels.AllowNew = False
            _dvSiteFuels.AllowEdit = False
            _dvSiteFuels.AllowDelete = False
            _dvSiteFuels.Table.TableName = Enums.TableNames.tblSiteFuel.ToString
            Me.dgSiteFuel.DataSource = SiteFuelsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedSiteFuelDataRow() As DataRow
        Get
            If Not Me.dgSiteFuel.CurrentRowIndex = -1 Then
                Return SiteFuelsDataView(Me.dgSiteFuel.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub PopulateSiteFuelDataGrid()
        Try
            SiteFuelsDataView = DB.Sites.SiteFuel_Get_ForEngineerVisit(EngineerVisit.EngineerVisitID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgSiteFuel_Click(sender As Object, e As EventArgs) Handles dgSiteFuel.Click
        If SelectedSiteFuelDataRow Is Nothing Then
            Exit Sub
        End If

        For Each dr As DataRow In SiteFuelsDataView.Table.Rows
            dr("tick") = 0
        Next

        Dim selected As Boolean = Not CBool(Me.dgSiteFuel(Me.dgSiteFuel.CurrentRowIndex, 0))
        Me.dgSiteFuel(Me.dgSiteFuel.CurrentRowIndex, 0) = selected
    End Sub

    Private Sub chkTimesheetSelectAll_Click(sender As Object, e As EventArgs) Handles chkTimesheetSelectAll.Click
        chkTimesheetSelectAll.Checked = Not chkTimesheetSelectAll.Checked
        Try
            If chkTimesheetSelectAll.Checked Then
                For Each dr As DataRow In TimeSheetCharges.Table.Rows
                    DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(dr("EngineerVisitTimesheetChargeID"), 1)
                Next
            Else
                For Each dr As DataRow In TimeSheetCharges.Table.Rows
                    DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(dr("EngineerVisitTimesheetChargeID"), 0)
                Next
            End If
            PopulateTimeSheetCharges(False, True)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkPartsSelectAll_Click(sender As Object, e As EventArgs) Handles chkPartsSelectAll.Click
        chkPartsSelectAll.Checked = Not chkPartsSelectAll.Checked
        Try
            If chkPartsSelectAll.Checked Then
                For Each dr As DataRow In PartProductsCharges.Table.Rows
                    If dr("Type") = "Part" Then
                        DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(dr("ChargeID"))
                        DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, dr("UniqueID"), dr("Price"), 1, dr("Cost"), dr("PartUsedID"))
                    Else
                        DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(dr("ChargeID"))
                        DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, dr("UniqueID"), dr("Price"), 1, dr("Cost"))
                    End If

                    dr("tick") = True
                Next
            Else
                For Each dr As DataRow In PartProductsCharges.Table.Rows
                    If dr("Type") = "Part" Then
                        DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(dr("ChargeID"))
                        DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, dr("UniqueID"), dr("Price"), 0, dr("Cost"), dr("PartUsedID"))
                    Else
                        DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(dr("ChargeID"))
                        DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, dr("UniqueID"), dr("Price"), 0, dr("Cost"))
                    End If

                    dr("tick") = False
                Next
            End If
            PopulatePartsProductsCharges(False, True)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtLabourMarkUp_TextChanged(sender As Object, e As EventArgs)
        Try
            For Each dr As DataRow In TimeSheetCharges.Table.Rows
                DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(dr("EngineerVisitTimesheetChargeID"), 1)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPartsMarkUp_Leave(sender As Object, e As EventArgs) Handles txtPartsMarkUp.Leave
        Try
            DB.EngineerVisitCharge.EngineerVisitPartsCharge_Update_Price(EngineerVisit.EngineerVisitID, Helper.MakeIntegerValid(txtPartsMarkUp.Text))
            PopulatePartsProductsCharges()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtPartsProductTotal_Leave(sender As Object, e As EventArgs) Handles txtPartsProductTotal.Leave
        CalculateJobValue()
    End Sub

    Private Sub txtTimesheetTotal_Leave(sender As Object, e As EventArgs) Handles txtTimesheetTotal.Leave
        CalculateJobValue()
    End Sub

    Private Sub UnCheckAllCharges()
        Try
            For Each dr As DataRow In PartProductsCharges.Table.Rows
                If dr("Type") = "Part" Then
                    DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete(dr("ChargeID"))
                    DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, dr("UniqueID"), dr("Price"), 0, dr("Cost"), dr("PartUsedID"))
                Else
                    DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(dr("ChargeID"))
                    DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, dr("UniqueID"), dr("Price"), 0, dr("Cost"))
                End If

                dr("tick") = False
            Next

            For Each dr As DataRow In TimeSheetCharges.Table.Rows
                DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(dr("EngineerVisitTimesheetChargeID"), 0)
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class