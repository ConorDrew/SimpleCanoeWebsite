using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace FleetVans
    {
        public class FleetVan
        {
            private DataTypeValidator _dataTypeValidator;

            public FleetVan()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _VanID = 0;

            public int VanID
            {
                get
                {
                    return _VanID;
                }
            }

            public object SetVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VanID", value);
                }
            }

            private string _Registration = string.Empty;

            public string Registration
            {
                get
                {
                    return _Registration;
                }
            }

            public object SetRegistration
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Registration", value);
                }
            }

            private int _VanTypeID = 0;

            public int VanTypeID
            {
                get
                {
                    return _VanTypeID;
                }
            }

            public object SetVanTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VanTypeID", value);
                }
            }

            private int _Mileage = 0;

            public int Mileage
            {
                get
                {
                    return _Mileage;
                }
            }

            public object SetMileage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Mileage", value);
                }
            }

            private int _AverageMileage = 0;

            public int AverageMileage
            {
                get
                {
                    return _AverageMileage;
                }
            }

            public object SetAverageMileage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AverageMileage", value);
                }
            }

            private string _department = string.Empty;

            public string Department
            {
                get
                {
                    return _department;
                }
            }

            public object SetDepartment
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_department", value);
                }
            }

            private bool _Returned = Conversions.ToBoolean(0);

            public bool Returned
            {
                get
                {
                    return _Returned;
                }
            }

            public object SetReturned
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Returned", value);
                }
            }

            private string _Notes = string.Empty;

            public string Notes
            {
                get
                {
                    return _Notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Notes", value);
                }
            }

            private string _TyreSize = string.Empty;

            public string TyreSize
            {
                get
                {
                    return _TyreSize;
                }
            }

            public object SetTyreSize
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TyreSize", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }

        public class FleetVanType
        {
            private DataTypeValidator _dataTypeValidator;

            public FleetVanType()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _vanTypeID = 0;

            public int VanTypeID
            {
                get
                {
                    return _vanTypeID;
                }
            }

            public object SetVanTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanTypeID", value);
                }
            }

            private string _make = string.Empty;

            public string Make
            {
                get
                {
                    return _make;
                }
            }

            public object SetMake
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_make", value);
                }
            }

            private string _model = string.Empty;

            public string Model
            {
                get
                {
                    return _model;
                }
            }

            public object SetModel
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_model", value);
                }
            }

            private int _mileageServiceInterval = 0;

            public int MileageServiceInterval
            {
                get
                {
                    return _mileageServiceInterval;
                }
            }

            public object SetMileageServiceInterval
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_mileageServiceInterval", value);
                }
            }

            private int _dateServiceInterval = 0;

            public int DateServiceInterval
            {
                get
                {
                    return _dateServiceInterval;
                }
            }

            public object SetDateServiceInterval
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_dateServiceInterval", value);
                }
            }

            private double _GrossVehicleWeight = 0;

            public double GrossVehicleWeight
            {
                get
                {
                    return _GrossVehicleWeight;
                }
            }

            public object SetGrossVehicleWeight
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GrossVehicleWeight", value);
                }
            }

            private double _Payload = 0;

            public double Payload
            {
                get
                {
                    return _Payload;
                }
            }

            public object SetPayload
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Payload", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }

        public class FleetVanEngineer
        {
            private DataTypeValidator _dataTypeValidator;

            public FleetVanEngineer()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _vanEngineerID = 0;

            public int VanEngineerID
            {
                get
                {
                    return _vanEngineerID;
                }
            }

            public object SetVanEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanEngineerID", value);
                }
            }

            private int _vanID = 0;

            public int VanID
            {
                get
                {
                    return _vanID;
                }
            }

            public object SetVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanID", value);
                }
            }

            private int _engineerID = 0;

            public int EngineerID
            {
                get
                {
                    return _engineerID;
                }
            }

            public object SetEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_engineerID", value);
                }
            }

            private DateTime _startDate = default;

            public DateTime StartDate
            {
                get
                {
                    return _startDate;
                }

                set
                {
                    _startDate = value;
                }
            }

            private DateTime _endDate = default;

            public DateTime EndDate
            {
                get
                {
                    return _endDate;
                }

                set
                {
                    _endDate = value;
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }

        public class FleetVanMaintenance
        {
            private DataTypeValidator _dataTypeValidator;

            public FleetVanMaintenance()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _vanMaintenanceID = 0;

            public int VanMaintenanceID
            {
                get
                {
                    return _vanMaintenanceID;
                }
            }

            public object SetVanMaintenanceID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanMaintenanceID", value);
                }
            }

            private int _vanID = 0;

            public int VanID
            {
                get
                {
                    return _vanID;
                }
            }

            public object SetVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanID", value);
                }
            }

            private DateTime _lastService = default;

            public DateTime LastService
            {
                get
                {
                    return _lastService;
                }

                set
                {
                    _lastService = value;
                }
            }

            private DateTime _nextService = default;

            public DateTime NextService
            {
                get
                {
                    return _nextService;
                }

                set
                {
                    _nextService = value;
                }
            }

            private int _lastServiceMileage = 0;

            public int LastServiceMileage
            {
                get
                {
                    return _lastServiceMileage;
                }
            }

            public object SetLastServiceMileage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_lastServiceMileage", value);
                }
            }

            private DateTime _MOTExpiry = default;

            public DateTime MOTExpiry
            {
                get
                {
                    return _MOTExpiry;
                }

                set
                {
                    _MOTExpiry = value;
                }
            }

            private DateTime _taxExpiry = default;

            public DateTime RoadTaxExpiry
            {
                get
                {
                    return _taxExpiry;
                }

                set
                {
                    _taxExpiry = value;
                }
            }

            private string _breakdown = string.Empty;

            public string Breakdown
            {
                get
                {
                    return _breakdown;
                }
            }

            public object SetBreakdown
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_breakdown", value);
                }
            }

            private DateTime _warrantyExpiry = default;

            public DateTime WarrantyExpiry
            {
                get
                {
                    return _warrantyExpiry;
                }

                set
                {
                    _warrantyExpiry = value;
                }
            }

            private DateTime _breakdownExpiry = default;

            public DateTime BreakdownExpiry
            {
                get
                {
                    return _breakdownExpiry;
                }

                set
                {
                    _breakdownExpiry = value;
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }

        public class FleetVanFault
        {
            private DataTypeValidator _dataTypeValidator;

            public FleetVanFault()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _vanFaultID = 0;

            public int VanFaultID
            {
                get
                {
                    return _vanFaultID;
                }
            }

            public object SetVanFaultID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanFaultID", value);
                }
            }

            private int _vanID = 0;

            public int VanID
            {
                get
                {
                    return _vanID;
                }
            }

            public object SetVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanID", value);
                }
            }

            private int _faultTypeID = 0;

            public int FaultTypeID
            {
                get
                {
                    return _faultTypeID;
                }
            }

            public object SetFaultTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_faultTypeID", value);
                }
            }

            private DateTime _faultDate = default;

            public DateTime FaultDate
            {
                get
                {
                    return _faultDate;
                }

                set
                {
                    _faultDate = value;
                }
            }

            private DateTime _resolvedDate = default;

            public DateTime ResolvedDate
            {
                get
                {
                    return _resolvedDate;
                }

                set
                {
                    _resolvedDate = value;
                }
            }

            private string _engineerNotes = string.Empty;

            public string EngineerNotes
            {
                get
                {
                    return _engineerNotes;
                }
            }

            public object SetEngineerNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_engineerNotes", value);
                }
            }

            private string _notes = string.Empty;

            public string Notes
            {
                get
                {
                    return _notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_notes", value);
                }
            }

            private int _jobID = 0;

            public int JobID
            {
                get
                {
                    return _jobID;
                }
            }

            public object SetJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_jobID", value);
                }
            }

            private bool _archive = false;

            public bool Archive
            {
                get
                {
                    return _archive;
                }
            }

            public bool SetArchive
            {
                set
                {
                    _archive = value;
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }

        public class FleetVanContract
        {
            private DataTypeValidator _dataTypeValidator;

            public FleetVanContract()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _vanContractID = 0;

            public int VanContractID
            {
                get
                {
                    return _vanContractID;
                }
            }

            public object SetVanContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanContractID", value);
                }
            }

            private int _vanID = 0;

            public int VanID
            {
                get
                {
                    return _vanID;
                }
            }

            public object SetVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_vanID", value);
                }
            }

            private string _lessor = string.Empty;

            public string Lessor
            {
                get
                {
                    return _lessor;
                }
            }

            public object SetLessor
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_lessor", value);
                }
            }

            private int _procurementMethod = 0;

            public int ProcurementMethod
            {
                get
                {
                    return _procurementMethod;
                }
            }

            public object SetProcurementMethod
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_procurementMethod", value);
                }
            }

            private int _contractLength = 0;

            public int ContractLength
            {
                get
                {
                    return _contractLength;
                }
            }

            public object SetContractLength
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_contractLength", value);
                }
            }

            private DateTime _contractStart = default;

            public DateTime ContractStart
            {
                get
                {
                    return _contractStart;
                }

                set
                {
                    _contractStart = value;
                }
            }

            private DateTime _contractEnd = default;

            public DateTime ContractEnd
            {
                get
                {
                    return _contractEnd;
                }

                set
                {
                    _contractEnd = value;
                }
            }

            private int _contractMileage = 0;

            public int ContractMileage
            {
                get
                {
                    return _contractMileage;
                }
            }

            public object SetContractMileage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_contractMileage", value);
                }
            }

            private int _startingMileage = 0;

            public int StartingMileage
            {
                get
                {
                    return _startingMileage;
                }
            }

            public object SetStartingMileage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_startingMileage", value);
                }
            }

            private double _excessMileageRate = 0;

            public double ExcessMileageRate
            {
                get
                {
                    return _excessMileageRate;
                }
            }

            public object SetExcessMileageRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_excessMileageRate", value);
                }
            }

            private double _weeklyRental = 0;

            public double WeeklyRental
            {
                get
                {
                    return _weeklyRental;
                }
            }

            public object SetWeeklyRental
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_weeklyRental", value);
                }
            }

            private double _monthlyRental = 0;

            public double MonthlyRental
            {
                get
                {
                    return _monthlyRental;
                }
            }

            public object SetMonthlyRental
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_monthlyRental", value);
                }
            }

            private double _annualRental = 0;

            public double AnnualRental
            {
                get
                {
                    return _annualRental;
                }
            }

            public object SetAnnualRental
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_annualRental", value);
                }
            }

            private string _agreementRef = string.Empty;

            public string AgreementRef
            {
                get
                {
                    return _agreementRef;
                }
            }

            public object SetAgreementRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_agreementRef", value);
                }
            }

            private string _notes = string.Empty;

            public string Notes
            {
                get
                {
                    return _notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_notes", value);
                }
            }

            private double _excessMileageCost = 0;

            public double ExcessMileageCost
            {
                get
                {
                    return _excessMileageCost;
                }
            }

            public object SetExcessMileageCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_excessMileageCost", value);
                }
            }

            private double _forecastExcessMileageCost = 0;

            public double ForecastExcessMileageCost
            {
                get
                {
                    return _forecastExcessMileageCost;
                }
            }

            public object SetForecastExcessMileageCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_forecastExcessMileageCost", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }

        public class FleetEquipment
        {
            private DataTypeValidator _dataTypeValidator;

            public FleetEquipment()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _equipmentID = 0;

            public int EquipmentID
            {
                get
                {
                    return _equipmentID;
                }
            }

            public object SetEquipmentID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_equipmentID", value);
                }
            }

            private string _name = string.Empty;

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public object SetName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_name", value);
                }
            }

            private string _description = string.Empty;

            public string Description
            {
                get
                {
                    return _description;
                }
            }

            public object SetDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_description", value);
                }
            }

            private double _cost = 0;

            public double Cost
            {
                get
                {
                    return _cost;
                }
            }

            public object SetCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_cost", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}