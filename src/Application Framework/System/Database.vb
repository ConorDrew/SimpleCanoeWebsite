Imports System.Data.SqlClient
Imports System.Threading.Tasks

Namespace Entity.Sys

    Public Class Database

        Public Sub New()
            Select Case TheSystem.DataBaseServerType
                Case Enums.DatabaseSystems.MySQL
                    'ServerConnection = New MySql.Data.MySqlClient.MySqlConnection(TheSystem.Configuration.ConnectionString)
                    'Command = New MySql.Data.MySqlClient.MySqlCommand("", ServerConnection)
                    'Adapter = New MySql.Data.MySqlClient.MySqlDataAdapter(Command)
                Case Enums.DatabaseSystems.Microsoft_SQL_Server
                    ServerConnection = New SqlClient.SqlConnection(TheSystem.Configuration.ConnectionString)
                    ServerConnectionString = TheSystem.Configuration.ConnectionString
                    Command = New SqlClient.SqlCommand("", ServerConnection)
                    CType(Command, SqlClient.SqlCommand).CommandTimeout = 400
                    Adapter = New SqlClient.SqlDataAdapter(Command)
                    PaggedQueryConnection = New SqlClient.SqlConnection(TheSystem.Configuration.ConnectionString)
            End Select

            Manager = New Entity.Management.ManagerSQL(Me)
            Picklists = New Entity.PickLists.PickListSQL(Me)
            User = New Entity.Users.UserSQL(Me)
            Customer = New Entity.Customers.CustomerSQL(Me)
            Part = New Entity.Parts.PartSQL(Me)
            Product = New Entity.Products.ProductSQL(Me)
            Supplier = New Entity.Suppliers.SupplierSQL(Me)
            PartSupplier = New Entity.PartSuppliers.PartSupplierSQL(Me)
            ProductSupplier = New Entity.ProductSuppliers.ProductSupplierSQL(Me)
            Sites = New Entity.Sites.SiteSQL(Me)
            Engineer = New Entity.Engineers.EngineerSQL(Me)
            Asset = New Entity.Assets.AssetSQL(Me)
            Van = New Entity.Vans.VanSQL(Me)
            Fleet = New Entity.FleetVans.FleetSQL(Me)
            FleetVan = New Entity.FleetVans.FleetVanSQL(Me)
            FleetVanType = New Entity.FleetVans.FleetVanTypeSQL(Me)
            FleetVanEngineer = New Entity.FleetVans.FleetVanEngineerSQL(Me)
            FleetVanMaintenance = New Entity.FleetVans.FleetVanMaintenanceSQL(Me)
            FleetVanFault = New Entity.FleetVans.FleetVanFaultSQL(Me)
            FleetVanContract = New Entity.FleetVans.FleetVanContractSQL(Me)
            FleetVanService = New Entity.FleetVans.FleetVanServiceSQL(Me)
            FleetVanEquipment = New Entity.FleetVans.FleetVanEquipmentSQL(Me)
            FleetEquipment = New Entity.FleetVans.FleetEquipmentSQL(Me)
            EngineerLevel = New Entity.EngineerLevels.EngineerLevelSQL(Me)
            Documents = New Entity.Documentss.DocumentsSQL(Me)
            Contact = New Entity.Contacts.ContactSQL(Me)
            EngineerPostalRegion = New Entity.EngineerPostalRegions.EngineerPostalRegionSQL(Me)
            Order = New Entity.Orders.OrderSQL(Me)
            SupplierInvoices = New Entity.Orders.SupplierInvoiceSQL(Me)
            OrderPart = New Entity.OrderParts.OrderPartSQL(Me)
            OrderProduct = New Entity.OrderProducts.OrderProductSQL(Me)
            SiteOrder = New Entity.SiteOrders.SiteOrderSQL(Me)
            InvoiceAddress = New Entity.InvoiceAddresss.InvoiceAddressSQL(Me)
            CustomerCharge = New Entity.CustomerCharges.CustomerChargeSQL(Me)
            SubContractor = New Entity.Subcontractors.SubcontractorSQL(Me)
            Area = New Entity.Areas.AreaSQL(Me)
            Section = New Entity.Sections.SectionSQL(Me)
            SubTask = New Entity.SubTasks.SubTaskSQL(Me)
            Task = New Entity.Tasks.TaskSQL(Me)
            Job = New Entity.Jobs.JobSQL(Me)
            JobContact = New Entity.JobContacts.JobContactSQL(Me)
            JobAsset = New Entity.JobAssets.JobAssetSQL(Me)
            JobItems = New Entity.JobItems.JobItemSQL(Me)
            JobOfWorks = New Entity.JobOfWorks.JobOfWorkSQL(Me)
            EngineerVisits = New Entity.EngineerVisits.EngineerVisitSQL(Me)
            Quotes = New Entity.Quotes.QuotesSQL(Me)
            Warehouse = New Entity.Warehouses.WarehouseSQL(Me)
            PartTransaction = New Entity.PartTransactions.PartTransactionSQL(Me)
            StockTakeAudit = New Entity.StockTakeAuditSQL(Me)
            ProductTransaction = New Entity.ProductTransactions.ProductTransactionSQL(Me)
            OrderLocationPart = New Entity.OrderLocationPart.OrderLocationPartSQL(Me)
            OrderLocationProduct = New Entity.OrderLocationProduct.OrderLocationProductSQL(Me)
            Location = New Entity.Locationss.LocationsSQL(Me)
            OrderLocation = New Entity.OrderLocations.OrderLocationSQL(Me)
            QuoteJob = New Entity.QuoteJobs.QuoteJobsSQL(Me)
            QuoteJobAsset = New Entity.QuoteJobAssets.QuoteJobAssetSQL(Me)
            QuoteJobOfWorks = New Entity.QuoteJobOfWorks.QuoteJobOfWorkSQL(Me)
            QuoteJobItems = New Entity.QuoteJobItems.QuoteJobItemSQL(Me)
            QuoteEngineerVisits = New Entity.QuoteEngineerVisits.QuoteEngineerVisitSQL(Me)
            ProductPriceRequest = New Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequestSQL(Me)
            PartPriceRequest = New Entity.PartSupplierPriceRequests.PartSupplierPriceRequestSQL(Me)
            EngineerVisitOrder = New Entity.EngineerVisitOrders.EngineerVisitOrderSQL(Me)
            Scheduler = New Entity.Scheduler.SchedulerSQL(Me)
            OrderCharge = New Entity.OrderCharges.OrderChargeSQL(Me)
            CustomerOrder = New Entity.CustomerOrders.CustomerOrderSQL(Me)
            QuoteOrder = New Entity.QuoteOrders.QuoteOrderSQL(Me)
            QuoteOrderPart = New Entity.QuoteOrderParts.QuoteOrderPartSQL(Me)
            QuoteOrderProduct = New Entity.QuoteOrderProducts.QuoteOrderProductSQL(Me)
            QuoteJobParts = New Entity.QuoteJobPartss.QuoteJobPartsSQL(Me)
            QuoteJobProducts = New Entity.QuoteJobProductss.QuoteJobProductsSQL(Me)
            EngineerAbsence = New Entity.EngineerAbsence.EngineerAbsenceSQL(Me)
            UserAbsence = New Entity.UserAbsence.UserAbsenceSQL(Me)
            ContractOriginal = New Entity.ContractsOriginal.ContractOriginalSQL(Me)
            ContractOriginalSite = New Entity.ContractOriginalSites.ContractOriginalSiteSQL(Me)
            ContractOriginalSiteAsset = New Entity.ContractOriginalSiteAssets.ContractOriginalSiteAssetSQL(Me)
            ContractOriginalPPMVisit = New Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisitSQL(Me)
            QuoteContractOriginal = New Entity.QuoteContractOriginals.QuoteContractOriginalSQL(Me)
            QuoteContractOriginalSite = New Entity.QuoteContractOriginalSites.QuoteContractOriginalSiteSQL(Me)
            QuoteContractOriginalSiteAsset = New Entity.QuoteContractOriginalSiteAssets.QuoteContractOriginalSiteAssetSQL(Me)
            QuoteContractOriginalPPMVisits = New Entity.QuoteContractOriginalPPMVisits.QuoteContractOriginalPPMVisitSQL(Me)
            ContractAlternative = New Entity.ContractsAlternative.ContractAlternativeSQL(Me)
            ContractAlternativeSite = New Entity.ContractAlternativeSites.ContractAlternativeSiteSQL(Me)
            ContractAlternativeSiteAsset = New Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAssetSQL(Me)
            ContractAlternativePPMVisit = New Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisitSQL(Me)
            ContractAlternativeSiteJobItems = New Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItemsSQL(Me)
            ContractAlternativeSiteJobOfWork = New Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWorkSQL(Me)
            QuoteContractAlternativePPMVisits = New Entity.QuoteContractAlternativePPMVisits.QuoteContractAlternativePPMVisitSQL(Me)
            QuoteContractAlternativeSite = New Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSiteSQL(Me)
            QuoteContractAlternativeSiteAsset = New Entity.QuoteContractAlternativeSiteAssets.QuoteContractAlternativeSiteAssetSQL(Me)
            QuoteContractAlternative = New Entity.QuoteContractAlternatives.QuoteContractAlternativeSQL(Me)
            QuoteContractAlternativeSiteJobItems = New Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItemsSQL(Me)
            QuoteContractAlternativeSiteJobOfWork = New Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWorkSQL(Me)
            Notes = New Entity.Notes.NotesSQL(Me)
            Checklists = New Entity.CheckLists.CheckListSQL(Me)
            EngineerVisitsPartsAndProducts = New Entity.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsSQL(Me)
            EngineerVisitsTimeSheet = New Entity.EngineerVisitTimeSheets.EngineerVisitTimeSheetSQL(Me)
            ProductAssociatedPart = New Entity.ProductAssociatedParts.ProductAssociatedPartSQL(Me)
            SystemScheduleOfRate = New Entity.SystemScheduleOfRates.SystemScheduleOfRateSQL(Me)
            CustomerScheduleOfRate = New Entity.CustomerScheduleOfRates.CustomerScheduleOfRateSQL(Me)
            EngineerVan = New Entity.EngineerVans.EngineerVanSQL(Me)
            ContractOption3 = New Entity.ContractOption3s.ContractOption3SQL(Me)
            ContractOption3Site = New Entity.ContractOption3Sites.ContractOption3SiteSQL(Me)
            ContractOption3SiteAsset = New Entity.ContractOption3SiteAsset.ContractOption3AssetSQL(Me)
            ContractOption3SitePPMVisit = New Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisitSQL(Me)
            QuoteContractOption3 = New Entity.QuoteContractOption3s.QuoteContractOption3SQL(Me)
            QuoteContractOption3Site = New Entity.QuoteContractOption3Sites.QuoteContractOption3SiteSQL(Me)
            QuoteContractOption3SiteAssetDurations = New Entity.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDurationSQL(Me)
            TimeSlotRates = New Entity.TimeSlotRates.TimeSlotRatesSQL(Me)
            EngineerVisitCharge = New Entity.EngineerVisitCharges.EngineerVisitChargeSQL(Me)
            JobAudit = New Entity.JobAudits.JobAuditSQL(Me)
            InvoiceToBeRaised = New Entity.InvoiceToBeRaiseds.InvoiceToBeRaisedSQL(Me)
            EngineerVisitPartProductAllocated = New Entity.EngineerVisitPartProductAllocateds.EngineerVisitPartProductAllocatedSQL(Me)
            Invoiced = New Entity.Invoiceds.InvoicedSQL(Me)
            InvoicedLines = New Entity.InvoicedLiness.InvoicedLinesSQL(Me)
            ContractManager = New Entity.ContractManager.ContractManagerSQL(Me)
            SiteCustomerAudit = New Entity.SiteCustomerAudits.SiteCustomerAuditSQL(Me)
            EngineerVisitDefects = New Entity.EngineerVisitDefectss.EngineerVisitDefectsSQL(Me)
            EngineerVisitAssetWorkSheet = New Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetSQL(Me)
            VATRatesSQL = New Entity.VATRatess.VATRatesSQL(Me)
            StandardSentence = New Entity.StandardSentences.StandardSentenceSQL(Me)
            JobInstallSQL = New Entity.JobInstalls.JobInstallSQL(Me)
            EngineerVisitQCSQL = New Entity.EngineerVisitQCs.EngineerVisitQCSQL(Me)
            JobLock = New Entity.JobLock.JobLockSQL(Me)
            OrderConsolidations = New Entity.OrderConsolidations.OrderConsolidationSQL(Me)
            MaxEngineerTime = New Entity.MaxEngineerTimes.MaxEngineerTimeSQL(Me)
            ContractOriginalSiteRates = New Entity.ContractOriginalSiteRatess.ContractOriginalSiteRatesSQL(Me)
            PartsToBeCredited = New Entity.PartsToBeCrediteds.PartsToBeCreditedSQL(Me)
            SalesCredit = New Entity.SalesCredits.SalesCreditSQL(Me)
            EngineerTimesheets = New Entity.EngineerTimeSheets.EngineerTimeSheetSQL(Me)
            ImportValidation = New Importer.Validation.ValidationSQL(Me)

            LetterManager = New Entity.LetterManager.LetterManagerSQL(Me)
            EngineerVisitNCCGSR = New Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSRSQL(Me)
            EngineerVisitAdditional = New Entity.EngineerVisitAdditionals.EngineerVisitAdditionalSQL(Me)
            POInvoice = New Entity.Orders.POInvoiceSQL(Me)

            TabletOrders = New Entity.TabletOrders.TabletOrderSQL(Me)
            Reports = New Entity.Reports.ReportSQL(Me)
            EngineerVisitPhotos = New Entity.EngineerVisitPhotos.EngineerVisitPhotoSQL(Me)
            ContractVisits = New Entity.ContractOriginalVisits.ContractOriginalVisitSQL(Me)
            Appointments = New Entity.Appointments.AppointmentsSQL(Me)
            JobImports = New Entity.JobImport.JobImportSQL(Me)
            SunFinance = New Entity.Accounts.SunFinanceSQL(Me)
            Authority = New Entity.Authority.AuthoritySQL(Me)
            Skills = New Entity.Skills.SkillsSQL(Me)
            UserLevels = New Entity.UserLevels.UserLevelSQL(Me)
            CostCentre = New Entity.CostCentres.CostCentreSql(Me)
            CostCentreLinkType = New Entity.CostCentres.LinkTypes.LinkTypeSql(Me)
            EvEngineer = New Entity.EngineerVisits.EngineerVisitEngineers.EngineerVisitEngineerSql(Me)
            VanEquipments = New Entity.Vans.Equipments.EquipmentSql(Me)
            Ibc = New Ibc.IbcSql(Me)
            JobTypeColour = New Settings.Scheduler.JobTypeColourSql(Me)
            RagRating = New RagRating.RagRatingSql(Me)
            SiteSafteyAudit = New Engineers.SiteSafetyAudits.SiteSafetyAuditSql(Me)
            EngineerRole = New EngineerRoles.EngineerRoleSql(Me)
            ContactAttempts = New ContactAttempts.ContactAttemptSql(Me)
            CustomerAlert = New Customers.CustomerAlertSql(Me)
            CompanyDetails = New CompanyDetails.CompanyDetailsSql(Me)
        End Sub

#Region "Properties"

        Private _paggedQueryConnection As SqlConnection = Nothing

        Private Property PaggedQueryConnection() As SqlConnection
            Get
                Return _paggedQueryConnection
            End Get
            Set(ByVal Value As SqlConnection)
                _paggedQueryConnection = Value
            End Set
        End Property

        Private _serverConnection As Object = Nothing

        Private Property ServerConnection() As Object
            Get
                Return _serverConnection
            End Get
            Set(ByVal Value As Object)
                _serverConnection = Value
            End Set
        End Property

        Private _ServerConnectionString As String = ""

        Public Property ServerConnectionString() As String
            Get
                Return _ServerConnectionString
            End Get
            Set(ByVal value As String)
                _ServerConnectionString = value
            End Set
        End Property

        Private _command As Object = Nothing

        Private Property Command() As Object
            Get
                Return _command
            End Get
            Set(ByVal Value As Object)
                _command = Value
            End Set
        End Property

        Private _adapter As Object = Nothing

        Private Property Adapter() As Object
            Get
                Return _adapter
            End Get
            Set(ByVal Value As Object)
                _adapter = Value
            End Set
        End Property

#End Region

#Region "Classes"

        Public Manager As Entity.Management.ManagerSQL
        Public Picklists As Entity.PickLists.PickListSQL
        Public User As Entity.Users.UserSQL
        Public Customer As Entity.Customers.CustomerSQL
        Public Part As Entity.Parts.PartSQL
        Public Product As Entity.Products.ProductSQL
        Public Supplier As Entity.Suppliers.SupplierSQL
        Public PartSupplier As Entity.PartSuppliers.PartSupplierSQL
        Public ProductSupplier As Entity.ProductSuppliers.ProductSupplierSQL
        Public Sites As Entity.Sites.SiteSQL
        Public Engineer As Entity.Engineers.EngineerSQL
        Public Asset As Entity.Assets.AssetSQL
        Public Van As Entity.Vans.VanSQL
        Public Fleet As Entity.FleetVans.FleetSQL
        Public FleetVan As Entity.FleetVans.FleetVanSQL
        Public FleetVanType As Entity.FleetVans.FleetVanTypeSQL
        Public FleetVanEngineer As Entity.FleetVans.FleetVanEngineerSQL
        Public FleetVanMaintenance As Entity.FleetVans.FleetVanMaintenanceSQL
        Public FleetVanFault As Entity.FleetVans.FleetVanFaultSQL
        Public FleetVanContract As Entity.FleetVans.FleetVanContractSQL
        Public FleetVanService As Entity.FleetVans.FleetVanServiceSQL
        Public FleetVanEquipment As Entity.FleetVans.FleetVanEquipmentSQL
        Public FleetEquipment As Entity.FleetVans.FleetEquipmentSQL
        Public EngineerLevel As Entity.EngineerLevels.EngineerLevelSQL
        Public Documents As Entity.Documentss.DocumentsSQL
        Public Contact As Entity.Contacts.ContactSQL
        Public EngineerPostalRegion As Entity.EngineerPostalRegions.EngineerPostalRegionSQL
        Public Order As Entity.Orders.OrderSQL
        Public SupplierInvoices As Entity.Orders.SupplierInvoiceSQL
        Public OrderProduct As Entity.OrderProducts.OrderProductSQL
        Public OrderPart As Entity.OrderParts.OrderPartSQL
        Public SiteOrder As Entity.SiteOrders.SiteOrderSQL
        Public InvoiceAddress As Entity.InvoiceAddresss.InvoiceAddressSQL
        Public CustomerCharge As Entity.CustomerCharges.CustomerChargeSQL
        Public SubContractor As Entity.Subcontractors.SubcontractorSQL
        Public Area As Entity.Areas.AreaSQL
        Public Section As Entity.Sections.SectionSQL
        Public SubTask As Entity.SubTasks.SubTaskSQL
        Public Task As Entity.Tasks.TaskSQL
        Public Job As Entity.Jobs.JobSQL
        Public JobContact As Entity.JobContacts.JobContactSQL
        Public JobAsset As Entity.JobAssets.JobAssetSQL
        Public JobItems As Entity.JobItems.JobItemSQL
        Public JobOfWorks As Entity.JobOfWorks.JobOfWorkSQL
        Public EngineerVisits As Entity.EngineerVisits.EngineerVisitSQL
        Public Quotes As Entity.Quotes.QuotesSQL
        Public Warehouse As Entity.Warehouses.WarehouseSQL
        Public PartTransaction As Entity.PartTransactions.PartTransactionSQL
        Public StockTakeAudit As Entity.StockTakeAuditSQL
        Public ProductTransaction As Entity.ProductTransactions.ProductTransactionSQL
        Public ProductPriceRequest As Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequestSQL
        Public PartPriceRequest As Entity.PartSupplierPriceRequests.PartSupplierPriceRequestSQL
        Public OrderLocationPart As Entity.OrderLocationPart.OrderLocationPartSQL
        Public OrderLocationProduct As Entity.OrderLocationProduct.OrderLocationProductSQL
        Public Location As Entity.Locationss.LocationsSQL
        Public OrderLocation As Entity.OrderLocations.OrderLocationSQL
        Public QuoteJob As Entity.QuoteJobs.QuoteJobsSQL
        Public QuoteJobAsset As Entity.QuoteJobAssets.QuoteJobAssetSQL
        Public QuoteJobOfWorks As Entity.QuoteJobOfWorks.QuoteJobOfWorkSQL
        Public QuoteJobItems As Entity.QuoteJobItems.QuoteJobItemSQL
        Public QuoteEngineerVisits As Entity.QuoteEngineerVisits.QuoteEngineerVisitSQL
        Public EngineerVisitOrder As Entity.EngineerVisitOrders.EngineerVisitOrderSQL
        Public Scheduler As Entity.Scheduler.SchedulerSQL
        Public OrderCharge As Entity.OrderCharges.OrderChargeSQL
        Public CustomerOrder As Entity.CustomerOrders.CustomerOrderSQL
        Public QuoteOrder As Entity.QuoteOrders.QuoteOrderSQL
        Public QuoteOrderPart As Entity.QuoteOrderParts.QuoteOrderPartSQL
        Public QuoteOrderProduct As Entity.QuoteOrderProducts.QuoteOrderProductSQL
        Public QuoteJobParts As Entity.QuoteJobPartss.QuoteJobPartsSQL
        Public QuoteJobProducts As Entity.QuoteJobProductss.QuoteJobProductsSQL
        Public EngineerAbsence As Entity.EngineerAbsence.EngineerAbsenceSQL
        Public UserAbsence As Entity.UserAbsence.UserAbsenceSQL
        Public ContractOriginal As Entity.ContractsOriginal.ContractOriginalSQL
        Public ContractOriginalSite As Entity.ContractOriginalSites.ContractOriginalSiteSQL
        Public ContractOriginalSiteAsset As Entity.ContractOriginalSiteAssets.ContractOriginalSiteAssetSQL
        Public ContractOriginalPPMVisit As Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisitSQL
        Public QuoteContractOriginalPPMVisits As Entity.QuoteContractOriginalPPMVisits.QuoteContractOriginalPPMVisitSQL
        Public QuoteContractOriginalSite As Entity.QuoteContractOriginalSites.QuoteContractOriginalSiteSQL
        Public QuoteContractOriginalSiteAsset As Entity.QuoteContractOriginalSiteAssets.QuoteContractOriginalSiteAssetSQL
        Public QuoteContractOriginal As Entity.QuoteContractOriginals.QuoteContractOriginalSQL
        Public ContractAlternative As Entity.ContractsAlternative.ContractAlternativeSQL
        Public ContractAlternativeSite As Entity.ContractAlternativeSites.ContractAlternativeSiteSQL
        Public ContractAlternativeSiteAsset As Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAssetSQL
        Public ContractAlternativePPMVisit As Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisitSQL
        Public ContractAlternativeSiteJobItems As Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItemsSQL
        Public ContractAlternativeSiteJobOfWork As Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWorkSQL
        Public QuoteContractAlternativePPMVisits As Entity.QuoteContractAlternativePPMVisits.QuoteContractAlternativePPMVisitSQL
        Public QuoteContractAlternativeSite As Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSiteSQL
        Public QuoteContractAlternativeSiteAsset As Entity.QuoteContractAlternativeSiteAssets.QuoteContractAlternativeSiteAssetSQL
        Public QuoteContractAlternative As Entity.QuoteContractAlternatives.QuoteContractAlternativeSQL
        Public QuoteContractAlternativeSiteJobItems As Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItemsSQL
        Public QuoteContractAlternativeSiteJobOfWork As Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWorkSQL
        Public Notes As Entity.Notes.NotesSQL
        Public Checklists As Entity.CheckLists.CheckListSQL
        Public EngineerVisitsPartsAndProducts As Entity.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsSQL
        Public EngineerVisitsTimeSheet As Entity.EngineerVisitTimeSheets.EngineerVisitTimeSheetSQL
        Public ProductAssociatedPart As Entity.ProductAssociatedParts.ProductAssociatedPartSQL
        Public SystemScheduleOfRate As Entity.SystemScheduleOfRates.SystemScheduleOfRateSQL
        Public CustomerScheduleOfRate As Entity.CustomerScheduleOfRates.CustomerScheduleOfRateSQL
        Public EngineerVan As Entity.EngineerVans.EngineerVanSQL
        Public ContractOption3 As Entity.ContractOption3s.ContractOption3SQL
        Public ContractOption3Site As Entity.ContractOption3Sites.ContractOption3SiteSQL
        Public ContractOption3SiteAsset As Entity.ContractOption3SiteAsset.ContractOption3AssetSQL
        Public ContractOption3SitePPMVisit As Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisitSQL
        Public QuoteContractOption3 As Entity.QuoteContractOption3s.QuoteContractOption3SQL
        Public QuoteContractOption3Site As Entity.QuoteContractOption3Sites.QuoteContractOption3SiteSQL
        Public QuoteContractOption3SiteAssetDurations As Entity.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDurationSQL
        Public TimeSlotRates As Entity.TimeSlotRates.TimeSlotRatesSQL
        Public EngineerVisitCharge As Entity.EngineerVisitCharges.EngineerVisitChargeSQL
        Public JobAudit As Entity.JobAudits.JobAuditSQL
        Public InvoiceToBeRaised As Entity.InvoiceToBeRaiseds.InvoiceToBeRaisedSQL
        Public EngineerVisitPartProductAllocated As Entity.EngineerVisitPartProductAllocateds.EngineerVisitPartProductAllocatedSQL
        Public Invoiced As Entity.Invoiceds.InvoicedSQL
        Public InvoicedLines As Entity.InvoicedLiness.InvoicedLinesSQL
        Public ContractManager As Entity.ContractManager.ContractManagerSQL
        Public SiteCustomerAudit As Entity.SiteCustomerAudits.SiteCustomerAuditSQL
        Public EngineerVisitDefects As Entity.EngineerVisitDefectss.EngineerVisitDefectsSQL
        Public EngineerVisitAssetWorkSheet As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetSQL
        Public VATRatesSQL As Entity.VATRatess.VATRatesSQL
        Public StandardSentence As Entity.StandardSentences.StandardSentenceSQL
        Public EngineerVisitQCSQL As Entity.EngineerVisitQCs.EngineerVisitQCSQL
        Public JobInstallSQL As Entity.JobInstalls.JobInstallSQL
        Public JobLock As Entity.JobLock.JobLockSQL
        Public OrderConsolidations As Entity.OrderConsolidations.OrderConsolidationSQL
        Public MaxEngineerTime As Entity.MaxEngineerTimes.MaxEngineerTimeSQL
        Public ContractOriginalSiteRates As Entity.ContractOriginalSiteRatess.ContractOriginalSiteRatesSQL
        Public PartsToBeCredited As Entity.PartsToBeCrediteds.PartsToBeCreditedSQL
        Public SalesCredit As Entity.SalesCredits.SalesCreditSQL
        Public EngineerTimesheets As Entity.EngineerTimeSheets.EngineerTimeSheetSQL
        Public ImportValidation As Importer.Validation.ValidationSQL
        Public LetterManager As Entity.LetterManager.LetterManagerSQL
        Public EngineerVisitNCCGSR As Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSRSQL
        Public EngineerVisitAdditional As Entity.EngineerVisitAdditionals.EngineerVisitAdditionalSQL
        Public POInvoice As Entity.Orders.POInvoiceSQL
        Public TabletOrders As Entity.TabletOrders.TabletOrderSQL
        Public Reports As Entity.Reports.ReportSQL
        Public EngineerVisitPhotos As Entity.EngineerVisitPhotos.EngineerVisitPhotoSQL
        Public ContractVisits As Entity.ContractOriginalVisits.ContractOriginalVisitSQL
        Public Appointments As Entity.Appointments.AppointmentsSQL
        Public JobImports As Entity.JobImport.JobImportSQL
        Public SunFinance As Entity.Accounts.SunFinanceSQL
        Public Authority As Entity.Authority.AuthoritySQL
        Public Skills As Entity.Skills.SkillsSQL
        Public UserLevels As Entity.UserLevels.UserLevelSQL
        Public CostCentre As Entity.CostCentres.CostCentreSql
        Public CostCentreLinkType As Entity.CostCentres.LinkTypes.LinkTypeSql
        Public EvEngineer As Entity.EngineerVisits.EngineerVisitEngineers.EngineerVisitEngineerSql
        Public VanEquipments As Vans.Equipments.EquipmentSql
        Public Ibc As Ibc.IbcSql
        Public JobTypeColour As Settings.Scheduler.JobTypeColourSql
        Public RagRating As RagRating.RagRatingSql
        Public SiteSafteyAudit As Engineers.SiteSafetyAudits.SiteSafetyAuditSql
        Public EngineerRole As EngineerRoles.EngineerRoleSql
        Public ContactAttempts As ContactAttempts.ContactAttemptSql
        Public CustomerAlert As Customers.CustomerAlertSql
        Public CompanyDetails As CompanyDetails.CompanyDetailsSql

#End Region

#Region "Functions"

        Private Function OpenConnection() As Boolean
            Try
                If ServerConnection.State = ConnectionState.Closed Then
                    ServerConnection.Open()
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Function CloseConnection() As Boolean
            Try
                If ServerConnection.State = ConnectionState.Open Then
                    ServerConnection.Close()
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Sub ClearParameter()
            Select Case TheSystem.DataBaseServerType
                Case Enums.DatabaseSystems.MySQL
                    '     CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Clear()
                Case Enums.DatabaseSystems.Microsoft_SQL_Server
                    CType(Command, SqlClient.SqlCommand).Parameters.Clear()
            End Select
        End Sub

        Public Sub AddParameter(ByVal name As String, ByVal value As Object, Optional ByVal valueAsItIsSent As Boolean = False)
            Select Case TheSystem.DataBaseServerType
                Case Enums.DatabaseSystems.MySQL
                    Select Case name
                        Case "?Operator"
                            '          CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Add(name, value)
                        Case "?SearchFilter"
                            '           CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Add(name, value)
                        Case Else
                            '          CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Add(name, Entity.Sys.Helper.CleanText(value))
                    End Select
                Case Enums.DatabaseSystems.Microsoft_SQL_Server
                    Select Case name
                        Case "?Operator"
                            CType(Command, SqlClient.SqlCommand).Parameters.Add(name.Replace("?", "@"), value)
                        Case "?SearchFilter"
                            CType(Command, SqlClient.SqlCommand).Parameters.Add(name.Replace("?", "@"), value)
                        Case Else
                            If name.ToUpper = "@RETURN" Then
                                Dim returnParam As New SqlClient.SqlParameter("@RETURN", SqlDbType.Int)
                                returnParam.Direction = ParameterDirection.ReturnValue
                                CType(Command, SqlClient.SqlCommand).Parameters.Add(returnParam)
                            Else
                                If Not valueAsItIsSent Then
                                    CType(Command, SqlClient.SqlCommand).Parameters.Add(name.Replace("?", "@"), Entity.Sys.Helper.CleanText(value))
                                Else
                                    CType(Command, SqlClient.SqlCommand).Parameters.Add(name.Replace("?", "@"), value)
                                End If
                            End If
                    End Select
            End Select
        End Sub

        Public Function ExecuteCommand_DataTable(ByVal fileName As String, Optional ByVal recordInteraction As Boolean = True) As DataTable
            _command.CommandText = Entity.Sys.Helper.GetTextResource(fileName)

            Dim returnDT As DataTable = ExecuteWithReturn(BuildSQL, recordInteraction)

            Return returnDT
        End Function

        Public Sub ExecuteCommand_NO_Return(ByVal fileName As String, Optional ByVal recordInteraction As Boolean = True)
            _command.CommandText = Entity.Sys.Helper.GetTextResource(fileName)

            ExecuteWithOutReturn(BuildSQL, recordInteraction)
        End Sub

        Public Function ExecuteCommand_Object(ByVal fileName As String, Optional ByVal recordInteraction As Boolean = True) As Object
            _command.CommandText = Entity.Sys.Helper.GetTextResource(fileName)

            Return ExecuteScalar(BuildSQL, recordInteraction)
        End Function

        Public Function ExecuteSP_DataTable(ByVal SPName As String, Optional ByVal RecordTheInteraction As Boolean = True) As DataTable
            Try

                If Me.OpenConnection() Then
                    _command.CommandText = SPName
                    _command.CommandType = CommandType.StoredProcedure

                    Dim returnDT As New DataTable
                    Adapter.Fill(returnDT)
                    If RecordTheInteraction Then
                        RecordInteraction(SPName)
                    End If
                    Return returnDT
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Public Function ExecuteSP_DataSet(ByVal SPName As String, Optional ByVal RecordTheInteraction As Boolean = True) As DataSet
            Try

                If Me.OpenConnection() Then
                    _command.CommandText = SPName
                    _command.CommandType = CommandType.StoredProcedure

                    Dim returnDS As New DataSet
                    Adapter.Fill(returnDS)
                    If RecordTheInteraction Then
                        RecordInteraction(SPName)
                    End If
                    Return returnDS
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Public Function ExecuteSP_DataTable(ByVal spName As String,
                    ByVal ParamArray params() As SqlParameter) As DataTable

            Try
                If Me.OpenConnection() Then
                    _command.CommandText = spName
                    _command.CommandType = CommandType.StoredProcedure
                    _command.Parameters.Clear()

                    For Each p As SqlParameter In params
                        _command.Parameters.Add(p)
                    Next

                    Dim returnDT As New DataTable
                    Adapter.Fill(returnDT)

                    Return returnDT
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try

        End Function

        Public Function ExecuteSP_ReturnRowsAffected(ByVal SPName As String) As Integer
            Try
                If Me.OpenConnection() Then
                    _command.CommandText = SPName
                    _command.CommandType = CommandType.StoredProcedure

                    Return _command.ExecuteNonQuery()
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Public Function ExecuteCommand_DataTable(ByVal Command As SqlCommand) As DataTable

            Try

                Dim retryCount As Integer = 3
                Dim success As Boolean = False
                Dim returnDT As New DataTable

                While (retryCount > 0 And Not success)

                    Try
                        Dim da As New SqlDataAdapter(Command)

                        da.Fill(returnDT)
                        success = True
                    Catch exception As SqlException

                        If Not exception.Number = 1205 Then

                            'a sql exception that is not a deadlock
                            Throw
                        End If

                        retryCount = retryCount - 1

                        If (retryCount = 0) Then
                            Throw
                        End If

                    End Try

                End While

                Return returnDT
            Catch ex As Exception

                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)

            End Try

        End Function

        Public Sub ExecuteSP_NO_Return(ByVal SPName As String, Optional ByVal RecordTheInteraction As Boolean = True)
            Try
                If Me.OpenConnection() Then
                    _command.CommandText = SPName
                    _command.CommandType = CommandType.StoredProcedure

                    If SPName = "Parts_PreImportValidate" Then
                        CType(Command, SqlClient.SqlCommand).CommandTimeout = 2000
                    Else
                        CType(Command, SqlClient.SqlCommand).CommandTimeout = 400
                    End If

                    Command.Executenonquery()

                    If RecordTheInteraction Then
                        RecordInteraction(SPName)
                    End If
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Sub

        Public Function ExecuteSP_OBJECT(ByVal SPName As String, Optional ByVal RecordTheInteraction As Boolean = True) As Object
            Try
                If Me.OpenConnection() Then
                    _command.CommandText = SPName
                    _command.CommandType = CommandType.StoredProcedure
                    Dim oReturn As Object = Command.ExecuteScalar()

                    If RecordTheInteraction Then
                        RecordInteraction(SPName)
                    End If

                    _command.Parameters.Clear()
                    Return oReturn
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                    Return Nothing
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                Return Nothing
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Private Function BuildSQL() As String
            Dim sql As String = _command.CommandText

            Select Case TheSystem.DataBaseServerType
                Case Enums.DatabaseSystems.MySQL
                    'If CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters.Count > 0 Then
                    '    For Each sqlParameter As MySql.Data.MySqlClient.MySqlParameter In CType(Command, MySql.Data.MySqlClient.MySqlCommand).Parameters
                    '        If Not (sqlParameter.Value = "NULL") Then
                    '            If sqlParameter.ParameterName = "Operator" Then
                    '                sql = sql.Replace("?" & sqlParameter.ParameterName, sqlParameter.Value)
                    '            ElseIf sqlParameter.ParameterName = "SearchFilter" Then
                    '                sql = sql.Replace("?" & sqlParameter.ParameterName, sqlParameter.Value)
                    '            Else
                    '                sql = sql.Replace("?" & sqlParameter.ParameterName, "'" & sqlParameter.Value & "'")
                    '            End If
                    '        Else
                    '            sql = sql.Replace("?" & sqlParameter.ParameterName, "NULL")
                    '        End If
                    '    Next
                    'End If
                Case Enums.DatabaseSystems.Microsoft_SQL_Server
                    If CType(Command, SqlClient.SqlCommand).Parameters.Count > 0 Then
                        sql = sql.Replace("?", "@").Replace("`", "")
                        For Each sqlParameter As SqlClient.SqlParameter In CType(Command, SqlClient.SqlCommand).Parameters
                            If Not (sqlParameter.Value = "NULL") Then
                                If sqlParameter.ParameterName = "@Operator" Then
                                    sql = sql.Replace(sqlParameter.ParameterName, sqlParameter.Value)
                                ElseIf sqlParameter.ParameterName = "@SearchFilter" Then
                                    sql = sql.Replace(sqlParameter.ParameterName, sqlParameter.Value)
                                Else
                                    sql = sql.Replace(sqlParameter.ParameterName, "'" & sqlParameter.Value & "'")
                                End If
                            Else
                                sql = sql.Replace(sqlParameter.ParameterName, "NULL")
                            End If
                        Next
                    End If
            End Select

            Return sql
        End Function

        Public Function ExecuteWithReturn(ByVal sql As String, Optional ByVal RecordTheInteraction As Boolean = True) As DataTable
            Try
                If Me.OpenConnection() Then
                    Command.CommandText = sql
                    Command.CommandType = CommandType.Text
                    Dim returnDT As New DataTable
                    Adapter.Fill(returnDT)
                    If RecordTheInteraction Then
                        RecordInteraction(sql)
                    End If
                    Return returnDT
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Public Sub ExecuteWithOutReturn(ByVal sql As String, Optional ByVal RecordTheInteraction As Boolean = True)
            Try
                If Me.OpenConnection() Then
                    Command.CommandText = sql
                    Command.CommandType = CommandType.Text
                    Command.ExecuteNonQuery()
                    If RecordTheInteraction Then
                        RecordInteraction(sql)
                    End If
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Sub

        Public Function [ExecuteScalar](ByVal sql As String, ByVal trans As SqlTransaction, Optional ByVal RecordTheInteraction As Boolean = True) As Object
            Try
                If Me.OpenConnection() Then
                    Command.CommandText = sql
                    Command.CommandType = CommandType.Text
                    Command.Transaction = trans
                    Command.Connection = trans.Connection
                    Dim o As Object = Command.ExecuteScalar()
                    If RecordTheInteraction Then
                        RecordInteraction(sql)
                    End If
                    Return o
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Public Function [ExecuteScalar](ByVal sql As String, Optional ByVal RecordTheInteraction As Boolean = True, Optional ByVal clearParams As Boolean = False) As Object
            Try
                If Me.OpenConnection() Then
                    Try
                        If clearParams Then Command.Parameters.Clear()
                    Catch ex As Exception

                    End Try

                    Command.CommandText = sql
                    Command.CommandType = CommandType.Text
                    Dim o As Object = Command.ExecuteScalar()
                    If RecordTheInteraction Then
                        RecordInteraction(sql)
                    End If
                    Return o
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Public Function [SP_ExecuteScalar](ByVal sql As String, Optional ByVal RecordTheInteraction As Boolean = True) As Object
            Try
                If Me.OpenConnection() Then
                    Command.CommandText = sql
                    Command.CommandType = CommandType.StoredProcedure
                    Dim o As Object = Command.ExecuteScalar()
                    If RecordTheInteraction Then
                        RecordInteraction(sql)
                    End If
                    Return o
                Else
                    ShowMessage("Database cannot open", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                ShowMessage("Database Error : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
            Finally
                If Not Me.CloseConnection() Then
                    ShowMessage("Database cannot close", MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
                End If
            End Try
        End Function

        Private Function RecordInteraction(ByVal sql As String)
            'Try
            'Dim settings As Entity.Management.Settings = DB.Manager.Get()

            '    Dim WorkingHoursStart As New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursStart.Split(":")(0), settings.WorkingHoursStart.Split(":")(1), 0)

            '    Dim WorkingHoursEnd As New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursEnd.Split(":")(0), settings.WorkingHoursEnd.Split(":")(1), 0)

            '    Dim sf As New System.Diagnostics.StackFrame(3, True)
            '    Dim ClassAndMethod As String

            '    If sf.GetMethod.DeclaringType.Name.ToUpper.StartsWith("FRM") Then
            '        ClassAndMethod = FriendlyText(sf.GetMethod.DeclaringType.Name.Substring(3) _
            '                & "; " & sf.GetMethod.Name)
            '    Else
            '        ClassAndMethod = FriendlyText(sf.GetMethod.DeclaringType.Name _
            '                & "; " & sf.GetMethod.Name)
            '    End If

            '    Dim loggedInUserID As String
            '    If loggedInUser Is Nothing Then
            '        loggedInUserID = "0"
            '    Else
            '        loggedInUserID = CStr(loggedInUser.UserID)
            '    End If

            '    Dim outOfHours As String
            '    outOfHours = IIf(Now > WorkingHoursStart And Now < WorkingHoursEnd, "0", "1")

            '    Select Case sql.Trim.Split(" ")(0)
            '        Case "INSERT"
            '            DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'INSERT', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            '        Case "UPDATE"
            '            DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'UPDATE', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            '        Case "DELETE"
            '            DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'DELETE', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            '        Case "SELECT"
            '            DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'SELECT', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            '        Case Else
            '            DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES ('" & Entity.Sys.Helper.FormatDateTime_Save(Now()) & "', " & loggedInUserID & ", 'UNRECOGNISED', '" & Entity.Sys.Helper.CleanText(sql) & "', '" & ClassAndMethod & "'," & outOfHours & ")", False)
            '    End Select
            'Catch
            '    'DO NOTHING
            'End Try
        End Function

#Region "Async Calls"

        Public Async Function ExecuteAsync(ByVal spName As String, ParamArray parameters As SqlParameter()) As Task(Of Object)
            Using newConnection = New SqlConnection(TheSystem.Configuration.ConnectionString)
                Using newCommand = New SqlCommand(spName, newConnection)
                    newCommand.CommandType = CommandType.StoredProcedure
                    If parameters IsNot Nothing Then newCommand.Parameters.AddRange(parameters)
                    Await newConnection.OpenAsync().ConfigureAwait(False)
                    Return Await newCommand.ExecuteScalarAsync().ConfigureAwait(False)
                End Using
            End Using
        End Function

#End Region

#End Region

    End Class

End Namespace