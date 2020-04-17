// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.Enums
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

namespace FSM.Entity.Sys
{
    public class Enums
    {
        public enum DatabaseSystems
        {
            NONE,
            MySQL,
            Microsoft_SQL_Server,
        }

        public enum TableNames
        {
            NO_TABLE = 0,
            NOT_IN_DATABASE_DLLs = 1,
            tblVersion = 2,
            tblHistory = 3,
            NOT_IN_DATABASE_TBLPickListTypes = 4,
            tblSettings = 5,
            tblUser = 6,
            NOT_IN_DATABASE_TBLSearchFor = 7,
            NOT_IN_DATABASE_TBLSearchResults = 8,
            tblPermissionType = 9,
            tblPickLists = 10, // 0x0000000A
            tblUserPermission = 11, // 0x0000000B
            tblCustomer = 12, // 0x0000000C
            tblPart = 13, // 0x0000000D
            tblProduct = 14, // 0x0000000E
            tblSupplier = 15, // 0x0000000F
            tblAsset = 16, // 0x00000010
            tblEngineer = 17, // 0x00000011
            tblMake = 18, // 0x00000012
            tblModel = 19, // 0x00000013
            tblType = 20, // 0x00000014
            tblVan = 21, // 0x00000015
            tblVisit = 22, // 0x00000016
            tblRegion = 23, // 0x00000017
            tblSite = 24, // 0x00000018
            tblLocation = 25, // 0x00000019
            tblEngineerLevel = 26, // 0x0000001A
            tblDocuments = 27, // 0x0000001B
            tblContact = 28, // 0x0000001C
            tblEngineerPostalRegion = 29, // 0x0000001D
            tblPartSupplier = 30, // 0x0000001E
            tblProductSupplier = 31, // 0x0000001F
            tblOrder = 32, // 0x00000020
            tblSiteOrder = 33, // 0x00000021
            tblInvoiceAddress = 34, // 0x00000022
            tblCustomerCharge = 35, // 0x00000023
            tblSiteCharge = 36, // 0x00000024
            tblContract = 37, // 0x00000025
            tblContractSite = 38, // 0x00000026
            tblContractSiteAsset = 39, // 0x00000027
            tblContractPPMVisit = 40, // 0x00000028
            tblSubcontractor = 41, // 0x00000029
            tblSubcontractorPostalRegion = 42, // 0x0000002A
            tblArea = 43, // 0x0000002B
            tblSection = 44, // 0x0000002C
            tblSubTask = 45, // 0x0000002D
            tblTask = 46, // 0x0000002E
            tblJob = 47, // 0x0000002F
            tblJobAsset = 48, // 0x00000030
            tblJobItem = 49, // 0x00000031
            tblEngineerVisit = 50, // 0x00000032
            tblQuotes = 51, // 0x00000033
            tblOrderPart = 52, // 0x00000034
            tblOrderProduct = 53, // 0x00000035
            tblQuoteContract = 54, // 0x00000036
            tblQuoteContractSite = 55, // 0x00000037
            tblQuoteContractSiteAsset = 56, // 0x00000038
            tblQuoteContractPPMVisit = 57, // 0x00000039
            tblWarehouse = 58, // 0x0000003A
            tblLocations = 59, // 0x0000003B
            tblOrderLocationPart = 60, // 0x0000003C
            tblOrderLocationProduct = 61, // 0x0000003D
            tblJobOfWork = 62, // 0x0000003E
            tblOrderLocation = 63, // 0x0000003F
            tblQuoteJobAssets = 64, // 0x00000040
            tblQuoteJobOfWork = 65, // 0x00000041
            tblQuoteJobItem = 66, // 0x00000042
            tblQuoteEngineerVisit = 67, // 0x00000043
            tblProductTransaction = 68, // 0x00000044
            tblPartTransaction = 69, // 0x00000045
            tblStock = 70, // 0x00000046
            tblPartSupplierPriceRequest = 71, // 0x00000047
            tblProductSupplierPriceRequest = 72, // 0x00000048
            tblOrderCharge = 74, // 0x0000004A
            tblQuoteOrder = 75, // 0x0000004B
            tblQuoteOrderPart = 76, // 0x0000004C
            tblQuoteOrderProduct = 77, // 0x0000004D
            NOT_IN_DATABASE_PartsAndProducts = 78, // 0x0000004E
            NOT_IN_DATABASE_PriceRequests = 79, // 0x0000004F
            tblContractAlternativeSiteJobItems = 81, // 0x00000051
            tblContractAlternativeSiteJobOfWork = 82, // 0x00000052
            tblNotes = 83, // 0x00000053
            NOT_IN_DATABASE_SuppliersForProduct = 84, // 0x00000054
            NOT_IN_DATABASE_SuppliersForPart = 85, // 0x00000055
            NOT_IN_DATABASE_VansForProduct = 86, // 0x00000056
            NOT_IN_DATABASE_WarehouseForProduct = 87, // 0x00000057
            NOT_IN_DATABASE_WarehouseForPart = 88, // 0x00000058
            NOT_IN_DATABASE_VansForPart = 89, // 0x00000059
            tblChecklists = 90, // 0x0000005A
            tblCheckListAnswers = 91, // 0x0000005B
            tblEngineerVisitTimesheet = 92, // 0x0000005C
            tblProductAssociatedPart = 93, // 0x0000005D
            tblSystemScheduleOfRate = 94, // 0x0000005E
            tblCustomerScheduleOfRate = 95, // 0x0000005F
            tblSiteScheduleOfRate = 96, // 0x00000060
            tblEngineerVan = 97, // 0x00000061
            tblQuoteContractOriginalSiteScheduleOfRates = 98, // 0x00000062
            tblContractOption3 = 99, // 0x00000063
            tblContractOption3Site = 100, // 0x00000064
            tblContractOption3SiteAsset = 101, // 0x00000065
            tblContractOption3SitePPMVisit = 102, // 0x00000066
            tblQuoteContractOption3 = 103, // 0x00000067
            tblQuoteContractOption3Site = 104, // 0x00000068
            tblQuoteContractOption3SiteAsset = 105, // 0x00000069
            tblTimeslotRates = 106, // 0x0000006A
            tblBankHolidays = 107, // 0x0000006B
            tblEngineerVisitAdditionalCharge = 108, // 0x0000006C
            tblEngineerVisitScheduleOfRateCharges = 109, // 0x0000006D
            tblEngineerVisitPartProductCharges = 110, // 0x0000006E
            tblEngineerVisitTimeSheetCharges = 111, // 0x0000006F
            tblJobAudit = 112, // 0x00000070
            NOT_IN_DATABASE_TBLSearchOn = 113, // 0x00000071
            NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated = 114, // 0x00000072
            tblEngineerVisitProductAllocated = 115, // 0x00000073
            tblInvoiceToBeRaised = 116, // 0x00000074
            NOT_IN_DATABASE_tblInvoices = 117, // 0x00000075
            tblInvoicedLines = 118, // 0x00000076
            tblInvoiced = 119, // 0x00000077
            NOT_IN_DATABASE_WarehousesAndVans = 120, // 0x00000078
            tblInvoicedPaymentsReceived = 121, // 0x00000079
            NOT_IN_DATABASE_PartsAndProductsAllocated = 122, // 0x0000007A
            tblInvoicedPaymentApplications = 123, // 0x0000007B
            NOT_IN_DATABASE_PartsAndProductsDistributed = 124, // 0x0000007C
            tblEngineerVisitAssetWorkSheet = 125, // 0x0000007D
            tblEngineerVisitDefects = 126, // 0x0000007E
            tblVATRates = 127, // 0x0000007F
            tblStandardSentences = 128, // 0x00000080
            tblJobNotes = 129, // 0x00000081
            tblSecurityUserModules = 130, // 0x00000082
            tblJobLock = 131, // 0x00000083
            tblPartLocations = 132, // 0x00000084
            tblMaxEngineerTime = 133, // 0x00000085
            tblContractOriginalSiteRates = 134, // 0x00000086
            tblSiteNotes = 135, // 0x00000087
            tblPartsToBeCredited = 136, // 0x00000088
            NOT_IN_DATABASE_tblPicklists_BIN = 137, // 0x00000089
            tblEngineerTimesheet = 138, // 0x0000008A
            tblIPTAudit = 139, // 0x0000008B
            tblEngineerVisitNCCGSR = 140, // 0x0000008C
            tblOrderSupplierInvoices = 141, // 0x0000008D
            tblPartCategoryMapping = 142, // 0x0000008E
            tblEngineerVisitPhoto = 143, // 0x0000008F
            tblEngineerVisitAdditionalChecks = 144, // 0x00000090
            tblvan2 = 145, // 0x00000091
            tblEquipment = 146, // 0x00000092
            tblPartPack = 147, // 0x00000093
            tblAppointments = 148, // 0x00000094
            tblEquipmentAudit = 149, // 0x00000095
            tblFleetVan = 150, // 0x00000096
            tblFleetVanType = 151, // 0x00000097
            tblFleetVanEngineer = 152, // 0x00000098
            tblFleetVanAudit = 153, // 0x00000099
            tblFleetVanFault = 154, // 0x0000009A
            tblFleetVanMaintenance = 154, // 0x0000009A
            tblFleetVanContract = 155, // 0x0000009B
            tblFleetEquipment = 156, // 0x0000009C
            tblFleetGarage = 157, // 0x0000009D
            tblFleetVanEquipment = 158, // 0x0000009E
            tblFleetJobType = 159, // 0x0000009F
            tblFleetReturnedVans = 160, // 0x000000A0
            tblEngineerSkills = 161, // 0x000000A1
            NOT_IN_Database_tblPartSupplierQty = 162, // 0x000000A2
            tblSiteFuel = 163, // 0x000000A3
            tblAuthority = 164, // 0x000000A4
            tblUserQualification = 165, // 0x000000A5
            tblEngineerRole = 166, // 0x000000A6
        }

        public enum FormState
        {
            Load = 1,
            Insert = 2,
            Update = 3,
        }

        public enum Region
        {
            National = 476, // 0x000001DC
            NonChargeable = 6429, // 0x0000191D
            NCC = 66662, // 0x00010466
            PerAnglia = 67055, // 0x000105EF
            GaswayCommercial = 68517, // 0x00010BA5
            Flagship = 69818, // 0x000110BA
        }

        public enum MenuImageTypes
        {
            NONE,
            Unselected,
            Selected,
            Hover,
        }

        public enum SecuritySystemModules
        {
            None = 0,
            Customers = 1,
            Spares = 2,
            Staff = 3,
            Jobs = 4,
            Invoicing = 5,
            Reports = 6,
            Setup = 7,
            POImporter = 10, // 0x0000000A
            POAuthorisation = 11, // 0x0000000B
            CreatePO = 12, // 0x0000000C
            EditPO = 13, // 0x0000000D
            CreateParts = 14, // 0x0000000E
            EditParts = 15, // 0x0000000F
            PartsOrderedImporter = 16, // 0x00000010
            POUnlock = 17, // 0x00000011
            IT = 18, // 0x00000012
            AllFeatures = 19, // 0x00000013
            Equipment = 20, // 0x00000014
            Fleet = 21, // 0x00000015
            Finance = 22, // 0x00000016
            FSMAdmin = 23, // 0x00000017
            Servicing = 24, // 0x00000018
            Compliance = 25, // 0x00000019
            Supervisor = 26, // 0x0000001A
            Export = 27, // 0x0000001B
            StockTake = 28, // 0x0000001C
            Voids = 29, // 0x0000001D
            Subcontractor = 30, // 0x0000001E
            Coordinator = 31, // 0x0000001F
            PDFEditor = 32, // 0x00000020
            GSREditor = 33, // 0x00000021
            JobWizard = 34, // 0x00000022
            Qualifications = 35, // 0x00000023
            VisitCharge = 36, // 0x00000024
            MoveDownloadedVisit = 37, // 0x00000025
            BetaFeatures = 38, // 0x00000026
            Region = 39, // 0x00000027
            SocialHousingSecurity = 40, // 0x00000028
            NeopostPrint = 41, // 0x00000029
            CustomerCharges = 42, // 0x0000002A
        }

        public enum AdditionalChecksTypes
        {
            SmokeAlarm = 68649, // 0x00010C29
            COMOAlarm = 68650, // 0x00010C2A
            CommercialSiteChecksCP17 = 69108, // 0x00010DF4
            CommercialStrengthTestCP16 = 69109, // 0x00010DF5
            CommercialPurgingTestCP16 = 69110, // 0x00010DF6
            CommercialTightnessTestCP16 = 69111, // 0x00010DF7
            WorkInProgressAuditDomGASWork = 69318, // 0x00010EC6
            PostCompleteAuditDomWork = 69319, // 0x00010EC7
            EcoDanMaintenanceSheet = 69419, // 0x00010F2B
            SolarThermalReport = 69424, // 0x00010F30
            WorkInProgressAuditDomesticOilWork = 69473, // 0x00010F61
            Quote = 69572, // 0x00010FC4
            PropertyMaintenanceChecklist = 69591, // 0x00010FD7
            WorkInProgressAuditCommercialGASWork = 69592, // 0x00010FD8
            SaffronUnventedReport = 69902, // 0x0001110E
            CommercialCateringCP42 = 69903, // 0x0001110F
            MinorWorksSingleCircuitElecCert = 69995, // 0x0001116B
            VanChecklistWeekly = 70925, // 0x0001150D
            VanChecklistMonthly = 70926, // 0x0001150E
            RollingStockTake = 70927, // 0x0001150F
            CommissioningChecklist = 71482, // 0x0001173A
            ElectricalAudit = 71484, // 0x0001173C
            HotWorksPermit = 71914, // 0x000118EA
        }

        public enum MenuTypes
        {
            NONE = 0,
            Customers = 1,
            Spares = 2,
            Staff = 3,
            Jobs = 4,
            Invoicing = 5,
            Reports = 6,
            Setup = 7,
            POImporter = 10, // 0x0000000A
            POAuthorisation = 11, // 0x0000000B
            FleetVan = 12, // 0x0000000C
        }

        public enum ComboValues
        {
            None,
            Please_Select,
            Add_New,
            Other,
            No_Filter,
            Off_The_Road,
            Not_Applicable,
            Dashes,
            All_Appointments,
            Please_Select_Negative,
        }

        public enum PickListTypes
        {
            NONE = 0,
            Salutations = 1,
            Locations = 2,
            Regions = 3,
            Types = 4,
            Makes = 5,
            Models = 6,
            Engineer_Levels = 7,
            DocumentTypes = 8,
            UnitTypes = 9,
            PostalRegions = 10, // 0x0000000A
            JobTypes = 11, // 0x0000000B
            StockTransactionTypes = 12, // 0x0000000C
            QuoteRejectionReasons = 13, // 0x0000000D
            CustomerTypes = 14, // 0x0000000E
            OrderChargeTypes = 15, // 0x0000000F
            NoteCategory = 16, // 0x00000010
            TimeSheetTypes = 17, // 0x00000011
            ScheduleRatesCategories = 18, // 0x00000012
            InvoiceAddressTypes = 19, // 0x00000013
            InvoiceTypes = 20, // 0x00000014
            PartCategories = 21, // 0x00000015
            PayGrades = 22, // 0x00000016
            DisciplinaryStatus = 23, // 0x00000017
            ContractTypes = 24, // 0x00000018
            GasTypes = 25, // 0x00000019
            FlueTypes = 26, // 0x0000001A
            PassFailNA = 27, // 0x0000001B
            YesNo = 28, // 0x0000001C
            ApplianceServiced = 29, // 0x0000001D
            LLTenPriv = 30, // 0x0000001E
            Signature = 31, // 0x0000001F
            PaymentMethods = 32, // 0x00000020
            DefectCategorys = 33, // 0x00000021
            PartBinReferences = 34, // 0x00000022
            PassFail = 35, // 0x00000023
            EngineerGroup = 36, // 0x00000024
            SourceOfCustomer = 37, // 0x00000025
            DomesticCustomer = 38, // 0x00000026
            YesNoNoButTested = 39, // 0x00000027
            PartShelfReferences = 40, // 0x00000028
            VATCodes = 41, // 0x00000029
            ReasonsForContact = 42, // 0x0000002A
            NotTestedPassFailNA = 43, // 0x0000002B
            YesNoNA = 44, // 0x0000002C
            JOWPriority = 45, // 0x0000002D
            HeatingSystemType = 46, // 0x0000002E
            CylinderType = 47, // 0x0000002F
            Jacket = 48, // 0x00000030
            CertificateType = 49, // 0x00000031
            CancellationReasons = 50, // 0x00000032
            ContractPricing = 52, // 0x00000034
            Power = 55, // 0x00000037
            TestType = 56, // 0x00000038
            FTFCodes = 57, // 0x00000039
            Recharge = 58, // 0x0000003A
            NccRad = 59, // 0x0000003B
            CoverPlanDiscounts = 60, // 0x0000003C
            YesNoNATab = 63, // 0x0000003F
            Symptoms = 64, // 0x00000040
            InvoiceTerms = 65, // 0x00000041
            PriceList = 71, // 0x00000047
            ScheduleOfInspections = 79, // 0x0000004F
            EarthingArrangement = 80, // 0x00000050
            NoOfPhases = 81, // 0x00000051
            NominalVoltages = 82, // 0x00000052
            SupplyProtectiveDevice = 83, // 0x00000053
            SupplyProtectiveDeviceType = 84, // 0x00000054
            MeansOfEarthing = 85, // 0x00000055
            EarthElectrode = 86, // 0x00000056
            ConductorMaterial = 87, // 0x00000057
            ConductorCSA = 88, // 0x00000058
            MainSwitchBSEN = 89, // 0x00000059
            RefMethod = 91, // 0x0000005B
            CurcuitConductormm = 93, // 0x0000005D
            MaxDisconnectionTime = 94, // 0x0000005E
            OvercurrentBSEN = 95, // 0x0000005F
            OvercurrentTypeNo = 96, // 0x00000060
            OvercurrentRating = 97, // 0x00000061
            OvercurrentBreaking = 98, // 0x00000062
            RCDOperatingCurrent = 99, // 0x00000063
            EquipmentType = 105, // 0x00000069
            EquipmentStatus = 106, // 0x0000006A
            Quote_Asbestos = 107, // 0x0000006B
            Quote_AccessEquipment = 108, // 0x0000006C
            Quote_Status = 109, // 0x0000006D
            SalesNominal = 110, // 0x0000006E
            PurchaseNominal = 111, // 0x0000006F
            MeterLocation = 112, // 0x00000070
            Department = 113, // 0x00000071
            SubTaxRate = 118, // 0x00000076
            AlertTypes = 119, // 0x00000077
            AccomType = 121, // 0x00000079
            Relationship = 122, // 0x0000007A
        }

        public enum Quote_JobStatus
        {
            Generated = 70902, // 0x000114F6
            Accepted = 70903, // 0x000114F7
            Rejected = 70904, // 0x000114F8
        }

        public enum PageViewing
        {
            NONE = 0,
            Supplier = 1,
            Customer = 2,
            Product = 3,
            Part = 4,
            Property = 5,
            Engineer = 6,
            Asset = 7,
            Van = 12, // 0x0000000C
            Contact = 13, // 0x0000000D
            Subcontractor = 18, // 0x00000012
            Warehouse = 20, // 0x00000014
            StockProfile = 25, // 0x00000019
            Equipment = 26, // 0x0000001A
            PartPack = 27, // 0x0000001B
            FleetVan = 28, // 0x0000001C
            FleetVanType = 29, // 0x0000001D
            FleetEquipment = 30, // 0x0000001E
            UserQuals = 31, // 0x0000001F
        }

        public enum CustomerStatus
        {
            NONE,
            Active,
            InActive,
            OnHold,
            Prospect,
        }

        public enum OrderStatus
        {
            AwaitingConfirmation = 1,
            Confirmed = 2,
            Cancelled = 3,
            Complete = 4,
            Invoiced = 5,
            Sent_To_Sage = 6,
            AwaitingApproval = 7,
        }

        public enum OrderType
        {
            Customer = 1,
            StockProfile = 2,
            Warehouse = 3,
            Job = 4,
        }

        public enum LocationType
        {
            Supplier = 1,
            Van = 2,
            Warehouse = 3,
        }

        public enum ContractStatus
        {
            Active = 3,
            Inactive = 4,
            Cancelled = 5,
            InactiveUpgrade = 12, // 0x0000000C
            InactiveDowngrade = 13, // 0x0000000D
            InactiveTransferred = 14, // 0x0000000E
        }

        public enum ContractPaymentType
        {
            Annual = 3,
            Direct_Debit = 4,
            AnnualDirectDebit = 5,
        }

        public enum ContractInitialPaymentType
        {
            DebitCard = 1,
            CreditCard = 2,
            Cash = 3,
            Cheque = 4,
            Invoice = 5,
            BACS = 6,
            FOC = 7,
            AnnualDD = 8,
        }

        public enum ContractRenewal
        {
            Renewed = 3,
            NotRenewed = 4,
        }

        public enum ContractTypes
        {
            SilverStar = 367, // 0x0000016F
            GoldStar = 368, // 0x00000170
            PlatinumStar = 369, // 0x00000171
            PlatinumImmediate = 68032, // 0x000109C0
            TotallyAssured = 68294, // 0x00010AC6
            FamilyFree = 68696, // 0x00010C58
            EmployeeFree = 68698, // 0x00010C5A
            PlatinumStarAgency = 69172, // 0x00010E34
            GoldStarAgency = 69173, // 0x00010E35
            PreventativeMaintenance = 69420, // 0x00010F2C
        }

        public enum ContractInactiveReason
        {
            Transferred = 67883, // 0x0001092B
            Upgraded = 70995, // 0x00011553
            Downgraded = 70996, // 0x00011554
        }

        public enum InvoiceFrequency
        {
            Weekly = 1,
            Monthly = 2,
            Quarterly = 3,
            Bi_Annually = 4,
            Annually = 6,
            Per_Visit = 7,
            AnnuallyDD = 9,
        }

        public enum InvoiceFrequency_NoWeeK
        {
            Monthly = 2,
            Quarterly = 3,
            Bi_Annually = 4,
            Annually = 6,
            Per_Visit = 7,
            GBS_4_Month_Visits = 8,
            AnnuallyDD = 9,
        }

        public enum VisitFrequency
        {
            Weekly = 3,
            Monthly = 4,
            Quarterly = 5,
            Bi_Annually = 6,
            Annually = 7,
            GBS_4_Month_Visits = 8,
            Fortnightly = 9,
        }

        public enum ContractVisitType
        {
            Domestic = 3,
            Commercial = 4,
            Electrical = 5,
            SubContractor = 6,
        }

        public enum JobDefinition
        {
            Quoted = 1,
            Contract = 2,
            Callout = 3,
            Misc = 4,
            ORDER = 100, // 0x00000064
            CONSOLIDATION = 101, // 0x00000065
            SERVICE_LETTER_JOB = 102, // 0x00000066
        }

        public enum JobStatus
        {
            NOT_SET,
            Open,
            Complete,
        }

        public enum VisitStatus
        {
            NOT_SET,
            Parts_Need_Ordering,
            Waiting_For_Parts,
            Parts_Despatched,
            Ready_For_Schedule,
            Scheduled,
            Downloaded,
            Uploaded,
            Not_To_Be_Invoiced,
            Ready_To_Be_Invoiced,
            Invoiced,
        }

        public enum EngineerVisitOutcomes
        {
            NOT_SET,
            Complete,
            Carded,
            Could_Not_Start,
            Declined,
            Further_Works,
            Visit_Not_Required,
        }

        public enum QuoteContractStatus
        {
            Generated = 1,
            Accepted = 2,
            Rejected = 3,
        }

        public enum QuoteType
        {
            Contract_Opt_1 = 1,
            Contract_Opt_2 = 2,
            Job = 3,
            Contract_Opt_3 = 4,
        }

        public enum Transaction
        {
            StockAdjustment = 1,
            StockIn = 2,
            StockOut = 3,
            StockTake = 4,
            StockReserve = 5,
        }

        public enum SystemDocumentType
        {
            OrderConfirmation = 1,
            PartPurchaseEnquiry = 2,
            ProductPurchaseEnquiry = 3,
            PickingList = 4,
            SupplierPurchaseOrder = 5,
            DeliveryNote = 6,
            Quote = 7,
            Invoice = 8,
            ApplicationForPayment = 9,
            ContractOption1 = 10, // 0x0000000A
            QuoteContractOption1 = 13, // 0x0000000D
            QuoteContractOption2 = 14, // 0x0000000E
            QuoteContractOption3 = 15, // 0x0000000F
            QuoteJob = 16, // 0x00000010
            EngineerJobSheet = 17, // 0x00000011
            EngineerJobSheetResults = 18, // 0x00000012
            Job = 19, // 0x00000013
            ContractExpiry = 20, // 0x00000014
            GSRDue = 21, // 0x00000015
            GSR = 22, // 0x00000016
            JobCosting = 23, // 0x00000017
            SVR = 24, // 0x00000018
            Install = 25, // 0x00000019
            SiteLetter = 26, // 0x0000001A
            PartCredit = 27, // 0x0000001B
            ConsolidationPickingList = 28, // 0x0000001C
            SupplierPurchaseOrder_WithDestination = 29, // 0x0000001D
            ServiceLetters = 30, // 0x0000001E
            GSRBatch = 31, // 0x0000001F
            ServiceLetterReport = 32, // 0x00000020
            SupplierPurchaseOrderReplenishment = 33, // 0x00000021
            AlphaPartCredit = 34, // 0x00000022
            SVRNEW = 35, // 0x00000023
            COMSR = 36, // 0x00000024
            COMTANDP = 37, // 0x00000025
            QCPrint = 38, // 0x00000026
            SalesCredit = 39, // 0x00000027
            ContractBatch = 40, // 0x00000028
            ServiceLettersMK2 = 41, // 0x00000029
            AdditionalInvoice = 42, // 0x0000002A
            ProForma = 43, // 0x0000002B
            JobSheet = 44, // 0x0000002C
            ElecMinor = 45, // 0x0000002D
            ComGSR = 46, // 0x0000002E
            DomGSR = 47, // 0x0000002F
            Warn = 48, // 0x00000030
            ComCat = 49, // 0x00000031
            SaffUnv = 50, // 0x00000032
            PropMaint = 51, // 0x00000033
            ASHP = 52, // 0x00000034
            ProFormaFromVisit = 53, // 0x00000035
            JobContactLetter = 54, // 0x00000036
            Analyser = 55, // 0x00000037
            JobImportLetters = 56, // 0x00000038
            GSRASHPGSHP = 57, // 0x00000039
            GSRHIU = 58, // 0x0000003A
            GSRUnvented = 59, // 0x0000003B
            PaymentReceipt = 60, // 0x0000003C
            CommissioningChecklist = 61, // 0x0000003D
            HotWorksPermit = 62, // 0x0000003E
        }

        public enum LabourTypes
        {
            Basic = 1,
            Time_And_Half = 2,
            Double = 3,
        }

        public enum TabletYesNoNA
        {
            Yes = 66597, // 0x00010425
            No = 66598, // 0x00010426
            NA = 66599, // 0x00010427
        }

        public enum NoteReminderStatus
        {
            Active = 1,
            Cancelled = 2,
        }

        public enum ReminderFrequencies
        {
            Minutes = 1,
            Hours = 2,
            Days = 3,
            Weeks = 4,
            Months = 5,
            Years = 6,
        }

        public enum PeriodType
        {
            NONE,
            Days,
            Weeks,
            Months,
            Years,
        }

        public enum ChecklistResults
        {
            NOT_SET,
            Yes,
            No,
            NA,
        }

        public enum JobChargingType
        {
            JobValue = 1,
            QuoteValue = 2,
            NoChargeContractInvoice = 3,
            NoChargeMisc = 4,
            NoChargeCallout = 5,
            PercentageOfQuote = 6,
        }

        public enum InvoiceReady
        {
            Not_Ready = 1,
            Ready = 2,
            Never = 3,
        }

        public enum InvoiceType
        {
            Visit = 260, // 0x00000104
            Order = 261, // 0x00000105
            Contract_Option1 = 327, // 0x00000147
            Contract_Option2 = 329, // 0x00000149
            Contract_Option3 = 330, // 0x0000014A
        }

        public enum InvoiceAddressType
        {
            Site = 253, // 0x000000FD
            HQ = 254, // 0x000000FE
            Invoice = 258, // 0x00000102
        }

        public enum DataBaseName
        {
            GaswayServicesFSM = 1,
            GaswayServicesFSM_Beta = 2,
            RftServicesFsm = 3,
            RftFsm_Beta = 4,
            BlueflameServicesFsm = 5,
            BlueflameServicesFsm_Beta = 6,
        }

        public enum YesNoNA
        {
            Yes = 390, // 0x00000186
            No = 391, // 0x00000187
            NA = 393, // 0x00000189
        }

        public enum PartsToBeCreditedStatus
        {
            Awaiting_Part_Return = 1,
            Part_Returned_To_Supplier = 2,
            Credit_Received = 3,
            Credit_Req_Sent_To_Supplier = 3,
            Sent_To_Sage = 4,
            Credit_Req_Cancelled_By_Engineer = 6,
        }

        public enum JobOfWorkStatus
        {
            Open = 1,
            Closed = 2,
            Complete = 3,
        }

        public enum PartValidationResults
        {
            MatchNoChange = 1,
            MatchPriceUp = 2,
            MatchPriceDown = 3,
            DuplicatesFound = 4,
            NewForThisSupplier = 5,
            NewPart = 6,
            CategoryNotFound = 7,
            SupplierPartCodeMismatch = 8,
            SupplierDuplicate = 9,
            PartOnlyMatch = 10, // 0x0000000A
            SPNOnlyMatch = 11, // 0x0000000B
            MPNDuplicate = 12, // 0x0000000C
            GNU = 13, // 0x0000000D
            Unverified = 14, // 0x0000000E
            MissingExistingForSupplier = 15, // 0x0000000F
        }

        public enum PartsInvoiceImportValidationResults
        {
            Unverified,
            Replenishment,
            UnableToLocatePO,
            MatchedPOPriceCorrect,
            MatchedPOPriceAbove,
            MatchedPOPriceBelow,
            PurchaseCredit,
            SupplierInvoiceCreated,
            MatchedPONoPartsIncluded,
            MatchedPOSentToSage,
            JobIncomplete,
            Authorised,
            MatchedPONoPartsIncludedUnableToMatchParts,
            MatchedPOMultipleSuppliersFoundForPart,
            SuppliersDoNotMatch,
        }

        public enum PartsOrderedImportValidationResults
        {
            Unverified = 0,
            UnableToMatchPartToSupplier = 1,
            UnableToLocatePO = 2,
            PartAlreadyExistsOnPO = 3,
            NotTabletGeneratedOrder = 4,
            MultiplePOForOrderRef = 5,
            DuplicateSupplierParts = 6,
            Processed = 10, // 0x0000000A
        }

        public enum ReplenishmentStatusResults
        {
            AmountAboveOrEqualToMaxAndMinQuantities = 1,
            AmountAboveOrEqualToMinAndBelowMaxQuantities = 2,
            AmountBelowBothMinAndMaxQuantities = 3,
            QuantityOnOrderToReplenishStock = 4,
            NoPreferredSupplierFound = 5,
            AmountBelowMinQuantitiesStockOnOrder = 6,
            AmountBelowMinQuantitiesStockRequired = 7,
        }

        public enum Appointments
        {
            FirstCall = 1,
            EightAmTillTwelvePm = 2,
            TenAmTillTwoPm = 3,
            TwelvePmTillFourPm = 4,
            TwoPmTillSixPm = 5,
            Am = 6,
            Pm = 7,
            Anytime = 8,
        }

        public enum AppointmentsPicklist
        {
            FirstCall = 69938, // 0x00011132
            EightAmTillTwelvePm = 69939, // 0x00011133
            TenAmTillTwoPm = 69940, // 0x00011134
            TwelvePmTillFourPm = 69941, // 0x00011135
            TwoPmTillSixPm = 69942, // 0x00011136
            Am = 69943, // 0x00011137
            Pm = 69944, // 0x00011138
            Anytime = 69945, // 0x00011139
        }

        public enum JobLatnessTypes
        {
            OnTime,
            SlightyLate,
            VeryLate,
        }

        public enum Customer
        {
            Domestic = 787, // 0x00000313
            NCC = 2846, // 0x00000B1E
            CotmanHousing = 3174, // 0x00000C66
            Vehicle = 4401, // 0x00001131
            Suffolk = 4703, // 0x0000125F
            WDC = 5155, // 0x00001423
            Flagship = 5338, // 0x000014DA
            Kier = 5385, // 0x00001509
            CHS = 5545, // 0x000015A9
            Hastoe = 5853, // 0x000016DD
            Victory = 5872, // 0x000016F0
            Hastoe2 = 6341, // 0x000018C5
            CotmanRMG = 6413, // 0x0000190D
            Tendring = 6526, // 0x0000197E
            Saffron = 6561, // 0x000019A1
            FlagshipInstalls = 6705, // 0x00001A31
            SuffolkLeaseholder = 8135, // 0x00001FC7
            FlagshipMarketRented = 8306, // 0x00002072
        }

        public enum EquipmentStatus
        {
            IssedToEngineer = 70873, // 0x000114D9
            ReadyForIssue = 70940, // 0x0001151C
            SentToSupplier = 70941, // 0x0001151D
            ReadyForDispatch = 70942, // 0x0001151E
            OutOfCalibration = 70985, // 0x00011549
        }

        public enum FleetVanFaultType
        {
            Lights = 1,
            Tyres = 2,
            FluidLevel = 3,
            FluidLeaks = 4,
            Brakes = 5,
            ScreenMirrors = 6,
            Bodywork = 7,
            Seatbelt = 8,
            Racking = 9,
            Clean = 10, // 0x0000000A
            Maintenance = 11, // 0x0000000B
            InvalidMileage = 12, // 0x0000000C
        }

        public enum FleetVanContractProcurementMethod
        {
            ContractHire = 1,
            HPDepn = 2,
            Hire = 3,
            Owned = 4,
            Leased = 5,
        }

        public enum FleetJobTypes
        {
            VanMaintenance = 1,
            VanFault = 2,
        }

        public enum QuoteJobOfWorkTypes
        {
            PaidWithThanks = 69481, // 0x00010F69
            StrictlySevenDays = 69483, // 0x00010F6B
            PaymentByReturn = 69484, // 0x00010F6C
            Reciept = 69491, // 0x00010F73
            DirectDebitCollection = 69609, // 0x00010FE9
            ProForma = 69817, // 0x000110B9
            StrcitlyThirtyDays = 69842, // 0x000110D2
        }

        public enum JobTypes
        {
            Remedial = 484, // 0x000001E4
            Service = 519, // 0x00000207
            Installation = 521, // 0x00000209
            ServiceCertificate = 4702, // 0x0000125E
            llCert = 4702, // 0x0000125E
            Breakdown = 4703, // 0x0000125F
            LightInstallation = 4704, // 0x00001260
            Plumbing = 4754, // 0x00001292
            Commercial = 6041, // 0x00001799
            QualityControl = 66971, // 0x0001059B
            Dayworks = 67098, // 0x0001061A
            Private = 67166, // 0x0001065E
            Survey = 68097, // 0x00010A01
            RenewablesElectrical = 68121, // 0x00010A19
            KitchensBathrooms = 70952, // 0x00011528
            CommercialMaintenance = 71007, // 0x0001155F
            CommercialService = 71008, // 0x00011560
            CommercialInstallation = 71009, // 0x00011561
            ContractualService = 71058, // 0x00011592
            Commission = 71443, // 0x00011713
        }

        public enum JobPriority
        {
            PriortyOneFiveDays = 66981, // 0x000105A5
            Service = 66982, // 0x000105A6
            EMTwentyFourHours = 66983, // 0x000105A7
            RoutineOneTwentyDays = 66984, // 0x000105A8
            RCRecall = 66985, // 0x000105A9
            Dayworks = 67165, // 0x0001065D
            PriortyThreeDays = 67906, // 0x00010942
            ApptTwentyEightDays = 68812, // 0x00010CCC
            EMTwentyFourHoursOOH = 71111, // 0x000115C7
        }

        public enum JobImportStatus
        {
            DidNotAttend,
            Carded,
            Complete,
        }

        public enum YesNo
        {
            Yes = 386, // 0x00000182
            No = 387, // 0x00000183
        }

        public enum FuelTypes
        {
            NatGas = 377, // 0x00000179
            LPG = 378, // 0x0000017A
            Electric = 486, // 0x000001E6
            Oil = 6027, // 0x0000178B
            SolidFuel = 69497, // 0x00010F79
            NA = 69498, // 0x00010F7A
            AirSource = 71219, // 0x00011633
            GroundSource = 71220, // 0x00011634
        }

        public enum WorksheetFuelTypes
        {
            Gas,
            Oil,
            SolidFuel,
            Unvented,
            Solar,
            ASHP,
            GSHP,
            Other,
            ComCat,
            HIU,
        }

        public enum EngineerQual
        {
            DOMGAS = 68820, // 0x00010CD4
            SOLIDFUEL = 68877, // 0x00010D0D
            OILOFTEC = 68889, // 0x00010D19
            RETAIL = 69697, // 0x00011041
            CBUOC = 69698, // 0x00011042
            ASHP = 69743, // 0x0001106F
            AUDITOR = 71469, // 0x0001172D
        }

        public enum JobCreationType
        {
            Manual,
            LetterManager,
            JobManager,
            Tablet,
        }

        public enum ExportType
        {
            CSV = 1,
            XLS = 2,
        }

        public enum CustomerType
        {
            Domestic = 475, // 0x000001DB
            Agency = 513, // 0x00000201
            Manufacturer = 514, // 0x00000202
            Commercial = 515, // 0x00000203
            SocialHousing = 516, // 0x00000204
            Insurance = 517, // 0x00000205
            PrivateLandlord = 518, // 0x00000206
            Unknown = 539, // 0x0000021B
            SubContractor = 4715, // 0x0000126B
            NonChargeable = 6430, // 0x0000191E
            GBS = 68552, // 0x00010BC8
        }

        public enum CertificateType
        {
            Reinstate = 67007, // 0x000105BF
            MutualExchange = 67008, // 0x000105C0
            District = 67009, // 0x000105C1
            FullGasService = 67018, // 0x000105CA
            SolidFuel = 67021, // 0x000105CD
            Electric = 67022, // 0x000105CE
        }

        public enum TableCellProperties
        {
            ContractAppliance = 1,
        }

        public enum CommisioningChecksEnums
        {
            RoomThermostatAndTimer = 71486, // 0x0001173E
            ProgrammableRoomThermostat = 71487, // 0x0001173F
            LoadWeatherCompensation = 71488, // 0x00011740
            OptimumStartControl = 71489, // 0x00011741
            CylinderThermostatAndTimer = 71490, // 0x00011742
            Combi = 71491, // 0x00011743
            Fitted = 71492, // 0x00011744
            NotRequired = 71493, // 0x00011745
        }

        public enum TabletAction
        {
            RemoveFromTablet = 1,
            UpdateTime = 2,
        }

        public enum AlertType
        {
            Jow = 71937, // 0x00011901
            JobCreation = 71938, // 0x00011902
        }

        public enum DefectCategory
        {
            CurrentStandards = 403, // 0x00000193
            AtRisk = 404, // 0x00000194
            ImmediatelyDangerous = 405, // 0x00000195
            Notes = 6061, // 0x000017AD
            PotentialRisk = 71685, // 0x00011805
            ImmediateRisk = 71686, // 0x00011806
        }

        public enum PlVatRates
        {
            T1 = 5373, // 0x000014FD
            T9 = 66929, // 0x00010571
            T0 = 72060, // 0x0001197C
        }

        public enum Terms
        {
            POC = 69650, // 0x00011012
            OTI30Days = 69651, // 0x00011013
            OTI7Days = 69652, // 0x00011014
            OTIByReturn = 69655, // 0x00011017
        }

        public enum UserType
        {
            User = 1,
            Engineer = 2,
        }

        public enum TemplateType
        {
            ServiceLetter = 1,
        }

        public enum JobItemPrice
        {
            BDOWN = 69669, // 0x00011025
            BOILER = 69670, // 0x00011026
            OILBLR = 69672, // 0x00011028
            WARMAIR = 69673, // 0x00011029
            STOREBLR = 69674, // 0x0001102A
            AIRANDSOL = 69675, // 0x0001102B
            GASFIRE = 69676, // 0x0001102C
            LRGUNIT = 69677, // 0x0001102D
            WATERHTR = 69678, // 0x0001102E
            UNVENT = 69679, // 0x0001102F
            UNVENTPLUS = 69680, // 0x00011030
            CKR = 69681, // 0x00011031
            RNGCKR = 69682, // 0x00011032
            HOB = 69683, // 0x00011033
            UNITHTR = 69684, // 0x00011034
            NCCLEASE = 69685, // 0x00011035
            LLCERT = 69686, // 0x00011036
            BDOWNPLUS = 69687, // 0x00011037
            BANDM = 69786, // 0x0001109A
            PLUM = 69787, // 0x0001109B
            COMM = 69788, // 0x0001109C
            ELEC = 69789, // 0x0001109D
            ADDAPP = 69923, // 0x00011123
            BDOWNPLUSOIL = 71116, // 0x000115CC
        }
    }
}