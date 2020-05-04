using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
    public class Database
    {
        public Database()
        {
            var switchExpr = App.TheSystem.DataBaseServerType;
            switch (switchExpr)
            {
                case Enums.DatabaseSystems.MySQL:
                    {
                        break;
                    }
                // ServerConnection = New MySql.Data.MySqlClient.MySqlConnection(TheSystem.Configuration.ConnectionString)
                // Command = New MySql.Data.MySqlClient.MySqlCommand("", ServerConnection)
                // Adapter = New MySql.Data.MySqlClient.MySqlDataAdapter(Command)
                case Enums.DatabaseSystems.Microsoft_SQL_Server:
                    {
                        ServerConnection = new SqlConnection(App.TheSystem.Configuration.ConnectionString);
                        ServerConnectionString = App.TheSystem.Configuration.ConnectionString;
                        Command = new SqlCommand("", (SqlConnection)ServerConnection);
                        ((SqlCommand)Command).CommandTimeout = 400;
                        Adapter = new SqlDataAdapter((SqlCommand)Command);
                        PaggedQueryConnection = new SqlConnection(App.TheSystem.Configuration.ConnectionString);
                        break;
                    }
            }

            Manager = new Management.ManagerSQL(this);
            Picklists = new PickLists.PickListSQL(this);
            User = new Users.UserSQL(this);
            Customer = new Customers.CustomerSQL(this);
            Part = new Parts.PartSQL(this);
            Product = new Products.ProductSQL(this);
            Supplier = new Suppliers.SupplierSQL(this);
            PartSupplier = new PartSuppliers.PartSupplierSQL(this);
            ProductSupplier = new ProductSuppliers.ProductSupplierSQL(this);
            Sites = new Sites.SiteSQL(this);
            Engineer = new Engineers.EngineerSQL(this);
            Asset = new Assets.AssetSQL(this);
            Van = new Vans.VanSQL(this);
            Fleet = new FleetVans.FleetSQL(this);
            FleetVan = new FleetVans.FleetVanSQL(this);
            FleetVanType = new FleetVans.FleetVanTypeSQL(this);
            FleetVanEngineer = new FleetVans.FleetVanEngineerSQL(this);
            FleetVanMaintenance = new FleetVans.FleetVanMaintenanceSQL(this);
            FleetVanFault = new FleetVans.FleetVanFaultSQL(this);
            FleetVanContract = new FleetVans.FleetVanContractSQL(this);
            FleetVanService = new FleetVans.FleetVanServiceSQL(this);
            FleetVanEquipment = new FleetVans.FleetVanEquipmentSQL(this);
            FleetEquipment = new FleetVans.FleetEquipmentSQL(this);
            EngineerLevel = new EngineerLevels.EngineerLevelSQL(this);
            Documents = new Documentss.DocumentsSQL(this);
            Contact = new Contacts.ContactSQL(this);
            EngineerPostalRegion = new EngineerPostalRegions.EngineerPostalRegionSQL(this);
            Order = new Orders.OrderSQL(this);
            SupplierInvoices = new Orders.SupplierInvoiceSQL(this);
            OrderPart = new OrderParts.OrderPartSQL(this);
            OrderProduct = new OrderProducts.OrderProductSQL(this);
            SiteOrder = new SiteOrders.SiteOrderSQL(this);
            InvoiceAddress = new InvoiceAddresss.InvoiceAddressSQL(this);
            CustomerCharge = new CustomerCharges.CustomerChargeSQL(this);
            SubContractor = new Subcontractors.SubcontractorSQL(this);
            Area = new Areas.AreaSQL(this);
            Section = new Sections.SectionSQL(this);
            SubTask = new SubTasks.SubTaskSQL(this);
            Task = new Tasks.TaskSQL(this);
            Job = new Jobs.JobSQL(this);
            JobContact = new JobContacts.JobContactSQL(this);
            JobAsset = new JobAssets.JobAssetSQL(this);
            JobItems = new JobItems.JobItemSQL(this);
            JobOfWorks = new JobOfWorks.JobOfWorkSQL(this);
            EngineerVisits = new EngineerVisits.EngineerVisitSQL(this);
            Quotes = new Quotes.QuotesSQL(this);
            Warehouse = new Warehouses.WarehouseSQL(this);
            PartTransaction = new PartTransactions.PartTransactionSQL(this);
            StockTakeAudit = new StockTakeAuditSQL(this);
            ProductTransaction = new ProductTransactions.ProductTransactionSQL(this);
            OrderLocationPart = new OrderLocationPart.OrderLocationPartSQL(this);
            OrderLocationProduct = new OrderLocationProduct.OrderLocationProductSQL(this);
            Location = new Locationss.LocationsSQL(this);
            OrderLocation = new OrderLocations.OrderLocationSQL(this);
            QuoteJob = new QuoteJobs.QuoteJobsSQL(this);
            QuoteJobAsset = new QuoteJobAssets.QuoteJobAssetSQL(this);
            QuoteJobOfWorks = new QuoteJobOfWorks.QuoteJobOfWorkSQL(this);
            QuoteJobItems = new QuoteJobItems.QuoteJobItemSQL(this);
            QuoteEngineerVisits = new QuoteEngineerVisits.QuoteEngineerVisitSQL(this);
            ProductPriceRequest = new ProductSupplierPriceRequests.ProductSupplierPriceRequestSQL(this);
            PartPriceRequest = new PartSupplierPriceRequests.PartSupplierPriceRequestSQL(this);
            EngineerVisitOrder = new EngineerVisitOrders.EngineerVisitOrderSQL(this);
            Scheduler = new Scheduler.SchedulerSQL(this);
            OrderCharge = new OrderCharges.OrderChargeSQL(this);
            CustomerOrder = new CustomerOrders.CustomerOrderSQL(this);
            QuoteJobParts = new QuoteJobPartss.QuoteJobPartsSQL(this);
            QuoteJobProducts = new QuoteJobProductss.QuoteJobProductsSQL(this);
            EngineerAbsence = new EngineerAbsence.EngineerAbsenceSQL(this);
            UserAbsence = new UserAbsence.UserAbsenceSQL(this);
            ContractOriginal = new ContractsOriginal.ContractOriginalSQL(this);
            ContractOriginalSite = new ContractOriginalSites.ContractOriginalSiteSQL(this);
            ContractOriginalSiteAsset = new ContractOriginalSiteAssets.ContractOriginalSiteAssetSQL(this);
            ContractOriginalPPMVisit = new ContractOriginalPPMVisits.ContractOriginalPPMVisitSQL(this);
            QuoteContractOriginal = new QuoteContractOriginals.QuoteContractOriginalSQL(this);
            QuoteContractOriginalSite = new QuoteContractOriginalSites.QuoteContractOriginalSiteSQL(this);
            QuoteContractOriginalPPMVisits = new QuoteContractOriginalPPMVisits.QuoteContractOriginalPPMVisitSQL(this);
            Notes = new Notes.NotesSQL(this);
            EngineerVisitsPartsAndProducts = new EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsSQL(this);
            EngineerVisitsTimeSheet = new EngineerVisitTimeSheets.EngineerVisitTimeSheetSQL(this);
            ProductAssociatedPart = new ProductAssociatedParts.ProductAssociatedPartSQL(this);
            SystemScheduleOfRate = new SystemScheduleOfRates.SystemScheduleOfRateSQL(this);
            CustomerScheduleOfRate = new CustomerScheduleOfRates.CustomerScheduleOfRateSQL(this);
            EngineerVan = new EngineerVans.EngineerVanSQL(this);
            TimeSlotRates = new TimeSlotRates.TimeSlotRatesSQL(this);
            EngineerVisitCharge = new EngineerVisitCharges.EngineerVisitChargeSQL(this);
            JobAudit = new JobAudits.JobAuditSQL(this);
            InvoiceToBeRaised = new InvoiceToBeRaiseds.InvoiceToBeRaisedSQL(this);
            EngineerVisitPartProductAllocated = new EngineerVisitPartProductAllocateds.EngineerVisitPartProductAllocatedSQL(this);
            Invoiced = new Invoiceds.InvoicedSQL(this);
            InvoicedLines = new InvoicedLiness.InvoicedLinesSQL(this);
            ContractManager = new ContractManager.ContractManagerSQL(this);
            SiteCustomerAudit = new SiteCustomerAudits.SiteCustomerAuditSQL(this);
            EngineerVisitDefects = new EngineerVisitDefectss.EngineerVisitDefectsSQL(this);
            EngineerVisitAssetWorkSheet = new EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetSQL(this);
            VATRatesSQL = new VATRatess.VATRatesSQL(this);
            StandardSentence = new StandardSentences.StandardSentenceSQL(this);
            JobInstallSQL = new JobInstalls.JobInstallSQL(this);
            EngineerVisitQCSQL = new EngineerVisitQCs.EngineerVisitQCSQL(this);
            JobLock = new JobLock.JobLockSQL(this);
            OrderConsolidations = new OrderConsolidations.OrderConsolidationSQL(this);
            MaxEngineerTime = new MaxEngineerTimes.MaxEngineerTimeSQL(this);
            ContractOriginalSiteRates = new ContractOriginalSiteRatess.ContractOriginalSiteRatesSQL(this);
            PartsToBeCredited = new PartsToBeCrediteds.PartsToBeCreditedSQL(this);
            SalesCredit = new SalesCredits.SalesCreditSQL(this);
            EngineerTimesheets = new EngineerTimeSheets.EngineerTimeSheetSQL(this);
            ImportValidation = new Importer.Validation.ValidationSQL(this);
            LetterManager = new LetterManager.LetterManagerSQL(this);
            EngineerVisitNCCGSR = new EngineerVisitNCCGSRs.EngineerVisitNCCGSRSQL(this);
            EngineerVisitAdditional = new EngineerVisitAdditionals.EngineerVisitAdditionalSQL(this);
            POInvoice = new Orders.POInvoiceSQL(this);
            EngineerVisitPhotos = new EngineerVisitPhotos.EngineerVisitPhotoSQL(this);
            ContractVisits = new ContractOriginalVisits.ContractOriginalVisitSQL(this);
            Appointments = new Appointments.AppointmentsSQL(this);
            JobImports = new JobImport.JobImportSQL(this);
            SunFinance = new Accounts.SunFinanceSQL(this);
            Authority = new Authority.AuthoritySQL(this);
            Skills = new Skills.SkillsSQL(this);
            UserLevels = new UserLevels.UserLevelSQL(this);
            CostCentre = new CostCentres.CostCentreSql(this);
            CostCentreLinkType = new CostCentres.LinkTypes.LinkTypeSql(this);
            EvEngineer = new EngineerVisits.EngineerVisitEngineers.EngineerVisitEngineerSql(this);
            VanEquipments = new Vans.Equipments.EquipmentSql(this);
            Ibc = new Ibc.IbcSql(this);
            JobTypeColour = new Settings.Scheduler.JobTypeColourSql(this);
            RagRating = new RagRating.RagRatingSql(this);
            SiteSafteyAudit = new Engineers.SiteSafetyAudits.SiteSafetyAuditSql(this);
            EngineerRole = new EngineerRoles.EngineerRoleSql(this);
            ContactAttempts = new ContactAttempts.ContactAttemptSql(this);
            CustomerAlert = new Customers.CustomerAlertSql(this);
            CompanyDetails = new CompanyDetails.CompanyDetailsSql(this);
        }

        private SqlConnection _paggedQueryConnection = null;

        private SqlConnection PaggedQueryConnection
        {
            get
            {
                return _paggedQueryConnection;
            }

            set
            {
                _paggedQueryConnection = value;
            }
        }

        private SqlConnection _serverConnection = null;

        private SqlConnection ServerConnection
        {
            get
            {
                return _serverConnection;
            }

            set
            {
                _serverConnection = value;
            }
        }

        private string _ServerConnectionString = "";

        public string ServerConnectionString
        {
            get
            {
                return _ServerConnectionString;
            }

            set
            {
                _ServerConnectionString = value;
            }
        }

        private SqlCommand _command = null;

        private SqlCommand Command
        {
            get
            {
                return _command;
            }

            set
            {
                _command = value;
            }
        }

        private SqlDataAdapter _adapter = null;

        private SqlDataAdapter Adapter
        {
            get
            {
                return _adapter;
            }

            set
            {
                _adapter = value;
            }
        }

        public Management.ManagerSQL Manager;
        public PickLists.PickListSQL Picklists;
        public Users.UserSQL User;
        public Customers.CustomerSQL Customer;
        public Parts.PartSQL Part;
        public Products.ProductSQL Product;
        public Suppliers.SupplierSQL Supplier;
        public PartSuppliers.PartSupplierSQL PartSupplier;
        public ProductSuppliers.ProductSupplierSQL ProductSupplier;
        public Sites.SiteSQL Sites;
        public Engineers.EngineerSQL Engineer;
        public Assets.AssetSQL Asset;
        public Vans.VanSQL Van;
        public FleetVans.FleetSQL Fleet;
        public FleetVans.FleetVanSQL FleetVan;
        public FleetVans.FleetVanTypeSQL FleetVanType;
        public FleetVans.FleetVanEngineerSQL FleetVanEngineer;
        public FleetVans.FleetVanMaintenanceSQL FleetVanMaintenance;
        public FleetVans.FleetVanFaultSQL FleetVanFault;
        public FleetVans.FleetVanContractSQL FleetVanContract;
        public FleetVans.FleetVanServiceSQL FleetVanService;
        public FleetVans.FleetVanEquipmentSQL FleetVanEquipment;
        public FleetVans.FleetEquipmentSQL FleetEquipment;
        public EngineerLevels.EngineerLevelSQL EngineerLevel;
        public Documentss.DocumentsSQL Documents;
        public Contacts.ContactSQL Contact;
        public EngineerPostalRegions.EngineerPostalRegionSQL EngineerPostalRegion;
        public Orders.OrderSQL Order;
        public Orders.SupplierInvoiceSQL SupplierInvoices;
        public OrderProducts.OrderProductSQL OrderProduct;
        public OrderParts.OrderPartSQL OrderPart;
        public SiteOrders.SiteOrderSQL SiteOrder;
        public InvoiceAddresss.InvoiceAddressSQL InvoiceAddress;
        public CustomerCharges.CustomerChargeSQL CustomerCharge;
        public Subcontractors.SubcontractorSQL SubContractor;
        public Areas.AreaSQL Area;
        public Sections.SectionSQL Section;
        public SubTasks.SubTaskSQL SubTask;
        public Tasks.TaskSQL Task;
        public Jobs.JobSQL Job;
        public JobContacts.JobContactSQL JobContact;
        public JobAssets.JobAssetSQL JobAsset;
        public JobItems.JobItemSQL JobItems;
        public JobOfWorks.JobOfWorkSQL JobOfWorks;
        public EngineerVisits.EngineerVisitSQL EngineerVisits;
        public Quotes.QuotesSQL Quotes;
        public Warehouses.WarehouseSQL Warehouse;
        public PartTransactions.PartTransactionSQL PartTransaction;
        public StockTakeAuditSQL StockTakeAudit;
        public ProductTransactions.ProductTransactionSQL ProductTransaction;
        public ProductSupplierPriceRequests.ProductSupplierPriceRequestSQL ProductPriceRequest;
        public PartSupplierPriceRequests.PartSupplierPriceRequestSQL PartPriceRequest;
        public OrderLocationPart.OrderLocationPartSQL OrderLocationPart;
        public OrderLocationProduct.OrderLocationProductSQL OrderLocationProduct;
        public Locationss.LocationsSQL Location;
        public OrderLocations.OrderLocationSQL OrderLocation;
        public QuoteJobs.QuoteJobsSQL QuoteJob;
        public QuoteJobAssets.QuoteJobAssetSQL QuoteJobAsset;
        public QuoteJobOfWorks.QuoteJobOfWorkSQL QuoteJobOfWorks;
        public QuoteJobItems.QuoteJobItemSQL QuoteJobItems;
        public QuoteEngineerVisits.QuoteEngineerVisitSQL QuoteEngineerVisits;
        public EngineerVisitOrders.EngineerVisitOrderSQL EngineerVisitOrder;
        public Scheduler.SchedulerSQL Scheduler;
        public OrderCharges.OrderChargeSQL OrderCharge;
        public CustomerOrders.CustomerOrderSQL CustomerOrder;
        public QuoteJobPartss.QuoteJobPartsSQL QuoteJobParts;
        public QuoteJobProductss.QuoteJobProductsSQL QuoteJobProducts;
        public EngineerAbsence.EngineerAbsenceSQL EngineerAbsence;
        public UserAbsence.UserAbsenceSQL UserAbsence;
        public ContractsOriginal.ContractOriginalSQL ContractOriginal;
        public ContractOriginalSites.ContractOriginalSiteSQL ContractOriginalSite;
        public ContractOriginalSiteAssets.ContractOriginalSiteAssetSQL ContractOriginalSiteAsset;
        public ContractOriginalPPMVisits.ContractOriginalPPMVisitSQL ContractOriginalPPMVisit;
        public QuoteContractOriginalPPMVisits.QuoteContractOriginalPPMVisitSQL QuoteContractOriginalPPMVisits;
        public QuoteContractOriginalSites.QuoteContractOriginalSiteSQL QuoteContractOriginalSite;
        public QuoteContractOriginals.QuoteContractOriginalSQL QuoteContractOriginal;
        public Notes.NotesSQL Notes;
        public EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsSQL EngineerVisitsPartsAndProducts;
        public EngineerVisitTimeSheets.EngineerVisitTimeSheetSQL EngineerVisitsTimeSheet;
        public ProductAssociatedParts.ProductAssociatedPartSQL ProductAssociatedPart;
        public SystemScheduleOfRates.SystemScheduleOfRateSQL SystemScheduleOfRate;
        public CustomerScheduleOfRates.CustomerScheduleOfRateSQL CustomerScheduleOfRate;
        public EngineerVans.EngineerVanSQL EngineerVan;
        public TimeSlotRates.TimeSlotRatesSQL TimeSlotRates;
        public EngineerVisitCharges.EngineerVisitChargeSQL EngineerVisitCharge;
        public JobAudits.JobAuditSQL JobAudit;
        public InvoiceToBeRaiseds.InvoiceToBeRaisedSQL InvoiceToBeRaised;
        public EngineerVisitPartProductAllocateds.EngineerVisitPartProductAllocatedSQL EngineerVisitPartProductAllocated;
        public Invoiceds.InvoicedSQL Invoiced;
        public InvoicedLiness.InvoicedLinesSQL InvoicedLines;
        public ContractManager.ContractManagerSQL ContractManager;
        public SiteCustomerAudits.SiteCustomerAuditSQL SiteCustomerAudit;
        public EngineerVisitDefectss.EngineerVisitDefectsSQL EngineerVisitDefects;
        public EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetSQL EngineerVisitAssetWorkSheet;
        public VATRatess.VATRatesSQL VATRatesSQL;
        public StandardSentences.StandardSentenceSQL StandardSentence;
        public EngineerVisitQCs.EngineerVisitQCSQL EngineerVisitQCSQL;
        public JobInstalls.JobInstallSQL JobInstallSQL;
        public JobLock.JobLockSQL JobLock;
        public OrderConsolidations.OrderConsolidationSQL OrderConsolidations;
        public MaxEngineerTimes.MaxEngineerTimeSQL MaxEngineerTime;
        public ContractOriginalSiteRatess.ContractOriginalSiteRatesSQL ContractOriginalSiteRates;
        public PartsToBeCrediteds.PartsToBeCreditedSQL PartsToBeCredited;
        public SalesCredits.SalesCreditSQL SalesCredit;
        public EngineerTimeSheets.EngineerTimeSheetSQL EngineerTimesheets;
        public Importer.Validation.ValidationSQL ImportValidation;
        public LetterManager.LetterManagerSQL LetterManager;
        public EngineerVisitNCCGSRs.EngineerVisitNCCGSRSQL EngineerVisitNCCGSR;
        public EngineerVisitAdditionals.EngineerVisitAdditionalSQL EngineerVisitAdditional;
        public Orders.POInvoiceSQL POInvoice;
        public EngineerVisitPhotos.EngineerVisitPhotoSQL EngineerVisitPhotos;
        public ContractOriginalVisits.ContractOriginalVisitSQL ContractVisits;
        public Appointments.AppointmentsSQL Appointments;
        public JobImport.JobImportSQL JobImports;
        public Accounts.SunFinanceSQL SunFinance;
        public Authority.AuthoritySQL Authority;
        public Skills.SkillsSQL Skills;
        public UserLevels.UserLevelSQL UserLevels;
        public CostCentres.CostCentreSql CostCentre;
        public CostCentres.LinkTypes.LinkTypeSql CostCentreLinkType;
        public EngineerVisits.EngineerVisitEngineers.EngineerVisitEngineerSql EvEngineer;
        public Vans.Equipments.EquipmentSql VanEquipments;
        public Ibc.IbcSql Ibc;
        public Settings.Scheduler.JobTypeColourSql JobTypeColour;
        public RagRating.RagRatingSql RagRating;
        public Engineers.SiteSafetyAudits.SiteSafetyAuditSql SiteSafteyAudit;
        public EngineerRoles.EngineerRoleSql EngineerRole;
        public ContactAttempts.ContactAttemptSql ContactAttempts;
        public Customers.CustomerAlertSql CustomerAlert;
        public CompanyDetails.CompanyDetailsSql CompanyDetails;

        private bool OpenConnection()
        {
            try
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ServerConnection.State, ConnectionState.Closed, false)))
                {
                    ServerConnection.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ServerConnection.State, ConnectionState.Open, false)))
                {
                    ServerConnection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ClearParameter()
        {
            var switchExpr = App.TheSystem.DataBaseServerType;
            switch (switchExpr)
            {
                case Enums.DatabaseSystems.MySQL:
                    {
                        break;
                    }
                // CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Clear()
                case Enums.DatabaseSystems.Microsoft_SQL_Server:
                    {
                        ((SqlCommand)Command).Parameters.Clear();
                        break;
                    }
            }
        }

        public void AddParameter(string name, object value, bool valueAsItIsSent = false)
        {
            var switchExpr = App.TheSystem.DataBaseServerType;
            switch (switchExpr)
            {
                case Enums.DatabaseSystems.MySQL:
                    {
                        switch (name)
                        {
                            case "?Operator":
                                {
                                    break;
                                }
                            // CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Add(name, value)
                            // CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Add(name, value)
                            case "?SearchFilter":
                                {
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                                // CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Add(name, Entity.Sys.Helper.CleanText(value))
                        }

                        break;
                    }

                case Enums.DatabaseSystems.Microsoft_SQL_Server:
                    {
                        switch (name)
                        {
                            case "?Operator":
                                {
                                    ((SqlCommand)Command).Parameters.Add(name.Replace("?", "@"), value);
                                    break;
                                }

                            case "?SearchFilter":
                                {
                                    ((SqlCommand)Command).Parameters.Add(name.Replace("?", "@"), value);
                                    break;
                                }

                            default:
                                {
                                    if ((name.ToUpper() ?? "") == "@RETURN")
                                    {
                                        var returnParam = new SqlParameter("@RETURN", SqlDbType.Int);
                                        returnParam.Direction = ParameterDirection.ReturnValue;
                                        ((SqlCommand)Command).Parameters.Add(returnParam);
                                    }
                                    else if (!valueAsItIsSent)
                                    {
                                        ((SqlCommand)Command).Parameters.Add(name.Replace("?", "@"), Helper.CleanText(Conversions.ToString(value)));
                                    }
                                    else
                                    {
                                        ((SqlCommand)Command).Parameters.Add(name.Replace("?", "@"), value);
                                    }

                                    break;
                                }
                        }

                        break;
                    }
            }
        }

        public void ExecuteCommand_NO_Return(string fileName, bool recordInteraction = true)
        {
            _command.CommandText = Helper.GetTextResource(fileName);
            ExecuteWithOutReturn(BuildSQL(), recordInteraction);
        }

        public DataTable ExecuteSP_DataTable(string SPName, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    _command.CommandText = SPName;
                    _command.CommandType = CommandType.StoredProcedure;
                    var returnDT = new DataTable();
                    Adapter.Fill(returnDT);
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(SPName);
                    }

                    return returnDT;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        public DataSet ExecuteSP_DataSet(string SPName, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    _command.CommandText = SPName;
                    _command.CommandType = CommandType.StoredProcedure;
                    var returnDS = new DataSet();
                    Adapter.Fill(returnDS);
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(SPName);
                    }

                    return returnDS;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        public DataTable ExecuteSP_DataTable(string spName, params SqlParameter[] @params)
        {
            try
            {
                if (OpenConnection())
                {
                    _command.CommandText = spName;
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Parameters.Clear();
                    foreach (SqlParameter p in @params)
                        _command.Parameters.Add(p);
                    var returnDT = new DataTable();
                    Adapter.Fill(returnDT);
                    return returnDT;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        public int ExecuteSP_ReturnRowsAffected(string SPName)
        {
            try
            {
                if (OpenConnection())
                {
                    _command.CommandText = SPName;
                    _command.CommandType = CommandType.StoredProcedure;
                    return Conversions.ToInteger(_command.ExecuteNonQuery());
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        public DataTable ExecuteCommand_DataTable(SqlCommand Command)
        {
            try
            {
                int retryCount = 3;
                bool success = false;
                var returnDT = new DataTable();
                while (retryCount > 0 & !success)
                {
                    try
                    {
                        var da = new SqlDataAdapter(Command);
                        da.Fill(returnDT);
                        success = true;
                    }
                    catch (SqlException exception)
                    {
                        if (!(exception.Number == 1205))
                        {
                            // a sql exception that is not a deadlock
                            throw;
                        }

                        retryCount = retryCount - 1;
                        if (retryCount == 0)
                        {
                            throw;
                        }
                    }
                }

                return returnDT;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }

            return default;
        }

        public void ExecuteSP_NO_Return(string SPName, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    _command.CommandText = SPName;
                    _command.CommandType = CommandType.StoredProcedure;
                    if ((SPName ?? "") == "Parts_PreImportValidate")
                    {
                        ((SqlCommand)Command).CommandTimeout = 2000;
                    }
                    else
                    {
                        ((SqlCommand)Command).CommandTimeout = 400;
                    }

                    Command.ExecuteNonQuery();
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(SPName);
                    }
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
        }

        public object ExecuteSP_OBJECT(string SPName, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    _command.CommandText = SPName;
                    _command.CommandType = CommandType.StoredProcedure;
                    var oReturn = Command.ExecuteScalar();
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(SPName);
                    }

                    _command.Parameters.Clear();
                    return oReturn;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                    return null;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                return null;
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
        }

        private string BuildSQL()
        {
            string sql = Conversions.ToString(_command.CommandText);
            var switchExpr = App.TheSystem.DataBaseServerType;
            switch (switchExpr)
            {
                case Enums.DatabaseSystems.MySQL:
                    {
                        break;
                    }
                // If CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Count > 0 Then
                // For Each sqlParameter As MySql.Data.MySqlClient.MySqlParameter In CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters
                // If Not (sqlParameter.Value = "NULL") Then
                // If sqlParameter.ParameterName = "Operator" Then
                // sql = sql.Replace("?" & sqlParameter.ParameterName, sqlParameter.Value)
                // ElseIf sqlParameter.ParameterName = "SearchFilter" Then
                // sql = sql.Replace("?" & sqlParameter.ParameterName, sqlParameter.Value)
                // Else
                // sql = sql.Replace("?" & sqlParameter.ParameterName, "'" & sqlParameter.Value & "'")
                // End If
                // Else
                // sql = sql.Replace("?" & sqlParameter.ParameterName, "NULL")
                // End If
                // Next
                // End If
                case Enums.DatabaseSystems.Microsoft_SQL_Server:
                    {
                        if (((SqlCommand)Command).Parameters.Count > 0)
                        {
                            sql = sql.Replace("?", "@").Replace("`", "");
                            foreach (SqlParameter sqlParameter in ((SqlCommand)Command).Parameters)
                            {
                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(sqlParameter.Value, "NULL", false)))
                                {
                                    if ((sqlParameter.ParameterName ?? "") == "@Operator")
                                    {
                                        sql = sql.Replace(sqlParameter.ParameterName, Conversions.ToString(sqlParameter.Value));
                                    }
                                    else if ((sqlParameter.ParameterName ?? "") == "@SearchFilter")
                                    {
                                        sql = sql.Replace(sqlParameter.ParameterName, Conversions.ToString(sqlParameter.Value));
                                    }
                                    else
                                    {
                                        sql = sql.Replace(sqlParameter.ParameterName, Conversions.ToString("'" + sqlParameter.Value + "'"));
                                    }
                                }
                                else
                                {
                                    sql = sql.Replace(sqlParameter.ParameterName, "NULL");
                                }
                            }
                        }

                        break;
                    }
            }

            return sql;
        }

        public DataTable ExecuteWithReturn(string sql, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    Command.CommandText = sql;
                    Command.CommandType = CommandType.Text;
                    var returnDT = new DataTable();
                    Adapter.Fill(returnDT);
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(sql);
                    }

                    return returnDT;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        public void ExecuteWithOutReturn(string sql, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    Command.CommandText = sql;
                    Command.CommandType = CommandType.Text;
                    Command.ExecuteNonQuery();
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(sql);
                    }
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
        }

        public object ExecuteScalar(string sql, SqlTransaction trans, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    Command.CommandText = sql;
                    Command.CommandType = CommandType.Text;
                    Command.Transaction = trans;
                    Command.Connection = trans.Connection;
                    var o = Command.ExecuteScalar();
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(sql);
                    }

                    return o;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        public object ExecuteScalar(string sql, bool RecordTheInteraction = true, bool clearParams = false)
        {
            try
            {
                if (OpenConnection())
                {
                    try
                    {
                        if (clearParams)
                            Command.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                    }

                    Command.CommandText = sql;
                    Command.CommandType = CommandType.Text;
                    var o = Command.ExecuteScalar();
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(sql);
                    }

                    return o;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        public object SP_ExecuteScalar(string sql, bool RecordTheInteraction = true)
        {
            try
            {
                if (OpenConnection())
                {
                    Command.CommandText = sql;
                    Command.CommandType = CommandType.StoredProcedure;
                    var o = Command.ExecuteScalar();
                    if (RecordTheInteraction)
                    {
                        RecordInteraction(sql);
                    }

                    return o;
                }
                else
                {
                    App.ShowMessage("Database cannot open", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Database Error : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
            finally
            {
                if (!CloseConnection())
                {
                    App.ShowMessage("Database cannot close", MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
                }
            }

            return default;
        }

        private object RecordInteraction(string sql)
        {
            return default;
            // Try
            // Dim settings As Entity.Management.Settings = DB.Manager.Get()

            // Dim WorkingHoursStart As New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursStart.Split(":")(0), settings.WorkingHoursStart.Split(":")(1), 0)

            // Dim WorkingHoursEnd As New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursEnd.Split(":")(0), settings.WorkingHoursEnd.Split(":")(1), 0)

            // Dim sf As New System.Diagnostics.StackFrame(3, True)
            // Dim ClassAndMethod As String

            // If sf.GetMethod.DeclaringType.Name.ToUpper.StartsWith("FRM") Then
            // ClassAndMethod = FriendlyText(sf.GetMethod.DeclaringType.Name.Substring(3) _
            // & "; " & sf.GetMethod.Name)
            // Else
            // ClassAndMethod = FriendlyText(sf.GetMethod.DeclaringType.Name _
            // & "; " & sf.GetMethod.Name)
            // End If

            // Dim loggedInUserID As String
            // If loggedInUser Is Nothing Then
            // loggedInUserID = "0"
            // Else
            // loggedInUserID = CStr(loggedInUser.UserID)
            // End If

            // Dim outOfHours As String
            // outOfHours = IIf(Now > WorkingHoursStart And Now < WorkingHoursEnd, "0", "1")

            // Select Case sql.Trim.Split(" ")(0)
            // Case "INSERT"
            // DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'INSERT', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            // Case "UPDATE"
            // DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'UPDATE', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            // Case "DELETE"
            // DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'DELETE', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            // Case "SELECT"
            // DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'SELECT', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            // Case Else
            // DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'UNRECOGNISED', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            // End Select
            // Catch
            // 'DO NOTHING
            // End Try
        }

        public async Task<object> ExecuteAsync(string spName, params SqlParameter[] parameters)
        {
            using (var newConnection = new SqlConnection(App.TheSystem.Configuration.ConnectionString))
            {
                using (var newCommand = new SqlCommand(spName, (SqlConnection)newConnection))
                {
                    newCommand.CommandType = CommandType.StoredProcedure;
                    if (parameters is object)
                        newCommand.Parameters.AddRange(parameters);
                    await newConnection.OpenAsync().ConfigureAwait(false);
                    return await newCommand.ExecuteScalarAsync().ConfigureAwait(false);
                }
            }
        }
    }
}