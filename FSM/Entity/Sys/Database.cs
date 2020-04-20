// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.Database
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Accounts;
using FSM.Entity.Appointments;
using FSM.Entity.Areas;
using FSM.Entity.Assets;
using FSM.Entity.Authority;
using FSM.Entity.CheckLists;
using FSM.Entity.CompanyDetails;
using FSM.Entity.ContactAttempts;
using FSM.Entity.Contacts;
using FSM.Entity.ContractAlternativePPMVisits;
using FSM.Entity.ContractAlternativeSiteAssets;
using FSM.Entity.ContractAlternativeSiteJobItems;
using FSM.Entity.ContractAlternativeSiteJobOfWorks;
using FSM.Entity.ContractAlternativeSites;
using FSM.Entity.ContractManager;
using FSM.Entity.ContractOption3s;
using FSM.Entity.ContractOption3SiteAsset;
using FSM.Entity.ContractOption3SitePPMVisits;
using FSM.Entity.ContractOption3Sites;
using FSM.Entity.ContractOriginalPPMVisits;
using FSM.Entity.ContractOriginalSiteAssets;
using FSM.Entity.ContractOriginalSiteRatess;
using FSM.Entity.ContractOriginalSites;
using FSM.Entity.ContractOriginalVisits;
using FSM.Entity.ContractsAlternative;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.CostCentres;
using FSM.Entity.CostCentres.LinkTypes;
using FSM.Entity.CustomerCharges;
using FSM.Entity.CustomerOrders;
using FSM.Entity.Customers;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.Documentss;
using FSM.Entity.EngineerAbsence;
using FSM.Entity.EngineerLevels;
using FSM.Entity.EngineerPostalRegions;
using FSM.Entity.EngineerRoles;
using FSM.Entity.Engineers;
using FSM.Entity.Engineers.SiteSafetyAudits;
using FSM.Entity.EngineerTimeSheets;
using FSM.Entity.EngineerVans;
using FSM.Entity.EngineerVisitAdditionals;
using FSM.Entity.EngineerVisitAssetWorkSheets;
using FSM.Entity.EngineerVisitCharges;
using FSM.Entity.EngineerVisitDefectss;
using FSM.Entity.EngineerVisitNCCGSRs;
using FSM.Entity.EngineerVisitOrders;
using FSM.Entity.EngineerVisitPartProductAllocateds;
using FSM.Entity.EngineerVisitPhotos;
using FSM.Entity.EngineerVisitQCs;
using FSM.Entity.EngineerVisits;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers;
using FSM.Entity.EngineerVisitsPartsAndProducts;
using FSM.Entity.EngineerVisitTimeSheets;
using FSM.Entity.FleetVans;
using FSM.Entity.Ibc;
using FSM.Entity.InvoiceAddresss;
using FSM.Entity.InvoicedLiness;
using FSM.Entity.Invoiceds;
using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.JobAssets;
using FSM.Entity.JobAudits;
using FSM.Entity.JobContacts;
using FSM.Entity.JobImport;
using FSM.Entity.JobInstalls;
using FSM.Entity.JobItems;
using FSM.Entity.JobLock;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.LetterManager;
using FSM.Entity.Locationss;
using FSM.Entity.Management;
using FSM.Entity.MaxEngineerTimes;
using FSM.Entity.Notes;
using FSM.Entity.OrderCharges;
using FSM.Entity.OrderConsolidations;
using FSM.Entity.OrderLocationPart;
using FSM.Entity.OrderLocationProduct;
using FSM.Entity.OrderLocations;
using FSM.Entity.OrderParts;
using FSM.Entity.OrderProducts;
using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.PartSupplierPriceRequests;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.PickLists;
using FSM.Entity.ProductAssociatedParts;
using FSM.Entity.Products;
using FSM.Entity.ProductSupplierPriceRequests;
using FSM.Entity.ProductSuppliers;
using FSM.Entity.ProductTransactions;
using FSM.Entity.QuoteContractAlternativePPMVisits;
using FSM.Entity.QuoteContractAlternatives;
using FSM.Entity.QuoteContractAlternativeSiteAssets;
using FSM.Entity.QuoteContractAlternativeSiteJobItems;
using FSM.Entity.QuoteContractAlternativeSiteJobOfWorks;
using FSM.Entity.QuoteContractAlternativeSites;
using FSM.Entity.QuoteContractOption3s;
using FSM.Entity.QuoteContractOption3SiteAssetDurations;
using FSM.Entity.QuoteContractOption3Sites;
using FSM.Entity.QuoteContractOriginalPPMVisits;
using FSM.Entity.QuoteContractOriginals;
using FSM.Entity.QuoteContractOriginalSiteAssets;
using FSM.Entity.QuoteContractOriginalSites;
using FSM.Entity.QuoteEngineerVisits;
using FSM.Entity.QuoteJobAssets;
using FSM.Entity.QuoteJobItems;
using FSM.Entity.QuoteJobOfWorks;
using FSM.Entity.QuoteJobPartss;
using FSM.Entity.QuoteJobProductss;
using FSM.Entity.QuoteJobs;
using FSM.Entity.QuoteOrderParts;
using FSM.Entity.QuoteOrderProducts;
using FSM.Entity.QuoteOrders;
using FSM.Entity.Quotes;
using FSM.Entity.RagRating;
using FSM.Entity.Reports;
using FSM.Entity.SalesCredits;
using FSM.Entity.Scheduler;
using FSM.Entity.Sections;
using FSM.Entity.Settings.Scheduler;
using FSM.Entity.SiteCustomerAudits;
using FSM.Entity.SiteOrders;
using FSM.Entity.Sites;
using FSM.Entity.Skills;
using FSM.Entity.StandardSentences;
using FSM.Entity.Subcontractors;
using FSM.Entity.SubTasks;
using FSM.Entity.Suppliers;
using FSM.Entity.SystemScheduleOfRates;
using FSM.Entity.TabletOrders;
using FSM.Entity.Tasks;
using FSM.Entity.TimeSlotRates;
using FSM.Entity.UserAbsence;
using FSM.Entity.UserLevels;
using FSM.Entity.Users;
using FSM.Entity.Vans;
using FSM.Entity.Vans.Equipments;
using FSM.Entity.VATRatess;
using FSM.Entity.Warehouses;
using FSM.Importer.Validation;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
    public class Database
    {
        private SqlConnection _paggedQueryConnection;
        private object _serverConnection;
        private string _ServerConnectionString;
        private object _command;
        private object _adapter;
        public ManagerSQL Manager;
        public PickListSQL Picklists;
        public UserSQL User;
        public CustomerSQL Customer;
        public PartSQL Part;
        public ProductSQL Product;
        public SupplierSQL Supplier;
        public PartSupplierSQL PartSupplier;
        public ProductSupplierSQL ProductSupplier;
        public SiteSQL Sites;
        public EngineerSQL Engineer;
        public AssetSQL Asset;
        public VanSQL Van;
        public FleetSQL Fleet;
        public FleetVanSQL FleetVan;
        public FleetVanTypeSQL FleetVanType;
        public FleetVanEngineerSQL FleetVanEngineer;
        public FleetVanMaintenanceSQL FleetVanMaintenance;
        public FleetVanFaultSQL FleetVanFault;
        public FleetVanContractSQL FleetVanContract;
        public FleetVanServiceSQL FleetVanService;
        public FleetVanEquipmentSQL FleetVanEquipment;
        public FleetEquipmentSQL FleetEquipment;
        public EngineerLevelSQL EngineerLevel;
        public DocumentsSQL Documents;
        public ContactSQL Contact;
        public EngineerPostalRegionSQL EngineerPostalRegion;
        public OrderSQL Order;
        public SupplierInvoiceSQL SupplierInvoices;
        public OrderProductSQL OrderProduct;
        public OrderPartSQL OrderPart;
        public SiteOrderSQL SiteOrder;
        public InvoiceAddressSQL InvoiceAddress;
        public CustomerChargeSQL CustomerCharge;
        public SubcontractorSQL SubContractor;
        public AreaSQL Area;
        public SectionSQL Section;
        public SubTaskSQL SubTask;
        public TaskSQL Task;
        public JobSQL Job;
        public JobContactSQL JobContact;
        public JobAssetSQL JobAsset;
        public JobItemSQL JobItems;
        public JobOfWorkSQL JobOfWorks;
        public EngineerVisitSQL EngineerVisits;
        public QuotesSQL Quotes;
        public WarehouseSQL Warehouse;
        public PartTransactionSQL PartTransaction;
        public StockTakeAuditSQL StockTakeAudit;
        public ProductTransactionSQL ProductTransaction;
        public ProductSupplierPriceRequestSQL ProductPriceRequest;
        public PartSupplierPriceRequestSQL PartPriceRequest;
        public OrderLocationPartSQL OrderLocationPart;
        public OrderLocationProductSQL OrderLocationProduct;
        public LocationsSQL Location;
        public OrderLocationSQL OrderLocation;
        public QuoteJobsSQL QuoteJob;
        public QuoteJobAssetSQL QuoteJobAsset;
        public QuoteJobOfWorkSQL QuoteJobOfWorks;
        public QuoteJobItemSQL QuoteJobItems;
        public QuoteEngineerVisitSQL QuoteEngineerVisits;
        public EngineerVisitOrderSQL EngineerVisitOrder;
        public SchedulerSQL Scheduler;
        public OrderChargeSQL OrderCharge;
        public CustomerOrderSQL CustomerOrder;
        public QuoteOrderSQL QuoteOrder;
        public QuoteOrderPartSQL QuoteOrderPart;
        public QuoteOrderProductSQL QuoteOrderProduct;
        public QuoteJobPartsSQL QuoteJobParts;
        public QuoteJobProductsSQL QuoteJobProducts;
        public EngineerAbsenceSQL EngineerAbsence;
        public UserAbsenceSQL UserAbsence;
        public ContractOriginalSQL ContractOriginal;
        public ContractOriginalSiteSQL ContractOriginalSite;
        public ContractOriginalSiteAssetSQL ContractOriginalSiteAsset;
        public ContractOriginalPPMVisitSQL ContractOriginalPPMVisit;
        public QuoteContractOriginalPPMVisitSQL QuoteContractOriginalPPMVisits;
        public QuoteContractOriginalSiteSQL QuoteContractOriginalSite;
        public QuoteContractOriginalSiteAssetSQL QuoteContractOriginalSiteAsset;
        public QuoteContractOriginalSQL QuoteContractOriginal;
        public ContractAlternativeSQL ContractAlternative;
        public ContractAlternativeSiteSQL ContractAlternativeSite;
        public ContractAlternativeSiteAssetSQL ContractAlternativeSiteAsset;
        public ContractAlternativePPMVisitSQL ContractAlternativePPMVisit;
        public ContractAlternativeSiteJobItemsSQL ContractAlternativeSiteJobItems;
        public ContractAlternativeSiteJobOfWorkSQL ContractAlternativeSiteJobOfWork;
        public QuoteContractAlternativePPMVisitSQL QuoteContractAlternativePPMVisits;
        public QuoteContractAlternativeSiteSQL QuoteContractAlternativeSite;
        public QuoteContractAlternativeSiteAssetSQL QuoteContractAlternativeSiteAsset;
        public QuoteContractAlternativeSQL QuoteContractAlternative;
        public QuoteContractAlternativeSiteJobItemsSQL QuoteContractAlternativeSiteJobItems;
        public QuoteContractAlternativeSiteJobOfWorkSQL QuoteContractAlternativeSiteJobOfWork;
        public NotesSQL Notes;
        public CheckListSQL Checklists;
        public EngineerVisitPartsAndProductsSQL EngineerVisitsPartsAndProducts;
        public EngineerVisitTimeSheetSQL EngineerVisitsTimeSheet;
        public ProductAssociatedPartSQL ProductAssociatedPart;
        public SystemScheduleOfRateSQL SystemScheduleOfRate;
        public CustomerScheduleOfRateSQL CustomerScheduleOfRate;
        public EngineerVanSQL EngineerVan;
        public ContractOption3SQL ContractOption3;
        public ContractOption3SiteSQL ContractOption3Site;
        public ContractOption3AssetSQL ContractOption3SiteAsset;
        public ContractOption3SitePPMVisitSQL ContractOption3SitePPMVisit;
        public QuoteContractOption3SQL QuoteContractOption3;
        public QuoteContractOption3SiteSQL QuoteContractOption3Site;
        public QuoteContractOption3SiteAssetDurationSQL QuoteContractOption3SiteAssetDurations;
        public TimeSlotRatesSQL TimeSlotRates;
        public EngineerVisitChargeSQL EngineerVisitCharge;
        public JobAuditSQL JobAudit;
        public InvoiceToBeRaisedSQL InvoiceToBeRaised;
        public EngineerVisitPartProductAllocatedSQL EngineerVisitPartProductAllocated;
        public InvoicedSQL Invoiced;
        public InvoicedLinesSQL InvoicedLines;
        public ContractManagerSQL ContractManager;
        public SiteCustomerAuditSQL SiteCustomerAudit;
        public EngineerVisitDefectsSQL EngineerVisitDefects;
        public EngineerVisitAssetWorkSheetSQL EngineerVisitAssetWorkSheet;
        public VATRatesSQL VATRatesSQL;
        public StandardSentenceSQL StandardSentence;
        public EngineerVisitQCSQL EngineerVisitQCSQL;
        public JobInstallSQL JobInstallSQL;
        public JobLockSQL JobLock;
        public OrderConsolidationSQL OrderConsolidations;
        public MaxEngineerTimeSQL MaxEngineerTime;
        public ContractOriginalSiteRatesSQL ContractOriginalSiteRates;
        public PartsToBeCreditedSQL PartsToBeCredited;
        public SalesCreditSQL SalesCredit;
        public EngineerTimeSheetSQL EngineerTimesheets;
        public ValidationSQL ImportValidation;
        public LetterManagerSQL LetterManager;
        public EngineerVisitNCCGSRSQL EngineerVisitNCCGSR;
        public EngineerVisitAdditionalSQL EngineerVisitAdditional;
        public POInvoiceSQL POInvoice;
        public TabletOrderSQL TabletOrders;
        public ReportSQL Reports;
        public EngineerVisitPhotoSQL EngineerVisitPhotos;
        public ContractOriginalVisitSQL ContractVisits;
        public AppointmentsSQL Appointments;
        public JobImportSQL JobImports;
        public SunFinanceSQL SunFinance;
        public AuthoritySQL Authority;
        public SkillsSQL Skills;
        public UserLevelSQL UserLevels;
        public CostCentreSql CostCentre;
        public LinkTypeSql CostCentreLinkType;
        public EngineerVisitEngineerSql EvEngineer;
        public EquipmentSql VanEquipments;
        public IbcSql Ibc;
        public JobTypeColourSql JobTypeColour;
        public RagRatingSql RagRating;
        public SiteSafetyAuditSql SiteSafteyAudit;
        public EngineerRoleSql EngineerRole;
        public ContactAttemptSql ContactAttempts;
        public CustomerAlertSql CustomerAlert;
        public CompanyDetailsSql CompanyDetails;

        public Database()
        {
            this._paggedQueryConnection = (SqlConnection)null;
            this._serverConnection = (object)null;
            this._ServerConnectionString = "";
            this._command = (object)null;
            this._adapter = (object)null;
            switch (App.TheSystem.DataBaseServerType)
            {
                case Enums.DatabaseSystems.Microsoft_SQL_Server:
                    this.ServerConnection = (object)new SqlConnection(App.TheSystem.Configuration.ConnectionString);
                    this.ServerConnectionString = App.TheSystem.Configuration.ConnectionString;
                    this.Command = (object)new SqlCommand("", (SqlConnection)this.ServerConnection);
                    ((SqlCommand)this.Command).CommandTimeout = 400;
                    this.Adapter = (object)new SqlDataAdapter((SqlCommand)this.Command);
                    this.PaggedQueryConnection = new SqlConnection(App.TheSystem.Configuration.ConnectionString);
                    break;
            }
            this.Manager = new ManagerSQL(this);
            this.Picklists = new PickListSQL(this);
            this.User = new UserSQL(this);
            this.Customer = new CustomerSQL(this);
            this.Part = new PartSQL(this);
            this.Product = new ProductSQL(this);
            this.Supplier = new SupplierSQL(this);
            this.PartSupplier = new PartSupplierSQL(this);
            this.ProductSupplier = new ProductSupplierSQL(this);
            this.Sites = new SiteSQL(this);
            this.Engineer = new EngineerSQL(this);
            this.Asset = new AssetSQL(this);
            this.Van = new VanSQL(this);
            this.Fleet = new FleetSQL(this);
            this.FleetVan = new FleetVanSQL(this);
            this.FleetVanType = new FleetVanTypeSQL(this);
            this.FleetVanEngineer = new FleetVanEngineerSQL(this);
            this.FleetVanMaintenance = new FleetVanMaintenanceSQL(this);
            this.FleetVanFault = new FleetVanFaultSQL(this);
            this.FleetVanContract = new FleetVanContractSQL(this);
            this.FleetVanService = new FleetVanServiceSQL(this);
            this.FleetVanEquipment = new FleetVanEquipmentSQL(this);
            this.FleetEquipment = new FleetEquipmentSQL(this);
            this.EngineerLevel = new EngineerLevelSQL(this);
            this.Documents = new DocumentsSQL(this);
            this.Contact = new ContactSQL(this);
            this.EngineerPostalRegion = new EngineerPostalRegionSQL(this);
            this.Order = new OrderSQL(this);
            this.SupplierInvoices = new SupplierInvoiceSQL(this);
            this.OrderPart = new OrderPartSQL(this);
            this.OrderProduct = new OrderProductSQL(this);
            this.SiteOrder = new SiteOrderSQL(this);
            this.InvoiceAddress = new InvoiceAddressSQL(this);
            this.CustomerCharge = new CustomerChargeSQL(this);
            this.SubContractor = new SubcontractorSQL(this);
            this.Area = new AreaSQL(this);
            this.Section = new SectionSQL(this);
            this.SubTask = new SubTaskSQL(this);
            this.Task = new TaskSQL(this);
            this.Job = new JobSQL(this);
            this.JobContact = new JobContactSQL(this);
            this.JobAsset = new JobAssetSQL(this);
            this.JobItems = new JobItemSQL(this);
            this.JobOfWorks = new JobOfWorkSQL(this);
            this.EngineerVisits = new EngineerVisitSQL(this);
            this.Quotes = new QuotesSQL(this);
            this.Warehouse = new WarehouseSQL(this);
            this.PartTransaction = new PartTransactionSQL(this);
            this.StockTakeAudit = new StockTakeAuditSQL(this);
            this.ProductTransaction = new ProductTransactionSQL(this);
            this.OrderLocationPart = new OrderLocationPartSQL(this);
            this.OrderLocationProduct = new OrderLocationProductSQL(this);
            this.Location = new LocationsSQL(this);
            this.OrderLocation = new OrderLocationSQL(this);
            this.QuoteJob = new QuoteJobsSQL(this);
            this.QuoteJobAsset = new QuoteJobAssetSQL(this);
            this.QuoteJobOfWorks = new QuoteJobOfWorkSQL(this);
            this.QuoteJobItems = new QuoteJobItemSQL(this);
            this.QuoteEngineerVisits = new QuoteEngineerVisitSQL(this);
            this.ProductPriceRequest = new ProductSupplierPriceRequestSQL(this);
            this.PartPriceRequest = new PartSupplierPriceRequestSQL(this);
            this.EngineerVisitOrder = new EngineerVisitOrderSQL(this);
            this.Scheduler = new SchedulerSQL(this);
            this.OrderCharge = new OrderChargeSQL(this);
            this.CustomerOrder = new CustomerOrderSQL(this);
            this.QuoteOrder = new QuoteOrderSQL(this);
            this.QuoteOrderPart = new QuoteOrderPartSQL(this);
            this.QuoteOrderProduct = new QuoteOrderProductSQL(this);
            this.QuoteJobParts = new QuoteJobPartsSQL(this);
            this.QuoteJobProducts = new QuoteJobProductsSQL(this);
            this.EngineerAbsence = new EngineerAbsenceSQL(this);
            this.UserAbsence = new UserAbsenceSQL(this);
            this.ContractOriginal = new ContractOriginalSQL(this);
            this.ContractOriginalSite = new ContractOriginalSiteSQL(this);
            this.ContractOriginalSiteAsset = new ContractOriginalSiteAssetSQL(this);
            this.ContractOriginalPPMVisit = new ContractOriginalPPMVisitSQL(this);
            this.QuoteContractOriginal = new QuoteContractOriginalSQL(this);
            this.QuoteContractOriginalSite = new QuoteContractOriginalSiteSQL(this);
            this.QuoteContractOriginalSiteAsset = new QuoteContractOriginalSiteAssetSQL(this);
            this.QuoteContractOriginalPPMVisits = new QuoteContractOriginalPPMVisitSQL(this);
            this.ContractAlternative = new ContractAlternativeSQL(this);
            this.ContractAlternativeSite = new ContractAlternativeSiteSQL(this);
            this.ContractAlternativeSiteAsset = new ContractAlternativeSiteAssetSQL(this);
            this.ContractAlternativePPMVisit = new ContractAlternativePPMVisitSQL(this);
            this.ContractAlternativeSiteJobItems = new ContractAlternativeSiteJobItemsSQL(this);
            this.ContractAlternativeSiteJobOfWork = new ContractAlternativeSiteJobOfWorkSQL(this);
            this.QuoteContractAlternativePPMVisits = new QuoteContractAlternativePPMVisitSQL(this);
            this.QuoteContractAlternativeSite = new QuoteContractAlternativeSiteSQL(this);
            this.QuoteContractAlternativeSiteAsset = new QuoteContractAlternativeSiteAssetSQL(this);
            this.QuoteContractAlternative = new QuoteContractAlternativeSQL(this);
            this.QuoteContractAlternativeSiteJobItems = new QuoteContractAlternativeSiteJobItemsSQL(this);
            this.QuoteContractAlternativeSiteJobOfWork = new QuoteContractAlternativeSiteJobOfWorkSQL(this);
            this.Notes = new NotesSQL(this);
            this.Checklists = new CheckListSQL(this);
            this.EngineerVisitsPartsAndProducts = new EngineerVisitPartsAndProductsSQL(this);
            this.EngineerVisitsTimeSheet = new EngineerVisitTimeSheetSQL(this);
            this.ProductAssociatedPart = new ProductAssociatedPartSQL(this);
            this.SystemScheduleOfRate = new SystemScheduleOfRateSQL(this);
            this.CustomerScheduleOfRate = new CustomerScheduleOfRateSQL(this);
            this.EngineerVan = new EngineerVanSQL(this);
            this.ContractOption3 = new ContractOption3SQL(this);
            this.ContractOption3Site = new ContractOption3SiteSQL(this);
            this.ContractOption3SiteAsset = new ContractOption3AssetSQL(this);
            this.ContractOption3SitePPMVisit = new ContractOption3SitePPMVisitSQL(this);
            this.QuoteContractOption3 = new QuoteContractOption3SQL(this);
            this.QuoteContractOption3Site = new QuoteContractOption3SiteSQL(this);
            this.QuoteContractOption3SiteAssetDurations = new QuoteContractOption3SiteAssetDurationSQL(this);
            this.TimeSlotRates = new TimeSlotRatesSQL(this);
            this.EngineerVisitCharge = new EngineerVisitChargeSQL(this);
            this.JobAudit = new JobAuditSQL(this);
            this.InvoiceToBeRaised = new InvoiceToBeRaisedSQL(this);
            this.EngineerVisitPartProductAllocated = new EngineerVisitPartProductAllocatedSQL(this);
            this.Invoiced = new InvoicedSQL(this);
            this.InvoicedLines = new InvoicedLinesSQL(this);
            this.ContractManager = new ContractManagerSQL(this);
            this.SiteCustomerAudit = new SiteCustomerAuditSQL(this);
            this.EngineerVisitDefects = new EngineerVisitDefectsSQL(this);
            this.EngineerVisitAssetWorkSheet = new EngineerVisitAssetWorkSheetSQL(this);
            this.VATRatesSQL = new VATRatesSQL(this);
            this.StandardSentence = new StandardSentenceSQL(this);
            this.JobInstallSQL = new JobInstallSQL(this);
            this.EngineerVisitQCSQL = new EngineerVisitQCSQL(this);
            this.JobLock = new JobLockSQL(this);
            this.OrderConsolidations = new OrderConsolidationSQL(this);
            this.MaxEngineerTime = new MaxEngineerTimeSQL(this);
            this.ContractOriginalSiteRates = new ContractOriginalSiteRatesSQL(this);
            this.PartsToBeCredited = new PartsToBeCreditedSQL(this);
            this.SalesCredit = new SalesCreditSQL(this);
            this.EngineerTimesheets = new EngineerTimeSheetSQL(this);
            this.ImportValidation = new ValidationSQL(this);
            this.LetterManager = new LetterManagerSQL(this);
            this.EngineerVisitNCCGSR = new EngineerVisitNCCGSRSQL(this);
            this.EngineerVisitAdditional = new EngineerVisitAdditionalSQL(this);
            this.POInvoice = new POInvoiceSQL(this);
            this.TabletOrders = new TabletOrderSQL(this);
            this.Reports = new ReportSQL(this);
            this.EngineerVisitPhotos = new EngineerVisitPhotoSQL(this);
            this.ContractVisits = new ContractOriginalVisitSQL(this);
            this.Appointments = new AppointmentsSQL(this);
            this.JobImports = new JobImportSQL(this);
            this.SunFinance = new SunFinanceSQL(this);
            this.Authority = new AuthoritySQL(this);
            this.Skills = new SkillsSQL(this);
            this.UserLevels = new UserLevelSQL(this);
            this.CostCentre = new CostCentreSql(this);
            this.CostCentreLinkType = new LinkTypeSql(this);
            this.EvEngineer = new EngineerVisitEngineerSql(this);
            this.VanEquipments = new EquipmentSql(this);
            this.Ibc = new IbcSql(this);
            this.JobTypeColour = new JobTypeColourSql(this);
            this.RagRating = new RagRatingSql(this);
            this.SiteSafteyAudit = new SiteSafetyAuditSql(this);
            this.EngineerRole = new EngineerRoleSql(this);
            this.ContactAttempts = new ContactAttemptSql(this);
            this.CustomerAlert = new CustomerAlertSql(this);
            this.CompanyDetails = new CompanyDetailsSql(this);
        }

        private SqlConnection PaggedQueryConnection
        {
            get
            {
                return this._paggedQueryConnection;
            }
            set
            {
                this._paggedQueryConnection = value;
            }
        }

        private object ServerConnection
        {
            get
            {
                return this._serverConnection;
            }
            set
            {
                this._serverConnection = RuntimeHelpers.GetObjectValue(value);
            }
        }

        public string ServerConnectionString
        {
            get
            {
                return this._ServerConnectionString;
            }
            set
            {
                this._ServerConnectionString = value;
            }
        }

        private object Command
        {
            get
            {
                return this._command;
            }
            set
            {
                this._command = RuntimeHelpers.GetObjectValue(value);
            }
        }

        private object Adapter
        {
            get
            {
                return this._adapter;
            }
            set
            {
                this._adapter = RuntimeHelpers.GetObjectValue(value);
            }
        }

        private bool OpenConnection()
        {
            bool flag;
            try
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.ServerConnection, (System.Type)null, "State", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)ConnectionState.Closed, false))
                    NewLateBinding.LateCall(this.ServerConnection, (System.Type)null, "Open", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
                flag = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        private bool CloseConnection()
        {
            bool flag;
            try
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.ServerConnection, (System.Type)null, "State", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)ConnectionState.Open, false))
                    NewLateBinding.LateCall(this.ServerConnection, (System.Type)null, "Close", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
                flag = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        public void ClearParameter()
        {
            switch (App.TheSystem.DataBaseServerType)
            {
                case Enums.DatabaseSystems.Microsoft_SQL_Server:
                    ((SqlCommand)this.Command).Parameters.Clear();
                    break;
            }
        }

        public void AddParameter(string name, object value, bool valueAsItIsSent = false)
        {
            switch (App.TheSystem.DataBaseServerType)
            {
                case Enums.DatabaseSystems.MySQL:
                    string Left1 = name;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "?Operator", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "?SearchFilter", false) == 0)
                        break;
                    break;

                case Enums.DatabaseSystems.Microsoft_SQL_Server:
                    string Left2 = name;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "?Operator", false) != 0)
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "?SearchFilter", false) == 0)
                        {
                            ((SqlCommand)this.Command).Parameters.Add(name.Replace("?", "@"), RuntimeHelpers.GetObjectValue(value));
                            break;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name.ToUpper(), "@RETURN", false) == 0)
                        {
                            ((SqlCommand)this.Command).Parameters.Add(new SqlParameter("@RETURN", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.ReturnValue
                            });
                            break;
                        }
                        if (!valueAsItIsSent)
                            ((SqlCommand)this.Command).Parameters.Add(name.Replace("?", "@"), (object)Helper.CleanText(Conversions.ToString(value)));
                        else
                            ((SqlCommand)this.Command).Parameters.Add(name.Replace("?", "@"), RuntimeHelpers.GetObjectValue(value));
                        break;
                    }
                ((SqlCommand)this.Command).Parameters.Add(name.Replace("?", "@"), RuntimeHelpers.GetObjectValue(value));
                    break;
            }
        }

        public DataTable ExecuteCommand_DataTable(string fileName, bool recordInteraction = true)
        {
            NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
            {
        (object) Helper.GetTextResource(fileName)
            }, (string[])null, (System.Type[])null);
            return this.ExecuteWithReturn(this.BuildSQL(), recordInteraction);
        }

        public void ExecuteCommand_NO_Return(string fileName, bool recordInteraction = true)
        {
            NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
            {
        (object) Helper.GetTextResource(fileName)
            }, (string[])null, (System.Type[])null);
            this.ExecuteWithOutReturn(this.BuildSQL(), recordInteraction);
        }

        public object ExecuteCommand_Object(string fileName, bool recordInteraction = true)
        {
            NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
            {
        (object) Helper.GetTextResource(fileName)
            }, (string[])null, (System.Type[])null);
            return this.ExecuteScalar(this.BuildSQL(), recordInteraction, false);
        }

        public DataTable ExecuteSP_DataTable(string SPName, bool RecordTheInteraction = true)
        {
            DataTable dataTable1 = null;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) SPName
                    }, (string[])null, (System.Type[])null);
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.StoredProcedure
                    }, (string[])null, (System.Type[])null);
                    DataTable dataTable2 = new DataTable();
                    object[] objArray;
                    bool[] flagArray;
                    NewLateBinding.LateCall(this.Adapter, (System.Type)null, "Fill", objArray = new object[1]
                    {
            (object) dataTable2
                    }, (string[])null, (System.Type[])null, flagArray = new bool[1]
                    {
            true
                    }, true);
                    if (flagArray[0])
                        dataTable2 = (DataTable)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(DataTable));
                    if (RecordTheInteraction)
                        this.RecordInteraction(SPName);
                    dataTable1 = dataTable2;
                    goto label_13;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_13:
            return dataTable1;
        }

        public DataSet ExecuteSP_DataSet(string SPName, bool RecordTheInteraction = true)
        {
            DataSet dataSet1 = null;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) SPName
                    }, (string[])null, (System.Type[])null);
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.StoredProcedure
                    }, (string[])null, (System.Type[])null);
                    DataSet dataSet2 = new DataSet();
                    object[] objArray;
                    bool[] flagArray;
                    NewLateBinding.LateCall(this.Adapter, (System.Type)null, "Fill", objArray = new object[1]
                    {
            (object) dataSet2
                    }, (string[])null, (System.Type[])null, flagArray = new bool[1]
                    {
            true
                    }, true);
                    if (flagArray[0])
                        dataSet2 = (DataSet)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(DataSet));
                    if (RecordTheInteraction)
                        this.RecordInteraction(SPName);
                    dataSet1 = dataSet2;
                    goto label_13;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_13:
            return dataSet1;
        }

        public DataTable ExecuteSP_DataTable(string spName, params SqlParameter[] @params)
        {
            DataTable dataTable1;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) spName
                    }, (string[])null, (System.Type[])null);
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.StoredProcedure
                    }, (string[])null, (System.Type[])null);
                    NewLateBinding.LateCall(NewLateBinding.LateGet(this._command, (System.Type)null, "Parameters", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Clear", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
                    SqlParameter[] sqlParameterArray = @params;
                    int index = 0;
                    while (index < sqlParameterArray.Length)
                    {
                        SqlParameter sqlParameter1 = sqlParameterArray[index];
                        object[] objArray;
                        bool[] flagArray;
                        NewLateBinding.LateCall(NewLateBinding.LateGet(this._command, (System.Type)null, "Parameters", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Add", objArray = new object[1]
                        {
              (object) sqlParameter1
                        }, (string[])null, (System.Type[])null, flagArray = new bool[1]
                        {
              true
                        }, true);
                        if (flagArray[0])
                        {
                            SqlParameter sqlParameter2 = (SqlParameter)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(SqlParameter));
                        }
                        checked { ++index; }
                    }
                    DataTable dataTable2 = new DataTable();
                    object[] objArray1;
                    bool[] flagArray1;
                    NewLateBinding.LateCall(this.Adapter, (System.Type)null, "Fill", objArray1 = new object[1]
                    {
            (object) dataTable2
                    }, (string[])null, (System.Type[])null, flagArray1 = new bool[1]
                    {
            true
                    }, true);
                    if (flagArray1[0])
                        dataTable2 = (DataTable)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray1[0]), typeof(DataTable));
                    dataTable1 = dataTable2;
                    goto label_16;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_16:
            return dataTable1 = null;
        }

        public int ExecuteSP_ReturnRowsAffected(string SPName)
        {
            int integer = 0;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) SPName
                    }, (string[])null, (System.Type[])null);
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.StoredProcedure
                    }, (string[])null, (System.Type[])null);
                    integer = Conversions.ToInteger(NewLateBinding.LateGet(this._command, (System.Type)null, "ExecuteNonQuery", new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    goto label_9;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_9:
            return integer;
        }

        public DataTable ExecuteCommand_DataTable(SqlCommand Command)
        {
            DataTable dataTable1 = null;
            try
            {
                int num = 3;
                bool flag = false;
                DataTable dataTable2 = new DataTable();
                while (num > 0 & !flag)
                {
                    try
                    {
                        new SqlDataAdapter(Command).Fill(dataTable2);
                        flag = true;
                    }
                    catch (SqlException ex)
                    {
                        ProjectData.SetProjectError((Exception)ex);
                        if (ex.Number != 1205)
                        {
                            throw;
                        }
                        else
                        {
                            checked { --num; }
                            if (num == 0)
                                throw;
                            else
                                ProjectData.ClearProjectError();
                        }
                    }
                }
                dataTable1 = dataTable2;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            return dataTable1;
        }

        public void ExecuteSP_NO_Return(string SPName, bool RecordTheInteraction = true)
        {
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) SPName
                    }, (string[])null, (System.Type[])null);
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.StoredProcedure
                    }, (string[])null, (System.Type[])null);
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(SPName, "Parts_PreImportValidate", false) == 0)
                        ((SqlCommand)this.Command).CommandTimeout = 2000;
                    else
                        ((SqlCommand)this.Command).CommandTimeout = 400;
                    NewLateBinding.LateCall(this.Command, (System.Type)null, "Executenonquery", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
                    if (!RecordTheInteraction)
                        return;
                    this.RecordInteraction(SPName);
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public object ExecuteSP_OBJECT(string SPName, bool RecordTheInteraction = true)
        {
            object obj;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) SPName
                    }, (string[])null, (System.Type[])null);
                    NewLateBinding.LateSet(this._command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.StoredProcedure
                    }, (string[])null, (System.Type[])null);
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.Command, (System.Type)null, "ExecuteScalar", new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    if (RecordTheInteraction)
                        this.RecordInteraction(SPName);
                    NewLateBinding.LateCall(NewLateBinding.LateGet(this._command, (System.Type)null, "Parameters", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Clear", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
                    obj = objectValue;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    obj = (object)null;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                obj = (object)null;
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return obj;
        }

        private string BuildSQL()
        {
            string str = Conversions.ToString(NewLateBinding.LateGet(this._command, (System.Type)null, "CommandText", new object[0], (string[])null, (System.Type[])null, (bool[])null));

            if (((SqlCommand)this.Command).Parameters.Count > 0)
            {
                str = str.Replace("?", "@").Replace("`", "");
                foreach (SqlParameter current in ((SqlCommand)this.Command).Parameters)
                {
                    str = !Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current.Value, (object)"NULL", false))) ? str.Replace(current.ParameterName, "NULL") : (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.ParameterName, "@Operator", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.ParameterName, "@SearchFilter", false) != 0 ? str.Replace(current.ParameterName, Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)"'", current.Value), (object)"'"))) : str.Replace(current.ParameterName, Conversions.ToString(current.Value))) : str.Replace(current.ParameterName, Conversions.ToString(current.Value)));
                }
            }
            else
            {
            }

            return str;
        }

        public DataTable ExecuteWithReturn(string sql, bool RecordTheInteraction = true)
        {
            DataTable dataTable1 = null;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) sql
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.Text
                    }, (string[])null, (System.Type[])null, false, true);
                    DataTable dataTable2 = new DataTable();
                    object[] objArray;
                    bool[] flagArray;
                    NewLateBinding.LateCall(this.Adapter, (System.Type)null, "Fill", objArray = new object[1]
                    {
            (object) dataTable2
                    }, (string[])null, (System.Type[])null, flagArray = new bool[1]
                    {
            true
                    }, true);
                    if (flagArray[0])
                        dataTable2 = (DataTable)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(DataTable));
                    if (RecordTheInteraction)
                        this.RecordInteraction(sql);
                    dataTable1 = dataTable2;
                    goto label_13;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_13:
            return dataTable1;
        }

        public void ExecuteWithOutReturn(string sql, bool RecordTheInteraction = true)
        {
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) sql
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.Text
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateCall(this.Command, (System.Type)null, "ExecuteNonQuery", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
                    if (!RecordTheInteraction)
                        return;
                    this.RecordInteraction(sql);
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public object ExecuteScalar(string sql, SqlTransaction trans, bool RecordTheInteraction = true)
        {
            object obj = null;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) sql
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.Text
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "Transaction", new object[1]
                    {
            (object) trans
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "Connection", new object[1]
                    {
            (object) trans.Connection
                    }, (string[])null, (System.Type[])null, false, true);
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.Command, (System.Type)null, nameof(ExecuteScalar), new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    if (RecordTheInteraction)
                        this.RecordInteraction(sql);
                    obj = objectValue;
                    goto label_11;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_11:
            return obj;
        }

        public object ExecuteScalar(string sql, bool RecordTheInteraction = true, bool clearParams = false)
        {
            object obj = null;
            try
            {
                if (this.OpenConnection())
                {
                    try
                    {
                        if (clearParams)
                            NewLateBinding.LateCall(NewLateBinding.LateGet(this.Command, (System.Type)null, "Parameters", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Clear", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        ProjectData.ClearProjectError();
                    }
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) sql
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.Text
                    }, (string[])null, (System.Type[])null, false, true);
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.Command, (System.Type)null, nameof(ExecuteScalar), new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    if (RecordTheInteraction)
                        this.RecordInteraction(sql);
                    obj = objectValue;
                    goto label_14;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_14:
            return obj;
        }

        public object SP_ExecuteScalar(string sql, bool RecordTheInteraction = true)
        {
            object obj = null;
            try
            {
                if (this.OpenConnection())
                {
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandText", new object[1]
                    {
            (object) sql
                    }, (string[])null, (System.Type[])null, false, true);
                    NewLateBinding.LateSetComplex(this.Command, (System.Type)null, "CommandType", new object[1]
                    {
            (object) CommandType.StoredProcedure
                    }, (string[])null, (System.Type[])null, false, true);
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.Command, (System.Type)null, "ExecuteScalar", new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    if (RecordTheInteraction)
                        this.RecordInteraction(sql);
                    obj = objectValue;
                    goto label_11;
                }
                else
                {
                    int num = (int)App.ShowMessage("Database cannot open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!this.CloseConnection())
                {
                    int num = (int)App.ShowMessage("Database cannot close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            label_11:
            return obj;
        }

        private object RecordInteraction(string sql)
        {
            object obj = null;
            return obj;
        }

        public async Task<object> ExecuteAsync(string spName, params SqlParameter[] parameters)
        {
            using (var newConnection = new SqlConnection(App.TheSystem.Configuration.ConnectionString))
            {
                using (var newCommand = new SqlCommand(spName, newConnection))
                {
                    newCommand.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        newCommand.Parameters.AddRange(parameters);
                    await newConnection.OpenAsync().ConfigureAwait(false);
                    return await newCommand.ExecuteScalarAsync().ConfigureAwait(false);
                }
            }
        }
    }
}