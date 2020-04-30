using System;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;

namespace FSM.Entity
{
    namespace EngineerVisits
    {
        public class EngineerVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisit()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            
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

            
            
            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }

            private int _JobOfWorkID = 0;

            public int JobOfWorkID
            {
                get
                {
                    return _JobOfWorkID;
                }
            }

            public object SetJobOfWorkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobOfWorkID", value);
                }
            }

            private int _AppointmentID = 0;

            public int AppointmentID
            {
                get
                {
                    return _AppointmentID;
                }
            }

            public object SetAppointmentID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AppointmentID", value);
                }
            }

            private int _EngineerID = 0;

            public int EngineerID
            {
                get
                {
                    return _EngineerID;
                }
            }

            public object SetEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerID", value);
                }
            }

            private DateTime _StartDateTime = DateTime.MinValue;

            public DateTime StartDateTime
            {
                get
                {
                    return _StartDateTime;
                }

                set
                {
                    _StartDateTime = value;
                }
            }

            private DateTime _EndDateTime = DateTime.MinValue;

            public DateTime EndDateTime
            {
                get
                {
                    return _EndDateTime;
                }

                set
                {
                    _EndDateTime = value;
                }
            }

            private int _StatusEnumID = 0;

            public int StatusEnumID
            {
                get
                {
                    return _StatusEnumID;
                }
            }

            public object SetStatusEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_StatusEnumID", value);
                }
            }

            private string _NotesToEngineer = string.Empty;

            public string NotesToEngineer
            {
                get
                {
                    return _NotesToEngineer;
                }
            }

            public object SetNotesToEngineer
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NotesToEngineer", value);
                }
            }

            private string _NotesFromEngineer = string.Empty;

            public string NotesFromEngineer
            {
                get
                {
                    return _NotesFromEngineer;
                }
            }

            public object SetNotesFromEngineer
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NotesFromEngineer", value);
                }
            }

            private int _OutcomeEnumID = 0;

            public int OutcomeEnumID
            {
                get
                {
                    return _OutcomeEnumID;
                }
            }

            public object SetOutcomeEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OutcomeEnumID", value);
                }
            }

            private string _OutcomeDetails = string.Empty;

            public string OutcomeDetails
            {
                get
                {
                    return _OutcomeDetails;
                }
            }

            public object SetOutcomeDetails
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OutcomeDetails", value);
                }
            }

            private string _VisitOutcome = string.Empty;

            public string VisitOutcome
            {
                get
                {
                    return _VisitOutcome;
                }
            }

            public object SetVisitOutcome
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitOutcome", value);
                }
            }

            private string _CustomerName = string.Empty;

            public string CustomerName
            {
                get
                {
                    return _CustomerName;
                }
            }

            public object SetCustomerName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerName", value);
                }
            }

            private byte[] _CustomerSignature = null;

            public byte[] CustomerSignature
            {
                get
                {
                    return _CustomerSignature;
                }

                set
                {
                    _CustomerSignature = value;
                }
            }

            private byte[] _EngineerSignature = null;

            public byte[] EngineerSignature
            {
                get
                {
                    return _EngineerSignature;
                }

                set
                {
                    _EngineerSignature = value;
                }
            }

            // Private _CustomerSignature As String = String.Empty
            // Public ReadOnly Property CustomerSignature() As String
            // Get
            // Return _CustomerSignature
            // End Get
            // End Property
            // Public WriteOnly Property SetCustomerSignature() As Object
            // Set(ByVal Value As Object)
            // _dataTypeValidator.SetValue(Me, "_CustomerSignature", Value)
            // End Set
            // End Property

            // Private _EngineerSignature As String = String.Empty
            // Public ReadOnly Property EngineerSignature() As String
            // Get
            // Return _EngineerSignature
            // End Get
            // End Property
            // Public WriteOnly Property SetEngineerSignature() As Object
            // Set(ByVal Value As Object)
            // _dataTypeValidator.SetValue(Me, "_EngineerSignature", Value)
            // End Set
            // End Property

            private int _ManualEntryByUserID = 0;

            public int ManualEntryByUserID
            {
                get
                {
                    return _ManualEntryByUserID;
                }
            }

            public object SetManualEntryByUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ManualEntryByUserID", value);
                }
            }

            private DateTime _ManualEntryOn = DateTime.MinValue;

            public DateTime ManualEntryOn
            {
                get
                {
                    return _ManualEntryOn;
                }

                set
                {
                    _ManualEntryOn = value;
                }
            }

            private DataView _PartsAndProductsUsed = new DataView();

            public DataView PartsAndProductsUsed
            {
                get
                {
                    return _PartsAndProductsUsed;
                }

                set
                {
                    _PartsAndProductsUsed = value;
                }
            }

            private DataView _TimeSheets = new DataView();

            public DataView TimeSheets
            {
                get
                {
                    return _TimeSheets;
                }

                set
                {
                    _TimeSheets = value;
                }
            }

            private DataView _Photos = new DataView();

            public DataView Photos
            {
                get
                {
                    return _Photos;
                }

                set
                {
                    _Photos = value;
                }
            }

            private bool _visitLocked = false;

            public bool VisitLocked
            {
                get
                {
                    return _visitLocked;
                }
            }

            public bool SetVisitLocked
            {
                set
                {
                    _visitLocked = value;
                }
            }

            private DataView _PartsAndProductsAllocated = new DataView();

            public DataView PartsAndProductsAllocated
            {
                get
                {
                    return _PartsAndProductsAllocated;
                }

                set
                {
                    _PartsAndProductsAllocated = value;
                }
            }

            private int _GasInstallationTightnessTestID;

            public int GasInstallationTightnessTestID
            {
                get
                {
                    return _GasInstallationTightnessTestID;
                }
            }

            public object SetGasInstallationTightnessTestID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GasInstallationTightnessTestID", value);
                }
            }

            private int _PaymentMethodID;

            public int PaymentMethodID
            {
                get
                {
                    return _PaymentMethodID;
                }
            }

            public object SetPaymentMethodID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaymentMethodID", value);
                }
            }

            private double _AmountCollected;

            public double AmountCollected
            {
                get
                {
                    return _AmountCollected;
                }
            }

            public object SetAmountCollected
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AmountCollected", value);
                }
            }

            private int _EmergencyControlAccessibleID;

            public int EmergencyControlAccessibleID
            {
                get
                {
                    return _EmergencyControlAccessibleID;
                }
            }

            public object SetEmergencyControlAccessibleID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EmergencyControlAccessibleID", value);
                }
            }

            private int _BondingID;

            public int BondingID
            {
                get
                {
                    return _BondingID;
                }
            }

            public object SetBondingID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BondingID", value);
                }
            }

            private int _PropertyRented;

            public int PropertyRented
            {
                get
                {
                    return _PropertyRented;
                }
            }

            public object SetPropertyRented
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PropertyRented", value);
                }
            }

            private int _SignatureSelectedID;

            public int SignatureSelectedID
            {
                get
                {
                    return _SignatureSelectedID;
                }
            }

            public object SetSignatureSelectedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SignatureSelectedID", value);
                }
            }

            private bool _PartsToFit = false;

            public bool PartsToFit
            {
                get
                {
                    return _PartsToFit;
                }
            }

            public object SetPartsToFit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsToFit", value);
                }
            }

            private bool _GasServiceCompleted = false;

            public bool GasServiceCompleted
            {
                get
                {
                    return _GasServiceCompleted;
                }
            }

            public object SetGasServiceCompleted
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GasServiceCompleted", value);
                }
            }

            private bool _EmailReceipt = false;

            public bool EmailReceipt
            {
                get
                {
                    return _EmailReceipt;
                }
            }

            public object SetEmailReceipt
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EmailReceipt", value);
                }
            }

            private bool _UseSORDescription = false;

            public bool UseSORDescription
            {
                get
                {
                    return _UseSORDescription;
                }
            }

            public object SetUseSORDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UseSORDescription", value);
                }
            }

            private DateTime _Downloading;

            public DateTime Downloading
            {
                get
                {
                    return _Downloading;
                }

                set
                {
                    _Downloading = value;
                }
            }

            private int _ExpectedEngineerID = 0;

            public int ExpectedEngineerID
            {
                get
                {
                    return _ExpectedEngineerID;
                }
            }

            public object SetExpectedEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ExpectedEngineerID", value);
                }
            }

            private DateTime _DueDate;

            public DateTime DueDate
            {
                get
                {
                    return _DueDate;
                }

                set
                {
                    _DueDate = value;
                }
            }

            private DateTime _EstimatedDate = DateAndTime.Today;

            public DateTime EstimatedDate
            {
                get
                {
                    return _EstimatedDate;
                }

                set
                {
                    _EstimatedDate = value;
                }
            }

            private string _AMPM = string.Empty;

            public string AMPM
            {
                get
                {
                    return _AMPM;
                }
            }

            public object SetAMPM
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AMPM", value);
                }
            }

            private int _VisitNumber = 0;

            public int VisitNumber
            {
                get
                {
                    return _VisitNumber;
                }
            }

            public object SetVisitNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitNumber", value);
                }
            }

            private EngineerVisitNCCGSRs.EngineerVisitNCCGSR _EngineerVisitNCCGSR = null;

            public EngineerVisitNCCGSRs.EngineerVisitNCCGSR EngineerVisitNCCGSR
            {
                get
                {
                    return _EngineerVisitNCCGSR;
                }

                set
                {
                    _EngineerVisitNCCGSR = value;
                }
            }

            private EngineerVisitAdditionals.EngineerVisitAdditional _EngineerVisitSMOKE = null;

            public EngineerVisitAdditionals.EngineerVisitAdditional EngineerVisitSMOKE
            {
                get
                {
                    return _EngineerVisitSMOKE;
                }

                set
                {
                    _EngineerVisitSMOKE = value;
                }
            }

            private EngineerVisitAdditionals.EngineerVisitAdditional _EngineerVisitCOMO = null;

            public EngineerVisitAdditionals.EngineerVisitAdditional EngineerVisitCOMO
            {
                get
                {
                    return _EngineerVisitCOMO;
                }

                set
                {
                    _EngineerVisitCOMO = value;
                }
            }

            private EngineerVisitAdditionals.EngineerVisitAdditional _EngineerVisitAdditionalWorksheets = null;

            public EngineerVisitAdditionals.EngineerVisitAdditional EngineerVisitAdditionalWorksheets
            {
                get
                {
                    return _EngineerVisitAdditionalWorksheets;
                }

                set
                {
                    _EngineerVisitAdditionalWorksheets = value;
                }
            }

            private bool _Recharge = false;

            public bool Recharge
            {
                get
                {
                    return _Recharge;
                }
            }

            public object SetRecharge
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Recharge", value);
                }
            }

            private bool _excludeFromTextMessage = false;

            public bool ExcludeFromTextMessage
            {
                get
                {
                    return _excludeFromTextMessage;
                }
            }

            public object SetExcludeFromTextMessage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_excludeFromTextMessage", value);
                }
            }

            private string _CostsTo = string.Empty;

            public string CostsTo
            {
                get
                {
                    return _CostsTo;
                }
            }

            public object SetCostsTo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CostsTo", value);
                }
            }

            private int _RechargeTypeID;

            public int RechargeTypeID
            {
                get
                {
                    return _RechargeTypeID;
                }
            }

            public object setRechargeTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RechargeTypeID", value);
                }
            }

            private int _NccRadID;

            public int NccRadID
            {
                get
                {
                    return _NccRadID;
                }
            }

            public object setNccRadID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NccRadID", value);
                }
            }

            private bool _Change = false;

            public bool Change
            {
                get
                {
                    return _Change;
                }
            }

            public object setChange
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Change", value);
                }
            }

            private int _MeterCappedID;

            public int MeterCappedID
            {
                get
                {
                    return _MeterCappedID;
                }
            }

            public object SetMeterCappedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MeterCappedID", value);
                }
            }

            private int _MeterLocationID;

            public int MeterLocationID
            {
                get
                {
                    return _MeterLocationID;
                }
            }

            public object SetMeterLocationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MeterLocationID", value);
                }
            }

            private string _ExpectedDepartment = string.Empty;

            public string ExpectedDepartment
            {
                get
                {
                    return _ExpectedDepartment;
                }
            }

            public object SetExpectedDepartment
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ExpectedDepartment", value);
                }
            }

            private string _visitStatus = string.Empty;

            public string VisitStatus
            {
                get
                {
                    return _visitStatus;
                }
            }

            public object SetVisitStatus
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_visitStatus", value);
                }
            }

            private int _FuelID = 0;

            public int FuelID
            {
                get
                {
                    return _FuelID;
                }
            }

            public object SetFuelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FuelID", value);
                }
            }

            
        }
    }
}