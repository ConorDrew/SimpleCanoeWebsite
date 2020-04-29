namespace FSM.Entity
{
    namespace Sys
    {
        public class Enums
        {
            public enum DatabaseSystems
            {
                NONE = 0,
                MySQL = 1,
                Microsoft_SQL_Server = 2
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
                tblPickLists = 10,
                tblUserPermission = 11,
                tblCustomer = 12,
                tblPart = 13,
                tblProduct = 14,
                tblSupplier = 15,
                tblAsset = 16,
                tblEngineer = 17,
                tblMake = 18,
                tblModel = 19,
                tblType = 20,
                tblVan = 21,
                tblVisit = 22,
                tblRegion = 23,
                tblSite = 24,
                tblLocation = 25,
                tblEngineerLevel = 26,
                tblDocuments = 27,
                tblContact = 28,
                tblEngineerPostalRegion = 29,
                tblPartSupplier = 30,
                tblProductSupplier = 31,
                tblOrder = 32,
                tblSiteOrder = 33,
                tblInvoiceAddress = 34,
                tblCustomerCharge = 35,
                tblSiteCharge = 36,
                tblContract = 37,
                tblContractSite = 38,
                tblContractSiteAsset = 39,
                tblContractPPMVisit = 40,
                tblSubcontractor = 41,
                tblSubcontractorPostalRegion = 42,
                tblArea = 43, // DO NOT CHANGE ID FROM 43 - See Tony B
                tblSection = 44, // DO NOT CHANGE ID FROM 44 - See Tony B
                tblSubTask = 45, // DO NOT CHANGE ID FROM 45 - See Tony B
                tblTask = 46, // DO NOT CHANGE ID FROM 46 - See Tony B
                tblJob = 47,
                tblJobAsset = 48,
                tblJobItem = 49,
                tblEngineerVisit = 50,
                tblQuotes = 51,
                tblOrderPart = 52,
                tblOrderProduct = 53,
                tblQuoteContract = 54,
                tblQuoteContractSite = 55,
                tblQuoteContractSiteAsset = 56,
                tblQuoteContractPPMVisit = 57,
                tblWarehouse = 58,
                tblLocations = 59,
                tblOrderLocationPart = 60,
                tblOrderLocationProduct = 61,
                tblJobOfWork = 62,
                tblOrderLocation = 63,
                tblQuoteJobAssets = 64,
                tblQuoteJobOfWork = 65,
                tblQuoteJobItem = 66,
                tblQuoteEngineerVisit = 67,
                tblProductTransaction = 68,
                tblPartTransaction = 69,
                tblStock = 70,
                tblPartSupplierPriceRequest = 71,
                tblProductSupplierPriceRequest = 72,
                tblOrderCharge = 74,
                tblQuoteOrder = 75,
                tblQuoteOrderPart = 76,
                tblQuoteOrderProduct = 77,
                NOT_IN_DATABASE_PartsAndProducts = 78,
                NOT_IN_DATABASE_PriceRequests = 79,
                tblContractAlternativeSiteJobItems = 81,
                tblContractAlternativeSiteJobOfWork = 82,
                tblNotes = 83,
                NOT_IN_DATABASE_SuppliersForProduct = 84,
                NOT_IN_DATABASE_SuppliersForPart = 85,
                NOT_IN_DATABASE_VansForProduct = 86,
                NOT_IN_DATABASE_WarehouseForProduct = 87,
                NOT_IN_DATABASE_WarehouseForPart = 88,
                NOT_IN_DATABASE_VansForPart = 89,
                tblChecklists = 90,
                tblCheckListAnswers = 91,
                tblEngineerVisitTimesheet = 92,
                tblProductAssociatedPart = 93,
                tblSystemScheduleOfRate = 94,
                tblCustomerScheduleOfRate = 95,
                tblSiteScheduleOfRate = 96,
                tblEngineerVan = 97,
                tblQuoteContractOriginalSiteScheduleOfRates = 98,
                tblContractOption3 = 99,
                tblContractOption3Site = 100,
                tblContractOption3SiteAsset = 101,
                tblContractOption3SitePPMVisit = 102,
                tblQuoteContractOption3 = 103,
                tblQuoteContractOption3Site = 104,
                tblQuoteContractOption3SiteAsset = 105,
                tblTimeslotRates = 106,
                tblBankHolidays = 107,
                tblEngineerVisitAdditionalCharge = 108,
                tblEngineerVisitScheduleOfRateCharges = 109,
                tblEngineerVisitPartProductCharges = 110,
                tblEngineerVisitTimeSheetCharges = 111,
                tblJobAudit = 112,
                NOT_IN_DATABASE_TBLSearchOn = 113,
                NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated = 114,
                tblEngineerVisitProductAllocated = 115,
                tblInvoiceToBeRaised = 116,
                NOT_IN_DATABASE_tblInvoices = 117,
                tblInvoicedLines = 118,
                tblInvoiced = 119,
                NOT_IN_DATABASE_WarehousesAndVans = 120,
                tblInvoicedPaymentsReceived = 121,
                NOT_IN_DATABASE_PartsAndProductsAllocated = 122,
                tblInvoicedPaymentApplications = 123,
                NOT_IN_DATABASE_PartsAndProductsDistributed = 124,
                tblEngineerVisitAssetWorkSheet = 125,
                tblEngineerVisitDefects = 126,
                tblVATRates = 127,
                tblStandardSentences = 128,
                tblJobNotes = 129,
                tblSecurityUserModules = 130,
                tblJobLock = 131,
                tblPartLocations = 132,
                tblMaxEngineerTime = 133,
                tblContractOriginalSiteRates = 134,
                tblSiteNotes = 135,
                tblPartsToBeCredited = 136,
                NOT_IN_DATABASE_tblPicklists_BIN = 137,
                tblEngineerTimesheet = 138,
                tblIPTAudit = 139,
                tblEngineerVisitNCCGSR = 140,
                tblOrderSupplierInvoices = 141,
                tblPartCategoryMapping = 142,
                tblEngineerVisitPhoto = 143,
                tblEngineerVisitAdditionalChecks = 144,
                tblvan2 = 145,
                tblEquipment = 146,
                tblPartPack = 147,
                tblAppointments = 148,
                tblEquipmentAudit = 149,
                tblFleetVan = 150,
                tblFleetVanType = 151,
                tblFleetVanEngineer = 152,
                tblFleetVanAudit = 153,
                tblFleetVanMaintenance = 154,
                tblFleetVanFault = 154,
                tblFleetVanContract = 155,
                tblFleetEquipment = 156,
                tblFleetGarage = 157,
                tblFleetVanEquipment = 158,
                tblFleetJobType = 159,
                tblFleetReturnedVans = 160,
                tblEngineerSkills = 161,
                NOT_IN_Database_tblPartSupplierQty = 162,
                tblSiteFuel = 163,
                tblAuthority = 164,
                tblUserQualification = 165,
                tblEngineerRole = 166
            }

            public enum FormState
            {
                Load = 1,
                Insert = 2,
                Update = 3
            }

            public enum Region // added regions as these are static in DB
            {
                GaswayCommercial = 68517,
                National = 476,
                NonChargeable = 6429,
                NCC = 66662,
                PerAnglia = 67055,
                Flagship = 69818
            }

            public enum MenuImageTypes
            {
                NONE = 0,
                Unselected = 1,
                Selected = 2,
                Hover = 3
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
                POImporter = 10,
                POAuthorisation = 11,
                CreatePO = 12,
                EditPO = 13,
                CreateParts = 14,
                EditParts = 15,
                PartsOrderedImporter = 16,
                POUnlock = 17,
                IT = 18,
                AllFeatures = 19,
                Equipment = 20,
                Fleet = 21,
                Finance = 22,
                FSMAdmin = 23,
                Servicing = 24,
                Compliance = 25,
                Supervisor = 26,
                Export = 27,
                StockTake = 28,
                Voids = 29,
                Subcontractor = 30,
                Coordinator = 31,
                PDFEditor = 32,
                GSREditor = 33,
                JobWizard = 34,
                Qualifications = 35,
                VisitCharge = 36,
                MoveDownloadedVisit = 37,
                BetaFeatures = 38,
                Region = 39,
                SocialHousingSecurity = 40,
                NeopostPrint = 41,
                CustomerCharges = 42,
                AccountPeriod = 43
            }

            public enum AdditionalChecksTypes
            {
                SmokeAlarm = 68649,
                COMOAlarm = 68650,
                CommercialSiteChecksCP17 = 69108,
                CommercialStrengthTestCP16 = 69109,
                CommercialPurgingTestCP16 = 69110,
                CommercialTightnessTestCP16 = 69111,
                WorkInProgressAuditDomGASWork = 69318,
                PostCompleteAuditDomWork = 69319,
                EcoDanMaintenanceSheet = 69419,
                SolarThermalReport = 69424,
                WorkInProgressAuditDomesticOilWork = 69473,
                Quote = 69572,
                PropertyMaintenanceChecklist = 69591,
                WorkInProgressAuditCommercialGASWork = 69592,
                SaffronUnventedReport = 69902,
                CommercialCateringCP42 = 69903,
                MinorWorksSingleCircuitElecCert = 69995,
                VanChecklistWeekly = 70925,
                VanChecklistMonthly = 70926,
                RollingStockTake = 70927,
                CommissioningChecklist = 71482,
                ElectricalAudit = 71484,
                HotWorksPermit = 71914
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
                POImporter = 10,
                POAuthorisation = 11,
                FleetVan = 12
            }

            public enum ComboValues
            {
                None = 0,
                Please_Select = 1,
                Add_New = 2,
                Other = 3,
                No_Filter = 4,
                Off_The_Road = 5,
                Not_Applicable = 6,
                Dashes = 7,
                All_Appointments = 8,
                Please_Select_Negative = 9
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
                PostalRegions = 10, // DO NOT ADD ON THE MANAGER - THESE ARE BUILT ON SITE INSERT AND UPDATE
                JobTypes = 11,
                StockTransactionTypes = 12,
                QuoteRejectionReasons = 13,
                CustomerTypes = 14,
                OrderChargeTypes = 15,
                NoteCategory = 16,
                TimeSheetTypes = 17,
                ScheduleRatesCategories = 18,
                InvoiceAddressTypes = 19, // NOT ON MANAGER
                InvoiceTypes = 20, // NOT ON MANAGER
                PartCategories = 21, // NOT ON MANAGER (HAS ITS OWN FORM)
                PayGrades = 22,
                DisciplinaryStatus = 23,
                ContractTypes = 24, // NOT ON MANAGEr
                GasTypes = 25, // NOT ON MANAGER
                FlueTypes = 26,
                PassFailNA = 27,
                YesNo = 28,
                ApplianceServiced = 29,
                LLTenPriv = 30,
                Signature = 31,
                PaymentMethods = 32,
                DefectCategorys = 33,
                PartBinReferences = 34,
                PassFail = 35,
                EngineerGroup = 36,
                SourceOfCustomer = 37,
                DomesticCustomer = 38,
                YesNoNoButTested = 39,
                PartShelfReferences = 40,
                VATCodes = 41,
                ReasonsForContact = 42,
                NotTestedPassFailNA = 43,
                YesNoNA = 44,
                JOWPriority = 45,
                HeatingSystemType = 46,
                CylinderType = 47,
                Jacket = 48,
                CertificateType = 49,
                CancellationReasons = 50,
                ContractPricing = 52,
                Power = 55,
                TestType = 56,
                FTFCodes = 57,
                Recharge = 58,
                NccRad = 59,
                CoverPlanDiscounts = 60,
                YesNoNATab = 63,
                Symptoms = 64,
                InvoiceTerms = 65,
                PriceList = 71,
                ScheduleOfInspections = 79,
                EarthingArrangement = 80,
                NoOfPhases = 81,
                NominalVoltages = 82,
                SupplyProtectiveDevice = 83,
                SupplyProtectiveDeviceType = 84,
                MeansOfEarthing = 85,
                EarthElectrode = 86,
                ConductorMaterial = 87,
                ConductorCSA = 88,
                MainSwitchBSEN = 89,
                RefMethod = 91,
                CurcuitConductormm = 93,
                MaxDisconnectionTime = 94,
                OvercurrentBSEN = 95,
                OvercurrentTypeNo = 96,
                OvercurrentRating = 97,
                OvercurrentBreaking = 98,
                RCDOperatingCurrent = 99,
                EquipmentType = 105,
                EquipmentStatus = 106,
                Quote_Asbestos = 107,
                Quote_AccessEquipment = 108,
                Quote_Status = 109,
                SalesNominal = 110,
                PurchaseNominal = 111,
                MeterLocation = 112,
                Department = 113,
                SubTaxRate = 118,
                AlertTypes = 119,
                AccomType = 121,
                Relationship = 122
            }

            public enum Quote_JobStatus
            {
                Generated = 70902,
                Accepted = 70903,
                Rejected = 70904
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
                Van = 12,
                Contact = 13,
                Subcontractor = 18,
                Warehouse = 20,
                StockProfile = 25,
                Equipment = 26,
                PartPack = 27,
                FleetVan = 28,
                FleetVanType = 29,
                FleetEquipment = 30,
                UserQuals = 31
            }

            public enum CustomerStatus
            {
                NONE = 0,
                Active = 1,
                InActive = 2,
                OnHold = 3,
                Prospect = 4
            }

            public enum OrderStatus
            {
                AwaitingConfirmation = 1,
                Confirmed = 2,
                Cancelled = 3,
                Complete = 4,
                Invoiced = 5,
                Sent_To_Sage = 6,
                AwaitingApproval = 7
            }

            public enum OrderType
            {
                Customer = 1,
                StockProfile = 2,
                Warehouse = 3,
                Job = 4
            }

            public enum LocationType
            {
                Supplier = 1,
                Van = 2,
                Warehouse = 3
            }

            public enum ContractStatus
            {
                Active = 3,
                Inactive = 4,
                Cancelled = 5,
                InactiveUpgrade = 12,
                InactiveDowngrade = 13,
                InactiveTransferred = 14
            }

            public enum ContractPaymentType
            {
                Annual = 3,
                Direct_Debit = 4,
                AnnualDirectDebit = 5
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
                AnnualDD = 8 // Annual direct debit
            }

            public enum ContractRenewal
            {
                Renewed = 3,
                NotRenewed = 4
            }

            public enum ContractTypes
            {
                SilverStar = 367,
                GoldStar = 368,
                PlatinumStar = 369,
                PlatinumImmediate = 68032,
                TotallyAssured = 68294,
                PreventativeMaintenance = 69420,
                EmployeeFree = 68698,
                GoldStarAgency = 69173,
                PlatinumStarAgency = 69172,
                FamilyFree = 68696
            }

            public enum ContractInactiveReason
            {
                Transferred = 67883,
                Upgraded = 70995,
                Downgraded = 70996
            }

            public enum InvoiceFrequency
            {
                Weekly = 1,
                Monthly = 2,
                Quarterly = 3,
                Bi_Annually = 4,
                Annually = 6,
                Per_Visit = 7,
                AnnuallyDD = 9
            }

            public enum InvoiceFrequency_NoWeeK
            {
                Monthly = 2,
                GBS_4_Month_Visits = 8,
                Quarterly = 3,
                Bi_Annually = 4,
                Annually = 6,
                Per_Visit = 7,
                AnnuallyDD = 9
            }

            public enum VisitFrequency
            {
                Weekly = 3,
                Fortnightly = 9,
                Monthly = 4,
                GBS_4_Month_Visits = 8,
                Quarterly = 5,
                Bi_Annually = 6,
                Annually = 7
            }

            public enum ContractVisitType
            {
                Domestic = 3,
                Commercial = 4,
                Electrical = 5,
                SubContractor = 6
            }

            public enum JobDefinition
            {
                Quoted = 1,
                Contract = 2,
                Callout = 3,
                Misc = 4,
                ORDER = 100, // TONY B USING THIS TO AUTO CREATE ORDER NUMBER
                CONSOLIDATION = 101, // TONY B USING THIS TO AUTO CREATE ORDER NUMBER
                SERVICE_LETTER_JOB = 102 // USING THIS TO AUTO CREATE ORDER NUMBER
            }

            public enum JobStatus
            {
                NOT_SET = 0,
                Open = 1,
                Complete = 2
            }

            public enum VisitStatus
            {
                NOT_SET = 0,
                Parts_Need_Ordering = 1,
                Waiting_For_Parts = 2,
                Parts_Despatched = 3,
                Ready_For_Schedule = 4,
                Scheduled = 5,
                Downloaded = 6,
                Uploaded = 7,
                Not_To_Be_Invoiced = 8,
                Ready_To_Be_Invoiced = 9,
                Invoiced = 10
            }

            public enum EngineerVisitOutcomes
            {
                NOT_SET = 0,
                Complete = 1,
                Carded = 2,
                Could_Not_Start = 3,
                Declined = 4,
                Further_Works = 5,
                Visit_Not_Required = 6
            }

            public enum QuoteContractStatus
            {
                Generated = 1,
                Accepted = 2,
                Rejected = 3
            }

            public enum QuoteType
            {
                Contract_Opt_1 = 1,
                Contract_Opt_2 = 2,
                Job = 3,
                Contract_Opt_3 = 4
            }

            public enum Transaction
            {
                StockAdjustment = 1,
                StockIn = 2,
                StockOut = 3,
                StockTake = 4,
                StockReserve = 5
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
                ContractOption1 = 10,
                QuoteContractOption1 = 13,
                QuoteContractOption2 = 14,
                QuoteContractOption3 = 15,
                QuoteJob = 16,
                EngineerJobSheet = 17,
                EngineerJobSheetResults = 18,
                Job = 19,
                ContractExpiry = 20,
                GSRDue = 21,
                GSR = 22,
                JobCosting = 23,
                SVR = 24,
                Install = 25,
                SiteLetter = 26,
                PartCredit = 27,
                ConsolidationPickingList = 28,
                SupplierPurchaseOrder_WithDestination = 29,
                ServiceLetters = 30,
                GSRBatch = 31,
                ServiceLetterReport = 32,
                SupplierPurchaseOrderReplenishment = 33,
                AlphaPartCredit = 34,
                SVRNEW = 35,
                COMSR = 36,
                COMTANDP = 37,
                QCPrint = 38,
                SalesCredit = 39,
                ContractBatch = 40,
                ServiceLettersMK2 = 41,
                AdditionalInvoice = 42,
                ProForma = 43,
                JobSheet = 44,
                ElecMinor = 45,
                ComGSR = 46,
                DomGSR = 47,
                Warn = 48,
                ComCat = 49,
                SaffUnv = 50,
                PropMaint = 51,
                ASHP = 52,
                ProFormaFromVisit = 53, // New Proform used from visit form
                JobContactLetter = 54, // RFT - GW may use?
                Analyser = 55,
                JobImportLetters = 56,
                GSRASHPGSHP = 57,
                GSRHIU = 58,
                GSRUnvented = 59,
                PaymentReceipt = 60,
                CommissioningChecklist = 61,
                HotWorksPermit = 62
            }

            public enum LabourTypes
            {
                Basic = 1,
                Time_And_Half = 2,
                Double = 3
            }

            public enum TabletYesNoNA
            {
                Yes = 66597,
                No = 66598,
                NA = 66599
            }

            public enum NoteReminderStatus
            {
                Active = 1,
                Cancelled = 2
            }

            public enum ReminderFrequencies
            {
                Minutes = 1,
                Hours = 2,
                Days = 3,
                Weeks = 4,
                Months = 5,
                Years = 6
            }

            public enum PeriodType
            {
                NONE = 0,
                Days = 1,
                Weeks = 2,
                Months = 3,
                Years = 4
            }

            public enum ChecklistResults
            {
                NOT_SET = 0,
                Yes = 1,
                No = 2,
                NA = 3
            }

            public enum JobChargingType
            {
                JobValue = 1,
                QuoteValue = 2,
                NoChargeContractInvoice = 3,
                NoChargeMisc = 4,
                NoChargeCallout = 5,
                PercentageOfQuote = 6
            }

            public enum InvoiceReady
            {
                Not_Ready = 1,
                Ready = 2,
                Never = 3
            }

            public enum InvoiceType
            {
                Visit = 260,
                Order = 261,
                Contract_Option1 = 327,
                Contract_Option2 = 329,
                Contract_Option3 = 330
            }

            public enum InvoiceAddressType
            {
                Site = 253,
                HQ = 254,
                Invoice = 258
            }

            public enum DataBaseName
            {
                GaswayServicesFSM = 1,
                GaswayServicesFSM_Beta = 2,
                RftServicesFsm = 3,
                RftFsm_Beta = 4,
                BlueflameServicesFsm = 5,
                BlueflameServicesFsm_Beta = 6
            }

            public enum YesNoNA
            {
                Yes = 390,
                No = 391,
                NA = 393
            }

            public enum PartsToBeCreditedStatus
            {
                Awaiting_Part_Return = 1,
                Part_Returned_To_Supplier = 2,
                Credit_Req_Sent_To_Supplier = 3,
                Credit_Received = 3,
                Sent_To_Sage = 4,
                Credit_Req_Cancelled_By_Engineer = 6
            }

            public enum JobOfWorkStatus
            {
                Open = 1,
                Closed = 2,
                Complete = 3
            }

            public enum PartValidationResults
            {
                Unverified = 14,
                MatchNoChange = 1,
                MatchPriceUp = 2,
                MatchPriceDown = 3,
                DuplicatesFound = 4,
                NewForThisSupplier = 5,
                NewPart = 6,
                CategoryNotFound = 7,
                SupplierPartCodeMismatch = 8,
                SupplierDuplicate = 9,
                PartOnlyMatch = 10,
                SPNOnlyMatch = 11,
                MPNDuplicate = 12,
                GNU = 13,
                MissingExistingForSupplier = 15
            }

            public enum PartsInvoiceImportValidationResults
            {
                Unverified = 0,
                Replenishment = 1,
                UnableToLocatePO = 2,
                MatchedPOPriceCorrect = 3,
                MatchedPOPriceAbove = 4,
                MatchedPOPriceBelow = 5,
                PurchaseCredit = 6,
                SupplierInvoiceCreated = 7,
                MatchedPONoPartsIncluded = 8,
                MatchedPOSentToSage = 9,
                JobIncomplete = 10,
                Authorised = 11,
                MatchedPONoPartsIncludedUnableToMatchParts = 12,
                MatchedPOMultipleSuppliersFoundForPart = 13,
                SuppliersDoNotMatch = 14
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
                Processed = 10
            }

            public enum ReplenishmentStatusResults
            {
                AmountAboveOrEqualToMaxAndMinQuantities = 1,
                AmountAboveOrEqualToMinAndBelowMaxQuantities = 2,
                AmountBelowBothMinAndMaxQuantities = 3,
                QuantityOnOrderToReplenishStock = 4,
                NoPreferredSupplierFound = 5,
                AmountBelowMinQuantitiesStockOnOrder = 6,
                AmountBelowMinQuantitiesStockRequired = 7
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
                Anytime = 8
            }

            public enum AppointmentsPicklist
            {
                FirstCall = 69938,
                EightAmTillTwelvePm = 69939,
                TenAmTillTwoPm = 69940,
                TwelvePmTillFourPm = 69941,
                TwoPmTillSixPm = 69942,
                Am = 69943,
                Pm = 69944,
                Anytime = 69945
            }

            public enum JobLatnessTypes
            {
                OnTime = 0,
                SlightyLate = 1,
                VeryLate = 2
            }

            public enum Customer
            {
                Flagship = 5338,
                FlagshipMarketRented = 8306,
                FlagshipInstalls = 6705,
                NCC = 2846,
                WDC = 5155,
                Suffolk = 4703,
                SuffolkLeaseholder = 8135,
                Hastoe = 5853,
                Hastoe2 = 6341,
                Kier = 5385,
                CHS = 5545,
                Victory = 5872,
                CotmanHousing = 3174,
                CotmanRMG = 6413,
                Tendring = 6526,
                Saffron = 6561,
                Domestic = 787,
                Vehicle = 4401
            }

            public enum EquipmentStatus
            {
                IssedToEngineer = 70873,
                ReadyForIssue = 70940,
                SentToSupplier = 70941,
                ReadyForDispatch = 70942,
                OutOfCalibration = 70985
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
                Clean = 10,
                Maintenance = 11,
                InvalidMileage = 12
            }

            public enum FleetVanContractProcurementMethod
            {
                ContractHire = 1,
                HPDepn = 2,
                Hire = 3,
                Owned = 4,
                Leased = 5
            }

            public enum FleetJobTypes
            {
                VanMaintenance = 1,
                VanFault = 2
            }

            public enum QuoteJobOfWorkTypes
            {
                PaidWithThanks = 69481,
                StrcitlyThirtyDays = 69842,
                StrictlySevenDays = 69483,
                PaymentByReturn = 69484,
                Reciept = 69491,
                DirectDebitCollection = 69609,
                ProForma = 69817
            }

            public enum JobTypes
            {
                Breakdown = 4703,
                Commercial = 6041,
                CommercialInstallation = 71009,
                CommercialMaintenance = 71007,
                CommercialService = 71008,
                ContractualService = 71058,
                Dayworks = 67098,
                Installation = 521,
                KitchensBathrooms = 70952,
                LightInstallation = 4704,
                Plumbing = 4754,
                Private = 67166,
                QualityControl = 66971,
                Remedial = 484,
                RenewablesElectrical = 68121,
                Service = 519,
                ServiceCertificate = 4702,
                Survey = 68097,
                Commission = 71443,
                llCert = 4702
            }

            public enum JobPriority
            {
                PriortyOneFiveDays = 66981,
                Service = 66982,
                EMTwentyFourHours = 66983,
                RoutineOneTwentyDays = 66984,
                RCRecall = 66985,
                Dayworks = 67165,
                PriortyThreeDays = 67906,
                ApptTwentyEightDays = 68812,
                EMTwentyFourHoursOOH = 71111
            }

            public enum JobImportStatus
            {
                DidNotAttend = 0,
                Carded = 1,
                Complete = 2
            }

            public enum YesNo
            {
                Yes = 386,
                No = 387
            }

            public enum FuelTypes
            {
                NatGas = 377,
                LPG = 378,
                Electric = 486,
                Oil = 6027,
                SolidFuel = 69497,
                NA = 69498,
                AirSource = 71219,
                GroundSource = 71220
            }

            public enum WorksheetFuelTypes
            {
                Gas = 0,
                Oil = 1,
                SolidFuel = 2,
                Unvented = 3,
                Solar = 4,
                ASHP = 5,
                GSHP = 6,
                Other = 7,
                ComCat = 8,
                HIU = 9
            }

            public enum EngineerQual
            {
                CBUOC = 69698,
                SOLIDFUEL = 68877,
                OILOFTEC = 68889,
                DOMGAS = 68820,
                ASHP = 69743,
                RETAIL = 69697,
                AUDITOR = 71469
            }

            public enum JobCreationType
            {
                Manual = 0,
                LetterManager = 1,
                JobManager = 2,
                Tablet = 3
            }

            public enum ExportType
            {
                CSV = 1,
                XLS = 2
            }

            public enum CustomerType
            {
                Domestic = 475,
                Agency = 513,
                Manufacturer = 514,
                Commercial = 515,
                SocialHousing = 516,
                Insurance = 517,
                PrivateLandlord = 518,
                Unknown = 539,
                SubContractor = 4715,
                NonChargeable = 6430,
                GBS = 68552
            }

            public enum CertificateType
            {
                Reinstate = 67007,
                MutualExchange = 67008,
                District = 67009,
                FullGasService = 67018,
                SolidFuel = 67021,
                Electric = 67022
            }

            public enum TableCellProperties
            {
                ContractAppliance = 1
            }

            public enum CommisioningChecksEnums
            {
                RoomThermostatAndTimer = 71486,
                ProgrammableRoomThermostat = 71487,
                LoadWeatherCompensation = 71488,
                OptimumStartControl = 71489,
                CylinderThermostatAndTimer = 71490,
                Combi = 71491,
                Fitted = 71492,
                NotRequired = 71493
            }

            public enum TabletAction
            {
                RemoveFromTablet = 1,
                UpdateTime = 2
            }

            public enum AlertType
            {
                Jow = 71937,
                JobCreation = 71938
            }

            public enum DefectCategory
            {
                CurrentStandards = 403,
                AtRisk = 404,
                ImmediatelyDangerous = 405,
                Notes = 6061,
                PotentialRisk = 71685,
                ImmediateRisk = 71686
            }

            public enum PlVatRates
            {
                T0 = 72060,
                T1 = 5373,
                T9 = 66929
            }

            public enum Terms
            {
                POC = 69650,
                OTI30Days = 69651,
                OTI7Days = 69652,
                OTIByReturn = 69655
            }

            public enum UserType
            {
                User = 1,
                Engineer = 2
            }

            public enum TemplateType
            {
                ServiceLetter = 1,
                Eicr = 2
            }

            public enum JobItemPrice
            {
                BDOWN = 69669,
                BOILER = 69670,
                OILBLR = 69672,
                WARMAIR = 69673,
                STOREBLR = 69674,
                AIRANDSOL = 69675,
                GASFIRE = 69676,
                LRGUNIT = 69677,
                WATERHTR = 69678,
                UNVENT = 69679,
                UNVENTPLUS = 69680,
                CKR = 69681,
                RNGCKR = 69682,
                HOB = 69683,
                UNITHTR = 69684,
                NCCLEASE = 69685,
                LLCERT = 69686,
                BDOWNPLUS = 69687,
                BANDM = 69786,
                PLUM = 69787,
                COMM = 69788,
                ELEC = 69789,
                ADDAPP = 69923,
                BDOWNPLUSOIL = 71116
            }
        }
    }
}