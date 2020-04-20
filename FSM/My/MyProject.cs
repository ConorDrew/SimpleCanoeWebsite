// Decompiled with JetBrains decompiler
// Type: FSM.My.MyProject
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM.My
{
    [StandardModule]
    [HideModuleName]
    [GeneratedCode("MyTemplate", "11.0.0.0")]
    internal sealed class MyProject
    {
        private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();
        private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();
        private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();
        private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();
        private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

        [HelpKeyword("My.Computer")]
        internal static MyComputer Computer
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_ComputerObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Application")]
        internal static MyApplication Application
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_AppObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.User")]
        internal static User User
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_UserObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Forms")]
        internal static MyProject.MyForms Forms
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_MyFormsObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.WebServices")]
        internal static MyProject.MyWebServices WebServices
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_MyWebServicesObjectProvider.GetInstance;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
        internal sealed class MyForms
        {
            [ThreadStatic]
            private static Hashtable m_FormBeingCreated;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGAdvancedItemSearch m_DLGAdvancedItemSearch;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGEngineerVisitDefect m_DLGEngineerVisitDefect;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGFindRecord m_DLGFindRecord;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGFindSite m_DLGFindSite;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGPasswordOverride m_DLGPasswordOverride;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGPasswordOverride_Service m_DLGPasswordOverride_Service;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGPasswordOverrideINV m_DLGPasswordOverrideINV;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGPickPartProductSupplier m_DLGPickPartProductSupplier;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGSetupVisit m_DLGSetupVisit;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGVisitAdditionalWorkSheet m_DLGVisitAdditionalWorkSheet;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DLGVisitAssetWorkSheet m_DLGVisitAssetWorkSheet;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAbout m_FRMAbout;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAbsenceColourKey m_FRMAbsenceColourKey;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmAbsences m_frmAbsences;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAddInvoiceAddress m_FRMAddInvoiceAddress;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FrmAdditionalNotes m_FrmAdditionalNotes;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAddPostcodeManager m_FRMAddPostcodeManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAddtoOrder m_FRMAddtoOrder;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAddToQuote m_FRMAddToQuote;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAddVanEquipment m_FRMAddVanEquipment;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAnswers m_FRMAnswers;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAsset m_FRMAsset;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMAvailableContractNos m_FRMAvailableContractNos;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMBaseForm m_FRMBaseForm;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMBatchGSRPrint m_FRMBatchGSRPrint;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMBatchVisitCosts m_FRMBatchVisitCosts;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FrmBlockAbsence m_FrmBlockAbsence;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMBookJob m_FRMBookJob;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMBulkJobCreation m_FRMBulkJobCreation;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangeInvoicedTotal m_FRMChangeInvoicedTotal;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangeInvoiceLine m_FRMChangeInvoiceLine;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangeJobType m_FRMChangeJobType;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangeOverridePassword m_FRMChangeOverridePassword;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangeOverridePassword_Service m_FRMChangeOverridePassword_Service;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangePassword m_FRMChangePassword;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangePaymentTerms m_FRMChangePaymentTerms;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangePriority m_FRMChangePriority;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangeRaiseDate m_FRMChangeRaiseDate;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChangeSageDate m_FRMChangeSageDate;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMCheckListManager m_FRMCheckListManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChooseAsset m_FRMChooseAsset;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMChooseSupplierPacks m_FRMChooseSupplierPacks;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMConsolidation m_FRMConsolidation;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContact m_FRMContact;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContactDetails m_FRMContactDetails;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractAlternativeSite m_FRMContractAlternativeSite;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractManager m_FRMContractManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractOption3Site m_FRMContractOption3Site;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractOriginal m_FRMContractOriginal;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractOriginalSite m_FRMContractOriginalSite;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractRenewal m_FRMContractRenewal;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractUpgradeDowngrade m_FRMContractUpgradeDowngrade;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMContractWiz m_FRMContractWiz;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMConvertToAnOrder m_FRMConvertToAnOrder;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMCostCentre m_FRMCostCentre;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMCreateServices m_FRMCreateServices;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMCreditReceived m_FRMCreditReceived;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMCustomer m_FRMCustomer;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMCustomerScheduleOfRate m_FRMCustomerScheduleOfRate;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMCustomerSORJobType m_FRMCustomerSORJobType;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMDirectDebitReport m_FRMDirectDebitReport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FrmDisplayEngineers m_FrmDisplayEngineers;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMDocuments m_FRMDocuments;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineer m_FRMEngineer;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerHistory m_FRMEngineerHistory;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerRaiseJob m_FRMEngineerRaiseJob;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerRole m_FRMEngineerRole;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerTimesheet m_FRMEngineerTimesheet;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerTimesheetReport m_FRMEngineerTimesheetReport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerTimesheets m_FRMEngineerTimesheets;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerVan m_FRMEngineerVan;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEngineerVisit m_FRMEngineerVisit;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEnterEmailAddress m_FRMEnterEmailAddress;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEquipment m_FRMEquipment;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMEquipmentUsed m_FRMEquipmentUsed;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMFindCustomers m_FRMFindCustomers;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMFindPart m_FRMFindPart;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMFleetEquipment m_FRMFleetEquipment;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMFleetVan m_FRMFleetVan;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMFleetVanImporter m_FRMFleetVanImporter;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMFleetVanManager m_FRMFleetVanManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMFleetVanType m_FRMFleetVanType;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMGenDropBox m_FRMGenDropBox;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMHistory m_FRMHistory;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMImport m_FRMImport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMInvoiceAddress m_FRMInvoiceAddress;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMInvoicedManager m_FRMInvoicedManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FrmInvoicedPayment m_FrmInvoicedPayment;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMInvoiceExtraDetail m_FRMInvoiceExtraDetail;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMInvoiceManager m_FRMInvoiceManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMItemReturn m_FRMItemReturn;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobAudit m_FRMJobAudit;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobImport m_FRMJobImport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobImportManager m_FRMJobImportManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobItemAssets m_FRMJobItemAssets;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobLocks m_FRMJobLocks;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobManager m_FRMJobManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobSkills m_FRMJobSkills;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMJobWizard m_FRMJobWizard;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMLastGSRReport m_FRMLastGSRReport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMLastServiceDate m_FRMLastServiceDate;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMLetterManager m_FRMLetterManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMLetterManagerMK3 m_FRMLetterManagerMK3;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMLogCallout m_FRMLogCallout;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMLogin m_FRMLogin;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMMain m_FRMMain;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMManager m_FRMManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMManualApp m_FRMManualApp;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMMoveParts m_FRMMoveParts;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMNewPrice m_FRMNewPrice;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMNotes m_FRMNotes;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMOrder m_FRMOrder;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMOrderCharges m_FRMOrderCharges;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMOrderManager m_FRMOrderManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMOrderRejection m_FRMOrderRejection;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FrmOverride m_FrmOverride;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPaidBy m_FRMPaidBy;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPart m_FRMPart;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartCategories m_FRMPartCategories;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartPack m_FRMPartPack;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartSelectLocation m_FRMPartSelectLocation;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartsImport m_FRMPartsImport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartsInvoiceImport m_FRMPartsInvoiceImport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartsToBeCredited m_FRMPartsToBeCredited;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartsToBeCreditedManager m_FRMPartsToBeCreditedManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartSupplier m_FRMPartSupplier;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPartsUsed m_FRMPartsUsed;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPickDespatchDetails m_FRMPickDespatchDetails;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPOInvoiceAuthorisation m_FRMPOInvoiceAuthorisation;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPOInvoiceAuthReasons m_FRMPOInvoiceAuthReasons;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPOInvoiceIncludedItems m_FRMPOInvoiceIncludedItems;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPostcodeManager m_FRMPostcodeManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMPrivNotes m_FRMPrivNotes;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMProduct m_FRMProduct;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMProductSupplier m_FRMProductSupplier;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteContractAlternativeConvert m_FRMQuoteContractAlternativeConvert;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteContractAlternativeSite m_FRMQuoteContractAlternativeSite;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteContractOption3 m_FRMQuoteContractOption3;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteContractOption3Convert m_FRMQuoteContractOption3Convert;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteContractOption3Site m_FRMQuoteContractOption3Site;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteJob m_FRMQuoteJob;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteJobItemAssets m_FRMQuoteJobItemAssets;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteJobSelectASite m_FRMQuoteJobSelectASite;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteManager m_FRMQuoteManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMQuoteRejection m_FRMQuoteRejection;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FrmRaiseInvoiceDetails m_FrmRaiseInvoiceDetails;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMReceiveStock m_FRMReceiveStock;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMReleaseNotes m_FRMReleaseNotes;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSchedulerFind m_FRMSchedulerFind;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmSchedulerMain m_frmSchedulerMain;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSchedulerSettings m_FRMSchedulerSettings;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSelectAMonth m_FRMSelectAMonth;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSelectAsset m_FRMSelectAsset;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSelectLocation m_FRMSelectLocation;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSite m_FRMSite;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSiteCustomerAudit m_FRMSiteCustomerAudit;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSiteLetterList m_FRMSiteLetterList;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSitePopup m_FRMSitePopup;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSiteVisitManager m_FRMSiteVisitManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSmokeComo m_FRMSmokeComo;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStandardSentences m_FRMStandardSentences;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStockCategoryValuation m_FRMStockCategoryValuation;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStockMove m_FRMStockMove;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStockMoved m_FRMStockMoved;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStockReplenishment m_FRMStockReplenishment;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStockTake m_FRMStockTake;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStockUsed m_FRMStockUsed;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMStockValuation m_FRMStockValuation;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSubcontractor m_FRMSubcontractor;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSupplier m_FRMSupplier;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSupplierInvoiceImporter m_FRMSupplierInvoiceImporter;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSupport m_FRMSupport;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMSystemScheduleOfRate m_FRMSystemScheduleOfRate;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMTimeSlotRates m_FRMTimeSlotRates;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMTypeMakeModel m_FRMTypeMakeModel;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMUserQualification m_FRMUserQualification;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMUsers m_FRMUsers;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMVan m_FRMVan;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMVanHistory m_FRMVanHistory;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMVATRates m_FRMVATRates;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMViewContractAlternativeChargeDetails m_FRMViewContractAlternativeChargeDetails;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMVisitManager m_FRMVisitManager;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FRMWarehouse m_FRMWarehouse;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public TabletOrder m_TabletOrder;

            [DebuggerHidden]
            private static T Create__Instance__<T>(T Instance) where T : Form, new()
            {
                if ((object)Instance != null && !Instance.IsDisposed)
                    return Instance;
                if (MyProject.MyForms.m_FormBeingCreated != null)
                {
                    if (MyProject.MyForms.m_FormBeingCreated.ContainsKey((object)typeof(T)))
                        throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate"));
                }
                else
                    MyProject.MyForms.m_FormBeingCreated = new Hashtable();
                MyProject.MyForms.m_FormBeingCreated.Add((object)typeof(T), (object)null);
                TargetInvocationException invocationException;
                try
                {
                    return new T();
                }
                catch (TargetInvocationException ex) when (
                {
                    // ISSUE: unable to correctly present filter
                    ProjectData.SetProjectError((Exception)ex);
                    invocationException = ex;
                    if (invocationException.InnerException != null)
                    {
                        SuccessfulFiltering;
                    }
                    else
                        throw;
                }
        )
        {
                    throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", invocationException.InnerException.Message), invocationException.InnerException);
                }
        finally
                {
                    MyProject.MyForms.m_FormBeingCreated.Remove((object)typeof(T));
                }
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance) where T : Form
            {
                instance.Dispose();
                instance = default(T);
            }

            [DebuggerHidden]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public MyForms()
            {
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            internal new System.Type GetType()
            {
                return typeof(MyProject.MyForms);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }

            public DLGAdvancedItemSearch DLGAdvancedItemSearch
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGAdvancedItemSearch = MyProject.MyForms.Create__Instance__<DLGAdvancedItemSearch>(this.m_DLGAdvancedItemSearch);
                    return this.m_DLGAdvancedItemSearch;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGAdvancedItemSearch)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGAdvancedItemSearch>(ref this.m_DLGAdvancedItemSearch);
                }
            }

            public DLGEngineerVisitDefect DLGEngineerVisitDefect
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGEngineerVisitDefect = MyProject.MyForms.Create__Instance__<DLGEngineerVisitDefect>(this.m_DLGEngineerVisitDefect);
                    return this.m_DLGEngineerVisitDefect;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGEngineerVisitDefect)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGEngineerVisitDefect>(ref this.m_DLGEngineerVisitDefect);
                }
            }

            public DLGFindRecord DLGFindRecord
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGFindRecord = MyProject.MyForms.Create__Instance__<DLGFindRecord>(this.m_DLGFindRecord);
                    return this.m_DLGFindRecord;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGFindRecord)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGFindRecord>(ref this.m_DLGFindRecord);
                }
            }

            public DLGFindSite DLGFindSite
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGFindSite = MyProject.MyForms.Create__Instance__<DLGFindSite>(this.m_DLGFindSite);
                    return this.m_DLGFindSite;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGFindSite)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGFindSite>(ref this.m_DLGFindSite);
                }
            }

            public DLGPasswordOverride DLGPasswordOverride
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGPasswordOverride = MyProject.MyForms.Create__Instance__<DLGPasswordOverride>(this.m_DLGPasswordOverride);
                    return this.m_DLGPasswordOverride;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGPasswordOverride)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGPasswordOverride>(ref this.m_DLGPasswordOverride);
                }
            }

            public DLGPasswordOverride_Service DLGPasswordOverride_Service
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGPasswordOverride_Service = MyProject.MyForms.Create__Instance__<DLGPasswordOverride_Service>(this.m_DLGPasswordOverride_Service);
                    return this.m_DLGPasswordOverride_Service;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGPasswordOverride_Service)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGPasswordOverride_Service>(ref this.m_DLGPasswordOverride_Service);
                }
            }

            public DLGPasswordOverrideINV DLGPasswordOverrideINV
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGPasswordOverrideINV = MyProject.MyForms.Create__Instance__<DLGPasswordOverrideINV>(this.m_DLGPasswordOverrideINV);
                    return this.m_DLGPasswordOverrideINV;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGPasswordOverrideINV)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGPasswordOverrideINV>(ref this.m_DLGPasswordOverrideINV);
                }
            }

            public DLGPickPartProductSupplier DLGPickPartProductSupplier
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGPickPartProductSupplier = MyProject.MyForms.Create__Instance__<DLGPickPartProductSupplier>(this.m_DLGPickPartProductSupplier);
                    return this.m_DLGPickPartProductSupplier;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGPickPartProductSupplier)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGPickPartProductSupplier>(ref this.m_DLGPickPartProductSupplier);
                }
            }

            public DLGSetupVisit DLGSetupVisit
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGSetupVisit = MyProject.MyForms.Create__Instance__<DLGSetupVisit>(this.m_DLGSetupVisit);
                    return this.m_DLGSetupVisit;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGSetupVisit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGSetupVisit>(ref this.m_DLGSetupVisit);
                }
            }

            public DLGVisitAdditionalWorkSheet DLGVisitAdditionalWorkSheet
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGVisitAdditionalWorkSheet = MyProject.MyForms.Create__Instance__<DLGVisitAdditionalWorkSheet>(this.m_DLGVisitAdditionalWorkSheet);
                    return this.m_DLGVisitAdditionalWorkSheet;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGVisitAdditionalWorkSheet)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGVisitAdditionalWorkSheet>(ref this.m_DLGVisitAdditionalWorkSheet);
                }
            }

            public DLGVisitAssetWorkSheet DLGVisitAssetWorkSheet
            {
                [DebuggerHidden]
                get
                {
                    this.m_DLGVisitAssetWorkSheet = MyProject.MyForms.Create__Instance__<DLGVisitAssetWorkSheet>(this.m_DLGVisitAssetWorkSheet);
                    return this.m_DLGVisitAssetWorkSheet;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_DLGVisitAssetWorkSheet)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<DLGVisitAssetWorkSheet>(ref this.m_DLGVisitAssetWorkSheet);
                }
            }

            public FRMAbout FRMAbout
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAbout = MyProject.MyForms.Create__Instance__<FRMAbout>(this.m_FRMAbout);
                    return this.m_FRMAbout;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAbout)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAbout>(ref this.m_FRMAbout);
                }
            }

            public FRMAbsenceColourKey FRMAbsenceColourKey
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAbsenceColourKey = MyProject.MyForms.Create__Instance__<FRMAbsenceColourKey>(this.m_FRMAbsenceColourKey);
                    return this.m_FRMAbsenceColourKey;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAbsenceColourKey)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAbsenceColourKey>(ref this.m_FRMAbsenceColourKey);
                }
            }

            public frmAbsences frmAbsences
            {
                [DebuggerHidden]
                get
                {
                    this.m_frmAbsences = MyProject.MyForms.Create__Instance__<frmAbsences>(this.m_frmAbsences);
                    return this.m_frmAbsences;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_frmAbsences)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmAbsences>(ref this.m_frmAbsences);
                }
            }

            public FRMAddInvoiceAddress FRMAddInvoiceAddress
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAddInvoiceAddress = MyProject.MyForms.Create__Instance__<FRMAddInvoiceAddress>(this.m_FRMAddInvoiceAddress);
                    return this.m_FRMAddInvoiceAddress;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAddInvoiceAddress)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAddInvoiceAddress>(ref this.m_FRMAddInvoiceAddress);
                }
            }

            public FrmAdditionalNotes FrmAdditionalNotes
            {
                [DebuggerHidden]
                get
                {
                    this.m_FrmAdditionalNotes = MyProject.MyForms.Create__Instance__<FrmAdditionalNotes>(this.m_FrmAdditionalNotes);
                    return this.m_FrmAdditionalNotes;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FrmAdditionalNotes)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FrmAdditionalNotes>(ref this.m_FrmAdditionalNotes);
                }
            }

            public FRMAddPostcodeManager FRMAddPostcodeManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAddPostcodeManager = MyProject.MyForms.Create__Instance__<FRMAddPostcodeManager>(this.m_FRMAddPostcodeManager);
                    return this.m_FRMAddPostcodeManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAddPostcodeManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAddPostcodeManager>(ref this.m_FRMAddPostcodeManager);
                }
            }

            public FRMAddtoOrder FRMAddtoOrder
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAddtoOrder = MyProject.MyForms.Create__Instance__<FRMAddtoOrder>(this.m_FRMAddtoOrder);
                    return this.m_FRMAddtoOrder;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAddtoOrder)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAddtoOrder>(ref this.m_FRMAddtoOrder);
                }
            }

            public FRMAddToQuote FRMAddToQuote
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAddToQuote = MyProject.MyForms.Create__Instance__<FRMAddToQuote>(this.m_FRMAddToQuote);
                    return this.m_FRMAddToQuote;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAddToQuote)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAddToQuote>(ref this.m_FRMAddToQuote);
                }
            }

            public FRMAddVanEquipment FRMAddVanEquipment
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAddVanEquipment = MyProject.MyForms.Create__Instance__<FRMAddVanEquipment>(this.m_FRMAddVanEquipment);
                    return this.m_FRMAddVanEquipment;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAddVanEquipment)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAddVanEquipment>(ref this.m_FRMAddVanEquipment);
                }
            }

            public FRMAnswers FRMAnswers
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAnswers = MyProject.MyForms.Create__Instance__<FRMAnswers>(this.m_FRMAnswers);
                    return this.m_FRMAnswers;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAnswers)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAnswers>(ref this.m_FRMAnswers);
                }
            }

            public FRMAsset FRMAsset
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAsset = MyProject.MyForms.Create__Instance__<FRMAsset>(this.m_FRMAsset);
                    return this.m_FRMAsset;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAsset)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAsset>(ref this.m_FRMAsset);
                }
            }

            public FRMAvailableContractNos FRMAvailableContractNos
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMAvailableContractNos = MyProject.MyForms.Create__Instance__<FRMAvailableContractNos>(this.m_FRMAvailableContractNos);
                    return this.m_FRMAvailableContractNos;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMAvailableContractNos)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMAvailableContractNos>(ref this.m_FRMAvailableContractNos);
                }
            }

            public FRMBaseForm FRMBaseForm
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMBaseForm = MyProject.MyForms.Create__Instance__<FRMBaseForm>(this.m_FRMBaseForm);
                    return this.m_FRMBaseForm;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMBaseForm)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMBaseForm>(ref this.m_FRMBaseForm);
                }
            }

            public FRMBatchGSRPrint FRMBatchGSRPrint
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMBatchGSRPrint = MyProject.MyForms.Create__Instance__<FRMBatchGSRPrint>(this.m_FRMBatchGSRPrint);
                    return this.m_FRMBatchGSRPrint;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMBatchGSRPrint)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMBatchGSRPrint>(ref this.m_FRMBatchGSRPrint);
                }
            }

            public FRMBatchVisitCosts FRMBatchVisitCosts
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMBatchVisitCosts = MyProject.MyForms.Create__Instance__<FRMBatchVisitCosts>(this.m_FRMBatchVisitCosts);
                    return this.m_FRMBatchVisitCosts;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMBatchVisitCosts)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMBatchVisitCosts>(ref this.m_FRMBatchVisitCosts);
                }
            }

            public FrmBlockAbsence FrmBlockAbsence
            {
                [DebuggerHidden]
                get
                {
                    this.m_FrmBlockAbsence = MyProject.MyForms.Create__Instance__<FrmBlockAbsence>(this.m_FrmBlockAbsence);
                    return this.m_FrmBlockAbsence;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FrmBlockAbsence)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FrmBlockAbsence>(ref this.m_FrmBlockAbsence);
                }
            }

            public FRMBookJob FRMBookJob
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMBookJob = MyProject.MyForms.Create__Instance__<FRMBookJob>(this.m_FRMBookJob);
                    return this.m_FRMBookJob;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMBookJob)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMBookJob>(ref this.m_FRMBookJob);
                }
            }

            public FRMBulkJobCreation FRMBulkJobCreation
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMBulkJobCreation = MyProject.MyForms.Create__Instance__<FRMBulkJobCreation>(this.m_FRMBulkJobCreation);
                    return this.m_FRMBulkJobCreation;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMBulkJobCreation)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMBulkJobCreation>(ref this.m_FRMBulkJobCreation);
                }
            }

            public FRMChangeInvoicedTotal FRMChangeInvoicedTotal
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangeInvoicedTotal = MyProject.MyForms.Create__Instance__<FRMChangeInvoicedTotal>(this.m_FRMChangeInvoicedTotal);
                    return this.m_FRMChangeInvoicedTotal;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangeInvoicedTotal)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangeInvoicedTotal>(ref this.m_FRMChangeInvoicedTotal);
                }
            }

            public FRMChangeInvoiceLine FRMChangeInvoiceLine
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangeInvoiceLine = MyProject.MyForms.Create__Instance__<FRMChangeInvoiceLine>(this.m_FRMChangeInvoiceLine);
                    return this.m_FRMChangeInvoiceLine;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangeInvoiceLine)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangeInvoiceLine>(ref this.m_FRMChangeInvoiceLine);
                }
            }

            public FRMChangeJobType FRMChangeJobType
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangeJobType = MyProject.MyForms.Create__Instance__<FRMChangeJobType>(this.m_FRMChangeJobType);
                    return this.m_FRMChangeJobType;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangeJobType)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangeJobType>(ref this.m_FRMChangeJobType);
                }
            }

            public FRMChangeOverridePassword FRMChangeOverridePassword
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangeOverridePassword = MyProject.MyForms.Create__Instance__<FRMChangeOverridePassword>(this.m_FRMChangeOverridePassword);
                    return this.m_FRMChangeOverridePassword;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangeOverridePassword)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangeOverridePassword>(ref this.m_FRMChangeOverridePassword);
                }
            }

            public FRMChangeOverridePassword_Service FRMChangeOverridePassword_Service
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangeOverridePassword_Service = MyProject.MyForms.Create__Instance__<FRMChangeOverridePassword_Service>(this.m_FRMChangeOverridePassword_Service);
                    return this.m_FRMChangeOverridePassword_Service;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangeOverridePassword_Service)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangeOverridePassword_Service>(ref this.m_FRMChangeOverridePassword_Service);
                }
            }

            public FRMChangePassword FRMChangePassword
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangePassword = MyProject.MyForms.Create__Instance__<FRMChangePassword>(this.m_FRMChangePassword);
                    return this.m_FRMChangePassword;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangePassword)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangePassword>(ref this.m_FRMChangePassword);
                }
            }

            public FRMChangePaymentTerms FRMChangePaymentTerms
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangePaymentTerms = MyProject.MyForms.Create__Instance__<FRMChangePaymentTerms>(this.m_FRMChangePaymentTerms);
                    return this.m_FRMChangePaymentTerms;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangePaymentTerms)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangePaymentTerms>(ref this.m_FRMChangePaymentTerms);
                }
            }

            public FRMChangePriority FRMChangePriority
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangePriority = MyProject.MyForms.Create__Instance__<FRMChangePriority>(this.m_FRMChangePriority);
                    return this.m_FRMChangePriority;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangePriority)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangePriority>(ref this.m_FRMChangePriority);
                }
            }

            public FRMChangeRaiseDate FRMChangeRaiseDate
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangeRaiseDate = MyProject.MyForms.Create__Instance__<FRMChangeRaiseDate>(this.m_FRMChangeRaiseDate);
                    return this.m_FRMChangeRaiseDate;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangeRaiseDate)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangeRaiseDate>(ref this.m_FRMChangeRaiseDate);
                }
            }

            public FRMChangeSageDate FRMChangeSageDate
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChangeSageDate = MyProject.MyForms.Create__Instance__<FRMChangeSageDate>(this.m_FRMChangeSageDate);
                    return this.m_FRMChangeSageDate;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChangeSageDate)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChangeSageDate>(ref this.m_FRMChangeSageDate);
                }
            }

            public FRMCheckListManager FRMCheckListManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMCheckListManager = MyProject.MyForms.Create__Instance__<FRMCheckListManager>(this.m_FRMCheckListManager);
                    return this.m_FRMCheckListManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMCheckListManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMCheckListManager>(ref this.m_FRMCheckListManager);
                }
            }

            public FRMChooseAsset FRMChooseAsset
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChooseAsset = MyProject.MyForms.Create__Instance__<FRMChooseAsset>(this.m_FRMChooseAsset);
                    return this.m_FRMChooseAsset;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChooseAsset)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChooseAsset>(ref this.m_FRMChooseAsset);
                }
            }

            public FRMChooseSupplierPacks FRMChooseSupplierPacks
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMChooseSupplierPacks = MyProject.MyForms.Create__Instance__<FRMChooseSupplierPacks>(this.m_FRMChooseSupplierPacks);
                    return this.m_FRMChooseSupplierPacks;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMChooseSupplierPacks)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMChooseSupplierPacks>(ref this.m_FRMChooseSupplierPacks);
                }
            }

            public FRMConsolidation FRMConsolidation
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMConsolidation = MyProject.MyForms.Create__Instance__<FRMConsolidation>(this.m_FRMConsolidation);
                    return this.m_FRMConsolidation;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMConsolidation)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMConsolidation>(ref this.m_FRMConsolidation);
                }
            }

            public FRMContact FRMContact
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContact = MyProject.MyForms.Create__Instance__<FRMContact>(this.m_FRMContact);
                    return this.m_FRMContact;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContact)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContact>(ref this.m_FRMContact);
                }
            }

            public FRMContactDetails FRMContactDetails
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContactDetails = MyProject.MyForms.Create__Instance__<FRMContactDetails>(this.m_FRMContactDetails);
                    return this.m_FRMContactDetails;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContactDetails)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContactDetails>(ref this.m_FRMContactDetails);
                }
            }

            public FRMContractAlternativeSite FRMContractAlternativeSite
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractAlternativeSite = MyProject.MyForms.Create__Instance__<FRMContractAlternativeSite>(this.m_FRMContractAlternativeSite);
                    return this.m_FRMContractAlternativeSite;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractAlternativeSite)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractAlternativeSite>(ref this.m_FRMContractAlternativeSite);
                }
            }

            public FRMContractManager FRMContractManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractManager = MyProject.MyForms.Create__Instance__<FRMContractManager>(this.m_FRMContractManager);
                    return this.m_FRMContractManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractManager>(ref this.m_FRMContractManager);
                }
            }

            public FRMContractOption3Site FRMContractOption3Site
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractOption3Site = MyProject.MyForms.Create__Instance__<FRMContractOption3Site>(this.m_FRMContractOption3Site);
                    return this.m_FRMContractOption3Site;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractOption3Site)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractOption3Site>(ref this.m_FRMContractOption3Site);
                }
            }

            public FRMContractOriginal FRMContractOriginal
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractOriginal = MyProject.MyForms.Create__Instance__<FRMContractOriginal>(this.m_FRMContractOriginal);
                    return this.m_FRMContractOriginal;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractOriginal)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractOriginal>(ref this.m_FRMContractOriginal);
                }
            }

            public FRMContractOriginalSite FRMContractOriginalSite
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractOriginalSite = MyProject.MyForms.Create__Instance__<FRMContractOriginalSite>(this.m_FRMContractOriginalSite);
                    return this.m_FRMContractOriginalSite;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractOriginalSite)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractOriginalSite>(ref this.m_FRMContractOriginalSite);
                }
            }

            public FRMContractRenewal FRMContractRenewal
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractRenewal = MyProject.MyForms.Create__Instance__<FRMContractRenewal>(this.m_FRMContractRenewal);
                    return this.m_FRMContractRenewal;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractRenewal)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractRenewal>(ref this.m_FRMContractRenewal);
                }
            }

            public FRMContractUpgradeDowngrade FRMContractUpgradeDowngrade
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractUpgradeDowngrade = MyProject.MyForms.Create__Instance__<FRMContractUpgradeDowngrade>(this.m_FRMContractUpgradeDowngrade);
                    return this.m_FRMContractUpgradeDowngrade;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractUpgradeDowngrade)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractUpgradeDowngrade>(ref this.m_FRMContractUpgradeDowngrade);
                }
            }

            public FRMContractWiz FRMContractWiz
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMContractWiz = MyProject.MyForms.Create__Instance__<FRMContractWiz>(this.m_FRMContractWiz);
                    return this.m_FRMContractWiz;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMContractWiz)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMContractWiz>(ref this.m_FRMContractWiz);
                }
            }

            public FRMConvertToAnOrder FRMConvertToAnOrder
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMConvertToAnOrder = MyProject.MyForms.Create__Instance__<FRMConvertToAnOrder>(this.m_FRMConvertToAnOrder);
                    return this.m_FRMConvertToAnOrder;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMConvertToAnOrder)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMConvertToAnOrder>(ref this.m_FRMConvertToAnOrder);
                }
            }

            public FRMCostCentre FRMCostCentre
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMCostCentre = MyProject.MyForms.Create__Instance__<FRMCostCentre>(this.m_FRMCostCentre);
                    return this.m_FRMCostCentre;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMCostCentre)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMCostCentre>(ref this.m_FRMCostCentre);
                }
            }

            public FRMCreateServices FRMCreateServices
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMCreateServices = MyProject.MyForms.Create__Instance__<FRMCreateServices>(this.m_FRMCreateServices);
                    return this.m_FRMCreateServices;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMCreateServices)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMCreateServices>(ref this.m_FRMCreateServices);
                }
            }

            public FRMCreditReceived FRMCreditReceived
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMCreditReceived = MyProject.MyForms.Create__Instance__<FRMCreditReceived>(this.m_FRMCreditReceived);
                    return this.m_FRMCreditReceived;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMCreditReceived)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMCreditReceived>(ref this.m_FRMCreditReceived);
                }
            }

            public FRMCustomer FRMCustomer
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMCustomer = MyProject.MyForms.Create__Instance__<FRMCustomer>(this.m_FRMCustomer);
                    return this.m_FRMCustomer;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMCustomer)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMCustomer>(ref this.m_FRMCustomer);
                }
            }

            public FRMCustomerScheduleOfRate FRMCustomerScheduleOfRate
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMCustomerScheduleOfRate = MyProject.MyForms.Create__Instance__<FRMCustomerScheduleOfRate>(this.m_FRMCustomerScheduleOfRate);
                    return this.m_FRMCustomerScheduleOfRate;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMCustomerScheduleOfRate)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMCustomerScheduleOfRate>(ref this.m_FRMCustomerScheduleOfRate);
                }
            }

            public FRMCustomerSORJobType FRMCustomerSORJobType
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMCustomerSORJobType = MyProject.MyForms.Create__Instance__<FRMCustomerSORJobType>(this.m_FRMCustomerSORJobType);
                    return this.m_FRMCustomerSORJobType;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMCustomerSORJobType)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMCustomerSORJobType>(ref this.m_FRMCustomerSORJobType);
                }
            }

            public FRMDirectDebitReport FRMDirectDebitReport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMDirectDebitReport = MyProject.MyForms.Create__Instance__<FRMDirectDebitReport>(this.m_FRMDirectDebitReport);
                    return this.m_FRMDirectDebitReport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMDirectDebitReport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMDirectDebitReport>(ref this.m_FRMDirectDebitReport);
                }
            }

            public FrmDisplayEngineers FrmDisplayEngineers
            {
                [DebuggerHidden]
                get
                {
                    this.m_FrmDisplayEngineers = MyProject.MyForms.Create__Instance__<FrmDisplayEngineers>(this.m_FrmDisplayEngineers);
                    return this.m_FrmDisplayEngineers;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FrmDisplayEngineers)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FrmDisplayEngineers>(ref this.m_FrmDisplayEngineers);
                }
            }

            public FRMDocuments FRMDocuments
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMDocuments = MyProject.MyForms.Create__Instance__<FRMDocuments>(this.m_FRMDocuments);
                    return this.m_FRMDocuments;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMDocuments)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMDocuments>(ref this.m_FRMDocuments);
                }
            }

            public FRMEngineer FRMEngineer
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineer = MyProject.MyForms.Create__Instance__<FRMEngineer>(this.m_FRMEngineer);
                    return this.m_FRMEngineer;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineer)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineer>(ref this.m_FRMEngineer);
                }
            }

            public FRMEngineerHistory FRMEngineerHistory
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerHistory = MyProject.MyForms.Create__Instance__<FRMEngineerHistory>(this.m_FRMEngineerHistory);
                    return this.m_FRMEngineerHistory;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerHistory)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerHistory>(ref this.m_FRMEngineerHistory);
                }
            }

            public FRMEngineerRaiseJob FRMEngineerRaiseJob
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerRaiseJob = MyProject.MyForms.Create__Instance__<FRMEngineerRaiseJob>(this.m_FRMEngineerRaiseJob);
                    return this.m_FRMEngineerRaiseJob;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerRaiseJob)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerRaiseJob>(ref this.m_FRMEngineerRaiseJob);
                }
            }

            public FRMEngineerRole FRMEngineerRole
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerRole = MyProject.MyForms.Create__Instance__<FRMEngineerRole>(this.m_FRMEngineerRole);
                    return this.m_FRMEngineerRole;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerRole)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerRole>(ref this.m_FRMEngineerRole);
                }
            }

            public FRMEngineerTimesheet FRMEngineerTimesheet
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerTimesheet = MyProject.MyForms.Create__Instance__<FRMEngineerTimesheet>(this.m_FRMEngineerTimesheet);
                    return this.m_FRMEngineerTimesheet;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerTimesheet)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerTimesheet>(ref this.m_FRMEngineerTimesheet);
                }
            }

            public FRMEngineerTimesheetReport FRMEngineerTimesheetReport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerTimesheetReport = MyProject.MyForms.Create__Instance__<FRMEngineerTimesheetReport>(this.m_FRMEngineerTimesheetReport);
                    return this.m_FRMEngineerTimesheetReport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerTimesheetReport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerTimesheetReport>(ref this.m_FRMEngineerTimesheetReport);
                }
            }

            public FRMEngineerTimesheets FRMEngineerTimesheets
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerTimesheets = MyProject.MyForms.Create__Instance__<FRMEngineerTimesheets>(this.m_FRMEngineerTimesheets);
                    return this.m_FRMEngineerTimesheets;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerTimesheets)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerTimesheets>(ref this.m_FRMEngineerTimesheets);
                }
            }

            public FRMEngineerVan FRMEngineerVan
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerVan = MyProject.MyForms.Create__Instance__<FRMEngineerVan>(this.m_FRMEngineerVan);
                    return this.m_FRMEngineerVan;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerVan)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerVan>(ref this.m_FRMEngineerVan);
                }
            }

            public FRMEngineerVisit FRMEngineerVisit
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEngineerVisit = MyProject.MyForms.Create__Instance__<FRMEngineerVisit>(this.m_FRMEngineerVisit);
                    return this.m_FRMEngineerVisit;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEngineerVisit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEngineerVisit>(ref this.m_FRMEngineerVisit);
                }
            }

            public FRMEnterEmailAddress FRMEnterEmailAddress
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEnterEmailAddress = MyProject.MyForms.Create__Instance__<FRMEnterEmailAddress>(this.m_FRMEnterEmailAddress);
                    return this.m_FRMEnterEmailAddress;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEnterEmailAddress)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEnterEmailAddress>(ref this.m_FRMEnterEmailAddress);
                }
            }

            public FRMEquipment FRMEquipment
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEquipment = MyProject.MyForms.Create__Instance__<FRMEquipment>(this.m_FRMEquipment);
                    return this.m_FRMEquipment;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEquipment)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEquipment>(ref this.m_FRMEquipment);
                }
            }

            public FRMEquipmentUsed FRMEquipmentUsed
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMEquipmentUsed = MyProject.MyForms.Create__Instance__<FRMEquipmentUsed>(this.m_FRMEquipmentUsed);
                    return this.m_FRMEquipmentUsed;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMEquipmentUsed)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMEquipmentUsed>(ref this.m_FRMEquipmentUsed);
                }
            }

            public FRMFindCustomers FRMFindCustomers
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMFindCustomers = MyProject.MyForms.Create__Instance__<FRMFindCustomers>(this.m_FRMFindCustomers);
                    return this.m_FRMFindCustomers;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMFindCustomers)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMFindCustomers>(ref this.m_FRMFindCustomers);
                }
            }

            public FRMFindPart FRMFindPart
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMFindPart = MyProject.MyForms.Create__Instance__<FRMFindPart>(this.m_FRMFindPart);
                    return this.m_FRMFindPart;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMFindPart)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMFindPart>(ref this.m_FRMFindPart);
                }
            }

            public FRMFleetEquipment FRMFleetEquipment
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMFleetEquipment = MyProject.MyForms.Create__Instance__<FRMFleetEquipment>(this.m_FRMFleetEquipment);
                    return this.m_FRMFleetEquipment;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMFleetEquipment)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMFleetEquipment>(ref this.m_FRMFleetEquipment);
                }
            }

            public FRMFleetVan FRMFleetVan
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMFleetVan = MyProject.MyForms.Create__Instance__<FRMFleetVan>(this.m_FRMFleetVan);
                    return this.m_FRMFleetVan;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMFleetVan)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMFleetVan>(ref this.m_FRMFleetVan);
                }
            }

            public FRMFleetVanImporter FRMFleetVanImporter
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMFleetVanImporter = MyProject.MyForms.Create__Instance__<FRMFleetVanImporter>(this.m_FRMFleetVanImporter);
                    return this.m_FRMFleetVanImporter;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMFleetVanImporter)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMFleetVanImporter>(ref this.m_FRMFleetVanImporter);
                }
            }

            public FRMFleetVanManager FRMFleetVanManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMFleetVanManager = MyProject.MyForms.Create__Instance__<FRMFleetVanManager>(this.m_FRMFleetVanManager);
                    return this.m_FRMFleetVanManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMFleetVanManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMFleetVanManager>(ref this.m_FRMFleetVanManager);
                }
            }

            public FRMFleetVanType FRMFleetVanType
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMFleetVanType = MyProject.MyForms.Create__Instance__<FRMFleetVanType>(this.m_FRMFleetVanType);
                    return this.m_FRMFleetVanType;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMFleetVanType)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMFleetVanType>(ref this.m_FRMFleetVanType);
                }
            }

            public FRMGenDropBox FRMGenDropBox
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMGenDropBox = MyProject.MyForms.Create__Instance__<FRMGenDropBox>(this.m_FRMGenDropBox);
                    return this.m_FRMGenDropBox;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMGenDropBox)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMGenDropBox>(ref this.m_FRMGenDropBox);
                }
            }

            public FRMHistory FRMHistory
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMHistory = MyProject.MyForms.Create__Instance__<FRMHistory>(this.m_FRMHistory);
                    return this.m_FRMHistory;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMHistory)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMHistory>(ref this.m_FRMHistory);
                }
            }

            public FRMImport FRMImport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMImport = MyProject.MyForms.Create__Instance__<FRMImport>(this.m_FRMImport);
                    return this.m_FRMImport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMImport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMImport>(ref this.m_FRMImport);
                }
            }

            public FRMInvoiceAddress FRMInvoiceAddress
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMInvoiceAddress = MyProject.MyForms.Create__Instance__<FRMInvoiceAddress>(this.m_FRMInvoiceAddress);
                    return this.m_FRMInvoiceAddress;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMInvoiceAddress)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMInvoiceAddress>(ref this.m_FRMInvoiceAddress);
                }
            }

            public FRMInvoicedManager FRMInvoicedManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMInvoicedManager = MyProject.MyForms.Create__Instance__<FRMInvoicedManager>(this.m_FRMInvoicedManager);
                    return this.m_FRMInvoicedManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMInvoicedManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMInvoicedManager>(ref this.m_FRMInvoicedManager);
                }
            }

            public FrmInvoicedPayment FrmInvoicedPayment
            {
                [DebuggerHidden]
                get
                {
                    this.m_FrmInvoicedPayment = MyProject.MyForms.Create__Instance__<FrmInvoicedPayment>(this.m_FrmInvoicedPayment);
                    return this.m_FrmInvoicedPayment;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FrmInvoicedPayment)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FrmInvoicedPayment>(ref this.m_FrmInvoicedPayment);
                }
            }

            public FRMInvoiceExtraDetail FRMInvoiceExtraDetail
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMInvoiceExtraDetail = MyProject.MyForms.Create__Instance__<FRMInvoiceExtraDetail>(this.m_FRMInvoiceExtraDetail);
                    return this.m_FRMInvoiceExtraDetail;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMInvoiceExtraDetail)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMInvoiceExtraDetail>(ref this.m_FRMInvoiceExtraDetail);
                }
            }

            public FRMInvoiceManager FRMInvoiceManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMInvoiceManager = MyProject.MyForms.Create__Instance__<FRMInvoiceManager>(this.m_FRMInvoiceManager);
                    return this.m_FRMInvoiceManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMInvoiceManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMInvoiceManager>(ref this.m_FRMInvoiceManager);
                }
            }

            public FRMItemReturn FRMItemReturn
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMItemReturn = MyProject.MyForms.Create__Instance__<FRMItemReturn>(this.m_FRMItemReturn);
                    return this.m_FRMItemReturn;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMItemReturn)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMItemReturn>(ref this.m_FRMItemReturn);
                }
            }

            public FRMJobAudit FRMJobAudit
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobAudit = MyProject.MyForms.Create__Instance__<FRMJobAudit>(this.m_FRMJobAudit);
                    return this.m_FRMJobAudit;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobAudit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobAudit>(ref this.m_FRMJobAudit);
                }
            }

            public FRMJobImport FRMJobImport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobImport = MyProject.MyForms.Create__Instance__<FRMJobImport>(this.m_FRMJobImport);
                    return this.m_FRMJobImport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobImport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobImport>(ref this.m_FRMJobImport);
                }
            }

            public FRMJobImportManager FRMJobImportManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobImportManager = MyProject.MyForms.Create__Instance__<FRMJobImportManager>(this.m_FRMJobImportManager);
                    return this.m_FRMJobImportManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobImportManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobImportManager>(ref this.m_FRMJobImportManager);
                }
            }

            public FRMJobItemAssets FRMJobItemAssets
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobItemAssets = MyProject.MyForms.Create__Instance__<FRMJobItemAssets>(this.m_FRMJobItemAssets);
                    return this.m_FRMJobItemAssets;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobItemAssets)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobItemAssets>(ref this.m_FRMJobItemAssets);
                }
            }

            public FRMJobLocks FRMJobLocks
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobLocks = MyProject.MyForms.Create__Instance__<FRMJobLocks>(this.m_FRMJobLocks);
                    return this.m_FRMJobLocks;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobLocks)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobLocks>(ref this.m_FRMJobLocks);
                }
            }

            public FRMJobManager FRMJobManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobManager = MyProject.MyForms.Create__Instance__<FRMJobManager>(this.m_FRMJobManager);
                    return this.m_FRMJobManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobManager>(ref this.m_FRMJobManager);
                }
            }

            public FRMJobSkills FRMJobSkills
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobSkills = MyProject.MyForms.Create__Instance__<FRMJobSkills>(this.m_FRMJobSkills);
                    return this.m_FRMJobSkills;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobSkills)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobSkills>(ref this.m_FRMJobSkills);
                }
            }

            public FRMJobWizard FRMJobWizard
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMJobWizard = MyProject.MyForms.Create__Instance__<FRMJobWizard>(this.m_FRMJobWizard);
                    return this.m_FRMJobWizard;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMJobWizard)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMJobWizard>(ref this.m_FRMJobWizard);
                }
            }

            public FRMLastGSRReport FRMLastGSRReport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMLastGSRReport = MyProject.MyForms.Create__Instance__<FRMLastGSRReport>(this.m_FRMLastGSRReport);
                    return this.m_FRMLastGSRReport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMLastGSRReport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMLastGSRReport>(ref this.m_FRMLastGSRReport);
                }
            }

            public FRMLastServiceDate FRMLastServiceDate
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMLastServiceDate = MyProject.MyForms.Create__Instance__<FRMLastServiceDate>(this.m_FRMLastServiceDate);
                    return this.m_FRMLastServiceDate;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMLastServiceDate)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMLastServiceDate>(ref this.m_FRMLastServiceDate);
                }
            }

            public FRMLetterManager FRMLetterManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMLetterManager = MyProject.MyForms.Create__Instance__<FRMLetterManager>(this.m_FRMLetterManager);
                    return this.m_FRMLetterManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMLetterManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMLetterManager>(ref this.m_FRMLetterManager);
                }
            }

            public FRMLetterManagerMK3 FRMLetterManagerMK3
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMLetterManagerMK3 = MyProject.MyForms.Create__Instance__<FRMLetterManagerMK3>(this.m_FRMLetterManagerMK3);
                    return this.m_FRMLetterManagerMK3;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMLetterManagerMK3)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMLetterManagerMK3>(ref this.m_FRMLetterManagerMK3);
                }
            }

            public FRMLogCallout FRMLogCallout
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMLogCallout = MyProject.MyForms.Create__Instance__<FRMLogCallout>(this.m_FRMLogCallout);
                    return this.m_FRMLogCallout;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMLogCallout)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMLogCallout>(ref this.m_FRMLogCallout);
                }
            }

            public FRMLogin FRMLogin
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMLogin = MyProject.MyForms.Create__Instance__<FRMLogin>(this.m_FRMLogin);
                    return this.m_FRMLogin;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMLogin)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMLogin>(ref this.m_FRMLogin);
                }
            }

            public FRMMain FRMMain
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMMain = MyProject.MyForms.Create__Instance__<FRMMain>(this.m_FRMMain);
                    return this.m_FRMMain;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMMain)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMMain>(ref this.m_FRMMain);
                }
            }

            public FRMManager FRMManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMManager = MyProject.MyForms.Create__Instance__<FRMManager>(this.m_FRMManager);
                    return this.m_FRMManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMManager>(ref this.m_FRMManager);
                }
            }

            public FRMManualApp FRMManualApp
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMManualApp = MyProject.MyForms.Create__Instance__<FRMManualApp>(this.m_FRMManualApp);
                    return this.m_FRMManualApp;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMManualApp)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMManualApp>(ref this.m_FRMManualApp);
                }
            }

            public FRMMoveParts FRMMoveParts
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMMoveParts = MyProject.MyForms.Create__Instance__<FRMMoveParts>(this.m_FRMMoveParts);
                    return this.m_FRMMoveParts;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMMoveParts)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMMoveParts>(ref this.m_FRMMoveParts);
                }
            }

            public FRMNewPrice FRMNewPrice
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMNewPrice = MyProject.MyForms.Create__Instance__<FRMNewPrice>(this.m_FRMNewPrice);
                    return this.m_FRMNewPrice;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMNewPrice)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMNewPrice>(ref this.m_FRMNewPrice);
                }
            }

            public FRMNotes FRMNotes
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMNotes = MyProject.MyForms.Create__Instance__<FRMNotes>(this.m_FRMNotes);
                    return this.m_FRMNotes;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMNotes)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMNotes>(ref this.m_FRMNotes);
                }
            }

            public FRMOrder FRMOrder
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMOrder = MyProject.MyForms.Create__Instance__<FRMOrder>(this.m_FRMOrder);
                    return this.m_FRMOrder;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMOrder)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMOrder>(ref this.m_FRMOrder);
                }
            }

            public FRMOrderCharges FRMOrderCharges
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMOrderCharges = MyProject.MyForms.Create__Instance__<FRMOrderCharges>(this.m_FRMOrderCharges);
                    return this.m_FRMOrderCharges;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMOrderCharges)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMOrderCharges>(ref this.m_FRMOrderCharges);
                }
            }

            public FRMOrderManager FRMOrderManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMOrderManager = MyProject.MyForms.Create__Instance__<FRMOrderManager>(this.m_FRMOrderManager);
                    return this.m_FRMOrderManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMOrderManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMOrderManager>(ref this.m_FRMOrderManager);
                }
            }

            public FRMOrderRejection FRMOrderRejection
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMOrderRejection = MyProject.MyForms.Create__Instance__<FRMOrderRejection>(this.m_FRMOrderRejection);
                    return this.m_FRMOrderRejection;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMOrderRejection)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMOrderRejection>(ref this.m_FRMOrderRejection);
                }
            }

            public FrmOverride FrmOverride
            {
                [DebuggerHidden]
                get
                {
                    this.m_FrmOverride = MyProject.MyForms.Create__Instance__<FrmOverride>(this.m_FrmOverride);
                    return this.m_FrmOverride;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FrmOverride)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FrmOverride>(ref this.m_FrmOverride);
                }
            }

            public FRMPaidBy FRMPaidBy
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPaidBy = MyProject.MyForms.Create__Instance__<FRMPaidBy>(this.m_FRMPaidBy);
                    return this.m_FRMPaidBy;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPaidBy)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPaidBy>(ref this.m_FRMPaidBy);
                }
            }

            public FRMPart FRMPart
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPart = MyProject.MyForms.Create__Instance__<FRMPart>(this.m_FRMPart);
                    return this.m_FRMPart;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPart)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPart>(ref this.m_FRMPart);
                }
            }

            public FRMPartCategories FRMPartCategories
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartCategories = MyProject.MyForms.Create__Instance__<FRMPartCategories>(this.m_FRMPartCategories);
                    return this.m_FRMPartCategories;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartCategories)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartCategories>(ref this.m_FRMPartCategories);
                }
            }

            public FRMPartPack FRMPartPack
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartPack = MyProject.MyForms.Create__Instance__<FRMPartPack>(this.m_FRMPartPack);
                    return this.m_FRMPartPack;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartPack)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartPack>(ref this.m_FRMPartPack);
                }
            }

            public FRMPartSelectLocation FRMPartSelectLocation
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartSelectLocation = MyProject.MyForms.Create__Instance__<FRMPartSelectLocation>(this.m_FRMPartSelectLocation);
                    return this.m_FRMPartSelectLocation;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartSelectLocation)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartSelectLocation>(ref this.m_FRMPartSelectLocation);
                }
            }

            public FRMPartsImport FRMPartsImport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartsImport = MyProject.MyForms.Create__Instance__<FRMPartsImport>(this.m_FRMPartsImport);
                    return this.m_FRMPartsImport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartsImport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartsImport>(ref this.m_FRMPartsImport);
                }
            }

            public FRMPartsInvoiceImport FRMPartsInvoiceImport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartsInvoiceImport = MyProject.MyForms.Create__Instance__<FRMPartsInvoiceImport>(this.m_FRMPartsInvoiceImport);
                    return this.m_FRMPartsInvoiceImport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartsInvoiceImport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartsInvoiceImport>(ref this.m_FRMPartsInvoiceImport);
                }
            }

            public FRMPartsToBeCredited FRMPartsToBeCredited
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartsToBeCredited = MyProject.MyForms.Create__Instance__<FRMPartsToBeCredited>(this.m_FRMPartsToBeCredited);
                    return this.m_FRMPartsToBeCredited;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartsToBeCredited)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartsToBeCredited>(ref this.m_FRMPartsToBeCredited);
                }
            }

            public FRMPartsToBeCreditedManager FRMPartsToBeCreditedManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartsToBeCreditedManager = MyProject.MyForms.Create__Instance__<FRMPartsToBeCreditedManager>(this.m_FRMPartsToBeCreditedManager);
                    return this.m_FRMPartsToBeCreditedManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartsToBeCreditedManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartsToBeCreditedManager>(ref this.m_FRMPartsToBeCreditedManager);
                }
            }

            public FRMPartSupplier FRMPartSupplier
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartSupplier = MyProject.MyForms.Create__Instance__<FRMPartSupplier>(this.m_FRMPartSupplier);
                    return this.m_FRMPartSupplier;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartSupplier)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartSupplier>(ref this.m_FRMPartSupplier);
                }
            }

            public FRMPartsUsed FRMPartsUsed
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPartsUsed = MyProject.MyForms.Create__Instance__<FRMPartsUsed>(this.m_FRMPartsUsed);
                    return this.m_FRMPartsUsed;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPartsUsed)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPartsUsed>(ref this.m_FRMPartsUsed);
                }
            }

            public FRMPickDespatchDetails FRMPickDespatchDetails
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPickDespatchDetails = MyProject.MyForms.Create__Instance__<FRMPickDespatchDetails>(this.m_FRMPickDespatchDetails);
                    return this.m_FRMPickDespatchDetails;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPickDespatchDetails)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPickDespatchDetails>(ref this.m_FRMPickDespatchDetails);
                }
            }

            public FRMPOInvoiceAuthorisation FRMPOInvoiceAuthorisation
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPOInvoiceAuthorisation = MyProject.MyForms.Create__Instance__<FRMPOInvoiceAuthorisation>(this.m_FRMPOInvoiceAuthorisation);
                    return this.m_FRMPOInvoiceAuthorisation;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPOInvoiceAuthorisation)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPOInvoiceAuthorisation>(ref this.m_FRMPOInvoiceAuthorisation);
                }
            }

            public FRMPOInvoiceAuthReasons FRMPOInvoiceAuthReasons
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPOInvoiceAuthReasons = MyProject.MyForms.Create__Instance__<FRMPOInvoiceAuthReasons>(this.m_FRMPOInvoiceAuthReasons);
                    return this.m_FRMPOInvoiceAuthReasons;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPOInvoiceAuthReasons)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPOInvoiceAuthReasons>(ref this.m_FRMPOInvoiceAuthReasons);
                }
            }

            public FRMPOInvoiceIncludedItems FRMPOInvoiceIncludedItems
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPOInvoiceIncludedItems = MyProject.MyForms.Create__Instance__<FRMPOInvoiceIncludedItems>(this.m_FRMPOInvoiceIncludedItems);
                    return this.m_FRMPOInvoiceIncludedItems;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPOInvoiceIncludedItems)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPOInvoiceIncludedItems>(ref this.m_FRMPOInvoiceIncludedItems);
                }
            }

            public FRMPostcodeManager FRMPostcodeManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPostcodeManager = MyProject.MyForms.Create__Instance__<FRMPostcodeManager>(this.m_FRMPostcodeManager);
                    return this.m_FRMPostcodeManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPostcodeManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPostcodeManager>(ref this.m_FRMPostcodeManager);
                }
            }

            public FRMPrivNotes FRMPrivNotes
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMPrivNotes = MyProject.MyForms.Create__Instance__<FRMPrivNotes>(this.m_FRMPrivNotes);
                    return this.m_FRMPrivNotes;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMPrivNotes)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMPrivNotes>(ref this.m_FRMPrivNotes);
                }
            }

            public FRMProduct FRMProduct
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMProduct = MyProject.MyForms.Create__Instance__<FRMProduct>(this.m_FRMProduct);
                    return this.m_FRMProduct;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMProduct)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMProduct>(ref this.m_FRMProduct);
                }
            }

            public FRMProductSupplier FRMProductSupplier
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMProductSupplier = MyProject.MyForms.Create__Instance__<FRMProductSupplier>(this.m_FRMProductSupplier);
                    return this.m_FRMProductSupplier;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMProductSupplier)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMProductSupplier>(ref this.m_FRMProductSupplier);
                }
            }

            public FRMQuoteContractAlternativeConvert FRMQuoteContractAlternativeConvert
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteContractAlternativeConvert = MyProject.MyForms.Create__Instance__<FRMQuoteContractAlternativeConvert>(this.m_FRMQuoteContractAlternativeConvert);
                    return this.m_FRMQuoteContractAlternativeConvert;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteContractAlternativeConvert)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteContractAlternativeConvert>(ref this.m_FRMQuoteContractAlternativeConvert);
                }
            }

            public FRMQuoteContractAlternativeSite FRMQuoteContractAlternativeSite
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteContractAlternativeSite = MyProject.MyForms.Create__Instance__<FRMQuoteContractAlternativeSite>(this.m_FRMQuoteContractAlternativeSite);
                    return this.m_FRMQuoteContractAlternativeSite;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteContractAlternativeSite)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteContractAlternativeSite>(ref this.m_FRMQuoteContractAlternativeSite);
                }
            }

            public FRMQuoteContractOption3 FRMQuoteContractOption3
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteContractOption3 = MyProject.MyForms.Create__Instance__<FRMQuoteContractOption3>(this.m_FRMQuoteContractOption3);
                    return this.m_FRMQuoteContractOption3;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteContractOption3)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteContractOption3>(ref this.m_FRMQuoteContractOption3);
                }
            }

            public FRMQuoteContractOption3Convert FRMQuoteContractOption3Convert
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteContractOption3Convert = MyProject.MyForms.Create__Instance__<FRMQuoteContractOption3Convert>(this.m_FRMQuoteContractOption3Convert);
                    return this.m_FRMQuoteContractOption3Convert;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteContractOption3Convert)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteContractOption3Convert>(ref this.m_FRMQuoteContractOption3Convert);
                }
            }

            public FRMQuoteContractOption3Site FRMQuoteContractOption3Site
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteContractOption3Site = MyProject.MyForms.Create__Instance__<FRMQuoteContractOption3Site>(this.m_FRMQuoteContractOption3Site);
                    return this.m_FRMQuoteContractOption3Site;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteContractOption3Site)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteContractOption3Site>(ref this.m_FRMQuoteContractOption3Site);
                }
            }

            public FRMQuoteJob FRMQuoteJob
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteJob = MyProject.MyForms.Create__Instance__<FRMQuoteJob>(this.m_FRMQuoteJob);
                    return this.m_FRMQuoteJob;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteJob)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteJob>(ref this.m_FRMQuoteJob);
                }
            }

            public FRMQuoteJobItemAssets FRMQuoteJobItemAssets
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteJobItemAssets = MyProject.MyForms.Create__Instance__<FRMQuoteJobItemAssets>(this.m_FRMQuoteJobItemAssets);
                    return this.m_FRMQuoteJobItemAssets;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteJobItemAssets)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteJobItemAssets>(ref this.m_FRMQuoteJobItemAssets);
                }
            }

            public FRMQuoteJobSelectASite FRMQuoteJobSelectASite
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteJobSelectASite = MyProject.MyForms.Create__Instance__<FRMQuoteJobSelectASite>(this.m_FRMQuoteJobSelectASite);
                    return this.m_FRMQuoteJobSelectASite;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteJobSelectASite)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteJobSelectASite>(ref this.m_FRMQuoteJobSelectASite);
                }
            }

            public FRMQuoteManager FRMQuoteManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteManager = MyProject.MyForms.Create__Instance__<FRMQuoteManager>(this.m_FRMQuoteManager);
                    return this.m_FRMQuoteManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteManager>(ref this.m_FRMQuoteManager);
                }
            }

            public FRMQuoteRejection FRMQuoteRejection
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMQuoteRejection = MyProject.MyForms.Create__Instance__<FRMQuoteRejection>(this.m_FRMQuoteRejection);
                    return this.m_FRMQuoteRejection;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMQuoteRejection)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMQuoteRejection>(ref this.m_FRMQuoteRejection);
                }
            }

            public FrmRaiseInvoiceDetails FrmRaiseInvoiceDetails
            {
                [DebuggerHidden]
                get
                {
                    this.m_FrmRaiseInvoiceDetails = MyProject.MyForms.Create__Instance__<FrmRaiseInvoiceDetails>(this.m_FrmRaiseInvoiceDetails);
                    return this.m_FrmRaiseInvoiceDetails;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FrmRaiseInvoiceDetails)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FrmRaiseInvoiceDetails>(ref this.m_FrmRaiseInvoiceDetails);
                }
            }

            public FRMReceiveStock FRMReceiveStock
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMReceiveStock = MyProject.MyForms.Create__Instance__<FRMReceiveStock>(this.m_FRMReceiveStock);
                    return this.m_FRMReceiveStock;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMReceiveStock)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMReceiveStock>(ref this.m_FRMReceiveStock);
                }
            }

            public FRMReleaseNotes FRMReleaseNotes
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMReleaseNotes = MyProject.MyForms.Create__Instance__<FRMReleaseNotes>(this.m_FRMReleaseNotes);
                    return this.m_FRMReleaseNotes;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMReleaseNotes)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMReleaseNotes>(ref this.m_FRMReleaseNotes);
                }
            }

            public FRMSchedulerFind FRMSchedulerFind
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSchedulerFind = MyProject.MyForms.Create__Instance__<FRMSchedulerFind>(this.m_FRMSchedulerFind);
                    return this.m_FRMSchedulerFind;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSchedulerFind)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSchedulerFind>(ref this.m_FRMSchedulerFind);
                }
            }

            public frmSchedulerMain frmSchedulerMain
            {
                [DebuggerHidden]
                get
                {
                    this.m_frmSchedulerMain = MyProject.MyForms.Create__Instance__<frmSchedulerMain>(this.m_frmSchedulerMain);
                    return this.m_frmSchedulerMain;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_frmSchedulerMain)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmSchedulerMain>(ref this.m_frmSchedulerMain);
                }
            }

            public FRMSchedulerSettings FRMSchedulerSettings
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSchedulerSettings = MyProject.MyForms.Create__Instance__<FRMSchedulerSettings>(this.m_FRMSchedulerSettings);
                    return this.m_FRMSchedulerSettings;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSchedulerSettings)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSchedulerSettings>(ref this.m_FRMSchedulerSettings);
                }
            }

            public FRMSelectAMonth FRMSelectAMonth
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSelectAMonth = MyProject.MyForms.Create__Instance__<FRMSelectAMonth>(this.m_FRMSelectAMonth);
                    return this.m_FRMSelectAMonth;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSelectAMonth)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSelectAMonth>(ref this.m_FRMSelectAMonth);
                }
            }

            public FRMSelectAsset FRMSelectAsset
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSelectAsset = MyProject.MyForms.Create__Instance__<FRMSelectAsset>(this.m_FRMSelectAsset);
                    return this.m_FRMSelectAsset;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSelectAsset)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSelectAsset>(ref this.m_FRMSelectAsset);
                }
            }

            public FRMSelectLocation FRMSelectLocation
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSelectLocation = MyProject.MyForms.Create__Instance__<FRMSelectLocation>(this.m_FRMSelectLocation);
                    return this.m_FRMSelectLocation;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSelectLocation)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSelectLocation>(ref this.m_FRMSelectLocation);
                }
            }

            public FRMSite FRMSite
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSite = MyProject.MyForms.Create__Instance__<FRMSite>(this.m_FRMSite);
                    return this.m_FRMSite;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSite)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSite>(ref this.m_FRMSite);
                }
            }

            public FRMSiteCustomerAudit FRMSiteCustomerAudit
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSiteCustomerAudit = MyProject.MyForms.Create__Instance__<FRMSiteCustomerAudit>(this.m_FRMSiteCustomerAudit);
                    return this.m_FRMSiteCustomerAudit;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSiteCustomerAudit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSiteCustomerAudit>(ref this.m_FRMSiteCustomerAudit);
                }
            }

            public FRMSiteLetterList FRMSiteLetterList
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSiteLetterList = MyProject.MyForms.Create__Instance__<FRMSiteLetterList>(this.m_FRMSiteLetterList);
                    return this.m_FRMSiteLetterList;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSiteLetterList)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSiteLetterList>(ref this.m_FRMSiteLetterList);
                }
            }

            public FRMSitePopup FRMSitePopup
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSitePopup = MyProject.MyForms.Create__Instance__<FRMSitePopup>(this.m_FRMSitePopup);
                    return this.m_FRMSitePopup;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSitePopup)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSitePopup>(ref this.m_FRMSitePopup);
                }
            }

            public FRMSiteVisitManager FRMSiteVisitManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSiteVisitManager = MyProject.MyForms.Create__Instance__<FRMSiteVisitManager>(this.m_FRMSiteVisitManager);
                    return this.m_FRMSiteVisitManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSiteVisitManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSiteVisitManager>(ref this.m_FRMSiteVisitManager);
                }
            }

            public FRMSmokeComo FRMSmokeComo
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSmokeComo = MyProject.MyForms.Create__Instance__<FRMSmokeComo>(this.m_FRMSmokeComo);
                    return this.m_FRMSmokeComo;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSmokeComo)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSmokeComo>(ref this.m_FRMSmokeComo);
                }
            }

            public FRMStandardSentences FRMStandardSentences
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStandardSentences = MyProject.MyForms.Create__Instance__<FRMStandardSentences>(this.m_FRMStandardSentences);
                    return this.m_FRMStandardSentences;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStandardSentences)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStandardSentences>(ref this.m_FRMStandardSentences);
                }
            }

            public FRMStockCategoryValuation FRMStockCategoryValuation
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStockCategoryValuation = MyProject.MyForms.Create__Instance__<FRMStockCategoryValuation>(this.m_FRMStockCategoryValuation);
                    return this.m_FRMStockCategoryValuation;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStockCategoryValuation)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStockCategoryValuation>(ref this.m_FRMStockCategoryValuation);
                }
            }

            public FRMStockMove FRMStockMove
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStockMove = MyProject.MyForms.Create__Instance__<FRMStockMove>(this.m_FRMStockMove);
                    return this.m_FRMStockMove;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStockMove)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStockMove>(ref this.m_FRMStockMove);
                }
            }

            public FRMStockMoved FRMStockMoved
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStockMoved = MyProject.MyForms.Create__Instance__<FRMStockMoved>(this.m_FRMStockMoved);
                    return this.m_FRMStockMoved;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStockMoved)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStockMoved>(ref this.m_FRMStockMoved);
                }
            }

            public FRMStockReplenishment FRMStockReplenishment
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStockReplenishment = MyProject.MyForms.Create__Instance__<FRMStockReplenishment>(this.m_FRMStockReplenishment);
                    return this.m_FRMStockReplenishment;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStockReplenishment)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStockReplenishment>(ref this.m_FRMStockReplenishment);
                }
            }

            public FRMStockTake FRMStockTake
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStockTake = MyProject.MyForms.Create__Instance__<FRMStockTake>(this.m_FRMStockTake);
                    return this.m_FRMStockTake;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStockTake)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStockTake>(ref this.m_FRMStockTake);
                }
            }

            public FRMStockUsed FRMStockUsed
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStockUsed = MyProject.MyForms.Create__Instance__<FRMStockUsed>(this.m_FRMStockUsed);
                    return this.m_FRMStockUsed;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStockUsed)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStockUsed>(ref this.m_FRMStockUsed);
                }
            }

            public FRMStockValuation FRMStockValuation
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMStockValuation = MyProject.MyForms.Create__Instance__<FRMStockValuation>(this.m_FRMStockValuation);
                    return this.m_FRMStockValuation;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMStockValuation)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMStockValuation>(ref this.m_FRMStockValuation);
                }
            }

            public FRMSubcontractor FRMSubcontractor
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSubcontractor = MyProject.MyForms.Create__Instance__<FRMSubcontractor>(this.m_FRMSubcontractor);
                    return this.m_FRMSubcontractor;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSubcontractor)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSubcontractor>(ref this.m_FRMSubcontractor);
                }
            }

            public FRMSupplier FRMSupplier
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSupplier = MyProject.MyForms.Create__Instance__<FRMSupplier>(this.m_FRMSupplier);
                    return this.m_FRMSupplier;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSupplier)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSupplier>(ref this.m_FRMSupplier);
                }
            }

            public FRMSupplierInvoiceImporter FRMSupplierInvoiceImporter
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSupplierInvoiceImporter = MyProject.MyForms.Create__Instance__<FRMSupplierInvoiceImporter>(this.m_FRMSupplierInvoiceImporter);
                    return this.m_FRMSupplierInvoiceImporter;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSupplierInvoiceImporter)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSupplierInvoiceImporter>(ref this.m_FRMSupplierInvoiceImporter);
                }
            }

            public FRMSupport FRMSupport
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSupport = MyProject.MyForms.Create__Instance__<FRMSupport>(this.m_FRMSupport);
                    return this.m_FRMSupport;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSupport)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSupport>(ref this.m_FRMSupport);
                }
            }

            public FRMSystemScheduleOfRate FRMSystemScheduleOfRate
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMSystemScheduleOfRate = MyProject.MyForms.Create__Instance__<FRMSystemScheduleOfRate>(this.m_FRMSystemScheduleOfRate);
                    return this.m_FRMSystemScheduleOfRate;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMSystemScheduleOfRate)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMSystemScheduleOfRate>(ref this.m_FRMSystemScheduleOfRate);
                }
            }

            public FRMTimeSlotRates FRMTimeSlotRates
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMTimeSlotRates = MyProject.MyForms.Create__Instance__<FRMTimeSlotRates>(this.m_FRMTimeSlotRates);
                    return this.m_FRMTimeSlotRates;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMTimeSlotRates)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMTimeSlotRates>(ref this.m_FRMTimeSlotRates);
                }
            }

            public FRMTypeMakeModel FRMTypeMakeModel
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMTypeMakeModel = MyProject.MyForms.Create__Instance__<FRMTypeMakeModel>(this.m_FRMTypeMakeModel);
                    return this.m_FRMTypeMakeModel;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMTypeMakeModel)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMTypeMakeModel>(ref this.m_FRMTypeMakeModel);
                }
            }

            public FRMUserQualification FRMUserQualification
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMUserQualification = MyProject.MyForms.Create__Instance__<FRMUserQualification>(this.m_FRMUserQualification);
                    return this.m_FRMUserQualification;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMUserQualification)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMUserQualification>(ref this.m_FRMUserQualification);
                }
            }

            public FRMUsers FRMUsers
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMUsers = MyProject.MyForms.Create__Instance__<FRMUsers>(this.m_FRMUsers);
                    return this.m_FRMUsers;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMUsers)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMUsers>(ref this.m_FRMUsers);
                }
            }

            public FRMVan FRMVan
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMVan = MyProject.MyForms.Create__Instance__<FRMVan>(this.m_FRMVan);
                    return this.m_FRMVan;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMVan)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMVan>(ref this.m_FRMVan);
                }
            }

            public FRMVanHistory FRMVanHistory
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMVanHistory = MyProject.MyForms.Create__Instance__<FRMVanHistory>(this.m_FRMVanHistory);
                    return this.m_FRMVanHistory;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMVanHistory)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMVanHistory>(ref this.m_FRMVanHistory);
                }
            }

            public FRMVATRates FRMVATRates
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMVATRates = MyProject.MyForms.Create__Instance__<FRMVATRates>(this.m_FRMVATRates);
                    return this.m_FRMVATRates;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMVATRates)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMVATRates>(ref this.m_FRMVATRates);
                }
            }

            public FRMViewContractAlternativeChargeDetails FRMViewContractAlternativeChargeDetails
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMViewContractAlternativeChargeDetails = MyProject.MyForms.Create__Instance__<FRMViewContractAlternativeChargeDetails>(this.m_FRMViewContractAlternativeChargeDetails);
                    return this.m_FRMViewContractAlternativeChargeDetails;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMViewContractAlternativeChargeDetails)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMViewContractAlternativeChargeDetails>(ref this.m_FRMViewContractAlternativeChargeDetails);
                }
            }

            public FRMVisitManager FRMVisitManager
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMVisitManager = MyProject.MyForms.Create__Instance__<FRMVisitManager>(this.m_FRMVisitManager);
                    return this.m_FRMVisitManager;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMVisitManager)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMVisitManager>(ref this.m_FRMVisitManager);
                }
            }

            public FRMWarehouse FRMWarehouse
            {
                [DebuggerHidden]
                get
                {
                    this.m_FRMWarehouse = MyProject.MyForms.Create__Instance__<FRMWarehouse>(this.m_FRMWarehouse);
                    return this.m_FRMWarehouse;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_FRMWarehouse)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<FRMWarehouse>(ref this.m_FRMWarehouse);
                }
            }

            public TabletOrder TabletOrder
            {
                [DebuggerHidden]
                get
                {
                    this.m_TabletOrder = MyProject.MyForms.Create__Instance__<TabletOrder>(this.m_TabletOrder);
                    return this.m_TabletOrder;
                }
                [DebuggerHidden]
                set
                {
                    if (value == this.m_TabletOrder)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<TabletOrder>(ref this.m_TabletOrder);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
        internal sealed class MyWebServices
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DebuggerHidden]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DebuggerHidden]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DebuggerHidden]
            internal new System.Type GetType()
            {
                return typeof(MyProject.MyWebServices);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DebuggerHidden]
            public override string ToString()
            {
                return base.ToString();
            }

            [DebuggerHidden]
            private static T Create__Instance__<T>(T instance) where T : new()
            {
                return (object)instance == null ? new T() : instance;
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance)
            {
                instance = default(T);
            }

            [DebuggerHidden]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public MyWebServices()
            {
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComVisible(false)]
        internal sealed class ThreadSafeObjectProvider<T> where T : new()
        {
            internal T GetInstance
            {
                [DebuggerHidden]
                get
                {
                    if ((object)MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
                        MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = new T();
                    return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
                }
            }

            [DebuggerHidden]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ThreadSafeObjectProvider()
            {
            }
        }
    }
}